Imports System.Drawing.Printing
Imports System.Data.OleDb

Public Class frmReciboIngresos
    Dim Posicion As Integer
    Dim Pagado As Decimal = 0
    Dim DineroEnLetras As String = ""
    Dim Concepto As String = ""

    Public Sub FormatGrid()
        dgvCredito.Rows.Clear()
        dgvCredito.ColumnCount = 5
        dgvCredito.Columns(0).HeaderText = "NO. FACTURA"
        dgvCredito.Columns(1).HeaderText = "FECHA"
        dgvCredito.Columns(2).HeaderText = "MONTO"
        dgvCredito.Columns(3).HeaderText = "ABONADO"
        dgvCredito.Columns(4).HeaderText = "BALANCE"

        dgvCredito.Columns(0).Width = 100
        dgvCredito.Columns(1).Width = 80
        dgvCredito.Columns(2).Width = 100
        dgvCredito.Columns(3).Width = 100
        dgvCredito.Columns(4).Width = 100

        ' desactivar los estilos visuales del sistema
        dgvCredito.EnableHeadersVisualStyles = False
        dgvCredito.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvCredito.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvCredito.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvCredito.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvCredito.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable

        dgvCredito.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvCredito.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvCredito.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        dgvCredito.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
        dgvCredito.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
        dgvCredito.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight

        dgvCredito.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow

    End Sub

    Public Sub FormatGridPagos()
        dgvPagos.Rows.Clear()
        dgvPagos.ColumnCount = 4
        dgvPagos.Columns(0).HeaderText = "NO. FACTURA"
        dgvPagos.Columns(1).HeaderText = "MONTO"
        dgvPagos.Columns(2).HeaderText = "CONCEPTO"
        dgvPagos.Columns(3).HeaderText = "FECHA"

        dgvPagos.Columns(0).Width = 100
        dgvPagos.Columns(1).Width = 100
        dgvPagos.Columns(2).Width = 285
        dgvPagos.Columns(3).Width = 80

        ' desactivar los estilos visuales del sistema
        dgvPagos.EnableHeadersVisualStyles = False
        dgvPagos.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvPagos.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvPagos.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvPagos.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable

        dgvPagos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvPagos.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight

        dgvPagos.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow

    End Sub

    Sub ActualizaGridCredito()

        FormatGrid()

        Try

            StrSql = "SELECT ID_FACTURA,FECHA,TOTAL FROM FACTURA WHERE ID_CLIENTE =" & txtId.Text _
            & " AND CONDICION ='Crédito' AND PAGADA ='N' ORDER BY ID_FACTURA ASC"
            Da = New OleDbDataAdapter(StrSql, Cnn)
            Da.Fill(Ds, "facturas")
            If Ds.Tables("facturas").Rows.Count > 0 Then
                Dim Abonado, Balance As Decimal

                For Each factura In Ds.Tables("facturas").Rows
                    Abonado = 0 : Balance = 0

                    StrSql = "SELECT SUM(MONTO) AS TOTAL_ABONADO FROM PAGOS WHERE ID_FACTURA =" & factura("id_factura")
                    objCmd = New OleDbCommand(StrSql, Cnn)
                    objReader = objCmd.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        If IsNumeric(objReader("total_abonado")) Then
                            Abonado = objReader("total_abonado")
                        End If
                        objReader.Close()

                    Else
                        objReader.Close()
                    End If

                    Balance = factura("total") - Abonado

                    dgvCredito.Rows.Add(factura("id_factura"), Lfecha(factura("fecha")).ToString, factura("total"), Abonado, Balance)
                Next
                Ds.Clear()
            Else
                Ds.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Sub LlenaConcepto()
        cmbConcepto.Items.Clear()
        cmbConcepto.Items.Add("ABONO")
        cmbConcepto.Items.Add("SALDO FACTURA")
    End Sub

    Sub BuscarSecuenciaRecibos()
        Try
            StrSql = "SELECT sec FROM secuencia_recibos"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader()
            If objReader.HasRows Then
                objReader.Read()
                txtRecibo.Text = objReader("sec") + 1
                objReader.Close()
            Else
                objReader.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub frmReciboIngresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormatGrid()
        FormatGridPagos()
        LlenaConcepto()
        txtFechaPago.Text = Format(Today, "dd/MM/yyyy")
        BuscarSecuenciaRecibos()
    End Sub

    Private Sub dgvCredito_DoubleClick(sender As Object, e As EventArgs) Handles dgvCredito.DoubleClick
        If dgvCredito.Rows.Count = 0 Then
            Return
        End If

        Try

            txtFactura.Text = dgvCredito.Item(0, dgvCredito.CurrentRow.Index).Value
            txtFechaFact.Text = dgvCredito.Item(1, dgvCredito.CurrentRow.Index).Value
            txtMontoFact.Text = FormatNumber(dgvCredito.Item(2, dgvCredito.CurrentRow.Index).Value, 2)
            txtAbonado.Text = FormatNumber(dgvCredito.Item(3, dgvCredito.CurrentRow.Index).Value, 2)
            txtBalance.Text = FormatNumber(dgvCredito.Item(4, dgvCredito.CurrentRow.Index).Value, 2)
            txtMontoRecibido.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub txtMontoRecibido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoRecibido.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtConcepto_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtFechaPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFechaPago.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnOk.Focus()
        End If
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Close()
    End Sub

    Private Sub txtMontoRecibido_Leave(sender As Object, e As EventArgs) Handles txtMontoRecibido.Leave
        If IsNumeric(txtMontoRecibido.Text) Then
            txtMontoRecibido.Text = FormatNumber(txtMontoRecibido.Text, 2)
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If Len(Trim(txtFactura.Text)) = 0 Then
            MsgBox("Debe seleccionar la factura", vbInformation)
            txtMontoRecibido.Clear() : cmbConcepto.Items.Clear() : txtMontoRecibido.Focus()
            Return
        End If
        If Not IsNumeric(txtMontoRecibido.Text) Then
            MsgBox("El monto recibido debe ser numérico, verifique", vbInformation)
            txtMontoRecibido.Focus()
            Return
        ElseIf CDec(txtMontoRecibido.Text) <= 0 Then
            MsgBox("El monto recibido debe ser mayor que cero", vbInformation)
            txtMontoRecibido.Focus()
            Return
        End If
        If cmbConcepto.Text = "" Then
            MsgBox("Debe seleccionar el concepto del cobro", vbInformation)
            cmbConcepto.Focus()
            Return
        End If
        If FechaValida(txtFechaPago.Text) = False Then
            MsgBox("La fecha de pago no es valida, verifique", vbInformation)
            txtFechaPago.Focus()
            Return
        End If

        If CDec(txtMontoRecibido.Text) > CDec(txtBalance.Text) Then
            MsgBox("El monto recibido No puede ser mayor que el balance de la factura, verifique", vbInformation)
            txtMontoRecibido.Focus()
            Return
        End If
        If CDec(txtMontoRecibido.Text) = CDec(txtBalance.Text) Then
            If cmbConcepto.Text = "ABONO" Then
                MsgBox("Si el monto recibido es igual al balance, el concepto debe ser SALDO FACTURA", vbInformation)
                cmbConcepto.Focus()
                Return
            End If
        End If
        If CDec(txtMontoRecibido.Text) < CDec(txtBalance.Text) Then
            If cmbConcepto.Text = "SALDO FACTURA" Then
                MsgBox("Si el monto recibido es menor al balance, el concepto debe ser ABONO", vbInformation)
                cmbConcepto.Focus()
                Return
            End If
        End If

        Try

            If txtMontoRecibido.BackColor = Color.White Then
                For X = 0 To dgvPagos.Rows.Count - 1
                    If dgvPagos.Item(0, X).Value = txtFactura.Text Then
                        MsgBox("Ya registro pago a esa factura, verifique", vbInformation)
                        txtMontoRecibido.Clear() : LlenaConcepto()
                        txtMontoRecibido.Focus()
                        Return
                    End If
                Next
            End If

            If txtMontoRecibido.BackColor = Color.White Then
                dgvPagos.Rows.Add(txtFactura.Text, txtMontoRecibido.Text, cmbConcepto.Text, txtFechaPago.Text)
            Else
                dgvPagos.Item(0, Posicion).Value = Trim(txtFactura.Text)
                dgvPagos.Item(1, Posicion).Value = txtMontoRecibido.Text
                dgvPagos.Item(2, Posicion).Value = cmbConcepto.Text
                dgvPagos.Item(3, Posicion).Value = txtFechaPago.Text

                txtMontoRecibido.BackColor = Color.White
                cmbConcepto.BackColor = Color.White
                txtFechaPago.BackColor = Color.White
            End If

            txtFactura.Clear() : txtFechaFact.Clear() : txtMontoFact.Clear() : txtAbonado.Clear() : txtBalance.Clear()
            txtMontoRecibido.Clear() : LlenaConcepto()
            dgvCredito.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub dgvPagos_DoubleClick(sender As Object, e As EventArgs) Handles dgvPagos.DoubleClick
        If dgvPagos.Rows.Count = 0 Then
            Return
        End If

        Try

            txtFechaFact.Clear() : txtMontoFact.Clear() : txtAbonado.Clear() : txtBalance.Clear()
            txtMontoRecibido.BackColor = Color.Yellow
            cmbConcepto.BackColor = Color.Yellow
            txtFechaPago.BackColor = Color.Yellow

            Posicion = dgvPagos.CurrentRow.Index

            txtFactura.Text = dgvPagos.Item(0, dgvPagos.CurrentRow.Index).Value
            txtMontoRecibido.Text = dgvPagos.Item(1, dgvPagos.CurrentRow.Index).Value
            cmbConcepto.Text = dgvPagos.Item(2, dgvPagos.CurrentRow.Index).Value
            txtFechaPago.Text = dgvPagos.Item(3, dgvPagos.CurrentRow.Index).Value

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try

            If txtMontoRecibido.BackColor = Color.Yellow Then
                dgvPagos.Rows.RemoveAt(Posicion)

                txtMontoRecibido.BackColor = Color.White
                cmbConcepto.BackColor = Color.White
                txtFechaPago.BackColor = Color.White

                txtFactura.Clear() : txtFechaFact.Clear() : txtMontoFact.Clear() : txtAbonado.Clear() : txtBalance.Clear()
                txtMontoRecibido.Clear() : LlenaConcepto()
                txtMontoRecibido.Focus()

            Else

                txtMontoRecibido.Clear() : LlenaConcepto()
                txtMontoRecibido.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try

            If dgvPagos.Rows.Count <= 1 Then
                MsgBox("No hay pagos registrados, verifique", vbInformation)
                txtMontoRecibido.Focus()
                Return
            End If

            trans = Cnn.BeginTransaction : TA = True

            For X = 0 To dgvPagos.RowCount - 2
                StrSql = "INSERT INTO PAGOS(id_recibo, id_cliente, id_factura, monto, concepto, fecha_pago, fecha_ing, id_usuario)" _
                & " VALUES(" & CLng(txtRecibo.Text) & "," & CLng(txtId.Text) & "," & CLng(dgvPagos(0, X).Value) & "," & CDec(dgvPagos(1, X).Value) _
                & ",'" & dgvPagos(2, X).Value & "','" & Efecha(dgvPagos(3, X).Value) & "','" & Format(Today, "yyyy/MM/dd") _
                & "'," & IdUsuario & ")"
                objCmd = New OleDbCommand(StrSql, Cnn, trans)
                RA = objCmd.ExecuteNonQuery
                If RA <= 0 Then
                    trans.Rollback() : TA = False
                    MsgBox("No fue posible grabar la información", vbCritical)
                    Return
                Else
                    If dgvPagos(2, X).Value = "SALDO FACTURA" Then
                        StrSql = "UPDATE FACTURA SET PAGADA ='S' WHERE ID_FACTURA =" & CLng(dgvPagos(0, X).Value)
                        objCmd = New OleDbCommand(StrSql, Cnn, trans)
                        RA = objCmd.ExecuteNonQuery
                        If RA <= 0 Then
                            trans.Rollback() : TA = False
                            MsgBox("No fue posible actualizar la factura", vbCritical)
                            Return
                        End If
                    End If
                End If
            Next

            StrSql = "UPDATE secuencia_recibos Set sec = " & CLng(txtRecibo.Text)
            objCmd = New OleDbCommand(StrSql, Cnn, trans)
            RA = objCmd.ExecuteNonQuery()
            If RA <= 0 Then
                trans.Rollback() : TA = False
                MsgBox("Error actualiazando secuencia de recibo", MsgBoxStyle.Critical)
                Return
            End If

            trans.Commit() : TA = False

            Pagado = 0 : Concepto = "" : DineroEnLetras = ""

            StrSql = "SELECT SUM(MONTO) AS TOTAL FROM PAGOS WHERE ID_RECIBO =" & CLng(txtRecibo.Text)
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                Pagado = objReader("total")
                objReader.Close()
            Else
                objReader.Close()
            End If

            StrSql = "SELECT CONCEPTO FROM PAGOS WHERE ID_RECIBO =" & CLng(txtRecibo.Text)
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                Concepto = objReader("concepto").ToString
                objReader.Close()
            Else
                objReader.Close()
            End If

            DineroEnLetras = DineroLetras(Pagado)

            If dgvPagos.Rows.Count > 2 Then
                Concepto = "Pagos a facturas ..."
            End If

            '*************** I M P R E S I O N ****************************************************************
            If Impresora = "DE RECIBO" Then
                Dim printDoc As New PrintDocument
                AddHandler printDoc.PrintPage, AddressOf print_PrintPage

                For X = 1 To Copias
                    printDoc.Print()
                Next

                btnNuevo.Visible = True
                btnNuevo.PerformClick()
                btnNuevo.Visible = False
            Else

                Me.Cursor = Cursors.WaitCursor
                Dim Reporte As New Reportes
                Reporte.MdiParent = Me.MdiParent

                Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

                Rpt.Load(Application.StartupPath & "\rptReciboIngreso.rpt")

                Rpt.SetDatabaseLogon("admin", "cladatos-ao")
                Reporte.CrystalReportViewer1.ReportSource = Rpt

                Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
                Rpt.DataDefinition.FormulaFields("NoRecibo").Text = "'RECIBO DE INGRESO NO.  " & txtRecibo.Text & "'"
                Rpt.DataDefinition.FormulaFields("DineroLetra").Text = "'" & DineroEnLetras & "'"
                Rpt.DataDefinition.FormulaFields("Pagado").Text = "'" & Pagado & "'"
                Rpt.DataDefinition.FormulaFields("Concepto").Text = "'" & Concepto & "'"

                Reporte.CrystalReportViewer1.RefreshReport()
                Reporte.Show()
                Me.Cursor = Cursors.Default

                btnNuevo.Visible = True
                btnNuevo.PerformClick()
                btnNuevo.Visible = False

            End If

        Catch ex As Exception
            If TA = True Then
                trans.Rollback() : TA = False
            End If
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub print_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        '********** FUNCION PARA IMPRIMIR LA FACTURA *******************************

        ' Este evento se producirá cada vez que se imprima una nueva página

        'If Len(objReader("descripcion")) > 0 And Len(objReader("descripcion")) <= 33 Then
        '    xPos = 38
        '    e.Graphics.DrawString(objReader("descripcion"), prFont, Brushes.Black, xPos, yPos)
        'ElseIf Len(objReader("descripcion")) > 33 Then
        '    Dim Desc1 As String
        '    Dim Desc2 As String
        '    Desc1 = Mid(objReader("descripcion"), 1, 33)
        '    Desc2 = Mid(objReader("descripcion"), 34, 33)

        '    xPos = 38
        '    e.Graphics.DrawString(Desc1, prFont, Brushes.Black, xPos, yPos)

        '    yPos = yPos + 18
        '    e.Graphics.DrawString(Desc2, prFont, Brushes.Black, xPos, yPos)
        'End If

        Dim xPos As Single = 0 'margen izquierdo
        Dim yPos As Single = 50 'posición superior
        Dim prFont As New Font("Arial", 10, FontStyle.Regular)
        'Dim prFont As New Font("MS Gothic", 10, FontStyle.Regular)

        Try

            e.Graphics.DrawString(Empresa, prFont, Brushes.Black, xPos, yPos)

            yPos = yPos + 18
            e.Graphics.DrawString("Recibo de Ingreso No. " & txtRecibo.Text, prFont, Brushes.Black, xPos, yPos)

            yPos = yPos + 18
            e.Graphics.DrawString("Fecha: " & txtFechaPago.Text, prFont, Brushes.Black, xPos, yPos)

            yPos = yPos + 36
            e.Graphics.DrawString("No. Fact.     Concepto                  Valor", prFont, Brushes.Black, xPos, yPos)

            yPos = yPos + 18
            e.Graphics.DrawString("-------------------------------------------------------------", prFont, Brushes.Black, xPos, yPos)

            StrSql = "SELECT * FROM PAGOS WHERE ID_RECIBO =" & CLng(txtRecibo.Text)
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                While objReader.Read
                    xPos = 0
                    yPos = yPos + 18
                    e.Graphics.DrawString(objReader("id_factura"), prFont, Brushes.Black, xPos, yPos)

                    xPos = 78
                    e.Graphics.DrawString(objReader("concepto"), prFont, Brushes.Black, xPos, yPos)

                    xPos = 205
                    e.Graphics.DrawString(FormatNumber(objReader("monto"), 2), prFont, Brushes.Black, xPos, yPos)

                End While
                objReader.Close()
            Else
                objReader.Close()
            End If

            xPos = 0
            yPos = yPos + 18
            e.Graphics.DrawString("-------------------------------------------------------------", prFont, Brushes.Black, xPos, yPos)

            yPos = yPos + 36
            e.Graphics.DrawString("Hemos recibido de:", prFont, Brushes.Black, xPos, yPos)

            yPos = yPos + 18
            e.Graphics.DrawString(Trim(txtNombreCompleto.Text), prFont, Brushes.Black, xPos, yPos)

            yPos = yPos + 36
            e.Graphics.DrawString("La suma de:", prFont, Brushes.Black, xPos, yPos)

            xPos = 80
            e.Graphics.DrawString(FormatNumber(Pagado, 2), prFont, Brushes.Black, xPos, yPos)

            xPos = 0
            yPos = yPos + 18
            e.Graphics.DrawString("Por concepto de :  pagos a facturas", prFont, Brushes.Black, xPos, yPos)

            yPos = yPos + 36
            e.Graphics.DrawString(".", prFont, Brushes.Black, xPos, yPos)

            e.HasMorePages = False

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
            If dgvPagos.RowCount > 1 Then
                MsgBox("Todavia no ha grabado. Debe grabar o eliminar lo que ha registrado", vbCritical)
                txtNombre.Clear()
                Return
            End If

            If Len(Trim(txtNombre.Text)) > 0 Then
                StrSql = "SELECT DISTINCT(F.ID_CLIENTE), C.NOMBRE FROM FACTURA F, CLIENTES C" _
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
            txtId.Text = ListBox2.SelectedItem
            ListBox1.Visible = False
            ActualizaGridCredito()
            txtNombre.Clear()
            dgvCredito.Focus()
        End If
    End Sub

    Private Sub ListBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListBox1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If ListBox1.Items.Count > 0 Then
                ListBox2.SelectedIndex = ListBox1.SelectedIndex
                txtNombreCompleto.Text = ListBox1.SelectedItem
                txtId.Text = ListBox2.SelectedItem
                ListBox1.Visible = False
                ActualizaGridCredito()
                txtNombre.Clear()
                dgvCredito.Focus()
            End If
        End If
    End Sub

    Private Sub cmbConcepto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbConcepto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dgvCredito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvCredito.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtFactura.Text = dgvCredito.Item(0, dgvCredito.CurrentRow.Index - 1).Value
            txtFechaFact.Text = dgvCredito.Item(1, dgvCredito.CurrentRow.Index - 1).Value
            txtMontoFact.Text = FormatNumber(dgvCredito.Item(2, dgvCredito.CurrentRow.Index - 1).Value, 2)
            txtAbonado.Text = FormatNumber(dgvCredito.Item(3, dgvCredito.CurrentRow.Index - 1).Value, 2)
            txtBalance.Text = FormatNumber(dgvCredito.Item(4, dgvCredito.CurrentRow.Index - 1).Value, 2)
            txtMontoRecibido.Focus()
        End If
    End Sub

    Private Sub frmReciboIngresos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            btnGrabar.PerformClick()
        End If
    End Sub

    Private Sub frmReciboIngresos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If dgvPagos.RowCount > 1 Then
            If MsgBox("Todavia no ha grabado. Desea salir de todos modos", vbQuestion + vbYesNo + vbDefaultButton2) = vbNo Then
                e.Cancel = True
                Return
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        txtNombre.Clear()
        txtNombreCompleto.Clear()
        txtRecibo.Clear()

        FormatGrid()
        FormatGridPagos()
        LlenaConcepto()
        txtFechaPago.Text = Format(Today, "dd/MM/yyyy")
        BuscarSecuenciaRecibos()

        txtMontoRecibido.BackColor = Color.White
        cmbConcepto.BackColor = Color.White
        txtFechaPago.BackColor = Color.White

        txtFactura.Clear() : txtFechaFact.Clear() : txtMontoFact.Clear() : txtAbonado.Clear() : txtBalance.Clear()
        txtMontoRecibido.Clear() : LlenaConcepto()
        txtNombre.Select()

    End Sub
End Class