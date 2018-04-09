<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.mnuStrip = New System.Windows.Forms.MenuStrip()
        Me.mnuMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGenerateMap = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAssembleMap = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExtractTiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDisplayCoverage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtBRLat = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtTLLat = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBRLon = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTLLon = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblMapHeader = New System.Windows.Forms.Label()
        Me.gbxDGVZoom = New System.Windows.Forms.GroupBox()
        Me.rdo4M = New System.Windows.Forms.RadioButton()
        Me.rdo2M = New System.Windows.Forms.RadioButton()
        Me.rdo1M = New System.Windows.Forms.RadioButton()
        Me.rdo500k = New System.Windows.Forms.RadioButton()
        Me.rdo250k = New System.Windows.Forms.RadioButton()
        Me.dgvMap = New System.Windows.Forms.DataGridView()
        Me.gbxMapScales = New System.Windows.Forms.GroupBox()
        Me.chk3 = New System.Windows.Forms.CheckBox()
        Me.chk2 = New System.Windows.Forms.CheckBox()
        Me.chk1 = New System.Windows.Forms.CheckBox()
        Me.chk0 = New System.Windows.Forms.CheckBox()
        Me.pbxLogo = New System.Windows.Forms.PictureBox()
        Me.myStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.myProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblCopyright = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pbxGlobe = New System.Windows.Forms.PictureBox()
        Me.myTimer = New System.Windows.Forms.Timer(Me.components)
        Me.mnuStrip.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.gbxDGVZoom.SuspendLayout()
        CType(Me.dgvMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxMapScales.SuspendLayout()
        CType(Me.pbxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.myStatusStrip.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.pbxGlobe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuStrip
        '
        Me.mnuStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.mnuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMenu})
        Me.mnuStrip.Location = New System.Drawing.Point(0, 0)
        Me.mnuStrip.Name = "mnuStrip"
        Me.mnuStrip.Padding = New System.Windows.Forms.Padding(12, 4, 0, 4)
        Me.mnuStrip.Size = New System.Drawing.Size(1492, 44)
        Me.mnuStrip.TabIndex = 7
        Me.mnuStrip.Text = "MenuStrip1"
        '
        'mnuMenu
        '
        Me.mnuMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGenerateMap, Me.mnuAssembleMap, Me.mnuExtractTiles, Me.mnuDisplayCoverage, Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripSeparator2, Me.mnuSettings, Me.mnuHelp, Me.mnuAbout, Me.ToolStripSeparator1, Me.mnuExit})
        Me.mnuMenu.Name = "mnuMenu"
        Me.mnuMenu.Size = New System.Drawing.Size(90, 36)
        Me.mnuMenu.Text = "Menu"
        '
        'mnuGenerateMap
        '
        Me.mnuGenerateMap.Name = "mnuGenerateMap"
        Me.mnuGenerateMap.Size = New System.Drawing.Size(369, 38)
        Me.mnuGenerateMap.Text = "Generate Map..."
        '
        'mnuAssembleMap
        '
        Me.mnuAssembleMap.Name = "mnuAssembleMap"
        Me.mnuAssembleMap.Size = New System.Drawing.Size(369, 38)
        Me.mnuAssembleMap.Text = "Assemble Map..."
        '
        'mnuExtractTiles
        '
        Me.mnuExtractTiles.Name = "mnuExtractTiles"
        Me.mnuExtractTiles.Size = New System.Drawing.Size(369, 38)
        Me.mnuExtractTiles.Text = "Extract Tiles..."
        '
        'mnuDisplayCoverage
        '
        Me.mnuDisplayCoverage.Name = "mnuDisplayCoverage"
        Me.mnuDisplayCoverage.Size = New System.Drawing.Size(369, 38)
        Me.mnuDisplayCoverage.Text = "Display Map Coverage..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(366, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(369, 38)
        Me.ToolStripMenuItem2.Text = "Clear TIle Cache"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(366, 6)
        '
        'mnuSettings
        '
        Me.mnuSettings.Name = "mnuSettings"
        Me.mnuSettings.Size = New System.Drawing.Size(369, 38)
        Me.mnuSettings.Text = "Settings..."
        '
        'mnuHelp
        '
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(369, 38)
        Me.mnuHelp.Text = "Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(369, 38)
        Me.mnuAbout.Text = "About"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(366, 6)
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(369, 38)
        Me.mnuExit.Text = "Exit"
        '
        'dlgOpenFile
        '
        Me.dlgOpenFile.FileName = "MGL*.gif"
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.FlowLayoutPanel4.Controls.Add(Me.txtBRLat)
        Me.FlowLayoutPanel4.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(282, 687)
        Me.FlowLayoutPanel4.Margin = New System.Windows.Forms.Padding(6)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(100, 88)
        Me.FlowLayoutPanel4.TabIndex = 20
        '
        'txtBRLat
        '
        Me.txtBRLat.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtBRLat.Location = New System.Drawing.Point(6, 6)
        Me.txtBRLat.Margin = New System.Windows.Forms.Padding(6)
        Me.txtBRLat.Name = "txtBRLat"
        Me.txtBRLat.Size = New System.Drawing.Size(72, 31)
        Me.txtBRLat.TabIndex = 1
        Me.txtBRLat.Text = "-34"
        Me.txtBRLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 43)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 25)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Lat (°)"
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.FlowLayoutPanel3.Controls.Add(Me.txtTLLat)
        Me.FlowLayoutPanel3.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(282, 218)
        Me.FlowLayoutPanel3.Margin = New System.Windows.Forms.Padding(6)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(100, 88)
        Me.FlowLayoutPanel3.TabIndex = 20
        '
        'txtTLLat
        '
        Me.txtTLLat.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTLLat.Location = New System.Drawing.Point(6, 51)
        Me.txtTLLat.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTLLat.Name = "txtTLLat"
        Me.txtTLLat.Size = New System.Drawing.Size(70, 31)
        Me.txtTLLat.TabIndex = 0
        Me.txtTLLat.Text = "-32"
        Me.txtTLLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Lat (°)"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FlowLayoutPanel2.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel2.Controls.Add(Me.txtBRLon)
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(530, 439)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(6)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(118, 115)
        Me.FlowLayoutPanel2.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Lon (°)"
        '
        'txtBRLon
        '
        Me.txtBRLon.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtBRLon.Location = New System.Drawing.Point(6, 31)
        Me.txtBRLon.Margin = New System.Windows.Forms.Padding(6)
        Me.txtBRLon.Name = "txtBRLon"
        Me.txtBRLon.Size = New System.Drawing.Size(64, 31)
        Me.txtBRLon.TabIndex = 3
        Me.txtBRLon.Text = "156"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtTLLon)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(30, 439)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(6)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(104, 115)
        Me.FlowLayoutPanel1.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 25)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Lon (°)"
        '
        'txtTLLon
        '
        Me.txtTLLon.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtTLLon.Location = New System.Drawing.Point(18, 31)
        Me.txtTLLon.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTLLon.Name = "txtTLLon"
        Me.txtTLLon.Size = New System.Drawing.Size(64, 31)
        Me.txtTLLon.TabIndex = 2
        Me.txtTLLon.Text = "154"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(530, 938)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(6)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(142, 40)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblMapHeader
        '
        Me.lblMapHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMapHeader.AutoSize = True
        Me.lblMapHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMapHeader.Location = New System.Drawing.Point(684, 120)
        Me.lblMapHeader.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblMapHeader.Name = "lblMapHeader"
        Me.lblMapHeader.Size = New System.Drawing.Size(792, 36)
        Me.lblMapHeader.TabIndex = 18
        Me.lblMapHeader.Text = "Tiles in Map"
        Me.lblMapHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbxDGVZoom
        '
        Me.gbxDGVZoom.Controls.Add(Me.rdo4M)
        Me.gbxDGVZoom.Controls.Add(Me.rdo2M)
        Me.gbxDGVZoom.Controls.Add(Me.rdo1M)
        Me.gbxDGVZoom.Controls.Add(Me.rdo500k)
        Me.gbxDGVZoom.Controls.Add(Me.rdo250k)
        Me.gbxDGVZoom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxDGVZoom.Enabled = False
        Me.gbxDGVZoom.Location = New System.Drawing.Point(684, 908)
        Me.gbxDGVZoom.Margin = New System.Windows.Forms.Padding(6)
        Me.gbxDGVZoom.Name = "gbxDGVZoom"
        Me.gbxDGVZoom.Padding = New System.Windows.Forms.Padding(6)
        Me.gbxDGVZoom.Size = New System.Drawing.Size(792, 100)
        Me.gbxDGVZoom.TabIndex = 17
        Me.gbxDGVZoom.TabStop = False
        Me.gbxDGVZoom.Text = "Scale"
        '
        'rdo4M
        '
        Me.rdo4M.AutoSize = True
        Me.rdo4M.Location = New System.Drawing.Point(490, 42)
        Me.rdo4M.Margin = New System.Windows.Forms.Padding(6)
        Me.rdo4M.Name = "rdo4M"
        Me.rdo4M.Size = New System.Drawing.Size(91, 29)
        Me.rdo4M.TabIndex = 0
        Me.rdo4M.TabStop = True
        Me.rdo4M.Tag = "7"
        Me.rdo4M.Text = "1:4M"
        Me.rdo4M.UseVisualStyleBackColor = True
        '
        'rdo2M
        '
        Me.rdo2M.AutoSize = True
        Me.rdo2M.Location = New System.Drawing.Point(380, 44)
        Me.rdo2M.Margin = New System.Windows.Forms.Padding(6)
        Me.rdo2M.Name = "rdo2M"
        Me.rdo2M.Size = New System.Drawing.Size(91, 29)
        Me.rdo2M.TabIndex = 0
        Me.rdo2M.TabStop = True
        Me.rdo2M.Tag = "8"
        Me.rdo2M.Text = "1:2M"
        Me.rdo2M.UseVisualStyleBackColor = True
        '
        'rdo1M
        '
        Me.rdo1M.AutoSize = True
        Me.rdo1M.Location = New System.Drawing.Point(270, 44)
        Me.rdo1M.Margin = New System.Windows.Forms.Padding(6)
        Me.rdo1M.Name = "rdo1M"
        Me.rdo1M.Size = New System.Drawing.Size(91, 29)
        Me.rdo1M.TabIndex = 0
        Me.rdo1M.TabStop = True
        Me.rdo1M.Tag = "9"
        Me.rdo1M.Text = "1:1M"
        Me.rdo1M.UseVisualStyleBackColor = True
        '
        'rdo500k
        '
        Me.rdo500k.AutoSize = True
        Me.rdo500k.Checked = True
        Me.rdo500k.Location = New System.Drawing.Point(142, 42)
        Me.rdo500k.Margin = New System.Windows.Forms.Padding(6)
        Me.rdo500k.Name = "rdo500k"
        Me.rdo500k.Size = New System.Drawing.Size(108, 29)
        Me.rdo500k.TabIndex = 0
        Me.rdo500k.TabStop = True
        Me.rdo500k.Tag = "10"
        Me.rdo500k.Text = "1:500k"
        Me.rdo500k.UseVisualStyleBackColor = True
        '
        'rdo250k
        '
        Me.rdo250k.AutoSize = True
        Me.rdo250k.Location = New System.Drawing.Point(22, 44)
        Me.rdo250k.Margin = New System.Windows.Forms.Padding(6)
        Me.rdo250k.Name = "rdo250k"
        Me.rdo250k.Size = New System.Drawing.Size(108, 29)
        Me.rdo250k.TabIndex = 0
        Me.rdo250k.TabStop = True
        Me.rdo250k.Tag = "11"
        Me.rdo250k.Text = "1:256k"
        Me.rdo250k.UseVisualStyleBackColor = True
        '
        'dgvMap
        '
        Me.dgvMap.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvMap.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMap.Location = New System.Drawing.Point(684, 162)
        Me.dgvMap.Margin = New System.Windows.Forms.Padding(6)
        Me.dgvMap.MultiSelect = False
        Me.dgvMap.Name = "dgvMap"
        Me.TableLayoutPanel1.SetRowSpan(Me.dgvMap, 3)
        Me.dgvMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvMap.Size = New System.Drawing.Size(792, 734)
        Me.dgvMap.TabIndex = 16
        '
        'gbxMapScales
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.gbxMapScales, 2)
        Me.gbxMapScales.Controls.Add(Me.chk3)
        Me.gbxMapScales.Controls.Add(Me.chk2)
        Me.gbxMapScales.Controls.Add(Me.chk1)
        Me.gbxMapScales.Controls.Add(Me.chk0)
        Me.gbxMapScales.Location = New System.Drawing.Point(16, 908)
        Me.gbxMapScales.Margin = New System.Windows.Forms.Padding(6)
        Me.gbxMapScales.Name = "gbxMapScales"
        Me.gbxMapScales.Padding = New System.Windows.Forms.Padding(6)
        Me.gbxMapScales.Size = New System.Drawing.Size(468, 100)
        Me.gbxMapScales.TabIndex = 15
        Me.gbxMapScales.TabStop = False
        Me.gbxMapScales.Text = "Scales to generate:"
        '
        'chk3
        '
        Me.chk3.AutoSize = True
        Me.chk3.Location = New System.Drawing.Point(356, 37)
        Me.chk3.Margin = New System.Windows.Forms.Padding(6)
        Me.chk3.Name = "chk3"
        Me.chk3.Size = New System.Drawing.Size(92, 29)
        Me.chk3.TabIndex = 3
        Me.chk3.Tag = "8"
        Me.chk3.Text = "1:2M"
        Me.chk3.UseVisualStyleBackColor = True
        '
        'chk2
        '
        Me.chk2.AutoSize = True
        Me.chk2.Location = New System.Drawing.Point(256, 38)
        Me.chk2.Margin = New System.Windows.Forms.Padding(6)
        Me.chk2.Name = "chk2"
        Me.chk2.Size = New System.Drawing.Size(92, 29)
        Me.chk2.TabIndex = 2
        Me.chk2.Tag = "9"
        Me.chk2.Text = "1:1M"
        Me.chk2.UseVisualStyleBackColor = True
        '
        'chk1
        '
        Me.chk1.AutoSize = True
        Me.chk1.Checked = True
        Me.chk1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk1.Location = New System.Drawing.Point(126, 38)
        Me.chk1.Margin = New System.Windows.Forms.Padding(6)
        Me.chk1.Name = "chk1"
        Me.chk1.Size = New System.Drawing.Size(109, 29)
        Me.chk1.TabIndex = 1
        Me.chk1.Tag = "10"
        Me.chk1.Text = "1:500k"
        Me.chk1.UseVisualStyleBackColor = True
        '
        'chk0
        '
        Me.chk0.AutoSize = True
        Me.chk0.Location = New System.Drawing.Point(14, 38)
        Me.chk0.Margin = New System.Windows.Forms.Padding(6)
        Me.chk0.Name = "chk0"
        Me.chk0.Size = New System.Drawing.Size(109, 29)
        Me.chk0.TabIndex = 0
        Me.chk0.Tag = "11"
        Me.chk0.Text = "1:256k"
        Me.chk0.UseVisualStyleBackColor = True
        '
        'pbxLogo
        '
        Me.pbxLogo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.pbxLogo, 3)
        Me.pbxLogo.Image = CType(resources.GetObject("pbxLogo.Image"), System.Drawing.Image)
        Me.pbxLogo.Location = New System.Drawing.Point(10, 0)
        Me.pbxLogo.Margin = New System.Windows.Forms.Padding(0)
        Me.pbxLogo.MaximumSize = New System.Drawing.Size(764, 156)
        Me.pbxLogo.Name = "pbxLogo"
        Me.pbxLogo.Size = New System.Drawing.Size(668, 156)
        Me.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxLogo.TabIndex = 11
        Me.pbxLogo.TabStop = False
        '
        'myStatusStrip
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.myStatusStrip, 4)
        Me.myStatusStrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.myStatusStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.myStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.myProgressBar, Me.lblCopyright})
        Me.myStatusStrip.Location = New System.Drawing.Point(10, 1014)
        Me.myStatusStrip.Name = "myStatusStrip"
        Me.myStatusStrip.Padding = New System.Windows.Forms.Padding(2, 0, 28, 0)
        Me.myStatusStrip.Size = New System.Drawing.Size(1472, 73)
        Me.myStatusStrip.TabIndex = 9
        Me.myStatusStrip.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(751, 68)
        Me.lblStatus.Spring = True
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'myProgressBar
        '
        Me.myProgressBar.Name = "myProgressBar"
        Me.myProgressBar.Size = New System.Drawing.Size(500, 67)
        Me.myProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'lblCopyright
        '
        Me.lblCopyright.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lblCopyright.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(189, 68)
        Me.lblCopyright.Text = "(c) C. Kurz, 2018"
        Me.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 384.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.myStatusStrip, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.pbxLogo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.gbxMapScales, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvMap, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.gbxDGVZoom, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMapHeader, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel3, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel4, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.pbxGlobe, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 44)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 156.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 369.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1492, 1087)
        Me.TableLayoutPanel1.TabIndex = 8
        '
        'pbxGlobe
        '
        Me.pbxGlobe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbxGlobe.Image = Global.OFM4MGL.My.Resources.Resources.Globe_stopped
        Me.pbxGlobe.Location = New System.Drawing.Point(146, 318)
        Me.pbxGlobe.Margin = New System.Windows.Forms.Padding(6)
        Me.pbxGlobe.Name = "pbxGlobe"
        Me.pbxGlobe.Size = New System.Drawing.Size(372, 357)
        Me.pbxGlobe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxGlobe.TabIndex = 21
        Me.pbxGlobe.TabStop = False
        '
        'myTimer
        '
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1492, 1131)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.mnuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuStrip
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "frmMain"
        Me.Text = "OFM-to-MGL Import"
        Me.mnuStrip.ResumeLayout(False)
        Me.mnuStrip.PerformLayout()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel4.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.gbxDGVZoom.ResumeLayout(False)
        Me.gbxDGVZoom.PerformLayout()
        CType(Me.dgvMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxMapScales.ResumeLayout(False)
        Me.gbxMapScales.PerformLayout()
        CType(Me.pbxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.myStatusStrip.ResumeLayout(False)
        Me.myStatusStrip.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.pbxGlobe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    'Friend WithEvents btnTest As Button
    Friend WithEvents mnuStrip As MenuStrip
    Friend WithEvents mnuMenu As ToolStripMenuItem
    Friend WithEvents mnuAssembleMap As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnuSettings As ToolStripMenuItem
    Friend WithEvents mnuHelp As ToolStripMenuItem
    Friend WithEvents mnuAbout As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents dlgOpenFile As OpenFileDialog
    Friend WithEvents mnuExtractTiles As ToolStripMenuItem
    Friend WithEvents mnuDisplayCoverage As ToolStripMenuItem
    Friend WithEvents mnuGenerateMap As ToolStripMenuItem
    Friend WithEvents FlowLayoutPanel4 As FlowLayoutPanel
    Friend WithEvents txtBRLat As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents txtTLLat As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBRLon As TextBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTLLon As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblMapHeader As Label
    Friend WithEvents gbxDGVZoom As GroupBox
    Friend WithEvents rdo4M As RadioButton
    Friend WithEvents rdo2M As RadioButton
    Friend WithEvents rdo1M As RadioButton
    Friend WithEvents rdo500k As RadioButton
    Friend WithEvents rdo250k As RadioButton
    Friend WithEvents dgvMap As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents myStatusStrip As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents myProgressBar As ToolStripProgressBar
    Friend WithEvents lblCopyright As ToolStripStatusLabel
    Friend WithEvents pbxLogo As PictureBox
    Friend WithEvents gbxMapScales As GroupBox
    Friend WithEvents chk3 As CheckBox
    Friend WithEvents chk2 As CheckBox
    Friend WithEvents chk1 As CheckBox
    Friend WithEvents chk0 As CheckBox
    Friend WithEvents pbxGlobe As PictureBox
    Friend WithEvents myTimer As Timer
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
End Class
