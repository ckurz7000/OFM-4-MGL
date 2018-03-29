Option Explicit On

Imports JeremyAnsel.ColorQuant
Public Class MGLMap

    Private _Tiles As New List(Of MGLTile)
    Private _Name As String
    Private _Path As String

    Public Sub New()
        _Name = ""
        _Tiles.Clear()
    End Sub

    ''' <summary>
    ''' Creates a new instance of <c>MGLMap</c> and adds the specified list of MGLTiles.
    ''' Only those tiles are added to the map which lie in the same map as the first tile.
    ''' Upon exit, 
    ''' </summary>
    ''' <param name="aTile">The list of tiles' file names to add. It also determines the map region.</param>
    Public Sub New(ByRef TileList As List(Of String))

        _Name = ""
        _Tiles.Clear()

        Dim i As Integer = 0
        Do
            Dim Lat As Single
            Dim Lon As Single
            Dim zoom As Integer
            Dim extent As Single
            Dim str() As String

            str = TileList(i).Split(CChar("_"), CChar("."))
            zoom = CInt(str(1))
            extent = MGLMap.MGLExtent(zoom)
            Lat = CSng(str(2))
            Lon = CSng(str(3))
            Dim aTile As New MGLTile(TileList(i), New GeoRectangle(Lon, Lat, extent, extent))

            'Check if the new tile is part of the map coverage.
            'If yes, add it to the map's tile list and remove it from the TileList.
            'If  no, leave it in the TileList and move on.
            Try
                Me.AddTile(aTile)
                TileList.RemoveAt(i)
            Catch ex As Exception
                i += 1
            End Try
        Loop While i < TileList.Count

    End Sub

#Region "Properties"
    ''' <summary>
    ''' Returns the list of <c>MGLTiles</c> contained in the map.
    ''' </summary>
    ''' <returns><c>List (Of MGLTile)</c></returns>
    ''' 
    Public Property Tiles() As List(Of MGLTile)
        Get
            Return _Tiles
        End Get
        Set(value As List(Of MGLTile))
            For Each aTile As MGLTile In value
                AddTile(aTile)
            Next
        End Set

    End Property

    Public ReadOnly Property GetName() As String
        Get
            If _Tiles.Count = 0 Then _Name = ""
            Return _Name
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the file path to the map file.
    ''' </summary>
    Public Property Path() As String
        Get
            Return _Path
        End Get
        Set(value As String)
            _Path = value
        End Set
    End Property

    ''' <summary>
    ''' Returns the Lat/Lon coordinates of the top left corner of the map  file.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property TopLeft() As PointF
        Get
            If _Name = "" Then Return Nothing

            Dim Lat As String = Mid(_Name, 6, 2) : If Mid(_Name, 5, 1) = "S" Then Lat = -Lat
            Dim Lon As String = Mid(_Name, 2, 3) : If Left(_Name, 1) = "W" Then Lon = -Lon

            Return New PointF(Lon, Lat)
        End Get
    End Property

    ''' <summary>
    ''' Returns the MGL zoom levels (0..4) corresponding to the OFM zoom levels (11, 10, 9, 8, 7)
    ''' </summary>
    ''' <param name="OFMzoomLevel"></param>
    ''' <returns></returns>
    Public Shared Function MGLZoom(ByVal OFMzoomLevel As Integer) As Integer
        'Returns the zoom level used in MGL jargon.
        Select Case OFMzoomLevel
            Case 11 : Return 0
            Case 10 : Return 1
            Case 9 : Return 2
            Case 8 : Return 3
            Case 7 : Return 4
            Case Else : Throw New Exception("Unsupported zoom level.")
        End Select
    End Function

    ''' <summary>
    ''' Converts the OFM zoom level of an <c>MGLTile</c> into its width and height in degrees.
    ''' </summary>
    ''' <param name="OFMzoomLevel"></param>
    ''' <returns>The length of the side of the MGLTile in degrees</returns>
    Public Shared Function MGLExtent(ByVal OFMzoomLevel As Integer) As Single
        'Returns the extent of MGL tile in degrees
        Select Case OFMzoomLevel
            Case 11 : Return 0.25
            Case 10 : Return 0.5
            Case 9 : Return 1
            Case 8 : Return 2
            Case 7 : Return 4
            Case Else : Throw New Exception("Unsupported zoom level.")
        End Select

    End Function
#End Region

#Region "Methods"
    Public Sub AddTile(aTile As MGLTile)
        If _Name = "" Then
            _Name = aTile.GetMapName
        Else
            If _Name <> aTile.GetMapName Then Throw New Exception("Tile is not within map boundary.")
        End If
        _Tiles.Add(aTile)
    End Sub

    ''' <summary>
    ''' Writes the <c>MGLMap</c> to a file.
    ''' </summary>
    ''' <param name="strMapFileName">Fully qualified file name, including path.</param>
    Public Sub Save(ByVal strMapFileName As String)

        Dim MapStream As New IO.FileStream(strMapFileName, IO.FileMode.Create)
        Dim aMapWriter As New IO.BinaryWriter(MapStream)
        Dim StreamPos As Long
        Dim enc As New Text.ASCIIEncoding()

        'Write the file header.
        aMapWriter.Write(enc.GetBytes("MGLRMAP"))
        aMapWriter.Write(CByte(1)) 'File version
        'Length-byte + 64 bytes of string data = 65 bytes.
        StreamPos = aMapWriter.BaseStream.Position
        aMapWriter.Write("(c) OPENFLIGHTMAPS, 2018")
        aMapWriter.BaseStream.Position = StreamPos + 65
        'Length-byte + 64 bytes of string data = 65 bytes.
        StreamPos = aMapWriter.BaseStream.Position
        aMapWriter.Write("WWW.OPENFLIGHTMAPS.ORG")
        aMapWriter.BaseStream.Position = StreamPos + 65
        '128 bytes of 0x00
        Dim bBuffer(127) As Byte
        aMapWriter.Write(bBuffer)

        'Next determine the pointers.
        'There are 1024 + 256 + 64 + 16 + 4 = 1364 pointers at 4 bytes each, i.e., a block of 5456 bytes of pointers.
        'We manipulate the pointers first in an array for faster access.
        Dim arrPtr(1363) As UInt32
        Dim GIFpos As Long = 5456 + 266 'Position of first GIF, following right after the pointer section.

        'Sort tiles in order of the pointer indices.
        Dim SortedTiles As List(Of MGLTile) = _Tiles.OrderBy(Function(x) x.GetIdx).ToList
        For Each aTile As MGLTile In SortedTiles
            arrPtr(aTile.GetIdx) = GIFpos
            GIFpos += aTile.GetFileSize + 5 'The 5 extra bytes are for the length (4 bytes) and a fixed byte of value 0x01.
        Next aTile
        'Write pointers
        For Each ptr As UInt32 In arrPtr
            aMapWriter.Write(ptr)
        Next
        'Write GIFs
        For Each aTile In SortedTiles
            Using TileStream As New IO.FileStream(aTile.Path, IO.FileMode.Open)
                Dim aBuffer(4) As Byte
                Dim length As UInt32 = aTile.GetFileSize
                aBuffer(0) = CByte(length And &HFF)
                aBuffer(1) = CByte((length And &HFF00) >> 8)
                aBuffer(2) = CByte((length And &HFF0000) >> 16)
                aBuffer(3) = CByte((length And &HFF000000) >> 24)
                aBuffer(4) = 1
                MapStream.Write(aBuffer, 0, 5)
                TileStream.CopyTo(MapStream, TileStream.Length)
            End Using
        Next

        aMapWriter.Close()
        aMapWriter.Dispose()
        MapStream.Dispose()

    End Sub

    ''' <summary>
    ''' Extracts all <c>MGLTiles</c> contained in a map file to a folder as GIF files.
    ''' </summary>
    ''' <param name="strMapFilename">The fully qualified file name of the map.</param>
    ''' <param name="strTilesPath">The folder to which the individual tiles are to be extracted.</param>
    ''' 
    Public Shared Sub ExtractTiles(strMapFilename As String, strTilesPath As String)
        'Extracts the individual MGL tiles from a given MAP file and saves them in the directory
        'given by strTilesPath.

        Using aFileStream As New IO.FileStream(strMapFilename, IO.FileMode.Open)
            Using aBinaryReader As New IO.BinaryReader(aFileStream)

                If aBinaryReader.ReadChars(7) <> "MGLRMAP" Then
                    MsgBox("This is not a valid MGL map file.", vbCritical)
                    Exit Sub
                End If
                aFileStream.Seek(266, IO.SeekOrigin.Begin) 'Skip the header bytes.

                'Now read the pointers and use the non-zero pointers to find and extract the GIF tile.
                Dim ptrs(1363) As UInt32
                Dim nTiles As Integer = 0
                Dim buff() As Byte
                For i As Integer = 0 To ptrs.Count - 1
                    aFileStream.Seek(266 + i * 4, IO.SeekOrigin.Begin)
                    ptrs(i) = aBinaryReader.ReadUInt32
                    If ptrs(i) <> 0 Then
                        'Extract the gif file and save it to disk
                        aFileStream.Seek(ptrs(i), IO.SeekOrigin.Begin)
                        Dim GIFLength As Long = aBinaryReader.ReadUInt32
                        ReDim buff(GIFLength)
                        Call aBinaryReader.ReadByte() 'Skip the next byte (0x01 just indicates that what follows is a GIF image).
                        buff = aBinaryReader.ReadBytes(buff.Length)
                        Using GIFFileStream As New IO.FileStream(strTilesPath & PtrIdx2TileFilenName(i, IO.Path.GetFileName(strMapFilename)), IO.FileMode.Create)
                            GIFFileStream.Write(buff, 0, buff.Length)
                        End Using
                        nTiles += 1
                        frmMain.lblStatus.Text = "Extracted " & nTiles & " tiles."
                    End If
                Next

            End Using 'aBinaryReader
        End Using 'aFileStream

    End Sub

    ''' <summary>
    ''' Populates a <c>DataGridView</c> to show which tiles are contained in a map at a given zoom level.
    ''' </summary>
    ''' <param name="aMap">The <c>MGLMap</c> of which to display the contents.</param>
    ''' <param name="zoom">OFM zoom level to display.</param>
    ''' <param name="dgvMap">The <c>DataGridView</c> control to be used to display the map's contents.</param>
    Public Shared Sub DisplayMap(ByVal aMap As MGLMap, ByVal zoom As Integer, ByRef dgvMap As DataGridView)
        'Displays which tiles are encoded in the map on the frmMain.dgvMap Datagridview control.

        'Generate a grid depending on the zoom level.
        Dim TilesPerRow As Integer = 8 / MGLMap.MGLExtent(zoom)
        Dim extent As Single = MGLMap.MGLExtent(zoom)
        With dgvMap
            .Columns.Clear()
            .RowHeadersVisible = True
            .AllowUserToAddRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToAddRows = False
            .RowHeadersWidth = 53

            Dim Lat As Single = aMap.TopLeft.Y
            Dim Lon As Single = aMap.TopLeft.X

            For i = Lon To Lon + 8 - extent Step extent
                Dim myCol As New DataGridViewImageColumn(valuesAreIcons:=False) With {
                    .Width = 29,
                    .ImageLayout = DataGridViewImageCellLayout.Zoom,
                    .Image = My.Resources.EmptyTile
                }
                'Generate colum labels every whole degree only.
                If (TilesPerRow > 8) AndAlso (i = Int(i)) Then
                    myCol.HeaderText = i & "°"
                ElseIf (TilesPerRow <= 8) Then
                    myCol.HeaderText = i & "°"
                End If
                .Columns.Add(myCol)
            Next

            For i = Lat To Lat - 8 + extent Step -extent
                Dim myRow As New DataGridViewRow
                'Generate row labels every whole degree only.
                If (TilesPerRow > 8) AndAlso (i = Int(i)) Then
                    myRow.HeaderCell.Value = CStr(i & "°")
                ElseIf (TilesPerRow <= 8) Then
                    myRow.HeaderCell.Value = CStr(i & "°")
                End If
                .Rows.Add(myRow)
            Next i
        End With 'dgvMap

        'Now fill in the cells where a tile exists in the map.
        'Only check tiles of the selected zoom level.
        For Each aTile In aMap.Tiles.FindAll(Function(x) x.GetMGLZoom = 11 - zoom)
            ' If 11 - zoom = aTile.GetMGLZoom Then
            Dim col As Integer = (aTile.Bounds.Left - aMap.TopLeft.X) / extent
            Dim row As Integer = -(aTile.Bounds.Top - aMap.TopLeft.Y) / extent
            dgvMap.Rows(row).Cells(col).Value = My.Resources.RenderedTile
            'End If
        Next


    End Sub

    ''' <summary>
    ''' Reads a map from a file.
    ''' </summary>
    ''' <param name="strMapFilename">Fully qualified filen name of the map.</param>
    ''' <returns>A <c>MGLMap</c></returns>
    Public Shared Function Open(strMapFilename As String) As MGLMap
        'Returns an MGLMap object generated from a stored map.
        'Note that individual tiles are NOT extracted.

        Dim aMap As New MGLMap()

        Using aFilestream As New IO.FileStream(strMapFilename, IO.FileMode.Open),
              aBinaryReader As New IO.BinaryReader(aFilestream)

            If aBinaryReader.ReadChars(7) <> "MGLRMAP" Then
                Throw New Exception("The file is not a proper MGL map file: " & strMapFilename)
                Return Nothing
            End If

            Dim bPtrs(1363) As Int32
            For i = 0 To bPtrs.Count - 1
                aFilestream.Seek(266 + i * 4, IO.SeekOrigin.Begin)
                bPtrs(i) = aBinaryReader.ReadUInt32
                If bPtrs(i) <> 0 Then
                    Dim strTileName As String = PtrIdx2TileFilenName(i, strMapFilename)
                    Dim str() As String = strTileName.Split({CChar("_"), CChar(".")})
                    Dim zoom As Integer = str(1)
                    Dim TLLat As Single = str(2)
                    Dim TLLon As Single = str(3)
                    Dim extent As Single = MGLMap.MGLExtent(zoom)
                    aMap.AddTile(New MGLTile(strTileName, New GeoRectangle(TLLon, TLLat, extent, extent)))
                End If
            Next

        End Using

        aMap.Path = IO.Path.GetDirectoryName(strMapFilename)

        Return aMap

    End Function

    ''' <summary>
    ''' Given Lat, Lon and zoom it returns the tile containing the queried point.
    ''' </summary>
    ''' <param name="Lat">Latitude in decimal degrees (negative is southern latitudes)</param>
    ''' <param name="Lon">Longitude in decimal degrees (negative is western latitudes)</param>
    ''' <param name="zoom">Zoom level in standard slippy map format (11, 10, 9 or 8)</param>
    ''' <returns></returns>
    Public Function LatLon2MGLTile(ByVal Lat As Single, ByVal Lon As Single, ByVal zoom As Integer) As MGLTile

        Dim TilesFound As List(Of MGLTile) = Me.Tiles.FindAll(Function(x)
                                                                  Return (x.Bounds.Top >= Lat AndAlso
                                                                          x.Bounds.Bottom < Lat AndAlso
                                                                          x.Bounds.Left <= Lon AndAlso
                                                                          x.Bounds.Right > Lon AndAlso
                                                                          x.GetMGLZoom = 11 - zoom)
                                                              End Function)

        If TilesFound.Count = 0 Then Return Nothing Else Return TilesFound(0)

    End Function

    ''' <summary>
    ''' Extracts a single tile and returns a memorystream to the tile's GIF data.
    ''' </summary>
    ''' <param name="Lat">Latitude of a point within the tile (top inclusive)</param>
    ''' <param name="Lon">Longitude of a point within the tile (left inclusive)</param>
    ''' <param name="zoom">OFM zoom level of the sought tile</param>
    ''' <returns>A memorystream containing the tile's GIF data.</returns>
    Public Function GetTileMemoryStream(ByVal Lat As Single, Lon As Single, ByVal zoom As Integer) As IO.MemoryStream

        Dim FoundTile As MGLTile = LatLon2MGLTile(Lat, Lon, zoom)

        If FoundTile Is Nothing Then
            Return Nothing
        Else
            'Need to extract that tile from the map file.
            Dim ptr As Long = FoundTile.GetIdx * 4 + 266
            Dim buffer() As Byte
            Using aFilestream As New IO.FileStream(_Path & "\" & _Name, IO.FileMode.Open),
                    aBinaryReader As New IO.BinaryReader(aFilestream)

                aFilestream.Position = ptr 'Advance to the pointer for the GIF
                aFilestream.Position = aBinaryReader.ReadUInt32 'Advance to the GIF by reading the pointer
                ReDim buffer(aBinaryReader.ReadUInt32 - 1) 'Read the length of the GIF and dimension a buffer to hold it.
                aFilestream.ReadByte() 'Skip one byte
                aFilestream.Read(buffer, 0, buffer.Length)
            End Using

            GetTileMemoryStream = New IO.MemoryStream(buffer)

        End If

        Return GetTileMemoryStream

    End Function

    ''' <summary>
    ''' Extracts a single tile-bitmap from a map file, where the tile is specified by a point and a zoom level.
    ''' </summary>
    ''' <param name="Lat">Latitude of the point contained in the tile.</param>
    ''' <param name="Lon">Longitude of the point contained in the tile.</param>
    ''' <param name="zoom">OFM zoom level of the tile to be extracted.</param>
    ''' <returns>A <c>Bitmap</c> of the extracted tile, <c>Nothing</c> if no tile was found.</returns>
    Public Function GetTileBitmap(ByVal Lat As Single, Lon As Single, ByVal zoom As Integer) As Bitmap

        GetTileBitmap = Bitmap.FromStream(GetTileMemoryStream(Lat, Lon, zoom))

        Return GetTileBitmap

    End Function

    ''' <summary>
    ''' Represents the map coverage in terms of a 2D grid of MGLTile. 
    ''' </summary>
    ''' <returns>A 2D array of map coverage. Contains only the covered portion of the map.</returns>
    Public Function TilesTo2DArray(ByVal MGLZoom As Integer) As MGLTile(,)

        Dim enumSortedTiles As IEnumerable(Of MGLTile) = _Tiles.OrderBy(Function(x) x.GetIdx)
        Dim enumSubsetZoom As IEnumerable(Of MGLTile) = enumSortedTiles.ToList.Where(Function(x) x.GetMGLZoom = MGLZoom)
        Dim enumRowTiles As IEnumerable(Of MGLTile) = enumSubsetZoom.ToList.Where(Function(x) ((x.Bounds.Left = enumSubsetZoom.ToList(0).Bounds.Left)))

        Dim nRows As Integer = enumRowTiles.Count
        Dim nCols As Integer = enumSubsetZoom.Count / nRows

        Dim myTileArray(nCols - 1, nRows - 1) As MGLTile
        Dim SubsetZoom As List(Of MGLTile) = enumSubsetZoom.ToList
        For i As Integer = 0 To myTileArray.Length - 1
            myTileArray(i Mod nCols, i \ nCols) = SubsetZoom(i)
        Next

        Return myTileArray

    End Function

#End Region

#Region "Private Parts"
    ''' <summary>
    ''' Given the index of the tile pointer in the map file, returns the properly formed tile file name.
    ''' </summary>
    ''' <param name="idx">The index of the pointer: 0..1363</param>
    ''' <param name="strMapName">The standard name of the map, without path.</param>
    ''' <returns>The standard name of the tile as "MGL_zoom_Lat_Lon.gif"</returns>
    ''' 
    Private Shared Function PtrIdx2TileFilenName(idx As Long, strMapName As String) As String
        'Taking an index into the array of pointer, this function
        'returns the properly formed tile name: "MGL_zoom_Lat_Lon.gif".

        strMapName = IO.Path.GetFileName(strMapName)
        Dim TLLat As Integer = Mid(strMapName, 6, 2) : If Mid(strMapName, 5, 1) = "S" Then TLLat = -TLLat
        Dim TLLon As Integer = Mid(strMapName, 2, 3) : If Left(strMapName, 1) = "W" Then TLLon = -TLLon
        Dim Lat As Single 'Latitude of top-left tile corner.
        Dim Lon As Single
        Dim row As Integer
        Dim col As Integer
        Dim zoom As Integer

        Select Case idx
            Case 0 To 1023 'MGLzoom 0, zoom 11, 32x32 tiles, 0.25 degrees
                row = Math.Floor(idx / 32)
                col = idx - row * 32
                Lat = TLLat - row * 0.25
                Lon = TLLon + col * 0.25
                zoom = 11

            Case 1024 To 1024 + 255 'MGLzoom 1, zoom 10, 16x16 tiles, 0.5 degrees
                idx -= 1024
                row = Math.Floor(idx / 16)
                col = idx - row * 16
                Lat = TLLat - row * 0.5
                Lon = TLLon + col * 0.5
                zoom = 10

            Case 1024 + 256 To 1024 + 256 + 63 'MGLzoom 2, zoom 9, 8x8 tiles, 1 degrees
                idx -= (1024 + 256)
                row = Math.Floor(idx / 8)
                col = idx - row * 8
                Lat = TLLat - row * 1
                Lon = TLLon + col * 1
                zoom = 9

            Case 1024 + 256 + 64 To 1024 + 256 + 64 + 15 'MGLzoom 3, zoom 8, 4x4 tiles, 2 degrees
                idx -= (1024 + 256 + 64)
                row = Math.Floor(idx / 4)
                col = idx - row * 4
                Lat = TLLat - row * 2
                Lon = TLLon + col * 2
                zoom = 8

            Case 1024 + 256 + 64 + 16 To 1024 + 256 + 64 + 16 + 3 'MGLzoom 4, zoom 8, 2x2 tiles, 4 degrees
                idx -= (1024 + 256 + 64 + 16)
                row = Math.Floor(idx / 2)
                col = idx - row * 2
                Lat = TLLat - row * 4
                Lon = TLLon + col * 4
                zoom = 7

            Case Else
                Throw New Exception("Invalid pointer index: " & idx)
        End Select

        PtrIdx2TileFilenName = "MGL_" & zoom & "_" & Lat & "_" & Lon & ".gif"

    End Function

#End Region

End Class

Public Class MGLTile

    Private _Path As String
    Private _Bounds As GeoRectangle

    Public Sub New(Path As String, Bounds As GeoRectangle)
        _Bounds = Bounds
        _Path = Path
    End Sub

    Public Shared Function TileWidth(ByVal TLLat As Single, ByVal extent As Single) As Integer
        'Returns the width of the tile in pixels, given its Top-Left latitude and width in degrees longitude.
        Return 600 * Math.Cos((TLLat - extent / 2) * Math.PI / 180)
    End Function

#Region "Properties"
    Public Property Path() As String
        Get
            Return _Path
        End Get
        Set(value As String)
            _Path = value
        End Set
    End Property

    Public Property Bounds() As GeoRectangle
        Get
            Return _Bounds
        End Get
        Set(value As GeoRectangle)
            _Bounds = value
        End Set
    End Property

    Public ReadOnly Property GetMGLZoom() As Integer
        Get
            Select Case _Bounds.Width
                Case 0.25 : Return 0
                Case 0.5 : Return 1
                Case 1 : Return 2
                Case 2 : Return 3
                Case 3 : Return 4
                Case Else : Throw New Exception("Ill definied tile extent: " & _Bounds.Width)
            End Select
        End Get
    End Property

    Public ReadOnly Property GetMapName() As String
        Get
            Dim MapLat As Integer = 90 - (Math.Floor(90 - _Bounds.Top) \ 8) * 8
            Dim MapLon As Integer = -180 + (Math.Floor(_Bounds.Left + 180) \ 8) * 8
            Dim aStr As String

            If MapLon >= 0 Then aStr = "E" & MapLon.ToString("000") Else aStr = "W" & Math.Abs(MapLon).ToString("000")
            If MapLat >= 0 Then aStr += "N" & MapLat.ToString("00") Else aStr += "S" & Math.Abs(MapLat).ToString("00")

            Return aStr & ".map"

        End Get
    End Property

    Public ReadOnly Property GetTileName As String
        Get
            Return "MGL_" &
                    (11 - GetMGLZoom) & "_" &
                    _Bounds.Top & "_" &
                    _Bounds.Left & ".gif"
        End Get
    End Property

    Public ReadOnly Property TileExtracted() As Boolean
        Get
            Return FileIO.FileSystem.FileExists(_Path)
        End Get
    End Property

    Public ReadOnly Property GetFileSize As Long
        Get
            Dim myFileInfo = New IO.FileInfo(_Path)
            Return myFileInfo.Length
        End Get
    End Property

    Public ReadOnly Property GetIdx() As Long
        'The property returns the index of the tile within its associated map file (zero based).
        'GIFIdx * 4 is the byte offset from the beginning of the pointer section.
        'Add 266 to this to get the offset form the beginning of the map file.

        Get

            Dim MapLon As Integer = CInt(Mid(GetMapName, 2, 3)) : If Left(GetMapName, 1) = "W" Then MapLon = -MapLon
            Dim MapLat As Integer = CInt(Mid(GetMapName, 6, 2)) : If Mid(GetMapName, 5, 1) = "S" Then MapLat = -MapLat

            Dim TileIdx As Integer = Math.Floor(CSng(MapLat - _Bounds.Top) / _Bounds.Width * (8 / _Bounds.Width)) + CSng((_Bounds.Left - MapLon) / _Bounds.Width)

            Select Case GetMGLZoom
                Case 0 : Return TileIdx '1:250k
                Case 1 : Return (1024 + TileIdx) '1:500k
                Case 2 : Return (1024 + 256 + TileIdx) '1:1M
                Case 3 : Return (1024 + 256 + 64 + TileIdx) '1:2M
                Case 4 : Return (1024 + 256 + 64 + 16 + TileIdx) '1:4M
                Case Else : Throw New Exception("Ill defined MGL zoom: " & GetMGLZoom)
            End Select

        End Get

    End Property

    Public ReadOnly Property GetPoint(ByVal Lat As Single, ByVal Lon As Single) As Point
        'Returns the pixel coorinates of the requested Lat/Lon point in the tile GIF.
        Get
            If Lat > Me.Bounds.Top OrElse
               Lat <= Me.Bounds.Bottom OrElse
               Lon < Me.Bounds.Left OrElse
               Lon >= Me.Bounds.Right Then Return Nothing

            Dim x As Integer = (Lat - Me.Bounds.Top) / Me.Bounds.Height * 600
            Dim y As Integer = (Lon - Me.Bounds.Left) / Me.Bounds.Width * MGLTile.TileWidth(Me.Bounds.Top, Me.Bounds.Width)

            Return New Point(x, y)
        End Get
    End Property

    Public Shared Sub PNG2GIF87a(ByVal strPNGFilename As String, Optional ByVal strGIFFilename As String = "")
        'This function converts a PNG file to a GIF87a file.

        If strGIFFilename = "" Then strGIFFilename = IO.Path.ChangeExtension(strPNGFilename, ".gif")

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
        bmpPNG.Dispose()
        For line As Integer = 0 To bmpGIF.Height - 1
            Runtime.InteropServices.Marshal.Copy(qResult.Bytes, line * bmpGIF.Width, bmpGIFData.Scan0 + line * bmpGIFData.Stride, bmpGIF.Width)
        Next
        bmpGIF.UnlockBits(bmpGIFData)
        bmpGIF.Palette = cTable

        Dim buffer() As Byte
        Using aMemoryStream As New IO.MemoryStream()
            bmpGIF.Save(aMemoryStream, Imaging.ImageFormat.Gif)
            ReDim buffer(aMemoryStream.Length - 1)
            buffer = aMemoryStream.ToArray()
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
        Using aFilestream As New IO.FileStream(strGIFFilename, IO.FileMode.Create)
            If buffer(idx) = &H21 AndAlso buffer(idx + 1) = &HF9 AndAlso buffer(idx + 2) = &H4 Then
                'We found a Graphics Control Extension Block starting at position idx and extending for 8 bytes, so remove it.
                aFilestream.Write(buffer, 0, idx)
                aFilestream.Write(buffer, idx + 8, buffer.Length - (idx + 8))
            Else
                aFilestream.Write(buffer, 0, buffer.Count)
            End If
        End Using

    End Sub

#End Region

End Class

Public Class GeoRectangle

    Private _TL As PointF = New PointF(Single.NaN, Single.NaN)
    Private _BR As PointF = New PointF(Single.NaN, Single.NaN)
    Public Sub New()
    End Sub

    ''' <summary>
    ''' Instantiates a new GeoRectangle
    ''' </summary>
    ''' <param name="TLX"></param>
    ''' <param name="TLY"></param>
    ''' <param name="Width"></param>
    ''' <param name="Height"></param>
    Public Sub New(TLX As Single, TLY As Single, Width As Single, Height As Single)

        If TLX > 180 OrElse
           TLX < -180 OrElse
           TLY < -90 OrElse
           TLY > 90 OrElse
           Width < 0 OrElse
           Width > 360 OrElse
           Height < 0 OrElse
           Height > 180 Then
            Throw New Exception("Invalid parameters for creating GeoRectangle.")
            Exit Sub
        End If

        _TL = New PointF(TLX, TLY)
        _BR = New PointF(TLX + Width, TLY - Height)
    End Sub

#Region "Properties"
    ''' <summary>
    ''' Sets or gets the top-left (northerly-westerly) coordinate.
    ''' </summary>
    ''' <returns></returns>
    Public Property TopLeft() As PointF
        Get
            Return _TL
        End Get
        Set(ByVal value As PointF)
            If value.Y > 90 OrElse
               value.Y < -90 OrElse
               value.X < -180 OrElse
               value.X > 180 Then
                Throw New Exception("Coordinates out of bounds.")
                Exit Property
            End If
        End Set
    End Property

    Public ReadOnly Property Width()
        Get
            Return _BR.X - _TL.X
        End Get
    End Property

    Public ReadOnly Property Height()
        Get
            Return _TL.Y - _BR.Y
        End Get
    End Property

    Public ReadOnly Property Top
        Get
            Return _TL.Y
        End Get
    End Property

    Public ReadOnly Property Bottom
        Get
            Return _BR.Y
        End Get
    End Property

    Public ReadOnly Property Left
        Get
            Return _TL.X
        End Get
    End Property

    Public ReadOnly Property Right
        Get
            Return _BR.X
        End Get
    End Property

#End Region

#Region "Methods"
    ''' <summary>
    ''' Checks whether a point lies within the GeoRectangle. The top and right edges of the rectangle are inclusive, the bottom and right ones exclusive.
    ''' </summary>
    ''' <param name="pt">Point to test.</param>
    ''' <returns><c>True</c> if <c>pt</c> is inside the rectangle, <c>False</c> otherwise.</returns>
    Public Function Contains(ByVal pt As PointF) As Boolean

        If pt.Y <= _TL.Y AndAlso
           pt.Y > _BR.Y AndAlso
           pt.X >= _TL.X AndAlso
           pt.X < _BR.X Then
            Return True
        Else
            Return False
        End If

    End Function

#End Region

End Class
