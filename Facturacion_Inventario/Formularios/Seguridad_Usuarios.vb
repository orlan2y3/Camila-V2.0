Imports System.Data.OleDb
Public Class Seguridad_Usuarios
    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtusuario.Focus()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtusuario.Text = "" Then
            MsgBox("Debe digitar un usuario", MsgBoxStyle.Information)
            txtusuario.Focus()
            Return
        End If

        If txtcontraseña.Text = "" Then
            MsgBox("Debe digitar una contraseña", MsgBoxStyle.Information)
            txtcontraseña.Focus()
            Return
        End If

        Try

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT nombre_completo, nivel, id, estado from usuarios where usuario = '" _
            & txtusuario.Text & "' AND contrasena ='" & txtcontraseña.Text & "'"
            Dim cmb As OleDbCommand = New OleDbCommand(query, Cnn)
            dr = cmb.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                NivelUsuario = dr("nivel")
                EstadoUsuario = dr("estado")
                dr.Close()
            Else
                dr.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress, txtcontraseña.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class
