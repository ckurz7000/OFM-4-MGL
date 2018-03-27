Imports System.Xml.Serialization

<Serializable>
Public Class TileMapServer

    <XmlAttribute>
    Public Name As String = ""

    <XmlElement>
    Public URL As String = ""

    <XmlElement>
    Public TileSize As Integer = 256

    <XmlElement>
    Public MaxDownloads As Integer = 2

    Public Sub New()
    End Sub
End Class

<Serializable>
Public Class TileMapServerList
    Inherits List(Of TileMapServer)

    Public Sub New()
    End Sub
End Class
