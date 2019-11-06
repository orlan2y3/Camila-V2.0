Imports System.Data.OleDb
Imports System.Net.Mail

Module Module1

    '**** VARIABLES PARA CONECCION Y QUERYS *********
    Public CadenaConnection As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\Factura_Inventario.mdb" _
                                                           & ";Jet OLEDB:Database Password=cladatos-ao;"
    Public Cnn As OleDbConnection = New OleDbConnection(CadenaConnection)
    Public objCmd As OleDbCommand
    Public trans As OleDbTransaction
    Public objReader As OleDbDataReader
    Public Ds As New DataSet
    Public Da As OleDbDataAdapter
    Public StrSql As String

    '**** VARIABLES PARA DATOS DE USUARIO *********
    Public IdUsuario As Long
    Public Usuario As String
    Public NombreUsuario As String
    Public NivelUsuario As Integer
    Public EstadoUsuario As String

    '**** VARIABLES *********
    Public TA As Boolean 'Para registrar el estado de las transacciones
    Public RA As Long 'Registros Afectados
    Public NF As Long 'Numero de Factura
    Public NC As Long 'Numero de Cotizacion
    Public Permitido As Boolean 'Para validar que el usuario tiene permiso

    '**** VARIABLES PARA DATOS DE LA EMPRESA *********
    Public Empresa As String
    Public EsloganEmp As String
    Public DireccionEmp As String
    Public ProvinciaEmp As String
    Public TelefonoEmp As String
    Public RncEmp As String
    Public EmailEmp As String

    '********* VARIABLES PARA PARAMETROS **************
    Public p_itbis As Double
    Public Valida As String
    Public Delivery As String
    Public Impresora As String
    Public Copias As Integer
    Public Maximo_Descuento As Decimal
    Public Email As String

    '********* FORMULARIOS EN MEMORIA **************
    Public FmantFacturas As New frmMantFacturas
    Public FmantCotizacion As New frmMantCotizacion
    Public Ffactura As New Form1
    'Public frmfactura As New Form1
    Public Fcotizacion As New Cotizacion
    Public FBuscarProductos As New frmBuscarProducto
    Public FbuscarCliente As New frmBuscarCliente
    Public FmantInventario As New frmMantInventario
    Public FentradaProductos As New frmEntradaProductos
    Public Fcondicion As New frmCondicionesProductos

    Public Sub Conectar()
        Cnn.Open()
    End Sub

    Public Sub Desconectar()
        Cnn.Close()
    End Sub

    Public Function EnviaCorreo(Direccion As String, Asunto As String, Mensaje As String, Adjunto As String) As Boolean

        Dim correo As New MailMessage
        Dim smtp As New SmtpClient()

        correo.From = New MailAddress("pimponeord@gmail.com", "Pimponeo", System.Text.Encoding.UTF8)
        correo.To.Add(Direccion)
        correo.SubjectEncoding = System.Text.Encoding.UTF8
        correo.Subject = Asunto
        correo.BodyEncoding = System.Text.Encoding.UTF8
        correo.Body = Mensaje
        correo.IsBodyHtml = False
        'correo.Priority = MailPriority.High

        '******* Codigo para enviar documentos adjuntos **************************************
        Dim attachment As New Net.Mail.Attachment(Adjunto)
        correo.Attachments.Add(attachment)
        '*************************************************************************************

        smtp.Credentials = New System.Net.NetworkCredential("pimponeord@gmail.com", "jose1122$")
        smtp.Port = 25 '587 ',465'
        smtp.Host = "smtp.gmail.com"    'smpt.live.com - para hotmail
        smtp.EnableSsl = True

        Try
            smtp.Send(correo)
            Return True
        Catch ex As System.Net.Mail.SmtpException
            MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
            Return False
        End Try

    End Function

    Public Function Comprobante(fijo As String, ncfsec As Long) As String
        Dim ncf As String
        Dim f As String = "0"

        For i = Len(ncfsec.ToString) To 6
            f &= "0"
        Next i
        ncf = fijo & f & ncfsec.ToString
        Return ncf

    End Function

    Function Efecha(Fecha As String) As String
        Dim Resul As String

        Resul = Mid(Fecha, 7, 4) & "/" & Mid(Fecha, 4, 2) & "/" & Mid(Fecha, 1, 2)
        Return Resul
    End Function

    Function Lfecha(Fecha As String) As String
        Dim Resul As String

        Resul = Mid(Fecha, 9, 2) & "/" & Mid(Fecha, 6, 2) & "/" & Mid(Fecha, 1, 4)
        Return Resul
    End Function

    Function FechaValida(fecha As String) As Boolean
        Dim Dia As String
        Dim Mes As String
        Dim Anio As String

        Try

            Dia = Mid(fecha, 1, 2) : Mes = Mid(fecha, 4, 2) : Anio = Mid(fecha, 7, 4)

            If IsNumeric(Dia) Then
                If CLng(Dia) > 31 Or CLng(Dia) < 1 Then
                    Return False
                End If
            Else
                Return False
            End If

            If IsNumeric(Mes) Then
                If CLng(Mes) > 12 Or CLng(Mes) < 1 Then
                    Return False
                End If
            Else
                Return False
            End If

            If Not IsNumeric(Anio) Then
                Return False
            End If

            If Len(Trim(Dia)) <> 2 Then
                Return False
            End If

            If Len(Trim(Mes)) <> 2 Then
                Return False
            End If

            If Len(Trim(Anio)) <> 4 Then
                Return False
            End If

            Return True

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
            Return Nothing
        End Try

    End Function

    Function Cambiar(Valor As String) As String
        Dim Cadena As String
        Cadena = Replace(Valor, "'", "´", 1)
        Return Cadena
    End Function

    Function BuscaLetra(Numero As Integer) As String
        Dim Desc As String

        StrSql = "SELECT DESCRIPCION FROM LETRAS WHERE NUMERO =" & Numero
        objCmd = New OleDbCommand(StrSql, Cnn)
        objReader = objCmd.ExecuteReader()
        If objReader.HasRows Then
            objReader.Read()
            Desc = objReader("Descripcion")
        Else
            Desc = ""
        End If
        objReader.Close()

        Return Desc

    End Function

    Function DineroLetras(Monto As Double) As String
        Dim Desc As String

        If Not IsNumeric(Monto) Then
            Desc = ""
            Return Desc

            Exit Function
        End If

        Dim Valor As String
        Dim Billon As Integer
        Dim Millon As Integer
        Dim Mil As Integer
        Dim Cien As Integer
        Dim Resto As Integer
        Dim Numero As Integer
        Dim Descripcion As String
        Dim Poner As Boolean

        Valor = Format(Monto, "0000000000.00")

        Numero = 0 : Billon = 0 : Millon = 0 : Mil = 0 : Resto = 0 : Poner = False : Descripcion = ""

        Billon = Val(Mid(Valor, 1, 1))
        Millon = Val(Mid(Valor, 2, 3))
        Mil = Val(Mid(Valor, 5, 3))
        Cien = Val(Mid(Valor, 8, 3))
        Resto = Val(Mid(Valor, 12, 2))

        'Trabajar Billones
        If Billon > 0 Then
            Descripcion = BuscaLetra(Billon) & " Billon(es)"
        End If
        'Trabajar millones
        If Millon > 0 Then
            If Len(Trim(Str(Millon))) = 3 Then
                Numero = Val(Mid(Millon, 1, 1))
                If Numero > 0 Then
                    Numero = Numero * 100
                    Descripcion = Descripcion & " " & BuscaLetra(Numero)
                End If
                Numero = Val(Mid(Millon, 2, 2))
                If Numero > 10 And Numero < 20 Then
                    Descripcion = Descripcion & " " & BuscaLetra(Numero)
                Else
                    Numero = Val(Mid(Millon, 2, 1))
                    If Numero > 0 Then
                        Poner = True
                        Numero = Numero * 10
                        Descripcion = Descripcion & " " & BuscaLetra(Numero)
                    Else
                        Poner = False
                    End If
                    Numero = Val(Mid(Millon, 3, 1))
                    If Numero > 0 Then
                        If Poner = True Then
                            Descripcion = Descripcion & " y " & BuscaLetra(Numero)
                        Else
                            Descripcion = Descripcion & " " & BuscaLetra(Numero)
                        End If
                    End If
                End If
            ElseIf Len(Trim(Str(Millon))) = 2 Then
                Numero = Val(Mid(Millon, 1, 2))
                If Numero > 10 And Numero < 20 Then
                    Descripcion = Descripcion & " " & BuscaLetra(Numero)
                Else
                    Numero = Val(Mid(Millon, 1, 1))
                    If Numero > 0 Then
                        Poner = True
                        Numero = Numero * 10
                        Descripcion = Descripcion & " " & BuscaLetra(Numero)
                    Else
                        Poner = False
                    End If
                    Numero = Val(Mid(Millon, 2, 1))
                    If Numero > 0 Then
                        If Poner = True Then
                            Descripcion = Descripcion & " y " & BuscaLetra(Numero)
                        Else
                            Descripcion = Descripcion & " " & BuscaLetra(Numero)
                        End If
                    End If
                End If
            ElseIf Len(Trim(Str(Millon))) = 1 Then
                Numero = Val(Mid(Millon, 1, 1))
                If Numero > 0 Then
                    Descripcion = Descripcion & " " & BuscaLetra(Numero)
                End If
            End If

            Descripcion = Descripcion & " Millon(es)"
        End If
        Poner = False

        'Trabajar miles
        If Mil > 0 Then
            If Len(Trim(Str(Mil))) = 3 Then
                Numero = Val(Mid(Mil, 1, 1))
                If Numero > 0 Then
                    Numero = Numero * 100
                    Descripcion = Descripcion & " " & BuscaLetra(Numero)
                End If
                Numero = Val(Mid(Mil, 2, 2))
                If Numero > 10 And Numero < 20 Then
                    Descripcion = Descripcion & " " & BuscaLetra(Numero)
                Else
                    Numero = Val(Mid(Mil, 2, 1))
                    If Numero > 0 Then
                        Poner = True
                        Numero = Numero * 10
                        Descripcion = Descripcion & " " & BuscaLetra(Numero)
                    Else
                        Poner = False
                    End If
                    Numero = Val(Mid(Mil, 3, 1))
                    If Numero > 0 Then
                        If Poner = True Then
                            Descripcion = Descripcion & " y " & BuscaLetra(Numero)
                        Else
                            Descripcion = Descripcion & " " & BuscaLetra(Numero)
                        End If
                    End If
                End If
            ElseIf Len(Trim(Str(Mil))) = 2 Then
                Numero = Val(Mid(Mil, 1, 2))
                If Numero > 10 And Numero < 20 Then
                    Descripcion = Descripcion & " " & BuscaLetra(Numero)
                Else
                    Numero = Val(Mid(Mil, 1, 1))
                    If Numero > 0 Then
                        Poner = True
                        Numero = Numero * 10
                        Descripcion = Descripcion & " " & BuscaLetra(Numero)
                    Else
                        Poner = False
                    End If
                    Numero = Val(Mid(Mil, 2, 1))
                    If Numero > 0 Then
                        If Poner = True Then
                            Descripcion = Descripcion & " y " & BuscaLetra(Numero)
                        Else
                            Descripcion = Descripcion & " " & BuscaLetra(Numero)
                        End If
                    End If
                End If
            ElseIf Len(Trim(Str(Mil))) = 1 Then
                Numero = Val(Mid(Mil, 1, 1))
                If Numero > 0 Then
                    Descripcion = Descripcion & " " & BuscaLetra(Numero)
                End If
            End If

            Descripcion = Descripcion & " Mil"
        End If
        Poner = True

        'Trabajar Cientos
        If Cien > 0 Then
            If Len(Trim(Str(Cien))) = 3 Then
                Numero = Val(Mid(Cien, 1, 1))
                If Numero > 0 Then
                    Numero = Numero * 100
                    Descripcion = Descripcion & " " & BuscaLetra(Numero)
                End If
                Numero = Val(Mid(Cien, 2, 2))
                If Numero > 10 And Numero < 20 Then
                    Descripcion = Descripcion & " " & BuscaLetra(Numero)
                Else
                    Numero = Val(Mid(Cien, 2, 1))
                    If Numero > 0 Then
                        Poner = True
                        Numero = Numero * 10
                        Descripcion = Descripcion & " " & BuscaLetra(Numero)
                    Else
                        Poner = False
                    End If
                    Numero = Val(Mid(Cien, 3, 1))
                    If Numero > 0 Then
                        If Poner = True Then
                            Descripcion = Descripcion & " y " & BuscaLetra(Numero)
                        Else
                            Descripcion = Descripcion & " " & BuscaLetra(Numero)
                        End If
                    End If
                End If
            ElseIf Len(Trim(Str(Cien))) = 2 Then
                Numero = Val(Mid(Cien, 1, 2))
                If Numero > 10 And Numero < 20 Then
                    Descripcion = Descripcion & " " & BuscaLetra(Numero)
                Else
                    Numero = Val(Mid(Cien, 1, 1))
                    If Numero > 0 Then
                        Poner = True
                        Numero = Numero * 10
                        Descripcion = Descripcion & " " & BuscaLetra(Numero)
                    Else
                        Poner = False
                    End If
                    Numero = Val(Mid(Cien, 2, 1))
                    If Numero > 0 Then
                        If Poner = True Then
                            Descripcion = Descripcion & " y " & BuscaLetra(Numero)
                        Else
                            Descripcion = Descripcion & " " & BuscaLetra(Numero)
                        End If
                    End If
                End If
            ElseIf Len(Trim(Str(Cien))) = 1 Then
                Numero = Val(Mid(Cien, 1, 1))
                If Numero > 0 Then
                    Descripcion = Descripcion & " " & BuscaLetra(Numero)
                End If
            End If
        End If

        'Trabajar resto
        If Resto > 0 Then
            Desc = Descripcion & " con " & Resto & "/100"
        Else
            Desc = Descripcion & " con " & "00/100"
        End If

        Return Desc

    End Function

End Module

