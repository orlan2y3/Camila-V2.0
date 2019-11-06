Imports System.Data.OleDb

Public Class frmRegistrarPagadas
    Dim Posicion As Integer

    Public Sub FormatGrid()
        DG.Rows.Clear()
        DG.ColumnCount = 4
        DG.Columns(0).HeaderText = "FECHA"
        DG.Columns(1).HeaderText = "NO. FACTURA"
        DG.Columns(2).HeaderText = "CLIENTE"
        DG.Columns(3).HeaderText = "TOTAL"

        DG.Columns(0).Width = 80
        DG.Columns(1).Width = 100
        DG.Columns(2).Width = 400
        DG.Columns(3).Width = 115

        ' desactivar los estilos visuales del sistema
        DG.EnableHeadersVisualStyles = False
        DG.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable

        DG.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        DG.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        ' estilo para la cabecera del grid
        DG.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Sub ActualizaGrid()
        Try

            StrSql = "SELECT F.FECHA, F.ID_FACTURA, C.NOMBRE, F.TOTAL FROM FACTURA F, CLIENTES C" _
            & " WHERE F.ESTADO ='Normal' AND F.CONDICION ='Crédito' AND PAGADA ='N' AND F.ID_CLIENTE = C.ID ORDER BY F.ID_FACTURA ASC"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                While objReader.Read()
                    DG.Rows.Add(Lfecha(objReader("fecha").ToString), objReader("id_factura"), objReader("nombre").ToString, FormatNumber(objReader("total"), 2))
                End While
                objReader.Close()
            Else
                objReader.Close()
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub frmRegistrarPagadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormatGrid()
        ActualizaGrid()
        DG.Focus()
    End Sub

    Private Sub DG_DoubleClick(sender As Object, e As EventArgs) Handles DG.DoubleClick
        Try
            If IsNothing(DG.CurrentRow.Cells(0).Value) Then
                Return
            End If

            If Not DG.CurrentRow.IsNewRow Then
                txtNoFact.Text = DG.Item(1, DG.CurrentRow.Index).Value
                txtCliente.Text = DG.Item(2, DG.CurrentRow.Index).Value
                txtMonto.Text = DG.Item(3, DG.CurrentRow.Index).Value
                txtFecha.Text = Format(Today, "dd/MM/yyyy")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
    End Sub

    Private Sub DG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DG.KeyPress
        Try

            If e.KeyChar = ChrW(Keys.Enter) Then

                Posicion = DG.CurrentCell.RowIndex - 1
                If Posicion = -1 Then
                    Return
                End If

                If IsNothing(DG.Item(0, Posicion).Value) Then
                    txtNoFact.Clear() : txtCliente.Clear() : txtMonto.Clear()
                    Return
                End If

                txtNoFact.Text = DG.Item(1, Posicion).Value
                txtCliente.Text = DG.Item(2, Posicion).Value
                txtMonto.Text = DG.Item(3, Posicion).Value
                btnGrabar.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            If Not IsNumeric(txtNoFact.Text) Then
                MsgBox("Debe seleccionar la factura que desea registrar como pagada", vbInformation)
                Return
            End If
            If FechaValida(txtFecha.Text) = False Then
                MsgBox("La fecha de pago no es una fecha valida, verifique", vbInformation)
                txtFecha.Focus()
                Return
            End If

            StrSql = "UPDATE FACTURA SET PAGADA ='S', FECHA_PAGO ='" & Efecha(txtFecha.Text) & "' WHERE ID_FACTURA =" & CLng(txtNoFact.Text)
            objCmd = New OleDbCommand(StrSql, Cnn)
            RA = objCmd.ExecuteNonQuery()
            If RA > 0 Then
                MsgBox("Ok. Factura registrada como pagada", vbInformation)
                txtNoFact.Clear() : txtCliente.Clear() : txtMonto.Clear() : txtFecha.Clear()
                FormatGrid()
                ActualizaGrid()
            Else
                MsgBox("No fue posible registrar la factura como pagada", vbCritical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

End Class