Imports System.Data.OleDb
Public Class Parametros
    Public ds As DataSet = New DataSet

    Private Sub txtitbis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtitbis.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub btguardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        If Not IsNumeric(txtitbis.Text) Then
            MsgBox("El ITBIS debe ser un valor numérico", MsgBoxStyle.Information)
            txtitbis.Focus()
            Return
        End If

        Try

            Dim myQuery As String = "UPDATE parametros Set itbis =" & CDbl(txtitbis.Text)
            Dim cmd As New OleDbCommand(myQuery, Cnn)
            RA = cmd.ExecuteNonQuery()
            If RA > 0 Then
                p_itbis = txtitbis.Text
                MsgBox("Ok. Itbis grabado", vbInformation)
                Return
            Else
                MsgBox("No fue posible actualizar la información", vbCritical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Parametros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtitbis.Text = p_itbis
        txtValida.Text = Valida
        cmbDeli.Text = Delivery
        cmbPrint.Text = Impresora
        cmbCopias.Text = Copias
        txtMonto.Text = FormatNumber(Maximo_Descuento, 2)
        txtEmail.Text = Email
        btsalir.Select()
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Close()
    End Sub

    Private Sub txtValida_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnGrabaDeli_Click(sender As Object, e As EventArgs) Handles btnGrabaDeli.Click
        If cmbDeli.Text = "" Then
            MsgBox("Debe seleccionar una opcion", MsgBoxStyle.Information)
            cmbDeli.Focus()
            Return
        End If

        Try

            Dim myQuery As String = "UPDATE parametros Set delivery ='" & cmbDeli.Text & "'"
            Dim cmd As New OleDbCommand(myQuery, Cnn)
            RA = cmd.ExecuteNonQuery()
            If RA > 0 Then
                Delivery = cmbDeli.Text
                MsgBox("Ok. registrado. (Debe cerrar el sistema y volver a abrirlo)", vbInformation)
                Return
            Else
                MsgBox("No fue posible actualizar la información", vbCritical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnGrabaPrint_Click(sender As Object, e As EventArgs) Handles btnGrabaPrint.Click
        If cmbPrint.Text = "" Then
            MsgBox("Debe seleccionar el tipo de printer que usará el sistema", MsgBoxStyle.Information)
            cmbPrint.Focus()
            Return
        End If

        Try

            Dim myQuery As String = "UPDATE parametros Set impresora ='" & cmbPrint.Text & "'"
            Dim cmd As New OleDbCommand(myQuery, Cnn)
            RA = cmd.ExecuteNonQuery()
            If RA > 0 Then
                Impresora = cmbPrint.Text
                MsgBox("Ok. registrado", vbInformation)
                Return
            Else
                MsgBox("No fue posible actualizar la información", vbCritical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnGrabarCopias_Click(sender As Object, e As EventArgs) Handles btnGrabarCopias.Click
        If cmbCopias.Text = "" Then
            MsgBox("Debe seleccionar la cantidad de copias que desea, al imprimir las facturas", MsgBoxStyle.Information)
            cmbCopias.Focus()
            Return
        End If

        Try

            Dim myQuery As String = "UPDATE parametros Set copias =" & cmbCopias.Text
            Dim cmd As New OleDbCommand(myQuery, Cnn)
            RA = cmd.ExecuteNonQuery()
            If RA > 0 Then
                Copias = cmbCopias.Text
                MsgBox("Ok. No. de copias registrado", vbInformation)
                Return
            Else
                MsgBox("No fue posible actualizar la información", vbCritical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnGrabarFecha_Click(sender As Object, e As EventArgs) Handles btnGrabarFecha.Click
        If FechaValida(txtValida.Text) = False Then
            MsgBox("La fecha no es una fecha valida. Verifique", MsgBoxStyle.Information)
            txtValida.Focus()
            Return
        End If

        Try

            Dim myQuery As String = "UPDATE parametros Set valida ='" & txtValida.Text & "'"
            Dim cmd As New OleDbCommand(myQuery, Cnn)
            RA = cmd.ExecuteNonQuery()
            If RA > 0 Then
                Valida = txtValida.Text
                MsgBox("Ok. fecha grabada", vbInformation)
                Return
            Else
                MsgBox("No fue posible actualizar la información", vbCritical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnGrabaMonto_Click(sender As Object, e As EventArgs) Handles btnGrabaMonto.Click
        If Not IsNumeric(txtMonto.Text) Then
            MsgBox("El Monto debe ser un valor numérico", MsgBoxStyle.Information)
            txtMonto.Focus()
            Return
        End If

        Try

            Dim myQuery As String = "UPDATE parametros Set maximo_descuento =" & CDec(txtMonto.Text)
            Dim cmd As New OleDbCommand(myQuery, Cnn)
            RA = cmd.ExecuteNonQuery()
            If RA > 0 Then
                Maximo_Descuento = CDec(txtMonto.Text)
                MsgBox("Ok. Descuento permitido grabado", vbInformation)
                Return
            Else
                MsgBox("No fue posible actualizar la información", vbCritical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnGrabarEmail_Click(sender As Object, e As EventArgs) Handles btnGrabarEmail.Click

        'If String.IsNullOrEmpty(txtEmail.Text) Then
        '    MsgBox("Debe digitar la cuenta de correo", MsgBoxStyle.Information)
        '    txtEmail.Focus()
        '    Return
        'End If
        If Len(Trim(txtEmail.Text)) > 0 Then
            If InStr(txtEmail.Text, "@") = 0 Then
                MsgBox("Esa no es una cuenta de correo valida", MsgBoxStyle.Exclamation)
                txtEmail.Focus()
                Return
            End If
            If InStr(txtEmail.Text, ".") = 0 Then
                MsgBox("Esa no es una cuenta de correo valida", MsgBoxStyle.Exclamation)
                txtEmail.Focus()
                Return
            End If
        End If

        Try

            Dim myQuery As String = "UPDATE parametros Set email ='" & Trim(txtEmail.Text) & "'"
            Dim cmd As New OleDbCommand(myQuery, Cnn)
            RA = cmd.ExecuteNonQuery()
            If RA > 0 Then
                Email = Trim(txtEmail.Text)
                MsgBox("Ok. Cuenta de correo grabada", vbInformation)
                Return
            Else
                MsgBox("No fue posible actualizar la información", vbCritical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class