Public Class frmBuscarCliente
    Dim Posicion As Integer

    Public Sub FormatGrid()
        DG.Rows.Clear()
        DG.ColumnCount = 5
        DG.Columns(0).HeaderText = "RNC"
        DG.Columns(1).HeaderText = "CEDULA"
        DG.Columns(2).HeaderText = "NOMBRE"
        DG.Columns(3).HeaderText = "TELEFONO"
        DG.Columns(4).HeaderText = "ID CLIENTE"

        DG.Columns(0).Width = 110
        DG.Columns(1).Width = 110
        DG.Columns(2).Width = 250
        DG.Columns(3).Width = 110
        DG.Columns(4).Visible = False

        ' desactivar los estilos visuales del sistema
        DG.EnableHeadersVisualStyles = False
        DG.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable

        ' estilo para la cabecera del grid
        DG.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Private Sub frmBuscarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormatGrid()
        txtNombre.Select()
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            btsalir.PerformClick()
        End If
    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click

        If Len(Trim(txtNombre.Text)) = 0 Then
            MsgBox("Digite las primeras letras del nombre que desea buscar", vbInformation)
            txtNombre.Focus()
            Return
        End If

        FormatGrid()

        Try
            StrSql = "SELECT TOP 50 RNC, CEDULA, NOMBRE, TELEFONO, ID FROM CLIENTES WHERE NOMBRE LIKE '%" & Trim(txtNombre.Text) & "%'"
            objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                While objReader.Read()
                    DG.Rows.Add(objReader("rnc").ToString, objReader("cedula").ToString, objReader("nombre").ToString, objReader("telefono").ToString, objReader("id"))
                End While
                objReader.Close()
                DG.Focus()
                DG.Item(0, 0).Selected = True
            Else
                objReader.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Hide()
    End Sub

    Private Sub DG_DoubleClick(sender As Object, e As EventArgs) Handles DG.DoubleClick
        If DG.CurrentRow.IsNewRow Then
            Return
        End If

        If Me.Tag = "Factura" Then
            Ffactura.txtIdCliente.Text = DG.CurrentRow.Cells(4).Value
            Ffactura.txtrnccliente.Text = DG.CurrentRow.Cells(0).Value
            Ffactura.txtcliente.Text = DG.CurrentRow.Cells(2).Value
            Ffactura.Show()
            Ffactura.txtRef.Focus()
            Me.Hide()
        End If

        If Me.Tag = "MantFactura" Then
            FmantFacturas.txtIdCliente.Text = DG.CurrentRow.Cells(4).Value
            FmantFacturas.txtrnccliente.Text = DG.CurrentRow.Cells(0).Value
            FmantFacturas.txtcliente.Text = DG.CurrentRow.Cells(2).Value
            FmantFacturas.Show()
            FmantFacturas.txtRef.Focus()
            Me.Hide()
        End If

        If Me.Tag = "Cotizacion" Then
            Fcotizacion.txtIdCliente.Text = DG.CurrentRow.Cells(4).Value
            Fcotizacion.txtrnccliente.Text = DG.CurrentRow.Cells(0).Value
            Fcotizacion.txtcliente.Text = DG.CurrentRow.Cells(2).Value
            Fcotizacion.Show()
            Fcotizacion.txtRef.Focus()
            Me.Hide()
        End If

        If Me.Tag = "MantCotizacion" Then
            FmantCotizacion.txtIdCliente.Text = DG.CurrentRow.Cells(4).Value
            FmantCotizacion.txtcliente.Text = DG.CurrentRow.Cells(2).Value
            FmantCotizacion.Show()
            FmantCotizacion.txtRef.Focus()
            Me.Hide()
        End If

    End Sub

    Private Sub frmBuscarCliente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

                If Me.Tag = "Factura" Then
                    'Ffactura.txtIdCliente.Text = DG.CurrentRow.Cells(3).Value
                    Ffactura.txtIdCliente.Text = DG.Item(4, Posicion).Value
                    Ffactura.txtrnccliente.Text = DG.Item(0, Posicion).Value
                    Ffactura.txtcliente.Text = DG.Item(2, Posicion).Value
                    Ffactura.Show()
                    Ffactura.txtRef.Focus()
                    Me.Hide()
                End If

                If Me.Tag = "Cotizacion" Then
                    Fcotizacion.txtIdCliente.Text = DG.Item(4, Posicion).Value
                    Fcotizacion.txtrnccliente.Text = DG.Item(0, Posicion).Value
                    Fcotizacion.txtcliente.Text = DG.Item(2, Posicion).Value
                    Fcotizacion.Show()
                    Fcotizacion.txtRef.Focus()
                    Me.Hide()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub
End Class