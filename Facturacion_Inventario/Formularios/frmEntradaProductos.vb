Imports System.Data.OleDb

Public Class frmEntradaProductos
    Dim Posicion As Integer
    Dim trans As OleDbTransaction

    Public Sub FormatGrid()
        DG.Rows.Clear()
        DG.ColumnCount = 6
        DG.Columns(0).HeaderText = "REFERENCIA"
        DG.Columns(1).HeaderText = "DESCRIPCION"
        DG.Columns(2).HeaderText = "COSTO"
        DG.Columns(3).HeaderText = "PRECIO VENTA"
        DG.Columns(4).HeaderText = "CANTIDAD"
        DG.Columns(5).HeaderText = "EXISTENCIA MINIMA"

        DG.Columns(0).Width = 150
        DG.Columns(1).Width = 350
        DG.Columns(2).Width = 80
        DG.Columns(3).Width = 80
        DG.Columns(4).Width = 70
        DG.Columns(5).Width = 75

        ' desactivar los estilos visuales del sistema
        DG.EnableHeadersVisualStyles = False
        DG.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable

        DG.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DG.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DG.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DG.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        ' estilo para la cabecera del grid
        DG.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        DG.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Private Sub frmEntradaProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormatGrid()
        txtRef.BackColor = Color.White
        txtDescrip.BackColor = Color.White
        txtCosto.BackColor = Color.White
        txtPrecio.BackColor = Color.White
        txtCant.BackColor = Color.White
        txtExistenciaMin.BackColor = Color.White

        txtRef.Select()
    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        If Len(Trim(txtRef.Text)) = 0 Then
            MsgBox("Debe digitar la referencia", vbInformation)
            txtRef.Focus()
            Return
        End If
        If InStr(txtRef.Text, "'") Then
            MsgBox("La Referencia tiene un caracter no permitido.  Ese: (')", vbInformation)
            txtRef.Focus()
            Return
        End If

        If Len(Trim(txtDescrip.Text)) = 0 Then
            MsgBox("Debe digitar la descripción del producto", vbInformation)
            txtDescrip.Focus()
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

        If Not IsNumeric(txtCant.Text) Then
            MsgBox("Debe digitar la cantidad", vbInformation)
            txtCant.Focus()
            Return
        End If
        If Not IsNumeric(txtExistenciaMin.Text) Then
            txtExistenciaMin.Text = 0
        End If

        If InStr(txtDescrip.Text, "'") Then
            txtDescrip.Text = Cambiar(txtDescrip.Text)
        End If

        If txtRef.BackColor = Color.White Then
            DG.Rows.Add(Trim(txtRef.Text), Trim(txtDescrip.Text), FormatNumber(txtCosto.Text, 2), FormatNumber(txtPrecio.Text, 2), FormatNumber(txtCant.Text, 0), CDbl(txtExistenciaMin.Text))
        Else
            DG.Item(0, Posicion).Value = Trim(txtRef.Text)
            DG.Item(1, Posicion).Value = Trim(txtDescrip.Text)
            DG.Item(2, Posicion).Value = FormatNumber(txtCosto.Text, 2)
            DG.Item(3, Posicion).Value = FormatNumber(txtPrecio.Text, 2)
            DG.Item(4, Posicion).Value = FormatNumber(txtCant.Text, 0)
            DG.Item(5, Posicion).Value = FormatNumber(txtExistenciaMin.Text, 0)

            txtRef.BackColor = Color.White
            txtDescrip.BackColor = Color.White
            txtCosto.BackColor = Color.White
            txtPrecio.BackColor = Color.White
            txtCant.BackColor = Color.White
            txtExistenciaMin.BackColor = Color.White
        End If

        txtRef.Clear() : txtDescrip.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtCant.Clear() : txtExistenciaMin.Clear()
        txtRef.Focus()

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtRef.Clear() : txtDescrip.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtCant.Clear() : txtExistenciaMin.Clear()

        txtRef.BackColor = Color.White
        txtDescrip.BackColor = Color.White
        txtCosto.BackColor = Color.White
        txtPrecio.BackColor = Color.White
        txtCant.BackColor = Color.White
        txtExistenciaMin.BackColor = Color.White
        txtRef.Focus()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Try

            If txtRef.BackColor = Color.White Then
                txtRef.Clear() : txtDescrip.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtCant.Clear() : txtExistenciaMin.Clear()
                txtRef.Focus()
            Else
                If MessageBox.Show("Seguro que desea eliminar esa entrada", "Eliminar Entrada", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = vbNo Then
                    Exit Sub
                End If

                DG.Rows.RemoveAt(Posicion)

                txtRef.Clear() : txtDescrip.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtCant.Clear() : txtExistenciaMin.Clear()

                txtRef.BackColor = Color.White
                txtDescrip.BackColor = Color.White
                txtCosto.BackColor = Color.White
                txtPrecio.BackColor = Color.White
                txtCant.BackColor = Color.White
                txtExistenciaMin.BackColor = Color.White
                txtRef.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try

            If DG.Rows.Count <= 0 Then
                MsgBox("Debe registrar los productos que desea grabar", vbInformation)
                txtRef.Focus()
                Return
            End If

            Me.Cursor = Cursors.WaitCursor

            trans = Cnn.BeginTransaction
            TA = True

            Dim X As Integer
            Dim Existencia As Long = 0

            For X = 0 To DG.Rows.Count - 1

                If Len(Trim(DG(0, X).ToString)) > 0 Then
                    StrSql = "INSERT INTO entradas_productos(referencia, descripcion, costo, precio_venta, cantidad, fecha, id_usuario)" _
                    & " VALUES('" & DG(0, X).Value & "','" & DG(1, X).Value & "'," & CDec(DG(2, X).Value) _
                    & "," & CDec(DG(3, X).Value) & "," & CDbl(DG(4, X).Value) & ",'" & Format(Today, "yyyy/MM/dd") & "'," & IdUsuario & ")"
                    objCmd = New OleDbCommand(StrSql, Cnn, trans)
                    RA = objCmd.ExecuteNonQuery()
                    If RA > 0 Then
                        StrSql = "SELECT TOP 1 ID FROM INVENTARIO WHERE REFERENCIA ='" & DG(0, X).Value & "'"
                        objCmd = New OleDbCommand(StrSql, Cnn, trans)
                        objReader = objCmd.ExecuteReader
                        If objReader.HasRows Then
                            objReader.Close()

                            StrSql = "UPDATE INVENTARIO SET EXISTENCIA = EXISTENCIA + " & CDbl(DG(4, X).Value) & ",EXISTENCIA_MINIMA =" & CDbl(DG(5, X).Value) _
                            & ",DESCRIPCION ='" & DG(1, X).Value & "',COSTO=" & CDec(DG(2, X).Value) & ",PRECIO_VENTA=" & CDec(DG(3, X).Value) _
                            & " WHERE REFERENCIA ='" & DG(0, X).Value & "'"
                            objCmd = New OleDbCommand(StrSql, Cnn, trans)
                            RA = objCmd.ExecuteNonQuery()
                            If RA <= 0 Then
                                trans.Rollback() : TA = False
                                MsgBox("Error actualizando existencia en el inventario", MsgBoxStyle.Critical)
                                txtRef.Focus()
                                Return
                            End If

                        Else
                            objReader.Close()

                            StrSql = "INSERT INTO INVENTARIO(referencia, descripcion, costo, precio_venta, existencia, existencia_minima)" _
                             & " VALUES('" & DG(0, X).Value & "','" & DG(1, X).Value & "'," & CDec(DG(2, X).Value) _
                             & "," & CDec(DG(3, X).Value) & "," & CDbl(DG(4, X).Value) & "," & CDbl(DG(5, X).Value) & ")"
                            objCmd = New OleDbCommand(StrSql, Cnn, trans)
                            RA = objCmd.ExecuteNonQuery()
                            If RA <= 0 Then
                                trans.Rollback() : TA = False
                                MsgBox("Error grabando el inventario", MsgBoxStyle.Critical)
                                txtRef.Focus()
                                Return
                            End If

                        End If

                    Else
                        trans.Rollback() : TA = False
                        MsgBox("Error grabando productos", MsgBoxStyle.Critical)
                        txtRef.Focus()
                        Return
                    End If

                Else
                    Exit For
                End If

            Next X

            trans.Commit() : TA = False
            FormatGrid()
            Me.Cursor = Cursors.Default
            MsgBox("Ok. Productos grabados", vbInformation)
            txtRef.Focus()

        Catch ex As Exception
            If TA = True Then
                trans.Rollback() : TA = False
            End If
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub txtRef_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRef.KeyPress
        Try

            If e.KeyChar = ChrW(Keys.Enter) Then

                If Len(Trim(txtRef.Text)) = 0 Then
                    MsgBox("Debe digitar la referencia", vbInformation)
                    txtRef.Focus()
                    Return
                End If

                StrSql = "SELECT * FROM INVENTARIO WHERE REFERENCIA ='" & Trim(txtRef.Text) & "'"
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    txtDescrip.Text = objReader("descripcion").ToString
                    txtCosto.Text = objReader("costo")
                    txtPrecio.Text = objReader("precio_venta")
                    txtExistenciaMin.Text = objReader("existencia_minima")
                    objReader.Close()
                    txtCant.Focus()
                    Return
                Else
                    objReader.Close()
                    txtDescrip.Focus()
                    Return
                End If

            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub txtDescrip_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescrip.KeyPress
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

    Private Sub txtCant_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCant.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DG_DoubleClick(sender As Object, e As EventArgs) Handles DG.DoubleClick

        If DG.Rows.Count > 0 Then
            If Not DG.CurrentRow.IsNewRow Then
                Posicion = DG.CurrentRow.Index
                txtRef.Text = DG.Item(0, DG.CurrentRow.Index).Value
                txtDescrip.Text = DG.Item(1, DG.CurrentRow.Index).Value
                txtCosto.Text = DG.Item(2, DG.CurrentRow.Index).Value
                txtPrecio.Text = DG.Item(3, DG.CurrentRow.Index).Value
                txtCant.Text = DG.Item(4, DG.CurrentRow.Index).Value
                txtExistenciaMin.Text = DG.Item(5, DG.CurrentRow.Index).Value

                txtRef.BackColor = Color.Yellow
                txtDescrip.BackColor = Color.Yellow
                txtCosto.BackColor = Color.Yellow
                txtPrecio.BackColor = Color.Yellow
                txtCant.BackColor = Color.Yellow
                txtExistenciaMin.BackColor = Color.Yellow
            End If
        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If DG.Rows.Count > 0 Then
            If MessageBox.Show("(O J O) - Seguro que desea salir sin grabar los productos ? ?", "Entrada Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = vbNo Then
                txtRef.Focus()
                Exit Sub
            End If
        End If

        Me.Hide()

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

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExistenciaMin.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmEntradaProductos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        MsgBox("Use el botón salir por favor", vbInformation)
        Return

    End Sub
End Class