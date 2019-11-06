Imports System.Data.OleDb
Imports System.IO
Imports CrystalDecisions.Shared

Public Class frmEnviarCorreos
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

    Private Sub frmEnviarCorreos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtbfecha1.Text = Format(Date.Today, "dd/MM/yyyy")
        mtbfecha2.Text = Format(Date.Today, "dd/MM/yyyy")
        mc.Visible = False
        LlenaUsuarios()
        rbTodos.Checked = True
        cmbUsuarios.Text = NombreUsuario

        If NivelUsuario <> 1 Then
            GroupBox1.Enabled = False
        End If

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

    Private Sub mc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mc.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            mc.Visible = False
        End If
    End Sub

    Private Sub rbUno_Click(sender As Object, e As EventArgs) Handles rbUno.Click
        cmbUsuarios.Enabled = True
        Label3.Enabled = True
    End Sub

    Private Sub rbTodos_Click(sender As Object, e As EventArgs) Handles rbTodos.Click
        cmbUsuarios.Enabled = False
        Label3.Enabled = False
    End Sub

    Private Sub cmbUsuarios_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbUsuarios.SelectedValueChanged
        cmbIdUsuarios.SelectedIndex = cmbUsuarios.SelectedIndex
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

            If Email.Length = 0 Then
                MsgBox("Primero debe registrar en parametros la cuenta de correo", vbInformation)
                Return
            End If

            btnEnviar.Enabled = False
            btprint.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            Dim TotalContado As Decimal = 0
            Dim TotalCredito As Decimal = 0
            Dim TotalDescuento As Decimal = 0

            If rbTodos.Checked Then
                StrSql = "SELECT SUM(sub_total) as SubTotal FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Contado'"
            Else
                StrSql = "SELECT SUM(sub_total) as SubTotal FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Contado' AND ID_USUARIO =" & cmbIdUsuarios.Text
            End If
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader("SubTotal")) Then
                    TotalContado = objReader("SubTotal")
                Else
                    TotalContado = 0
                End If
                objReader.Close()
            Else
                objReader.Close()
                TotalContado = 0
            End If


            If rbTodos.Checked Then
                StrSql = "SELECT SUM(sub_total) as SubTotal FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Crédito'"
            Else
                StrSql = "SELECT SUM(sub_total) as SubTotal FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Crédito' AND ID_USUARIO =" & cmbIdUsuarios.Text
            End If
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader("SubTotal")) Then
                    TotalCredito = objReader("SubTotal")
                Else
                    TotalCredito = 0
                End If
                objReader.Close()
            Else
                objReader.Close()
                TotalCredito = 0
            End If


            If rbTodos.Checked Then
                StrSql = "SELECT SUM(cantidad_descuento) AS TOTALDESCUENTO FROM FACTURA" _
                & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) _
                & "' AND ESTADO ='Normal'"
            Else
                StrSql = "SELECT SUM(cantidad_descuento) AS TOTALDESCUENTO FROM FACTURA" _
                & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) _
                & "' AND ESTADO ='Normal' AND ID_USUARIO =" & cmbIdUsuarios.Text
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



            If TotalContado = 0 And TotalCredito = 0 Then
                btnEnviar.Enabled = True
                btprint.Enabled = True
                Me.Cursor = Cursors.Default
                MsgBox("No hay ventas registradas en ese rango de fechas", vbInformation)
                Return
            End If

            Dim Criterio As String = ""
            Dim Titulo As String = ""
            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\rptVentas_VentasProductos.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")

            Titulo = "REPORTE DE VENTAS"
            Criterio = "Desde el " & mtbfecha1.Text & " Hasta el " & mtbfecha2.Text

            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("titulo").Text = "'" & Titulo & "'"
            Rpt.DataDefinition.FormulaFields("criterio").Text = "'" & Criterio & "'"

            Rpt.DataDefinition.FormulaFields("VentasContado").Text = TotalContado
            Rpt.DataDefinition.FormulaFields("VentasCredito").Text = TotalCredito
            Rpt.DataDefinition.FormulaFields("TotalDescuento").Text = TotalDescuento

            If rbUno.Checked Then
                Rpt.DataDefinition.FormulaFields("USUARIO").Text = "'Cuadre de:  " & cmbUsuarios.Text & "'"
            Else
                Rpt.DataDefinition.FormulaFields("USUARIO").Text = "'Cuadre General'"
            End If


            Titulo = "REPORTE DE VENTAS POR PRODUCTO"
            Criterio = "Desde el " & mtbfecha1.Text & " Hasta el " & mtbfecha2.Text

            Rpt.Subreports.Item("rptVentasPorProductos.rpt").RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) _
            & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) & "' AND {factura.estado} ='Normal'"

            Rpt.Subreports.Item("rptVentasPorProductos.rpt").DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.Subreports.Item("rptVentasPorProductos.rpt").DataDefinition.FormulaFields("TITULO").Text = "'" & Titulo & "'"
            Rpt.Subreports.Item("rptVentasPorProductos.rpt").DataDefinition.FormulaFields("criterio").Text = "'" & Criterio & "'"
            Rpt.Subreports.Item("rptVentasPorProductos.rpt").DataDefinition.FormulaFields("Periodo").Text = "'Total Vendido desde el " _
                                                                                                & mtbfecha1.Text & " hasta el " & mtbfecha2.Text & "  ==>'"


            Dim Asunto As String = "Reporte de Ventas del " & Date.Now
            Dim Adjunto As String = Application.StartupPath & "\Archivos Pdf\ReporteVentas_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

            Rpt.ExportToDisk(ExportFormatType.PortableDocFormat, Adjunto)

            If EnviaCorreo(Email, Asunto, "", Adjunto) = True Then
                ''Para verificar si existen documentos pdf en la ruta especificada
                ''y si existen, eliminarlos todos
                'Dim files() As String = System.IO.Directory.GetFiles(Application.StartupPath, "*.pdf", IO.SearchOption.TopDirectoryOnly)
                'If files.Count > 0 Then
                '    For Each doc In files
                '        File.Delete(doc)
                '    Next
                'End If

                Me.Cursor = Cursors.Default
                MsgBox("Correo enviado", vbInformation)
                btnEnviar.Enabled = True
                btprint.Enabled = True
            Else
                btnEnviar.Enabled = True
                btprint.Enabled = True
                Me.Cursor = Cursors.Default
                MsgBox("Error: No fue posible enviar el correo", vbCritical)
                Return
            End If

        Catch ex As Exception
            btnEnviar.Enabled = True
            btprint.Enabled = True
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message)
            Return
        End Try

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

            If Email.Length = 0 Then
                MsgBox("Primero debe registrar en parametros la cuenta de correo", vbInformation)
                Return
            End If

            btprint.Enabled = False
            btnEnviar.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            Dim TotalContado As Decimal = 0
            Dim TotalCredito As Decimal = 0
            Dim TotalDescuento As Decimal = 0

            If rbTodos.Checked Then
                StrSql = "SELECT SUM(sub_total) as SubTotal FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Contado'"
            Else
                StrSql = "SELECT SUM(sub_total) as SubTotal FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Contado' AND ID_USUARIO =" & cmbIdUsuarios.Text
            End If
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader("SubTotal")) Then
                    TotalContado = objReader("SubTotal")
                Else
                    TotalContado = 0
                End If
                objReader.Close()
            Else
                objReader.Close()
                TotalContado = 0
            End If


            If rbTodos.Checked Then
                StrSql = "SELECT SUM(sub_total) as SubTotal FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Crédito'"
            Else
                StrSql = "SELECT SUM(sub_total) as SubTotal FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Crédito' AND ID_USUARIO =" & cmbIdUsuarios.Text
            End If
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader("SubTotal")) Then
                    TotalCredito = objReader("SubTotal")
                Else
                    TotalCredito = 0
                End If
                objReader.Close()
            Else
                objReader.Close()
                TotalCredito = 0
            End If


            If rbTodos.Checked Then
                StrSql = "SELECT SUM(cantidad_descuento) AS TOTALDESCUENTO FROM FACTURA" _
                & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) _
                & "' AND ESTADO ='Normal'"
            Else
                StrSql = "SELECT SUM(cantidad_descuento) AS TOTALDESCUENTO FROM FACTURA" _
                & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) _
                & "' AND ESTADO ='Normal' AND ID_USUARIO =" & cmbIdUsuarios.Text
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



            If TotalContado = 0 And TotalCredito = 0 Then
                btnEnviar.Enabled = True
                btprint.Enabled = True
                Me.Cursor = Cursors.Default
                MsgBox("No hay ventas registradas en ese rango de fechas", vbInformation)
                Return
            End If

            Dim Criterio As String = ""
            Dim Titulo As String = ""
            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\rptVentas_VentasProductos.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")

            Titulo = "REPORTE DE VENTAS"
            Criterio = "Desde el " & mtbfecha1.Text & " Hasta el " & mtbfecha2.Text

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("titulo").Text = "'" & Titulo & "'"
            Rpt.DataDefinition.FormulaFields("criterio").Text = "'" & Criterio & "'"

            Rpt.DataDefinition.FormulaFields("VentasContado").Text = TotalContado
            Rpt.DataDefinition.FormulaFields("VentasCredito").Text = TotalCredito
            Rpt.DataDefinition.FormulaFields("TotalDescuento").Text = TotalDescuento

            If rbUno.Checked Then
                Rpt.DataDefinition.FormulaFields("USUARIO").Text = "'Cuadre de:  " & cmbUsuarios.Text & "'"
            Else
                Rpt.DataDefinition.FormulaFields("USUARIO").Text = "'Cuadre General'"
            End If


            Titulo = "REPORTE DE VENTAS POR PRODUCTO"
            Criterio = "Desde el " & mtbfecha1.Text & " Hasta el " & mtbfecha2.Text

            Rpt.Subreports.Item("rptVentasPorProductos.rpt").RecordSelectionFormula = "{factura.fecha} >= '" & Efecha(mtbfecha1.Text) _
            & "' AND {factura.fecha} <= '" & Efecha(mtbfecha2.Text) & "' AND {factura.estado} ='Normal'"

            Rpt.Subreports.Item("rptVentasPorProductos.rpt").DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.Subreports.Item("rptVentasPorProductos.rpt").DataDefinition.FormulaFields("TITULO").Text = "'" & Titulo & "'"
            Rpt.Subreports.Item("rptVentasPorProductos.rpt").DataDefinition.FormulaFields("criterio").Text = "'" & Criterio & "'"
            Rpt.Subreports.Item("rptVentasPorProductos.rpt").DataDefinition.FormulaFields("Periodo").Text = "'Total Vendido desde el " _
                                                                                                & mtbfecha1.Text & " hasta el " & mtbfecha2.Text & "  ==>'"

            Reporte.CrystalReportViewer1.ReportSource = Rpt
            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.Show()
            btprint.Enabled = True
            btnEnviar.Enabled = True
            Me.Cursor = Cursors.Default


        Catch ex As Exception
            btnEnviar.Enabled = True
            btprint.Enabled = True
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

End Class