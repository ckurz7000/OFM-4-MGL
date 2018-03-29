Imports ImageProcessor

Public Class frmTile

    Public strMapFilename As String
    Public zoom As Integer
    Public ptCell As Point
    Private curTile As Image

    Public Sub ShowTile() Handles Me.Invalidated
        'Displays info about a tile, indexed by idxTile, within a MAP file.

        Dim strMap = IO.Path.GetFileName(strMapFilename)
        Dim TLLat As Integer = Mid(strMap, 6, 2) : If Mid(strMap, 5, 1) = "S" Then TLLat = -TLLat 'TL-latitude of map file.
        Dim TLLon As Integer = Mid(strMap, 2, 3) : If Mid(strMap, 1, 1) = "W" Then TLLon = -TLLon 'TL-longitude of map file.
        Dim extent As Single = MGLMap.MGLExtent(zoom)
        Dim idxPtr As Integer
        Dim Lat As Single = TLLat - ptCell.Y * extent 'TL-latidtude of tile.
        Dim Lon As Single = TLLon + ptCell.X * extent 'TL-longitude of tile.

        lblMapName.Text = strMap
        lblExtent.Text = extent & " degrees"
        lblTileFilename.Text = "MGL_" & zoom & "_" & Lat & "_" & Lon & ".gif"

        Dim aStr As String
        If Lat > 0 Then aStr = "N" Else aStr = "S"
        aStr += Math.Abs(Lat).ToString("00.00") & " / "
        If Lon > 0 Then aStr += "E" Else aStr += "W"
        aStr += Math.Abs(Lon).ToString("000.00")
        lblLatLon.Text = aStr

        Select Case 11 - zoom
            Case 0 : idxPtr = 0
            Case 1 : idxPtr = 1024
            Case 2 : idxPtr = 1280
            Case 3 : idxPtr = 1344
            Case 4 : idxPtr = 1360
            Case Else
                Throw New Exception("Invalid zoom level.")
        End Select
        idxPtr += (8 / extent) * (ptCell.Y) + ptCell.X
        lblPtrIdx.Text = idxPtr

        Dim addrPtr As Long = 266 + (idxPtr * 4)
        lblPtrAddr.Text = addrPtr & " = 0x" & Hex(addrPtr)

        Using aFilestream As New IO.FileStream(strMapFilename, IO.FileMode.Open)
            Dim buffer(3) As Byte
            Dim Ptr As ULong
            aFilestream.Position = addrPtr
            aFilestream.Read(buffer, 0, 4)
            Ptr = ((buffer(3) * 256 + buffer(2)) * 256 + buffer(1)) * 256 + buffer(0)
            lblPtr.Text = Ptr & " = 0x" & Hex(Ptr)

            If Ptr > 0 Then
                Dim GifLen As ULong
                aFilestream.Position = Ptr
                aFilestream.Read(buffer, 0, 4)
                GifLen = ((buffer(3) * 256 + buffer(2)) * 256 + buffer(1)) * 256 + buffer(0)
                lblGIFLen.Text = GifLen.ToString("#,###") & " bytes (" & (GifLen \ 1024).ToString("#,###") & " kB)"

                Dim chrHeader(5) As Char
                Using aBinaryReader As New IO.BinaryReader(aFilestream)
                    aFilestream.Position = Ptr + 5
                    chrHeader = aBinaryReader.ReadChars(chrHeader.Length)
                    lblDump.Text = New String(chrHeader)

                    'Extract GIF and display it.
                    Dim GIFBuffer(GifLen - 1) As Byte
                    aFilestream.Position = Ptr + 5
                    aFilestream.Read(GIFBuffer, 0, GifLen)
                    curTile = Bitmap.FromStream(New IO.MemoryStream(GIFBuffer))

                    'Apply image processing.
                    Using aTileImage As New ImageFactory(preserveExifData:=False)
                        aTileImage.Load(GIFBuffer)
                        aTileImage.Contrast(tbrContrast.Value)
                        aTileImage.Saturation(tbrSaturation.Value)
                        aTileImage.Brightness(tbrBrightness.Value)
                        Dim outStream As New IO.MemoryStream
                        aTileImage.Save(outStream)
                        ReDim GIFBuffer(outStream.Length - 1)
                        GIFBuffer = outStream.ToArray
                    End Using

                    Dim imgGIF As New Bitmap(New IO.MemoryStream(GIFBuffer))
                    pbxTile.Image = imgGIF
                    lblSize.Text = imgGIF.Width & " x " & imgGIF.Height & " px"
                End Using 'aBinaryReader
            Else
                lblGIFLen.Text = "--"
                lblDump.Text = "--"
                lblSize.Text = "--"
                pbxTile.Image = Nothing
            End If

        End Using

    End Sub

    Private Sub frmTile_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Top = frmMain.Top
        Me.Left = frmMain.Left + frmMain.Width
    End Sub

    Private Sub ImageControlSlider_ValueChanged(sender As Object, e As EventArgs) Handles tbrContrast.ValueChanged,
                                                                                          tbrSaturation.ValueChanged,
                                                                                          tbrBrightness.ValueChanged

        Dim TileImage As New ImageFactory(preserveExifData:=False)
        With TileImage
            .Load(curTile)
            .Contrast(tbrContrast.Value)
            .Saturation(tbrSaturation.Value)
            .Brightness(tbrBrightness.Value)
            Dim outStream As New IO.MemoryStream
            .Save(outStream)
            pbxTile.Image = Image.FromStream(outStream)
            outStream.Dispose()
        End With

        TileImage.Dispose()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        tbrBrightness.Value = 0
        tbrContrast.Value = 0
        tbrSaturation.Value = 0
        Call ImageControlSlider_ValueChanged(New Object, New EventArgs)
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        If MsgBox("The map will be re-created using current image setting." & vbCrLf &
                  "The existing map will be overwritten." & vbCrLf &
                  "Do you want to proceed?", vbOKCancel) = vbOK Then
            'Apply the image processing settings to all tiles at the current zoom level in the map.
            'To do this, we extract all tiles from the map to a temporary directory.
            'Then we apply the image settings and re-assemble them to a map.

            'Create a temporary directory; empty it if it already exists.
            Dim TempTilesDir As String = My.Settings.TilesPath & "Temp\"
            If IO.Directory.Exists(TempTilesDir) Then
                For Each deleteFile In IO.Directory.EnumerateFiles(TempTilesDir)
                    Try
                        IO.File.Delete(deleteFile)
                    Catch ex As Exception
                        'Just skip the file quietly.
                    End Try
                Next
            Else
                FileSystem.MkDir(TempTilesDir)
            End If
            MGLMap.ExtractTiles(strMapFilename, TempTilesDir)

            'Apply image settings to every file.
            'Save first as PNG and then convert it to GIF87a with quantization and all.
            Dim DirInfo As New IO.DirectoryInfo(TempTilesDir)
            For Each aFile In DirInfo.EnumerateFiles
                Using AdjustImage As New ImageFactory(preserveExifData:=False)
                    With AdjustImage
                        .Load(aFile.FullName)
                        .Brightness(tbrBrightness.Value)
                        .Contrast(tbrContrast.Value)
                        .Saturation(tbrSaturation.Value)
                        .Format(New Imaging.Formats.PngFormat)
                        .Save(IO.Path.ChangeExtension(aFile.FullName, ".png"))
                    End With
                End Using
                Call MGLTile.PNG2GIF87a(IO.Path.ChangeExtension(aFile.FullName, ".png"))
                IO.File.Delete(IO.Path.ChangeExtension(aFile.FullName, ".png"))
            Next

            'Re-assemble map.
            Dim NewMap As New MGLMap(IO.Directory.EnumerateFiles(TempTilesDir, "MGL_*.gif").ToList)
            NewMap.Save(My.Settings.MapsPath & NewMap.GetName)

        End If
    End Sub
End Class