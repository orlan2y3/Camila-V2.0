Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class frmMantRecibo

    Public Sub FormatGridRecibos()
        dgvRecibos.Rows.Clear()
        dgvRecibos.ColumnCount = 6
        dgvRecibos.Columns(0).HeaderText = "FECHA PAGO"
        dgvRecibos.Columns(1).HeaderText = "NO. RECIBO"
        dgvRecibos.Columns(2).HeaderText = "MONTO"
        dgvRecibos.Columns(3).HeaderText = "CONCEPTO"
        dgvRecibos.Columns(4).HeaderText = "ID PAGO"
        dgvRecibos.Columns(5).HeaderText = "ANULADO"

        dgvRecibos.Columns(0).Width = 100
        dgvRecibos.Columns(1).Width = 110
        dgvRecibos.Columns(2).Width = 100
        dgvRecibos.Columns(3).Width = 150
        dgvRecibos.Columns(4).Visible = False
        dgvRecibos.Columns(5).Visible = False

        ' desactivar los estilos visuales del sistema
        dgvRecibos.EnableHeadersVisualStyles = False
        dgvRecibos.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvRecibos.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvRecibos.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvRecibos.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable

        dgvRecibos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvRecibos.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvRecibos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvRecibos.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvRecibos.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow

    End Sub

    Sub ActualizaGridRecibos()

        FormatGridRecibos()

        Try

            StrSql = "SELECT P.ID, P.ID_CLIENTE, C.NOMBRE, P.ID_RECIBO, P.FECHA_PAGO, P.MONTO, P.CONCEPTO, P.ANULADO" _
            & " FROM PAGOS P, CLIENTES C WHERE P.ID_FACTURA =" & CLng(txtFactura.Text) _
            & " AND P.ID_CLIENTE = C.ID ORDER BY P.ID_RECIBO ASC"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                While objReader.Read
                    dgvRecibos.Rows.Add(Lfecha(objReader("fecha_pago")), objReader("id_recibo"), FormatNumber(objReader("monto"), 2),
                                                                  objReader("concepto").ToString, objReader("id"), objReader("anulado"))
                End While
                objReader.Close()

                For X = 1 To dgvRecibos.Rows.Count - 1
                    If dgvRecibos.Item(5, X).Value = "S" Then
                        dgvRecibos.Rows(X).Cells(0).Style.BackColor = Color.Orange
                        dgvRecibos.Rows(X).Cells(1).Style.BackColor = Color.Orange
                        dgvRecibos.Rows(X).Cells(2).Style.BackColor = Color.Orange
                        dgvRecibos.Rows(X).Cells(3).Style.BackColor = Color.Orange
                    End If
                Next
            Else
                objReader.Close()
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

    Sub ImprimirRecibo()
        Try

            If Impresora = "DE RECIBO" Then

                Dim printDoc As New PrintDocument
                AddHandler printDoc.PrintPage, AddressOf print_PrintPage

                For X = 1 To Copias
                    printDoc.Print()
                Next

            Else

                Me.Cursor = Cursors.WaitCursor
                Dim Reporte As New Reportes
                Reporte.MdiParent = Me.MdiParent

                Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

                Rpt.Load(Application.StartupPath & "\rptReciboIngreso.rpt")

                Dim DineroEnLetras As String = DineroLetras(CDec(txtMontoRecibido.Text))

                Rpt.SetDatabaseLogon("admin", "cladatos-ao")
                Reporte.CrystalReportViewer1.ReportSource = Rpt

                Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
                Rpt.DataDefinition.FormulaFields("NoRecibo").Text = "'RECIBO DE INGRESO NO.  " & txtRecibo.Text & "'"
                Rpt.DataDefinition.FormulaFields("DineroLetra").Text = "'" & DineroEnLetras & "'"
                Rpt.DataDefinition.FormulaFields("Pagado").Text = "'" & CDec(txtMontoRecibido.Text) & "'"
                Rpt.DataDefinition.FormulaFields("Concepto").Text = "'" & cmbConcepto.Text & "'"

                Reporte.CrystalReportViewer1.RefreshReport()
                Reporte.Show()
                Me.Cursor = Cursors.Default

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

        Dim xPos As Single = 0 'margen izquierdo
        Dim yPos As Single = 50 'posición superior
        Dim prFont As New Font("Arial", 10, FontStyle.Regular)
        'Dim prFont As New Font("MS Gothic", 10, FontStyle.Regular)
        Dim P As Integer = 0
        Dim L As Integer = 0

        Dim DineroEnLetras As String = Trim(DineroLetras(CDec(txtMontoRecibido.Text)))

        Try
            L = Len(Empresa)
            P = Int((125 - L) / 2)

            xPos = P
            e.Graphics.DrawString(Empresa, prFont, Brushes.Black, xPos, yPos)

            L = Len("Recibo de Ingreso No. ")
            P = Int((150 - L) / 2)
            xPos = P
            yPos = yPos + 18
            e.Graphics.DrawString("Recibo de Ingreso No. " & txtRecibo.Text, prFont, Brushes.Black, xPos, yPos)

            L = Len("Fecha: ")
            P = Int((175 - L) / 2)
            xPos = P
            yPos = yPos + 18
            e.Graphics.DrawString("Fecha: " & txtFechaPago.Text, prFont, Brushes.Black, xPos, yPos)

            xPos = 0
            yPos = yPos + 36
            e.Graphics.DrawString("-------------------------------------------------------------", prFont, Brushes.Black, xPos, yPos)

            yPos = yPos + 18
            e.Graphics.DrawString("Hemos recibido de:", prFont, Brushes.Black, xPos, yPos)

            yPos = yPos + 18
            e.Graphics.DrawString(Trim(txtCliente.Text), prFont, Brushes.Black, xPos, yPos)

            yPos = yPos + 36
            e.Graphics.DrawString("La suma de: RD$ ", prFont, Brushes.Black, xPos, yPos)

            xPos = 110
            e.Graphics.DrawString(FormatNumber(CDec(txtMontoRecibido.Text), 2), prFont, Brushes.Black, xPos, yPos)

            xPos = 0
            If Len(DineroEnLetras) > 0 And Len(DineroEnLetras) <= 45 Then
                yPos = yPos + 18
                e.Graphics.DrawString(DineroEnLetras, prFont, Brushes.Black, xPos, yPos)
            ElseIf Len(DineroEnLetras) > 45 Then
                Dim Desc1 As String = ""
                Dim Desc2 As String = ""
                Dim Desc3 As String = ""

                Desc1 = Mid(DineroEnLetras, 1, 40)
                Desc2 = Trim(Mid(DineroEnLetras, 41, 40))
                Desc3 = Trim(Mid(DineroEnLetras, 82))

                yPos = yPos + 18
                e.Graphics.DrawString(Desc1, prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 18
                e.Graphics.DrawString(Desc2, prFont, Brushes.Black, xPos, yPos)

                If Len(Desc3) > 0 Then
                    yPos = yPos + 18
                    e.Graphics.DrawString(Desc3, prFont, Brushes.Black, xPos, yPos)
                End If
            End If

            yPos = yPos + 36
            e.Graphics.DrawString("Por concepto de:", prFont, Brushes.Black, xPos, yPos)

            xPos = 110
            e.Graphics.DrawString(cmbConcepto.Text, prFont, Brushes.Black, xPos, yPos)

            xPos = 0
            yPos = yPos + 18
            e.Graphics.DrawString("Factura No. ", prFont, Brushes.Black, xPos, yPos)

            xPos = 80
            e.Graphics.DrawString(txtFactura.Text, prFont, Brushes.Black, xPos, yPos)

            xPos = 0
            yPos = yPos + 18
            e.Graphics.DrawString("-------------------------------------------------------------", prFont, Brushes.Black, xPos, yPos)

            xPos = 75
            yPos = yPos + 72
            e.Graphics.DrawString("-----------------------------", prFont, Brushes.Black, xPos, yPos)

            xPos = 100
            yPos = yPos + 18
            e.Graphics.DrawString("Recibido por :", prFont, Brushes.Black, xPos, yPos)

            xPos = 0
            yPos = yPos + 18
            e.Graphics.DrawString(".", prFont, Brushes.Black, xPos, yPos)

            e.HasMorePages = False

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub frmMantRecibo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaConcepto()
        txtFechaPago.Text = Format(Today, "dd/MM/yyyy")
        FormatGridRecibos()
        txtFactura.Select()
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try

            If Len(Trim(txtCliente.Text)) = 0 Then
                MsgBox("Debe buscar la factura", vbInformation)
                txtFactura.Focus()
                Return
            End If
            If Not IsNumeric(txtRecibo.Text) Then
                MsgBox("Debe seleccionar el recibo", vbInformation)
                dgvRecibos.Focus()
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
            If lblAnulado.Visible = True Then
                MsgBox("Ese recibo está anulado, no puede modificarlo", vbInformation)
                Return
            End If

            Dim AbonoReal As Decimal = 0
            Dim NuevoBalance As Decimal = 0

            AbonoReal = (CDec(txtAbonado.Text) - CDec(txtMontoAnt.Text)) + CDec(txtMontoRecibido.Text)
            If AbonoReal > CDec(txtMontoFact.Text) Then
                MsgBox("Con el nuevo monto, el total pagado es mayor que el total de la factura, verifique", vbInformation)
                txtMontoRecibido.Focus()
                Return
            End If

            NuevoBalance = CDec(txtMontoFact.Text) - AbonoReal

            If NuevoBalance = 0 Then
                If cmbConcepto.Text = "ABONO" Then
                    MsgBox("Con el nuevo monto, el balance de la factura es cero (0), por lo que el concepto debe ser SALDO FACTURA", vbInformation)
                    cmbConcepto.Focus()
                    Return
                End If
            End If

            If NuevoBalance > 0 Then
                If cmbConcepto.Text = "SALDO FACTURA" Then
                    MsgBox("Con el nuevo monto, el balance de la factura es mayor que cero (0), por lo que el concepto debe ser ABONO", vbInformation)
                    cmbConcepto.Focus()
                    Return
                End If
            End If

            trans = Cnn.BeginTransaction : TA = True

            StrSql = "UPDATE PAGOS SET MONTO =" & CDec(txtMontoRecibido.Text) & ", CONCEPTO ='" & cmbConcepto.Text _
            & "', FECHA_PAGO ='" & Efecha(txtFechaPago.Text) & "' WHERE ID =" & CLng(txtIdPago.Text)
            objCmd = New OleDbCommand(StrSql, Cnn, trans)
            RA = objCmd.ExecuteNonQuery
            If RA <= 0 Then
                trans.Rollback() : TA = False
                MsgBox("No fue posible actualizar el recibo", vbCritical)
                Return
            End If

            If cmbConcepto.Text = "SALDO FACTURA" Then
                StrSql = "UPDATE FACTURA SET PAGADA ='S' WHERE ID_FACTURA =" & CLng(txtFactura.Text)
                objCmd = New OleDbCommand(StrSql, Cnn, trans)
                RA = objCmd.ExecuteNonQuery
                If RA <= 0 Then
                    trans.Rollback() : TA = False
                    MsgBox("Error: No fue posible poner la factura como pagada", vbCritical)
                    Return
                End If
            Else
                StrSql = "UPDATE FACTURA SET PAGADA ='N' WHERE ID_FACTURA =" & CLng(txtFactura.Text)
                objCmd = New OleDbCommand(StrSql, Cnn, trans)
                RA = objCmd.ExecuteNonQuery
                If RA <= 0 Then
                    trans.Rollback() : TA = False
                    MsgBox("Error: No fue posible actualizar la factura", vbCritical)
                    Return
                End If
            End If

            trans.Commit() : TA = False

            ActualizaGridRecibos()

            txtFechaFact.Clear() : txtMontoFact.Clear() : txtAbonado.Clear() : txtBalance.Clear()
            dgvRecibos.Focus()

        Catch ex As Exception
            If TA = True Then
                trans.Rollback() : TA = False
            End If
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub txtFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFactura.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            Try

                If Not IsNumeric(txtFactura.Text) Then
                    MsgBox("El No. de factura debe ser numerico", vbInformation)
                    txtFactura.Focus()
                    Return
                End If

                txtFechaFact.Clear() : txtMontoFact.Clear() : txtAbonado.Clear() : txtBalance.Clear()
                txtIdCliente.Clear() : txtRecibo.Clear() : txtMontoRecibido.Clear() : LlenaConcepto()

                StrSql = "SELECT F.CONDICION, F.FECHA, F.TOTAL, F.PAGADA, C.ID, C.NOMBRE FROM FACTURA F, CLIENTES C" _
                & " WHERE F.ID_FACTURA =" & CLng(txtFactura.Text) & " AND F.ID_CLIENTE = C.ID"
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If objReader("condicion").ToString = "Contado" Then
                        MsgBox("Ese No. de factura es de contado", vbInformation)
                        objReader.Close()
                        Return
                        txtFactura.Focus()
                    End If

                    txtIdCliente.Text = objReader("id")
                    txtCliente.Text = objReader("nombre").ToString
                    txtFechaFact.Text = Lfecha(objReader("fecha").ToString)
                    txtMontoFact.Text = FormatNumber(objReader("total"), 2)

                    objReader.Close()
                    ActualizaGridRecibos()

                Else
                    objReader.Close()
                    FormatGridRecibos()
                    Return
                End If

                Dim Abonado, Balance As Decimal
                Abonado = 0 : Balance = 0

                StrSql = "SELECT SUM(MONTO) AS TOTAL_ABONADO FROM PAGOS" _
                & " WHERE ID_FACTURA =" & CLng(txtFactura.Text) & " AND ANULADO ='N'"
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

                Balance = CDec(txtMontoFact.Text) - Abonado
                txtAbonado.Text = FormatNumber(Abonado, 2)
                txtBalance.Text = FormatNumber(Balance, 2)

                dgvRecibos.Focus()

            Catch ex As Exception
                MsgBox(ex.Message)
                Return
            End Try

        End If

    End Sub

    Private Sub txtMontoRecibido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoRecibido.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub txtMontoRecibido_Leave(sender As Object, e As EventArgs) Handles txtMontoRecibido.Leave
        If IsNumeric(txtMontoRecibido.Text) Then
            txtMontoRecibido.Text = FormatNumber(txtMontoRecibido.Text, 2)
        End If
    End Sub

    Private Sub cmbConcepto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbConcepto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtFechaPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFechaPago.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnGrabar.Focus()
        End If
    End Sub

    Private Sub frmRecibo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            btnGrabar.PerformClick()
        End If
    End Sub

    Private Sub dgvRecibos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvRecibos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If dgvRecibos.Rows.Count = 1 Then
                Return
            End If

            txtRecibo.Text = dgvRecibos.Item(1, dgvRecibos.CurrentRow.Index - 1).Value
            txtMontoRecibido.Text = dgvRecibos.Item(2, dgvRecibos.CurrentRow.Index - 1).Value
            txtMontoAnt.Text = dgvRecibos.Item(2, dgvRecibos.CurrentRow.Index - 1).Value
            cmbConcepto.Text = dgvRecibos.Item(3, dgvRecibos.CurrentRow.Index - 1).Value
            txtFechaPago.Text = dgvRecibos.Item(0, dgvRecibos.CurrentRow.Index - 1).Value
            txtIdPago.Text = dgvRecibos.Item(4, dgvRecibos.CurrentRow.Index - 1).Value
            If dgvRecibos.Item(5, dgvRecibos.CurrentRow.Index - 1).Value = "S" Then
                lblAnulado.Visible = True
            Else
                lblAnulado.Visible = False
            End If
            txtRecibo.Focus()

        End If

    End Sub

    Private Sub dgvRecibos_DoubleClick(sender As Object, e As EventArgs) Handles dgvRecibos.DoubleClick
        If dgvRecibos.Rows.Count = 1 Then
            Return
        End If

        txtRecibo.Text = dgvRecibos.Item(1, dgvRecibos.CurrentRow.Index).Value
        txtMontoRecibido.Text = dgvRecibos.Item(2, dgvRecibos.CurrentRow.Index).Value
        txtMontoAnt.Text = dgvRecibos.Item(2, dgvRecibos.CurrentRow.Index).Value
        cmbConcepto.Text = dgvRecibos.Item(3, dgvRecibos.CurrentRow.Index).Value
        txtFechaPago.Text = dgvRecibos.Item(0, dgvRecibos.CurrentRow.Index).Value
        txtIdPago.Text = dgvRecibos.Item(4, dgvRecibos.CurrentRow.Index).Value
        If dgvRecibos.Item(5, dgvRecibos.CurrentRow.Index).Value = "S" Then
            lblAnulado.Visible = True
        Else
            lblAnulado.Visible = False
        End If
        txtRecibo.Focus()

    End Sub

    Private Sub txtRecibo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRecibo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btprint_Click(sender As Object, e As EventArgs) Handles btprint.Click
        If IsNumeric(txtRecibo.Text) Then
            ImprimirRecibo()
        End If
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        Try
            If lblAnulado.Visible = True Then
                MsgBox("Ese recibo ya está anulado", vbInformation)
                Return
            End If

            If IsNumeric(txtRecibo.Text) Then
                If MsgBox("Seguro que desea anular ese recibo ?", vbQuestion + vbYesNo, vbDefaultButton2) = vbNo Then
                    txtRecibo.Clear() : txtMontoRecibido.Clear() : LlenaConcepto()
                    dgvRecibos.Focus()
                    Return
                End If

                trans = Cnn.BeginTransaction : TA = True

                StrSql = "UPDATE PAGOS SET ANULADO ='S' WHERE ID_RECIBO =" & CLng(txtRecibo.Text)
                objCmd = New OleDbCommand(StrSql, Cnn, trans)
                RA = objCmd.ExecuteNonQuery
                If RA > 0 Then
                    StrSql = "UPDATE FACTURA SET PAGADA ='N' WHERE ID_FACTURA =" & CLng(txtFactura.Text)
                    objCmd = New OleDbCommand(StrSql, Cnn, trans)
                    RA = objCmd.ExecuteNonQuery
                    If RA > 0 Then
                        trans.Commit() : TA = False
                        MsgBox("Ok. Recibo Anulado", vbInformation)

                        ActualizaGridRecibos()
                        txtFechaFact.Clear() : txtMontoFact.Clear() : txtAbonado.Clear() : txtBalance.Clear()
                        txtRecibo.Clear() : txtMontoRecibido.Clear() : LlenaConcepto()
                        dgvRecibos.Focus()
                        Return
                    Else
                        trans.Rollback() : TA = False
                        MsgBox("Error: No fue posible actualizar la factura", vbCritical)
                        Return
                    End If
                Else
                    trans.Rollback() : TA = False
                    MsgBox("Error: No fue posible anular el recibo", vbCritical)
                    Return
                End If

            End If

        Catch ex As Exception
            If TA = True Then
                trans.Rollback() : TA = False
            End If
            MsgBox(ex.Message)
            Return
        End Try

    End Sub
End Class