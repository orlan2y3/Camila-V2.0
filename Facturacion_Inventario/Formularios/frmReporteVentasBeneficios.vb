Imports System.Data.OleDb

Public Class frmReporteVentasBeneficios
    Dim fecha1 As Boolean

    Private Sub frmReporteVentasBeneficios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtbfecha1.Text = Format(Today, "dd/MM/yyyy")
        mtbfecha2.Text = Format(Today, "dd/MM/yyyy")
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

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Close()
    End Sub

    Private Sub mc_DateSelected(sender As Object, e As DateRangeEventArgs) Handles mc.DateSelected
        If fecha1 = True Then
            mtbfecha1.Text = mc.SelectionRange.Start.ToString("dd/MM/yyyy")
        Else
            mtbfecha2.Text = mc.SelectionRange.Start.ToString("dd/MM/yyyy")
        End If
        mc.Visible = False
    End Sub

    Private Sub btprint_Click(sender As Object, e As EventArgs) Handles btprint.Click
        Try

            If FechaValida(mtbfecha1.Text) = False Then
                MsgBox("La fecha Desde no es valida, verifique", vbInformation)
                mtbfecha1.Focus()
                Return
            End If
            If FechaValida(mtbfecha2.Text) = False Then
                MsgBox("La fecha Hasta no es valida, verifique", vbInformation)
                mtbfecha2.Focus()
                Return
            End If

            Dim TotalDescuento As Decimal = 0
            Dim Costo As Decimal = 0

            StrSql = "SELECT SUM(cantidad_descuento) AS TOTALDESCUENTO FROM FACTURA" _
            & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) _
            & "' AND ESTADO ='Normal'"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader("TOTALDESCUENTO")) Then
                    TotalDescuento = objReader("TOTALDESCUENTO")
                Else
                    TotalDescuento = 0
                End If
                objReader.Close()
            Else
                TotalDescuento = 0
                objReader.Close()
            End If

            Dim Cant As Long = 0
            Dim CantidadArticulos As Long = 0
            Dim SumaCosto As Decimal = 0
            Dim CostoInventario As Decimal = 0
            Dim CostoPromedio As Decimal = 0
            Dim Promedio As Decimal = 0

            '******** Proceso para calcular el costo promedio del periodo seleccionado *************************
            StrSql = "SELECT DISTINCT(DF.REFERENCIA) FROM FACTURA F, DETALLES_FACTURA DF" _
            & " WHERE F.FECHA >='" & Efecha(mtbfecha1.Text) & "' AND F.FECHA <='" & Efecha(mtbfecha2.Text) _
            & "' AND F.ESTADO ='Normal' AND F.ID_FACTURA = DF.ID_FACTURA"
            Da = New OleDbDataAdapter(StrSql, Cnn)
            Da.Fill(Ds, "REFERENCIAS")
            For Each registro In Ds.Tables("REFERENCIAS").Rows

                StrSql = "SELECT COUNT(referencia) as cantidad FROM ENTRADAS_PRODUCTOS WHERE REFERENCIA ='" & registro("referencia").ToString _
                & "' AND FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "'"
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                objReader.Read()
                Cant = objReader("cantidad")
                objReader.Close()

                If Cant = 0 Then
                    StrSql = "SELECT COSTO FROM INVENTARIO WHERE REFERENCIA ='" & registro("referencia").ToString & "'"
                    objCmd = New OleDbCommand(StrSql, Cnn)
                    objReader = objCmd.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        CostoInventario = objReader("costo")
                        objReader.Close()
                    Else
                        objReader.Close()
                    End If

                Else

                    StrSql = "SELECT SUM(costo) as SumaCosto FROM ENTRADAS_PRODUCTOS WHERE REFERENCIA ='" & registro("referencia").ToString _
                    & "' AND FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "'"
                    objCmd = New OleDbCommand(StrSql, Cnn)
                    objReader = objCmd.ExecuteReader
                    objReader.Read()
                    SumaCosto = objReader("SumaCosto")
                    objReader.Close()

                End If

                If Cant > 0 Then
                    Promedio = SumaCosto / Cant
                Else
                    Promedio = CostoInventario
                End If

                StrSql = "SELECT SUM(DF.CANTIDAD) AS CANTIDAD_ARTICULOS FROM FACTURA F, DETALLES_FACTURA DF" _
                & " WHERE DF.REFERENCIA ='" & registro("referencia").ToString _
                & "' AND F.FECHA >='" & Efecha(mtbfecha1.Text) & "' AND F.FECHA <='" & Efecha(mtbfecha2.Text) _
                & "' AND F.ESTADO ='Normal' AND F.ID_FACTURA = DF.ID_FACTURA"
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                objReader.Read()
                CantidadArticulos = objReader("cantidad_articulos")
                objReader.Close()

                CostoPromedio = CostoPromedio + (Promedio * CantidadArticulos)


                SumaCosto = 0 : Cant = 0 : CostoInventario = 0 : CantidadArticulos = 0 : Promedio = 0
                '***************************************************************************************************
            Next
            Ds.Clear()


            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\rptVentasBeneficios.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")

            Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) _
            & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) _
            & "' AND {factura.estado} ='Normal'"

            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Dim Critero As String = "Desde el " & mtbfecha1.Text & " Hasta el " & mtbfecha2.Text

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("criterio").Text = "'" & Critero & "'"
            Rpt.DataDefinition.FormulaFields("CostoPeriodo").Text = CostoPromedio
            Rpt.DataDefinition.FormulaFields("Descuentos").Text = CDec(TotalDescuento)

            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.Show()

        Catch ex As Exception
            MsgBox(ex.Message)
        Return
        End Try

    End Sub

    Private Sub mc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mc.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            mc.Visible = False
        End If
    End Sub
End Class