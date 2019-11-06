Imports System.Data.OleDb

Public Class frmDatosEmpresa
    Private Sub frmDatosEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNombre.Text = Empresa
        txtRnc.Text = RncEmp
        txtEslogan.Text = EsloganEmp
        txtTelefonos.Text = TelefonoEmp
        txtDireccion.Text = DireccionEmp
        txtProvincia.Text = ProvinciaEmp
        txtEmail.Text = EmailEmp

    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click

        Try

            If Len(Trim(txtNombre.Text)) = 0 Then
                MsgBox("Debe digitar el nombre de la empresa", vbInformation)
                txtNombre.Focus()
                Return
            End If
            'If Len(Trim(txtTelefonos.Text)) = 0 Then
            '    MsgBox("Debe digitar el telefono", vbInformation)
            '    txtTelefonos.Focus()
            '    Return
            'End If
            'If Len(Trim(txtDireccion.Text)) = 0 Then
            '    MsgBox("Debe digitar la dirección de la empresa", vbInformation)
            '    txtDireccion.Focus()
            '    Return
            'End If
            'If Len(Trim(txtProvincia.Text)) = 0 Then
            '    MsgBox("Debe digitar la provincia", vbInformation)
            '    txtProvincia.Focus()
            '    Return
            'End If

            Dim myQuery As String = " UPDATE datos_empresa SET NombreEmpresa ='" & Trim(txtNombre.Text) _
            & "', direccion ='" & Trim(txtDireccion.Text) & "',provincia ='" & Trim(txtProvincia.Text) _
            & "', telefono ='" & Trim(txtTelefonos.Text) & "', rnc ='" & txtRnc.Text & "', eslogan ='" & Trim(txtEslogan.Text) _
            & "', email ='" & Trim(txtEmail.Text) & "'"
            Dim cmd As OleDbCommand = New OleDbCommand(myQuery, Cnn)
            cmd.Connection = Cnn
            RA = cmd.ExecuteNonQuery
            If RA > 0 Then
                Empresa = Trim(txtNombre.Text)
                DireccionEmp = Trim(txtDireccion.Text)
                ProvinciaEmp = Trim(txtProvincia.Text)
                EmailEmp = Trim(txtEmail.Text)
                RncEmp = Trim(txtRnc.Text)
                TelefonoEmp = Trim(txtTelefonos.Text)
                EsloganEmp = Trim(txtEslogan.Text)
                MsgBox("Los datos fueron actualizados", vbInformation)
                Return
            Else
                MsgBox("No fue posible actualizar la información", vbCritical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Close()
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtRnc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRnc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtEslogan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEslogan.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtTelefonos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefonos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmail.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProvincia.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class