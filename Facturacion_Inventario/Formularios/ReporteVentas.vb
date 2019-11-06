Imports System.Data.OleDb

Public Class ReporteVentas
    Dim fecha1 As Boolean

    Private Sub ReporteVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtbfecha1.Text = Format(Date.Today, "dd/MM/yyyy")
        mtbfecha2.Text = Format(Date.Today, "dd/MM/yyyy")
        rbContado.Checked = True
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

            Dim Criterio As String = ""
            Dim Titulo As String = ""
            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\rptVentas.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")

            If rbContado.Checked = True Then
                StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Contado'"
            ElseIf rbCredito.Checked = True Then
                StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Crédito'"
            Else
                StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal'"
            End If
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If Not objReader.HasRows Then
                objReader.Close()
                MsgBox("No hay facturas que cumplan con los parametros especificados", vbInformation)
                Return
            Else
                objReader.Close()
            End If

            Dim TotalDescuento As Decimal = 0

            If rbContado.Checked = True Then
                StrSql = "SELECT SUM(cantidad_descuento) AS TOTALDESCUENTO FROM FACTURA" _
                & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) _
                & "' AND ESTADO ='Normal' AND CONDICION ='Contado'"
            ElseIf rbCredito.Checked = True Then
                StrSql = "SELECT SUM(cantidad_descuento) AS TOTALDESCUENTO FROM FACTURA" _
                & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) _
                & "' AND ESTADO ='Normal' AND CONDICION ='Crédito'"
            Else
                StrSql = "SELECT SUM(cantidad_descuento) AS TOTALDESCUENTO FROM FACTURA" _
                 & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) _
                 & "' AND ESTADO ='Normal'"
            End If

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

            If rbContado.Checked = True Then
                Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) _
                & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) & "' AND {factura.estado} ='Normal'" _
                & " AND {factura.condicion} = 'Contado'"

                Titulo = "REPORTE DE VENTAS DE CONTADO"
                Criterio = "Desde el " & mtbfecha1.Text & " Hasta el " & mtbfecha2.Text
            ElseIf rbCredito.Checked = True Then
                Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) _
                & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) & "' AND {factura.estado} ='Normal'" _
                & " AND {factura.condicion} = 'Crédito'"

                Titulo = "REPORTE DE VENTAS A CREDITO"
                Criterio = "Desde el " & mtbfecha1.Text & " Hasta el " & mtbfecha2.Text
            Else
                Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) _
                & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) & "' AND {factura.estado} ='Normal'"

                Titulo = "REPORTE DE VENTAS DE FACTURAS A CREDITO Y AL CONTADO"
                Criterio = "Desde el " & mtbfecha1.Text & " Hasta el " & mtbfecha2.Text
            End If

            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("titulo").Text = "'" & Titulo & "'"
            Rpt.DataDefinition.FormulaFields("criterio").Text = "'" & Criterio & "'"

            Rpt.DataDefinition.FormulaFields("TotalDescuento").Text = TotalDescuento

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