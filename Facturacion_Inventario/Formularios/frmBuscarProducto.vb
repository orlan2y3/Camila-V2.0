Imports System.Data.OleDb

Public Class frmBuscarProducto
    Dim Posicion As Integer

    Public Sub FormatGrid()
        DG.Rows.Clear()
        DG.ColumnCount = 5
        DG.Columns(0).HeaderText = "REFERENCIA"
        DG.Columns(1).HeaderText = "DESCRIPCION"
        DG.Columns(2).HeaderText = "COSTO"
        DG.Columns(3).HeaderText = "PRECIO VENTA"
        DG.Columns(4).HeaderText = "EXISTENCIA"

        DG.Columns(0).Width = 150
        DG.Columns(1).Width = 455
        DG.Columns(2).Width = 90
        DG.Columns(3).Width = 90
        DG.Columns(4).Width = 80

        ' desactivar los estilos visuales del sistema
        DG.EnableHeadersVisualStyles = False
        DG.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable

        DG.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DG.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DG.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        DG.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        ' estilo para la cabecera del grid
        DG.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Try
            FormatGrid()

            If Len(Trim(txtReferencia.Text)) > 0 Then
                StrSql = "SELECT TOP 125 referencia, descripcion, costo, precio_venta, existencia" _
                & " FROM inventario WHERE descripcion Like '" & Trim(txtReferencia.Text) & "%' ORDER BY descripcion ASC"
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    While objReader.Read
                        DG.Rows.Add(objReader("referencia").ToString, objReader("descripcion").ToString, objReader("costo"), objReader("precio_venta"), objReader("existencia"))
                    End While
                    objReader.Close()
                    DG.Focus()
                    DG.Item(0, 0).Selected = True
                Else
                    objReader.Close()
                End If
            Else
                MsgBox("Digite las primeras letras del producto que desea y dele clic al botón buscar", vbInformation)
                txtReferencia.Focus()
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub frmBuscarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DG.ColumnHeadersDefaultCellStyle.BackColor = Color.Coral
        FormatGrid()
        txtReferencia.Select()
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Hide()
    End Sub

    Private Sub txtReferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReferencia.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Len(Trim(txtReferencia.Text)) > 0 Then
                btbuscar.PerformClick()
            End If
        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            btsalir.PerformClick()
        End If

    End Sub

    Private Sub frmListadoProductos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        MsgBox("Use el botón Salir", vbInformation)
    End Sub

    Private Sub DG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DG.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Try

                Posicion = DG.CurrentCell.RowIndex - 1
                If Posicion = -1 Then
                    Return
                End If

                Dim valor As String
                valor = DG.Item(0, Posicion).Value

                If IsNothing(DG.Item(0, Posicion).Value) Then
                    Return
                End If

                If Me.Tag = "frmMantInventario" Then
                    FmantInventario.txtBref.Text = DG.Item(0, Posicion).Value
                    txtReferencia.Clear()
                    FormatGrid()
                    FmantInventario.btnBuscar.PerformClick()
                    FmantInventario.Show()
                    Me.Hide()
                End If


                If Me.Tag = "Factura" Then
                    Ffactura.txtRef.Text = DG.Item(0, Posicion).Value
                    txtReferencia.Clear()
                    FormatGrid()
                    Ffactura.Show()

                    Dim Argumento As New KeyPressEventArgs(Convert.ToChar(13))
                    Call Ffactura.txtRef_KeyPress(sender, Argumento)

                    Me.Hide()
                End If

                If Me.Tag = "MantFactura" Then
                    FmantFacturas.txtRef.Text = DG.Item(0, Posicion).Value
                    txtReferencia.Clear()
                    FormatGrid()
                    FmantFacturas.Show()

                    Dim Argumento As New KeyPressEventArgs(Convert.ToChar(13))
                    Call FmantFacturas.txtRef_KeyPress(sender, Argumento)

                    Me.Hide()
                End If


                If Me.Tag = "Cotizacion" Then
                    Fcotizacion.txtRef.Text = DG.Item(0, Posicion).Value
                    txtReferencia.Clear()
                    FormatGrid()
                    Fcotizacion.Show()

                    Dim Argumento As New KeyPressEventArgs(Convert.ToChar(13))
                    Call Fcotizacion.txtRef_KeyPress(sender, Argumento)

                    Me.Hide()
                End If

                If Me.Tag = "MantCotizacion" Then
                    FmantCotizacion.txtRef.Text = DG.Item(0, Posicion).Value
                    txtReferencia.Clear()
                    FormatGrid()
                    FmantCotizacion.Show()

                    Dim Argumento As New KeyPressEventArgs(Convert.ToChar(13))
                    Call FmantCotizacion.txtRef_KeyPress(sender, Argumento)

                    Me.Hide()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub

    Private Sub DG_DoubleClick(sender As Object, e As EventArgs) Handles DG.DoubleClick
        Try
            If Not DG.CurrentRow.IsNewRow Then
                If Me.Tag = "frmMantInventario" Then
                    FmantInventario.txtBref.Text = DG.Item(0, DG.CurrentRow.Index).Value
                    txtReferencia.Clear()
                    FormatGrid()
                    FmantInventario.btnBuscar.PerformClick()
                    FmantInventario.Show()
                    Me.Hide()
                End If

                If Me.Tag = "Factura" Then
                    Ffactura.txtRef.Text = DG.Item(0, DG.CurrentRow.Index).Value
                    txtReferencia.Clear()
                    FormatGrid()
                    Ffactura.Show()

                    Dim Argumento As New KeyPressEventArgs(Convert.ToChar(13))
                    Call Ffactura.txtRef_KeyPress(sender, Argumento)

                    Me.Hide()
                End If

                If Me.Tag = "Cotizacion" Then
                    Fcotizacion.txtRef.Text = DG.Item(0, DG.CurrentRow.Index).Value
                    txtReferencia.Clear()
                    FormatGrid()
                    Fcotizacion.Show()

                    Dim Argumento As New KeyPressEventArgs(Convert.ToChar(13))
                    Call Fcotizacion.txtRef_KeyPress(sender, Argumento)

                    Me.Hide()
                End If

                If Me.Tag = "MantCotizacion" Then
                    FmantCotizacion.txtRef.Text = DG.Item(0, DG.CurrentRow.Index).Value
                    txtReferencia.Clear()
                    FormatGrid()
                    FmantCotizacion.Show()

                    Dim Argumento As New KeyPressEventArgs(Convert.ToChar(13))
                    Call FmantCotizacion.txtRef_KeyPress(sender, Argumento)

                    Me.Hide()
                End If

                If Me.Tag = "Condicion" Then
                    Fcondicion.txtRef.Text = DG.Item(0, DG.CurrentRow.Index).Value
                    txtReferencia.Clear()
                    FormatGrid()
                    Fcondicion.Show()

                    Dim Argumento As New KeyPressEventArgs(Convert.ToChar(13))
                    Call Fcondicion.txtRef_KeyPress(sender, Argumento)

                    Me.Hide()
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class