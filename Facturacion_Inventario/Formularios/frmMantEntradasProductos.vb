Imports System.Data.OleDb

Public Class frmMantEntradasProductos

    Dim Posicion As Integer
    Dim fecha1 As Boolean
    Dim trans As OleDbTransaction

    Public Sub FormatGrid()
        DG.Rows.Clear()
        DG.ColumnCount = 8
        DG.Columns(0).HeaderText = "ID"
        DG.Columns(1).HeaderText = "FECHA"
        DG.Columns(2).HeaderText = "REFERENCIA"
        DG.Columns(3).HeaderText = "DESCRIPCION"
        DG.Columns(4).HeaderText = "COSTO"
        DG.Columns(5).HeaderText = "PRECIO VENTA"
        DG.Columns(6).HeaderText = "CANTIDAD"
        DG.Columns(7).HeaderText = "EXISTENCIA MINIMA"

        DG.Columns(0).Visible = False
        DG.Columns(1).Width = 80
        DG.Columns(2).Width = 110
        DG.Columns(3).Width = 300
        DG.Columns(4).Width = 80
        DG.Columns(5).Width = 80
        DG.Columns(6).Width = 75
        DG.Columns(7).Width = 80

        ' desactivar los estilos visuales del sistema
        DG.EnableHeadersVisualStyles = False

        DG.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable

        DG.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DG.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DG.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DG.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        ' estilo para la cabecera del grid
        DG.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        DG.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Private Sub frmMantEntradasProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtbfecha1.Text = Format(Date.Today, "dd/MM/yyyy")
        mtbfecha2.Text = Format(Date.Today, "dd/MM/yyyy")
        mc.Visible = False

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
        If Not IsNumeric(txtId.Text) Then
            MsgBox("Debe seleccionar el producto que desea modificar", vbInformation)
            txtRef.Focus()
            Return
        End If
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

        If MsgBox("Seguro que desea actualizar esa entrada ?", vbQuestion + vbYesNo + vbDefaultButton2) = vbNo Then
            txtRef.BackColor = Color.White
            txtDescrip.BackColor = Color.White
            txtCosto.BackColor = Color.White
            txtPrecio.BackColor = Color.White
            txtCant.BackColor = Color.White
            txtExistenciaMin.BackColor = Color.White

            txtId.Clear() : txtFecha.Clear() : txtCantAnt.Clear()
            txtRef.Clear() : txtDescrip.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtCant.Clear() : txtExistenciaMin.Clear()
            txtRef.Focus()
            Exit Sub
        End If

        Try

            trans = Cnn.BeginTransaction() : TA = True

            StrSql = "UPDATE ENTRADAS_PRODUCTOS SET DESCRIPCION ='" & txtDescrip.Text & "',COSTO =" & CDec(txtCosto.Text) _
                & ",PRECIO_VENTA = " & CDec(txtPrecio.Text) & ",CANTIDAD =" & txtCant.Text _
                & " WHERE ID =" & txtId.Text
            objCmd = New OleDbCommand(StrSql, Cnn, trans)
            RA = objCmd.ExecuteNonQuery()
            If RA > 0 Then
                StrSql = "UPDATE INVENTARIO SET EXISTENCIA = EXISTENCIA - " & CDbl(txtCantAnt.Text) _
                & " WHERE REFERENCIA ='" & Trim(txtRef.Text) & "'"
                objCmd = New OleDbCommand(StrSql, Cnn, trans)
                RA = objCmd.ExecuteNonQuery()
                If RA > 0 Then
                    StrSql = "UPDATE INVENTARIO SET EXISTENCIA = EXISTENCIA + " & CDbl(txtCant.Text) _
                        & ",DESCRIPCION ='" & Trim(txtDescrip.Text) & "',COSTO =" & CDec(txtCosto.Text) _
                        & ",PRECIO_VENTA =" & CDec(txtPrecio.Text) & ",EXISTENCIA_MINIMA =" & CDbl(txtExistenciaMin.Text) _
                        & " WHERE REFERENCIA ='" & Trim(txtRef.Text) & "'"
                    objCmd = New OleDbCommand(StrSql, Cnn, trans)
                    RA = objCmd.ExecuteNonQuery()
                    If RA > 0 Then
                        trans.Commit() : TA = False

                        DG.Item(1, Posicion).Value = txtFecha.Text
                        DG.Item(2, Posicion).Value = Trim(txtRef.Text)
                        DG.Item(3, Posicion).Value = Trim(txtDescrip.Text)
                        DG.Item(4, Posicion).Value = FormatNumber(txtCosto.Text, 2)
                        DG.Item(5, Posicion).Value = FormatNumber(txtPrecio.Text, 2)
                        DG.Item(6, Posicion).Value = FormatNumber(txtCant.Text, 0)
                        DG.Item(7, Posicion).Value = FormatNumber(txtExistenciaMin.Text, 0)

                        txtRef.BackColor = Color.White
                        txtDescrip.BackColor = Color.White
                        txtCosto.BackColor = Color.White
                        txtPrecio.BackColor = Color.White
                        txtCant.BackColor = Color.White
                        txtExistenciaMin.BackColor = Color.White

                        txtId.Clear() : txtFecha.Clear() : txtCantAnt.Clear()
                        txtRef.Clear() : txtDescrip.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtCant.Clear() : txtExistenciaMin.Clear()
                        txtRef.Focus()

                        MsgBox("Entrada actualizada", MsgBoxStyle.Information)
                        Return

                    Else
                        trans.Rollback() : TA = False
                        MsgBox("Error actualizando los datos en el inventario", MsgBoxStyle.Critical)
                        Return
                    End If
                Else
                    trans.Rollback() : TA = False
                    MsgBox("Error actualizando la existencia en el inventario", MsgBoxStyle.Critical)
                    Return
                End If
            Else
                trans.Rollback() : TA = False
                MsgBox("Error actualizando la entrada del producto", MsgBoxStyle.Critical)
                Return
            End If

        Catch ex As Exception
            If TA = True Then
                trans.Rollback() : TA = False
            End If
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Try

            If txtRef.BackColor = Color.White Then
                txtId.Clear() : txtFecha.Clear() : txtCantAnt.Clear()
                txtRef.Clear() : txtDescrip.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtCant.Clear() : txtExistenciaMin.Clear()
                txtRef.Focus()
            Else
                If MessageBox.Show("Seguro que desea ELIMINAR esa entrada ?", "Eliminar Entrada", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = vbNo Then

                    txtRef.BackColor = Color.White
                    txtDescrip.BackColor = Color.White
                    txtCosto.BackColor = Color.White
                    txtPrecio.BackColor = Color.White
                    txtCant.BackColor = Color.White
                    txtExistenciaMin.BackColor = Color.White

                    txtId.Clear() : txtFecha.Clear() : txtCantAnt.Clear()
                    txtRef.Clear() : txtDescrip.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtCant.Clear() : txtExistenciaMin.Clear()
                    txtRef.Focus()

                    Exit Sub
                End If

                trans = Cnn.BeginTransaction : TA = True

                StrSql = "DELETE * FROM ENTRADAS_PRODUCTOS WHERE ID =" & txtId.Text
                objCmd = New OleDbCommand(StrSql, Cnn, trans)
                RA = objCmd.ExecuteNonQuery()
                If RA > 0 Then
                    StrSql = "UPDATE INVENTARIO SET EXISTENCIA = EXISTENCIA - " & CDbl(txtCantAnt.Text) _
                    & " WHERE REFERENCIA ='" & Trim(txtRef.Text) & "'"
                    objCmd = New OleDbCommand(StrSql, Cnn, trans)
                    RA = objCmd.ExecuteNonQuery()
                    If RA > 0 Then
                        trans.Commit() : TA = False

                        DG.Rows.RemoveAt(Posicion)

                        txtRef.BackColor = Color.White
                        txtDescrip.BackColor = Color.White
                        txtCosto.BackColor = Color.White
                        txtPrecio.BackColor = Color.White
                        txtCant.BackColor = Color.White
                        txtExistenciaMin.BackColor = Color.White

                        txtId.Clear() : txtFecha.Clear() : txtCantAnt.Clear()
                        txtRef.Clear() : txtDescrip.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtCant.Clear() : txtExistenciaMin.Clear()
                        txtRef.Focus()

                        MsgBox("Entrada Eliminada", MsgBoxStyle.Information)
                        Return
                    Else
                        trans.Rollback() : TA = False
                        MsgBox("Error actualizando los datos en el inventario", MsgBoxStyle.Critical)
                        Return
                    End If
                Else
                    trans.Rollback() : TA = False
                    MsgBox("Error eliminando la entrada del producto", MsgBoxStyle.Critical)
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
                txtId.Text = DG.Item(0, DG.CurrentRow.Index).Value
                txtFecha.Text = DG.Item(1, DG.CurrentRow.Index).Value
                txtRef.Text = DG.Item(2, DG.CurrentRow.Index).Value
                txtDescrip.Text = DG.Item(3, DG.CurrentRow.Index).Value
                txtCosto.Text = DG.Item(4, DG.CurrentRow.Index).Value
                txtPrecio.Text = DG.Item(5, DG.CurrentRow.Index).Value
                txtCant.Text = DG.Item(6, DG.CurrentRow.Index).Value
                txtCantAnt.Text = DG.Item(6, DG.CurrentRow.Index).Value
                txtExistenciaMin.Text = DG.Item(7, DG.CurrentRow.Index).Value

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
        Me.Close()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fecha1 = True

        If mc.Visible = False Then
            mc.Visible = True
            mc.Focus()
        Else
            mc.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fecha1 = False

        If mc.Visible = True Then
            mc.Visible = False
        Else
            mc.Visible = True
            mc.Focus()
        End If

    End Sub

    Private Sub mc_DateSelected(sender As Object, e As DateRangeEventArgs) Handles mc.DateSelected
        If fecha1 = True Then
            mtbfecha1.Text = mc.SelectionRange.Start.ToString("dd/MM/yyyy")
        Else
            mtbfecha2.Text = mc.SelectionRange.Start.ToString("dd/MM/yyyy")
        End If
        mc.Visible = False
    End Sub

    Private Sub mc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mc.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            mc.Visible = False
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        FormatGrid()

        Try

            StrSql = "SELECT ID, REFERENCIA, DESCRIPCION, COSTO, PRECIO_VENTA, CANTIDAD, FECHA" _
            & " FROM ENTRADAS_PRODUCTOS" _
            & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
            & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "'"
            Da = New OleDbDataAdapter(StrSql, Cnn)
            Da.Fill(Ds, "ENTRADAS")
            For Each registro In Ds.Tables("ENTRADAS").Rows

                Dim ExistenciaMinima As Double = 0

                StrSql = "SELECT EXISTENCIA_MINIMA FROM INVENTARIO" _
                & " WHERE REFERENCIA ='" & registro("referencia") & "'"
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    ExistenciaMinima = objReader("existencia_minima")
                    objReader.Close()
                Else
                    ExistenciaMinima = 0
                    objReader.Close()
                End If

                DG.Rows.Add(registro("id"), Lfecha(registro("fecha")), registro("referencia"), registro("descripcion"), FormatNumber(registro("costo"), 2),
                FormatNumber(registro("precio_venta"), 2), FormatNumber(registro("cantidad"), 0), ExistenciaMinima)
            Next

            Ds.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

End Class