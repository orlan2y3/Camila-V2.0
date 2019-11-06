<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantFacturas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantFacturas))
        Me.cb1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbIdComprobante = New System.Windows.Forms.ComboBox()
        Me.cmbComprobantes = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtnumcomprobante = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtporcientoitbis = New System.Windows.Forms.TextBox()
        Me.mtbfecha = New System.Windows.Forms.MaskedTextBox()
        Me.lbusuarioquefacturo = New System.Windows.Forms.Label()
        Me.lbestado = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtValida = New System.Windows.Forms.MaskedTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.rdb2 = New System.Windows.Forms.RadioButton()
        Me.rdb1 = New System.Windows.Forms.RadioButton()
        Me.txtrnccliente = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rtbcomentario = New System.Windows.Forms.RichTextBox()
        Me.cmbcondicion = New System.Windows.Forms.ComboBox()
        Me.txtdescuento = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.lbitbis = New System.Windows.Forms.Label()
        Me.txtitbis = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtsubtotal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcliente = New System.Windows.Forms.TextBox()
        Me.txtnumfactura = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvfactura = New System.Windows.Forms.DataGridView()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btprint = New System.Windows.Forms.Button()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.btinsertar = New System.Windows.Forms.Button()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.bteliminar = New System.Windows.Forms.Button()
        Me.btagregar = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtRef = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.txtprecio = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtCosto = New System.Windows.Forms.TextBox()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbIdCondicion = New System.Windows.Forms.ComboBox()
        Me.cmbPrecio = New System.Windows.Forms.ComboBox()
        Me.cmbCosto = New System.Windows.Forms.ComboBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btbuscar = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnOtra = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvfactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cb1
        '
        Me.cb1.AutoSize = True
        Me.cb1.Location = New System.Drawing.Point(585, 441)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(71, 17)
        Me.cb1.TabIndex = 225
        Me.cb1.Text = "Sin ITBIS"
        Me.cb1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbIdComprobante)
        Me.GroupBox2.Controls.Add(Me.cmbComprobantes)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtnumcomprobante)
        Me.GroupBox2.Location = New System.Drawing.Point(709, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(220, 83)
        Me.GroupBox2.TabIndex = 223
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccione el Tipo de Comprobante"
        '
        'cmbIdComprobante
        '
        Me.cmbIdComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdComprobante.FormattingEnabled = True
        Me.cmbIdComprobante.Location = New System.Drawing.Point(42, 18)
        Me.cmbIdComprobante.Name = "cmbIdComprobante"
        Me.cmbIdComprobante.Size = New System.Drawing.Size(73, 21)
        Me.cmbIdComprobante.TabIndex = 180
        Me.cmbIdComprobante.Visible = False
        '
        'cmbComprobantes
        '
        Me.cmbComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComprobantes.FormattingEnabled = True
        Me.cmbComprobantes.Location = New System.Drawing.Point(10, 20)
        Me.cmbComprobantes.Name = "cmbComprobantes"
        Me.cmbComprobantes.Size = New System.Drawing.Size(198, 23)
        Me.cmbComprobantes.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 13)
        Me.Label15.TabIndex = 72
        Me.Label15.Text = "No."
        '
        'txtnumcomprobante
        '
        Me.txtnumcomprobante.Location = New System.Drawing.Point(34, 52)
        Me.txtnumcomprobante.Name = "txtnumcomprobante"
        Me.txtnumcomprobante.ReadOnly = True
        Me.txtnumcomprobante.Size = New System.Drawing.Size(174, 20)
        Me.txtnumcomprobante.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(643, 465)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 16)
        Me.Label12.TabIndex = 222
        Me.Label12.Text = "%"
        '
        'txtporcientoitbis
        '
        Me.txtporcientoitbis.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtporcientoitbis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtporcientoitbis.Location = New System.Drawing.Point(670, 462)
        Me.txtporcientoitbis.Name = "txtporcientoitbis"
        Me.txtporcientoitbis.ReadOnly = True
        Me.txtporcientoitbis.Size = New System.Drawing.Size(50, 22)
        Me.txtporcientoitbis.TabIndex = 221
        '
        'mtbfecha
        '
        Me.mtbfecha.Location = New System.Drawing.Point(181, 20)
        Me.mtbfecha.Mask = "00/00/0000"
        Me.mtbfecha.Name = "mtbfecha"
        Me.mtbfecha.ReadOnly = True
        Me.mtbfecha.Size = New System.Drawing.Size(69, 20)
        Me.mtbfecha.TabIndex = 184
        Me.mtbfecha.ValidatingType = GetType(Date)
        '
        'lbusuarioquefacturo
        '
        Me.lbusuarioquefacturo.AutoSize = True
        Me.lbusuarioquefacturo.ForeColor = System.Drawing.Color.Red
        Me.lbusuarioquefacturo.Location = New System.Drawing.Point(81, 439)
        Me.lbusuarioquefacturo.Name = "lbusuarioquefacturo"
        Me.lbusuarioquefacturo.Size = New System.Drawing.Size(142, 13)
        Me.lbusuarioquefacturo.TabIndex = 220
        Me.lbusuarioquefacturo.Text = "Esta Factura fue hecha por: "
        Me.lbusuarioquefacturo.Visible = False
        '
        'lbestado
        '
        Me.lbestado.AutoSize = True
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.Red
        Me.lbestado.Location = New System.Drawing.Point(10, 403)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(149, 29)
        Me.lbestado.TabIndex = 219
        Me.lbestado.Text = "A n u l a d a"
        Me.lbestado.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 439)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 218
        Me.Label11.Text = "Comentarios"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtValida)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.rdb2)
        Me.GroupBox1.Controls.Add(Me.rdb1)
        Me.GroupBox1.Location = New System.Drawing.Point(513, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(187, 103)
        Me.GroupBox1.TabIndex = 214
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Escoja una opción"
        '
        'txtValida
        '
        Me.txtValida.Enabled = False
        Me.txtValida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValida.Location = New System.Drawing.Point(83, 73)
        Me.txtValida.Mask = "##/##/####"
        Me.txtValida.Name = "txtValida"
        Me.txtValida.Size = New System.Drawing.Size(74, 21)
        Me.txtValida.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Enabled = False
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(7, 78)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 15)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Válida hasta"
        '
        'rdb2
        '
        Me.rdb2.AutoSize = True
        Me.rdb2.Location = New System.Drawing.Point(8, 48)
        Me.rdb2.Name = "rdb2"
        Me.rdb2.Size = New System.Drawing.Size(110, 17)
        Me.rdb2.TabIndex = 1
        Me.rdb2.TabStop = True
        Me.rdb2.Text = "Con Comprobante"
        Me.rdb2.UseVisualStyleBackColor = True
        '
        'rdb1
        '
        Me.rdb1.AutoSize = True
        Me.rdb1.Location = New System.Drawing.Point(8, 19)
        Me.rdb1.Name = "rdb1"
        Me.rdb1.Size = New System.Drawing.Size(175, 17)
        Me.rdb1.TabIndex = 0
        Me.rdb1.TabStop = True
        Me.rdb1.Text = "Factura Sin Comprobante Fiscal"
        Me.rdb1.UseVisualStyleBackColor = True
        '
        'txtrnccliente
        '
        Me.txtrnccliente.Location = New System.Drawing.Point(9, 69)
        Me.txtrnccliente.Name = "txtrnccliente"
        Me.txtrnccliente.ReadOnly = True
        Me.txtrnccliente.Size = New System.Drawing.Size(122, 20)
        Me.txtrnccliente.TabIndex = 186
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 213
        Me.Label7.Text = "RNC Cliente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(260, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 204
        Me.Label4.Text = "Condición"
        '
        'rtbcomentario
        '
        Me.rtbcomentario.Location = New System.Drawing.Point(10, 455)
        Me.rtbcomentario.Name = "rtbcomentario"
        Me.rtbcomentario.Size = New System.Drawing.Size(514, 65)
        Me.rtbcomentario.TabIndex = 10
        Me.rtbcomentario.Text = ""
        '
        'cmbcondicion
        '
        Me.cmbcondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcondicion.FormattingEnabled = True
        Me.cmbcondicion.Items.AddRange(New Object() {"Contado", "Crédito"})
        Me.cmbcondicion.Location = New System.Drawing.Point(261, 19)
        Me.cmbcondicion.Name = "cmbcondicion"
        Me.cmbcondicion.Size = New System.Drawing.Size(149, 21)
        Me.cmbcondicion.TabIndex = 185
        '
        'txtdescuento
        '
        Me.txtdescuento.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtdescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescuento.Location = New System.Drawing.Point(726, 490)
        Me.txtdescuento.Name = "txtdescuento"
        Me.txtdescuento.Size = New System.Drawing.Size(100, 22)
        Me.txtdescuento.TabIndex = 208
        Me.txtdescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(689, 523)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 207
        Me.Label8.Text = "Total"
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.Location = New System.Drawing.Point(726, 518)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(100, 22)
        Me.txttotal.TabIndex = 200
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbitbis
        '
        Me.lbitbis.AutoSize = True
        Me.lbitbis.Location = New System.Drawing.Point(603, 467)
        Me.lbitbis.Name = "lbitbis"
        Me.lbitbis.Size = New System.Drawing.Size(34, 13)
        Me.lbitbis.TabIndex = 206
        Me.lbitbis.Text = "ITBIS"
        '
        'txtitbis
        '
        Me.txtitbis.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtitbis.ForeColor = System.Drawing.Color.Red
        Me.txtitbis.Location = New System.Drawing.Point(726, 464)
        Me.txtitbis.Name = "txtitbis"
        Me.txtitbis.ReadOnly = True
        Me.txtitbis.Size = New System.Drawing.Size(100, 20)
        Me.txtitbis.TabIndex = 199
        Me.txtitbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(667, 441)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 205
        Me.Label6.Text = "Sub-Total"
        '
        'txtsubtotal
        '
        Me.txtsubtotal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtsubtotal.Location = New System.Drawing.Point(726, 438)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.ReadOnly = True
        Me.txtsubtotal.Size = New System.Drawing.Size(100, 20)
        Me.txtsubtotal.TabIndex = 198
        Me.txtsubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(179, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 203
        Me.Label3.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(142, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 202
        Me.Label2.Text = "Cliente"
        '
        'txtcliente
        '
        Me.txtcliente.Location = New System.Drawing.Point(144, 69)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.Size = New System.Drawing.Size(350, 20)
        Me.txtcliente.TabIndex = 187
        '
        'txtnumfactura
        '
        Me.txtnumfactura.Location = New System.Drawing.Point(10, 21)
        Me.txtnumfactura.Name = "txtnumfactura"
        Me.txtnumfactura.ReadOnly = True
        Me.txtnumfactura.Size = New System.Drawing.Size(96, 20)
        Me.txtnumfactura.TabIndex = 183
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 201
        Me.Label1.Text = "# de Factura"
        '
        'dgvfactura
        '
        Me.dgvfactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvfactura.Location = New System.Drawing.Point(11, 155)
        Me.dgvfactura.Name = "dgvfactura"
        Me.dgvfactura.ReadOnly = True
        Me.dgvfactura.Size = New System.Drawing.Size(815, 276)
        Me.dgvfactura.TabIndex = 11
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.Honeydew
        Me.btnBuscar.Image = Global.FacturacionServicios.My.Resources.Resources.Search
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(114, -1)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(52, 50)
        Me.btnBuscar.TabIndex = 229
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'btprint
        '
        Me.btprint.BackColor = System.Drawing.Color.Honeydew
        Me.btprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btprint.Image = Global.FacturacionServicios.My.Resources.Resources.Print2
        Me.btprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btprint.Location = New System.Drawing.Point(844, 293)
        Me.btprint.Name = "btprint"
        Me.btprint.Size = New System.Drawing.Size(87, 41)
        Me.btprint.TabIndex = 7
        Me.btprint.Text = "Imprimir"
        Me.btprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btprint.UseVisualStyleBackColor = False
        '
        'btnAnular
        '
        Me.btnAnular.BackColor = System.Drawing.Color.Honeydew
        Me.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAnular.Image = Global.FacturacionServicios.My.Resources.Resources.cancel
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnular.Location = New System.Drawing.Point(844, 216)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(87, 41)
        Me.btnAnular.TabIndex = 6
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnular.UseVisualStyleBackColor = False
        '
        'btinsertar
        '
        Me.btinsertar.BackColor = System.Drawing.Color.Honeydew
        Me.btinsertar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btinsertar.Image = Global.FacturacionServicios.My.Resources.Resources.Check
        Me.btinsertar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btinsertar.Location = New System.Drawing.Point(844, 438)
        Me.btinsertar.Name = "btinsertar"
        Me.btinsertar.Size = New System.Drawing.Size(87, 41)
        Me.btinsertar.TabIndex = 8
        Me.btinsertar.Text = "Actualizar"
        Me.btinsertar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btinsertar.UseVisualStyleBackColor = False
        '
        'btsalir
        '
        Me.btsalir.BackColor = System.Drawing.Color.Honeydew
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btsalir.Image = Global.FacturacionServicios.My.Resources.Resources.Out
        Me.btsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsalir.Location = New System.Drawing.Point(843, 499)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(87, 41)
        Me.btsalir.TabIndex = 9
        Me.btsalir.Text = "Salir"
        Me.btsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btsalir.UseVisualStyleBackColor = False
        '
        'bteliminar
        '
        Me.bteliminar.BackColor = System.Drawing.Color.Honeydew
        Me.bteliminar.Image = Global.FacturacionServicios.My.Resources.Resources.Delete
        Me.bteliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bteliminar.Location = New System.Drawing.Point(843, 164)
        Me.bteliminar.Name = "bteliminar"
        Me.bteliminar.Size = New System.Drawing.Size(87, 41)
        Me.bteliminar.TabIndex = 5
        Me.bteliminar.Text = "Eliminar"
        Me.bteliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bteliminar.UseVisualStyleBackColor = False
        Me.bteliminar.Visible = False
        '
        'btagregar
        '
        Me.btagregar.BackColor = System.Drawing.Color.Honeydew
        Me.btagregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btagregar.Image = Global.FacturacionServicios.My.Resources.Resources.Plus
        Me.btagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btagregar.Location = New System.Drawing.Point(843, 112)
        Me.btagregar.Name = "btagregar"
        Me.btagregar.Size = New System.Drawing.Size(87, 41)
        Me.btagregar.TabIndex = 4
        Me.btagregar.Text = "Agregar"
        Me.btagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btagregar.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 111)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 13)
        Me.Label18.TabIndex = 237
        Me.Label18.Text = "Referencia"
        '
        'txtRef
        '
        Me.txtRef.BackColor = System.Drawing.Color.White
        Me.txtRef.Location = New System.Drawing.Point(11, 126)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(187, 20)
        Me.txtRef.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(759, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 236
        Me.Label5.Text = "Cantidad"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(657, 111)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 235
        Me.Label10.Text = "Precio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(205, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 234
        Me.Label9.Text = "Descripción"
        '
        'txtcantidad
        '
        Me.txtcantidad.BackColor = System.Drawing.Color.White
        Me.txtcantidad.Location = New System.Drawing.Point(760, 126)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(66, 20)
        Me.txtcantidad.TabIndex = 3
        '
        'txtprecio
        '
        Me.txtprecio.BackColor = System.Drawing.Color.White
        Me.txtprecio.Location = New System.Drawing.Point(660, 126)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.Size = New System.Drawing.Size(91, 20)
        Me.txtprecio.TabIndex = 2
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(625, 182)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(34, 13)
        Me.Label22.TabIndex = 239
        Me.Label22.Text = "Costo"
        Me.Label22.Visible = False
        '
        'txtCosto
        '
        Me.txtCosto.BackColor = System.Drawing.Color.White
        Me.txtCosto.Location = New System.Drawing.Point(662, 178)
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.ReadOnly = True
        Me.txtCosto.Size = New System.Drawing.Size(91, 20)
        Me.txtCosto.TabIndex = 238
        Me.txtCosto.Visible = False
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.Color.White
        Me.txtIdCliente.Location = New System.Drawing.Point(312, 64)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(91, 20)
        Me.txtIdCliente.TabIndex = 240
        Me.txtIdCliente.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(662, 496)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 209
        Me.Label13.Text = "Descuento"
        '
        'cmbIdCondicion
        '
        Me.cmbIdCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdCondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdCondicion.FormattingEnabled = True
        Me.cmbIdCondicion.Location = New System.Drawing.Point(322, 116)
        Me.cmbIdCondicion.Name = "cmbIdCondicion"
        Me.cmbIdCondicion.Size = New System.Drawing.Size(90, 21)
        Me.cmbIdCondicion.TabIndex = 244
        Me.cmbIdCondicion.Visible = False
        '
        'cmbPrecio
        '
        Me.cmbPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrecio.FormattingEnabled = True
        Me.cmbPrecio.Location = New System.Drawing.Point(526, 116)
        Me.cmbPrecio.Name = "cmbPrecio"
        Me.cmbPrecio.Size = New System.Drawing.Size(74, 21)
        Me.cmbPrecio.TabIndex = 243
        Me.cmbPrecio.Visible = False
        '
        'cmbCosto
        '
        Me.cmbCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCosto.FormattingEnabled = True
        Me.cmbCosto.Location = New System.Drawing.Point(424, 116)
        Me.cmbCosto.Name = "cmbCosto"
        Me.cmbCosto.Size = New System.Drawing.Size(90, 21)
        Me.cmbCosto.TabIndex = 242
        Me.cmbCosto.Visible = False
        '
        'cmbProducto
        '
        Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(208, 126)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(440, 21)
        Me.cmbProducto.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(373, -3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(145, 15)
        Me.Label14.TabIndex = 245
        Me.Label14.Text = "F9 para busca cliente"
        '
        'btbuscar
        '
        Me.btbuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btbuscar.Image = Global.FacturacionServicios.My.Resources.Resources.Clients
        Me.btbuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btbuscar.Location = New System.Drawing.Point(418, 14)
        Me.btbuscar.Name = "btbuscar"
        Me.btbuscar.Size = New System.Drawing.Size(86, 50)
        Me.btbuscar.TabIndex = 246
        Me.btbuscar.Text = "Buscar Cliente"
        Me.btbuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btbuscar.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(8, 93)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(163, 15)
        Me.Label17.TabIndex = 247
        Me.Label17.Text = "F2 para buscar producto"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(6, 526)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(66, 15)
        Me.Label19.TabIndex = 248
        Me.Label19.Text = "F5 Graba"
        '
        'btnOtra
        '
        Me.btnOtra.BackColor = System.Drawing.Color.Honeydew
        Me.btnOtra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnOtra.Image = Global.FacturacionServicios.My.Resources.Resources.Buscar6
        Me.btnOtra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOtra.Location = New System.Drawing.Point(844, 354)
        Me.btnOtra.Name = "btnOtra"
        Me.btnOtra.Size = New System.Drawing.Size(88, 43)
        Me.btnOtra.TabIndex = 249
        Me.btnOtra.Text = "Buscar Otra"
        Me.btnOtra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOtra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOtra.UseVisualStyleBackColor = False
        '
        'frmMantFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FloralWhite
        Me.ClientSize = New System.Drawing.Size(940, 548)
        Me.Controls.Add(Me.btnOtra)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btbuscar)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cmbIdCondicion)
        Me.Controls.Add(Me.cmbPrecio)
        Me.Controls.Add(Me.cmbCosto)
        Me.Controls.Add(Me.cmbProducto)
        Me.Controls.Add(Me.txtIdCliente)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtCosto)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtRef)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.txtprecio)
        Me.Controls.Add(Me.btprint)
        Me.Controls.Add(Me.btnAnular)
        Me.Controls.Add(Me.btinsertar)
        Me.Controls.Add(Me.cb1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtporcientoitbis)
        Me.Controls.Add(Me.mtbfecha)
        Me.Controls.Add(Me.btsalir)
        Me.Controls.Add(Me.lbusuarioquefacturo)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtrnccliente)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.rtbcomentario)
        Me.Controls.Add(Me.cmbcondicion)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtdescuento)
        Me.Controls.Add(Me.bteliminar)
        Me.Controls.Add(Me.btagregar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.lbitbis)
        Me.Controls.Add(Me.txtitbis)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtsubtotal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtcliente)
        Me.Controls.Add(Me.txtnumfactura)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvfactura)
        Me.Controls.Add(Me.btnBuscar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMantFacturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Facturas"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvfactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cb1 As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbIdComprobante As ComboBox
    Friend WithEvents cmbComprobantes As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtnumcomprobante As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtporcientoitbis As TextBox
    Friend WithEvents mtbfecha As MaskedTextBox
    Friend WithEvents btsalir As Button
    Friend WithEvents lbusuarioquefacturo As Label
    Friend WithEvents lbestado As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtValida As MaskedTextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents rdb2 As RadioButton
    Friend WithEvents rdb1 As RadioButton
    Friend WithEvents txtrnccliente As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents rtbcomentario As RichTextBox
    Friend WithEvents cmbcondicion As ComboBox
    Friend WithEvents txtdescuento As TextBox
    Friend WithEvents bteliminar As Button
    Friend WithEvents btagregar As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txttotal As TextBox
    Friend WithEvents lbitbis As Label
    Friend WithEvents txtitbis As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtsubtotal As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtcliente As TextBox
    Friend WithEvents txtnumfactura As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvfactura As DataGridView
    Friend WithEvents btprint As Button
    Friend WithEvents btnAnular As Button
    Friend WithEvents btinsertar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents txtRef As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtcantidad As TextBox
    Friend WithEvents txtprecio As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtCosto As TextBox
    Friend WithEvents txtIdCliente As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cmbIdCondicion As ComboBox
    Friend WithEvents cmbPrecio As ComboBox
    Friend WithEvents cmbCosto As ComboBox
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btbuscar As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents btnOtra As Button
End Class
