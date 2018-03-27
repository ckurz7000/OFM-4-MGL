Imports System.ComponentModel
Imports System.Xml.Serialization

Public Class frmSettings

    Private TileMapServers As New TileMapServerList
    Private PrimaryServer As New TileMapServer

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Shown

        Try

            Dim strTileMapServerList As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\OFM-4-MGL\TileMapServerList.xml"
            'Populate the cbxTMS from the Tile Map Servers defined in the file "TileMapServers.xml"
            Using fs As New IO.FileStream(strTileMapServerList, IO.FileMode.Open)
                Dim myXMLSerializer As New XmlSerializer(GetType(TileMapServerList))
                TileMapServers = myXMLSerializer.Deserialize(fs)
            End Using

        Catch ex As Exception

            'Use the default server profiles stored as an embedded XML resource.
            MsgBox("Could not open the file ""TileMapServerList.xml""" & vbCrLf &
                   "Using a default set instead." & vbCrLf &
                   "Check the help file for possible solution.", vbOKOnly)
            Dim myResourceManager As New Resources.ResourceManager("OFM4MGL.Resources", GetType(frmSettings).Assembly)
            Using fs As IO.MemoryStream = New IO.MemoryStream(CType(myResourceManager.GetObject("TileMapServerList"), Byte()))
                Dim myXMLSerializer As New XmlSerializer(GetType(TileMapServerList))
                TileMapServers = myXMLSerializer.Deserialize(fs)
            End Using

        Finally

            'Populate the list box with the profiles contained in TileMapServers.
            For Each aTMS In TileMapServers
                lbxTMS.Items.Add(aTMS.Name)
            Next
            'Set the TMS stored in My.Settings as the active one.
            Try
                lbxTMS.SelectedItem = lbxTMS.Items(My.Settings.idxPrimaryTMS)
            Catch ex As Exception
                MsgBox("Error locating the previously used server. Choosing first TMS in list.", vbOKOnly)
                PrimaryServer = TileMapServers(0)
                My.Settings.idxPrimaryTMS = 0
                lbxTMS.SelectedItem = lbxTMS.Items(0)
                My.Settings.PrimaryTmsURL = PrimaryServer.URL
            End Try

        End Try

        txtTileCachePath.Text = My.Settings.TilesPath
        txtMapPath.Text = My.Settings.MapsPath
        cbxColors.SelectedIndex = My.Settings.idxColors

    End Sub

    Private Sub btnBrowseTileCache_Click(sender As Object, e As EventArgs) Handles btnBrowseTileCache.Click

        With dlgBrowsePaths
            .Description = "Select the folder where tiles are downloaded to."
            .ShowDialog()
            txtTileCachePath.Text = .SelectedPath & "\"
            My.Settings.TilesPath = .SelectedPath & "\"
        End With

    End Sub

    Private Sub btnBrowseMapPath_Click(sender As Object, e As EventArgs) Handles btnBrowseMapPath.Click
        With dlgBrowsePaths
            .Description = "Select the folder where maps are output to."
            .ShowDialog()
            txtMapPath.Text = .SelectedPath & "\"
            My.Settings.MapsPath = .SelectedPath & "\"
        End With

    End Sub

    Private Sub frmSettings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim PrimaryTMS As TileMapServer = TileMapServers(lbxTMS.SelectedIndex)

        My.Settings.idxPrimaryTMS = lbxTMS.SelectedIndex
        My.Settings.PrimaryTmsURL = PrimaryTMS.URL
        My.Settings.TileSize = PrimaryTMS.TileSize
        My.Settings.MaxDownloads = PrimaryTMS.MaxDownloads
        My.Settings.MapsPath = txtMapPath.Text
        My.Settings.TilesPath = txtTileCachePath.Text
        My.Settings.idxColors = cbxColors.SelectedIndex
        My.Settings.nColors = cbxColors.SelectedItem.ToString
        My.Settings.Save()

        If Not IO.Directory.Exists(My.Settings.TilesPath) Then
            Try
                IO.Directory.CreateDirectory(txtTileCachePath.Text)
            Catch ex As Exception
                If MsgBox("Error creating the folder for the tile cache: """ & txtTileCachePath.Text & ".""", vbOKCancel) = vbOK Then e.Cancel = True
                Exit Sub
            End Try
        End If

        If Not IO.Directory.Exists(txtMapPath.Text) Then
            Try
                IO.Directory.CreateDirectory(txtMapPath.Text)
            Catch ex As Exception
                If MsgBox("Error creating the folder for storing maps: """ & txtMapPath.Text & ".""", vbOKCancel) = vbOK Then e.Cancel = True
                Exit Sub
            End Try
        End If

    End Sub

End Class