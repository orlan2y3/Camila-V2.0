Public Class frmMaestraClientes
    Dim Posicion As Integer

    Public Sub FormatGrid()
        DG.Rows.Clear()
        DG.ColumnCount = 6
        DG.Columns(0).HeaderText = "ID"
        DG.Columns(1).HeaderText = "RNC"
        DG.Columns(2).HeaderText = "CEDULA"
        DG.Columns(3).HeaderText = "NOMBRE"
        DG.Columns(4).HeaderText = "TELEFONO"
        DG.Columns(5).HeaderText = "CELULAR"

        DG.Columns(0).Visible = False
        DG.Columns(1).Width = 110
        DG.Columns(2).Width = 110
        DG.Columns(3).Width = 250
        DG.Columns(4).Width = 110
        DG.Columns(5).Width = 110

        ' desactivar los estilos visuales del sistema
        DG.EnableHeadersVisualStyles = False
        DG.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable

        ' estilo para la cabecera del grid
        DG.ColumnHeadersDefaultCellStyle.BackColor = Color.YellowGreen
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Sub ActualizaGrid()

        FormatGrid()

        Try
            StrSql = "SELECT * FROM CLIENTES ORDER BY NOMBRE ASC"
            objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                While objReader.Read()
                    DG.Rows.Add(objReader("id"), objReader("rnc").ToString, objReader("cedula").ToString, objReader("nombre").ToString, objReader("telefono").ToString, objReader("celular").ToString)
                End While
                objReader.Close()
            Else
                objReader.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub txtRnc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRnc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCedula.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtTel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTel.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCelular_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCelular.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmail.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtContacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContacto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtTelContacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelContacto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCelContacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCelContacto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtDir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDir.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmMaestraClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtRnc.BackColor = Color.White
        txtCedula.BackColor = Color.White
        txtNombre.BackColor = Color.White
        txtTel.BackColor = Color.White
        txtCelular.BackColor = Color.White
        txtEmail.BackColor = Color.White
        txtContacto.BackColor = Color.White
        txtTelContacto.BackColor = Color.White
        txtCelContacto.BackColor = Color.White
        txtDir.BackColor = Color.White

        ActualizaGrid()

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If Len(Trim(txtNombre.Text)) = 0 Then
            MsgBox("Debe digitar el nombre del cliente", vbInformation)
            txtNombre.Focus()
            Return
        End If

        Try

            If txtRnc.BackColor = Color.White Then
                StrSql = "INSERT INTO CLIENTES(rnc, cedula, nombre, direccion, telefono, celular, email, contacto, tel_contacto, cel_contacto )" _
                & " VALUES('" & Trim(txtRnc.Text) & "','" & Trim(txtCedula.Text) & "','" & Trim(txtNombre.Text) & "','" & Trim(txtDir.Text) & "','" _
                & Trim(txtTel.Text) & "','" & Trim(txtCelular.Text) & "','" & Trim(txtEmail.Text) & "','" & Trim(txtContacto.Text) & "','" _
                & Trim(txtTelContacto.Text) & "','" & Trim(txtCelContacto.Text) & "')"
                objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
                RA = objCmd.ExecuteNonQuery
                If RA > 0 Then
                    ActualizaGrid()
                    MsgBox("Ok. Cliente grabado", vbInformation)
                    btnNuevo.PerformClick()
                    Return
                Else
                    MsgBox("Error: No fue posible grabar la información", vbInformation)
                    Return
                End If
            Else
                If Not IsNumeric(txtId.Text) Then
                    MsgBox("Debe seleccionar el cliente", vbInformation)
                    DG.Focus()
                    Return
                End If

                StrSql = "UPDATE CLIENTES SET RNC ='" & Trim(txtRnc.Text) & "',cedula='" & Trim(txtCedula.Text) _
                & "',nombre='" & Trim(txtNombre.Text) & "',telefono='" & Trim(txtTel.Text) & "',celular='" & Trim(txtCelular.Text) _
                & "',email='" & Trim(txtEmail.Text) & "',contacto='" & Trim(txtContacto.Text) & "',tel_contacto='" & Trim(txtTelContacto.Text) _
                & "',cel_contacto='" & Trim(txtCelContacto.Text) & "',direccion='" & Trim(txtDir.Text) & "' WHERE ID =" & CLng(txtId.Text)
                objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
                RA = objCmd.ExecuteNonQuery
                If RA > 0 Then
                    ActualizaGrid()
                    MsgBox("Ok. Cliente actualizado", vbInformation)
                    btnNuevo.PerformClick()
                    Return
                Else
                    MsgBox("Error: No fue posible actualizar la información", vbInformation)
                    Return
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Return
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Not IsNumeric(txtId.Text) Then
            MsgBox("Debe seleccionar el cliente que desea eliminar", vbInformation)
            Return
        End If

        StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE ID_CLIENTE =" & CLng(txtId.Text)
        objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
        objReader = objCmd.ExecuteReader
        If objReader.HasRows Then
            objReader.Close()
            MsgBox("Ese cliente tiene facturas hechas, no puede ser eliminado", vbInformation)
            Return
        Else
            objReader.Close()
        End If

        StrSql = "SELECT TOP 1 ID_COTIZACION FROM COTIZACION WHERE ID_CLIENTE =" & CLng(txtId.Text)
        objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
        objReader = objCmd.ExecuteReader
        If objReader.HasRows Then
            objReader.Close()
            MsgBox("Ese cliente tiene cotizaciones hechas, no puede ser eliminado", vbInformation)
            Return
        Else
            objReader.Close()
        End If

        If MsgBox("Seguro que desea eliminar ese Cliente", vbQuestion + vbYesNo + vbDefaultButton2) = vbNo Then
            Return
        End If

        StrSql = "DELETE * FROM CLIENTES WHERE ID =" & CLng(txtId.Text)
        objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
        RA = objCmd.ExecuteNonQuery
        If RA > 0 Then
            MsgBox("Cliente eliminado", vbInformation)
            ActualizaGrid()
            btnNuevo.PerformClick()
        Else
            MsgBox("Error: No fue posible eliminar el cliente solicitado", vbInformation)
            Return
        End If

    End Sub

    Private Sub DG_DoubleClick(sender As Object, e As EventArgs) Handles DG.DoubleClick
        Try
            If IsNothing(DG.CurrentRow.Cells(0).Value) Then
                Return
            End If

            Posicion = DG.CurrentRow.Index
            txtId.Text = DG.Item(0, DG.CurrentRow.Index).Value

            StrSql = "SELECT * FROM CLIENTES WHERE ID =" & CLng(txtId.Text)
            objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                txtRnc.Text = objReader("rnc").ToString
                txtCedula.Text = objReader("cedula").ToString
                txtNombre.Text = objReader("nombre").ToString
                txtTel.Text = objReader("telefono").ToString
                txtCelular.Text = objReader("celular").ToString
                txtEmail.Text = objReader("email").ToString
                txtContacto.Text = objReader("contacto").ToString
                txtTelContacto.Text = objReader("tel_contacto").ToString
                txtCelContacto.Text = objReader("cel_contacto").ToString
                txtDir.Text = objReader("direccion").ToString
                objReader.Close()

                txtRnc.BackColor = Color.Yellow
                txtCedula.BackColor = Color.Yellow
                txtNombre.BackColor = Color.Yellow
                txtTel.BackColor = Color.Yellow
                txtCelular.BackColor = Color.Yellow
                txtEmail.BackColor = Color.Yellow
                txtContacto.BackColor = Color.Yellow
                txtTelContacto.BackColor = Color.Yellow
                txtCelContacto.BackColor = Color.Yellow
                txtDir.BackColor = Color.Yellow

                btnEliminar.Enabled = True
            Else
                objReader.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtId.Clear() : txtRnc.Clear() : txtCedula.Clear() : txtNombre.Clear() : txtDir.Clear() : txtTel.Clear() : txtCelular.Clear()
        txtEmail.Clear() : txtContacto.Clear() : txtTelContacto.Clear() : txtCelContacto.Clear() : txtDir.Clear()

        txtRnc.BackColor = Color.White
        txtCedula.BackColor = Color.White
        txtNombre.BackColor = Color.White
        txtDir.BackColor = Color.White
        txtTel.BackColor = Color.White
        txtCelular.BackColor = Color.White
        txtEmail.BackColor = Color.White
        txtContacto.BackColor = Color.White
        txtTelContacto.BackColor = Color.White
        txtCelContacto.BackColor = Color.White
        txtDir.BackColor = Color.White

        btnEliminar.Enabled = False
        txtRnc.Focus()

    End Sub

    Private Sub txtNombre_Leave(sender As Object, e As EventArgs) Handles txtNombre.Leave
        If Len(Trim(txtNombre.Text)) > 0 Then
            txtNombre.Text = UCase(txtNombre.Text)
        End If
    End Sub
End Class