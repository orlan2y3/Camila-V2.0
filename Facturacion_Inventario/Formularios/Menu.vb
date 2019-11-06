Imports System.Data.OleDb

Public Class frmMenu
    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FmantFacturas.MdiParent = Me
            FmantCotizacion.MdiParent = Me
            Permitido = False
            tssusuario.Text = "Bienvenido" & " " & NombreUsuario

            Dim fecha As String
            fecha = Format(Date.Today, "short Date")
            tssfecha.Text = fecha

            If NivelUsuario <> 1 Then
                MantenimientoDeProductosEnInventarioToolStripMenuItem.Enabled = False
                MantenimientoDeUsuariosToolStripMenuItem.Enabled = False
                MantenimientoDeEntradasDeProductosToolStripMenuItem.Enabled = False
                ReporteDeEntradasAlInventarioToolStripMenuItem.Enabled = False
                ReporteDeInventarioConExistenciaMenorQueToolStripMenuItem.Enabled = False
                ReporteDeInventarioConExistenciaMinimaToolStripMenuItem.Enabled = False
                ReporteDeProductosToolStripMenuItem.Enabled = False
                ReporteDeVentasBeneficiosToolStripMenuItem.Enabled = False

                ParámetrosToolStripMenuItem.Enabled = False
            End If

            If NivelUsuario = 3 Then
                ConfiguraciónToolStripMenuItem1.Enabled = False
                MantenimientoDeUsuariosToolStripMenuItem.Enabled = False
            End If

            If Delivery = "NO" Then
                RegistrarFacturaComoRecibidaToolStripMenuItem.Visible = False
            End If
            'If PermitirCombinacion = "NO" Then

            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tsshora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub NosotrosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim nosotros As New Nosotros
        nosotros.MdiParent = Me
        nosotros.Show()
    End Sub

    Private Sub FacturacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturacionToolStripMenuItem.Click
        Try

            Ffactura.MdiParent = Me
            Ffactura.Show()
            Ffactura.btnuevo.PerformClick()

            Ffactura.cmbcondicion.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CotizacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CotizacionToolStripMenuItem.Click
        Try

            Fcotizacion.MdiParent = Me
            Fcotizacion.Show()
            Fcotizacion.btnuevo.PerformClick()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ReporteDeFacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeFacturasToolStripMenuItem.Click
        If NivelUsuario <> 1 Then
            Dim fseg As New Seguridad
            fseg.ShowDialog()
            If Permitido = True Then
                Permitido = False
                Dim reportefacturas As New ReporteFacturas
                reportefacturas.MdiParent = Me
                reportefacturas.Show()
            End If
        Else
            Dim reportefacturas As New ReporteFacturas
            reportefacturas.MdiParent = Me
            reportefacturas.Show()
        End If

    End Sub

    Private Sub ReporteDeCotizaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeCotizaciónToolStripMenuItem.Click
        Dim reportecotizacion As New ReporteCotizacion
        reportecotizacion.MdiParent = Me
        reportecotizacion.Show()
    End Sub

    Private Sub NosotrosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles NosotrosToolStripMenuItem2.Click
        Dim nosotros As New Nosotros
        nosotros.MdiParent = Me
        nosotros.Show()
    End Sub

    Private Sub SalirDelSistemaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SalirDelSistemaToolStripMenuItem1.Click
        Desconectar()
        End
    End Sub

    Private Sub DatosEmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatosEmpresaToolStripMenuItem.Click
        Dim DatosEmpresa As New frmDatosEmpresa
        DatosEmpresa.MdiParent = Me
        DatosEmpresa.Show()
    End Sub

    Private Sub MantenimientoDeUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeUsuariosToolStripMenuItem.Click
        Try

            Dim usuarios As New Usuarios
            usuarios.MdiParent = Me
            usuarios.Show()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EntradaDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntradaDeProductosToolStripMenuItem.Click
        FentradaProductos.MdiParent = Me
        FentradaProductos.Show()
        FentradaProductos.FormatGrid()
        FentradaProductos.txtRef.Focus()

        'If NivelUsuario <> 1 Then
        '    Dim fseg As New Seguridad
        '    fseg.ShowDialog()
        '    If Permitido = True Then
        '        Permitido = False
        '        FentradaProductos.MdiParent = Me
        '        FentradaProductos.Show()
        '        FentradaProductos.FormatGrid()
        '        FentradaProductos.txtRef.Focus()
        '    End If
        'Else
        '    FentradaProductos.MdiParent = Me
        '    FentradaProductos.Show()
        '    FentradaProductos.FormatGrid()
        '    FentradaProductos.txtRef.Focus()
        'End If

    End Sub

    Private Sub MantenimientoDeProductosEnInventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeProductosEnInventarioToolStripMenuItem.Click
        FmantInventario.MdiParent = Me
        FmantInventario.Show()
    End Sub

    Private Sub MantenimientoDeFacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeFacturasToolStripMenuItem.Click
        If NivelUsuario <> 1 Then
            Dim fseg As New Seguridad
            fseg.ShowDialog()
            If Permitido = True Then
                Permitido = False
                Dim FbuscarFactura As New Buscar_Factura
                FbuscarFactura.MdiParent = Me
                FbuscarFactura.Show()
            End If
        Else
            Dim FbuscarFactura As New Buscar_Factura
            FbuscarFactura.MdiParent = Me
            FbuscarFactura.Show()
        End If

    End Sub

    Private Sub MantenimientoDeCotizacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeCotizacionesToolStripMenuItem.Click
        Dim FbuscarCotizacion As New Buscar_Cotizacion
        FbuscarCotizacion.MdiParent = Me
        FbuscarCotizacion.Show()
    End Sub

    Private Sub ReporteDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeProductosToolStripMenuItem.Click
        Try

            StrSql = "DELETE * FROM RPTINVENTARIO"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objCmd.ExecuteNonQuery()

            Dim FechaInicial As String = ""
            Dim FechaFinal As String = ""
            Dim Cant As Long = 0
            Dim SumaCosto As Decimal = 0
            Dim Promedio As Decimal = 0

            FechaFinal = Format(Now, "dd/MM/yyyy")
            FechaInicial = Format(Now.AddMonths(-1), "dd/MM/yyyy")

            '******** Proceso para calcular el costo promedio del periodo seleccionado *************************
            StrSql = "SELECT REFERENCIA, COSTO FROM INVENTARIO"
            Da = New OleDbDataAdapter(StrSql, Cnn)
            Da.Fill(Ds, "REFERENCIAS")
            For Each registro In Ds.Tables("REFERENCIAS").Rows

                StrSql = "SELECT COUNT(referencia) as cantidad FROM ENTRADAS_PRODUCTOS WHERE REFERENCIA ='" & registro("referencia").ToString _
                & "' AND FECHA >='" & Efecha(FechaInicial) & "' AND FECHA <='" & Efecha(FechaFinal) & "'"
                objCmd = New OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                objReader.Read()
                Cant = objReader("cantidad")
                objReader.Close()

                If Cant > 0 Then
                    StrSql = "SELECT SUM(costo) as SumaCosto FROM ENTRADAS_PRODUCTOS WHERE REFERENCIA ='" & registro("referencia").ToString _
                    & "' AND FECHA >='" & Efecha(FechaInicial) & "' AND FECHA <='" & Efecha(FechaFinal) & "'"
                    objCmd = New OleDbCommand(StrSql, Cnn)
                    objReader = objCmd.ExecuteReader
                    objReader.Read()
                    SumaCosto = objReader("SumaCosto")
                    objReader.Close()

                    Promedio = SumaCosto / Cant
                Else
                    Promedio = registro("costo")
                End If

                StrSql = "INSERT INTO RPTINVENTARIO(REFERENCIA,COSTO_PROMEDIO) VALUES ('" & registro("referencia").ToString & "'," & Promedio & ")"
                objCmd = New OleDbCommand(StrSql, Cnn)
                objCmd.ExecuteNonQuery()

                SumaCosto = 0 : Cant = 0 : Promedio = 0
                '***************************************************************************************************
            Next
            Ds.Clear()

            Me.Cursor = Cursors.WaitCursor
            Dim Criterio As String = ""
            Dim Reporte As New Reportes
            Reporte.MdiParent = Me.MdiParent

            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            Rpt.Load(Application.StartupPath & "\rptInventario2.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")
            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Criterio = "** Fecha de calculo del Costo Promedio: desde el " & FechaInicial & " Hasta el " & FechaFinal & " **"
            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"
            Rpt.DataDefinition.FormulaFields("Criterio").Text = "'" & Criterio & "'"

            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.MdiParent = Me
            Reporte.Show()
            Me.Cursor = Cursors.Default


        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub ReporteDeEntradasAlInventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeEntradasAlInventarioToolStripMenuItem.Click
        Dim FentradaInventario As New ReporteEntradasInventario
        FentradaInventario.MdiParent = Me
        FentradaInventario.Show()
    End Sub



    Private Sub MantenimientoDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeClientesToolStripMenuItem.Click
        Dim FmantClientes As New frmMaestraClientes
        FmantClientes.MdiParent = Me
        FmantClientes.Show()
    End Sub

    Private Sub ReporteDeInventarioConExistenciaMinimaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeInventarioConExistenciaMinimaToolStripMenuItem.Click
        Try

            StrSql = "SELECT TOP 1 ID FROM INVENTARIO WHERE EXISTENCIA <= EXISTENCIA_MINIMA"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If Not objReader.HasRows Then
                objReader.Close()
                MsgBox("No hay productos que cumplan con esas condiciones", vbInformation)
                Return
            Else
                objReader.Close()
            End If

            Me.Cursor = Cursors.WaitCursor
            Dim Reporte As New Reportes
            Reporte.MdiParent = Me.MdiParent

            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            Rpt.Load(Application.StartupPath & "\rptInventarioExistMin.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")
            Rpt.RecordSelectionFormula = "{inventario.existencia} <= {inventario.existencia_minima}"
            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"

            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.MdiParent = Me
            Reporte.Show()
            Me.Cursor = Cursors.Default


        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub ReporteDeInventarioConExistenciaMenorQueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeInventarioConExistenciaMenorQueToolStripMenuItem.Click
        Dim FreporteMenorQue As New frmReporteInvMenorQue
        FreporteMenorQue.MdiParent = Me
        FreporteMenorQue.Show()
    End Sub

    Private Sub ReporteDeVentasBeneficiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentasBeneficiosToolStripMenuItem.Click
        Dim FreporteVentasB As New frmReporteVentasBeneficios
        FreporteVentasB.MdiParent = Me
        FreporteVentasB.Show()
    End Sub

    Private Sub ReporteDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentasToolStripMenuItem.Click
        If NivelUsuario <> 1 Then
            Dim fseg As New Seguridad
            fseg.ShowDialog()
            If Permitido = True Then
                Permitido = False
                Dim FreporteVentas As New ReporteVentas
                FreporteVentas.MdiParent = Me
                FreporteVentas.Show()
            End If
        Else
            Dim FreporteVentas As New ReporteVentas
            FreporteVentas.MdiParent = Me
            FreporteVentas.Show()
        End If

    End Sub

    Private Sub RegistrarFacturaComoRecibidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarFacturaComoRecibidaToolStripMenuItem.Click
        Dim Frecibida As New frmRecibida
        Frecibida.MdiParent = Me
        Frecibida.Show()
    End Sub

    Private Sub ReporteDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeClientesToolStripMenuItem.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim Reporte As New Reportes
            Reporte.MdiParent = Me.MdiParent

            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            Rpt.Load(Application.StartupPath & "\rptClientes.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")
            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"

            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.MdiParent = Me
            Reporte.Show()
            Me.Cursor = Cursors.Default


        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
    End Sub

    Private Sub ReImprimirFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReImprimirFacturaToolStripMenuItem.Click
        Dim Fprueba As New frmImprimir
        Fprueba.MdiParent = Me
        Fprueba.Show()
    End Sub

    Private Sub MantenimientoDeCondicionesAProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeCondicionesAProductosToolStripMenuItem.Click
        If NivelUsuario <> 1 Then
            Dim fseg As New Seguridad
            fseg.ShowDialog()
            If Permitido = True Then
                Permitido = False
                Fcondicion.MdiParent = Me
                Fcondicion.Show()
                Fcondicion.txtRef.Focus()
            End If
        Else
            Fcondicion.MdiParent = Me
            Fcondicion.Show()
            Fcondicion.txtRef.Focus()
        End If

    End Sub

    Private Sub GeneralesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralesToolStripMenuItem.Click
        Try

            Dim parametros As New Parametros
            parametros.Show()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub NCFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NCFToolStripMenuItem.Click
        Try

            Dim Fncf As New frmNCF
            Fncf.Show()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ReporteDeExistenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeExistenciaToolStripMenuItem.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim Reporte As New Reportes
            Reporte.MdiParent = Me.MdiParent

            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            Rpt.Load(Application.StartupPath & "\rptExistencia.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")
            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"

            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.MdiParent = Me
            Reporte.Show()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
    End Sub

    Private Sub CuadreDeCajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuadreDeCajaToolStripMenuItem.Click
        Dim FcuadreCaja As New ReporteCuadreCaja
        FcuadreCaja.MdiParent = Me
        FcuadreCaja.Show()
    End Sub

    Private Sub ReciboDeIngresosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReciboDeIngresosToolStripMenuItem.Click
        Dim Frecibo As New frmRecibo
        Frecibo.MdiParent = Me
        Frecibo.Show()
    End Sub

    Private Sub MantenimientoDeReciboDeIngresosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeReciboDeIngresosToolStripMenuItem.Click
        Dim FMantRecibo As New frmMantRecibo
        FMantRecibo.MdiParent = Me
        FMantRecibo.Show()
    End Sub

    Private Sub EstadoDeCuentasPorClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadoDeCuentasPorClientesToolStripMenuItem.Click
        Dim ReporteEstado As New frmReporteEstadoCuentas
        ReporteEstado.MdiParent = Me
        ReporteEstado.Show()
    End Sub

    Private Sub ReportesDeFacturasACréditoPorCobrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportesDeFacturasACréditoPorCobrarToolStripMenuItem.Click
        Try

            StrSql = "SELECT TOP 1 ID_FACTURA FROM FACTURA WHERE ESTADO ='Normal' AND CONDICION ='Crédito' AND PAGADA ='N'"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If Not objReader.HasRows Then
                objReader.Close()
                MsgBox("No hay Facturas a Crédito por pagar", vbInformation)
                Return
            Else
                objReader.Close()
            End If

            Me.Cursor = Cursors.WaitCursor
            Dim Reporte As New Reportes
            Reporte.MdiParent = Me.MdiParent

            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            Rpt.Load(Application.StartupPath & "\rptFacturasCredito.rpt")
            Rpt.SetDatabaseLogon("admin", "cladatos-ao")
            Rpt.RecordSelectionFormula = "{factura.estado} ='Normal' AND {factura.condicion} = 'Crédito' AND  {factura.pagada} ='N'"

            Reporte.CrystalReportViewer1.ReportSource = Rpt

            Rpt.DataDefinition.FormulaFields("EMPRESA").Text = "'" & Empresa & "'"

            Reporte.CrystalReportViewer1.RefreshReport()
            Reporte.MdiParent = Me
            Reporte.Show()
            Me.Cursor = Cursors.Default


        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
    End Sub

    Private Sub ReporteDeRecibosDeIngresosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeRecibosDeIngresosToolStripMenuItem.Click
        Dim ReporteRecibo As New frmReporteRecibos
        ReporteRecibo.MdiParent = Me
        ReporteRecibo.Show()
    End Sub

    Private Sub ReporteDeFacturasPorClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeFacturasPorClienteToolStripMenuItem.Click
        Dim ReporteFacturado As New frmReporteFacturasPorCliente
        ReporteFacturado.MdiParent = Me
        ReporteFacturado.Show()
    End Sub

    Private Sub ConsultarCostoPromedioInventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarCostoPromedioInventarioToolStripMenuItem.Click
        Dim ReporteFacturado As New frmConsultarCP
        ReporteFacturado.MdiParent = Me
        ReporteFacturado.Show()
    End Sub

    Private Sub MantenimientoDeEntradasDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeEntradasDeProductosToolStripMenuItem.Click
        Dim MantEntProductos As New frmMantEntradasProductos
        MantEntProductos.MdiParent = Me
        MantEntProductos.Show()
    End Sub

    Private Sub ReporteDeVentasPorFechaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentasPorFechaToolStripMenuItem.Click
        Dim RepVentas2 As New frmReporteVentas2
        RepVentas2.MdiParent = Me
        RepVentas2.Show()
    End Sub

    Private Sub EnviarReportesAlCorreoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarReportesAlCorreoToolStripMenuItem.Click
        Dim formEnviar As New frmEnviarCorreos
        formEnviar.MdiParent = Me
        formEnviar.Show()
    End Sub
End Class