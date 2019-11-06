Imports System.Data.OleDb

Public Class frmReporteInvMenorQue
    Private Sub frmReporteInvMenorQue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCant.Select()
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Me.Close()
    End Sub

    Private Sub btprint_Click(sender As Object, e As EventArgs) Handles btprint.Click
        Try

            If Not IsNumeric(txtCant.Text) Then
                MsgBox("Debe digitar un valor numerico en cantidad", vbInformation)
                txtCant.Focus()
                Return
            End If

            StrSql = "SELECT TOP 1 ID FROM INVENTARIO WHERE EXISTENCIA <=" & CLng(txtCant.Text)
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If Not objReader.HasRows Then
                objReader.Close()
                MsgBox("No hay productos con existencia menor o igual a: " & txtCant.Text, vbInformation)
                Return
            Else
                objReader.Close()
            End If

            Me.Cursor = Cursors.WaitCursor
            Dim Reporte As New Reportes
            Reporte.MdiParent = Me.MdiParent

            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            Rpt.Load(Application.StartupPath & "\rptInventarioMenorQue.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")

            Rpt.RecordSelectionFormula = "{inventario.existencia} <=" & CLng(txtCant.Text)
            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"

            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.Show()
            Me.Cursor = Cursors.Default


        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
    End Sub

    Private Sub txtCant_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCant.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class