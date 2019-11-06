Imports System.Data.OleDb

Public Class Seguridad
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Trim(txtusuario.Text) = "" Then
            MsgBox("El Nombre de Usuario no Deben Estar en Blanco", MsgBoxStyle.Information)
            txtusuario.Focus()
            Return
        ElseIf Trim(txtcontraseña.Text) = "" Then
            MsgBox("La Contraseña no Deben Estar en Blanco", MsgBoxStyle.Information)
            txtcontraseña.Focus()
            Return
        End If

        Try
            Dim Nivel As Integer
            Dim Estado As String
            Dim cmd As New OleDbCommand
            Dim Reader As OleDbDataReader
            Dim StrSql As String = "SELECT nombre_completo, nivel, id, estado from usuarios where usuario = '" + txtusuario.Text + "' and contrasena = '" + txtcontraseña.Text + "'"
            cmd.CommandText = StrSql
            cmd.CommandType = CommandType.Text
            cmd.Connection = Cnn
            Reader = cmd.ExecuteReader()
            If Reader.HasRows Then
                Reader.Read()
                Nivel = Reader("nivel")
                Estado = Reader("estado").ToString
                Reader.Close()
                If Estado = "Inactivo" Then
                    MsgBox("Usuario inactivo", vbCritical)
                    Return
                End If
                If Nivel <> 1 Then
                    MsgBox("Ese usuario no tiene permisos para ese proceso", vbCritical)
                    Return
                End If

                Permitido = True
                Me.Close()
            Else
                Reader.Close()
                MsgBox("Usuario no encontrado, verifique usuario y contraseña", vbCritical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Permitido = False
        Me.Close()
    End Sub

    Private Sub Seguridad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtusuario.Select()
    End Sub

    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress, txtcontraseña.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class