Public Class frmReporteRecibos
    Dim fecha1 As Boolean

    Private Sub frmReporteRecibos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtbfecha1.Text = Format(Date.Today, "dd/MM/yyyy")
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
            Rpt.Load(Application.StartupPath & "\rptRecibos.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")

            Titulo = "REPORTE DE RECIBOS"
            Criterio = "Desde el " & mtbfecha1.Text & " Hasta el " & mtbfecha2.Text

            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.RecordSelectionFormula = "{pagos.fecha_pago} >= '" & Efecha(mtbfecha1.Text) _
                & "' AND {pagos.fecha_pago} <= '" & Efecha(mtbfecha2.Text) & "'"

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("TITULO").Text = "'" & Titulo & "'"
            Rpt.DataDefinition.FormulaFields("criterio").Text = "'" & Criterio & "'"

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