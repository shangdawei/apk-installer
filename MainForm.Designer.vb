<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.labelAppName = New System.Windows.Forms.Label()
        Me.labelAppVersion = New System.Windows.Forms.Label()
        Me.labelVersion = New System.Windows.Forms.Label()
        Me.buttonInstall = New System.Windows.Forms.Button()
        Me.menuLanguage = New System.Windows.Forms.ComboBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.PermID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PermDesc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(10, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'labelAppName
        '
        Me.labelAppName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelAppName.AutoEllipsis = True
        Me.labelAppName.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelAppName.Location = New System.Drawing.Point(87, 11)
        Me.labelAppName.Name = "labelAppName"
        Me.labelAppName.Size = New System.Drawing.Size(327, 25)
        Me.labelAppName.TabIndex = 1
        Me.labelAppName.Text = "AppName"
        '
        'labelAppVersion
        '
        Me.labelAppVersion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelAppVersion.AutoEllipsis = True
        Me.labelAppVersion.Location = New System.Drawing.Point(90, 40)
        Me.labelAppVersion.Name = "labelAppVersion"
        Me.labelAppVersion.Size = New System.Drawing.Size(487, 15)
        Me.labelAppVersion.TabIndex = 2
        Me.labelAppVersion.Text = "Version {0} ({1})"
        '
        'labelVersion
        '
        Me.labelVersion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelVersion.AutoEllipsis = True
        Me.labelVersion.Enabled = False
        Me.labelVersion.Location = New System.Drawing.Point(90, 55)
        Me.labelVersion.Name = "labelVersion"
        Me.labelVersion.Size = New System.Drawing.Size(487, 15)
        Me.labelVersion.TabIndex = 2
        Me.labelVersion.Text = "Requires Android {0}"
        '
        'buttonInstall
        '
        Me.buttonInstall.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonInstall.Location = New System.Drawing.Point(502, 296)
        Me.buttonInstall.Name = "buttonInstall"
        Me.buttonInstall.Size = New System.Drawing.Size(75, 21)
        Me.buttonInstall.TabIndex = 5
        Me.buttonInstall.Text = "Install"
        Me.buttonInstall.UseVisualStyleBackColor = True
        '
        'menuLanguage
        '
        Me.menuLanguage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.menuLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.menuLanguage.DropDownWidth = 230
        Me.menuLanguage.FormattingEnabled = True
        Me.menuLanguage.Location = New System.Drawing.Point(420, 12)
        Me.menuLanguage.Name = "menuLanguage"
        Me.menuLanguage.Size = New System.Drawing.Size(157, 21)
        Me.menuLanguage.Sorted = True
        Me.menuLanguage.TabIndex = 6
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PermID, Me.PermDesc})
        Me.ListView1.Location = New System.Drawing.Point(10, 80)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(567, 210)
        Me.ListView1.TabIndex = 7
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'PermID
        '
        Me.PermID.Text = "ID"
        Me.PermID.Width = 200
        '
        'PermDesc
        '
        Me.PermDesc.Text = "Description"
        Me.PermDesc.Width = 256
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 329)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.menuLanguage)
        Me.Controls.Add(Me.buttonInstall)
        Me.Controls.Add(Me.labelVersion)
        Me.Controls.Add(Me.labelAppVersion)
        Me.Controls.Add(Me.labelAppName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(325, 300)
        Me.Name = "MainForm"
        Me.Text = "Install {0}"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents labelAppName As System.Windows.Forms.Label
    Friend WithEvents labelAppVersion As System.Windows.Forms.Label
    Friend WithEvents labelVersion As System.Windows.Forms.Label
    Friend WithEvents buttonInstall As System.Windows.Forms.Button
    Friend WithEvents menuLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents PermID As System.Windows.Forms.ColumnHeader
    Friend WithEvents PermDesc As System.Windows.Forms.ColumnHeader

End Class
