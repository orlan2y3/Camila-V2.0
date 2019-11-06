Imports System.Data.OleDb

Public Class frmReporteEstadoCuentas
    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Close()
    End Sub

    Private Sub btprint_Click(sender As Object, e As EventArgs) Handles btprint.Click
        Try

            StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA" _
            & " WHERE ID_CLIENTE =" & CLng(txtIdCliente.Text) & " AND ESTADO ='Normal' AND CONDICION ='Crédito' AND PAGADA ='N'"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If Not objReader.HasRows Then
                objReader.Close()
                MsgBox("No hay Facturas a Crédito por pagar de ese cliente", vbInformation)
                Return
            Else
                objReader.Close()
            End If

            Me.Cursor = Cursors.WaitCursor
            Dim Reporte As New Reportes
            Reporte.MdiParent = Me.MdiParent

            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            Rpt.Load(Application.StartupPath & "\rptFacturasCredito.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")

            Rpt.RecordSelectionFormula = "{factura.id_cliente} = " & CLng(txtIdCliente.Text) _
            & " AND {factura.estado} ='Normal' AND {factura.condicion} = 'Crédito' AND  {factura.pagada} ='N'"

            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"

            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.Show()
            Me.Cursor = Cursors.Default


        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If ListBox1.Visible = True Then
                If ListBox1.Items.Count > 0 Then
                    ListBox1.Focus()
                    ListBox1.SelectedIndex = 0
                End If
            End If
        End If
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        Try
            If Len(Trim(txtNombre.Text)) = 0 Then
                Return
            End If

            If Len(Trim(txtNombre.Text)) > 0 Then
                StrSql = "SELECT DISTINCT TOP 50 F.ID_CLIENTE, C.NOMBRE FROM FACTURA F, CLIENTES C" _
                & " WHERE F.CONDICION ='Crédito' AND F.PAGADA ='N' AND C.NOMBRE LIKE '" & Trim(txtNombre.Text) & "%' AND F.ID_CLIENTE = C.ID"
                objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    ListBox1.Visible = True
                    ListBox1.Items.Clear() : ListBox2.Items.Clear()
                    While objReader.Read
                        ListBox1.Items.Add(objReader("nombre").ToString)
                        ListBox2.Items.Add(objReader("id_cliente"))
                    End While
                    objReader.Close()
                Else
                    objReader.Close()
                End If
            Else
                txtNombreCompleto.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        If ListBox1.Items.Count > 0 Then
            ListBox2.SelectedIndex = ListBox1.SelectedIndex
            txtNombreCompleto.Text = ListBox1.SelectedItem
            txtIdCliente.Text = ListBox2.SelectedItem
            ListBox1.Visible = False
            txtNombre.Clear()
            btprint.Focus()
        End If
    End Sub

    Private Sub ListBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListBox1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If ListBox1.Items.Count > 0 Then
                ListBox2.SelectedIndex = ListBox1.SelectedIndex
                txtNombreCompleto.Text = ListBox1.SelectedItem
                txtIdCliente.Text = ListBox2.SelectedItem
                ListBox1.Visible = False
                txtNombre.Clear()
                btprint.Focus()
            End If
        End If
    End Sub

    Private Sub frmReporteEstadoCuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNombre.Select()
    End Sub

End Class