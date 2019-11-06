<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Parametros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Parametros))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGrabaDeli = New System.Windows.Forms.Button()
        Me.cmbDeli = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btguardar = New System.Windows.Forms.Button()
        Me.txtitbis = New System.Windows.Forms.TextBox()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnGrabaPrint = New System.Windows.Forms.Button()
        Me.cmbPrint = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnGrabarCopias = New System.Windows.Forms.Button()
        Me.cmbCopias = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.btnGrabaMonto = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtValida = New System.Windows.Forms.MaskedTextBox()
        Me.btnGrabarFecha = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.btnGrabarEmail = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGrabaDeli)
        Me.GroupBox1.Controls.Add(Me.cmbDeli)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 175)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 57)
        Me.GroupBox1.TabIndex = 188
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Delivery recepción factura ??"
        '
        'btnGrabaDeli
        '
        Me.btnGrabaDeli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGrabaDeli.Image = Global.FacturacionServicios.My.Resources.Resources.Check
        Me.btnGrabaDeli.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabaDeli.Location = New System.Drawing.Point(105, 17)
        Me.btnGrabaDeli.Name = "btnGrabaDeli"
        Me.btnGrabaDeli.Size = New System.Drawing.Size(78, 30)
        Me.btnGrabaDeli.TabIndex = 1
        Me.btnGrabaDeli.Text = "Grabar"
        Me.btnGrabaDeli.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrabaDeli.UseVisualStyleBackColor = True
        '
        'cmbDeli
        '
        Me.cmbDeli.FormattingEnabled = True
        Me.cmbDeli.Items.AddRange(New Object() {"SI", "NO"})
        Me.cmbDeli.Location = New System.Drawing.Point(28, 21)
        Me.cmbDeli.Name = "cmbDeli"
        Me.cmbDeli.Size = New System.Drawing.Size(44, 21)
        Me.cmbDeli.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btguardar)
        Me.GroupBox2.Controls.Add(Me.txtitbis)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(197, 57)
        Me.GroupBox2.TabIndex = 189
        Me.GroupBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 192
        Me.Label3.Text = "% ITBIS "
        '
        'btguardar
        '
        Me.btguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btguardar.Image = Global.FacturacionServicios.My.Resources.Resources.Check
        Me.btguardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btguardar.Location = New System.Drawing.Point(109, 18)
        Me.btguardar.Name = "btguardar"
        Me.btguardar.Size = New System.Drawing.Size(74, 30)
        Me.btguardar.TabIndex = 2
        Me.btguardar.Text = "Grabar"
        Me.btguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btguardar.UseVisualStyleBackColor = True
        '
        'txtitbis
        '
        Me.txtitbis.Location = New System.Drawing.Point(16, 28)
        Me.txtitbis.Name = "txtitbis"
        Me.txtitbis.Size = New System.Drawing.Size(55, 20)
        Me.txtitbis.TabIndex = 0
        '
        'btsalir
        '
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btsalir.Image = Global.FacturacionServicios.My.Resources.Resources.Out
        Me.btsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsalir.Location = New System.Drawing.Point(190, 372)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(74, 38)
        Me.btsalir.TabIndex = 190
        Me.btsalir.Text = "Salir"
        Me.btsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btsalir.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnGrabaPrint)
        Me.GroupBox3.Controls.Add(Me.cmbPrint)
        Me.GroupBox3.Location = New System.Drawing.Point(236, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(196, 54)
        Me.GroupBox3.TabIndex = 191
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo de Impresora"
        '
        'btnGrabaPrint
        '
        Me.btnGrabaPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGrabaPrint.Image = Global.FacturacionServicios.My.Resources.Resources.Check
        Me.btnGrabaPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabaPrint.Location = New System.Drawing.Point(113, 15)
        Me.btnGrabaPrint.Name = "btnGrabaPrint"
        Me.btnGrabaPrint.Size = New System.Drawing.Size(74, 30)
        Me.btnGrabaPrint.TabIndex = 1
        Me.btnGrabaPrint.Text = "Grabar"
        Me.btnGrabaPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrabaPrint.UseVisualStyleBackColor = True
        '
        'cmbPrint
        '
        Me.cmbPrint.FormattingEnabled = True
        Me.cmbPrint.Items.AddRange(New Object() {"DE RECIBO", "NORMAL"})
        Me.cmbPrint.Location = New System.Drawing.Point(9, 19)
        Me.cmbPrint.Name = "cmbPrint"
        Me.cmbPrint.Size = New System.Drawing.Size(93, 21)
        Me.cmbPrint.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnGrabarCopias)
        Me.GroupBox4.Controls.Add(Me.cmbCopias)
        Me.GroupBox4.Location = New System.Drawing.Point(236, 88)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(196, 54)
        Me.GroupBox4.TabIndex = 192
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cantidad de Copias al imprimir"
        '
        'btnGrabarCopias
        '
        Me.btnGrabarCopias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGrabarCopias.Image = Global.FacturacionServicios.My.Resources.Resources.Check
        Me.btnGrabarCopias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabarCopias.Location = New System.Drawing.Point(110, 17)
        Me.btnGrabarCopias.Name = "btnGrabarCopias"
        Me.btnGrabarCopias.Size = New System.Drawing.Size(78, 30)
        Me.btnGrabarCopias.TabIndex = 1
        Me.btnGrabarCopias.Text = "Grabar"
        Me.btnGrabarCopias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrabarCopias.UseVisualStyleBackColor = True
        '
        'cmbCopias
        '
        Me.cmbCopias.FormattingEnabled = True
        Me.cmbCopias.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cmbCopias.Location = New System.Drawing.Point(35, 21)
        Me.cmbCopias.Name = "cmbCopias"
        Me.cmbCopias.Size = New System.Drawing.Size(46, 21)
        Me.cmbCopias.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtMonto)
        Me.GroupBox5.Controls.Add(Me.btnGrabaMonto)
        Me.GroupBox5.Location = New System.Drawing.Point(236, 175)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(196, 57)
        Me.GroupBox5.TabIndex = 193
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Monto Maximo de Descuento"
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(14, 22)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(76, 20)
        Me.txtMonto.TabIndex = 2
        '
        'btnGrabaMonto
        '
        Me.btnGrabaMonto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGrabaMonto.Image = Global.FacturacionServicios.My.Resources.Resources.Check
        Me.btnGrabaMonto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabaMonto.Location = New System.Drawing.Point(110, 17)
        Me.btnGrabaMonto.Name = "btnGrabaMonto"
        Me.btnGrabaMonto.Size = New System.Drawing.Size(78, 30)
        Me.btnGrabaMonto.TabIndex = 1
        Me.btnGrabaMonto.Text = "Grabar"
        Me.btnGrabaMonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrabaMonto.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtValida)
        Me.GroupBox6.Controls.Add(Me.btnGrabarFecha)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 88)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(196, 55)
        Me.GroupBox6.TabIndex = 194
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Fecha Valida hasta.  Para los NCF"
        '
        'txtValida
        '
        Me.txtValida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValida.Location = New System.Drawing.Point(13, 22)
        Me.txtValida.Mask = "##/##/####"
        Me.txtValida.Name = "txtValida"
        Me.txtValida.Size = New System.Drawing.Size(74, 21)
        Me.txtValida.TabIndex = 2
        '
        'btnGrabarFecha
        '
        Me.btnGrabarFecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGrabarFecha.Image = Global.FacturacionServicios.My.Resources.Resources.Check
        Me.btnGrabarFecha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabarFecha.Location = New System.Drawing.Point(105, 17)
        Me.btnGrabarFecha.Name = "btnGrabarFecha"
        Me.btnGrabarFecha.Size = New System.Drawing.Size(78, 30)
        Me.btnGrabarFecha.TabIndex = 1
        Me.btnGrabarFecha.Text = "Grabar"
        Me.btnGrabarFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrabarFecha.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 250)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(235, 16)
        Me.Label1.TabIndex = 195
        Me.Label1.Text = "Cuenta de correo para enviar reportes"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(8, 268)
        Me.txtEmail.MaxLength = 125
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(424, 22)
        Me.txtEmail.TabIndex = 196
        '
        'btnGrabarEmail
        '
        Me.btnGrabarEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGrabarEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabarEmail.Image = Global.FacturacionServicios.My.Resources.Resources.Check
        Me.btnGrabarEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabarEmail.Location = New System.Drawing.Point(138, 300)
        Me.btnGrabarEmail.Name = "btnGrabarEmail"
        Me.btnGrabarEmail.Size = New System.Drawing.Size(177, 35)
        Me.btnGrabarEmail.TabIndex = 197
        Me.btnGrabarEmail.Text = "Grabar cuenta de correo"
        Me.btnGrabarEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrabarEmail.UseVisualStyleBackColor = True
        '
        'Parametros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LavenderBlush
        Me.ClientSize = New System.Drawing.Size(441, 415)
        Me.Controls.Add(Me.btnGrabarEmail)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btsalir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Parametros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parametros Generales"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnGrabaDeli As Button
    Friend WithEvents cmbDeli As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btguardar As Button
    Friend WithEvents txtitbis As TextBox
    Friend WithEvents btsalir As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnGrabaPrint As Button
    Friend WithEvents cmbPrint As ComboBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnGrabarCopias As Button
    Friend WithEvents cmbCopias As ComboBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents btnGrabaMonto As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txtValida As MaskedTextBox
    Friend WithEvents btnGrabarFecha As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnGrabarEmail As Button
End Class
