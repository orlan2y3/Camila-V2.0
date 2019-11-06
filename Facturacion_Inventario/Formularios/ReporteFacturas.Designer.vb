<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteFacturas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteFacturas))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btprint = New System.Windows.Forms.Button()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.mtbfecha1 = New System.Windows.Forms.MaskedTextBox()
        Me.mtbfecha2 = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbCC = New System.Windows.Forms.RadioButton()
        Me.rbAnuladas = New System.Windows.Forms.RadioButton()
        Me.rbCredito = New System.Windows.Forms.RadioButton()
        Me.rbContado = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbIdUsuarios = New System.Windows.Forms.ComboBox()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.rbUno = New System.Windows.Forms.RadioButton()
        Me.mc = New System.Windows.Forms.MonthCalendar()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "DESDE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(153, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "HASTA"
        '
        'Button1
        '
        Me.Button1.Image = Global.FacturacionServicios.My.Resources.Resources._Date
        Me.Button1.Location = New System.Drawing.Point(85, 109)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 34)
        Me.Button1.TabIndex = 6
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.FacturacionServicios.My.Resources.Resources._Date
        Me.Button2.Location = New System.Drawing.Point(229, 109)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 34)
        Me.Button2.TabIndex = 7
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btprint
        '
        Me.btprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btprint.Image = Global.FacturacionServicios.My.Resources.Resources.Print2
        Me.btprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btprint.Location = New System.Drawing.Point(30, 316)
        Me.btprint.Name = "btprint"
        Me.btprint.Size = New System.Drawing.Size(87, 41)
        Me.btprint.TabIndex = 148
        Me.btprint.Text = "Imprimir"
        Me.btprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btprint.UseVisualStyleBackColor = True
        '
        'btsalir
        '
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btsalir.Image = Global.FacturacionServicios.My.Resources.Resources.Out
        Me.btsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsalir.Location = New System.Drawing.Point(154, 316)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(87, 41)
        Me.btsalir.TabIndex = 149
        Me.btsalir.Text = "Salir"
        Me.btsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btsalir.UseVisualStyleBackColor = True
        '
        'mtbfecha1
        '
        Me.mtbfecha1.Location = New System.Drawing.Point(12, 117)
        Me.mtbfecha1.Mask = "00/00/0000"
        Me.mtbfecha1.Name = "mtbfecha1"
        Me.mtbfecha1.Size = New System.Drawing.Size(67, 20)
        Me.mtbfecha1.TabIndex = 150
        Me.mtbfecha1.ValidatingType = GetType(Date)
        '
        'mtbfecha2
        '
        Me.mtbfecha2.Location = New System.Drawing.Point(156, 117)
        Me.mtbfecha2.Mask = "00/00/0000"
        Me.mtbfecha2.Name = "mtbfecha2"
        Me.mtbfecha2.Size = New System.Drawing.Size(67, 20)
        Me.mtbfecha2.TabIndex = 151
        Me.mtbfecha2.ValidatingType = GetType(Date)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbCC)
        Me.GroupBox1.Controls.Add(Me.rbAnuladas)
        Me.GroupBox1.Controls.Add(Me.rbCredito)
        Me.GroupBox1.Controls.Add(Me.rbContado)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 78)
        Me.GroupBox1.TabIndex = 154
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione una Opción"
        '
        'rbCC
        '
        Me.rbCC.AutoSize = True
        Me.rbCC.Location = New System.Drawing.Point(6, 52)
        Me.rbCC.Name = "rbCC"
        Me.rbCC.Size = New System.Drawing.Size(222, 17)
        Me.rbCC.TabIndex = 4
        Me.rbCC.TabStop = True
        Me.rbCC.Text = "Las de Contado y las de Crédito cobradas"
        Me.rbCC.UseVisualStyleBackColor = True
        '
        'rbAnuladas
        '
        Me.rbAnuladas.AutoSize = True
        Me.rbAnuladas.Location = New System.Drawing.Point(192, 19)
        Me.rbAnuladas.Name = "rbAnuladas"
        Me.rbAnuladas.Size = New System.Drawing.Size(69, 17)
        Me.rbAnuladas.TabIndex = 3
        Me.rbAnuladas.TabStop = True
        Me.rbAnuladas.Text = "Anuladas"
        Me.rbAnuladas.UseVisualStyleBackColor = True
        '
        'rbCredito
        '
        Me.rbCredito.AutoSize = True
        Me.rbCredito.Location = New System.Drawing.Point(106, 19)
        Me.rbCredito.Name = "rbCredito"
        Me.rbCredito.Size = New System.Drawing.Size(68, 17)
        Me.rbCredito.TabIndex = 2
        Me.rbCredito.TabStop = True
        Me.rbCredito.Text = "A Credito"
        Me.rbCredito.UseVisualStyleBackColor = True
        '
        'rbContado
        '
        Me.rbContado.AutoSize = True
        Me.rbContado.Location = New System.Drawing.Point(6, 20)
        Me.rbContado.Name = "rbContado"
        Me.rbContado.Size = New System.Drawing.Size(82, 17)
        Me.rbContado.TabIndex = 1
        Me.rbContado.TabStop = True
        Me.rbContado.Text = "De Contado"
        Me.rbContado.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cmbIdUsuarios)
        Me.GroupBox2.Controls.Add(Me.cmbUsuarios)
        Me.GroupBox2.Controls.Add(Me.rbTodos)
        Me.GroupBox2.Controls.Add(Me.rbUno)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 148)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 107)
        Me.GroupBox2.TabIndex = 183
        Me.GroupBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Seleccione el usuario"
        '
        'cmbIdUsuarios
        '
        Me.cmbIdUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdUsuarios.FormattingEnabled = True
        Me.cmbIdUsuarios.Location = New System.Drawing.Point(110, 71)
        Me.cmbIdUsuarios.Name = "cmbIdUsuarios"
        Me.cmbIdUsuarios.Size = New System.Drawing.Size(68, 21)
        Me.cmbIdUsuarios.TabIndex = 3
        Me.cmbIdUsuarios.Visible = False
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(11, 71)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(226, 24)
        Me.cmbUsuarios.TabIndex = 2
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTodos.Location = New System.Drawing.Point(157, 18)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(66, 20)
        Me.rbTodos.TabIndex = 1
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbUno
        '
        Me.rbUno.AutoSize = True
        Me.rbUno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbUno.Location = New System.Drawing.Point(27, 18)
        Me.rbUno.Name = "rbUno"
        Me.rbUno.Size = New System.Drawing.Size(93, 20)
        Me.rbUno.TabIndex = 0
        Me.rbUno.TabStop = True
        Me.rbUno.Text = "Un Usuario"
        Me.rbUno.UseVisualStyleBackColor = True
        '
        'mc
        '
        Me.mc.Location = New System.Drawing.Point(10, 147)
        Me.mc.Name = "mc"
        Me.mc.TabIndex = 184
        '
        'ReporteFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 365)
        Me.Controls.Add(Me.mc)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.mtbfecha2)
        Me.Controls.Add(Me.mtbfecha1)
        Me.Controls.Add(Me.btsalir)
        Me.Controls.Add(Me.btprint)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ReporteFacturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Facturas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btprint As System.Windows.Forms.Button
    Friend WithEvents btsalir As System.Windows.Forms.Button
    Friend WithEvents mtbfecha1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtbfecha2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbAnuladas As RadioButton
    Friend WithEvents rbCredito As RadioButton
    Friend WithEvents rbContado As RadioButton
    Friend WithEvents rbCC As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbIdUsuarios As ComboBox
    Friend WithEvents cmbUsuarios As ComboBox
    Friend WithEvents rbTodos As RadioButton
    Friend WithEvents rbUno As RadioButton
    Friend WithEvents mc As MonthCalendar
End Class
