<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantCotizacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantCotizacion))
        Me.dgvcotizacion = New System.Windows.Forms.DataGridView()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtporcientoitbis = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.mtbfecha = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtcliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtnumcotizacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rtbcomentario = New System.Windows.Forms.RichTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtdescuento = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.lbitbis = New System.Windows.Forms.Label()
        Me.txtitbis = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtsubtotal = New System.Windows.Forms.TextBox()
        Me.bteliminar = New System.Windows.Forms.Button()
        Me.btagregar = New System.Windows.Forms.Button()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.btinsertar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lbestado = New System.Windows.Forms.Label()
        Me.lbusuarioquefacturo = New System.Windows.Forms.Label()
        Me.cb1 = New System.Windows.Forms.CheckBox()
        Me.btanular = New System.Windows.Forms.Button()
        Me.btprint = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtRef = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.txtprecio = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.cmbIdCondicion = New System.Windows.Forms.ComboBox()
        Me.cmbPrecio = New System.Windows.Forms.ComboBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.btnOtra = New System.Windows.Forms.Button()
        CType(Me.dgvcotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvcotizacion
        '
        Me.dgvcotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvcotizacion.Location = New System.Drawing.Point(9, 113)
        Me.dgvcotizacion.Name = "dgvcotizacion"
        Me.dgvcotizacion.ReadOnly = True
        Me.dgvcotizacion.Size = New System.Drawing.Size(815, 235)
        Me.dgvcotizacion.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(640, 389)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 16)
        Me.Label12.TabIndex = 194
        Me.Label12.Text = "%"
        '
        'txtporcientoitbis
        '
        Me.txtporcientoitbis.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtporcientoitbis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtporcientoitbis.Location = New System.Drawing.Point(667, 386)
        Me.txtporcientoitbis.Name = "txtporcientoitbis"
        Me.txtporcientoitbis.Size = New System.Drawing.Size(50, 22)
        Me.txtporcientoitbis.TabIndex = 193
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(600, 391)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 192
        Me.Label10.Text = "ITBIS"
        '
        'mtbfecha
        '
        Me.mtbfecha.Location = New System.Drawing.Point(659, 22)
        Me.mtbfecha.Name = "mtbfecha"
        Me.mtbfecha.ReadOnly = True
        Me.mtbfecha.Size = New System.Drawing.Size(69, 20)
        Me.mtbfecha.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 352)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 191
        Me.Label7.Text = "Comentarios"
        '
        'txtcliente
        '
        Me.txtcliente.Location = New System.Drawing.Point(181, 22)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.Size = New System.Drawing.Size(467, 20)
        Me.txtcliente.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 178
        Me.Label1.Text = "# de Cotizacion"
        '
        'txtnumcotizacion
        '
        Me.txtnumcotizacion.Location = New System.Drawing.Point(10, 22)
        Me.txtnumcotizacion.Name = "txtnumcotizacion"
        Me.txtnumcotizacion.ReadOnly = True
        Me.txtnumcotizacion.Size = New System.Drawing.Size(73, 20)
        Me.txtnumcotizacion.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(179, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = "Cliente"
        '
        'rtbcomentario
        '
        Me.rtbcomentario.Location = New System.Drawing.Point(10, 365)
        Me.rtbcomentario.Name = "rtbcomentario"
        Me.rtbcomentario.Size = New System.Drawing.Size(538, 63)
        Me.rtbcomentario.TabIndex = 14
        Me.rtbcomentario.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(656, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "Fecha"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(660, 420)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 188
        Me.Label13.Text = "Descuento"
        '
        'txtdescuento
        '
        Me.txtdescuento.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtdescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescuento.Location = New System.Drawing.Point(723, 414)
        Me.txtdescuento.Name = "txtdescuento"
        Me.txtdescuento.Size = New System.Drawing.Size(100, 22)
        Me.txtdescuento.TabIndex = 187
        Me.txtdescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(686, 447)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 184
        Me.Label8.Text = "Total"
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.Location = New System.Drawing.Point(723, 442)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(100, 22)
        Me.txttotal.TabIndex = 177
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbitbis
        '
        Me.lbitbis.AutoSize = True
        Me.lbitbis.Location = New System.Drawing.Point(642, 391)
        Me.lbitbis.Name = "lbitbis"
        Me.lbitbis.Size = New System.Drawing.Size(0, 13)
        Me.lbitbis.TabIndex = 183
        '
        'txtitbis
        '
        Me.txtitbis.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtitbis.ForeColor = System.Drawing.Color.Red
        Me.txtitbis.Location = New System.Drawing.Point(723, 388)
        Me.txtitbis.Name = "txtitbis"
        Me.txtitbis.ReadOnly = True
        Me.txtitbis.Size = New System.Drawing.Size(100, 20)
        Me.txtitbis.TabIndex = 176
        Me.txtitbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(664, 365)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 182
        Me.Label6.Text = "Sub-Total"
        '
        'txtsubtotal
        '
        Me.txtsubtotal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtsubtotal.Location = New System.Drawing.Point(723, 362)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.ReadOnly = True
        Me.txtsubtotal.Size = New System.Drawing.Size(100, 20)
        Me.txtsubtotal.TabIndex = 175
        Me.txtsubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bteliminar
        '
        Me.bteliminar.Image = Global.FacturacionServicios.My.Resources.Resources.Delete
        Me.bteliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bteliminar.Location = New System.Drawing.Point(839, 126)
        Me.bteliminar.Name = "bteliminar"
        Me.bteliminar.Size = New System.Drawing.Size(99, 41)
        Me.bteliminar.TabIndex = 8
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
        Me.btagregar.Location = New System.Drawing.Point(839, 74)
        Me.btagregar.Name = "btagregar"
        Me.btagregar.Size = New System.Drawing.Size(99, 41)
        Me.btagregar.TabIndex = 7
        Me.btagregar.Text = "Agregar"
        Me.btagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btagregar.UseVisualStyleBackColor = True
        '
        'btsalir
        '
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btsalir.Image = Global.FacturacionServicios.My.Resources.Resources.Out
        Me.btsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsalir.Location = New System.Drawing.Point(839, 423)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(99, 41)
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
        Me.btinsertar.Location = New System.Drawing.Point(839, 361)
        Me.btinsertar.Name = "btinsertar"
        Me.btinsertar.Size = New System.Drawing.Size(99, 41)
        Me.btinsertar.TabIndex = 12
        Me.btinsertar.Text = "Actualizar"
        Me.btinsertar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btinsertar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.Honeydew
        Me.btnBuscar.Image = Global.FacturacionServicios.My.Resources.Resources.Search
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(94, 0)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(52, 50)
        Me.btnBuscar.TabIndex = 230
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'lbestado
        '
        Me.lbestado.AutoSize = True
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.Red
        Me.lbestado.Location = New System.Drawing.Point(9, 319)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(149, 29)
        Me.lbestado.TabIndex = 231
        Me.lbestado.Text = "A n u l a d a"
        Me.lbestado.Visible = False
        '
        'lbusuarioquefacturo
        '
        Me.lbusuarioquefacturo.AutoSize = True
        Me.lbusuarioquefacturo.ForeColor = System.Drawing.Color.Red
        Me.lbusuarioquefacturo.Location = New System.Drawing.Point(7, 456)
        Me.lbusuarioquefacturo.Name = "lbusuarioquefacturo"
        Me.lbusuarioquefacturo.Size = New System.Drawing.Size(155, 13)
        Me.lbusuarioquefacturo.TabIndex = 232
        Me.lbusuarioquefacturo.Text = "Esta Cotizacion fue hecha por: "
        '
        'cb1
        '
        Me.cb1.AutoSize = True
        Me.cb1.Location = New System.Drawing.Point(576, 362)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(71, 17)
        Me.cb1.TabIndex = 233
        Me.cb1.Text = "Sin ITBIS"
        Me.cb1.UseVisualStyleBackColor = True
        '
        'btanular
        '
        Me.btanular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btanular.Image = Global.FacturacionServicios.My.Resources.Resources.cancel
        Me.btanular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btanular.Location = New System.Drawing.Point(839, 178)
        Me.btanular.Name = "btanular"
        Me.btanular.Size = New System.Drawing.Size(99, 41)
        Me.btanular.TabIndex = 10
        Me.btanular.Text = "Anular"
        Me.btanular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btanular.UseVisualStyleBackColor = True
        '
        'btprint
        '
        Me.btprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btprint.Image = Global.FacturacionServicios.My.Resources.Resources.Print2
        Me.btprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btprint.Location = New System.Drawing.Point(839, 239)
        Me.btprint.Name = "btprint"
        Me.btprint.Size = New System.Drawing.Size(99, 41)
        Me.btprint.TabIndex = 11
        Me.btprint.Text = "Imprimir"
        Me.btprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btprint.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(6, 54)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(163, 15)
        Me.Label17.TabIndex = 244
        Me.Label17.Text = "F2 para buscar producto"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 72)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 13)
        Me.Label18.TabIndex = 243
        Me.Label18.Text = "Referencia"
        '
        'txtRef
        '
        Me.txtRef.BackColor = System.Drawing.Color.White
        Me.txtRef.Location = New System.Drawing.Point(9, 87)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(187, 20)
        Me.txtRef.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(757, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 242
        Me.Label5.Text = "Cantidad"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(655, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 241
        Me.Label9.Text = "Precio"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(203, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 240
        Me.Label11.Text = "Descripción"
        '
        'txtcantidad
        '
        Me.txtcantidad.BackColor = System.Drawing.Color.White
        Me.txtcantidad.Location = New System.Drawing.Point(758, 87)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(66, 20)
        Me.txtcantidad.TabIndex = 6
        '
        'txtprecio
        '
        Me.txtprecio.BackColor = System.Drawing.Color.White
        Me.txtprecio.Location = New System.Drawing.Point(658, 87)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.ReadOnly = True
        Me.txtprecio.Size = New System.Drawing.Size(91, 20)
        Me.txtprecio.TabIndex = 5
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(6, 435)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(135, 15)
        Me.Label19.TabIndex = 245
        Me.Label19.Text = "F5 Graba e Imprime"
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.Color.White
        Me.txtIdCliente.Location = New System.Drawing.Point(254, 4)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(91, 20)
        Me.txtIdCliente.TabIndex = 246
        Me.txtIdCliente.Visible = False
        '
        'cmbIdCondicion
        '
        Me.cmbIdCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdCondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdCondicion.FormattingEnabled = True
        Me.cmbIdCondicion.Location = New System.Drawing.Point(322, 76)
        Me.cmbIdCondicion.Name = "cmbIdCondicion"
        Me.cmbIdCondicion.Size = New System.Drawing.Size(90, 21)
        Me.cmbIdCondicion.TabIndex = 249
        Me.cmbIdCondicion.Visible = False
        '
        'cmbPrecio
        '
        Me.cmbPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrecio.FormattingEnabled = True
        Me.cmbPrecio.Location = New System.Drawing.Point(526, 76)
        Me.cmbPrecio.Name = "cmbPrecio"
        Me.cmbPrecio.Size = New System.Drawing.Size(74, 21)
        Me.cmbPrecio.TabIndex = 248
        Me.cmbPrecio.Visible = False
        '
        'cmbProducto
        '
        Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(206, 86)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(440, 21)
        Me.cmbProducto.TabIndex = 4
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBuscarCliente.Image = Global.FacturacionServicios.My.Resources.Resources.Clients
        Me.btnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarCliente.Location = New System.Drawing.Point(759, 4)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(42, 39)
        Me.btnBuscarCliente.TabIndex = 250
        Me.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'btnOtra
        '
        Me.btnOtra.BackColor = System.Drawing.Color.Honeydew
        Me.btnOtra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnOtra.Image = Global.FacturacionServicios.My.Resources.Resources.Buscar6
        Me.btnOtra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOtra.Location = New System.Drawing.Point(838, 293)
        Me.btnOtra.Name = "btnOtra"
        Me.btnOtra.Size = New System.Drawing.Size(100, 43)
        Me.btnOtra.TabIndex = 251
        Me.btnOtra.Text = "Buscar Otra"
        Me.btnOtra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOtra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOtra.UseVisualStyleBackColor = False
        '
        'frmMantCotizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 474)
        Me.Controls.Add(Me.btnOtra)
        Me.Controls.Add(Me.btnBuscarCliente)
        Me.Controls.Add(Me.cmbIdCondicion)
        Me.Controls.Add(Me.cmbPrecio)
        Me.Controls.Add(Me.cmbProducto)
        Me.Controls.Add(Me.txtIdCliente)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtRef)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.txtprecio)
        Me.Controls.Add(Me.btanular)
        Me.Controls.Add(Me.btprint)
        Me.Controls.Add(Me.cb1)
        Me.Controls.Add(Me.lbusuarioquefacturo)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.dgvcotizacion)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtporcientoitbis)
        Me.Controls.Add(Me.Label10)
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
        Me.MaximizeBox = False
        Me.Name = "frmMantCotizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Cotizaciones"
        CType(Me.dgvcotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvcotizacion As DataGridView
    Friend WithEvents Label12 As Label
    Friend WithEvents txtporcientoitbis As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents mtbfecha As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtcliente As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtnumcotizacion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents rtbcomentario As RichTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtdescuento As TextBox
    Friend WithEvents bteliminar As Button
    Friend WithEvents btagregar As Button
    Friend WithEvents btsalir As Button
    Friend WithEvents btinsertar As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txttotal As TextBox
    Friend WithEvents lbitbis As Label
    Friend WithEvents txtitbis As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtsubtotal As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents lbestado As Label
    Friend WithEvents lbusuarioquefacturo As Label
    Friend WithEvents cb1 As CheckBox
    Friend WithEvents btanular As Button
    Friend WithEvents btprint As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtRef As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtcantidad As TextBox
    Friend WithEvents txtprecio As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtIdCliente As TextBox
    Friend WithEvents cmbIdCondicion As ComboBox
    Friend WithEvents cmbPrecio As ComboBox
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents btnBuscarCliente As Button
    Friend WithEvents btnOtra As Button
End Class
