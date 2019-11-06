<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtnumfactura = New System.Windows.Forms.TextBox()
        Me.txtcliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbcondicion = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtsubtotal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtitbis = New System.Windows.Forms.TextBox()
        Me.lbitbis = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtdescuento = New System.Windows.Forms.TextBox()
        Me.rtbcomentario = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtrnccliente = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtValida = New System.Windows.Forms.MaskedTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.rdb2 = New System.Windows.Forms.RadioButton()
        Me.rdb1 = New System.Windows.Forms.RadioButton()
        Me.txtnumcomprobante = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbestado = New System.Windows.Forms.Label()
        Me.lbusuarioquefacturo = New System.Windows.Forms.Label()
        Me.mtbfecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtporcientoitbis = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbComprobantes = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbIdComprobante = New System.Windows.Forms.ComboBox()
        Me.dgvfactura = New System.Windows.Forms.DataGridView()
        Me.cb1 = New System.Windows.Forms.CheckBox()
        Me.txtprecio = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtRef = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtDevuelta = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtRecibido = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtCosto = New System.Windows.Forms.TextBox()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.btbuscar = New System.Windows.Forms.Button()
        Me.btbuscarCotizacion = New System.Windows.Forms.Button()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.btnuevo = New System.Windows.Forms.Button()
        Me.bteliminar = New System.Windows.Forms.Button()
        Me.btagregar = New System.Windows.Forms.Button()
        Me.btinsertar = New System.Windows.Forms.Button()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.cmbCosto = New System.Windows.Forms.ComboBox()
        Me.cmbPrecio = New System.Windows.Forms.ComboBox()
        Me.cmbIdCondicion = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvfactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "# de Factura"
        '
        'txtnumfactura
        '
        Me.txtnumfactura.Location = New System.Drawing.Point(10, 22)
        Me.txtnumfactura.Name = "txtnumfactura"
        Me.txtnumfactura.ReadOnly = True
        Me.txtnumfactura.Size = New System.Drawing.Size(122, 20)
        Me.txtnumfactura.TabIndex = 0
        '
        'txtcliente
        '
        Me.txtcliente.Location = New System.Drawing.Point(146, 68)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.Size = New System.Drawing.Size(348, 20)
        Me.txtcliente.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(144, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(144, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Fecha"
        '
        'cmbcondicion
        '
        Me.cmbcondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcondicion.FormattingEnabled = True
        Me.cmbcondicion.Items.AddRange(New Object() {"Contado", "Crédito"})
        Me.cmbcondicion.Location = New System.Drawing.Point(228, 21)
        Me.cmbcondicion.Name = "cmbcondicion"
        Me.cmbcondicion.Size = New System.Drawing.Size(156, 21)
        Me.cmbcondicion.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(225, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Condición"
        '
        'txtsubtotal
        '
        Me.txtsubtotal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtsubtotal.Location = New System.Drawing.Point(728, 421)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.ReadOnly = True
        Me.txtsubtotal.Size = New System.Drawing.Size(100, 20)
        Me.txtsubtotal.TabIndex = 15
        Me.txtsubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(669, 424)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Sub-Total"
        '
        'txtitbis
        '
        Me.txtitbis.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtitbis.ForeColor = System.Drawing.Color.Red
        Me.txtitbis.Location = New System.Drawing.Point(728, 447)
        Me.txtitbis.Name = "txtitbis"
        Me.txtitbis.ReadOnly = True
        Me.txtitbis.Size = New System.Drawing.Size(100, 20)
        Me.txtitbis.TabIndex = 16
        Me.txtitbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbitbis
        '
        Me.lbitbis.AutoSize = True
        Me.lbitbis.Location = New System.Drawing.Point(605, 450)
        Me.lbitbis.Name = "lbitbis"
        Me.lbitbis.Size = New System.Drawing.Size(34, 13)
        Me.lbitbis.TabIndex = 39
        Me.lbitbis.Text = "ITBIS"
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.Location = New System.Drawing.Point(728, 501)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(100, 22)
        Me.txttotal.TabIndex = 18
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(691, 506)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Total"
        '
        'txtcantidad
        '
        Me.txtcantidad.BackColor = System.Drawing.Color.White
        Me.txtcantidad.Location = New System.Drawing.Point(762, 128)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(66, 20)
        Me.txtcantidad.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(664, 478)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "Descuento"
        '
        'txtdescuento
        '
        Me.txtdescuento.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtdescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescuento.Location = New System.Drawing.Point(728, 473)
        Me.txtdescuento.Name = "txtdescuento"
        Me.txtdescuento.Size = New System.Drawing.Size(100, 22)
        Me.txtdescuento.TabIndex = 17
        Me.txtdescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rtbcomentario
        '
        Me.rtbcomentario.Location = New System.Drawing.Point(12, 441)
        Me.rtbcomentario.Name = "rtbcomentario"
        Me.rtbcomentario.Size = New System.Drawing.Size(380, 57)
        Me.rtbcomentario.TabIndex = 19
        Me.rtbcomentario.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "RNC Cliente"
        '
        'txtrnccliente
        '
        Me.txtrnccliente.Location = New System.Drawing.Point(11, 68)
        Me.txtrnccliente.Name = "txtrnccliente"
        Me.txtrnccliente.ReadOnly = True
        Me.txtrnccliente.Size = New System.Drawing.Size(122, 20)
        Me.txtrnccliente.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtValida)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.rdb2)
        Me.GroupBox1.Controls.Add(Me.rdb1)
        Me.GroupBox1.Location = New System.Drawing.Point(508, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(187, 101)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Escoja una opción"
        '
        'txtValida
        '
        Me.txtValida.Enabled = False
        Me.txtValida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValida.Location = New System.Drawing.Point(83, 72)
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
        Me.Label16.Location = New System.Drawing.Point(7, 77)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 15)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Válida hasta"
        '
        'rdb2
        '
        Me.rdb2.AutoSize = True
        Me.rdb2.Location = New System.Drawing.Point(8, 47)
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
        'txtnumcomprobante
        '
        Me.txtnumcomprobante.Location = New System.Drawing.Point(34, 52)
        Me.txtnumcomprobante.Name = "txtnumcomprobante"
        Me.txtnumcomprobante.ReadOnly = True
        Me.txtnumcomprobante.Size = New System.Drawing.Size(174, 20)
        Me.txtnumcomprobante.TabIndex = 1
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(761, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 76
        Me.Label5.Text = "Cantidad"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 424)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Comentarios"
        '
        'lbestado
        '
        Me.lbestado.AutoSize = True
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.Red
        Me.lbestado.Location = New System.Drawing.Point(12, 381)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(149, 29)
        Me.lbestado.TabIndex = 104
        Me.lbestado.Text = "A n u l a d a"
        Me.lbestado.Visible = False
        '
        'lbusuarioquefacturo
        '
        Me.lbusuarioquefacturo.AutoSize = True
        Me.lbusuarioquefacturo.ForeColor = System.Drawing.Color.Red
        Me.lbusuarioquefacturo.Location = New System.Drawing.Point(11, 410)
        Me.lbusuarioquefacturo.Name = "lbusuarioquefacturo"
        Me.lbusuarioquefacturo.Size = New System.Drawing.Size(142, 13)
        Me.lbusuarioquefacturo.TabIndex = 111
        Me.lbusuarioquefacturo.Text = "Esta Factura fue hecha por: "
        Me.lbusuarioquefacturo.Visible = False
        '
        'mtbfecha
        '
        Me.mtbfecha.Location = New System.Drawing.Point(146, 22)
        Me.mtbfecha.Mask = "00/00/0000"
        Me.mtbfecha.Name = "mtbfecha"
        Me.mtbfecha.ReadOnly = True
        Me.mtbfecha.Size = New System.Drawing.Size(69, 20)
        Me.mtbfecha.TabIndex = 1
        Me.mtbfecha.ValidatingType = GetType(Date)
        '
        'txtporcientoitbis
        '
        Me.txtporcientoitbis.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtporcientoitbis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtporcientoitbis.Location = New System.Drawing.Point(672, 445)
        Me.txtporcientoitbis.Name = "txtporcientoitbis"
        Me.txtporcientoitbis.ReadOnly = True
        Me.txtporcientoitbis.Size = New System.Drawing.Size(50, 22)
        Me.txtporcientoitbis.TabIndex = 156
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(645, 448)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 16)
        Me.Label12.TabIndex = 157
        Me.Label12.Text = "%"
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbIdComprobante)
        Me.GroupBox2.Controls.Add(Me.cmbComprobantes)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtnumcomprobante)
        Me.GroupBox2.Location = New System.Drawing.Point(707, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(220, 83)
        Me.GroupBox2.TabIndex = 180
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
        'dgvfactura
        '
        Me.dgvfactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvfactura.Location = New System.Drawing.Point(13, 154)
        Me.dgvfactura.Name = "dgvfactura"
        Me.dgvfactura.ReadOnly = True
        Me.dgvfactura.Size = New System.Drawing.Size(815, 256)
        Me.dgvfactura.TabIndex = 20
        '
        'cb1
        '
        Me.cb1.AutoSize = True
        Me.cb1.Location = New System.Drawing.Point(587, 424)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(71, 17)
        Me.cb1.TabIndex = 182
        Me.cb1.Text = "Sin ITBIS"
        Me.cb1.UseVisualStyleBackColor = True
        '
        'txtprecio
        '
        Me.txtprecio.BackColor = System.Drawing.Color.White
        Me.txtprecio.Location = New System.Drawing.Point(662, 128)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.ReadOnly = True
        Me.txtprecio.Size = New System.Drawing.Size(91, 20)
        Me.txtprecio.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(659, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 75
        Me.Label10.Text = "Precio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(207, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 74
        Me.Label9.Text = "Descripción"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(10, 113)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 13)
        Me.Label18.TabIndex = 184
        Me.Label18.Text = "Referencia"
        '
        'txtRef
        '
        Me.txtRef.BackColor = System.Drawing.Color.White
        Me.txtRef.Location = New System.Drawing.Point(13, 128)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(187, 20)
        Me.txtRef.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(10, 96)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(163, 15)
        Me.Label17.TabIndex = 185
        Me.Label17.Text = "F2 para buscar producto"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(8, 505)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(135, 15)
        Me.Label19.TabIndex = 186
        Me.Label19.Text = "F5 Graba e Imprime"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtDevuelta)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.txtRecibido)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Location = New System.Drawing.Point(407, 413)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(143, 111)
        Me.GroupBox3.TabIndex = 187
        Me.GroupBox3.TabStop = False
        '
        'txtDevuelta
        '
        Me.txtDevuelta.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDevuelta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDevuelta.Location = New System.Drawing.Point(12, 78)
        Me.txtDevuelta.Name = "txtDevuelta"
        Me.txtDevuelta.Size = New System.Drawing.Size(122, 25)
        Me.txtDevuelta.TabIndex = 66
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(9, 60)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(70, 16)
        Me.Label21.TabIndex = 67
        Me.Label21.Text = "Devuelta"
        '
        'txtRecibido
        '
        Me.txtRecibido.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecibido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRecibido.Location = New System.Drawing.Point(10, 27)
        Me.txtRecibido.Name = "txtRecibido"
        Me.txtRecibido.Size = New System.Drawing.Size(122, 25)
        Me.txtRecibido.TabIndex = 64
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(6, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(131, 16)
        Me.Label20.TabIndex = 65
        Me.Label20.Text = "Efectivo Recibido"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(625, 172)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(34, 13)
        Me.Label22.TabIndex = 189
        Me.Label22.Text = "Costo"
        Me.Label22.Visible = False
        '
        'txtCosto
        '
        Me.txtCosto.BackColor = System.Drawing.Color.White
        Me.txtCosto.Location = New System.Drawing.Point(662, 168)
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.ReadOnly = True
        Me.txtCosto.Size = New System.Drawing.Size(91, 20)
        Me.txtCosto.TabIndex = 188
        Me.txtCosto.Visible = False
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.Color.White
        Me.txtIdCliente.Location = New System.Drawing.Point(274, 60)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(91, 20)
        Me.txtIdCliente.TabIndex = 191
        Me.txtIdCliente.Visible = False
        '
        'btbuscar
        '
        Me.btbuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btbuscar.Image = Global.FacturacionServicios.My.Resources.Resources.Clients
        Me.btbuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btbuscar.Location = New System.Drawing.Point(410, 12)
        Me.btbuscar.Name = "btbuscar"
        Me.btbuscar.Size = New System.Drawing.Size(84, 49)
        Me.btbuscar.TabIndex = 190
        Me.btbuscar.Text = "Buscar Cliente"
        Me.btbuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btbuscar.UseVisualStyleBackColor = True
        '
        'btbuscarCotizacion
        '
        Me.btbuscarCotizacion.Image = CType(resources.GetObject("btbuscarCotizacion.Image"), System.Drawing.Image)
        Me.btbuscarCotizacion.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btbuscarCotizacion.Location = New System.Drawing.Point(842, 291)
        Me.btbuscarCotizacion.Name = "btbuscarCotizacion"
        Me.btbuscarCotizacion.Size = New System.Drawing.Size(87, 51)
        Me.btbuscarCotizacion.TabIndex = 12
        Me.btbuscarCotizacion.Text = "Buscar Cotización para Factura"
        Me.btbuscarCotizacion.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btbuscarCotizacion.UseVisualStyleBackColor = True
        '
        'btsalir
        '
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btsalir.Image = Global.FacturacionServicios.My.Resources.Resources.Out
        Me.btsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsalir.Location = New System.Drawing.Point(842, 482)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(87, 41)
        Me.btsalir.TabIndex = 14
        Me.btsalir.Text = "Salir"
        Me.btsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btsalir.UseVisualStyleBackColor = True
        '
        'btnuevo
        '
        Me.btnuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnuevo.Image = Global.FacturacionServicios.My.Resources.Resources._New
        Me.btnuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnuevo.Location = New System.Drawing.Point(842, 224)
        Me.btnuevo.Name = "btnuevo"
        Me.btnuevo.Size = New System.Drawing.Size(87, 39)
        Me.btnuevo.TabIndex = 11
        Me.btnuevo.Text = "Nueva"
        Me.btnuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnuevo.UseVisualStyleBackColor = True
        '
        'bteliminar
        '
        Me.bteliminar.Image = Global.FacturacionServicios.My.Resources.Resources.Delete
        Me.bteliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bteliminar.Location = New System.Drawing.Point(842, 161)
        Me.bteliminar.Name = "bteliminar"
        Me.bteliminar.Size = New System.Drawing.Size(87, 38)
        Me.bteliminar.TabIndex = 10
        Me.bteliminar.Text = "Eliminar"
        Me.bteliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bteliminar.UseVisualStyleBackColor = True
        Me.bteliminar.Visible = False
        '
        'btagregar
        '
        Me.btagregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btagregar.Image = Global.FacturacionServicios.My.Resources.Resources.Plus
        Me.btagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btagregar.Location = New System.Drawing.Point(842, 106)
        Me.btagregar.Name = "btagregar"
        Me.btagregar.Size = New System.Drawing.Size(87, 41)
        Me.btagregar.TabIndex = 9
        Me.btagregar.Text = "Agregar"
        Me.btagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btagregar.UseVisualStyleBackColor = True
        '
        'btinsertar
        '
        Me.btinsertar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btinsertar.Image = Global.FacturacionServicios.My.Resources.Resources.Check
        Me.btinsertar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btinsertar.Location = New System.Drawing.Point(842, 369)
        Me.btinsertar.Name = "btinsertar"
        Me.btinsertar.Size = New System.Drawing.Size(87, 41)
        Me.btinsertar.TabIndex = 13
        Me.btinsertar.Text = "Grabar"
        Me.btinsertar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btinsertar.UseVisualStyleBackColor = True
        '
        'cmbProducto
        '
        Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(210, 128)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(440, 21)
        Me.cmbProducto.TabIndex = 6
        '
        'cmbCosto
        '
        Me.cmbCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCosto.FormattingEnabled = True
        Me.cmbCosto.Location = New System.Drawing.Point(428, 118)
        Me.cmbCosto.Name = "cmbCosto"
        Me.cmbCosto.Size = New System.Drawing.Size(90, 21)
        Me.cmbCosto.TabIndex = 192
        Me.cmbCosto.Visible = False
        '
        'cmbPrecio
        '
        Me.cmbPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrecio.FormattingEnabled = True
        Me.cmbPrecio.Location = New System.Drawing.Point(530, 118)
        Me.cmbPrecio.Name = "cmbPrecio"
        Me.cmbPrecio.Size = New System.Drawing.Size(74, 21)
        Me.cmbPrecio.TabIndex = 193
        Me.cmbPrecio.Visible = False
        '
        'cmbIdCondicion
        '
        Me.cmbIdCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdCondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdCondicion.FormattingEnabled = True
        Me.cmbIdCondicion.Location = New System.Drawing.Point(326, 118)
        Me.cmbIdCondicion.Name = "cmbIdCondicion"
        Me.cmbIdCondicion.Size = New System.Drawing.Size(90, 21)
        Me.cmbIdCondicion.TabIndex = 194
        Me.cmbIdCondicion.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(395, -3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(112, 15)
        Me.Label14.TabIndex = 195
        Me.Label14.Text = "F9 busca cliente"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(938, 528)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cmbIdCondicion)
        Me.Controls.Add(Me.cmbPrecio)
        Me.Controls.Add(Me.cmbCosto)
        Me.Controls.Add(Me.cmbProducto)
        Me.Controls.Add(Me.txtIdCliente)
        Me.Controls.Add(Me.btbuscar)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtCosto)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtRef)
        Me.Controls.Add(Me.cb1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btbuscarCotizacion)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtporcientoitbis)
        Me.Controls.Add(Me.mtbfecha)
        Me.Controls.Add(Me.btsalir)
        Me.Controls.Add(Me.btnuevo)
        Me.Controls.Add(Me.lbusuarioquefacturo)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtrnccliente)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.rtbcomentario)
        Me.Controls.Add(Me.cmbcondicion)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtdescuento)
        Me.Controls.Add(Me.bteliminar)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.btagregar)
        Me.Controls.Add(Me.btinsertar)
        Me.Controls.Add(Me.txtprecio)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crear Factura"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvfactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtnumfactura As System.Windows.Forms.TextBox
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbcondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtsubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtitbis As System.Windows.Forms.TextBox
    Friend WithEvents lbitbis As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btinsertar As System.Windows.Forms.Button
    Friend WithEvents btagregar As System.Windows.Forms.Button
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents bteliminar As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtdescuento As System.Windows.Forms.TextBox
    Friend WithEvents rtbcomentario As System.Windows.Forms.RichTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtrnccliente As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdb1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtnumcomprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As System.Windows.Forms.Label

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents lbusuarioquefacturo As System.Windows.Forms.Label
    Friend WithEvents btnuevo As System.Windows.Forms.Button
    Friend WithEvents btsalir As System.Windows.Forms.Button
    Friend WithEvents mtbfecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtporcientoitbis As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btbuscarCotizacion As Button
    Friend WithEvents rdb2 As RadioButton
    Friend WithEvents cmbComprobantes As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbIdComprobante As ComboBox
    Friend WithEvents dgvfactura As DataGridView
    Friend WithEvents cb1 As CheckBox
    Friend WithEvents txtValida As MaskedTextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtprecio As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtRef As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtDevuelta As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtRecibido As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtCosto As TextBox
    Friend WithEvents btbuscar As Button
    Friend WithEvents txtIdCliente As TextBox
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents cmbCosto As ComboBox
    Friend WithEvents cmbPrecio As ComboBox
    Friend WithEvents cmbIdCondicion As ComboBox
    Friend WithEvents Label14 As Label
End Class
