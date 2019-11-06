<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Cotizacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cotizacion))
        Me.rtbcomentario = New System.Windows.Forms.RichTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtdescuento = New System.Windows.Forms.TextBox()
        Me.bteliminar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.lbitbis = New System.Windows.Forms.Label()
        Me.txtitbis = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtsubtotal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcliente = New System.Windows.Forms.TextBox()
        Me.txtnumcotizacion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btagregar = New System.Windows.Forms.Button()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.btinsertar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.mtbfecha = New System.Windows.Forms.TextBox()
        Me.btnuevo = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtporcientoitbis = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtrnccliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb1 = New System.Windows.Forms.CheckBox()
        Me.dgvcotizacion = New System.Windows.Forms.DataGridView()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtRef = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.txtprecio = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btbuscar = New System.Windows.Forms.Button()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.cmbIdCondicion = New System.Windows.Forms.ComboBox()
        Me.cmbPrecio = New System.Windows.Forms.ComboBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        CType(Me.dgvcotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rtbcomentario
        '
        Me.rtbcomentario.Location = New System.Drawing.Point(9, 375)
        Me.rtbcomentario.Name = "rtbcomentario"
        Me.rtbcomentario.Size = New System.Drawing.Size(525, 57)
        Me.rtbcomentario.TabIndex = 14
        Me.rtbcomentario.Text = ""
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(662, 411)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 100
        Me.Label13.Text = "Descuento"
        '
        'txtdescuento
        '
        Me.txtdescuento.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtdescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescuento.Location = New System.Drawing.Point(724, 405)
        Me.txtdescuento.Name = "txtdescuento"
        Me.txtdescuento.Size = New System.Drawing.Size(100, 22)
        Me.txtdescuento.TabIndex = 99
        Me.txtdescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bteliminar
        '
        Me.bteliminar.Image = Global.FacturacionServicios.My.Resources.Resources.Delete
        Me.bteliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bteliminar.Location = New System.Drawing.Point(835, 114)
        Me.bteliminar.Name = "bteliminar"
        Me.bteliminar.Size = New System.Drawing.Size(87, 41)
        Me.bteliminar.TabIndex = 9
        Me.bteliminar.Text = "Eliminar"
        Me.bteliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bteliminar.UseVisualStyleBackColor = True
        Me.bteliminar.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(687, 438)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 87
        Me.Label8.Text = "Total"
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.Location = New System.Drawing.Point(724, 433)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(100, 22)
        Me.txttotal.TabIndex = 75
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbitbis
        '
        Me.lbitbis.AutoSize = True
        Me.lbitbis.Location = New System.Drawing.Point(643, 382)
        Me.lbitbis.Name = "lbitbis"
        Me.lbitbis.Size = New System.Drawing.Size(0, 13)
        Me.lbitbis.TabIndex = 86
        '
        'txtitbis
        '
        Me.txtitbis.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtitbis.ForeColor = System.Drawing.Color.Red
        Me.txtitbis.Location = New System.Drawing.Point(724, 379)
        Me.txtitbis.Name = "txtitbis"
        Me.txtitbis.ReadOnly = True
        Me.txtitbis.Size = New System.Drawing.Size(100, 20)
        Me.txtitbis.TabIndex = 74
        Me.txtitbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(665, 356)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Sub-Total"
        '
        'txtsubtotal
        '
        Me.txtsubtotal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtsubtotal.Location = New System.Drawing.Point(724, 353)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.ReadOnly = True
        Me.txtsubtotal.Size = New System.Drawing.Size(100, 20)
        Me.txtsubtotal.TabIndex = 73
        Me.txtsubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(109, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(309, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Cliente"
        '
        'txtcliente
        '
        Me.txtcliente.Location = New System.Drawing.Point(312, 20)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.Size = New System.Drawing.Size(512, 20)
        Me.txtcliente.TabIndex = 3
        '
        'txtnumcotizacion
        '
        Me.txtnumcotizacion.Location = New System.Drawing.Point(9, 20)
        Me.txtnumcotizacion.Name = "txtnumcotizacion"
        Me.txtnumcotizacion.ReadOnly = True
        Me.txtnumcotizacion.Size = New System.Drawing.Size(93, 20)
        Me.txtnumcotizacion.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "# de Cotizacion"
        '
        'btagregar
        '
        Me.btagregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btagregar.Image = Global.FacturacionServicios.My.Resources.Resources.Plus
        Me.btagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btagregar.Location = New System.Drawing.Point(835, 60)
        Me.btagregar.Name = "btagregar"
        Me.btagregar.Size = New System.Drawing.Size(87, 41)
        Me.btagregar.TabIndex = 8
        Me.btagregar.Text = "Agregar"
        Me.btagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btagregar.UseVisualStyleBackColor = True
        '
        'btsalir
        '
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btsalir.Image = Global.FacturacionServicios.My.Resources.Resources.Out
        Me.btsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsalir.Location = New System.Drawing.Point(835, 414)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(87, 41)
        Me.btsalir.TabIndex = 13
        Me.btsalir.Text = "Salir"
        Me.btsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btsalir.UseVisualStyleBackColor = True
        '
        'btinsertar
        '
        Me.btinsertar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btinsertar.Image = Global.FacturacionServicios.My.Resources.Resources.Check
        Me.btinsertar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btinsertar.Location = New System.Drawing.Point(835, 303)
        Me.btinsertar.Name = "btinsertar"
        Me.btinsertar.Size = New System.Drawing.Size(87, 41)
        Me.btinsertar.TabIndex = 12
        Me.btinsertar.Text = "Grabar"
        Me.btinsertar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btinsertar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 357)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 15)
        Me.Label7.TabIndex = 105
        Me.Label7.Text = "Comentarios"
        '
        'mtbfecha
        '
        Me.mtbfecha.Location = New System.Drawing.Point(112, 20)
        Me.mtbfecha.Name = "mtbfecha"
        Me.mtbfecha.ReadOnly = True
        Me.mtbfecha.Size = New System.Drawing.Size(82, 20)
        Me.mtbfecha.TabIndex = 1
        '
        'btnuevo
        '
        Me.btnuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnuevo.Image = Global.FacturacionServicios.My.Resources.Resources._New
        Me.btnuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnuevo.Location = New System.Drawing.Point(835, 206)
        Me.btnuevo.Name = "btnuevo"
        Me.btnuevo.Size = New System.Drawing.Size(87, 41)
        Me.btnuevo.TabIndex = 10
        Me.btnuevo.Text = "Nuevo"
        Me.btnuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnuevo.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(641, 380)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 16)
        Me.Label12.TabIndex = 160
        Me.Label12.Text = "%"
        '
        'txtporcientoitbis
        '
        Me.txtporcientoitbis.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtporcientoitbis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtporcientoitbis.Location = New System.Drawing.Point(668, 377)
        Me.txtporcientoitbis.Name = "txtporcientoitbis"
        Me.txtporcientoitbis.Size = New System.Drawing.Size(50, 22)
        Me.txtporcientoitbis.TabIndex = 159
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(601, 382)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 158
        Me.Label10.Text = "ITBIS"
        '
        'txtrnccliente
        '
        Me.txtrnccliente.Location = New System.Drawing.Point(204, 20)
        Me.txtrnccliente.MaxLength = 50
        Me.txtrnccliente.Name = "txtrnccliente"
        Me.txtrnccliente.ReadOnly = True
        Me.txtrnccliente.Size = New System.Drawing.Size(98, 20)
        Me.txtrnccliente.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(201, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 162
        Me.Label4.Text = "RNC Cliente"
        '
        'cb1
        '
        Me.cb1.AutoSize = True
        Me.cb1.Location = New System.Drawing.Point(580, 356)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(71, 17)
        Me.cb1.TabIndex = 183
        Me.cb1.Text = "Sin ITBIS"
        Me.cb1.UseVisualStyleBackColor = True
        '
        'dgvcotizacion
        '
        Me.dgvcotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvcotizacion.Location = New System.Drawing.Point(8, 106)
        Me.dgvcotizacion.Name = "dgvcotizacion"
        Me.dgvcotizacion.ReadOnly = True
        Me.dgvcotizacion.Size = New System.Drawing.Size(816, 238)
        Me.dgvcotizacion.TabIndex = 184
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(5, 47)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(163, 15)
        Me.Label17.TabIndex = 194
        Me.Label17.Text = "F2 para buscar producto"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(5, 65)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 13)
        Me.Label18.TabIndex = 193
        Me.Label18.Text = "Referencia"
        '
        'txtRef
        '
        Me.txtRef.BackColor = System.Drawing.Color.White
        Me.txtRef.Location = New System.Drawing.Point(8, 80)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(187, 20)
        Me.txtRef.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(756, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 192
        Me.Label5.Text = "Cantidad"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(654, 65)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 191
        Me.Label9.Text = "Precio"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(202, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 190
        Me.Label11.Text = "Descripción"
        '
        'txtcantidad
        '
        Me.txtcantidad.BackColor = System.Drawing.Color.White
        Me.txtcantidad.Location = New System.Drawing.Point(757, 80)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(66, 20)
        Me.txtcantidad.TabIndex = 7
        '
        'txtprecio
        '
        Me.txtprecio.BackColor = System.Drawing.Color.White
        Me.txtprecio.Location = New System.Drawing.Point(657, 80)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.ReadOnly = True
        Me.txtprecio.Size = New System.Drawing.Size(91, 20)
        Me.txtprecio.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(6, 439)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(135, 15)
        Me.Label19.TabIndex = 195
        Me.Label19.Text = "F5 Graba e Imprime"
        '
        'btbuscar
        '
        Me.btbuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btbuscar.Image = Global.FacturacionServicios.My.Resources.Resources.Clients
        Me.btbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btbuscar.Location = New System.Drawing.Point(835, 3)
        Me.btbuscar.Name = "btbuscar"
        Me.btbuscar.Size = New System.Drawing.Size(42, 39)
        Me.btbuscar.TabIndex = 196
        Me.btbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btbuscar.UseVisualStyleBackColor = True
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.Color.White
        Me.txtIdCliente.Location = New System.Drawing.Point(396, 0)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(91, 20)
        Me.txtIdCliente.TabIndex = 197
        Me.txtIdCliente.Visible = False
        '
        'cmbIdCondicion
        '
        Me.cmbIdCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdCondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdCondicion.FormattingEnabled = True
        Me.cmbIdCondicion.Location = New System.Drawing.Point(320, 70)
        Me.cmbIdCondicion.Name = "cmbIdCondicion"
        Me.cmbIdCondicion.Size = New System.Drawing.Size(90, 21)
        Me.cmbIdCondicion.TabIndex = 201
        Me.cmbIdCondicion.Visible = False
        '
        'cmbPrecio
        '
        Me.cmbPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrecio.FormattingEnabled = True
        Me.cmbPrecio.Location = New System.Drawing.Point(524, 70)
        Me.cmbPrecio.Name = "cmbPrecio"
        Me.cmbPrecio.Size = New System.Drawing.Size(74, 21)
        Me.cmbPrecio.TabIndex = 200
        Me.cmbPrecio.Visible = False
        '
        'cmbProducto
        '
        Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(204, 80)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(440, 21)
        Me.cmbProducto.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(682, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(145, 15)
        Me.Label14.TabIndex = 202
        Me.Label14.Text = "F9 para busca cliente"
        '
        'Cotizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 463)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cmbIdCondicion)
        Me.Controls.Add(Me.cmbPrecio)
        Me.Controls.Add(Me.cmbProducto)
        Me.Controls.Add(Me.txtIdCliente)
        Me.Controls.Add(Me.btbuscar)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtRef)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.txtprecio)
        Me.Controls.Add(Me.dgvcotizacion)
        Me.Controls.Add(Me.cb1)
        Me.Controls.Add(Me.txtrnccliente)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtporcientoitbis)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnuevo)
        Me.Controls.Add(Me.mtbfecha)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtcliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtnumcotizacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rtbcomentario)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtdescuento)
        Me.Controls.Add(Me.bteliminar)
        Me.Controls.Add(Me.btagregar)
        Me.Controls.Add(Me.btsalir)
        Me.Controls.Add(Me.btinsertar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.lbitbis)
        Me.Controls.Add(Me.txtitbis)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtsubtotal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "Cotizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cotización"
        CType(Me.dgvcotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtbcomentario As System.Windows.Forms.RichTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtdescuento As System.Windows.Forms.TextBox
    Friend WithEvents bteliminar As System.Windows.Forms.Button
    Friend WithEvents btagregar As System.Windows.Forms.Button
    Friend WithEvents btsalir As System.Windows.Forms.Button
    Friend WithEvents btinsertar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents lbitbis As System.Windows.Forms.Label
    Friend WithEvents txtitbis As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtsubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtnumcotizacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mtbfecha As System.Windows.Forms.TextBox
    Friend WithEvents btnuevo As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtporcientoitbis As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtrnccliente As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cb1 As CheckBox
    Friend WithEvents dgvcotizacion As DataGridView
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtRef As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtcantidad As TextBox
    Friend WithEvents txtprecio As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents btbuscar As Button
    Friend WithEvents txtIdCliente As TextBox
    Friend WithEvents cmbIdCondicion As ComboBox
    Friend WithEvents cmbPrecio As ComboBox
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents Label14 As Label
End Class
