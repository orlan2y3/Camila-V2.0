<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatosEmpresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDatosEmpresa))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtProvincia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEslogan = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTelefonos = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRnc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.btguardar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtProvincia)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtEslogan)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtTelefonos)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtRnc)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDireccion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(720, 227)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'txtProvincia
        '
        Me.txtProvincia.Location = New System.Drawing.Point(496, 144)
        Me.txtProvincia.MaxLength = 50
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.Size = New System.Drawing.Size(214, 22)
        Me.txtProvincia.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(493, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 193
        Me.Label6.Text = "Provincia"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(166, 18)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Datos de la Empresa"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(10, 194)
        Me.txtEmail.MaxLength = 255
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(702, 22)
        Me.txtEmail.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 177)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 16)
        Me.Label8.TabIndex = 191
        Me.Label8.Text = "Email"
        '
        'txtEslogan
        '
        Me.txtEslogan.Location = New System.Drawing.Point(10, 94)
        Me.txtEslogan.MaxLength = 125
        Me.txtEslogan.Name = "txtEslogan"
        Me.txtEslogan.Size = New System.Drawing.Size(382, 22)
        Me.txtEslogan.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 16)
        Me.Label7.TabIndex = 189
        Me.Label7.Text = "Eslogan"
        '
        'txtTelefonos
        '
        Me.txtTelefonos.Location = New System.Drawing.Point(405, 94)
        Me.txtTelefonos.MaxLength = 50
        Me.txtTelefonos.Name = "txtTelefonos"
        Me.txtTelefonos.Size = New System.Drawing.Size(305, 22)
        Me.txtTelefonos.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(403, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 16)
        Me.Label5.TabIndex = 187
        Me.Label5.Text = "Telefonos"
        '
        'txtRnc
        '
        Me.txtRnc.Location = New System.Drawing.Point(496, 44)
        Me.txtRnc.MaxLength = 50
        Me.txtRnc.Name = "txtRnc"
        Me.txtRnc.Size = New System.Drawing.Size(214, 22)
        Me.txtRnc.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(494, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 185
        Me.Label4.Text = "RNC"
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(9, 144)
        Me.txtDireccion.MaxLength = 255
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(473, 22)
        Me.txtDireccion.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 16)
        Me.Label1.TabIndex = 183
        Me.Label1.Text = "Dirección"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(9, 44)
        Me.txtNombre.MaxLength = 255
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(473, 22)
        Me.txtNombre.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 16)
        Me.Label2.TabIndex = 181
        Me.Label2.Text = "Nombre Empresa"
        '
        'btsalir
        '
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btsalir.Image = Global.FacturacionServicios.My.Resources.Resources.Out
        Me.btsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsalir.Location = New System.Drawing.Point(437, 264)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(87, 41)
        Me.btsalir.TabIndex = 1
        Me.btsalir.Text = "Salir"
        Me.btsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btsalir.UseVisualStyleBackColor = True
        '
        'btguardar
        '
        Me.btguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btguardar.Image = Global.FacturacionServicios.My.Resources.Resources.Check
        Me.btguardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btguardar.Location = New System.Drawing.Point(213, 264)
        Me.btguardar.Name = "btguardar"
        Me.btguardar.Size = New System.Drawing.Size(87, 41)
        Me.btguardar.TabIndex = 0
        Me.btguardar.Text = "Grabar"
        Me.btguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btguardar.UseVisualStyleBackColor = True
        '
        'frmDatosEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(741, 316)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btsalir)
        Me.Controls.Add(Me.btguardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDatosEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrar Datos de la Empresa"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtEslogan As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTelefonos As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtRnc As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btsalir As Button
    Friend WithEvents btguardar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtProvincia As TextBox
    Friend WithEvents Label6 As Label
End Class
