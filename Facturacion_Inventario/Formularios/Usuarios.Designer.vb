<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Usuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Usuarios))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.dgvclientes = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre_completo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtbuscar = New System.Windows.Forms.TextBox()
        Me.btbuscar = New System.Windows.Forms.Button()
        Me.rdbid = New System.Windows.Forms.RadioButton()
        Me.rdbnombre = New System.Windows.Forms.RadioButton()
        Me.txtcontrasena = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdbcajero = New System.Windows.Forms.RadioButton()
        Me.rdbsupervisor = New System.Windows.Forms.RadioButton()
        Me.rdbadministrador = New System.Windows.Forms.RadioButton()
        Me.btlimpiar = New System.Windows.Forms.Button()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.btactivar = New System.Windows.Forms.Button()
        Me.bteliminar = New System.Windows.Forms.Button()
        Me.btinsertar = New System.Windows.Forms.Button()
        Me.txtNivel = New System.Windows.Forms.ComboBox()
        CType(Me.dgvclientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "ID"
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(79, 12)
        Me.txtid.Name = "txtid"
        Me.txtid.ReadOnly = True
        Me.txtid.Size = New System.Drawing.Size(66, 20)
        Me.txtid.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Usuario"
        '
        'txtnombre
        '
        Me.txtnombre.Location = New System.Drawing.Point(79, 38)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(156, 20)
        Me.txtnombre.TabIndex = 0
        '
        'txtusuario
        '
        Me.txtusuario.Location = New System.Drawing.Point(79, 64)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.Size = New System.Drawing.Size(156, 20)
        Me.txtusuario.TabIndex = 1
        '
        'dgvclientes
        '
        Me.dgvclientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvclientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvclientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvclientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.nombre_completo, Me.usuario, Me.nivel, Me.estado})
        Me.dgvclientes.EnableHeadersVisualStyles = False
        Me.dgvclientes.Location = New System.Drawing.Point(12, 200)
        Me.dgvclientes.Name = "dgvclientes"
        Me.dgvclientes.ReadOnly = True
        Me.dgvclientes.Size = New System.Drawing.Size(692, 165)
        Me.dgvclientes.TabIndex = 9
        '
        'id
        '
        Me.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.id.DataPropertyName = "id"
        Me.id.FillWeight = 50.0!
        Me.id.HeaderText = "Código"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 50
        '
        'nombre_completo
        '
        Me.nombre_completo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.nombre_completo.DataPropertyName = "nombre_completo"
        Me.nombre_completo.HeaderText = "Nombre Completo"
        Me.nombre_completo.Name = "nombre_completo"
        Me.nombre_completo.ReadOnly = True
        '
        'usuario
        '
        Me.usuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.usuario.DataPropertyName = "usuario"
        Me.usuario.HeaderText = "Usuario"
        Me.usuario.Name = "usuario"
        Me.usuario.ReadOnly = True
        '
        'nivel
        '
        Me.nivel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.nivel.DataPropertyName = "nivel"
        Me.nivel.HeaderText = "Nivel"
        Me.nivel.Name = "nivel"
        Me.nivel.ReadOnly = True
        Me.nivel.Width = 50
        '
        'estado
        '
        Me.estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.estado.DataPropertyName = "estado"
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtbuscar)
        Me.GroupBox1.Controls.Add(Me.btbuscar)
        Me.GroupBox1.Controls.Add(Me.rdbid)
        Me.GroupBox1.Controls.Add(Me.rdbnombre)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 142)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(692, 52)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar Por:"
        '
        'txtbuscar
        '
        Me.txtbuscar.Location = New System.Drawing.Point(116, 18)
        Me.txtbuscar.Name = "txtbuscar"
        Me.txtbuscar.Size = New System.Drawing.Size(100, 20)
        Me.txtbuscar.TabIndex = 4
        '
        'btbuscar
        '
        Me.btbuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btbuscar.Image = Global.FacturacionServicios.My.Resources.Resources.Search
        Me.btbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btbuscar.Location = New System.Drawing.Point(222, 7)
        Me.btbuscar.Name = "btbuscar"
        Me.btbuscar.Size = New System.Drawing.Size(87, 41)
        Me.btbuscar.TabIndex = 3
        Me.btbuscar.Text = "Buscar"
        Me.btbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btbuscar.UseVisualStyleBackColor = True
        '
        'rdbid
        '
        Me.rdbid.AutoSize = True
        Me.rdbid.Location = New System.Drawing.Point(74, 19)
        Me.rdbid.Name = "rdbid"
        Me.rdbid.Size = New System.Drawing.Size(36, 17)
        Me.rdbid.TabIndex = 2
        Me.rdbid.TabStop = True
        Me.rdbid.Text = "ID"
        Me.rdbid.UseVisualStyleBackColor = True
        '
        'rdbnombre
        '
        Me.rdbnombre.AutoSize = True
        Me.rdbnombre.Location = New System.Drawing.Point(6, 19)
        Me.rdbnombre.Name = "rdbnombre"
        Me.rdbnombre.Size = New System.Drawing.Size(62, 17)
        Me.rdbnombre.TabIndex = 0
        Me.rdbnombre.TabStop = True
        Me.rdbnombre.Text = "Nombre"
        Me.rdbnombre.UseVisualStyleBackColor = True
        '
        'txtcontrasena
        '
        Me.txtcontrasena.Location = New System.Drawing.Point(79, 90)
        Me.txtcontrasena.Name = "txtcontrasena"
        Me.txtcontrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtcontrasena.Size = New System.Drawing.Size(156, 20)
        Me.txtcontrasena.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Contraseña"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(42, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Nivel"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdbcajero)
        Me.GroupBox2.Controls.Add(Me.rdbsupervisor)
        Me.GroupBox2.Controls.Add(Me.rdbadministrador)
        Me.GroupBox2.Location = New System.Drawing.Point(241, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(463, 124)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Niveles"
        '
        'rdbcajero
        '
        Me.rdbcajero.AutoSize = True
        Me.rdbcajero.Location = New System.Drawing.Point(6, 65)
        Me.rdbcajero.Name = "rdbcajero"
        Me.rdbcajero.Size = New System.Drawing.Size(452, 17)
        Me.rdbcajero.TabIndex = 2
        Me.rdbcajero.TabStop = True
        Me.rdbcajero.Text = "Cajero(a) (Acceso a facturacion y mantenimiento, necesita clave admin en algunas " &
    "tareas)."
        Me.rdbcajero.UseVisualStyleBackColor = True
        '
        'rdbsupervisor
        '
        Me.rdbsupervisor.AutoSize = True
        Me.rdbsupervisor.Location = New System.Drawing.Point(6, 42)
        Me.rdbsupervisor.Name = "rdbsupervisor"
        Me.rdbsupervisor.Size = New System.Drawing.Size(398, 17)
        Me.rdbsupervisor.TabIndex = 1
        Me.rdbsupervisor.TabStop = True
        Me.rdbsupervisor.Text = "Supervisor (Acceso a todo el sistema, necesita clave admin en algunas tareas)."
        Me.rdbsupervisor.UseVisualStyleBackColor = True
        '
        'rdbadministrador
        '
        Me.rdbadministrador.AutoSize = True
        Me.rdbadministrador.Location = New System.Drawing.Point(6, 19)
        Me.rdbadministrador.Name = "rdbadministrador"
        Me.rdbadministrador.Size = New System.Drawing.Size(218, 17)
        Me.rdbadministrador.TabIndex = 0
        Me.rdbadministrador.TabStop = True
        Me.rdbadministrador.Text = "Administrador (Acceso a todo el sistema)."
        Me.rdbadministrador.UseVisualStyleBackColor = True
        '
        'btlimpiar
        '
        Me.btlimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btlimpiar.Image = Global.FacturacionServicios.My.Resources.Resources.Clean
        Me.btlimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btlimpiar.Location = New System.Drawing.Point(524, 371)
        Me.btlimpiar.Name = "btlimpiar"
        Me.btlimpiar.Size = New System.Drawing.Size(87, 41)
        Me.btlimpiar.TabIndex = 6
        Me.btlimpiar.Text = "Limpiar"
        Me.btlimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btlimpiar.UseVisualStyleBackColor = True
        '
        'btsalir
        '
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btsalir.Image = Global.FacturacionServicios.My.Resources.Resources.Out
        Me.btsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsalir.Location = New System.Drawing.Point(617, 371)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(87, 41)
        Me.btsalir.TabIndex = 7
        Me.btsalir.Text = "Salir"
        Me.btsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btsalir.UseVisualStyleBackColor = True
        '
        'btactivar
        '
        Me.btactivar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btactivar.Image = Global.FacturacionServicios.My.Resources.Resources.Activate
        Me.btactivar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btactivar.Location = New System.Drawing.Point(105, 371)
        Me.btactivar.Name = "btactivar"
        Me.btactivar.Size = New System.Drawing.Size(87, 41)
        Me.btactivar.TabIndex = 18
        Me.btactivar.Text = "Activar"
        Me.btactivar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btactivar.UseVisualStyleBackColor = True
        '
        'bteliminar
        '
        Me.bteliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.bteliminar.Image = Global.FacturacionServicios.My.Resources.Resources.Deactivate
        Me.bteliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bteliminar.Location = New System.Drawing.Point(198, 371)
        Me.bteliminar.Name = "bteliminar"
        Me.bteliminar.Size = New System.Drawing.Size(87, 41)
        Me.bteliminar.TabIndex = 5
        Me.bteliminar.Text = "Desactivar"
        Me.bteliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bteliminar.UseVisualStyleBackColor = True
        '
        'btinsertar
        '
        Me.btinsertar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btinsertar.Image = Global.FacturacionServicios.My.Resources.Resources.Check
        Me.btinsertar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btinsertar.Location = New System.Drawing.Point(12, 371)
        Me.btinsertar.Name = "btinsertar"
        Me.btinsertar.Size = New System.Drawing.Size(87, 41)
        Me.btinsertar.TabIndex = 3
        Me.btinsertar.Text = "Grabar"
        Me.btinsertar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btinsertar.UseVisualStyleBackColor = True
        '
        'txtNivel
        '
        Me.txtNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtNivel.FormattingEnabled = True
        Me.txtNivel.Location = New System.Drawing.Point(79, 116)
        Me.txtNivel.Name = "txtNivel"
        Me.txtNivel.Size = New System.Drawing.Size(51, 21)
        Me.txtNivel.TabIndex = 19
        '
        'Usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 424)
        Me.Controls.Add(Me.txtNivel)
        Me.Controls.Add(Me.btactivar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtcontrasena)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btlimpiar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvclientes)
        Me.Controls.Add(Me.bteliminar)
        Me.Controls.Add(Me.btsalir)
        Me.Controls.Add(Me.btinsertar)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.txtnombre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Usuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        CType(Me.dgvclientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtid As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents txtusuario As System.Windows.Forms.TextBox
    Friend WithEvents btinsertar As System.Windows.Forms.Button
    Friend WithEvents btsalir As System.Windows.Forms.Button
    Friend WithEvents bteliminar As System.Windows.Forms.Button
    Friend WithEvents dgvclientes As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btbuscar As System.Windows.Forms.Button
    Friend WithEvents rdbid As System.Windows.Forms.RadioButton
    Friend WithEvents rdbnombre As System.Windows.Forms.RadioButton
    Friend WithEvents txtbuscar As System.Windows.Forms.TextBox
    Friend WithEvents btlimpiar As System.Windows.Forms.Button
    Friend WithEvents txtcontrasena As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbsupervisor As System.Windows.Forms.RadioButton
    Friend WithEvents rdbadministrador As System.Windows.Forms.RadioButton
    Friend WithEvents rdbcajero As System.Windows.Forms.RadioButton
    Friend WithEvents btactivar As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre_completo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nivel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtNivel As ComboBox
End Class
