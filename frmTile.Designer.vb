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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblSaturation = New System.Windows.Forms.Label()
        Me.lblContrast = New System.Windows.Forms.Label()
        Me.lblBrightness = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.tbrBrightness = New System.Windows.Forms.TrackBar()
        Me.tbrSaturation = New System.Windows.Forms.TrackBar()
        Me.tbrContrast = New System.Windows.Forms.TrackBar()
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.pbxTile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.tbrBrightness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbrSaturation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbrContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1216.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.pbxTile, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1169.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1708, 1165)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'pbxTile
        '
        Me.pbxTile.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxTile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbxTile.InitialImage = Global.OFM4MGL.My.Resources.Resources.openflightmaps_logo
        Me.pbxTile.Location = New System.Drawing.Point(498, 6)
        Me.pbxTile.Margin = New System.Windows.Forms.Padding(6)
        Me.pbxTile.Name = "pbxTile"
        Me.pbxTile.Size = New System.Drawing.Size(1204, 1156)
        Me.pbxTile.TabIndex = 0
        Me.pbxTile.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblSaturation)
        Me.Panel2.Controls.Add(Me.lblContrast)
        Me.Panel2.Controls.Add(Me.lblBrightness)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.btnApply)
        Me.Panel2.Controls.Add(Me.btnReset)
        Me.Panel2.Controls.Add(Me.tbrBrightness)
        Me.Panel2.Controls.Add(Me.tbrSaturation)
        Me.Panel2.Controls.Add(Me.tbrContrast)
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
        Me.Panel2.Location = New System.Drawing.Point(206, 6)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(280, 1157)
        Me.Panel2.TabIndex = 1
        '
        'lblSaturation
        '
        Me.lblSaturation.Location = New System.Drawing.Point(96, 853)
        Me.lblSaturation.Name = "lblSaturation"
        Me.lblSaturation.Size = New System.Drawing.Size(89, 25)
        Me.lblSaturation.TabIndex = 4
        Me.lblSaturation.Text = "0"
        Me.lblSaturation.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblContrast
        '
        Me.lblContrast.Location = New System.Drawing.Point(96, 759)
        Me.lblContrast.Name = "lblContrast"
        Me.lblContrast.Size = New System.Drawing.Size(89, 25)
        Me.lblContrast.TabIndex = 4
        Me.lblContrast.Text = "0"
        Me.lblContrast.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBrightness
        '
        Me.lblBrightness.Location = New System.Drawing.Point(90, 666)
        Me.lblBrightness.Name = "lblBrightness"
        Me.lblBrightness.Size = New System.Drawing.Size(100, 23)
        Me.lblBrightness.TabIndex = 4
        Me.lblBrightness.Text = "0"
        Me.lblBrightness.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Location = New System.Drawing.Point(12, 590)
        Me.Label12.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(256, 4)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Label12"
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(170, 921)
        Me.btnApply.Margin = New System.Windows.Forms.Padding(6)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(98, 56)
        Me.btnApply.TabIndex = 2
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(12, 921)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(6)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(98, 56)
        Me.btnReset.TabIndex = 2
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'tbrBrightness
        '
        Me.tbrBrightness.LargeChange = 10
        Me.tbrBrightness.Location = New System.Drawing.Point(0, 625)
        Me.tbrBrightness.Margin = New System.Windows.Forms.Padding(6)
        Me.tbrBrightness.Maximum = 50
        Me.tbrBrightness.Minimum = -50
        Me.tbrBrightness.Name = "tbrBrightness"
        Me.tbrBrightness.Size = New System.Drawing.Size(280, 90)
        Me.tbrBrightness.TabIndex = 1
        Me.tbrBrightness.TickFrequency = 20
        '
        'tbrSaturation
        '
        Me.tbrSaturation.LargeChange = 10
        Me.tbrSaturation.Location = New System.Drawing.Point(0, 813)
        Me.tbrSaturation.Margin = New System.Windows.Forms.Padding(6)
        Me.tbrSaturation.Maximum = 100
        Me.tbrSaturation.Minimum = -100
        Me.tbrSaturation.Name = "tbrSaturation"
        Me.tbrSaturation.Size = New System.Drawing.Size(280, 90)
        Me.tbrSaturation.TabIndex = 1
        Me.tbrSaturation.TickFrequency = 20
        '
        'tbrContrast
        '
        Me.tbrContrast.LargeChange = 10
        Me.tbrContrast.Location = New System.Drawing.Point(0, 719)
        Me.tbrContrast.Margin = New System.Windows.Forms.Padding(6)
        Me.tbrContrast.Maximum = 50
        Me.tbrContrast.Minimum = -50
        Me.tbrContrast.Name = "tbrContrast"
        Me.tbrContrast.Size = New System.Drawing.Size(280, 90)
        Me.tbrContrast.TabIndex = 1
        Me.tbrContrast.TickFrequency = 20
        '
        'lblSize
        '
        Me.lblSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSize.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSize.Location = New System.Drawing.Point(12, 520)
        Me.lblSize.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(254, 33)
        Me.lblSize.TabIndex = 0
        Me.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDump
        '
        Me.lblDump.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDump.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblDump.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDump.Location = New System.Drawing.Point(12, 474)
        Me.lblDump.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblDump.Name = "lblDump"
        Me.lblDump.Size = New System.Drawing.Size(254, 33)
        Me.lblDump.TabIndex = 0
        Me.lblDump.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGIFLen
        '
        Me.lblGIFLen.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGIFLen.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblGIFLen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGIFLen.Location = New System.Drawing.Point(12, 428)
        Me.lblGIFLen.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblGIFLen.Name = "lblGIFLen"
        Me.lblGIFLen.Size = New System.Drawing.Size(254, 33)
        Me.lblGIFLen.TabIndex = 0
        Me.lblGIFLen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPtr
        '
        Me.lblPtr.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPtr.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblPtr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPtr.Location = New System.Drawing.Point(12, 384)
        Me.lblPtr.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblPtr.Name = "lblPtr"
        Me.lblPtr.Size = New System.Drawing.Size(254, 33)
        Me.lblPtr.TabIndex = 0
        Me.lblPtr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPtrAddr
        '
        Me.lblPtrAddr.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPtrAddr.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblPtrAddr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPtrAddr.Location = New System.Drawing.Point(12, 337)
        Me.lblPtrAddr.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblPtrAddr.Name = "lblPtrAddr"
        Me.lblPtrAddr.Size = New System.Drawing.Size(254, 33)
        Me.lblPtrAddr.TabIndex = 0
        Me.lblPtrAddr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPtrIdx
        '
        Me.lblPtrIdx.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPtrIdx.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblPtrIdx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPtrIdx.Location = New System.Drawing.Point(12, 293)
        Me.lblPtrIdx.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblPtrIdx.Name = "lblPtrIdx"
        Me.lblPtrIdx.Size = New System.Drawing.Size(254, 33)
        Me.lblPtrIdx.TabIndex = 0
        Me.lblPtrIdx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblExtent
        '
        Me.lblExtent.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExtent.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblExtent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExtent.Location = New System.Drawing.Point(12, 249)
        Me.lblExtent.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblExtent.Name = "lblExtent"
        Me.lblExtent.Size = New System.Drawing.Size(254, 33)
        Me.lblExtent.TabIndex = 0
        Me.lblExtent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMapName
        '
        Me.lblMapName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMapName.BackColor = System.Drawing.SystemColors.Control
        Me.lblMapName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMapName.Location = New System.Drawing.Point(12, 82)
        Me.lblMapName.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblMapName.Name = "lblMapName"
        Me.lblMapName.Size = New System.Drawing.Size(256, 35)
        Me.lblMapName.TabIndex = 0
        Me.lblMapName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTileFilename
        '
        Me.lblTileFilename.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTileFilename.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTileFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTileFilename.Location = New System.Drawing.Point(12, 153)
        Me.lblTileFilename.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTileFilename.Name = "lblTileFilename"
        Me.lblTileFilename.Size = New System.Drawing.Size(254, 33)
        Me.lblTileFilename.TabIndex = 0
        Me.lblTileFilename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLatLon
        '
        Me.lblLatLon.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLatLon.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblLatLon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLatLon.Location = New System.Drawing.Point(12, 205)
        Me.lblLatLon.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblLatLon.Name = "lblLatLon"
        Me.lblLatLon.Size = New System.Drawing.Size(254, 33)
        Me.lblLatLon.TabIndex = 0
        Me.lblLatLon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(194, 1163)
        Me.Panel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(71, 636)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Brightness:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(92, 730)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Contrast:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(75, 824)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 25)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Saturation:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(121, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 25)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(105, 212)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 25)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Lat/Lon:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(122, 256)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 25)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Width:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(125, 300)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 25)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Index:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(109, 344)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 25)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Pointer:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(95, 391)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 25)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "(Pointer):"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(78, 435)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 25)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "GIF length:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(129, 481)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 25)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Type:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(37, 527)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(158, 25)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Width x Height:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmTile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1708, 1167)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.Name = "frmTile"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Tile"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.pbxTile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.tbrBrightness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbrSaturation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbrContrast, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents pbxTile As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblGIFLen As Label
    Friend WithEvents lblPtr As Label
    Friend WithEvents lblPtrAddr As Label
    Friend WithEvents lblPtrIdx As Label
    Friend WithEvents lblExtent As Label
    Friend WithEvents lblLatLon As Label
    Friend WithEvents lblMapName As Label
    Friend WithEvents lblDump As Label
    Friend WithEvents lblTileFilename As Label
    Friend WithEvents lblSize As Label
    Friend WithEvents tbrContrast As TrackBar
    Friend WithEvents tbrSaturation As TrackBar
    Friend WithEvents tbrBrightness As TrackBar
    Friend WithEvents Label12 As Label
    Friend WithEvents btnApply As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents lblSaturation As Label
    Friend WithEvents lblContrast As Label
    Friend WithEvents lblBrightness As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
End Class
