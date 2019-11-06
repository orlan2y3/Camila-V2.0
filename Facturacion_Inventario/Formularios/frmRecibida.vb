Imports System.Data.OleDb

Public Class frmRecibida
    Dim Posicion As Integer

    Public Sub FormatGrid()
        dgvfactura.Rows.Clear()
        dgvfactura.ColumnCount = 4
        dgvfactura.Columns(0).HeaderText = "FECHA"
        dgvfactura.Columns(1).HeaderText = "NO. FACTURA"
        dgvfactura.Columns(2).HeaderText = "CLIENTE"
        dgvfactura.Columns(3).HeaderText = "TOTAL"

        dgvfactura.Columns(0).Width = 80
        dgvfactura.Columns(1).Width = 100
        dgvfactura.Columns(2).Width = 400
        dgvfactura.Columns(3).Width = 125

        ' desactivar los estilos visuales del sistema
        dgvfactura.EnableHeadersVisualStyles = False
        dgvfactura.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvfactura.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvfactura.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvfactura.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable

        dgvfactura.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvfactura.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        ' estilo para la cabecera del grid
        dgvfactura.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Sub ActualizaGrid()
        Try

            StrSql = "SELECT F.FECHA, F.ID_FACTURA, C.NOMBRE, F.TOTAL FROM FACTURA F, CLIENTES C" _
            & " WHERE F.FECHA >='" & Efecha(txtInicial.Text) & "' AND F.FECHA <='" & Efecha(txtFinal.Text) _
            & "' AND F.RECIBIDA ='N' AND F.ESTADO ='Normal' AND F.ID_CLIENTE = C.ID ORDER BY F.ID_FACTURA ASC"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                While objReader.Read()
                    dgvfactura.Rows.Add(Lfecha(objReader("fecha").ToString), objReader("id_factura"), objReader("nombre").ToString, FormatNumber(objReader("total"), 2))
                End While
                objReader.Close()
            Else
                objReader.Close()
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub frmRecibida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtInicial.Text = Format(Date.Today, "dd/MM/yyyy")
        txtFinal.Text = Format(Date.Today, "dd/MM/yyyy")
        btnBuscar.PerformClick()
        dgvfactura.Select()
    End Sub

    Private Sub txtInicial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInicial.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtFinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If FechaValida(txtInicial.Text) And FechaValida(txtFinal.Text) Then
            FormatGrid()
            ActualizaGrid()
            dgvfactura.Focus()
        Else
            MsgBox("Hay un error con las fecha, verifique", vbInformation)
            txtFinal.Focus()
            Return
        End If

    End Sub

    Private Sub dgvfactura_DoubleClick(sender As Object, e As EventArgs) Handles dgvfactura.DoubleClick
        Try
            If IsNothing(dgvfactura.CurrentRow.Cells(0).Value) Then
                Return
            End If

            If Not dgvfactura.CurrentRow.IsNewRow Then
                txtNoFact.Text = dgvfactura.Item(1, dgvfactura.CurrentRow.Index).Value
                txtCliente.Text = dgvfactura.Item(2, dgvfactura.CurrentRow.Index).Value
                txtMonto.Text = dgvfactura.Item(3, dgvfactura.CurrentRow.Index).Value
                btnOk.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try

            StrSql = "UPDATE FACTURA SET RECIBIDA ='S' WHERE ID_FACTURA =" & CLng(txtNoFact.Text)
            objCmd = New OleDbCommand(StrSql, Cnn)
            RA = objCmd.ExecuteNonQuery()
            If RA > 0 Then
                txtNoFact.Clear() : txtCliente.Clear() : txtMonto.Clear()
                btnBuscar.PerformClick()
            Else
                MsgBox("No fue posible registrar la factura como recibida", vbCritical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub dgvfactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvfactura.KeyPress
        Try

            If e.KeyChar = ChrW(Keys.Enter) Then

                Posicion = dgvfactura.CurrentCell.RowIndex - 1
                If Posicion = -1 Then
                    Return
                End If

                If IsNothing(dgvfactura.Item(0, Posicion).Value) Then
                    txtNoFact.Clear() : txtCliente.Clear() : txtMonto.Clear()
                    Return
                End If

                txtNoFact.Text = dgvfactura.Item(1, Posicion).Value
                txtCliente.Text = dgvfactura.Item(2, Posicion).Value
                txtMonto.Text = dgvfactura.Item(3, Posicion).Value
                btnOk.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        If FechaValida(txtInicial.Text) And FechaValida(txtFinal.Text) Then
            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\rptfacturasRecibidas.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")

            Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(txtInicial.Text) & "' AND {factura.fecha} <= '" & Efecha(txtFinal.Text) _
            & "' AND {factura.estado} = 'Normal'"
            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("DIRECCION").Text = "'" & DireccionEmp & "'"
            Rpt.DataDefinition.FormulaFields("RNC").Text = "' RNC: " & RncEmp & "'"
            Rpt.DataDefinition.FormulaFields("TELEFONO").Text = "' Tels: " & TelefonoEmp & "'"

            Rpt.DataDefinition.FormulaFields("fecha1").Text = "'" & txtInicial.Text & "'"
            Rpt.DataDefinition.FormulaFields("fecha2").Text = "'" & txtFinal.Text & "'"
            Rpt.DataDefinition.FormulaFields("nombre").Text = "'REPORTE  DE  FACTURAS  RECIBIDAS'"
            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.Show()
        End If
    End Sub
End Class