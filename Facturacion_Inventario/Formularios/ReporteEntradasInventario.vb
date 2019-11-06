Imports System.Data.OleDb
Imports CrystalDecisions.Shared

Public Class ReporteEntradasInventario
    Dim fecha1 As Boolean

    Private Sub ReporteEntradasInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Fecha = Format(Now.AddMonths(-1), "dd/MM/yyyy")
        mtbfecha1.Text = Fecha
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


            StrSql = "SELECT TOP 1 ID FROM ENTRADAS_PRODUCTOS" _
            & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "'"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Close()
            Else
                objReader.Close()
                MsgBox("No hay entradas al inventario en ese rango de fechas", vbInformation)
                mtbfecha1.Focus()
                Return
            End If

            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\rptEntradasInventario.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")

            Rpt.RecordSelectionFormula = "{entradas_productos.fecha} >= '" & Efecha(mtbfecha1.Text) _
            & "' AND {entradas_productos.fecha} <= '" & Efecha(mtbfecha2.Text) & "'"

            Reporte.CrystalReportViewer1.ReportSource = Rpt

            'For x = 0 To Rpt.Database.Tables.Count - 1
            '    Rpt.Database.Tables(x).Location = Application.StartupPath & "\Factura_Inventario.mdb"
            'Next

            Dim Critero As String = "Desde el " & mtbfecha1.Text & " Hasta el " & mtbfecha2.Text

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("criterio").Text = "'" & Critero & "'"

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

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
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

            StrSql = "SELECT TOP 1 ID FROM ENTRADAS_PRODUCTOS" _
            & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "'"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Close()
            Else
                objReader.Close()
                MsgBox("No hay entradas al inventario en ese rango de fechas", vbInformation)
                mtbfecha1.Focus()
                Return
            End If

            btnEnviar.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\rptEntradasInventario.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")

            Rpt.RecordSelectionFormula = "{entradas_productos.fecha} >= '" & Efecha(mtbfecha1.Text) _
            & "' AND {entradas_productos.fecha} <= '" & Efecha(mtbfecha2.Text) & "'"

            Reporte.CrystalReportViewer1.ReportSource = Rpt

            'For x = 0 To Rpt.Database.Tables.Count - 1
            '    Rpt.Database.Tables(x).Location = Application.StartupPath & "\Factura_Inventario.mdb"
            'Next

            Dim Critero As String = "Desde el " & mtbfecha1.Text & " Hasta el " & mtbfecha2.Text

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("criterio").Text = "'" & Critero & "'"

            Dim Asunto As String = "Entradas al Inventario del " & Date.Now
            Dim Adjunto As String = Application.StartupPath & "\Archivos Pdf\EntradaInventario_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

            Rpt.ExportToDisk(ExportFormatType.PortableDocFormat, Adjunto)

            If EnviaCorreo(Email, Asunto, "", Adjunto) = True Then
                Me.Cursor = Cursors.Default
                MsgBox("Correo enviado", vbInformation)
                btnEnviar.Enabled = True
            Else
                btnEnviar.Enabled = True
                Me.Cursor = Cursors.Default
                MsgBox("Error: No fue posible enviar el correo", vbCritical)
                Return
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            btnEnviar.Enabled = True
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

End Class