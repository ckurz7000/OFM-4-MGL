Option Explicit On

Imports System.ComponentModel
Imports JeremyAnsel.ColorQuant

Public Class frmMain

    Private OFMTILEWIDTH As Integer = -1
    '    Private widthLists As New List(Of List(Of Integer))
    Private MapDict As New Dictionary(Of String, MGLMap)
    Private bMapLoaded As Boolean = False
    Private aMapToDisplayTheCoverage As MGLMap
    Private myCancellationTokenSource As Threading.CancellationTokenSource

#Region "Event Handlers"
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Set the status message.
        lblStatus.Text = "Initializing..."

        myTimer.Stop()

        OFMTILEWIDTH = My.Settings.TileSize

        'Load geographical bounds of last session.
        txtTLLat.Text = My.Settings.TLLat
        txtTLLon.Text = My.Settings.TLLon
        txtBRLat.Text = My.Settings.BRLat
        txtBRLon.Text = My.Settings.BRLon

        lblStatus.Text = "Ready."

    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.TLLat = txtTLLat.Text
        My.Settings.TLLon = txtTLLon.Text
        My.Settings.BRLat = txtBRLat.Text
        My.Settings.BRLon = txtBRLon.Text
        My.Settings.Save()
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtTLLon.Focus()
    End Sub

    Private Sub myTimer_Tick(sender As Object, e As EventArgs) Handles myTimer.Tick
        'At each tick count the number of tiles in the tile cache and update the progress bar.
        myProgressBar.Value = ParallelDownload.TilesDownloaded
        lblStatus.Text = "Downloaded " & myProgressBar.Value & " of " & myProgressBar.Maximum & " tiles."
    End Sub

    Private Sub rdo250k_CheckedChanged(sender As Object, e As EventArgs) Handles rdo250k.CheckedChanged,
                                                                                 rdo500k.CheckedChanged,
                                                                                 rdo1M.CheckedChanged,
                                                                                 rdo2M.CheckedChanged,
                                                                                 rdo4M.CheckedChanged
        If bMapLoaded Then
            Dim zoom As Integer = gbxDGVZoom.Controls.OfType(Of RadioButton).FirstOrDefault(Function(radioButton) radioButton.Checked).Tag
            MGLMap.DisplayMap(aMapToDisplayTheCoverage, zoom, dgvMap)
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        myCancellationTokenSource.Cancel()
        btnCancel.Enabled = False
    End Sub

    Private Sub dgvMap_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMap.CellClick
        'Find out if the tile is part of the MAP file.

        frmTile.zoom = gbxDGVZoom.Controls.OfType(Of RadioButton).FirstOrDefault(Function(radioButton) radioButton.Checked).Tag
        frmTile.strMapFilename = aMapToDisplayTheCoverage.Path & "\" & aMapToDisplayTheCoverage.GetName
        frmTile.ptCell = New Point(e.ColumnIndex, e.RowIndex)

        If Application.OpenForms.OfType(Of frmTile).Count > 0 Then 'frmTile is already shown.
            frmTile.Invalidate()
        Else
            frmTile.Show()
        End If
    End Sub

    Private Sub dgvMap_RowPrePaint(ByVal sender As Object, ByVal e As DataGridViewRowPrePaintEventArgs) Handles dgvMap.RowPrePaint
        'Supress the painting of the record marquee in the row header column.
        e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All)
        e.PaintHeader(DataGridViewPaintParts.Background Or
                      DataGridViewPaintParts.Border Or
                      DataGridViewPaintParts.Focus Or
                      DataGridViewPaintParts.SelectionBackground Or
                      DataGridViewPaintParts.ContentForeground)
        e.Handled = True
    End Sub

#End Region

#Region "Utility"
    Private Sub LatLon2TileXY(ByVal Lat As Double,
                              ByVal Lon As Double,
                              ByVal Zoom As Integer,
                              ByRef XTile As Long,
                              ByRef YTile As Long)
        Dim z As Long = 2 ^ Zoom
        Dim LatRad As Double = Lat * Math.PI / 180

        XTile = Math.Floor(z * ((Lon + 180) / 360))
        YTile = Math.Floor(z * (1 - Math.Log(Math.Tan(LatRad) + 1 / Math.Cos(LatRad)) / Math.PI) / 2)

    End Sub

    Private Sub TileXY2LatLon(ByVal TileX As Long,
                              ByVal TileY As Long,
                              ByVal zoom As Double,
                              ByRef LatUL As Double,
                              ByRef LonUL As Double)
        Dim z As Long = 2 ^ zoom

        LatUL = Math.Atan(Math.Sinh(Math.PI * (1 - 2 * TileY / z))) * 180 / Math.PI   'ATAN( SINH( PI* (1-2*E4/(2^E5)) ) )*180/PI
        LonUL = TileX / z * 360 - 180

    End Sub

    Private Sub LatLon2Pixel(ByVal Lat As Double,
                             ByVal Lon As Double,
                             ByVal zoom As Integer,
                             ByRef pxX As Long,
                             ByRef pxY As Long)
        Dim z As Long = 2 ^ zoom
        Dim sinLat As Double = Math.Sin(Lat * Math.PI / 180)

        pxY = CLng((0.5 - Math.Log((1 + sinLat) / (1 - sinLat)) / (4 * Math.PI)) * (OFMTILEWIDTH * z))    '(0,5 - LN( (1+sinLat) / (1-sinLat) ) / (4*PI)) * (256*z)
        pxX = CLng((OFMTILEWIDTH * z) * ((Lon + 180) / 360))  '(256*z)*((H4+180)/360)

    End Sub

    Private Function AssembleMGLTile(ByVal TLLat As Single, ByVal TLLon As Single, ByVal zoom As Integer) As Bitmap
        'Returns the MGL-tile with coordinates TLLat/TLLon at the given zoom level.
        'All required map tiles are assembled to a "BigTile", which contains the MGL-tile.
        'Then the excess around the border of the MGL-tile is trimmed and the MGL-tile scaled to the required size and returned.

        Dim extent As Single = MGLMap.MGLExtent(zoom)
        Dim TLx, TLy As Long : Call LatLon2TileXY(TLLat, TLLon, zoom, TLx, TLy)
        Dim BRx, BRy As Long : Call LatLon2TileXY(TLLat - extent, TLLon + extent, zoom, BRx, BRy)

        Dim BigTile As New Bitmap(CInt(BRx - TLx + 1) * OFMTILEWIDTH, CInt(BRy - TLy + 1) * OFMTILEWIDTH)
        Dim g As Graphics = Graphics.FromImage(BigTile)

        'Assemble all map tiles that are part of the MGL tile into "BigTile"
        For y As Long = TLy To BRy
            For x As Long = TLx To BRx
                Using aTile As Bitmap = New Bitmap(My.Settings.TilesPath & CStr(zoom) & "_" & x & "_" & y & ".png")
                    g.DrawImage(aTile, (x - TLx) * OFMTILEWIDTH, (y - TLy) * OFMTILEWIDTH, OFMTILEWIDTH, OFMTILEWIDTH)
                End Using
            Next
        Next

        'Trim the excess space around the MGL tile borders.
        Dim pxTLX0 As Long = TLx * OFMTILEWIDTH  'pixel coordinate of the TL corner of BigTile in the "world bitmap".
        Dim pxTLY0 As Long = TLy * OFMTILEWIDTH
        Dim pxTLX As Long   'pixel coordinate of the TL corner of the MGL-Tile in aBitmap.
        Dim pxTLY As Long
        Dim pxBRX As Long   'pixel coordinate of the BR corner of the MGL-Tile in aBitmap.
        Dim pxBRY As Long

        Call LatLon2Pixel(TLLat, TLLon, zoom, pxTLX, pxTLY) 'pxTLX/pxTLY are pixel coordinates for the TL corner of the MGL tile.
        pxTLX = pxTLX - pxTLX0
        pxTLY = pxTLY - pxTLY0

        Call LatLon2Pixel(TLLat - extent, TLLon + extent, zoom, pxBRX, pxBRY) 'pxBRX/pxBRY are pixel coordinates for the BR corner of the MGL tile.
        pxBRX = pxBRX - pxTLX0
        pxBRY = pxBRY - pxTLY0

        'Create bitmap of correct size for MGL tile and copy-scale the correct portion of aBitmap to that bitmap.
        'Dim TileWidth As Integer = widthLists(zoom - 7)((90 - TLLat) / extent)
        Dim TileWidth As Integer = OFM4MGL.MGLTile.TileWidth(TLLat, extent)

        Dim MGLTile As New Bitmap(TileWidth, 600)
        g = Graphics.FromImage(MGLTile)
        g.DrawImage(BigTile,
                    New Rectangle(0, 0, MGLTile.Width, MGLTile.Height),
                    New Rectangle(pxTLX, pxTLY, pxBRX - pxTLX, pxBRY - pxTLY),
                    GraphicsUnit.Pixel)

        g.Dispose()
        BigTile.Dispose()

        Return MGLTile

    End Function

    Private Function PNG2GIF(ByVal strPNGFilename As String) As Bitmap

        'Load the PNG, lock it in memory and copy it to a byte array.
        Dim bmpPNG As New Bitmap(strPNGFilename)
        Dim bmpPNGData As Imaging.BitmapData = bmpPNG.LockBits(New Rectangle(0, 0, bmpPNG.Width, bmpPNG.Height), Imaging.ImageLockMode.ReadOnly, Imaging.PixelFormat.Format32bppArgb)
        Dim nPNGBytes As ULong = Math.Abs(bmpPNG.Width * 4) * bmpPNG.Height
        Dim PNGBytes(nPNGBytes - 1) As Byte
        For line As Integer = 0 To bmpPNG.Height - 1
            Runtime.InteropServices.Marshal.Copy(bmpPNGData.Scan0 + line * bmpPNGData.Stride, PNGBytes, line * bmpPNG.Width * 4, bmpPNGData.Width * 4)
        Next
        bmpPNG.UnlockBits(bmpPNGData)

        Dim qResult As ColorQuantizerResult = New WuColorQuantizer().Quantize(PNGBytes, My.Settings.nColors)

        'Generate color table from qResult.Palette
        Dim bmpGIF As New Bitmap(bmpPNG.Width, bmpPNG.Height, Imaging.PixelFormat.Format8bppIndexed)
        Dim cTable As Imaging.ColorPalette = bmpGIF.Palette
        For i As Integer = 0 To qResult.Palette.Count / 4 - 1
            cTable.Entries(i) = Color.FromArgb(qResult.Palette(i * 4 + 3), qResult.Palette(i * 4 + 2), qResult.Palette(i * 4 + 1), qResult.Palette(i * 4))
        Next i

        'Make the quantized byte array into a GIF
        Dim bmpGIFData As Imaging.BitmapData = bmpGIF.LockBits(New Rectangle(0, 0, bmpPNG.Width, bmpPNG.Height), Imaging.ImageLockMode.WriteOnly, Imaging.PixelFormat.Format8bppIndexed)
        For line As Integer = 0 To bmpGIF.Height - 1
            Runtime.InteropServices.Marshal.Copy(qResult.Bytes, line * bmpGIF.Width, bmpGIFData.Scan0 + line * bmpGIFData.Stride, bmpGIF.Width)
        Next
        bmpGIF.UnlockBits(bmpGIFData)
        bmpGIF.Palette = cTable

        bmpPNG.Dispose()

        Return bmpGIF

    End Function

    Private Sub DeleteGCEBlock(strFilename As String)
        'Deletes an optionally present Graphics Control Extension block in the GIF data stream
        'in order to conform to GIF87a standard.

        Dim buffer() As Byte
        Using aFilestream As New IO.FileStream(strFilename, IO.FileMode.Open)
            Using aMemorystream As New IO.MemoryStream()
                aFilestream.CopyTo(aMemorystream)
                buffer = aMemorystream.ToArray
            End Using
        End Using

        'Change the header for GIF87a instead of GIF89a.
        buffer(4) = Asc(7)

        Dim PackedByte As Byte = buffer(10)
        Dim ColorTableSize As Integer = 2 ^ ((PackedByte And 7) + 1) * 3
        Dim idx As Long = 0
        If PackedByte > &H80 Then
            'global color table present.
            idx = 6 + 7 + ColorTableSize
        Else
            idx = 6 + 7
        End If
        Using aFilestream As New IO.FileStream(strFilename, IO.FileMode.Create)
            If buffer(idx) = &H21 AndAlso buffer(idx + 1) = &HF9 AndAlso buffer(idx + 2) = &H4 Then
                'We found a Graphics Control Extension Block starting at position idx and extending for 8 bytes, so remove it.
                aFilestream.Write(buffer, 0, idx)
                aFilestream.Write(buffer, idx + 8, buffer.Length - (idx + 8))
            Else
                aFilestream.Write(buffer, 0, buffer.Count)
            End If
        End Using

    End Sub

    Private Sub AssembleMap()
        'Assembles the generated MGL-tiles into one or more maps.

        For Each chk As CheckBox In gbxMapScales.Controls
            If chk.Checked Then
                Dim extent As Single = MGLMap.MGLExtent(chk.Tag)
                For Lat As Single = txtTLLat.Text To txtBRLat.Text + extent Step -extent
                    For Lon As Single = txtTLLon.Text To txtBRLon.Text - extent Step extent
                        Dim zoom As Integer = chk.Tag
                        Dim MGLTilePath As String = My.Settings.TilesPath & "MGL_" & zoom & "_" & Lat & "_" & Lon
                        If Not IO.File.Exists(MGLTilePath & ".gif") Then
                            Dim MGLTile As Bitmap = AssembleMGLTile(Lat, Lon, zoom)
                            MGLTile.Save(MGLTilePath & ".png", Imaging.ImageFormat.Png) 'Save the MGL-tile to a temporary PNG file.
                            PNG2GIF(MGLTilePath & ".png").Save(MGLTilePath & ".gif", Imaging.ImageFormat.Gif) 'Color quantization and conversion to GIF format.
                            Call DeleteGCEBlock(MGLTilePath & ".gif") 'To conform to GIF87a standard, need to delete an optionally present GCE block in the GIF.
                            FileIO.FileSystem.DeleteFile(MGLTilePath & ".png") 'Delete the temporary PNG-file, leaving only the GIF file.
                        End If
                        'Add the tile to the proper map.
                        Dim aTile As New MGLTile(MGLTilePath & ".gif", New GeoRectangle(Lon, Lat, extent, extent))
                        'Check to see which map file this tile belongs to and create a dictionary of needed maps, then add the tile to the appropriate map.
                        If Not MapDict.ContainsKey(aTile.GetMapName) Then MapDict.Add(aTile.GetMapName, New MGLMap())
                        MapDict(aTile.GetMapName).AddTile(aTile)
                        If myCancellationToken.IsCancellationRequested Then
                            Exit Sub 'Check if we need to cancel prematurely.
                        End If
                    Next Lon
                Next Lat
            End If 'chk.Checked
        Next chk

    End Sub

    Private Function AIRAC(ByVal t As Date) As String
        'This function returns the AIRAC-designator (e.g. "1803") for a given date.
        Dim EffectiveDate As Date = #2018-01-04#
        Dim YearDesignator_temp As Integer = 18
        Dim AIRACNumber_temp As Integer = 1
        Dim YearDesignator As Integer
        Dim AIRACNumber As Integer

        While t > EffectiveDate
            YearDesignator = YearDesignator_temp
            AIRACNumber = AIRACNumber_temp
            If EffectiveDate.AddDays(28).Year = EffectiveDate.Year Then
                EffectiveDate = EffectiveDate.AddDays(28)
                AIRACNumber_temp += 1
            Else
                EffectiveDate = EffectiveDate.AddDays(28)
                AIRACNumber_temp = 1
                YearDesignator_temp += 1
            End If
        End While

        AIRAC = YearDesignator.ToString("00") & AIRACNumber.ToString("00")

    End Function

    Private Function GetTileMapServerURL() As String
        'For the OFM-TMS, the AIRAC cycle is encoded in the URL. Hence the URL is defined with a placeholder "{AIRAC}".
        'This placeholder needs to be replaced by the actual AIRAC cycle to arrive at the final URL.
        'URL's for all other TMS are passed unchanged.

        If My.Settings.PrimaryTmsURL.IndexOf("{AIRAC}") > 0 Then
            GetTileMapServerURL = My.Settings.PrimaryTmsURL.Replace("{AIRAC}", AIRAC(Now))
        Else
            GetTileMapServerURL = My.Settings.PrimaryTmsURL
        End If

    End Function

#End Region

#Region "Menus"

    Private Async Sub mnuGenerateMap_Click(sender As Object, e As EventArgs) Handles mnuGenerateMap.Click

        'Check that the user specified paths for the tiles and maps in Settings.
        While My.Settings.TilesPath = "" OrElse My.Settings.MapsPath = ""
            MsgBox("Please specify a location to store tiles and maps on the following form.", vbOKOnly)
            frmSettings.ShowDialog()
        End While

        'Set the globe spinning.
        pbxGlobe.Image = My.Resources.Globe
        btnCancel.Enabled = True
        mnuGenerateMap.Enabled = False
        mnuExtractTiles.Enabled = False
        mnuDisplayCoverage.Enabled = False
        mnuAssembleMap.Enabled = False

        'Collect all tiles needed to be downloaded in two lists: their URLs and their full paths.
        Dim TileURLList As New List(Of String)
        Dim TilePathList As New List(Of String)
        Dim nTiles As Long = 0
        For Each chk As CheckBox In gbxMapScales.Controls
            If chk.Checked Then
                Dim zoom As Integer = chk.Tag
                Dim TLx, TLy As Long : LatLon2TileXY(txtTLLat.Text, txtTLLon.Text, zoom, TLx, TLy)
                Dim BRx, BRy As Long : LatLon2TileXY(txtBRLat.Text, txtBRLon.Text, zoom, BRx, BRy)
                nTiles += (BRy - TLy + 1) * (BRx - TLx + 1)
                For y = TLy To BRy
                    For x = TLx To BRx
                        TileURLList.Add(GetTileMapServerURL() & zoom & "/" & x & "/" & y & ".png") 'Gather all the tiles' URLs to download.
                        TilePathList.Add(My.Settings.TilesPath & zoom & "_" & x & "_" & y & ".png") 'Similarly all the tiles' paths to download to.
                    Next x
                Next y
            End If
        Next

        'Start the actual download.
        lblStatus.Text = "Downloaded 0 of " & nTiles & " tiles."

        ParallelDownload.TileMapServerURL = GetTileMapServerURL()
        ParallelDownload.MaxConcurrentDownloads = My.Settings.MaxDownloads
        ParallelDownload.TilesCache = My.Settings.TilesPath
        ParallelDownload.RetryDelayMilliSeconds = 1000
        ParallelDownload.MaxRetries = 3
        ParallelDownload.TilesDownloaded = 0
        myCancellationTokenSource = New Threading.CancellationTokenSource
        ParallelDownload.myCancellationToken = myCancellationTokenSource.Token
        Dim DownloadTilesTask As New Task(Sub()
                                              ParallelDownload.DownloadTiles(TileURLList, TilePathList)
                                          End Sub)
        DownloadTilesTask.Start()

        myProgressBar.Maximum = nTiles
        myTimer.Interval = 250 'ms
        myTimer.Start()
        Await DownloadTilesTask
        myTimer.Stop()

        'Assemble MGL tiles
        lblStatus.Text = "Assembling MGL tiles..."
        MapDict.Clear()
        Try
            Await Task.Run(AddressOf AssembleMap,
                           myCancellationToken) 'We are using the "old" cancellation token from the download task, because if that was cancelled we won't proceed further.
        Catch ex As OperationCanceledException
            MsgBox("Download was cancelled, no map generated.", vbOKOnly)
        End Try

        If DownloadTilesTask.Status = TaskStatus.RanToCompletion Then
            'Generate maps.
            For Each aMap As MGLMap In MapDict.Values
                aMap.WriteMap(My.Settings.MapsPath & aMap.GetName)
            Next
        End If

        'Stop the globe.
        lblStatus.Text = "Ready."
        myProgressBar.Value = 0
        btnCancel.Enabled = False
        mnuGenerateMap.Enabled = True
        mnuExtractTiles.Enabled = True
        mnuDisplayCoverage.Enabled = True
        mnuAssembleMap.Enabled = True
        pbxGlobe.Image = My.Resources.Globe_stopped

    End Sub

    Private Sub mnuAssembleMap_Click(sender As Object, e As EventArgs) Handles mnuAssembleMap.Click
        'Reads all selected MGL-tiles and makes them into MAP files.

        With dlgOpenFile
            .Title = "Select MGL tiles to form into a map:"
            .Multiselect = True
            .InitialDirectory = My.Settings.TilesPath
            .ReadOnlyChecked = True
            .Filter = "GIF files (*.gif)|(*.gif)|All files (*.*)|(*.*)"
        End With
        If dlgOpenFile.ShowDialog <> vbOK Then Exit Sub

        'Read all chosen tiles and assemble them into maps.
        lblStatus.Text = "Generating MAP file..."
        Application.DoEvents()
        MapDict.Clear()
        For Each strFilename As String In dlgOpenFile.FileNames
            Dim Lat As Single
            Dim Lon As Single
            Dim zoom As Integer
            Dim extent As Single
            Dim str() As String

            str = strFilename.Split(CChar("_"), CChar("."))
            zoom = CInt(str(1))
            extent = MGLMap.MGLExtent(zoom)
            Lat = CSng(str(2))
            Lon = CSng(str(3))
            Dim aTile As New MGLTile(strFilename, New GeoRectangle(Lon, Lat, extent, extent))
            If Not MapDict.ContainsKey(aTile.GetMapName) Then MapDict.Add(aTile.GetMapName, New MGLMap)
            MapDict(aTile.GetMapName).AddTile(aTile)
        Next

        'Now write the map files.
        For Each aMap As MGLMap In MapDict.Values
            aMap.WriteMap(My.Settings.MapsPath & aMap.GetName)
        Next

        lblStatus.Text = "Ready."

    End Sub

    Private Sub mnuSettings_Click(sender As Object, e As EventArgs) Handles mnuSettings.Click
        frmSettings.Show()
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub mnuExtractTiles_Click(sender As Object, e As EventArgs) Handles mnuExtractTiles.Click
        'Extracts GIF tiles from a MAP file into a specified directory.

        With dlgOpenFile
            .Title = "Select MAP file to extract tiles from:"
            .RestoreDirectory = True
            .Filter = "MAP files (*.map)|(*.map)|All files (*.*)|(*.*)"
            .FilterIndex = 1
            .Multiselect = False
            .ReadOnlyChecked = True
            .FileName = "*.*"
        End With
        If dlgOpenFile.ShowDialog <> DialogResult.OK Then Exit Sub
        Dim strMapPath As String = IO.Path.GetDirectoryName(dlgOpenFile.FileName)
        Dim strTilesPath As String = strMapPath & "\Extracted Tiles\"

        If IO.Directory.Exists(strTilesPath) Then
            If IO.Directory.GetFiles(strTilesPath).Count > 0 Then
                If MsgBox("The directory """ & strTilesPath & """ is not empty. Do you want to potentially overwirte tiles?", MsgBoxStyle.OkCancel) <> vbOK Then Exit Sub
            End If
        Else
            IO.Directory.CreateDirectory(strTilesPath)
        End If

        MGLMap.ExtractTiles(dlgOpenFile.FileName, strTilesPath)


    End Sub

    Private Sub mnuDisplayCoverage_Click(sender As Object, e As EventArgs) Handles mnuDisplayCoverage.Click
        'Loads a MAP and displays tile coverage in dgvMap

        With dlgOpenFile
            .Title = "Select MAP file to display coverage:"
            .Multiselect = True
            .Filter = "MAP files (*.map)|(*.map)|All files (*.*)|(*.*)"
            .FileName = "*.*"
            .RestoreDirectory = True
            .ReadOnlyChecked = True
        End With
        If dlgOpenFile.ShowDialog <> vbOK Then
            bMapLoaded = False
            gbxDGVZoom.Enabled = False
            dgvMap.Columns.Clear()
            dgvMap.Rows.Clear()
            Exit Sub
        Else
            bMapLoaded = True
            gbxDGVZoom.Enabled = True
        End If

        Dim zoom As Integer = gbxDGVZoom.Controls.OfType(Of RadioButton).FirstOrDefault(Function(radioButton) radioButton.Checked).Tag

        aMapToDisplayTheCoverage = MGLMap.Open(dlgOpenFile.FileName)
        MGLMap.DisplayMap(aMapToDisplayTheCoverage, zoom, dgvMap)

    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        frmAbout.Show()
    End Sub

    Private Sub mnuHelp_Click(sender As Object, e As EventArgs) Handles mnuHelp.Click
        Help.ShowHelp(Me, "OFM-4-MGL.chm")
    End Sub

#End Region

End Class