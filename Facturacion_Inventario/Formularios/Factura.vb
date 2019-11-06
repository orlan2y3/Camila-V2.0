Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class Form1
    Dim subtotal As Double
    Dim itbis As Double
    Dim total As Double
    Dim numfactura As Long
    Dim numfacturaanterior As Long
    Dim numcomp As Long
    Dim Seleccion As Int16
    Dim importeanterior As Double
    Dim ncfsec As Long
    Dim NCF_Fijo As String
    Dim grabando As Boolean
    Dim posicion As Integer

    Public Sub FormatGrid()
        dgvfactura.Rows.Clear()
        dgvfactura.ColumnCount = 9
        dgvfactura.Columns(0).HeaderText = "REFERENCIA"
        dgvfactura.Columns(1).HeaderText = "DESCRIPCION"
        dgvfactura.Columns(2).HeaderText = "CANT"
        dgvfactura.Columns(3).HeaderText = "PRECIO"
        dgvfactura.Columns(4).HeaderText = "IMPORTE"
        dgvfactura.Columns(5).HeaderText = "ITBIS"
        dgvfactura.Columns(6).HeaderText = "VALOR"
        dgvfactura.Columns(7).HeaderText = "COSTO"
        dgvfactura.Columns(8).HeaderText = "ID CONDICION"

        dgvfactura.Columns(0).Width = 150
        dgvfactura.Columns(1).Width = 265
        dgvfactura.Columns(2).Width = 50
        dgvfactura.Columns(3).Width = 70
        dgvfactura.Columns(4).Width = 80
        dgvfactura.Columns(5).Width = 60
        dgvfactura.Columns(6).Width = 80
        dgvfactura.Columns(7).Visible = False
        dgvfactura.Columns(8).Visible = False

        ' desactivar los estilos visuales del sistema
        dgvfactura.EnableHeadersVisualStyles = False
        dgvfactura.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvfactura.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvfactura.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvfactura.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvfactura.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvfactura.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvfactura.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable

        dgvfactura.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvfactura.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvfactura.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvfactura.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvfactura.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        ' estilo para la cabecera del grid
        dgvfactura.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Sub LlenaTipoComprobantes()
        Try
            cmbComprobantes.Items.Clear()
            cmbIdComprobante.Items.Clear()

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT id_tipo, descripcion  FROM NCF"
            Dim cmb As OleDbCommand = New OleDbCommand(query, Cnn)
            dr = cmb.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    cmbIdComprobante.Items.Add(dr("id_tipo"))
                    cmbComprobantes.Items.Add(dr("descripcion"))
                End While
                dr.Close()
            Else
                dr.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Sub CalcularTotal()
        Try
            If dgvfactura.Rows.Count > 0 Then
                Dim SubTotal As Double = 0
                Dim Itbis As Double = 0
                Dim Descuento As Double = 0
                Dim Total As Double = 0

                For X = 0 To dgvfactura.Rows.Count - 1
                    SubTotal = SubTotal + dgvfactura.Item(4, X).Value
                    Itbis = Itbis + dgvfactura.Item(5, X).Value
                Next
                txtitbis.Text = FormatNumber(Itbis, 2)
                txtsubtotal.Text = FormatNumber(SubTotal, 2)

                If IsNumeric(txtdescuento.Text) Then
                    Descuento = CDbl(txtdescuento.Text)
                End If

                Total = (SubTotal + Itbis) - Descuento
                txttotal.Text = FormatNumber(Total, 2)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub print_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        '********** FUNCION PARA IMPRIMIR LA FACTURA *******************************

        ' Este evento se producirá cada vez que se imprima una nueva página

        Dim xPos As Single = 0 'margen izquierdo
        Dim yPos As Single = 50 'posición superior
        Dim prFont As New Font("Arial", 10, FontStyle.Regular)
        'Dim prFont As New Font("MS Gothic", 10, FontStyle.Regular)

        Try

            StrSql = "SELECT C.NOMBRE, C.DIRECCION, F.CONDICION, F.FECHA, F.SUB_TOTAL, F.TOTAL, F.ESTADO," _
            & " CANTIDAD_DESCUENTO, F.COMPROBANTE, F.EFECTIVO, F.DEVUELTA, F.ID_COMPROBANTE, F.COMENTARIO" _
            & " FROM FACTURA F, CLIENTES C WHERE ID_FACTURA =" & numfacturaanterior & " AND F.ID_CLIENTE = C.ID"
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
                Dim IdComprobante As Long = 0
                Dim NCFdescripcion As String = ""
                Dim Comentario As String = ""

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
                Devuelta = objReader("devuelta").ToString
                Descuento = objReader("cantidad_descuento")
                IdComprobante = objReader("id_comprobante")
                Comentario = objReader("comentario").ToString

                objReader.Close()

                Dim Dcondicion As String = ""
                If Condicion = "Contado" Then
                    Dcondicion = "Factura de Contado"
                Else
                    Dcondicion = "Factura a Crédito"
                End If

                If IdComprobante > 0 Then
                    StrSql = "SELECT DESCRIPCION FROM NCF WHERE ID_TIPO =" & IdComprobante
                    objCmd = New OleDbCommand(StrSql, Cnn)
                    objReader = objCmd.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        NCFdescripcion = objReader("descripcion").ToString
                        objReader.Close()
                    Else
                        objReader.Close()
                        MsgBox("Error: no se encontró en la tabla NCF el id: " & IdComprobante, vbCritical)
                        Return
                    End If
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
                    e.Graphics.DrawString(NCFdescripcion, prFont, Brushes.Black, xPos, yPos)
                    yPos = yPos + 18
                    e.Graphics.DrawString("No. Comp. Fiscal : " & Comprobante, prFont, Brushes.Black, xPos, yPos)
                Else
                    e.Graphics.DrawString("FACTURA PARA CONSUMIDOR FINAL " & Comprobante, prFont, Brushes.Black, xPos, yPos)
                End If

                yPos = yPos + 18
                e.Graphics.DrawString(Dcondicion, prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 18
                e.Graphics.DrawString("Numero de Factura : " & numfacturaanterior, prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 18
                e.Graphics.DrawString("Fecha factura : " & Lfecha(Fecha), prFont, Brushes.Black, xPos, yPos)

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


                StrSql = "SELECT * FROM DETALLES_FACTURA WHERE ID_FACTURA =" & numfacturaanterior & " ORDER BY ID_DETALLES_FACTURA ASC"
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

                    If Len(Comentario) > 0 Then
                        If Len(Comentario) > 0 And Len(Comentario) <= 33 Then
                            yPos = yPos + 36
                            e.Graphics.DrawString(Comentario, prFont, Brushes.Black, xPos, yPos)
                        ElseIf Len(Comentario) > 33 Then
                            Dim Comentario1 As String
                            Dim Comentario2 As String
                            Comentario1 = Mid(Comentario, 1, 33)
                            Comentario2 = Mid(Comentario, 34, 33)

                            yPos = yPos + 36
                            e.Graphics.DrawString(Comentario1, prFont, Brushes.Black, xPos, yPos)

                            yPos = yPos + 18
                            e.Graphics.DrawString(Comentario2, prFont, Brushes.Black, xPos, yPos)
                        End If
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

    Private Sub btagregar_Click(sender As Object, e As EventArgs) Handles btagregar.Click

        Try

            If Len(Trim(txtcliente.Text)) = 0 Then
                MsgBox("Debe Digitar un Cliente", MsgBoxStyle.Information)
                txtcliente.Focus()
                Return
            End If

            If Len(Trim(txtRef.Text)) = 0 Then
                MsgBox("Debe Digitar la Referencia", MsgBoxStyle.Information)
                txtRef.Focus()
                Return
            End If

            If Len(Trim(cmbProducto.Text)) = 0 Then
                MsgBox("Falta la descripción del producto ", MsgBoxStyle.Information)
                txtRef.Focus()
                Return
            ElseIf cmbProducto.Text = "SELECCIONA UNA OPCION ..." Then
                MsgBox("Debe seleccionar una opción en Descripción", MsgBoxStyle.Information, "Creación de Facturas")
                cmbProducto.Focus()
                Return
            End If

            If Not IsNumeric(txtprecio.Text) Then
                MsgBox("El precio debe ser numerico ", MsgBoxStyle.Information)
                txtRef.Focus()
                Return
            Else
                If txtprecio.Text <= 0 Then
                    MsgBox("El precio debe ser un valor mayor que cero ", MsgBoxStyle.Information)
                    txtRef.Focus()
                    Return
                End If
            End If

            If Not IsNumeric(txtcantidad.Text) Then
                MsgBox("Debe Digitar una Cantidad numerica", MsgBoxStyle.Information)
                txtcantidad.Focus()
                Return
            Else
                If txtcantidad.Text <= 0 Then
                    MsgBox("La cantidad debe ser un valor mayor que cero ", MsgBoxStyle.Information)
                    txtcantidad.Focus()
                    Return
                End If
            End If

            StrSql = "SELECT ID FROM INVENTARIO WHERE REFERENCIA ='" & Trim(txtRef.Text) & "'"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If Not objReader.HasRows Then
                objReader.Close()
                MsgBox("Esa referencia no existe en el inventario", vbCritical)
                txtRef.Focus()
                Return
            Else
                objReader.Close()
            End If

            txtRecibido.Clear() : txtDevuelta.Clear()

            Dim importe As Double = 0
            Dim Valor As Double = 0
            itbis = 0

            importe = txtprecio.Text * txtcantidad.Text
            If cb1.Checked = False Then
                itbis = (importe * p_itbis) / 100
                Valor = importe + itbis
            Else
                Valor = importe
            End If

            If InStr(cmbProducto.Text, "'") Then
                cmbProducto.Text = Cambiar(cmbProducto.Text)
            End If

            If txtcantidad.BackColor = Color.White Then
                dgvfactura.Rows.Add(Trim(txtRef.Text), cmbProducto.Text, CDbl(txtcantidad.Text), FormatNumber(txtprecio.Text, 2),
                FormatNumber(importe, 2), FormatNumber(itbis, 2), FormatNumber(Valor, 2), FormatNumber(txtCosto.Text, 2), cmbIdCondicion.Text)
            Else
                dgvfactura.Item(0, posicion).Value = Trim(txtRef.Text)
                dgvfactura.Item(1, posicion).Value = cmbProducto.Text
                dgvfactura.Item(2, posicion).Value = CDbl(txtcantidad.Text)
                dgvfactura.Item(3, posicion).Value = FormatNumber(txtprecio.Text, 2)
                dgvfactura.Item(4, posicion).Value = FormatNumber(importe, 2)
                dgvfactura.Item(5, posicion).Value = FormatNumber(itbis, 2)
                dgvfactura.Item(6, posicion).Value = FormatNumber(Valor, 2)
                dgvfactura.Item(7, posicion).Value = FormatNumber(txtCosto.Text, 2)
                dgvfactura.Item(8, posicion).Value = cmbIdCondicion.Text

                txtRef.BackColor = Color.White
                txtcantidad.BackColor = Color.White
                cmbProducto.BackColor = Color.White
                txtprecio.BackColor = Color.White

                bteliminar.Visible = False

            End If

            CalcularTotal()

            txtRef.Clear() : cmbProducto.Items.Clear() : txtprecio.Clear() : txtcantidad.Clear() : txtCosto.Clear()
            cmbIdCondicion.Items.Clear() : cmbCosto.Items.Clear() : cmbPrecio.Items.Clear()
            txtRef.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub btinsertar_Click(sender As Object, e As EventArgs) Handles btinsertar.Click

        Try

            If Len(Trim(txtcliente.Text)) = 0 Then
                MsgBox("Debe de Digitar un Cliente", MsgBoxStyle.Information)
                txtcliente.Focus()
                Return
            ElseIf cmbcondicion.Text = "" Then
                MsgBox("Debe Seleccionar una Condición", MsgBoxStyle.Information)
                cmbcondicion.Focus()
                Return
            ElseIf IsNothing(dgvfactura(0, 0).Value) Then
                MsgBox("Debe agregar un producto a la factura", MsgBoxStyle.Information)
                txtRef.Focus()
                Return
            End If

            If IsNumeric(txtdescuento.Text) Then
                If CDec(txtdescuento.Text) > Maximo_Descuento Then
                    If MsgBox("El descuento es superior al permitido. Desea continuar ??", vbQuestion + vbYesNo + vbDefaultButton2) = vbNo Then
                        Return
                    End If
                    If NivelUsuario <> 1 Then
                        Dim fseg As New Seguridad
                        fseg.ShowDialog()
                        If Permitido = True Then
                            Permitido = False
                        Else
                            Return
                        End If
                    End If
                End If
            End If

            grabando = True

            Dim PorcientoItbis As Double = 0
            Dim ValidaHasta As String = ""

            StrSql = "SELECT sec FROM secuencia"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader()
            If objReader.HasRows Then
                objReader.Read()
                txtnumfactura.Text = objReader("sec") + 1
                objReader.Close()
            Else
                objReader.Close()
            End If

            trans = Cnn.BeginTransaction
            TA = True

            If Not IsNumeric(txtitbis.Text) Then
                txtitbis.Text = 0
            End If

            If Not IsNumeric(txtdescuento.Text) Then
                txtdescuento.Text = 0
            End If
            If cb1.Checked = True Then
                PorcientoItbis = 0
            Else
                PorcientoItbis = txtporcientoitbis.Text
            End If

            Dim TipoComprobante As String = ""
            Dim IdComprobante As Integer = 0
            Dim Efectivo As Decimal = 0
            Dim Devuelta As Decimal = 0
            Dim Pagada As String = ""

            If rdb1.Checked = True Then
                ValidaHasta = "" : IdComprobante = 0
            Else
                StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE COMPROBANTE ='" & Trim(txtnumcomprobante.Text) & "'"
                objCmd = New OleDbCommand(StrSql, Cnn, trans)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    Dim IdFactura As Long = 0
                    objReader.Read()
                    IdFactura = objReader("id_factura")
                    objReader.Close()
                    MsgBox("Ese No. de comprobante ya se uso en la factura No. " & IdFactura, vbCritical)
                    txtRef.Focus()
                    Return
                Else
                    objReader.Close()
                End If

                ValidaHasta = txtValida.Text
                IdComprobante = cmbIdComprobante.Text
            End If

            If cmbcondicion.Text = "Contado" Then
                Pagada = "S"
            Else
                Pagada = "N"
            End If

            If IsNumeric(txtRecibido.Text) Then
                Efectivo = CDec(txtRecibido.Text)
            End If
            If IsNumeric(txtDevuelta.Text) Then
                Devuelta = CDec(txtDevuelta.Text)
            End If

            Dim myQuery As String = "INSERT INTO factura (id_factura,id_cliente,condicion,comentario,fecha,sub_total,itbis,total," _
            & "cantidad_descuento,porciento_itbis,id_usuario,comprobante, id_comprobante, valida_hasta, pagada, efectivo, devuelta)" _
            & " VALUES (" & txtnumfactura.Text & "," & CLng(txtIdCliente.Text) & ",'" & cmbcondicion.Text _
            & "','" & Trim(rtbcomentario.Text) & "','" & Efecha(mtbfecha.Text) & "'," & CDec(txtsubtotal.Text) _
            & "," & CDec(txtitbis.Text) & "," & CDec(txttotal.Text) & "," & CDec(txtdescuento.Text) & "," & PorcientoItbis & "," & IdUsuario _
            & ",'" & txtnumcomprobante.Text & "'," & IdComprobante & ",'" & ValidaHasta & "','" & Pagada & "'," & Efectivo & "," & Devuelta & ")"

            Dim cmd3 As OleDbCommand = New OleDbCommand(myQuery, Cnn, trans)
            cmd3.Connection = Cnn
            RA = cmd3.ExecuteNonQuery
            If RA <= 0 Then
                trans.Rollback()
                MsgBox("Error grabando el encabezado de la factura", MsgBoxStyle.Critical)
                txtcliente.Focus()
                Return
            End If

            Dim X As Integer
            For X = 0 To dgvfactura.Rows.Count - 1
                If Len(Trim(dgvfactura(0, X).Value)) > 0 Then
                    Dim cmd4 As OleDbCommand

                    Dim myQuery1 As String = "INSERT INTO detalles_factura(id_factura, referencia, descripcion, costo, cantidad, precio, importe, itbis, valor, id_condicion)" _
                    & " VALUES (" & txtnumfactura.Text & ",'" & dgvfactura(0, X).Value & "','" & dgvfactura(1, X).Value & "'," & CDec(dgvfactura(7, X).Value) _
                    & "," & CDbl(dgvfactura(2, X).Value) & "," & CDec(dgvfactura(3, X).Value) & "," & CDec(dgvfactura(4, X).Value) & "," _
                    & CDec(dgvfactura(5, X).Value) & "," & CDec(dgvfactura(6, X).Value) & "," & CDec(dgvfactura(8, X).Value) & ")"
                    cmd4 = New OleDbCommand(myQuery1, Cnn, trans)
                    cmd4.Connection = Cnn
                    RA = cmd4.ExecuteNonQuery()
                    If RA > 0 Then
                        StrSql = "UPDATE INVENTARIO SET EXISTENCIA = EXISTENCIA - " & CDbl(dgvfactura(2, X).Value) _
                        & " WHERE REFERENCIA ='" & dgvfactura(0, X).Value & "'"
                        objCmd = New OleDbCommand(StrSql, Cnn, trans)
                        RA = objCmd.ExecuteNonQuery()
                        If RA <= 0 Then
                            trans.Rollback() : TA = False
                            MsgBox("Error actualiazando existencia en el inventario", MsgBoxStyle.Critical)
                            txtRef.Focus()
                            Return
                        End If
                    Else
                        trans.Rollback() : TA = False
                        MsgBox("Error grabando el detalle de la factura", MsgBoxStyle.Critical)
                        txtRef.Focus()
                        Return
                    End If
                Else
                    Exit For
                End If
            Next X

            Dim queryupdate As String = "UPDATE secuencia Set sec = " & txtnumfactura.Text
            Dim cmb2 As OleDbCommand = New OleDbCommand(queryupdate, Cnn, trans)
            RA = cmb2.ExecuteNonQuery()
            If RA <= 0 Then
                trans.Rollback() : TA = False
                MsgBox("Error actualiazando secuencia de factura", MsgBoxStyle.Critical)
                Return
            End If

            If rdb2.Checked = True Then
                Dim queryupdate2 As String = "UPDATE ncf Set sec = " & ncfsec & " WHERE id_tipo = " & cmbIdComprobante.Text
                Dim cmb3 As OleDbCommand = New OleDbCommand(queryupdate2, Cnn, trans)
                RA = cmb3.ExecuteNonQuery()
                If RA <= 0 Then
                    trans.Rollback() : TA = False
                    MsgBox("Error actualiazando secuencia del comprobante fiscal", MsgBoxStyle.Critical)
                    Return
                End If
            End If

            trans.Commit()

            numfacturaanterior = txtnumfactura.Text

            '*************** I M P R E S I O N ****************************************************************
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

                If rdb1.Checked = True Then
                    Rpt.Load(Application.StartupPath & "\FacturaSin.rpt")
                Else
                    Rpt.Load(Application.StartupPath & "\Factura.rpt")
                End If

                Rpt.SetDatabaseLogon("admin", "cladatos-ao")
                Reporte.CrystalReportViewer1.ReportSource = Rpt

                Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
                Rpt.DataDefinition.FormulaFields("eslogan").Text = "'" & EsloganEmp & "'"
                Rpt.DataDefinition.FormulaFields("DIRECCION").Text = "'" & DireccionEmp & "'"
                Rpt.DataDefinition.FormulaFields("RNC").Text = "' RNC: " & RncEmp & "'"
                Rpt.DataDefinition.FormulaFields("TELEFONO").Text = "' Tels: " & TelefonoEmp & "'"
                Rpt.RecordSelectionFormula = "{factura.id_factura} =" & numfacturaanterior
                Reporte.CrystalReportViewer1.RefreshReport()
                Reporte.Show()
                Me.Cursor = Cursors.Default

            End If

            btnuevo.PerformClick()

        Catch ex As Exception
            If TA = True Then
                trans.Rollback() : TA = False
            End If
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub bteliminar_Click(sender As Object, e As EventArgs) Handles bteliminar.Click
        Try

            If txtRef.BackColor = Color.Yellow Then
                dgvfactura.Rows.RemoveAt(posicion)
                CalcularTotal()
            End If

            txtRecibido.Clear() : txtDevuelta.Clear()

            txtRef.BackColor = Color.White
            txtcantidad.BackColor = Color.White
            cmbProducto.BackColor = Color.White
            txtprecio.BackColor = Color.White

            txtRef.Clear() : cmbProducto.Items.Clear() : txtprecio.Clear() : txtcantidad.Clear() : txtCosto.Clear()
            cmbIdCondicion.Items.Clear() : cmbCosto.Items.Clear() : cmbPrecio.Items.Clear()
            txtRef.Focus()

            bteliminar.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub txtporcientodescuento_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            btinsertar.Focus()
        End If
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub rtbcomentario_Click(sender As Object, e As EventArgs) Handles rtbcomentario.Click
        rtbcomentario.SelectionStart = 0
        rtbcomentario.SelectionLength = rtbcomentario.Text.Length
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Ffactura.Hide()
    End Sub

    Private Sub btbuscarCotizacion_Click(sender As Object, e As EventArgs) Handles btbuscarCotizacion.Click
        Dim buscar As New Buscar_Cotizacion_facturacion
        buscar.MdiParent = Me.MdiParent
        buscar.Show()
    End Sub

    Private Sub txtnumfactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumfactura.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtrnccliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrnccliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbComprobantes_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbComprobantes.SelectedValueChanged
        cmbIdComprobante.SelectedIndex = cmbComprobantes.SelectedIndex
    End Sub

    Private Sub cmbIdComprobante_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbIdComprobante.SelectedValueChanged
        Try
            If cmbIdComprobante.Text <> "" Then

                Dim dr As OleDbDataReader
                Dim query As String = "SELECT sec, fijo FROM NCF WHERE id_tipo =" & cmbIdComprobante.Text
                Dim cmb As OleDbCommand = New OleDbCommand(query, Cnn)
                dr = cmb.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    NCF_Fijo = dr("fijo").ToString
                    ncfsec = dr("sec") + 1
                    txtnumcomprobante.Text = NCF_Fijo & ncfsec
                    dr.Close()
                Else
                    dr.Close()
                    txtnumcomprobante.Text = ""
                End If

            Else
                txtnumcomprobante.Text = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        Try
            Dim dr As OleDbDataReader
            Dim query As String = "SELECT sec FROM secuencia"
            Dim cmb1 As OleDbCommand = New OleDbCommand(query, Cnn)
            dr = cmb1.ExecuteReader()
            dr.Read()
            numfactura = dr("sec") + 1
            txtnumfactura.Text = numfactura
            dr.Close()

            cmbcondicion.SelectedIndex = 0
            txtcliente.Clear() : txtIdCliente.Clear() : txtrnccliente.Clear()
            Dim fecha As String = Date.Today.ToString("dd/MM/yyyy")
            mtbfecha.Text = fecha
            txtRef.Clear() : cmbProducto.Items.Clear() : txtprecio.Clear() : txtcantidad.Clear() : txtCosto.Clear()
            cmbIdCondicion.Items.Clear() : cmbCosto.Items.Clear() : cmbPrecio.Items.Clear()
            txtsubtotal.Clear() : txtitbis.Clear() : txtdescuento.Text = "0.00" : txttotal.Clear()
            txtRecibido.Clear() : txtDevuelta.Clear() : txtRef.Clear()

            txtporcientoitbis.ReadOnly = True
            rdb1.Checked = True
            cb1.Checked = True
            LlenaTipoComprobantes()
            txtnumcomprobante.Clear()
            txtValida.Text = Valida
            txtporcientoitbis.Text = p_itbis
            txtnumcomprobante.Text = ""
            GroupBox2.Enabled = False

            Label16.Enabled = False
            txtValida.Enabled = False
            FormatGrid()

            txtRef.BackColor = Color.White
            txtcantidad.BackColor = Color.White
            cmbProducto.BackColor = Color.White
            txtprecio.BackColor = Color.White

            StrSql = "SELECT ID, RNC, NOMBRE FROM CLIENTES WHERE NOMBRE ='CLIENTE DE CONTADO'"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                txtIdCliente.Text = objReader("id")
                txtrnccliente.Text = objReader("rnc").ToString
                txtcliente.Text = objReader("nombre").ToString
                objReader.Close()
            Else
                objReader.Close()
                MsgBox("Debe registrar el nombre de cliente: CLIENTE DE CONTADO, antes de hacer facturas o cotizaciones", vbInformation)
                Me.Hide()
            End If

            txtRef.Select()

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtprecio.Text) Then
                MsgBox("Falta el precio", vbInformation)
                txtRef.Focus()
                Return
            End If
            If Not IsNumeric(txtcantidad.Text) Then
                MsgBox("Debe digitar la cantidad", vbInformation)
                txtcantidad.Focus()
                Return
            End If

            btagregar.PerformClick()

        End If
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If

    End Sub

    Private Sub cmbcondicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbcondicion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtRef.Focus()
        End If
    End Sub

    Private Sub cb1_Click(sender As Object, e As EventArgs) Handles cb1.Click
        If cb1.Checked = True Then
            cb1.Font = New Font(cb1.Font, FontStyle.Bold)
        Else
            cb1.Font = New Font(cb1.Font, FontStyle.Regular)
        End If

    End Sub

    Private Sub dgvfactura_DoubleClick(sender As Object, e As EventArgs) Handles dgvfactura.DoubleClick
        Try

            If dgvfactura.RowCount = 1 Then
                Return
            End If

            If Not dgvfactura.CurrentRow.IsNewRow Then
                txtRef.Clear() : cmbProducto.Items.Clear() : txtprecio.Clear() : txtcantidad.Clear() : txtCosto.Clear()
                cmbIdCondicion.Items.Clear() : cmbCosto.Items.Clear() : cmbPrecio.Items.Clear()

                posicion = dgvfactura.CurrentRow.Index

                If dgvfactura.Item(8, dgvfactura.CurrentRow.Index).Value > 0 Then
                    StrSql = "SELECT REFERENCIA FROM CONDICIONES WHERE ID =" & dgvfactura.Item(8, dgvfactura.CurrentRow.Index).Value
                    objCmd = New OleDbCommand(StrSql, Cnn)
                    objReader = objCmd.ExecuteReader
                    If Not objReader.HasRows Then
                        objReader.Close()
                        MsgBox("Esa condición ya no existe para ese producto", vbInformation)
                        Return
                    Else
                        objReader.Close()
                    End If
                End If

                txtRef.Text = dgvfactura.Item(0, dgvfactura.CurrentRow.Index).Value

                StrSql = "SELECT C.ID, C.CONDICION, C.COSTO, C.PRECIO_VENTA, I.DESCRIPCION FROM CONDICIONES C, INVENTARIO I" _
                & " WHERE C.REFERENCIA ='" & Trim(txtRef.Text) & "' AND C.REFERENCIA = I.REFERENCIA"
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    cmbIdCondicion.Items.Add(0)
                    cmbCosto.Items.Add(0)
                    cmbPrecio.Items.Add(0)
                    cmbProducto.Items.Add("SELECCIONA UNA OPCION ...")
                    While objReader.Read()
                        cmbIdCondicion.Items.Add(objReader("id"))
                        cmbCosto.Items.Add(objReader("costo"))
                        cmbPrecio.Items.Add(objReader("precio_venta"))
                        cmbProducto.Items.Add(objReader("descripcion").ToString & "  " & objReader("condicion").ToString)
                    End While
                    objReader.Close()

                    'cmbProducto.Text = dgvfactura.Item(1, dgvfactura.CurrentRow.Index).Value
                    txtcantidad.Text = dgvfactura.Item(2, dgvfactura.CurrentRow.Index).Value
                    txtprecio.Text = dgvfactura.Item(3, dgvfactura.CurrentRow.Index).Value
                    txtCosto.Text = dgvfactura.Item(7, dgvfactura.CurrentRow.Index).Value
                    cmbIdCondicion.Text = dgvfactura.Item(8, dgvfactura.CurrentRow.Index).Value
                    txtcantidad.Focus()

                Else
                    objReader.Close()

                    StrSql = "SELECT * FROM INVENTARIO WHERE REFERENCIA ='" & Trim(txtRef.Text) & "'"
                    objCmd = New OleDbCommand(StrSql, Cnn)
                    objReader = objCmd.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        cmbIdCondicion.Items.Add(0)
                        cmbCosto.Items.Add(objReader("costo"))
                        cmbPrecio.Items.Add(objReader("precio_venta"))
                        cmbProducto.Items.Add(objReader("descripcion").ToString)
                        cmbProducto.Text = dgvfactura.Item(1, dgvfactura.CurrentRow.Index).Value
                        txtcantidad.Text = dgvfactura.Item(2, dgvfactura.CurrentRow.Index).Value
                        txtprecio.Text = dgvfactura.Item(3, dgvfactura.CurrentRow.Index).Value
                        txtCosto.Text = dgvfactura.Item(7, dgvfactura.CurrentRow.Index).Value
                        objReader.Close()
                        txtcantidad.Focus()
                    Else
                        objReader.Close()
                        txtRef.SelectionStart = 0
                        txtRef.SelectionLength = Len(txtRef.Text)
                        txtRef.Focus()
                        Return
                    End If
                End If

                txtRef.BackColor = Color.Yellow
                txtcantidad.BackColor = Color.Yellow
                cmbProducto.BackColor = Color.Yellow
                txtprecio.BackColor = Color.Yellow

                bteliminar.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub rdb1_Click(sender As Object, e As EventArgs) Handles rdb1.Click
        LlenaTipoComprobantes()
        txtnumcomprobante.Text = ""
        GroupBox2.Enabled = False

        Label16.Enabled = False
        txtValida.Enabled = False

    End Sub

    Private Sub rdb2_Click(sender As Object, e As EventArgs) Handles rdb2.Click
        txtnumcomprobante.Text = ""
        GroupBox2.Enabled = True

        Label16.Enabled = True
        txtValida.Enabled = True
    End Sub

    Public Sub txtRef_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRef.KeyPress
        Try

            If e.KeyChar = ChrW(Keys.Enter) Then
                cmbCosto.Items.Clear() : cmbPrecio.Items.Clear() : cmbProducto.Items.Clear() : cmbIdCondicion.Items.Clear()

                If Len(Trim(txtRef.Text)) = 0 Then
                    If IsNumeric(txttotal.Text) Then
                        If CDec(txttotal.Text) > 0 Then
                            txtRecibido.Focus()
                            Return
                        Else
                            txtRef.Focus()
                            Return
                        End If
                    Else
                        txtRef.Focus()
                        Return
                    End If
                End If

                StrSql = "SELECT C.ID, C.CONDICION, C.COSTO, C.PRECIO_VENTA, I.DESCRIPCION FROM CONDICIONES C, INVENTARIO I" _
                & " WHERE C.REFERENCIA ='" & Trim(txtRef.Text) & "' AND C.REFERENCIA = I.REFERENCIA"
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    cmbIdCondicion.Items.Add(0)
                    cmbCosto.Items.Add(0)
                    cmbPrecio.Items.Add(0)
                    cmbProducto.Items.Add("SELECCIONA UNA OPCION ...")
                    While objReader.Read()
                        cmbIdCondicion.Items.Add(objReader("id"))
                        cmbCosto.Items.Add(objReader("costo"))
                        cmbPrecio.Items.Add(objReader("precio_venta"))
                        cmbProducto.Items.Add(objReader("descripcion").ToString & "  " & objReader("condicion").ToString)
                        cmbProducto.SelectedIndex = 0
                    End While
                    objReader.Close()
                    cmbProducto.Focus()

                Else
                    objReader.Close()

                    StrSql = "SELECT * FROM INVENTARIO WHERE REFERENCIA ='" & Trim(txtRef.Text) & "'"
                    objCmd = New OleDbCommand(StrSql, Cnn)
                    objReader = objCmd.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        cmbIdCondicion.Items.Add(0)
                        cmbCosto.Items.Add(objReader("costo"))
                        cmbPrecio.Items.Add(objReader("precio_venta"))
                        cmbProducto.Items.Add(objReader("descripcion").ToString)
                        cmbProducto.SelectedIndex = 0

                        txtCosto.Text = FormatNumber(objReader("costo"), 2)
                        txtprecio.Text = FormatNumber(objReader("precio_venta"), 2)
                        objReader.Close()
                        'txtcantidad.Text = 1
                        txtcantidad.Focus()
                        Return
                    Else
                        objReader.Close()
                        txtRef.SelectionStart = 0
                        txtRef.SelectionLength = Len(txtRef.Text)
                        txtRef.Focus()
                        Return
                    End If
                End If

            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub txtRecibido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRecibido.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            If IsNumeric(txtRecibido.Text) Then

                If IsNumeric(txttotal.Text) Then
                    If CDec(txttotal.Text) > 0 Then
                        txtRecibido.Text = FormatNumber(txtRecibido.Text, 2)
                        txtDevuelta.Text = CDec(txtRecibido.Text) - CDec(txttotal.Text)
                        txtDevuelta.Text = FormatNumber(txtDevuelta.Text, 2)
                    End If
                End If

            End If

        End If

    End Sub

    Private Sub mtbfecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mtbfecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        MsgBox("Utilice el botón Salir", vbInformation)
        Return
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        FbuscarCliente.MdiParent = Ffactura.MdiParent
        FbuscarCliente.Tag = "Factura"
        FbuscarCliente.Show()
        FbuscarCliente.FormatGrid()
        FbuscarCliente.txtNombre.Clear()
        FbuscarCliente.txtNombre.Focus()

    End Sub

    Private Sub txtdescuento_Leave(sender As Object, e As EventArgs) Handles txtdescuento.Leave
        If IsNumeric(txtdescuento.Text) Then
            txtdescuento.Text = FormatNumber(txtdescuento.Text, 2)

            If IsNumeric(txttotal.Text) Then
                If CDec(txttotal.Text) > 0 Then
                    CalcularTotal()
                End If
            End If

        Else
            txtdescuento.Text = 0
        End If

    End Sub

    Private Sub txtdescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdescuento.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtRecibido.Focus()
        End If
    End Sub

    Private Sub cmbProducto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedValueChanged
        cmbIdCondicion.SelectedIndex = cmbProducto.SelectedIndex
        cmbCosto.SelectedIndex = cmbProducto.SelectedIndex
        cmbPrecio.SelectedIndex = cmbProducto.SelectedIndex
        txtCosto.Text = cmbCosto.Text
        txtprecio.Text = cmbPrecio.Text
    End Sub

    Private Sub cmbProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbProducto.KeyPress
        If cmbProducto.Text = "SELECCIONA UNA OPCION ..." Then
            MsgBox("Seleccione una Opción en Descripción", vbInformation)
            cmbProducto.Focus()
            Return
        End If

        txtCosto.Text = FormatNumber(cmbCosto.Text, 2)
        txtprecio.Text = FormatNumber(cmbPrecio.Text, 2)

        'If txtcantidad.BackColor = Color.White Then
        '    txtcantidad.Text = 1
        'End If

        txtcantidad.Focus()
    End Sub

    Private Sub cmbIdCondicion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbIdCondicion.SelectedValueChanged
        cmbProducto.SelectedIndex = cmbIdCondicion.SelectedIndex
        cmbCosto.SelectedIndex = cmbIdCondicion.SelectedIndex
        cmbPrecio.SelectedIndex = cmbIdCondicion.SelectedIndex

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F2 Then
            FBuscarProductos.Tag = "Factura"
            FBuscarProductos.Show()
            FBuscarProductos.txtReferencia.Clear()
            FBuscarProductos.FormatGrid()
            FBuscarProductos.txtReferencia.Focus()
        ElseIf e.KeyValue = Keys.F5 Then
            If IsNumeric(txttotal.Text) Then
                If CDec(txttotal.Text) > 0 Then
                    btinsertar.PerformClick()
                End If
            End If
        ElseIf e.KeyValue = Keys.F9 Then
            btbuscar.PerformClick()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class