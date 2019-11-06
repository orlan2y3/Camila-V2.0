Public Class ReporteCotizacion
    Dim fecha1 As Boolean

    Private Sub ReporteCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtbfecha1.Text = Format(Today, "dd/MM/yyyy")
        mtbfecha2.Text = Format(Today, "dd/MM/yyyy")
        mc1.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fecha1 = True

        If mc1.Visible = False Then
            mc1.Visible = True
            mc1.Focus()
        Else
            mc1.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fecha1 = False

        If mc1.Visible = True Then
            mc1.Visible = False
        Else
            mc1.Visible = True
            mc1.Focus()
        End If
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Close()
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

            If CheckBox1.Checked = True Then
                Dim Reporte As New Reportes
                Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                Rpt.Load(Application.StartupPath & "\rptcotizaciones.rpt")
                Rpt.SetDatabaseLogon("admin", "cladatos-ao")

                Rpt.RecordSelectionFormula = "{cotizacion.fecha} >= '" & Efecha(mtbfecha1.Text) & "' AND {cotizacion.fecha} <= '" & Efecha(mtbfecha2.Text) & "' AND {cotizacion.estado} = 'Anulada'"
                Reporte.CrystalReportViewer1.ReportSource = Rpt

                'For x = 0 To Rpt.Database.Tables.Count - 1
                '    Rpt.Database.Tables(x).Location = Application.StartupPath & "\Factura_Inventario.mdb"
                'Next

                Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
                Rpt.DataDefinition.FormulaFields("DIRECCION").Text = "'" & DireccionEmp & "'"
                Rpt.DataDefinition.FormulaFields("RNC").Text = "' RNC: " & RncEmp & "'"
                Rpt.DataDefinition.FormulaFields("TELEFONO").Text = "' Tels: " & TelefonoEmp & "'"

                Rpt.DataDefinition.FormulaFields("fecha1").Text = "'" & mtbfecha1.Text & "'"
                Rpt.DataDefinition.FormulaFields("fecha2").Text = "'" & mtbfecha2.Text & "'"
                Rpt.DataDefinition.FormulaFields("nombre").Text = "'REPORTE  DE  COTIZACIONES  ANULADAS'"
                Reporte.CrystalReportViewer1.RefreshReport()
                Reporte.Show()
            Else
                Dim Reporte As New Reportes
                Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                Rpt.Load(Application.StartupPath & "\rptcotizaciones.rpt")
                Rpt.SetDatabaseLogon("admin", "cladatos-ao")

                Rpt.RecordSelectionFormula = "{cotizacion.fecha} >= '" & Efecha(mtbfecha1.Text) & "' AND {cotizacion.fecha} <= '" & Efecha(mtbfecha2.Text) & "' AND {cotizacion.estado} = 'Normal'"
                Reporte.CrystalReportViewer1.ReportSource = Rpt

                Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
                Rpt.DataDefinition.FormulaFields("DIRECCION").Text = "'" & DireccionEmp & "'"
                Rpt.DataDefinition.FormulaFields("RNC").Text = "' RNC: " & RncEmp & "'"
                Rpt.DataDefinition.FormulaFields("TELEFONO").Text = "' Tels: " & TelefonoEmp & "'"

                Rpt.DataDefinition.FormulaFields("fecha1").Text = "'" & mtbfecha1.Text & "'"
                Rpt.DataDefinition.FormulaFields("fecha2").Text = "'" & mtbfecha2.Text & "'"
                Rpt.DataDefinition.FormulaFields("nombre").Text = "'REPORTE  DE  COTIZACIONES  REGISTRADAS'"
                Reporte.CrystalReportViewer1.RefreshReport()
                Reporte.Show()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub mc_DateSelected(sender As Object, e As DateRangeEventArgs) Handles mc1.DateSelected
        If fecha1 = True Then
            mtbfecha1.Text = mc1.SelectionRange.Start.ToString("dd/MM/yyyy")
        Else
            mtbfecha2.Text = mc1.SelectionRange.Start.ToString("dd/MM/yyyy")
        End If
        mc1.Visible = False
    End Sub

    Private Sub mc1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mc1.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            mc1.Visible = False
        End If
    End Sub
End Class