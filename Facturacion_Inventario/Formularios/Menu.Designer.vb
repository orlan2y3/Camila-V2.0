<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CotizaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculadoraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssfecha = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsshora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssusuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip3 = New System.Windows.Forms.MenuStrip()
        Me.FuncionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CotizacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EntradaDeProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.RegistrarFacturaComoRecibidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReImprimirFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConsultarCostoPromedioInventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoDeFacturasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoDeCotizacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MantenimientoDeProductosEnInventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoDeEntradasDeProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.MantenimientoDeClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoDeUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator()
        Me.MantenimientoDeCondicionesAProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuentasXCobrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReciboDeIngresosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoDeCuentasPorClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripSeparator()
        Me.MantenimientoDeReciboDeIngresosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesDeFacturasACréditoPorCobrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeRecibosDeIngresosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeFacturasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeFacturasPorClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeCotizaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReporteDeProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeExistenciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReporteDeInventarioConExistenciaMinimaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeInventarioConExistenciaMenorQueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReporteDeEntradasAlInventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CuadreDeCajaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReporteDeVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeVentasPorFechaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeVentasBeneficiosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReporteDeClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripSeparator()
        Me.EnviarReportesAlCorreoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguraciónToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParámetrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneralesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NCFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatosEmpresaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NosotrosToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirDelSistemaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'FacturaToolStripMenuItem
        '
        Me.FacturaToolStripMenuItem.Name = "FacturaToolStripMenuItem"
        Me.FacturaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FacturaToolStripMenuItem.Text = "Facturar"
        '
        'CotizaciónToolStripMenuItem
        '
        Me.CotizaciónToolStripMenuItem.Name = "CotizaciónToolStripMenuItem"
        Me.CotizaciónToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CotizaciónToolStripMenuItem.Text = "Cotización"
        '
        'CalculadoraToolStripMenuItem
        '
        Me.CalculadoraToolStripMenuItem.Name = "CalculadoraToolStripMenuItem"
        Me.CalculadoraToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CalculadoraToolStripMenuItem.Text = "Calculadora"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssfecha, Me.tsshora, Me.tssusuario})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 528)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(907, 24)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssfecha
        '
        Me.tssfecha.Name = "tssfecha"
        Me.tssfecha.Size = New System.Drawing.Size(54, 19)
        Me.tssfecha.Text = "Fecha"
        '
        'tsshora
        '
        Me.tsshora.Name = "tsshora"
        Me.tsshora.Size = New System.Drawing.Size(45, 19)
        Me.tsshora.Text = "Hora"
        '
        'tssusuario
        '
        Me.tssusuario.Name = "tssusuario"
        Me.tssusuario.Size = New System.Drawing.Size(72, 19)
        Me.tssusuario.Text = "Usuario"
        '
        'MenuStrip3
        '
        Me.MenuStrip3.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FuncionesToolStripMenuItem, Me.MantenimientoToolStripMenuItem, Me.CuentasXCobrarToolStripMenuItem, Me.ReportesToolStripMenuItem1, Me.ConfiguraciónToolStripMenuItem1, Me.AcercaDeToolStripMenuItem2, Me.SalirToolStripMenuItem})
        Me.MenuStrip3.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip3.Name = "MenuStrip3"
        Me.MenuStrip3.Size = New System.Drawing.Size(907, 27)
        Me.MenuStrip3.TabIndex = 5
        Me.MenuStrip3.Text = "MenuStrip3"
        '
        'FuncionesToolStripMenuItem
        '
        Me.FuncionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacturacionToolStripMenuItem, Me.CotizacionToolStripMenuItem, Me.ToolStripMenuItem1, Me.EntradaDeProductosToolStripMenuItem, Me.ToolStripMenuItem8, Me.RegistrarFacturaComoRecibidaToolStripMenuItem, Me.ReImprimirFacturaToolStripMenuItem, Me.ToolStripMenuItem13, Me.ConsultarCostoPromedioInventarioToolStripMenuItem})
        Me.FuncionesToolStripMenuItem.Image = Global.FacturacionServicios.My.Resources.Resources.Invoice
        Me.FuncionesToolStripMenuItem.Name = "FuncionesToolStripMenuItem"
        Me.FuncionesToolStripMenuItem.Size = New System.Drawing.Size(118, 23)
        Me.FuncionesToolStripMenuItem.Text = "Funciones"
        '
        'FacturacionToolStripMenuItem
        '
        Me.FacturacionToolStripMenuItem.Name = "FacturacionToolStripMenuItem"
        Me.FacturacionToolStripMenuItem.Size = New System.Drawing.Size(393, 24)
        Me.FacturacionToolStripMenuItem.Text = "Facturación"
        '
        'CotizacionToolStripMenuItem
        '
        Me.CotizacionToolStripMenuItem.Name = "CotizacionToolStripMenuItem"
        Me.CotizacionToolStripMenuItem.Size = New System.Drawing.Size(393, 24)
        Me.CotizacionToolStripMenuItem.Text = "Cotización"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(390, 6)
        '
        'EntradaDeProductosToolStripMenuItem
        '
        Me.EntradaDeProductosToolStripMenuItem.Name = "EntradaDeProductosToolStripMenuItem"
        Me.EntradaDeProductosToolStripMenuItem.Size = New System.Drawing.Size(393, 24)
        Me.EntradaDeProductosToolStripMenuItem.Text = "Entrada de Productos"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(390, 6)
        '
        'RegistrarFacturaComoRecibidaToolStripMenuItem
        '
        Me.RegistrarFacturaComoRecibidaToolStripMenuItem.Name = "RegistrarFacturaComoRecibidaToolStripMenuItem"
        Me.RegistrarFacturaComoRecibidaToolStripMenuItem.Size = New System.Drawing.Size(393, 24)
        Me.RegistrarFacturaComoRecibidaToolStripMenuItem.Text = "Registrar Facturas como Recibida"
        '
        'ReImprimirFacturaToolStripMenuItem
        '
        Me.ReImprimirFacturaToolStripMenuItem.Name = "ReImprimirFacturaToolStripMenuItem"
        Me.ReImprimirFacturaToolStripMenuItem.Size = New System.Drawing.Size(393, 24)
        Me.ReImprimirFacturaToolStripMenuItem.Text = "Re Imprimir Factura"
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(390, 6)
        '
        'ConsultarCostoPromedioInventarioToolStripMenuItem
        '
        Me.ConsultarCostoPromedioInventarioToolStripMenuItem.Name = "ConsultarCostoPromedioInventarioToolStripMenuItem"
        Me.ConsultarCostoPromedioInventarioToolStripMenuItem.Size = New System.Drawing.Size(393, 24)
        Me.ConsultarCostoPromedioInventarioToolStripMenuItem.Text = "Consultar Costo Promedio Inventario"
        '
        'MantenimientoToolStripMenuItem
        '
        Me.MantenimientoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MantenimientoDeFacturasToolStripMenuItem, Me.MantenimientoDeCotizacionesToolStripMenuItem, Me.ToolStripMenuItem2, Me.MantenimientoDeProductosEnInventarioToolStripMenuItem, Me.MantenimientoDeEntradasDeProductosToolStripMenuItem, Me.ToolStripMenuItem5, Me.MantenimientoDeClientesToolStripMenuItem, Me.MantenimientoDeUsuariosToolStripMenuItem, Me.ToolStripMenuItem10, Me.MantenimientoDeCondicionesAProductosToolStripMenuItem})
        Me.MantenimientoToolStripMenuItem.Image = Global.FacturacionServicios.My.Resources.Resources.maintenance
        Me.MantenimientoToolStripMenuItem.Name = "MantenimientoToolStripMenuItem"
        Me.MantenimientoToolStripMenuItem.Size = New System.Drawing.Size(154, 23)
        Me.MantenimientoToolStripMenuItem.Text = "Mantenimiento"
        '
        'MantenimientoDeFacturasToolStripMenuItem
        '
        Me.MantenimientoDeFacturasToolStripMenuItem.Name = "MantenimientoDeFacturasToolStripMenuItem"
        Me.MantenimientoDeFacturasToolStripMenuItem.Size = New System.Drawing.Size(438, 24)
        Me.MantenimientoDeFacturasToolStripMenuItem.Text = "Mantenimiento de Facturas"
        '
        'MantenimientoDeCotizacionesToolStripMenuItem
        '
        Me.MantenimientoDeCotizacionesToolStripMenuItem.Name = "MantenimientoDeCotizacionesToolStripMenuItem"
        Me.MantenimientoDeCotizacionesToolStripMenuItem.Size = New System.Drawing.Size(438, 24)
        Me.MantenimientoDeCotizacionesToolStripMenuItem.Text = "Mantenimiento de Cotizaciones"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(435, 6)
        '
        'MantenimientoDeProductosEnInventarioToolStripMenuItem
        '
        Me.MantenimientoDeProductosEnInventarioToolStripMenuItem.Name = "MantenimientoDeProductosEnInventarioToolStripMenuItem"
        Me.MantenimientoDeProductosEnInventarioToolStripMenuItem.Size = New System.Drawing.Size(438, 24)
        Me.MantenimientoDeProductosEnInventarioToolStripMenuItem.Text = "Mantenimiento de Productos en Inventario"
        '
        'MantenimientoDeEntradasDeProductosToolStripMenuItem
        '
        Me.MantenimientoDeEntradasDeProductosToolStripMenuItem.Name = "MantenimientoDeEntradasDeProductosToolStripMenuItem"
        Me.MantenimientoDeEntradasDeProductosToolStripMenuItem.Size = New System.Drawing.Size(438, 24)
        Me.MantenimientoDeEntradasDeProductosToolStripMenuItem.Text = "Mantenimiento de Entradas de Productos"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(435, 6)
        '
        'MantenimientoDeClientesToolStripMenuItem
        '
        Me.MantenimientoDeClientesToolStripMenuItem.Name = "MantenimientoDeClientesToolStripMenuItem"
        Me.MantenimientoDeClientesToolStripMenuItem.Size = New System.Drawing.Size(438, 24)
        Me.MantenimientoDeClientesToolStripMenuItem.Text = "Mantenimiento de Clientes"
        '
        'MantenimientoDeUsuariosToolStripMenuItem
        '
        Me.MantenimientoDeUsuariosToolStripMenuItem.Name = "MantenimientoDeUsuariosToolStripMenuItem"
        Me.MantenimientoDeUsuariosToolStripMenuItem.Size = New System.Drawing.Size(438, 24)
        Me.MantenimientoDeUsuariosToolStripMenuItem.Text = "Mantenimiento de Usuarios"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(435, 6)
        '
        'MantenimientoDeCondicionesAProductosToolStripMenuItem
        '
        Me.MantenimientoDeCondicionesAProductosToolStripMenuItem.Name = "MantenimientoDeCondicionesAProductosToolStripMenuItem"
        Me.MantenimientoDeCondicionesAProductosToolStripMenuItem.Size = New System.Drawing.Size(438, 24)
        Me.MantenimientoDeCondicionesAProductosToolStripMenuItem.Text = "Mantenimiento de Condiciones a Productos"
        '
        'CuentasXCobrarToolStripMenuItem
        '
        Me.CuentasXCobrarToolStripMenuItem.Checked = True
        Me.CuentasXCobrarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CuentasXCobrarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReciboDeIngresosToolStripMenuItem, Me.EstadoDeCuentasPorClientesToolStripMenuItem, Me.ToolStripMenuItem12, Me.MantenimientoDeReciboDeIngresosToolStripMenuItem, Me.ReportesDeFacturasACréditoPorCobrarToolStripMenuItem, Me.ReporteDeRecibosDeIngresosToolStripMenuItem})
        Me.CuentasXCobrarToolStripMenuItem.Image = Global.FacturacionServicios.My.Resources.Resources.note_edit
        Me.CuentasXCobrarToolStripMenuItem.Name = "CuentasXCobrarToolStripMenuItem"
        Me.CuentasXCobrarToolStripMenuItem.Size = New System.Drawing.Size(181, 23)
        Me.CuentasXCobrarToolStripMenuItem.Text = "Cuentas x Cobrar"
        '
        'ReciboDeIngresosToolStripMenuItem
        '
        Me.ReciboDeIngresosToolStripMenuItem.Name = "ReciboDeIngresosToolStripMenuItem"
        Me.ReciboDeIngresosToolStripMenuItem.Size = New System.Drawing.Size(447, 24)
        Me.ReciboDeIngresosToolStripMenuItem.Text = "Recibo de Ingresos"
        '
        'EstadoDeCuentasPorClientesToolStripMenuItem
        '
        Me.EstadoDeCuentasPorClientesToolStripMenuItem.Name = "EstadoDeCuentasPorClientesToolStripMenuItem"
        Me.EstadoDeCuentasPorClientesToolStripMenuItem.Size = New System.Drawing.Size(447, 24)
        Me.EstadoDeCuentasPorClientesToolStripMenuItem.Text = "Estado de Cuentas por Clientes"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(444, 6)
        '
        'MantenimientoDeReciboDeIngresosToolStripMenuItem
        '
        Me.MantenimientoDeReciboDeIngresosToolStripMenuItem.Name = "MantenimientoDeReciboDeIngresosToolStripMenuItem"
        Me.MantenimientoDeReciboDeIngresosToolStripMenuItem.Size = New System.Drawing.Size(447, 24)
        Me.MantenimientoDeReciboDeIngresosToolStripMenuItem.Text = "Mantenimiento de Recibo de Ingresos"
        '
        'ReportesDeFacturasACréditoPorCobrarToolStripMenuItem
        '
        Me.ReportesDeFacturasACréditoPorCobrarToolStripMenuItem.Name = "ReportesDeFacturasACréditoPorCobrarToolStripMenuItem"
        Me.ReportesDeFacturasACréditoPorCobrarToolStripMenuItem.Size = New System.Drawing.Size(447, 24)
        Me.ReportesDeFacturasACréditoPorCobrarToolStripMenuItem.Text = "Reportes de Facturas a Crédito por Cobrar"
        '
        'ReporteDeRecibosDeIngresosToolStripMenuItem
        '
        Me.ReporteDeRecibosDeIngresosToolStripMenuItem.Name = "ReporteDeRecibosDeIngresosToolStripMenuItem"
        Me.ReporteDeRecibosDeIngresosToolStripMenuItem.Size = New System.Drawing.Size(447, 24)
        Me.ReporteDeRecibosDeIngresosToolStripMenuItem.Text = "Reporte de Recibos de Ingresos"
        '
        'ReportesToolStripMenuItem1
        '
        Me.ReportesToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReporteDeFacturasToolStripMenuItem, Me.ReporteDeFacturasPorClienteToolStripMenuItem, Me.ReporteDeCotizaciónToolStripMenuItem, Me.ToolStripMenuItem3, Me.ReporteDeProductosToolStripMenuItem, Me.ReporteDeExistenciaToolStripMenuItem, Me.ToolStripMenuItem6, Me.ReporteDeInventarioConExistenciaMinimaToolStripMenuItem, Me.ReporteDeInventarioConExistenciaMenorQueToolStripMenuItem, Me.ToolStripMenuItem7, Me.ReporteDeEntradasAlInventarioToolStripMenuItem, Me.ToolStripMenuItem4, Me.CuadreDeCajaToolStripMenuItem, Me.ToolStripMenuItem11, Me.ReporteDeVentasToolStripMenuItem, Me.ReporteDeVentasPorFechaToolStripMenuItem, Me.ReporteDeVentasBeneficiosToolStripMenuItem, Me.ToolStripMenuItem9, Me.ReporteDeClientesToolStripMenuItem, Me.ToolStripMenuItem14, Me.EnviarReportesAlCorreoToolStripMenuItem})
        Me.ReportesToolStripMenuItem1.Image = Global.FacturacionServicios.My.Resources.Resources.Reports
        Me.ReportesToolStripMenuItem1.Name = "ReportesToolStripMenuItem1"
        Me.ReportesToolStripMenuItem1.Size = New System.Drawing.Size(109, 23)
        Me.ReportesToolStripMenuItem1.Text = "Reportes"
        '
        'ReporteDeFacturasToolStripMenuItem
        '
        Me.ReporteDeFacturasToolStripMenuItem.Name = "ReporteDeFacturasToolStripMenuItem"
        Me.ReporteDeFacturasToolStripMenuItem.Size = New System.Drawing.Size(555, 24)
        Me.ReporteDeFacturasToolStripMenuItem.Text = "Reporte de Facturas"
        '
        'ReporteDeFacturasPorClienteToolStripMenuItem
        '
        Me.ReporteDeFacturasPorClienteToolStripMenuItem.Name = "ReporteDeFacturasPorClienteToolStripMenuItem"
        Me.ReporteDeFacturasPorClienteToolStripMenuItem.Size = New System.Drawing.Size(555, 24)
        Me.ReporteDeFacturasPorClienteToolStripMenuItem.Text = "Reporte de Facturas por Cliente"
        '
        'ReporteDeCotizaciónToolStripMenuItem
        '
        Me.ReporteDeCotizaciónToolStripMenuItem.Name = "ReporteDeCotizaciónToolStripMenuItem"
        Me.ReporteDeCotizaciónToolStripMenuItem.Size = New System.Drawing.Size(555, 24)
        Me.ReporteDeCotizaciónToolStripMenuItem.Text = "Reporte de Cotización"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(552, 6)
        '
        'ReporteDeProductosToolStripMenuItem
        '
        Me.ReporteDeProductosToolStripMenuItem.Name = "ReporteDeProductosToolStripMenuItem"
        Me.ReporteDeProductosToolStripMenuItem.Size = New System.Drawing.Size(555, 24)
        Me.ReporteDeProductosToolStripMenuItem.Text = "Reporte de Inventario"
        '
        'ReporteDeExistenciaToolStripMenuItem
        '
        Me.ReporteDeExistenciaToolStripMenuItem.Name = "ReporteDeExistenciaToolStripMenuItem"
        Me.ReporteDeExistenciaToolStripMenuItem.Size = New System.Drawing.Size(555, 24)
        Me.ReporteDeExistenciaToolStripMenuItem.Text = "Reporte de Existencia"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(552, 6)
        '
        'ReporteDeInventarioConExistenciaMinimaToolStripMenuItem
        '
        Me.ReporteDeInventarioConExistenciaMinimaToolStripMenuItem.Name = "ReporteDeInventarioConExistenciaMinimaToolStripMenuItem"
        Me.ReporteDeInventarioConExistenciaMinimaToolStripMenuItem.Size = New System.Drawing.Size(555, 24)
        Me.ReporteDeInventarioConExistenciaMinimaToolStripMenuItem.Text = "Reporte de Inventario con Existencia Minima"
        '
        'ReporteDeInventarioConExistenciaMenorQueToolStripMenuItem
        '
        Me.ReporteDeInventarioConExistenciaMenorQueToolStripMenuItem.Name = "ReporteDeInventarioConExistenciaMenorQueToolStripMenuItem"
        Me.ReporteDeInventarioConExistenciaMenorQueToolStripMenuItem.Size = New System.Drawing.Size(555, 24)
        Me.ReporteDeInventarioConExistenciaMenorQueToolStripMenuItem.Text = "Reporte de Inventario con Existencia Menor o Igual a:"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(552, 6)
        '
        'ReporteDeEntradasAlInventarioToolStripMenuItem
        '
        Me.ReporteDeEntradasAlInventarioToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ReporteDeEntradasAlInventarioToolStripMenuItem.Name = "ReporteDeEntradasAlInventarioToolStripMenuItem"
        Me.ReporteDeEntradasAlInventarioToolStripMenuItem.Size = New System.Drawing.Size(555, 24)
        Me.ReporteDeEntradasAlInventarioToolStripMenuItem.Text = "Reporte de Entradas al Inventario"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(552, 6)
        '
        'CuadreDeCajaToolStripMenuItem
        '
        Me.CuadreDeCajaToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CuadreDeCajaToolStripMenuItem.Name = "CuadreDeCajaToolStripMenuItem"
        Me.CuadreDeCajaToolStripMenuItem.Size = New System.Drawing.Size(555, 24)
        Me.CuadreDeCajaToolStripMenuItem.Text = "Reporte de Cuadre de Caja"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(552, 6)
        '
        'ReporteDeVentasToolStripMenuItem
        '
        Me.ReporteDeVentasToolStripMenuItem.Name = "ReporteDeVentasToolStripMenuItem"
        Me.ReporteDeVentasToolStripMenuItem.Size = New System.Drawing.Size(555, 24)
        Me.ReporteDeVentasToolStripMenuItem.Text = "Reporte de Ventas"
        '
        'ReporteDeVentasPorFechaToolStripMenuItem
        '
        Me.ReporteDeVentasPorFechaToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ReporteDeVentasPorFechaToolStripMenuItem.Name = "ReporteDeVentasPorFechaToolStripMenuItem"
        Me.ReporteDeVentasPorFechaToolStripMenuItem.Size = New System.Drawing.Size(555, 24)
        Me.ReporteDeVentasPorFechaToolStripMenuItem.Text = "Reporte de Ventas por Producto"
        '
        'ReporteDeVentasBeneficiosToolStripMenuItem
        '
        Me.ReporteDeVentasBeneficiosToolStripMenuItem.Name = "ReporteDeVentasBeneficiosToolStripMenuItem"
        Me.ReporteDeVentasBeneficiosToolStripMenuItem.Size = New System.Drawing.Size(555, 24)
        Me.ReporteDeVentasBeneficiosToolStripMenuItem.Text = "Reporte de Ventas - Beneficios"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(552, 6)
        '
        'ReporteDeClientesToolStripMenuItem
        '
        Me.ReporteDeClientesToolStripMenuItem.Name = "ReporteDeClientesToolStripMenuItem"
        Me.ReporteDeClientesToolStripMenuItem.Size = New System.Drawing.Size(555, 24)
        Me.ReporteDeClientesToolStripMenuItem.Text = "Reporte de Clientes"
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(552, 6)
        '
        'EnviarReportesAlCorreoToolStripMenuItem
        '
        Me.EnviarReportesAlCorreoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.EnviarReportesAlCorreoToolStripMenuItem.Name = "EnviarReportesAlCorreoToolStripMenuItem"
        Me.EnviarReportesAlCorreoToolStripMenuItem.Size = New System.Drawing.Size(555, 24)
        Me.EnviarReportesAlCorreoToolStripMenuItem.Text = "Enviar Reporte de Ventas Detallado por Correo"
        '
        'ConfiguraciónToolStripMenuItem1
        '
        Me.ConfiguraciónToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParámetrosToolStripMenuItem, Me.DatosEmpresaToolStripMenuItem})
        Me.ConfiguraciónToolStripMenuItem1.Image = Global.FacturacionServicios.My.Resources.Resources.configuration1
        Me.ConfiguraciónToolStripMenuItem1.Name = "ConfiguraciónToolStripMenuItem1"
        Me.ConfiguraciónToolStripMenuItem1.Size = New System.Drawing.Size(154, 23)
        Me.ConfiguraciónToolStripMenuItem1.Text = "Configuración"
        '
        'ParámetrosToolStripMenuItem
        '
        Me.ParámetrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneralesToolStripMenuItem, Me.NCFToolStripMenuItem})
        Me.ParámetrosToolStripMenuItem.Name = "ParámetrosToolStripMenuItem"
        Me.ParámetrosToolStripMenuItem.Size = New System.Drawing.Size(195, 24)
        Me.ParámetrosToolStripMenuItem.Text = "Parámetros"
        '
        'GeneralesToolStripMenuItem
        '
        Me.GeneralesToolStripMenuItem.Name = "GeneralesToolStripMenuItem"
        Me.GeneralesToolStripMenuItem.Size = New System.Drawing.Size(159, 24)
        Me.GeneralesToolStripMenuItem.Text = "Generales"
        '
        'NCFToolStripMenuItem
        '
        Me.NCFToolStripMenuItem.Name = "NCFToolStripMenuItem"
        Me.NCFToolStripMenuItem.Size = New System.Drawing.Size(159, 24)
        Me.NCFToolStripMenuItem.Text = "NCF"
        '
        'DatosEmpresaToolStripMenuItem
        '
        Me.DatosEmpresaToolStripMenuItem.Name = "DatosEmpresaToolStripMenuItem"
        Me.DatosEmpresaToolStripMenuItem.Size = New System.Drawing.Size(195, 24)
        Me.DatosEmpresaToolStripMenuItem.Text = "Datos empresa"
        '
        'AcercaDeToolStripMenuItem2
        '
        Me.AcercaDeToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NosotrosToolStripMenuItem2})
        Me.AcercaDeToolStripMenuItem2.Image = Global.FacturacionServicios.My.Resources.Resources.About1
        Me.AcercaDeToolStripMenuItem2.Name = "AcercaDeToolStripMenuItem2"
        Me.AcercaDeToolStripMenuItem2.Size = New System.Drawing.Size(118, 23)
        Me.AcercaDeToolStripMenuItem2.Text = "Acerca de"
        '
        'NosotrosToolStripMenuItem2
        '
        Me.NosotrosToolStripMenuItem2.Name = "NosotrosToolStripMenuItem2"
        Me.NosotrosToolStripMenuItem2.Size = New System.Drawing.Size(150, 24)
        Me.NosotrosToolStripMenuItem2.Text = "Nosotros"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirDelSistemaToolStripMenuItem1})
        Me.SalirToolStripMenuItem.Image = Global.FacturacionServicios.My.Resources.Resources.Out
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(82, 23)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'SalirDelSistemaToolStripMenuItem1
        '
        Me.SalirDelSistemaToolStripMenuItem1.Name = "SalirDelSistemaToolStripMenuItem1"
        Me.SalirDelSistemaToolStripMenuItem1.Size = New System.Drawing.Size(231, 24)
        Me.SalirDelSistemaToolStripMenuItem1.Text = "Salir del Sistema"
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(907, 552)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip3)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "C A M I L A  V.2.0 - Facturación e Inventario - Menú Principal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip3.ResumeLayout(False)
        Me.MenuStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CotizaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CalculadoraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents MenuStrip3 As MenuStrip
    Friend WithEvents FuncionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturacionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CotizacionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReporteDeFacturasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeCotizaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfiguraciónToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ParámetrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NosotrosToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents SalirDelSistemaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents tssfecha As ToolStripStatusLabel
    Friend WithEvents tsshora As ToolStripStatusLabel
    Friend WithEvents tssusuario As ToolStripStatusLabel
    Friend WithEvents DatosEmpresaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MantenimientoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MantenimientoDeUsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents EntradaDeProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MantenimientoDeProductosEnInventarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MantenimientoDeFacturasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents MantenimientoDeCotizacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents ReporteDeProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeEntradasAlInventarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents MantenimientoDeClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
    Friend WithEvents ReporteDeVentasToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReporteDeInventarioConExistenciaMinimaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeInventarioConExistenciaMenorQueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem7 As ToolStripSeparator
    Friend WithEvents ReporteDeVentasBeneficiosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As ToolStripSeparator
    Friend WithEvents RegistrarFacturaComoRecibidaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As ToolStripSeparator
    Friend WithEvents ReporteDeClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReImprimirFacturaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As ToolStripSeparator
    Friend WithEvents MantenimientoDeCondicionesAProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeneralesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NCFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeExistenciaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CuadreDeCajaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As ToolStripSeparator
    Friend WithEvents CuentasXCobrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReciboDeIngresosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstadoDeCuentasPorClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As ToolStripSeparator
    Friend WithEvents MantenimientoDeReciboDeIngresosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesDeFacturasACréditoPorCobrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeRecibosDeIngresosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeFacturasPorClienteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As ToolStripSeparator
    Friend WithEvents ConsultarCostoPromedioInventarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MantenimientoDeEntradasDeProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeVentasPorFechaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem14 As ToolStripSeparator
    Friend WithEvents EnviarReportesAlCorreoToolStripMenuItem As ToolStripMenuItem
End Class
