Imports System.Data.OleDb
Imports System.IO
Imports CrystalDecisions.Shared

Public Class ReporteCuadreCaja
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

    Private Sub ReporteCuadreCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtbfecha1.Text = Format(Date.Today, "dd/MM/yyyy")
        mtbfecha2.Text = Format(Date.Today, "dd/MM/yyyy")
        mc.Visible = False
        LlenaUsuarios()
        rbUno.Checked = True
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

    Private Sub btprint_Click(sender As Object, e As EventArgs) Handles btprint.Click
        Try

            'If NivelUsuario <> 1 Then
            '    Dim fseg As New Seguridad
            '    fseg.ShowDialog()
            '    If Permitido = True Then
            '        Permitido = False
            '    Else
            '        MsgBox("No tiene permisos para imprimir todos los usuarios", vbExclamation)
            '        Return
            '    End If
            'End If

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

            Dim SubTotal As Decimal = 0
            Dim Itbis As Decimal = 0
            Dim TotalDescuento As Decimal = 0
            Dim TotalCobrado As Decimal = 0

            If rbTodos.Checked Then
                StrSql = "SELECT SUM(sub_total) as SubTotal, SUM(ITBIS) as Itbis FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Contado'"
            Else
                StrSql = "SELECT SUM(sub_total) as SubTotal, SUM(ITBIS) as Itbis FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Contado' AND ID_USUARIO =" & cmbIdUsuarios.Text
            End If
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader("SubTotal")) Then
                    SubTotal = objReader("SubTotal")
                    Itbis = objReader("Itbis")
                Else
                    SubTotal = 0 : Itbis = 0
                End If
                objReader.Close()
            Else
                objReader.Close()
                SubTotal = 0 : Itbis = 0
            End If

            If rbTodos.Checked Then
                StrSql = "SELECT SUM(cantidad_descuento) AS TOTALDESCUENTO FROM FACTURA" _
                & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) _
                & "' AND ESTADO ='Normal' AND CONDICION ='Contado'"
            Else
                StrSql = "SELECT SUM(cantidad_descuento) AS TOTALDESCUENTO FROM FACTURA" _
                & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) _
                & "' AND ESTADO ='Normal' AND CONDICION ='Contado' AND ID_USUARIO =" & cmbIdUsuarios.Text
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

            If rbTodos.Checked Then
                StrSql = "SELECT SUM(p.monto) AS TOTALCOBRADO FROM PAGOS P, FACTURA F" _
                & " WHERE P.FECHA_PAGO >='" & Efecha(mtbfecha1.Text) & "' AND P.FECHA_PAGO <='" & Efecha(mtbfecha2.Text) _
                & "' AND P.ANULADO ='N' AND F.ESTADO ='Normal' AND P.ID_FACTURA = F.ID_FACTURA"
            Else
                StrSql = "SELECT SUM(p.monto) AS TOTALCOBRADO FROM PAGOS P, FACTURA F" _
                & " WHERE P.FECHA_PAGO >='" & Efecha(mtbfecha1.Text) & "' AND P.FECHA_PAGO <='" & Efecha(mtbfecha2.Text) _
                & "' AND P.ANULADO ='N' AND P.ID_USUARIO =" & cmbIdUsuarios.Text _
                & " AND F.ESTADO ='Normal' AND P.ID_FACTURA = F.ID_FACTURA"
            End If
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader("TOTALCOBRADO")) Then
                    TotalCobrado = objReader("TOTALCOBRADO")
                End If
                objReader.Close()
            Else
                objReader.Close()
            End If

            '********************************************************************************
            'StrSql = "SELECT SUM(sub_total) AS SubTotal, SUM(ITBIS) AS Itbis FROM FACTURA WHERE FECHA_PAGO >='" & Efecha(mtbfecha1.Text) _
            '& "' AND FECHA_PAGO <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Crédito' AND PAGADA ='S'"
            'objCmd = New OleDbCommand(StrSql, Cnn)
            'objReader = objCmd.ExecuteReader
            'If objReader.HasRows Then
            '    objReader.Read()
            '    If IsNumeric(objReader("SubTotal")) Then
            '        SubTotal = SubTotal + objReader("SubTotal")
            '        Itbis = Itbis + objReader("Itbis")
            '    End If
            '    objReader.Close()
            'Else
            '    objReader.Close()
            'End If

            'StrSql = "SELECT SUM(cantidad_descuento) AS TOTALDESCUENTO FROM FACTURA" _
            '& " WHERE FECHA_PAGO >='" & Efecha(mtbfecha1.Text) & "' AND FECHA_PAGO <='" & Efecha(mtbfecha2.Text) _
            '& "' AND ESTADO ='Normal' AND CONDICION ='Crédito' AND PAGADA ='S'"
            'objCmd = New OleDbCommand(StrSql, Cnn)
            'objReader = objCmd.ExecuteReader
            'If objReader.HasRows Then
            '    objReader.Read()
            '    If IsNumeric(objReader("TOTALDESCUENTO")) Then
            '        TotalDescuento = TotalDescuento + objReader("TOTALDESCUENTO")
            '    End If
            '    objReader.Close()
            'Else
            '    objReader.Close()
            'End If
            '**********************************************************************************************

            If SubTotal = 0 Then
                MsgBox("No hay ventas ni pagos recibidos en ese rango de fechas", vbInformation)
                Return
            End If

            Dim Criterio As String = ""
            Dim Titulo As String = ""
            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\rptCuadreCaja.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")

            Titulo = "REPORTE DE CUADRE DE CAJA"
            Criterio = "Desde el " & mtbfecha1.Text & " Hasta el " & mtbfecha2.Text

            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("titulo").Text = "'" & Titulo & "'"
            Rpt.DataDefinition.FormulaFields("criterio").Text = "'" & Criterio & "'"

            Rpt.DataDefinition.FormulaFields("SubTotal").Text = SubTotal
            Rpt.DataDefinition.FormulaFields("Itbis").Text = Itbis
            Rpt.DataDefinition.FormulaFields("TotalDescuento").Text = TotalDescuento
            Rpt.DataDefinition.FormulaFields("TotalCobrado").Text = TotalCobrado

            If rbUno.Checked Then
                Rpt.DataDefinition.FormulaFields("USUARIO").Text = "'Cuadre de:  " & cmbUsuarios.Text & "'"
            Else
                Rpt.DataDefinition.FormulaFields("USUARIO").Text = "'Cuadre General'"
            End If

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
            Me.Cursor = Cursors.WaitCursor

            Dim SubTotal As Decimal = 0
            Dim Itbis As Decimal = 0
            Dim TotalDescuento As Decimal = 0
            Dim TotalCobrado As Decimal = 0

            If rbTodos.Checked Then
                StrSql = "SELECT SUM(sub_total) as SubTotal, SUM(ITBIS) as Itbis FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Contado'"
            Else
                StrSql = "SELECT SUM(sub_total) as SubTotal, SUM(ITBIS) as Itbis FROM FACTURA WHERE FECHA >='" & Efecha(mtbfecha1.Text) _
                & "' AND FECHA <='" & Efecha(mtbfecha2.Text) & "' AND ESTADO ='Normal' AND CONDICION ='Contado' AND ID_USUARIO =" & cmbIdUsuarios.Text
            End If
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader("SubTotal")) Then
                    SubTotal = objReader("SubTotal")
                    Itbis = objReader("Itbis")
                Else
                    SubTotal = 0 : Itbis = 0
                End If
                objReader.Close()
            Else
                objReader.Close()
                SubTotal = 0 : Itbis = 0
            End If

            If rbTodos.Checked Then
                StrSql = "SELECT SUM(cantidad_descuento) AS TOTALDESCUENTO FROM FACTURA" _
                & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) _
                & "' AND ESTADO ='Normal' AND CONDICION ='Contado'"
            Else
                StrSql = "SELECT SUM(cantidad_descuento) AS TOTALDESCUENTO FROM FACTURA" _
                & " WHERE FECHA >='" & Efecha(mtbfecha1.Text) & "' AND FECHA <='" & Efecha(mtbfecha2.Text) _
                & "' AND ESTADO ='Normal' AND CONDICION ='Contado' AND ID_USUARIO =" & cmbIdUsuarios.Text
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

            If rbTodos.Checked Then
                StrSql = "SELECT SUM(p.monto) AS TOTALCOBRADO FROM PAGOS P, FACTURA F" _
                & " WHERE P.FECHA_PAGO >='" & Efecha(mtbfecha1.Text) & "' AND P.FECHA_PAGO <='" & Efecha(mtbfecha2.Text) _
                & "' AND P.ANULADO ='N' AND F.ESTADO ='Normal' AND P.ID_FACTURA = F.ID_FACTURA"
            Else
                StrSql = "SELECT SUM(p.monto) AS TOTALCOBRADO FROM PAGOS P, FACTURA F" _
                & " WHERE P.FECHA_PAGO >='" & Efecha(mtbfecha1.Text) & "' AND P.FECHA_PAGO <='" & Efecha(mtbfecha2.Text) _
                & "' AND P.ANULADO ='N' AND P.ID_USUARIO =" & cmbIdUsuarios.Text _
                & " AND F.ESTADO ='Normal' AND P.ID_FACTURA = F.ID_FACTURA"
            End If
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader("TOTALCOBRADO")) Then
                    TotalCobrado = objReader("TOTALCOBRADO")
                End If
                objReader.Close()
            Else
                objReader.Close()
            End If

            If SubTotal = 0 Then
                btnEnviar.Enabled = True
                Me.Cursor = Cursors.Default
                MsgBox("No hay ventas ni pagos recibidos en ese rango de fechas", vbInformation)
                Return
            End If

            Dim Criterio As String = ""
            Dim Titulo As String = ""
            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\rptCuadreCaja.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")

            Titulo = "REPORTE DE CUADRE DE CAJA"
            Criterio = "Desde el " & mtbfecha1.Text & " Hasta el " & mtbfecha2.Text

            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("titulo").Text = "'" & Titulo & "'"
            Rpt.DataDefinition.FormulaFields("criterio").Text = "'" & Criterio & "'"

            Rpt.DataDefinition.FormulaFields("SubTotal").Text = SubTotal
            Rpt.DataDefinition.FormulaFields("Itbis").Text = Itbis
            Rpt.DataDefinition.FormulaFields("TotalDescuento").Text = TotalDescuento
            Rpt.DataDefinition.FormulaFields("TotalCobrado").Text = TotalCobrado

            If rbUno.Checked Then
                Rpt.DataDefinition.FormulaFields("USUARIO").Text = "'Cuadre de:  " & cmbUsuarios.Text & "'"
            Else
                Rpt.DataDefinition.FormulaFields("USUARIO").Text = "'Cuadre General'"
            End If

            Dim Asunto As String = "Cuadre de Caja del " & Date.Now
            Dim Adjunto As String = Application.StartupPath & "\Archivos Pdf\CuadreCaja_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

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
            Else
                btnEnviar.Enabled = True
                Me.Cursor = Cursors.Default
                MsgBox("Error: No fue posible enviar el correo", vbCritical)
                Return
            End If

        Catch ex As Exception
            btnEnviar.Enabled = True
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

End Class