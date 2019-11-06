Imports System.Drawing.Printing
Imports System.Data.OleDb

Public Class frmImprimir
    Private Function Completa(Valor As String) As String
        If Len(Valor) > 12 Then
            Return Valor
        End If

        Dim Diferencia As Integer
        Diferencia = 12 - Len(Valor)
        Valor = Space(Diferencia) & Valor
        Return Valor

    End Function

    Private Sub imprimir(ByVal esPreview As Boolean)
        ' imprimir o mostrar el PrintPreview

        'If prtSettings Is Nothing Then
        '    prtSettings = New PrinterSettings
        'End If

        'If chkSelAntes.Checked Then
        '    If seleccionarImpresora() = False Then Return
        'End If

        'If prtDoc Is Nothing Then
        '    prtDoc = New System.Drawing.Printing.PrintDocument
        '    AddHandler prtDoc.PrintPage, AddressOf prt_PrintPage
        'End If

        '' la línea actual
        'lineaActual = 0

        '' la configuración a usar en la impresión
        'prtDoc.PrinterSettings = prtSettings

        'If esPreview Then
        '    Dim prtPrev As New PrintPreviewDialog
        '    prtPrev.Document = prtDoc

        '    prtPrev.Text = "Previsualizar documento"
        '    prtPrev.ShowDialog()
        'Else
        '    prtDoc.Print()
        'End If
    End Sub

    Private Function seleccionarImpresora() As Boolean
        Dim prtDialog As New PrintDialog
        'If prtSettings Is Nothing Then
        '    prtSettings = New PrinterSettings
        'End If


        With prtDialog
            .AllowPrintToFile = False
            .AllowSelection = False
            .AllowSomePages = False
            .PrintToFile = False
            .ShowHelp = False
            .ShowNetwork = True

            '.PrinterSettings = prtSettings

            'If .ShowDialog() = DialogResult.OK Then
            '    prtSettings = .PrinterSettings
            'Else
            '    Return False
            'End If

        End With

        Return True
    End Function

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Close()
    End Sub

    Private Sub btprint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btprint.Click
        If Not IsNumeric(txtNoFact.Text) Then
            MsgBox("Debe digitar el No. de factura (solo numeros)", vbInformation)
            txtNoFact.Focus()
            Return
        End If

        Try

            StrSql = "SELECT TOP 1 ID_CLIENTE FROM FACTURA WHERE ID_FACTURA =" & CLng(txtNoFact.Text)
            objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If Not objReader.HasRows Then
                objReader.Close()
                MsgBox("Ese numero de factura no existe, verifique", vbInformation)
                txtNoFact.Focus()
                Return
            Else
                objReader.Close()
            End If

            '*************** I M P R E S I O N ****************************************************************
            If Impresora = "DE RECIBO" Then
                Dim printDoc As New PrintDocument
                AddHandler printDoc.PrintPage, AddressOf print_PrintPage

                printDoc.Print()

            Else

                Dim dr As OleDbDataReader
                Dim Estado As String = ""
                Dim Comprobante As String = ""

                Dim query As String = "SELECT estado, comprobante FROM factura WHERE id_factura =" & txtNoFact.Text
                Dim cmb As OleDbCommand = New OleDbCommand(query, Cnn)
                dr = cmb.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    Estado = dr("estado").ToString
                    Comprobante = dr("comprobante").ToString
                    dr.Close()
                Else
                    Estado = ""
                    dr.Close()
                End If

                Me.Cursor = Cursors.WaitCursor
                Dim Reporte As New Reportes
                Reporte.MdiParent = Me.MdiParent

                Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

                If Len(Trim(Comprobante)) = 0 Then
                    Rpt.Load(Application.StartupPath & "\FacturaSin.rpt")
                Else
                    Rpt.Load(Application.StartupPath & "\Factura.rpt")
                End If
                Rpt.SetDatabaseLogon("admin", "cladatos-ao")

                Rpt.RecordSelectionFormula = "{factura.id_factura} =" & txtNoFact.Text
                Reporte.CrystalReportViewer1.ReportSource = Rpt

                Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
                Rpt.DataDefinition.FormulaFields("eslogan").Text = "'" & EsloganEmp & "'"
                Rpt.DataDefinition.FormulaFields("DIRECCION").Text = "'" & DireccionEmp & "'"
                Rpt.DataDefinition.FormulaFields("RNC").Text = "' RNC: " & RncEmp & "'"
                Rpt.DataDefinition.FormulaFields("TELEFONO").Text = "'" & "Tels: " & TelefonoEmp & "'"

                If Estado = "Anulada" Then
                    Rpt.DataDefinition.FormulaFields("Estado").Text = "' ***** FACTURA ANULADA ***** '"
                End If

                Reporte.CrystalReportViewer1.RefreshReport()
                Reporte.Show()
                Me.Cursor = Cursors.Default
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
            Return
        End Try

    End Sub

    Private Sub print_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        ' Este evento se producirá cada vez que se imprima una nueva página

        Dim xPos As Single = 0 'margen izquierdo
        Dim yPos As Single = 50 'posición superior
        Dim prFont As New Font("Arial", 10, FontStyle.Regular)
        'Dim prFont As New Font("MS Gothic", 10, FontStyle.Regular)

        Try

            StrSql = "SELECT C.NOMBRE, C.DIRECCION, F.CONDICION, F.FECHA, F.SUB_TOTAL, F.TOTAL, F.ESTADO, CANTIDAD_DESCUENTO, F.COMPROBANTE, EFECTIVO, DEVUELTA" _
            & " FROM FACTURA F, CLIENTES C WHERE ID_FACTURA =" & txtNoFact.Text & " AND F.ID_CLIENTE = C.ID"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                Dim Nombre As String = ""
                Dim Dir As String = ""
                Dim Condicion As String = ""
                Dim Fecha As String = ""
                Dim SubTotal As Decimal = 0
                Dim Total As Decimal = 0
                Dim Estado As String = ""
                Dim Comprobante As String = ""
                Dim Efectivo As Decimal = 0
                Dim Devuelta As Decimal = 0
                Dim Descuento As Decimal = 0

                objReader.Read()

                Nombre = objReader("nombre").ToString
                Dir = objReader("direccion").ToString
                Condicion = objReader("condicion").ToString
                Fecha = objReader("fecha").ToString
                SubTotal = objReader("sub_total")
                Total = objReader("total")
                Estado = objReader("estado").ToString
                Comprobante = objReader("comprobante").ToString
                Efectivo = objReader("efectivo")
                Devuelta = objReader("devuelta")
                Descuento = objReader("cantidad_descuento")

                objReader.Close()

                Dim Dcondicion As String = ""
                If Condicion = "Contado" Then
                    Dcondicion = "Factura de Contado"
                Else
                    Dcondicion = "Factura a Crédito"
                End If

                Dim newImage As Image = Image.FromFile(Application.StartupPath & "\logo.png")
                Dim Srect As New Rectangle(15, 0, 250, 150)
                e.Graphics.DrawImage(newImage, Srect)
                yPos = yPos + 108

                e.Graphics.DrawString(Empresa, prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 18
                e.Graphics.DrawString(DireccionEmp, prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 18
                e.Graphics.DrawString(ProvinciaEmp, prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 18
                e.Graphics.DrawString(TelefonoEmp, prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 18
                e.Graphics.DrawString("RNC: " & RncEmp, prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 18
                e.Graphics.DrawString("Usuario: " & NombreUsuario, prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 36
                If Len(Comprobante) > 0 Then
                    e.Graphics.DrawString("No. Comp. Fiscal : " & Comprobante, prFont, Brushes.Black, xPos, yPos)
                Else
                    e.Graphics.DrawString("FACTURA PARA CONSUMIDOR FINAL " & Comprobante, prFont, Brushes.Black, xPos, yPos)
                End If

                yPos = yPos + 18
                e.Graphics.DrawString(Dcondicion, prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 18
                e.Graphics.DrawString("Numero de Factura : " & txtNoFact.Text, prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 18
                e.Graphics.DrawString("Fecha factura: " & Lfecha(Fecha), prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 18
                e.Graphics.DrawString("Cliente : " & Nombre, prFont, Brushes.Black, xPos, yPos)

                If Len(Dir) > 0 And Len(Dir) <= 40 Then
                    yPos = yPos + 18
                    e.Graphics.DrawString(Dir, prFont, Brushes.Black, xPos, yPos)
                ElseIf Len(Dir) > 40 Then
                    Dim Dir1 As String
                    Dim Dir2 As String
                    Dir1 = Mid(Dir, 1, 40)
                    Dir2 = Mid(Dir, 41, 40)

                    yPos = yPos + 18
                    e.Graphics.DrawString(Dir1, prFont, Brushes.Black, xPos, yPos)

                    yPos = yPos + 18
                    e.Graphics.DrawString(Dir2, prFont, Brushes.Black, xPos, yPos)
                End If

                yPos = yPos + 18
                e.Graphics.DrawString("-------------------------------------------------------------", prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 18
                'prFont = New Font("Arial", 12, FontStyle.Regular)
                e.Graphics.DrawString("Can.  Desc.     Prec.           Itbis             Valor", prFont, Brushes.Black, xPos, yPos)

                'prFont = New Font("Arial", 10, FontStyle.Regular)
                yPos = yPos + 18
                e.Graphics.DrawString("-------------------------------------------------------------", prFont, Brushes.Black, xPos, yPos)


                StrSql = "SELECT * FROM DETALLES_FACTURA WHERE ID_FACTURA =" & txtNoFact.Text & " ORDER BY ID_DETALLES_FACTURA ASC"
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then

                    While objReader.Read
                        xPos = 0
                        yPos = yPos + 18
                        e.Graphics.DrawString(objReader("cantidad"), prFont, Brushes.Black, xPos, yPos)

                        prFont = New Font("Arial", 9, FontStyle.Regular)

                        If Len(objReader("descripcion")) > 0 And Len(objReader("descripcion")) <= 33 Then
                            xPos = 38
                            e.Graphics.DrawString(objReader("descripcion"), prFont, Brushes.Black, xPos, yPos)
                        ElseIf Len(objReader("descripcion")) > 33 Then
                            Dim Desc1 As String
                            Dim Desc2 As String
                            Desc1 = Mid(objReader("descripcion"), 1, 33)
                            Desc2 = Mid(objReader("descripcion"), 34, 33)

                            xPos = 38
                            e.Graphics.DrawString(Desc1, prFont, Brushes.Black, xPos, yPos)

                            yPos = yPos + 18
                            e.Graphics.DrawString(Desc2, prFont, Brushes.Black, xPos, yPos)
                        End If

                        prFont = New Font("Arial", 10, FontStyle.Regular)

                        If Len(FormatNumber(objReader("precio"), 2)) = 4 Then
                            xPos = 97
                        ElseIf Len(FormatNumber(objReader("precio"), 2)) = 5 Then
                            xPos = 90
                        ElseIf Len(FormatNumber(objReader("precio"), 2)) = 6 Then
                            xPos = 82
                        ElseIf Len(FormatNumber(objReader("precio"), 2)) = 7 Then
                            xPos = 74
                        ElseIf Len(FormatNumber(objReader("precio"), 2)) = 8 Then
                            xPos = 71
                        ElseIf Len(FormatNumber(objReader("precio"), 2)) = 9 Then
                            xPos = 63
                        ElseIf Len(FormatNumber(objReader("precio"), 2)) = 10 Then
                            xPos = 56
                        ElseIf Len(FormatNumber(objReader("precio"), 2)) = 11 Then
                            xPos = 49
                        ElseIf Len(FormatNumber(objReader("precio"), 2)) = 12 Then
                            xPos = 45
                        Else
                            xPos = 37
                        End If
                        yPos = yPos + 18
                        e.Graphics.DrawString(FormatNumber(objReader("precio"), 2), prFont, Brushes.Black, xPos, yPos)


                        If Len(FormatNumber(objReader("itbis"), 2)) = 4 Then
                            xPos = 165
                        ElseIf Len(FormatNumber(objReader("itbis"), 2)) = 5 Then
                            xPos = 158
                        ElseIf Len(FormatNumber(objReader("itbis"), 2)) = 6 Then
                            xPos = 150
                        ElseIf Len(FormatNumber(objReader("itbis"), 2)) = 7 Then
                            xPos = 142
                        ElseIf Len(FormatNumber(objReader("itbis"), 2)) = 8 Then
                            xPos = 139
                        ElseIf Len(FormatNumber(objReader("itbis"), 2)) = 9 Then
                            xPos = 131
                        ElseIf Len(FormatNumber(objReader("itbis"), 2)) = 10 Then
                            xPos = 124
                        ElseIf Len(FormatNumber(objReader("itbis"), 2)) = 11 Then
                            xPos = 117
                        ElseIf Len(FormatNumber(objReader("itbis"), 2)) = 12 Then
                            xPos = 113
                        Else
                            xPos = 105
                        End If
                        e.Graphics.DrawString(FormatNumber(objReader("itbis"), 2), prFont, Brushes.Black, xPos, yPos)


                        If Len(FormatNumber(objReader("valor"), 2)) = 4 Then
                            xPos = 245
                        ElseIf Len(FormatNumber(objReader("valor"), 2)) = 5 Then
                            xPos = 238
                        ElseIf Len(FormatNumber(objReader("valor"), 2)) = 6 Then
                            xPos = 230
                        ElseIf Len(FormatNumber(objReader("valor"), 2)) = 7 Then
                            xPos = 222
                        ElseIf Len(FormatNumber(objReader("valor"), 2)) = 8 Then
                            xPos = 219
                        ElseIf Len(FormatNumber(objReader("valor"), 2)) = 9 Then
                            xPos = 211
                        ElseIf Len(FormatNumber(objReader("valor"), 2)) = 10 Then
                            xPos = 204
                        ElseIf Len(FormatNumber(objReader("valor"), 2)) = 11 Then
                            xPos = 197
                        ElseIf Len(FormatNumber(objReader("valor"), 2)) = 12 Then
                            xPos = 193
                        Else
                            xPos = 185
                        End If
                        e.Graphics.DrawString(FormatNumber(objReader("valor"), 2), prFont, Brushes.Black, xPos, yPos)

                    End While
                    objReader.Close()

                    xPos = 0
                    yPos = yPos + 18
                    e.Graphics.DrawString("-------------------------------------------------------------", prFont, Brushes.Black, xPos, yPos)

                    yPos = yPos + 18
                    e.Graphics.DrawString("SubTotal          ---->", prFont, Brushes.Black, xPos, yPos)

                    If Len(FormatNumber(SubTotal, 2)) = 4 Then
                        xPos = 245
                    ElseIf Len(FormatNumber(SubTotal, 2)) = 5 Then
                        xPos = 238
                    ElseIf Len(FormatNumber(SubTotal, 2)) = 6 Then
                        xPos = 230
                    ElseIf Len(FormatNumber(SubTotal, 2)) = 7 Then
                        xPos = 222
                    ElseIf Len(FormatNumber(SubTotal, 2)) = 8 Then
                        xPos = 219
                    ElseIf Len(FormatNumber(SubTotal, 2)) = 9 Then
                        xPos = 211
                    ElseIf Len(FormatNumber(SubTotal, 2)) = 10 Then
                        xPos = 204
                    ElseIf Len(FormatNumber(SubTotal, 2)) = 11 Then
                        xPos = 197
                    ElseIf Len(FormatNumber(SubTotal, 2)) = 12 Then
                        xPos = 193
                    Else
                        xPos = 185
                    End If
                    e.Graphics.DrawString(FormatNumber(SubTotal, 2), prFont, Brushes.Black, xPos, yPos)

                    If Descuento > 0 Then
                        xPos = 0
                        yPos = yPos + 18
                        e.Graphics.DrawString("Descuento       ---->", prFont, Brushes.Black, xPos, yPos)

                        If Len(FormatNumber(Descuento, 2)) = 4 Then
                            xPos = 245
                        ElseIf Len(FormatNumber(Descuento, 2)) = 5 Then
                            xPos = 238
                        ElseIf Len(FormatNumber(Descuento, 2)) = 6 Then
                            xPos = 230
                        ElseIf Len(FormatNumber(Descuento, 2)) = 7 Then
                            xPos = 222
                        ElseIf Len(FormatNumber(Descuento, 2)) = 8 Then
                            xPos = 219
                        ElseIf Len(FormatNumber(Descuento, 2)) = 9 Then
                            xPos = 211
                        ElseIf Len(FormatNumber(Descuento, 2)) = 10 Then
                            xPos = 204
                        ElseIf Len(FormatNumber(Descuento, 2)) = 11 Then
                            xPos = 197
                        ElseIf Len(FormatNumber(Descuento, 2)) = 12 Then
                            xPos = 193
                        Else
                            xPos = 185
                        End If
                        e.Graphics.DrawString(FormatNumber(Descuento, 2), prFont, Brushes.Black, xPos, yPos)
                    End If

                    xPos = 0
                    yPos = yPos + 18
                    e.Graphics.DrawString("Total a Pagar   ---->", prFont, Brushes.Black, xPos, yPos)

                    If Len(FormatNumber(Total, 2)) = 4 Then
                        xPos = 245
                    ElseIf Len(FormatNumber(Total, 2)) = 5 Then
                        xPos = 238
                    ElseIf Len(FormatNumber(Total, 2)) = 6 Then
                        xPos = 230
                    ElseIf Len(FormatNumber(Total, 2)) = 7 Then
                        xPos = 222
                    ElseIf Len(FormatNumber(Total, 2)) = 8 Then
                        xPos = 219
                    ElseIf Len(FormatNumber(Total, 2)) = 9 Then
                        xPos = 211
                    ElseIf Len(FormatNumber(Total, 2)) = 10 Then
                        xPos = 204
                    ElseIf Len(FormatNumber(Total, 2)) = 11 Then
                        xPos = 197
                    ElseIf Len(FormatNumber(Total, 2)) = 12 Then
                        xPos = 193
                    Else
                        xPos = 185
                    End If
                    e.Graphics.DrawString(FormatNumber(Total, 2), prFont, Brushes.Black, xPos, yPos)

                    xPos = 0
                    yPos = yPos + 18
                    e.Graphics.DrawString("-------------------------------------------------------------", prFont, Brushes.Black, xPos, yPos)

                    If Efectivo > 0 Then
                        yPos = yPos + 18
                        e.Graphics.DrawString("Efectivo", prFont, Brushes.Black, xPos, yPos)
                        xPos = 100
                        e.Graphics.DrawString(FormatNumber(Efectivo, 2), prFont, Brushes.Black, xPos, yPos)

                        xPos = 0
                        yPos = yPos + 18
                        e.Graphics.DrawString("Devuelta", prFont, Brushes.Black, xPos, yPos)
                        xPos = 100
                        e.Graphics.DrawString(FormatNumber(Devuelta, 2), prFont, Brushes.Black, xPos, yPos)

                        xPos = 0
                        yPos = yPos + 18
                        e.Graphics.DrawString("-------------------------------------------------------------", prFont, Brushes.Black, xPos, yPos)
                    End If

                    yPos = yPos + 36
                    e.Graphics.DrawString("                Gracias Por Su Compra...", prFont, Brushes.Black, xPos, yPos)

                    yPos = yPos + 36
                    e.Graphics.DrawString(".", prFont, Brushes.Black, xPos, yPos)

                    e.HasMorePages = False

                Else
                    objReader.Close()
                End If

            Else
                objReader.Close()
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub txtNoFact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoFact.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class