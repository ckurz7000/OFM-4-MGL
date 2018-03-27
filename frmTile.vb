Public Class frmTile

    Public strMapFilename As String
    Public zoom As Integer
    Public ptCell As Point

    Public Sub ShowTile() Handles Me.Invalidated
        'Displays info about a tile, indexed by idxTile, within a MAP file.

        Dim strMap = IO.Path.GetFileName(strMapFilename)
        Dim TLLat As Integer = Mid(strMap, 6, 2) : If Mid(strMap, 5, 1) = "S" Then TLLat = -TLLat
        Dim TLLon As Integer = Mid(strMap, 2, 3) : If Mid(strMap, 1, 1) = "W" Then TLLon = -TLLon
        Dim extent As Single = MGLMap.MGLExtent(zoom)
        Dim idxPtr As Integer
        Dim Lat As Single = TLLat - ptCell.Y * extent
        Dim Lon As Single = TLLon + ptCell.X * extent

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

End Class