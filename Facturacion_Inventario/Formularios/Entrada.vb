Imports System.Data.OleDb
Imports System.IO

Public Class Entrada
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontraseña.KeyPress, txtusuario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btentrar_Click(sender As Object, e As EventArgs) Handles btentrar.Click
        If Trim(txtusuario.Text) = "" Then
            MsgBox("Debe digitar un usuario", MsgBoxStyle.Information, "Acceso Usuarios")
            txtusuario.Focus()
            Return
        End If

        If Trim(txtcontraseña.Text) = "" Then
            MsgBox("Debe digitar una contraseña", MsgBoxStyle.Information, "Acceso Usuarios")
            txtcontraseña.Focus()
            Return
        End If

        Try

            Conectar()

            Dim Reader As OleDbDataReader
            Dim objCmb As OleDbCommand

            Dim StrSql As String = "SELECT nombre_completo, nivel, id, estado from usuarios where usuario = '" + txtusuario.Text + "' and contrasena = '" + txtcontraseña.Text + "'"
            objCmb = New OleDbCommand(StrSql, Cnn)
            Reader = objCmb.ExecuteReader()
            If Reader.HasRows Then
                Reader.Read()
                NombreUsuario = Reader("nombre_completo").ToString
                NivelUsuario = Reader("nivel").ToString
                IdUsuario = Reader("id")
                EstadoUsuario = Reader("estado").ToString
                Reader.Close()
            Else
                Reader.Close()
                Desconectar()
                MsgBox("Acceso Negado ** Nombre de Usuario y/o Contraseña Incorrectos **", MsgBoxStyle.Critical)
                txtusuario.Focus()
                Return
            End If

            If EstadoUsuario = "Inactivo" Then
                MsgBox("Este Usuario Esta Inactivo", MsgBoxStyle.Critical)
                txtusuario.Focus()
                Desconectar()
                Return
            End If

            StrSql = "SELECT NombreEmpresa, Eslogan, Direccion, Provincia, Telefono, Rnc, email FROM datos_empresa"
            objCmb = New OleDbCommand(StrSql, Cnn)
            Reader = objCmb.ExecuteReader()
            If Reader.HasRows Then
                Reader.Read()
                Empresa = Reader("NombreEmpresa").ToString
                EsloganEmp = Reader("eslogan").ToString
                DireccionEmp = Reader("direccion").ToString
                ProvinciaEmp = Reader("provincia").ToString
                TelefonoEmp = Reader("telefono").ToString
                RncEmp = Reader("rnc").ToString
                EmailEmp = Reader("email").ToString
                Reader.Close()
            Else
                Reader.Close()
            End If

            StrSql = "SELECT itbis, valida, delivery, impresora, copias, maximo_descuento, email FROM parametros"
            objCmb = New OleDbCommand(StrSql, Cnn)
            Reader = objCmb.ExecuteReader()
            If Reader.HasRows Then
                Reader.Read()
                p_itbis = Reader("itbis")
                Valida = Reader("valida").ToString
                Delivery = Reader("delivery").ToString
                Impresora = Reader("impresora").ToString
                Copias = Reader("copias").ToString
                Maximo_Descuento = Reader("maximo_descuento").ToString
                Email = Reader("email").ToString
                Reader.Close()
            Else
                Reader.Close()
            End If

            'Para verificar si existen documentos pdf en la ruta especificada
            'y si existen, eliminarlos todos
            Dim files() As String = System.IO.Directory.GetFiles(Application.StartupPath & "\Archivos Pdf", "*.pdf", IO.SearchOption.TopDirectoryOnly)
            If files.Count > 0 Then
                For Each doc In files
                    File.Delete(doc)
                Next
            End If

            Dim Menu As New frmMenu
            Menu.Show()
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Desconectar()
        End
    End Sub

End Class