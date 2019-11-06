Imports System.Data.OleDb

Public Class frmCondicionesProductos
    Dim Posicion As Integer

    Public Sub FormatGrid()
        DG.Rows.Clear()
        DG.ColumnCount = 7
        DG.Columns(0).HeaderText = "ID"
        DG.Columns(1).HeaderText = "REFERENCIA"
        DG.Columns(2).HeaderText = "PRODUCTO"
        DG.Columns(3).HeaderText = "CONDICION"
        DG.Columns(4).HeaderText = "COSTO"
        DG.Columns(5).HeaderText = "PRECIO VENTA"
        DG.Columns(6).HeaderText = "COSTO PROMEDIO"

        DG.Columns(0).Visible = False
        DG.Columns(1).Width = 115
        DG.Columns(2).Width = 320
        DG.Columns(3).Width = 123
        DG.Columns(4).Width = 80
        DG.Columns(5).Width = 80
        DG.Columns(6).Visible = False

        ' desactivar los estilos visuales del sistema
        DG.EnableHeadersVisualStyles = False
        DG.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable

        DG.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DG.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DG.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        ' estilo para la cabecera del grid
        DG.ColumnHeadersDefaultCellStyle.BackColor = Color.YellowGreen
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Sub ActualizaGrid()

        FormatGrid()

        Try

            Dim Fecha As String = ""
            Dim Fecha2 As String = ""
            Dim CostoTotal As Double = 0
            Dim CostoPromedio As Double = 0
            Dim Cantidad As Integer = 0

            Fecha = Format(Today, "yyyy/MM/dd")
            Fecha2 = Format(Today.AddMonths(-1), "yyyy/MM/dd")

            StrSql = "SELECT C.ID, C.REFERENCIA, I.DESCRIPCION, C.CONDICION, C.COSTO, C.PRECIO_VENTA" _
            & " FROM CONDICIONES C, INVENTARIO I WHERE C.REFERENCIA = I.REFERENCIA ORDER BY I.DESCRIPCION ASC"
            objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
            Da = New OleDbDataAdapter(StrSql, Cnn)
            Da.Fill(Ds, "condiciones")
            If Ds.Tables("condiciones").Rows.Count > 0 Then
                For Each registro In Ds.Tables("condiciones").Rows

                    Cantidad = 0 : CostoTotal = 0 : CostoPromedio = 0

                    StrSql = "SELECT COSTO FROM ENTRADAS_PRODUCTOS WHERE REFERENCIA ='" & registro("referencia") _
                    & "' AND FECHA >='" & Fecha2 & "' AND FECHA <='" & Fecha & "'"
                    objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
                    objReader = objCmd.ExecuteReader
                    If objReader.HasRows Then
                        While objReader.Read
                            Cantidad = Cantidad + 1
                            CostoTotal = CostoTotal + objReader("costo")
                        End While
                        objReader.Close()

                        CostoPromedio = CostoTotal / Cantidad
                    Else
                        objReader.Close()

                        StrSql = "SELECT COSTO FROM INVENTARIO WHERE REFERENCIA ='" & registro("referencia") & "'"
                        objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
                        objReader = objCmd.ExecuteReader
                        If objReader.HasRows Then
                            objReader.Read()
                            CostoPromedio = objReader("costo")
                            objReader.Close()
                        Else
                            objReader.Close()
                        End If

                    End If

                    DG.Rows.Add(registro("id"), registro("referencia"), registro("descripcion"), registro("condicion").ToString,
                    FormatNumber(registro("costo"), 2), FormatNumber(registro("precio_venta"), 2), FormatNumber(CostoPromedio, 2))

                Next
            End If
            Ds.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub frmCondicionesProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizaGrid()
        txtRef.Select()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Len(Trim(txtRef.Text)) = 0 Then
            MsgBox("Debe digitar la referencia", vbInformation)
            txtRef.Focus()
            Return
        End If

        If Len(Trim(txtproducto.Text)) = 0 Then
            MsgBox("Falta la descripción del producto", vbInformation)
            txtRef.Focus()
            Return
        End If

        If Len(Trim(txtCondicion.Text)) = 0 Then
            MsgBox("Debe digitar el nombre de la condición", vbInformation)
            txtCondicion.Focus()
            Return
        End If

        If Not IsNumeric(txtCosto.Text) Then
            MsgBox("Debe digitar el costo", vbInformation)
            txtCosto.Focus()
            Return
        End If

        If Not IsNumeric(txtPrecio.Text) Then
            MsgBox("Debe digitar el precio de venta", vbInformation)
            txtPrecio.Focus()
            Return
        End If

        If txtCondicion.BackColor = Color.White Then
            StrSql = "INSERT INTO CONDICIONES(referencia, condicion, costo, precio_venta) VALUES('" & Trim(txtRef.Text) _
            & "','" & Trim(txtCondicion.Text) & "'," & CDec(txtCosto.Text) & "," & CDec(txtPrecio.Text) & ")"
            objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
            RA = objCmd.ExecuteNonQuery
            If RA > 0 Then
                ActualizaGrid()

                txtCondicion.BackColor = Color.White
                txtCosto.BackColor = Color.White
                txtPrecio.BackColor = Color.White
                'txtCP.BackColor = Color.White
                txtCondicion.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtId.Clear() ': txtCP.Clear()
                txtCondicion.Focus()
            Else
                MsgBox("No fue posible grabar la información", vbCritical)
                txtCondicion.Focus()
                Return
            End If

        Else
            If Not IsNumeric(txtId.Text) Then
                MsgBox("Debe seleccionar la condición que desea", vbInformation)
                txtCondicion.Focus()
                Return
            End If

            StrSql = "UPDATE CONDICIONES SET condicion ='" & Trim(txtCondicion.Text) & "',costo =" & CDec(txtCosto.Text) _
            & ",precio_venta =" & CDec(txtPrecio.Text) & " WHERE ID =" & CLng(txtId.Text)
            objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
            RA = objCmd.ExecuteNonQuery
            If RA > 0 Then
                ActualizaGrid()

                txtCondicion.BackColor = Color.White
                txtCosto.BackColor = Color.White
                txtPrecio.BackColor = Color.White
                'txtCP.BackColor = Color.White
                txtCondicion.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtId.Clear() ': txtCP.Clear()
                txtCondicion.Focus()
            Else
                MsgBox("No fue posible grabar la información", vbCritical)
                txtCondicion.Focus()
                Return
            End If
        End If

    End Sub

    Private Sub DG_DoubleClick(sender As Object, e As EventArgs) Handles DG.DoubleClick

        If DG.Rows.Count > 0 Then
            If Not DG.CurrentRow.IsNewRow Then
                Posicion = DG.CurrentRow.Index
                txtId.Text = DG.Item(0, DG.CurrentRow.Index).Value
                txtRef.Text = DG.Item(1, DG.CurrentRow.Index).Value
                txtproducto.Text = DG.Item(2, DG.CurrentRow.Index).Value
                txtCondicion.Text = DG.Item(3, DG.CurrentRow.Index).Value
                txtCosto.Text = DG.Item(4, DG.CurrentRow.Index).Value
                txtPrecio.Text = DG.Item(5, DG.CurrentRow.Index).Value
                'txtCP.Text = DG.Item(6, DG.CurrentRow.Index).Value

                txtCondicion.BackColor = Color.Yellow
                txtCosto.BackColor = Color.Yellow
                txtPrecio.BackColor = Color.Yellow
                'txtCP.BackColor = Color.Yellow
            End If
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try

            If txtCondicion.BackColor = Color.White Then
                txtCondicion.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtId.Clear()
                txtCondicion.Focus()
            Else

                StrSql = "SELECT TOP 1 ID_FACTURA FROM DETALLES_FACTURA WHERE ID_CONDICION =" & CLng(txtId.Text)
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    objReader.Close()
                    MsgBox("Hay facturas con esa condición. No se puede eliminar", vbCritical)
                    Return
                Else
                    objReader.Close()
                End If

                StrSql = "SELECT TOP 1 ID_COTIZACION FROM DETALLES_COTIZACION WHERE ID_CONDICION =" & CLng(txtId.Text)
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    objReader.Close()
                    MsgBox("Hay Cotizaciones con esa condición. No se puede eliminar", vbCritical)
                    Return
                Else
                    objReader.Close()
                End If

                If MessageBox.Show("Seguro que desea eliminar esa condición", "Eliminar Condición", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = vbNo Then
                        Exit Sub
                    End If

                    StrSql = "DELETE * FROM CONDICIONES WHERE ID =" & CLng(txtId.Text)
                    objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
                    RA = objCmd.ExecuteNonQuery
                    If RA > 0 Then
                        ActualizaGrid()
                        txtCondicion.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtId.Clear()
                        txtCondicion.BackColor = Color.White
                        txtCosto.BackColor = Color.White
                        txtPrecio.BackColor = Color.White
                        txtCondicion.Focus()
                    Else
                        MsgBox("No fue posible eliminar la información", vbCritical)
                        txtCondicion.Focus()
                        Return
                    End If

                End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
    End Sub

    Private Sub txtRef_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRef.KeyDown
        If e.KeyValue = Keys.F2 Then
            FBuscarProductos.Tag = "Condicion"
            FBuscarProductos.Show()
            FBuscarProductos.txtReferencia.Clear()
            FBuscarProductos.FormatGrid()
            FBuscarProductos.txtReferencia.Focus()
        End If
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Hide()
    End Sub

    Private Sub frmCondicionesProductos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        MsgBox("Use el botón salir por favor", vbInformation)
        Return
    End Sub

    Public Sub txtRef_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRef.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then

                StrSql = "SELECT * FROM INVENTARIO WHERE REFERENCIA ='" & Trim(txtRef.Text) & "'"
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    txtproducto.Text = objReader("descripcion").ToString
                    txtCosto.Text = objReader("costo").ToString
                    txtPrecio.Text = objReader("precio_venta").ToString
                    objReader.Close()
                    txtCondicion.Focus()
                    Return
                Else
                    objReader.Close()
                    txtRef.SelectionStart = 0
                    txtRef.SelectionLength = Len(txtRef.Text)
                    txtRef.Focus()
                    Return
                End If

            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message)
            Return
        End Try
    End Sub

    Private Sub txtCondicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCondicion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCosto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCosto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCosto_Leave(sender As Object, e As EventArgs) Handles txtCosto.Leave
        If IsNumeric(txtCosto.Text) Then
            txtCosto.Text = FormatNumber(txtCosto.Text, 2)
        End If
    End Sub

    Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
        If IsNumeric(txtPrecio.Text) Then
            txtPrecio.Text = FormatNumber(txtPrecio.Text, 2)
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtCondicion.BackColor = Color.White
        txtCosto.BackColor = Color.White
        txtPrecio.BackColor = Color.White
        txtRef.Clear() : txtproducto.Clear()
        txtCondicion.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtId.Clear()
        txtRef.Focus()
    End Sub
End Class