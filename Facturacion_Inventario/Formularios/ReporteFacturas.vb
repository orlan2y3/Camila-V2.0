Imports System.Data.OleDb

Public Class ReporteFacturas
    Dim fecha1 As Boolean

    Sub LlenaUsuarios()
        cmbUsuarios.Items.Clear()
        cmbIdUsuarios.Items.Clear()

        StrSql = "SELECT ID, NOMBRE_COMPLETO, ESTADO FROM USUARIOS WHERE ESTADO ='ACTIVO'"
        objCmd = New OleDbCommand(StrSql, Cnn)
        objReader = objCmd.ExecuteReader
        If objReader.HasRows Then
            While objReader.Read
                cmbIdUsuarios.Items.Add(objReader("id"))
                cmbUsuarios.Items.Add(objReader("nombre_completo").ToString)
            End While
            objReader.Close()
        Else
            objReader.Close()
        End If

    End Sub

    Private Sub ReporteFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtbfecha1.Text = Format(Today, "dd/MM/yyyy")
        mtbfecha2.Text = Format(Today, "dd/MM/yyyy")
        mc.Visible = False
        LlenaUsuarios()
        rbUno.Checked = True
        cmbUsuarios.Text = NombreUsuario
        rbContado.Checked = True
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
        Close()
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

            If rbAnuladas.Checked = True Then
                If rbTodos.Checked Then
                    StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE ESTADO ='Anulada'"
                Else
                    StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE ESTADO ='Anulada' AND ID_USUARIO =" & cmbIdUsuarios.Text
                End If
            ElseIf rbContado.Checked = True Then
                If rbTodos.Checked Then
                    StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE ESTADO ='Normal' AND CONDICION ='Contado'"
                Else
                    StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE ESTADO ='Normal' AND CONDICION ='Contado' AND ID_USUARIO =" & cmbIdUsuarios.Text
                End If
            ElseIf rbCredito.Checked = True Then
                If rbTodos.Checked Then
                    StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE ESTADO ='Normal' AND CONDICION ='Crédito'"
                Else
                    StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE ESTADO ='Normal' AND CONDICION ='Crédito' AND ID_USUARIO =" & cmbIdUsuarios.Text
                End If
            Else
                If rbTodos.Checked Then
                    StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE ESTADO ='Normal' AND PAGADA ='S'"
                Else
                    StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE ESTADO ='Normal' AND PAGADA ='S' AND ID_USUARIO =" & cmbIdUsuarios.Text
                End If
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

            Dim Criterio As String = ""
            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\rptfacturas.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")

            If rbAnuladas.Checked = True Then
                If rbTodos.Checked Then
                    Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) _
                    & "' AND {factura.estado} = 'Anulada'"

                    Criterio = "Reporte de Facturas Anuladas"
                Else
                    Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) _
                    & "' AND {factura.estado} = 'Anulada' AND {factura.id_usuario} =" & cmbIdUsuarios.Text

                    Criterio = "Reporte de Facturas Anuladas de " & cmbUsuarios.Text
                End If

            ElseIf rbContado.Checked = True Then
                If rbTodos.Checked Then
                    Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) _
                    & "' AND {factura.estado} = 'Normal' AND  {factura.condicion} = 'Contado'"

                    Criterio = "Reporte de Facturas de Contado"
                Else
                    Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) _
                    & "' AND {factura.estado} = 'Normal' AND  {factura.condicion} = 'Contado' AND {factura.id_usuario} =" & cmbIdUsuarios.Text

                    Criterio = "Reporte de Facturas de Contado de " & cmbUsuarios.Text
                End If
            ElseIf rbCredito.Checked = True Then
                If rbTodos.Checked Then
                    Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) _
                    & "' AND {factura.estado} = 'Normal' AND  {factura.condicion} = 'Crédito'"

                    Criterio = "Reporte de Facturas a Crédito"
                Else
                    Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) _
                    & "' AND {factura.estado} = 'Normal' AND  {factura.condicion} = 'Crédito' AND {factura.id_usuario} =" & cmbIdUsuarios.Text

                    Criterio = "Reporte de Facturas a Crédito de " & cmbUsuarios.Text
                End If
            Else
                If rbTodos.Checked Then
                    Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) _
                    & "' AND {factura.estado} = 'Normal' AND  {factura.pagada} = 'S'"

                    Criterio = "Reporte de Facturas de Contado y las de Crédito cobradas"
                Else
                    Rpt.RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) _
                    & "' AND {factura.estado} = 'Normal' AND  {factura.pagada} = 'S' AND {factura.id_usuario} =" & cmbIdUsuarios.Text

                    Criterio = "Reporte de Facturas de Contado y las de Crédito cobradas de " & cmbUsuarios.Text
                End If
            End If

            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("DIRECCION").Text = "'" & DireccionEmp & "'"
            Rpt.DataDefinition.FormulaFields("RNC").Text = "' RNC: " & RncEmp & "'"
            Rpt.DataDefinition.FormulaFields("TELEFONO").Text = "' Tels: " & TelefonoEmp & "'"

            Rpt.DataDefinition.FormulaFields("fecha1").Text = "'" & mtbfecha1.Text & "'"
            Rpt.DataDefinition.FormulaFields("fecha2").Text = "'" & mtbfecha2.Text & "'"
            Rpt.DataDefinition.FormulaFields("nombre").Text = "'" & Criterio & "'"
            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.Show()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub mc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mc.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            mc.Visible = False
        End If
    End Sub

    Private Sub cmbUsuarios_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbUsuarios.SelectedValueChanged
        cmbIdUsuarios.SelectedIndex = cmbUsuarios.SelectedIndex
    End Sub

    Private Sub rbUno_Click(sender As Object, e As EventArgs) Handles rbUno.Click
        cmbUsuarios.Enabled = True
        Label3.Enabled = True
    End Sub

    Private Sub rbTodos_Click(sender As Object, e As EventArgs) Handles rbTodos.Click
        cmbUsuarios.Enabled = False
        Label3.Enabled = False
    End Sub

End Class