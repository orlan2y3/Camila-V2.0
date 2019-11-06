Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class Cotizacion

    Dim subtotal As Double
    Dim itbis As Double
    Dim total As Double
    Dim numcotizacion As Long
    Dim numcotizacionanterior As Long
    Dim EstadoCotizacion As String
    Dim idcliente As Long
    Dim Seleccion As Int16
    Dim importeanterior As Double
    Dim posicion As Integer

    Private Sub FormatGrid()

        dgvcotizacion.Rows.Clear()
        dgvcotizacion.ColumnCount = 8
        dgvcotizacion.Columns(0).HeaderText = "REFERENCIA"
        dgvcotizacion.Columns(1).HeaderText = "DESCRIPCION"
        dgvcotizacion.Columns(2).HeaderText = "CANT"
        dgvcotizacion.Columns(3).HeaderText = "PRECIO"
        dgvcotizacion.Columns(4).HeaderText = "IMPORTE"
        dgvcotizacion.Columns(5).HeaderText = "ITBIS"
        dgvcotizacion.Columns(6).HeaderText = "VALOR"
        dgvcotizacion.Columns(7).HeaderText = "ID CONDICION"

        dgvcotizacion.Columns(0).Width = 150
        dgvcotizacion.Columns(1).Width = 265
        dgvcotizacion.Columns(2).Width = 50
        dgvcotizacion.Columns(3).Width = 70
        dgvcotizacion.Columns(4).Width = 80
        dgvcotizacion.Columns(5).Width = 60
        dgvcotizacion.Columns(6).Width = 80
        dgvcotizacion.Columns(7).Visible = False

        ' desactivar los estilos visuales del sistema
        dgvcotizacion.EnableHeadersVisualStyles = False
        dgvcotizacion.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcotizacion.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcotizacion.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcotizacion.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcotizacion.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcotizacion.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvcotizacion.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable

        dgvcotizacion.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvcotizacion.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvcotizacion.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvcotizacion.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgvcotizacion.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        ' estilo para la cabecera del grid
        dgvcotizacion.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Sub CalcularTotal()
        If dgvcotizacion.Rows.Count > 0 Then
            Dim SubTotal As Double = 0
            Dim Itbis As Double = 0
            Dim Descuento As Double = 0
            Dim Total As Double = 0

            For X = 0 To dgvcotizacion.Rows.Count - 1
                SubTotal = SubTotal + dgvcotizacion.Item(4, X).Value
                Itbis = Itbis + dgvcotizacion.Item(5, X).Value
            Next
            txtitbis.Text = FormatNumber(Itbis, 2)
            txtsubtotal.Text = FormatNumber(SubTotal, 2)

            If IsNumeric(txtdescuento.Text) Then
                Descuento = CDbl(txtdescuento.Text)
            End If

            Total = (SubTotal + Itbis) - Descuento
            txttotal.Text = FormatNumber(Total, 2)

        End If

    End Sub

    Private Sub print_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        '********** FUNCION PARA IMPRIMIR LA FACTURA *******************************

        ' Este evento se producirá cada vez que se imprima una nueva página

        Dim xPos As Single = 0 'margen izquierdo
        Dim yPos As Single = 50 'posición superior
        Dim prFont As New Font("Arial", 10, FontStyle.Regular)
        'Dim prFont As New Font("MS Gothic", 10, FontStyle.Regular)

        Try

            StrSql = "SELECT C.NOMBRE, C.DIRECCION , F.FECHA, F.SUB_TOTAL, F.TOTAL, F.ESTADO, CANTIDAD_DESCUENTO, F.COMENTARIO" _
            & " FROM COTIZACION F, CLIENTES C WHERE ID_COTIZACION =" & numcotizacionanterior & " AND F.ID_CLIENTE = C.ID"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                Dim Nombre As String = ""
                Dim Dir As String = ""
                Dim Fecha As String = ""
                Dim SubTotal As Decimal = 0
                Dim Total As Decimal = 0
                Dim Estado As String = ""
                Dim Descuento As Decimal = 0
                Dim Comentario As String = ""

                objReader.Read()

                Nombre = objReader("nombre").ToString
                Dir = objReader("direccion").ToString
                Fecha = objReader("fecha").ToString
                SubTotal = objReader("sub_total")
                Total = objReader("total")
                Estado = objReader("estado").ToString
                Descuento = objReader("cantidad_descuento")
                Comentario = objReader("comentario").ToString

                objReader.Close()

                e.Graphics.DrawString("                       COTIZACION", prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 36
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
                e.Graphics.DrawString("Numero de Cotización : " & numcotizacionanterior, prFont, Brushes.Black, xPos, yPos)

                yPos = yPos + 18
                e.Graphics.DrawString("Fecha : " & Lfecha(Fecha), prFont, Brushes.Black, xPos, yPos)

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


                StrSql = "SELECT * FROM DETALLES_COTIZACION WHERE ID_COTIZACION =" & numcotizacionanterior & " ORDER BY ID_DETALLES_COTIZACION ASC"
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
                    e.Graphics.DrawString("Estos precios estan sujetos a cambios", prFont, Brushes.Black, xPos, yPos)

                    yPos = yPos + 18
                    e.Graphics.DrawString("sin previo aviso", prFont, Brushes.Black, xPos, yPos)

                    yPos = yPos + 36
                    e.Graphics.DrawString("Gracias Por Preferirnos....", prFont, Brushes.Black, xPos, yPos)

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

    Private Sub mtbfecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mtbfecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Hide()
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
                MsgBox("Debe seleccionar una opción en Descripción", MsgBoxStyle.Information, "Creación de Cotización")
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

            If txtRef.BackColor = Color.White Then
                dgvcotizacion.Rows.Add(txtRef.Text, cmbProducto.Text, txtcantidad.Text, FormatNumber(txtprecio.Text, 2),
                FormatNumber(importe, 2), FormatNumber(itbis, 2), FormatNumber(Valor, 2), cmbIdCondicion.Text)
            Else
                dgvcotizacion.Item(0, posicion).Value = txtRef.Text
                dgvcotizacion.Item(1, posicion).Value = cmbProducto.Text
                dgvcotizacion.Item(2, posicion).Value = txtcantidad.Text
                dgvcotizacion.Item(3, posicion).Value = FormatNumber(txtprecio.Text, 2)
                dgvcotizacion.Item(4, posicion).Value = FormatNumber(importe, 2)
                dgvcotizacion.Item(5, posicion).Value = FormatNumber(itbis, 2)
                dgvcotizacion.Item(6, posicion).Value = FormatNumber(Valor, 2)
                dgvcotizacion.Item(7, posicion).Value = cmbIdCondicion.Text

                txtRef.BackColor = Color.White
                txtcantidad.BackColor = Color.White
                cmbProducto.BackColor = Color.White
                txtprecio.BackColor = Color.White

                bteliminar.Visible = False

            End If

            CalcularTotal()
            txtRef.Clear() : cmbProducto.Items.Clear() : txtcantidad.Clear() : txtprecio.Clear()
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
            ElseIf dgvcotizacion(0, 0).Value.ToString = "" Then
                MsgBox("Debe agregar un producto a la factura", MsgBoxStyle.Information)
                txtRef.Focus()
                Return
            End If

            Dim PorcientoItbis As Double = 0

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT sec FROM secuencia_cotizacion"
            Dim cmb1 As OleDbCommand = New OleDbCommand(query, Cnn)
            dr = cmb1.ExecuteReader()
            dr.Read()
            numcotizacion = dr("sec") + 1
            txtnumcotizacion.Text = numcotizacion

            dr.Close()

            trans = Cnn.BeginTransaction
            TA = True

            If cb1.Checked = True Then
                PorcientoItbis = 0
            Else
                PorcientoItbis = txtporcientoitbis.Text
            End If

            Dim myQuery As String = "INSERT INTO cotizacion (id_cotizacion, id_cliente,comentario,fecha,sub_total,itbis,total,cantidad_descuento,porciento_itbis,id_usuario) VALUES (" _
                                    & CInt(txtnumcotizacion.Text) & "," & txtIdCliente.Text & ",'" & rtbcomentario.Text _
                                    & "','" & Efecha(mtbfecha.Text) & "'," & CDec(txtsubtotal.Text) & "," & CDec(txtitbis.Text) _
                                    & "," & CDec(txttotal.Text) & "," & CDec(txtdescuento.Text) _
                                    & "," & PorcientoItbis & "," & IdUsuario & ")"

            Dim cmd3 As OleDbCommand = New OleDbCommand(myQuery, Cnn, trans)
            cmd3.Connection = Cnn
            RA = cmd3.ExecuteNonQuery

            If RA <= 0 Then
                trans.Rollback() : TA = False
                MsgBox("Error grabando el encabezado de la cotización", MsgBoxStyle.Critical)
                txtcliente.Focus()
                Return
            End If

            Dim X As Integer
            For X = 0 To dgvcotizacion.Rows.Count - 1
                If Len(Trim(dgvcotizacion(0, X).Value)) > 0 Then
                    Dim cmd4 As OleDbCommand
                    Dim myQuery1 As String = "INSERT INTO detalles_cotizacion(id_cotizacion, referencia, descripcion, cantidad, precio, importe, itbis, valor, id_condicion) VALUES (" _
                                                & CInt(txtnumcotizacion.Text) & ",'" & dgvcotizacion(0, X).Value & "','" & (dgvcotizacion(1, X).Value) _
                                                & "'," & CDbl(dgvcotizacion(2, X).Value) & "," & CDec(dgvcotizacion(3, X).Value) & "," _
                                                & CDec(dgvcotizacion(4, X).Value) & "," & CDec(dgvcotizacion(5, X).Value) & "," & CDec(dgvcotizacion(6, X).Value) & "," & dgvcotizacion(7, X).Value & ")"

                    cmd4 = New OleDbCommand(myQuery1, Cnn, trans)
                    RA = cmd4.ExecuteNonQuery()

                    If RA <= 0 Then
                        trans.Rollback() : TA = False
                        MsgBox("Error grabando el detalle de la cotizacion", MsgBoxStyle.Critical)
                        cmbProducto.Focus()
                        Return

                    End If

                Else
                    Exit For
                End If
            Next X

            Dim queryupdate As String = "UPDATE secuencia_cotizacion SET sec = " & txtnumcotizacion.Text
            Dim cmb2 As OleDbCommand = New OleDbCommand(queryupdate, Cnn, trans)
            RA = cmb2.ExecuteNonQuery()
            If RA <= 0 Then
                trans.Rollback() : TA = False
                MsgBox("Error actualizando secuencia de la cotizacion", MsgBoxStyle.Critical)
                Return
            End If

            trans.Commit() : TA = False

            numcotizacionanterior = txtnumcotizacion.Text

            '*************** I M P R E S I O N ****************************************************************
            If Impresora = "DE RECIBO" Then
                Dim printDoc As New PrintDocument
                AddHandler printDoc.PrintPage, AddressOf print_PrintPage

                printDoc.Print()

            Else

                Me.Cursor = Cursors.WaitCursor
                Dim Reporte As New Reportes
                Reporte.MdiParent = Me.MdiParent

                Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                Rpt.Load(Application.StartupPath & "\RptCotizacion.rpt")
                Rpt.SetDatabaseLogon("admin", "cladatos-ao")

                Rpt.RecordSelectionFormula = "{cotizacion.id_cotizacion} =" & numcotizacionanterior
                Reporte.CrystalReportViewer1.ReportSource = Rpt

                Rpt.DataDefinition.FormulaFields("empresa").Text = "'" & Empresa & "'"
                Rpt.DataDefinition.FormulaFields("eslogan").Text = "'" & EsloganEmp & "'"

                Rpt.DataDefinition.FormulaFields("direccion").Text = "'" & DireccionEmp & "'"
                Rpt.DataDefinition.FormulaFields("telefono").Text = "'" & TelefonoEmp & "'"
                Rpt.DataDefinition.FormulaFields("rnc").Text = "'" & RncEmp & "'"

                Reporte.Refresh()
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
        End Try

    End Sub

    Private Sub bteliminar_Click(sender As Object, e As EventArgs) Handles bteliminar.Click
        Try

            If txtRef.BackColor = Color.Yellow Then
                dgvcotizacion.Rows.Remove(dgvcotizacion.CurrentRow)
                CalcularTotal()
            End If

            txtRef.BackColor = Color.White
            txtcantidad.BackColor = Color.White
            cmbProducto.BackColor = Color.White
            txtprecio.BackColor = Color.White

            txtRef.Clear() : cmbProducto.Items.Clear() : txtprecio.Clear() : txtcantidad.Clear()
            cmbIdCondicion.Items.Clear() : cmbPrecio.Items.Clear()
            txtRef.Focus()

            bteliminar.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message)
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

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        txtsubtotal.Clear()
        txtitbis.Clear()
        txtdescuento.Text = "0.00"
        txttotal.Clear()
        txtdescuento.Text = 0.0
        cb1.Checked = True

        txtRef.Clear() : cmbProducto.Items.Clear() : txtprecio.Clear() : txtcantidad.Clear()
        cmbIdCondicion.Items.Clear() : cmbPrecio.Items.Clear()

        txtRef.BackColor = Color.White
        txtcantidad.BackColor = Color.White
        cmbProducto.BackColor = Color.White
        txtprecio.BackColor = Color.White

        Dim fecha As String = Date.Today.ToString("dd/MM/yyyy")
        mtbfecha.Text = fecha

        txtporcientoitbis.ReadOnly = True
        txtporcientoitbis.Text = p_itbis

        Try

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT sec FROM secuencia_cotizacion"
            Dim cmb1 As OleDbCommand = New OleDbCommand(query, Cnn)
            dr = cmb1.ExecuteReader()

            dr.Read()
            numcotizacion = dr("sec") + 1
            txtnumcotizacion.Text = numcotizacion

            dr.Close()
            txtrnccliente.Clear()
            txtcliente.Clear()
            txtRef.Clear() : txtcantidad.Clear() : cmbProducto.Items.Clear() : txtprecio.Clear()

            FormatGrid()

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
        End Try

    End Sub

    Private Sub txtporcientoitbis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtporcientoitbis.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtnumcotizacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumcotizacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtproductos_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtrnccliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrnccliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dgvcotizacion_DoubleClick(sender As Object, e As EventArgs) Handles dgvcotizacion.DoubleClick
        Try

            If dgvcotizacion.RowCount = 1 Then
                Return
            End If

            If Not dgvcotizacion.CurrentRow.IsNewRow Then
                txtRef.Clear() : cmbProducto.Items.Clear() : txtprecio.Clear() : txtcantidad.Clear()
                cmbIdCondicion.Items.Clear() : cmbPrecio.Items.Clear()

                posicion = dgvcotizacion.CurrentRow.Index

                If dgvcotizacion.Item(7, dgvcotizacion.CurrentRow.Index).Value > 0 Then
                    StrSql = "SELECT REFERENCIA FROM CONDICIONES WHERE ID =" & dgvcotizacion.Item(7, dgvcotizacion.CurrentRow.Index).Value
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

                txtRef.Text = dgvcotizacion.Item(0, dgvcotizacion.CurrentRow.Index).Value

                StrSql = "SELECT C.ID, C.CONDICION, C.COSTO, C.PRECIO_VENTA, I.DESCRIPCION FROM CONDICIONES C, INVENTARIO I" _
                & " WHERE C.REFERENCIA ='" & Trim(txtRef.Text) & "' AND C.REFERENCIA = I.REFERENCIA"
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    cmbIdCondicion.Items.Add(0)
                    cmbPrecio.Items.Add(0)
                    cmbProducto.Items.Add("SELECCIONA UNA OPCION ...")
                    While objReader.Read()
                        cmbIdCondicion.Items.Add(objReader("id"))
                        cmbPrecio.Items.Add(objReader("precio_venta"))
                        cmbProducto.Items.Add(objReader("descripcion").ToString & "  " & objReader("condicion").ToString)
                        cmbProducto.Text = dgvcotizacion.Item(1, dgvcotizacion.CurrentRow.Index).Value
                    End While
                    objReader.Close()

                    txtcantidad.Text = dgvcotizacion.Item(2, dgvcotizacion.CurrentRow.Index).Value
                    txtprecio.Text = dgvcotizacion.Item(3, dgvcotizacion.CurrentRow.Index).Value
                    cmbIdCondicion.Text = dgvcotizacion.Item(7, dgvcotizacion.CurrentRow.Index).Value
                    txtcantidad.Focus()

                Else
                    objReader.Close()

                    StrSql = "SELECT * FROM INVENTARIO WHERE REFERENCIA ='" & Trim(txtRef.Text) & "'"
                    objCmd = New OleDbCommand(StrSql, Cnn)
                    objReader = objCmd.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        cmbIdCondicion.Items.Add(0)
                        cmbPrecio.Items.Add(objReader("precio_venta"))
                        cmbProducto.Items.Add(objReader("descripcion").ToString)
                        cmbProducto.Text = dgvcotizacion.Item(1, dgvcotizacion.CurrentRow.Index).Value
                        txtcantidad.Text = dgvcotizacion.Item(2, dgvcotizacion.CurrentRow.Index).Value
                        txtprecio.Text = dgvcotizacion.Item(3, dgvcotizacion.CurrentRow.Index).Value
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

            End If

            txtRef.BackColor = Color.Yellow
            txtcantidad.BackColor = Color.Yellow
            cmbProducto.BackColor = Color.Yellow
            txtprecio.BackColor = Color.Yellow

            bteliminar.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub cb1_Click(sender As Object, e As EventArgs) Handles cb1.Click
        If cb1.Checked = True Then
            cb1.Font = New Font(cb1.Font, FontStyle.Bold)
        Else
            cb1.Font = New Font(cb1.Font, FontStyle.Regular)
        End If
    End Sub

    Public Sub txtRef_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRef.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                cmbPrecio.Items.Clear() : cmbProducto.Items.Clear() : cmbIdCondicion.Items.Clear()
                txtRef.Focus()

                StrSql = "SELECT C.ID, C.CONDICION, C.COSTO, C.PRECIO_VENTA, I.DESCRIPCION FROM CONDICIONES C, INVENTARIO I" _
                & " WHERE C.REFERENCIA ='" & Trim(txtRef.Text) & "' AND C.REFERENCIA = I.REFERENCIA"
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    cmbIdCondicion.Items.Add(0)
                    cmbPrecio.Items.Add(0)
                    cmbProducto.Items.Add("SELECCIONA UNA OPCION ...")
                    While objReader.Read()
                        cmbIdCondicion.Items.Add(objReader("id"))
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
                        cmbPrecio.Items.Add(objReader("precio_venta"))
                        cmbProducto.Items.Add(objReader("descripcion").ToString)
                        cmbProducto.SelectedIndex = 0

                        txtprecio.Text = FormatNumber(objReader("precio_venta"), 2)
                        objReader.Close()
                        txtcantidad.Text = 1
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

    Private Sub Cotizacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        MsgBox("Utilice el botón Salir", vbInformation)
        Return
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        FbuscarCliente.MdiParent = Fcotizacion.MdiParent
        FbuscarCliente.Tag = "Cotizacion"
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
            txtRef.Focus()
        End If
    End Sub

    Private Sub cmbProducto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedValueChanged
        cmbIdCondicion.SelectedIndex = cmbProducto.SelectedIndex
        cmbPrecio.SelectedIndex = cmbProducto.SelectedIndex
        txtprecio.Text = cmbPrecio.Text
    End Sub

    Private Sub cmbProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbProducto.KeyPress
        If cmbProducto.Text = "SELECCIONA UNA OPCION ..." Then
            MsgBox("Seleccione una Opción en la Descripción", vbInformation)
            cmbProducto.Focus()
            Return
        End If

        txtprecio.Text = FormatNumber(cmbPrecio.Text, 2)
        txtcantidad.Focus()
    End Sub

    Private Sub cmbIdCondicion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbIdCondicion.SelectedValueChanged
        cmbProducto.SelectedIndex = cmbIdCondicion.SelectedIndex
        cmbPrecio.SelectedIndex = cmbIdCondicion.SelectedIndex
    End Sub

    Private Sub Cotizacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F2 Then
            FBuscarProductos.Tag = "Cotizacion"
            FBuscarProductos.Show()
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
End Class