<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteVentasBeneficios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteVentasBeneficios))
        Me.mc = New System.Windows.Forms.MonthCalendar()
        Me.mtbfecha2 = New System.Windows.Forms.MaskedTextBox()
        Me.mtbfecha1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.btprint = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'mc
        '
        Me.mc.Location = New System.Drawing.Point(8, 85)
        Me.mc.Name = "mc"
        Me.mc.TabIndex = 179
        '
        'mtbfecha2
        '
        Me.mtbfecha2.Location = New System.Drawing.Point(150, 58)
        Me.mtbfecha2.Mask = "00/00/0000"
        Me.mtbfecha2.Name = "mtbfecha2"
        Me.mtbfecha2.Size = New System.Drawing.Size(67, 20)
        Me.mtbfecha2.TabIndex = 178
        Me.mtbfecha2.ValidatingType = GetType(Date)
        '
        'mtbfecha1
        '
        Me.mtbfecha1.Location = New System.Drawing.Point(8, 58)
        Me.mtbfecha1.Mask = "00/00/0000"
        Me.mtbfecha1.Name = "mtbfecha1"
        Me.mtbfecha1.Size = New System.Drawing.Size(67, 20)
        Me.mtbfecha1.TabIndex = 177
        Me.mtbfecha1.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(147, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 172
        Me.Label2.Text = "HASTA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 171
        Me.Label1.Text = "DESDE"
        '
        'btsalir
        '
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btsalir.Image = Global.FacturacionServicios.My.Resources.Resources.Out
        Me.btsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsalir.Location = New System.Drawing.Point(168, 203)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(87, 41)
        Me.btsalir.TabIndex = 176
        Me.btsalir.Text = "Salir"
        Me.btsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btsalir.UseVisualStyleBackColor = True
        '
        'btprint
        '
        Me.btprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btprint.Image = Global.FacturacionServicios.My.Resources.Resources.Print2
        Me.btprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btprint.Location = New System.Drawing.Point(8, 203)
        Me.btprint.Name = "btprint"
        Me.btprint.Size = New System.Drawing.Size(87, 41)
        Me.btprint.TabIndex = 175
        Me.btprint.Text = "Imprimir"
        Me.btprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btprint.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.FacturacionServicios.My.Resources.Resources._Date
        Me.Button2.Location = New System.Drawing.Point(223, 47)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 34)
        Me.Button2.TabIndex = 174
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.FacturacionServicios.My.Resources.Resources._Date
        Me.Button1.Location = New System.Drawing.Point(81, 47)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 34)
        Me.Button1.TabIndex = 173
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(248, 16)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "REPORTE VENTAS - BENEFICIOS"
        '
        'frmReporteVentasBeneficios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(265, 253)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.mc)
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
        Me.Name = "frmReporteVentasBeneficios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Ventas - Beneficios"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mc As MonthCalendar
    Friend WithEvents mtbfecha2 As MaskedTextBox
    Friend WithEvents mtbfecha1 As MaskedTextBox
    Friend WithEvents btsalir As Button
    Friend WithEvents btprint As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
End Class
