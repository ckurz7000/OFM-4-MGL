<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSettings
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTileCachePath = New System.Windows.Forms.TextBox()
        Me.btnBrowseTileCache = New System.Windows.Forms.Button()
        Me.txtMapPath = New System.Windows.Forms.TextBox()
        Me.btnBrowseMapPath = New System.Windows.Forms.Button()
        Me.dlgBrowsePaths = New System.Windows.Forms.FolderBrowserDialog()
        Me.cbxColors = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbxTMS = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Download tiles from here:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Store tiles here:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Store maps here:"
        '
        'txtTileCachePath
        '
        Me.txtTileCachePath.Location = New System.Drawing.Point(138, 126)
        Me.txtTileCachePath.Name = "txtTileCachePath"
        Me.txtTileCachePath.Size = New System.Drawing.Size(394, 20)
        Me.txtTileCachePath.TabIndex = 1
        '
        'btnBrowseTileCache
        '
        Me.btnBrowseTileCache.Location = New System.Drawing.Point(538, 124)
        Me.btnBrowseTileCache.Name = "btnBrowseTileCache"
        Me.btnBrowseTileCache.Size = New System.Drawing.Size(35, 23)
        Me.btnBrowseTileCache.TabIndex = 2
        Me.btnBrowseTileCache.Text = "..."
        Me.btnBrowseTileCache.UseVisualStyleBackColor = True
        '
        'txtMapPath
        '
        Me.txtMapPath.Location = New System.Drawing.Point(138, 154)
        Me.txtMapPath.Name = "txtMapPath"
        Me.txtMapPath.Size = New System.Drawing.Size(394, 20)
        Me.txtMapPath.TabIndex = 1
        '
        'btnBrowseMapPath
        '
        Me.btnBrowseMapPath.Location = New System.Drawing.Point(538, 152)
        Me.btnBrowseMapPath.Name = "btnBrowseMapPath"
        Me.btnBrowseMapPath.Size = New System.Drawing.Size(35, 23)
        Me.btnBrowseMapPath.TabIndex = 2
        Me.btnBrowseMapPath.Text = "..."
        Me.btnBrowseMapPath.UseVisualStyleBackColor = True
        '
        'cbxColors
        '
        Me.cbxColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxColors.FormattingEnabled = True
        Me.cbxColors.Items.AddRange(New Object() {"256", "128", "64", "32", "16"})
        Me.cbxColors.Location = New System.Drawing.Point(138, 182)
        Me.cbxColors.Name = "cbxColors"
        Me.cbxColors.Size = New System.Drawing.Size(88, 21)
        Me.cbxColors.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(59, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Colors per tile:"
        '
        'lbxTMS
        '
        Me.lbxTMS.FormattingEnabled = True
        Me.lbxTMS.Location = New System.Drawing.Point(138, 30)
        Me.lbxTMS.Name = "lbxTMS"
        Me.lbxTMS.Size = New System.Drawing.Size(394, 82)
        Me.lbxTMS.TabIndex = 4
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 245)
        Me.Controls.Add(Me.lbxTMS)
        Me.Controls.Add(Me.cbxColors)
        Me.Controls.Add(Me.btnBrowseMapPath)
        Me.Controls.Add(Me.btnBrowseTileCache)
        Me.Controls.Add(Me.txtMapPath)
        Me.Controls.Add(Me.txtTileCachePath)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSettings"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTileCachePath As TextBox
    Friend WithEvents btnBrowseTileCache As Button
    Friend WithEvents txtMapPath As TextBox
    Friend WithEvents btnBrowseMapPath As Button
    Friend WithEvents dlgBrowsePaths As FolderBrowserDialog
    Friend WithEvents cbxColors As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lbxTMS As ListBox
End Class
