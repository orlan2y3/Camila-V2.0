Imports System.Data.OleDb

Public Class Usuarios
    Dim QuerySelect As String = "SELECT id, nombre_completo, usuario, nivel, estado FROM usuarios  order by id desc"
    Public ds As DataSet = New DataSet
    Public ds1 As DataSet = New DataSet

    Sub LlenaNivel()
        txtNivel.Items.Clear()
        txtNivel.Items.Add(1)
        txtNivel.Items.Add(2)
        txtNivel.Items.Add(3)
    End Sub

    Public Sub cargardatagrid(myQuery As String)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, Cnn)
        da.Fill(ds, "usuarios")
    End Sub

    Public Sub Buscar(myQuery As String)
        Dim da1 As OleDbDataAdapter = New OleDbDataAdapter(myQuery, Cnn)
        da1.Fill(ds1, "usuarios")
    End Sub

    Public Sub Activar(myQuery As String)
        Dim cmd As OleDbCommand = New OleDbCommand(myQuery)
        cmd.Connection = Cnn
        cmd.ExecuteNonQuery()
        MsgBox("Activado Con Éxito", MsgBoxStyle.Information)
    End Sub

    Public Sub Desactivar(myQuery As String)
        Dim cmd As OleDbCommand = New OleDbCommand(myQuery)
        cmd.Connection = Cnn
        cmd.ExecuteNonQuery()
        MsgBox("Desactivado Con Éxito", MsgBoxStyle.Information)
    End Sub

    Public Sub Actualizar(myQuery As String)
        Dim cmd As OleDbCommand = New OleDbCommand(myQuery)
        cmd.Connection = Cnn
        cmd.ExecuteNonQuery()
        MsgBox("Grabado Con Éxito", MsgBoxStyle.Information)
    End Sub

    Private Sub btinsertar_Click(sender As Object, e As EventArgs) Handles btinsertar.Click
        If txtnombre.Text = "" Then
            MsgBox("Debe Digitar un Nombre", MsgBoxStyle.Information)
            txtnombre.Focus()
            Return
            txtnombre.Focus()
        End If

        If txtusuario.Text = "" Then
            MsgBox("Debe Debe Digitar un Apellido", MsgBoxStyle.Information)
            txtusuario.Focus()
            Return
        End If

        If txtcontrasena.Text = "" Then
            MsgBox("Debe Debe Digitar una Contraseña", MsgBoxStyle.Information)
            txtcontrasena.Focus()
            Return
        End If

        If IsNumeric(txtnombre.Text) Then
            MsgBox("El nombre no debe contener numeros", MsgBoxStyle.Information)
            txtnombre.Focus()
            Return
        ElseIf IsNumeric(txtusuario.Text) Then
            MsgBox("El apellido no debe contener numeros", MsgBoxStyle.Information)
            txtusuario.Focus()
            Return
        End If

        'If rdbadministrador.Checked = False And rdbsupervisor.Checked = False And rdbcajero.Checked = False Then
        '    MsgBox("Debe elegir el nivel del nuevo usuario", MsgBoxStyle.Information)
        '    Return
        'End If

        'Try

        If IsNumeric(txtid.Text) Then

            StrSql = "UPDATE usuarios SET nombre_completo = '" & txtnombre.Text _
                & "', usuario = '" & txtusuario.Text & "', contrasena = '" & txtcontrasena.Text _
                & "', nivel = " & txtNivel.Text & " where id = " & txtid.Text & ""
            objCmd = New OleDbCommand(StrSql, Cnn)
                RA = objCmd.ExecuteNonQuery()
                If RA > 0 Then
                    ds.Clear()
                    cargardatagrid(QuerySelect)
                    txtid.Text = ""
                    txtnombre.Text = ""
                    txtusuario.Text = ""
                    txtcontrasena.Text = ""
                    rdbadministrador.Checked = False
                    rdbsupervisor.Checked = False
                    rdbcajero.Checked = False
                    LlenaNivel()
                Else
                    MsgBox("No fue posible actualizar los datos", vbInformation)
                    Return
                End If

            Else

                StrSql = "INSERT INTO usuarios (nombre_completo,usuario,contrasena,nivel) VALUES ('" _
                & txtnombre.Text & "','" & txtusuario.Text _
                & "','" & txtcontrasena.Text & "', " & txtNivel.Text & ")"
                objCmd = New OleDbCommand(StrSql, Cnn)
                RA = objCmd.ExecuteNonQuery()
                If RA > 0 Then
                    ds.Clear()
                    cargardatagrid(QuerySelect)
                    txtid.Text = ""
                    txtnombre.Text = ""
                    txtusuario.Text = ""
                    txtcontrasena.Text = ""
                    rdbadministrador.Checked = False
                    rdbsupervisor.Checked = False
                    rdbcajero.Checked = False
                    LlenaNivel()
                Else
                    MsgBox("No fue posible grabar la información", vbInformation)
                    Return
                End If

            End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    Private Sub btsalir2_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Close()
    End Sub

    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            dgvclientes.ColumnHeadersDefaultCellStyle.BackColor = Color.Coral
            ds.Clear()
            ds.Tables.Clear()
            LlenaNivel()
            rdbnombre.Checked = True
            cargardatagrid(QuerySelect)
            dgvclientes.DataSource = ds
            dgvclientes.DataMember = "usuarios"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub bteliminar_Click(sender As Object, e As EventArgs) Handles bteliminar.Click
        If txtid.Text = "" Then
            MsgBox("Debe Hacer Doble Clic en el Usuario que Desea Desactivar", MsgBoxStyle.Information)
            Return
        End If

        Try

            Select Case MsgBox("Esta Seguro que Desea Desactivar Este Usuario", MsgBoxStyle.YesNo, MsgBoxStyle.DefaultButton2)

                Case MsgBoxResult.Yes

                    StrSql = "UPDATE usuarios SET estado = 'Inactivo' Where id = " & txtid.Text
                    objCmd = New OleDbCommand(StrSql, Cnn)
                    RA = objCmd.ExecuteNonQuery()
                    ds.Clear()
                    cargardatagrid(QuerySelect)
                    txtid.Text = ""
                    txtnombre.Text = ""
                    txtusuario.Text = ""
                    txtcontrasena.Text = ""
                    txtnivel.Text = ""
                    rdbadministrador.Checked = False
                    rdbsupervisor.Checked = False
                    rdbcajero.Checked = False
                    LlenaNivel()
                Case MsgBoxResult.No
                    Return
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        If rdbnombre.Checked = True And IsNumeric(txtbuscar.Text) Then
            MsgBox("Debe Digitar un Nombre", MsgBoxStyle.Information)
            Return
            txtbuscar.Focus()
        ElseIf rdbid.Checked = True And Not IsNumeric(txtbuscar.Text) Then
            MsgBox("Debe Digitar un Codigo", MsgBoxStyle.Information)
            Return
            txtbuscar.Focus()
        End If

        Try

            Dim myQuery As String = ""

            If (rdbid.Checked = True) Then
                myQuery = "select id, nombre_completo, usuario, nivel FROM usuarios where id = " & txtbuscar.Text & " "
            End If

            If (rdbnombre.Checked = True) Then
                myQuery = "select id, nombre_completo, usuario, nivel FROM usuarios where nombre_completo like '%" & txtbuscar.Text & "%'"
            End If

            ds1.Clear()
            Buscar(myQuery)
            dgvclientes.DataSource = ds1
            dgvclientes.DataMember = "usuarios"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btlimpiar_Click(sender As Object, e As EventArgs) Handles btlimpiar.Click
        txtusuario.Text = ""
        txtbuscar.Text = ""
        txtid.Text = ""
        txtnombre.Text = ""
        txtcontrasena.Text = ""
        txtnivel.Text = ""
        rdbadministrador.Checked = False
        rdbsupervisor.Checked = False
        rdbcajero.Checked = False
        LlenaNivel()
    End Sub
    Private Sub clientesFormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ds.Clear()
        ds.Tables.Clear()
        ds1.Clear()
        ds1.Tables.Clear()
    End Sub
    Private Sub txtnombre_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress, txtnombre.KeyPress, txtcontrasena.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub rdbadministrador_Click(sender As Object, e As EventArgs) Handles rdbadministrador.Click
        If rdbadministrador.Checked = True Then
            txtnivel.Text = 1
        End If
    End Sub
    Private Sub rdbsupervisor_Click(sender As Object, e As EventArgs) Handles rdbsupervisor.Click
        If rdbsupervisor.Checked = True Then
            txtnivel.Text = 2
        End If
    End Sub
    Private Sub rdbcajero_Click(sender As Object, e As EventArgs) Handles rdbcajero.Click
        If rdbcajero.Checked = True Then
            txtnivel.Text = 3
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btactivar.Click
        If txtid.Text = "" Then
            MsgBox("Debe Hacer Doble Clic en el Usuario que Desea Activar", MsgBoxStyle.Information)
            Return
        End If

        Try

            Select Case MsgBox("Esta Seguro que Desea Activar Este Usuario", MsgBoxStyle.YesNo, MsgBoxStyle.DefaultButton2)
                Case MsgBoxResult.Yes

                    Dim myQuery As String = "UPDATE usuarios SET estado = 'Activo' Where id = " & txtid.Text
                    Activar(myQuery)
                    ds.Clear()
                    cargardatagrid(QuerySelect)
                    txtid.Text = ""
                    txtnombre.Text = ""
                    txtusuario.Text = ""
                    txtcontrasena.Text = ""
                    txtnivel.Text = ""
                    rdbadministrador.Checked = False
                    rdbsupervisor.Checked = False
                    rdbcajero.Checked = False

                Case MsgBoxResult.No
                    Return
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvclientes_DoubleClick(sender As Object, e As EventArgs) Handles dgvclientes.DoubleClick
        txtid.Text = Convert.ToString(dgvclientes.Item(0, dgvclientes.CurrentRow.Index).Value)
        txtnombre.Text = Convert.ToString(dgvclientes.Item(1, dgvclientes.CurrentRow.Index).Value)
        txtusuario.Text = Convert.ToString(dgvclientes.Item(2, dgvclientes.CurrentRow.Index).Value)
        txtNivel.Text = dgvclientes.Item(3, dgvclientes.CurrentRow.Index).Value
    End Sub
End Class
