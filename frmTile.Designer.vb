<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTile))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pbxTile = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblDump = New System.Windows.Forms.Label()
        Me.lblGIFLen = New System.Windows.Forms.Label()
        Me.lblPtr = New System.Windows.Forms.Label()
        Me.lblPtrAddr = New System.Windows.Forms.Label()
        Me.lblPtrIdx = New System.Windows.Forms.Label()
        Me.lblExtent = New System.Windows.Forms.Label()
        Me.lblMapName = New System.Windows.Forms.Label()
        Me.lblTileFilename = New System.Windows.Forms.Label()
        Me.lblLatLon = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.pbxTile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 608.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.pbxTile, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 608.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(854, 606)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'pbxTile
        '
        Me.pbxTile.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxTile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbxTile.InitialImage = Global.OFM4MGL.My.Resources.Resources.openflightmaps_logo
        Me.pbxTile.Location = New System.Drawing.Point(249, 3)
        Me.pbxTile.Name = "pbxTile"
        Me.pbxTile.Size = New System.Drawing.Size(602, 602)
        Me.pbxTile.TabIndex = 0
        Me.pbxTile.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(94, 602)
        Me.Panel1.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label9.Location = New System.Drawing.Point(10, 274)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Width x Height:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(54, 248)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(34, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "@Ptr:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 226)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "GIF length:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(38, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Ptr-value:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ptr-address:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Ptr-index:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Extent:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(38, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Filename:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lat/Lon:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblSize)
        Me.Panel2.Controls.Add(Me.lblDump)
        Me.Panel2.Controls.Add(Me.lblGIFLen)
        Me.Panel2.Controls.Add(Me.lblPtr)
        Me.Panel2.Controls.Add(Me.lblPtrAddr)
        Me.Panel2.Controls.Add(Me.lblPtrIdx)
        Me.Panel2.Controls.Add(Me.lblExtent)
        Me.Panel2.Controls.Add(Me.lblMapName)
        Me.Panel2.Controls.Add(Me.lblTileFilename)
        Me.Panel2.Controls.Add(Me.lblLatLon)
        Me.Panel2.Location = New System.Drawing.Point(103, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(140, 602)
        Me.Panel2.TabIndex = 1
        '
        'lblSize
        '
        Me.lblSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSize.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSize.Location = New System.Drawing.Point(6, 271)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(128, 18)
        Me.lblSize.TabIndex = 0
        Me.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDump
        '
        Me.lblDump.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDump.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblDump.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDump.Location = New System.Drawing.Point(6, 247)
        Me.lblDump.Name = "lblDump"
        Me.lblDump.Size = New System.Drawing.Size(128, 18)
        Me.lblDump.TabIndex = 0
        Me.lblDump.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGIFLen
        '
        Me.lblGIFLen.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGIFLen.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblGIFLen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGIFLen.Location = New System.Drawing.Point(6, 223)
        Me.lblGIFLen.Name = "lblGIFLen"
        Me.lblGIFLen.Size = New System.Drawing.Size(128, 18)
        Me.lblGIFLen.TabIndex = 0
        Me.lblGIFLen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPtr
        '
        Me.lblPtr.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPtr.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblPtr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPtr.Location = New System.Drawing.Point(6, 200)
        Me.lblPtr.Name = "lblPtr"
        Me.lblPtr.Size = New System.Drawing.Size(128, 18)
        Me.lblPtr.TabIndex = 0
        Me.lblPtr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPtrAddr
        '
        Me.lblPtrAddr.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPtrAddr.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblPtrAddr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPtrAddr.Location = New System.Drawing.Point(6, 176)
        Me.lblPtrAddr.Name = "lblPtrAddr"
        Me.lblPtrAddr.Size = New System.Drawing.Size(128, 18)
        Me.lblPtrAddr.TabIndex = 0
        Me.lblPtrAddr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPtrIdx
        '
        Me.lblPtrIdx.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPtrIdx.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblPtrIdx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPtrIdx.Location = New System.Drawing.Point(6, 153)
        Me.lblPtrIdx.Name = "lblPtrIdx"
        Me.lblPtrIdx.Size = New System.Drawing.Size(128, 18)
        Me.lblPtrIdx.TabIndex = 0
        Me.lblPtrIdx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblExtent
        '
        Me.lblExtent.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExtent.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblExtent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExtent.Location = New System.Drawing.Point(6, 130)
        Me.lblExtent.Name = "lblExtent"
        Me.lblExtent.Size = New System.Drawing.Size(128, 18)
        Me.lblExtent.TabIndex = 0
        Me.lblExtent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMapName
        '
        Me.lblMapName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMapName.BackColor = System.Drawing.SystemColors.Control
        Me.lblMapName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMapName.Location = New System.Drawing.Point(6, 43)
        Me.lblMapName.Name = "lblMapName"
        Me.lblMapName.Size = New System.Drawing.Size(128, 18)
        Me.lblMapName.TabIndex = 0
        Me.lblMapName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTileFilename
        '
        Me.lblTileFilename.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTileFilename.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTileFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTileFilename.Location = New System.Drawing.Point(6, 80)
        Me.lblTileFilename.Name = "lblTileFilename"
        Me.lblTileFilename.Size = New System.Drawing.Size(128, 18)
        Me.lblTileFilename.TabIndex = 0
        Me.lblTileFilename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLatLon
        '
        Me.lblLatLon.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLatLon.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblLatLon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLatLon.Location = New System.Drawing.Point(6, 107)
        Me.lblLatLon.Name = "lblLatLon"
        Me.lblLatLon.Size = New System.Drawing.Size(128, 18)
        Me.lblLatLon.TabIndex = 0
        Me.lblLatLon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmTile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 607)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmTile"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Tile"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.pbxTile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents pbxTile As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblGIFLen As Label
    Friend WithEvents lblPtr As Label
    Friend WithEvents lblPtrAddr As Label
    Friend WithEvents lblPtrIdx As Label
    Friend WithEvents lblExtent As Label
    Friend WithEvents lblLatLon As Label
    Friend WithEvents lblMapName As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblDump As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblTileFilename As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblSize As Label
End Class
