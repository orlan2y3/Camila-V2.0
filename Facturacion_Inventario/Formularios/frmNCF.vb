Public Class frmNCF
    Dim Posicion As Integer

    Public Sub FormatGrid()
        DG.Rows.Clear()
        DG.ColumnCount = 4
        DG.Columns(0).HeaderText = "ID"
        DG.Columns(1).HeaderText = "DESCRIPCION"
        DG.Columns(2).HeaderText = "NUMERACION"
        DG.Columns(3).HeaderText = "SECUENCIA"

        DG.Columns(0).Visible = False
        DG.Columns(1).Width = 300
        DG.Columns(2).Width = 200
        DG.Columns(3).Width = 90

        ' desactivar los estilos visuales del sistema
        DG.EnableHeadersVisualStyles = False
        DG.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable

        DG.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        ' estilo para la cabecera del grid
        DG.ColumnHeadersDefaultCellStyle.BackColor = Color.YellowGreen
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Sub ActualizaGrid()

        FormatGrid()

        Try
            StrSql = "SELECT * FROM NCF ORDER BY DESCRIPCION ASC"
            objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                While objReader.Read()
                    DG.Rows.Add(objReader("id_tipo"), objReader("descripcion").ToString, objReader("fijo").ToString, objReader("sec"))
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

    Private Sub frmNCF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizaGrid()
        txtDescripcion.Select()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Len(Trim(txtDescripcion.Text)) = 0 Then
            MsgBox("Debe digitar la Descripción", vbInformation)
            txtDescripcion.Focus()
            Return
        End If

        If Len(Trim(txtNumeracion.Text)) = 0 Then
            MsgBox("Debe digitar la numeración", vbInformation)
            txtNumeracion.Focus()
            Return
        End If

        If Not IsNumeric(txtSec.Text) Then
            MsgBox("Debe digitar la última secuencia usada", vbInformation)
            txtSec.Focus()
            Return
        End If

        If txtDescripcion.BackColor = Color.White Then
            StrSql = "INSERT INTO NCF(descripcion, fijo, sec) VALUES('" & Trim(txtDescripcion.Text) _
            & "','" & Trim(txtNumeracion.Text) & "'," & CLng(txtSec.Text) & ")"
            objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
            RA = objCmd.ExecuteNonQuery
            If RA > 0 Then
                ActualizaGrid()

                txtDescripcion.BackColor = Color.White
                txtNumeracion.BackColor = Color.White
                txtSec.BackColor = Color.White
                txtDescripcion.Clear() : txtNumeracion.Clear() : txtSec.Clear() : txtId.Clear()
                txtDescripcion.Focus()
            Else
                MsgBox("No fue posible grabar la información", vbCritical)
                txtDescripcion.Focus()
                Return
            End If

        Else
            If Not IsNumeric(txtId.Text) Then
                MsgBox("Debe seleccionar el NCF que desea modificar", vbInformation)
                Return
            End If

            StrSql = "UPDATE NCF SET descripcion ='" & Trim(txtDescripcion.Text) & "',fijo ='" & Trim(txtNumeracion.Text) _
            & "',sec =" & CLng(txtSec.Text) & " WHERE ID_TIPO =" & CLng(txtId.Text)
            objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
            RA = objCmd.ExecuteNonQuery
            If RA > 0 Then
                ActualizaGrid()

                txtDescripcion.BackColor = Color.White
                txtNumeracion.BackColor = Color.White
                txtSec.BackColor = Color.White
                txtDescripcion.Clear() : txtNumeracion.Clear() : txtSec.Clear() : txtId.Clear()
                txtDescripcion.Focus()
            Else
                MsgBox("No fue posible grabar la información", vbCritical)
                txtDescripcion.Focus()
                Return
            End If
        End If

    End Sub

    Private Sub DG_DoubleClick(sender As Object, e As EventArgs) Handles DG.DoubleClick
        If DG.Rows.Count > 0 Then
            If Not DG.CurrentRow.IsNewRow Then
                Posicion = DG.CurrentRow.Index
                txtId.Text = DG.Item(0, DG.CurrentRow.Index).Value
                txtDescripcion.Text = DG.Item(1, DG.CurrentRow.Index).Value
                txtNumeracion.Text = DG.Item(2, DG.CurrentRow.Index).Value
                txtSec.Text = DG.Item(3, DG.CurrentRow.Index).Value

                txtDescripcion.BackColor = Color.Yellow
                txtNumeracion.BackColor = Color.Yellow
                txtSec.BackColor = Color.Yellow
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try

            If txtDescripcion.BackColor = Color.White Then
                txtDescripcion.Clear() : txtNumeracion.Clear() : txtSec.Clear() : txtId.Clear()
                txtDescripcion.Focus()
            Else
                If MessageBox.Show("Seguro que desea eliminar esa descripción", "Eliminar Descripción NFC", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = vbNo Then
                    Exit Sub
                End If

                StrSql = "DELETE * FROM NCF WHERE ID_TIPO =" & CLng(txtId.Text)
                objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
                RA = objCmd.ExecuteNonQuery
                If RA > 0 Then
                    ActualizaGrid()
                    txtDescripcion.BackColor = Color.White
                    txtNumeracion.BackColor = Color.White
                    txtSec.BackColor = Color.White
                    txtDescripcion.Clear() : txtNumeracion.Clear() : txtSec.Clear() : txtId.Clear()
                    txtDescripcion.Focus()
                Else
                    MsgBox("No fue posible eliminar la información", vbCritical)
                    txtDescripcion.Focus()
                    Return
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Close()
    End Sub

    Private Sub txtCondicion_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtDescripcion.BackColor = Color.White
        txtNumeracion.BackColor = Color.White
        txtSec.BackColor = Color.White
        txtDescripcion.Clear() : txtNumeracion.Clear() : txtSec.Clear() : txtId.Clear()
        txtDescripcion.Focus()
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumeracion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeracion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtSec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSec.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class