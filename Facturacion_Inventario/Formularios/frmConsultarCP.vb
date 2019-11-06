Imports System.Data.OleDb

Public Class frmConsultarCP
    Dim fecha1 As Boolean

    Public Sub FormatGrid()
        DG.Rows.Clear()
        DG.ColumnCount = 6
        DG.Columns(0).HeaderText = "ID"
        DG.Columns(1).HeaderText = "REFERENCIA"
        DG.Columns(2).HeaderText = "PRODUCTO"
        DG.Columns(3).HeaderText = "COSTO"
        DG.Columns(4).HeaderText = "PRECIO VENTA"
        DG.Columns(5).HeaderText = "COSTO PROMEDIO"

        DG.Columns(0).Visible = False
        DG.Columns(1).Width = 115
        DG.Columns(2).Width = 325
        DG.Columns(3).Width = 90
        DG.Columns(4).Width = 90
        DG.Columns(5).Width = 90

        ' desactivar los estilos visuales del sistema
        DG.EnableHeadersVisualStyles = False
        DG.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        DG.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable

        DG.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        DG.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DG.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DG.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        ' estilo para la cabecera del grid
        DG.ColumnHeadersDefaultCellStyle.BackColor = Color.YellowGreen
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

    End Sub

    Sub ActualizaGrid()

        FormatGrid()

        Try

            'Dim Fecha As String = ""
            'Dim Fecha2 As String = ""
            Dim CostoTotal As Double = 0
            Dim CostoPromedio As Double = 0
            Dim Cantidad As Integer = 0

            'Fecha = Format(Today, "yyyy/MM/dd")
            'Fecha2 = Format(Today.AddMonths(-1), "yyyy/MM/dd")

            If Len(Trim(txtProducto.Text)) = 0 Then
                StrSql = "SELECT * FROM INVENTARIO ORDER BY DESCRIPCION ASC"
            Else
                StrSql = "SELECT * FROM INVENTARIO WHERE DESCRIPCION LIKE '" & txtProducto.Text & "%' ORDER BY DESCRIPCION ASC"
            End If
            objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
            Da = New OleDbDataAdapter(StrSql, Cnn)
            Da.Fill(Ds, "inventario")
            If Ds.Tables("inventario").Rows.Count > 0 Then
                For Each registro In Ds.Tables("inventario").Rows

                    Cantidad = 0 : CostoTotal = 0 : CostoPromedio = 0


                    StrSql = "SELECT COSTO FROM ENTRADAS_PRODUCTOS WHERE REFERENCIA ='" & registro("referencia") _
                    & "' AND FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "'"
                    objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
                    objReader = objCmd.ExecuteReader
                    If objReader.HasRows Then
                        While objReader.Read
                            Cantidad = Cantidad + 1
                            CostoTotal = CostoTotal + objReader("costo")
                        End While
                        objReader.Close()

                        CostoPromedio = CostoTotal / Cantidad
                    Else
                        objReader.Close()
                        CostoPromedio = registro("costo")
                    End If

                    DG.Rows.Add(registro("id"), registro("referencia"), registro("descripcion"),
                    FormatNumber(registro("costo"), 2), FormatNumber(registro("precio_venta"), 2), FormatNumber(CostoPromedio, 2))

                Next
            End If
            Ds.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub frmConsultarCP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtbfecha1.Text = Format(Date.Today.AddDays(-1), "dd/MM/yyyy")
        mtbfecha2.Text = Format(Date.Today, "dd/MM/yyyy")
        mc.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fecha1 = True

        If mc.Visible = False Then
            mc.Visible = True
            mc.Focus()
        Else
            mc.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fecha1 = False

        If mc.Visible = True Then
            mc.Visible = False
        Else
            mc.Visible = True
            mc.Focus()
        End If

    End Sub

    Private Sub mc_DateSelected(sender As Object, e As DateRangeEventArgs) Handles mc.DateSelected
        If fecha1 = True Then
            mtbfecha1.Text = mc.SelectionRange.Start.ToString("dd/MM/yyyy")
        Else
            mtbfecha2.Text = mc.SelectionRange.Start.ToString("dd/MM/yyyy")
        End If
        mc.Visible = False
    End Sub

    Private Sub mc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mc.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            mc.Visible = False
        End If
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If FechaValida(mtbfecha1.Text) = False Then
            MsgBox("La fecha DESDE no es valida, verifique", vbInformation)
            Return
        End If
        If FechaValida(mtbfecha2.Text) = False Then
            MsgBox("La fecha HASTA no es valida, verifique", vbInformation)
            Return
        End If

        ActualizaGrid()
    End Sub
End Class