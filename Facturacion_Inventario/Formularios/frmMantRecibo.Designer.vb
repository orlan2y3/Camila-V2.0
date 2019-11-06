<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantRecibo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantRecibo))
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.dgvRecibos = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtMontoAnt = New System.Windows.Forms.TextBox()
        Me.txtIdPago = New System.Windows.Forms.TextBox()
        Me.cmbConcepto = New System.Windows.Forms.ComboBox()
        Me.txtRecibo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFechaPago = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMontoRecibido = New System.Windows.Forms.TextBox()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFechaFact = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMontoFact = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAbonado = New System.Windows.Forms.TextBox()
        Me.btprint = New System.Windows.Forms.Button()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.lblAnulado = New System.Windows.Forms.Label()
        CType(Me.dgvRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGrabar
        '
        Me.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGrabar.Image = Global.FacturacionServicios.My.Resources.Resources.Cd11
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(39, 378)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(96, 40)
        Me.btnGrabar.TabIndex = 132
        Me.btnGrabar.Text = "Actualizar"
        Me.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'dgvRecibos
        '
        Me.dgvRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecibos.Location = New System.Drawing.Point(11, 54)
        Me.dgvRecibos.Name = "dgvRecibos"
        Me.dgvRecibos.ReadOnly = True
        Me.dgvRecibos.Size = New System.Drawing.Size(523, 136)
        Me.dgvRecibos.TabIndex = 129
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.LightCyan
        Me.GroupBox2.Controls.Add(Me.txtMontoAnt)
        Me.GroupBox2.Controls.Add(Me.txtIdPago)
        Me.GroupBox2.Controls.Add(Me.cmbConcepto)
        Me.GroupBox2.Controls.Add(Me.txtRecibo)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtFechaPago)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtMontoRecibido)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 286)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(524, 65)
        Me.GroupBox2.TabIndex = 134
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DATOS DEL RECIBO"
        '
        'txtMontoAnt
        '
        Me.txtMontoAnt.BackColor = System.Drawing.Color.White
        Me.txtMontoAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoAnt.Location = New System.Drawing.Point(162, 40)
        Me.txtMontoAnt.Name = "txtMontoAnt"
        Me.txtMontoAnt.Size = New System.Drawing.Size(84, 22)
        Me.txtMontoAnt.TabIndex = 102
        Me.txtMontoAnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMontoAnt.Visible = False
        '
        'txtIdPago
        '
        Me.txtIdPago.Location = New System.Drawing.Point(36, 42)
        Me.txtIdPago.Name = "txtIdPago"
        Me.txtIdPago.Size = New System.Drawing.Size(78, 20)
        Me.txtIdPago.TabIndex = 101
        Me.txtIdPago.Visible = False
        '
        'cmbConcepto
        '
        Me.cmbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConcepto.FormattingEnabled = True
        Me.cmbConcepto.Location = New System.Drawing.Point(270, 36)
        Me.cmbConcepto.Name = "cmbConcepto"
        Me.cmbConcepto.Size = New System.Drawing.Size(156, 21)
        Me.cmbConcepto.TabIndex = 2
        '
        'txtRecibo
        '
        Me.txtRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecibo.Location = New System.Drawing.Point(10, 36)
        Me.txtRecibo.Name = "txtRecibo"
        Me.txtRecibo.ReadOnly = True
        Me.txtRecibo.Size = New System.Drawing.Size(114, 22)
        Me.txtRecibo.TabIndex = 0
        Me.txtRecibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 16)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "No. de Recibo"
        '
        'txtFechaPago
        '
        Me.txtFechaPago.BackColor = System.Drawing.Color.White
        Me.txtFechaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaPago.Location = New System.Drawing.Point(439, 36)
        Me.txtFechaPago.Mask = "##/##/####"
        Me.txtFechaPago.Name = "txtFechaPago"
        Me.txtFechaPago.Size = New System.Drawing.Size(74, 22)
        Me.txtFechaPago.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(436, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 16)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Fecha pago"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(268, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 16)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Seleccione el Concepto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(160, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 16)
        Me.Label5.TabIndex = 87
        Me.Label5.Text = "Monto Recibido"
        '
        'txtMontoRecibido
        '
        Me.txtMontoRecibido.BackColor = System.Drawing.Color.White
        Me.txtMontoRecibido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoRecibido.Location = New System.Drawing.Point(136, 36)
        Me.txtMontoRecibido.Name = "txtMontoRecibido"
        Me.txtMontoRecibido.Size = New System.Drawing.Size(122, 22)
        Me.txtMontoRecibido.TabIndex = 1
        Me.txtMontoRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btsalir
        '
        Me.btsalir.BackColor = System.Drawing.Color.Honeydew
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btsalir.Image = Global.FacturacionServicios.My.Resources.Resources.Out
        Me.btsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsalir.Location = New System.Drawing.Point(428, 378)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(78, 40)
        Me.btsalir.TabIndex = 133
        Me.btsalir.Text = "Salir"
        Me.btsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btsalir.UseVisualStyleBackColor = False
        '
        'txtIdCliente
        '
        Me.txtIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCliente.Location = New System.Drawing.Point(350, 17)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(76, 22)
        Me.txtIdCliente.TabIndex = 139
        Me.txtIdCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIdCliente.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(110, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 16)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.White
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(112, 26)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(422, 22)
        Me.txtCliente.TabIndex = 137
        '
        'txtFactura
        '
        Me.txtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactura.Location = New System.Drawing.Point(11, 26)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(88, 22)
        Me.txtFactura.TabIndex = 135
        Me.txtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 136
        Me.Label7.Text = "No. Factura"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Beige
        Me.GroupBox1.Controls.Add(Me.txtFechaFact)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtBalance)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtMontoFact)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtAbonado)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 202)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(523, 63)
        Me.GroupBox1.TabIndex = 140
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS DE LA FACTURA"
        '
        'txtFechaFact
        '
        Me.txtFechaFact.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFact.Location = New System.Drawing.Point(12, 33)
        Me.txtFechaFact.Mask = "##/##/####"
        Me.txtFechaFact.Name = "txtFechaFact"
        Me.txtFechaFact.ReadOnly = True
        Me.txtFechaFact.Size = New System.Drawing.Size(74, 22)
        Me.txtFechaFact.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 16)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "Fecha Fact."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(452, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 16)
        Me.Label10.TabIndex = 95
        Me.Label10.Text = "Balance"
        '
        'txtBalance
        '
        Me.txtBalance.BackColor = System.Drawing.Color.White
        Me.txtBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBalance.Location = New System.Drawing.Point(373, 33)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(139, 22)
        Me.txtBalance.TabIndex = 4
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(140, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 16)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "Monto Factura"
        '
        'txtMontoFact
        '
        Me.txtMontoFact.BackColor = System.Drawing.Color.White
        Me.txtMontoFact.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoFact.Location = New System.Drawing.Point(98, 33)
        Me.txtMontoFact.Name = "txtMontoFact"
        Me.txtMontoFact.ReadOnly = True
        Me.txtMontoFact.Size = New System.Drawing.Size(130, 22)
        Me.txtMontoFact.TabIndex = 2
        Me.txtMontoFact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(267, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 16)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Total Abonado"
        '
        'txtAbonado
        '
        Me.txtAbonado.BackColor = System.Drawing.Color.White
        Me.txtAbonado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbonado.Location = New System.Drawing.Point(241, 33)
        Me.txtAbonado.Name = "txtAbonado"
        Me.txtAbonado.ReadOnly = True
        Me.txtAbonado.Size = New System.Drawing.Size(119, 22)
        Me.txtAbonado.TabIndex = 3
        Me.txtAbonado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btprint
        '
        Me.btprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btprint.Image = Global.FacturacionServicios.My.Resources.Resources.Print2
        Me.btprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btprint.Location = New System.Drawing.Point(178, 378)
        Me.btprint.Name = "btprint"
        Me.btprint.Size = New System.Drawing.Size(91, 40)
        Me.btprint.TabIndex = 141
        Me.btprint.Text = "Imprimir"
        Me.btprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btprint.UseVisualStyleBackColor = True
        '
        'btnAnular
        '
        Me.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAnular.Image = Global.FacturacionServicios.My.Resources.Resources.Delete2
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnular.Location = New System.Drawing.Point(311, 378)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(75, 40)
        Me.btnAnular.TabIndex = 142
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnular.UseVisualStyleBackColor = True
        '
        'lblAnulado
        '
        Me.lblAnulado.AutoSize = True
        Me.lblAnulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnulado.ForeColor = System.Drawing.Color.Red
        Me.lblAnulado.Location = New System.Drawing.Point(175, 269)
        Me.lblAnulado.Name = "lblAnulado"
        Me.lblAnulado.Size = New System.Drawing.Size(188, 16)
        Me.lblAnulado.TabIndex = 143
        Me.lblAnulado.Text = "R E C I B O  A N U L A D O"
        Me.lblAnulado.Visible = False
        '
        'frmMantRecibo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.NavajoWhite
        Me.ClientSize = New System.Drawing.Size(546, 428)
        Me.Controls.Add(Me.lblAnulado)
        Me.Controls.Add(Me.btnAnular)
        Me.Controls.Add(Me.btprint)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtIdCliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtFactura)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.dgvRecibos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btsalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMantRecibo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Recibo de Ingreso"
        CType(Me.dgvRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGrabar As Button
    Friend WithEvents dgvRecibos As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtIdPago As TextBox
    Friend WithEvents cmbConcepto As ComboBox
    Friend WithEvents txtRecibo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtFechaPago As MaskedTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtMontoRecibido As TextBox
    Friend WithEvents btsalir As Button
    Friend WithEvents txtIdCliente As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents txtFactura As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtFechaFact As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtBalance As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMontoFact As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtAbonado As TextBox
    Friend WithEvents txtMontoAnt As TextBox
    Friend WithEvents btprint As Button
    Friend WithEvents btnAnular As Button
    Friend WithEvents lblAnulado As Label
End Class
