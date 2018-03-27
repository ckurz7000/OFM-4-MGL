<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmView
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
        Me.tlpGrid = New System.Windows.Forms.TableLayoutPanel()
        Me.pbxMap = New System.Windows.Forms.PictureBox()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.tlpGrid.SuspendLayout()
        CType(Me.pbxMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpGrid
        '
        Me.tlpGrid.ColumnCount = 5
        Me.tlpGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpGrid.Controls.Add(Me.pbxMap, 1, 1)
        Me.tlpGrid.Controls.Add(Me.btnUp, 2, 0)
        Me.tlpGrid.Controls.Add(Me.Button1, 0, 2)
        Me.tlpGrid.Controls.Add(Me.Button2, 2, 4)
        Me.tlpGrid.Controls.Add(Me.Button3, 4, 2)
        Me.tlpGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpGrid.Location = New System.Drawing.Point(0, 0)
        Me.tlpGrid.Name = "tlpGrid"
        Me.tlpGrid.Padding = New System.Windows.Forms.Padding(3)
        Me.tlpGrid.RowCount = 5
        Me.tlpGrid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpGrid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpGrid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpGrid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpGrid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpGrid.Size = New System.Drawing.Size(661, 564)
        Me.tlpGrid.TabIndex = 0
        '
        'pbxMap
        '
        Me.pbxMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tlpGrid.SetColumnSpan(Me.pbxMap, 3)
        Me.pbxMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbxMap.Location = New System.Drawing.Point(56, 56)
        Me.pbxMap.Name = "pbxMap"
        Me.tlpGrid.SetRowSpan(Me.pbxMap, 3)
        Me.pbxMap.Size = New System.Drawing.Size(549, 450)
        Me.pbxMap.TabIndex = 0
        Me.pbxMap.TabStop = False
        '
        'btnUp
        '
        Me.btnUp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnUp.BackColor = System.Drawing.Color.Transparent
        Me.btnUp.BackgroundImage = Global.OFM4MGL.My.Resources.Resources.ArrowUp
        Me.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnUp.FlatAppearance.BorderSize = 0
        Me.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUp.Location = New System.Drawing.Point(294, 6)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(72, 44)
        Me.btnUp.TabIndex = 1
        Me.btnUp.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.OFM4MGL.My.Resources.Resources.ArrowLeft
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(6, 259)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(44, 44)
        Me.Button1.TabIndex = 2
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.OFM4MGL.My.Resources.Resources.ArrowDown
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(294, 513)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 44)
        Me.Button2.TabIndex = 3
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.OFM4MGL.My.Resources.Resources.ArrowRight
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(611, 259)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(44, 44)
        Me.Button3.TabIndex = 4
        Me.Button3.UseVisualStyleBackColor = False
        '
        'frmMapView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 564)
        Me.Controls.Add(Me.tlpGrid)
        Me.Name = "frmMapView"
        Me.Text = "Map"
        Me.tlpGrid.ResumeLayout(False)
        CType(Me.pbxMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpGrid As TableLayoutPanel
    Friend WithEvents pbxMap As PictureBox
    Friend WithEvents btnUp As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class
