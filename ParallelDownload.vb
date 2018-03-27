Option Explicit On
Public Module ParallelDownload

    Public TileMapServerURL As String
    Public MaxConcurrentDownloads As Integer
    Public TilesCache As String
    Public MaxRetries As Integer = 3
    Public RetryDelayMilliSeconds As Integer = 3000
    Public myCancellationToken As Threading.CancellationToken
    Public TilesDownloaded As Long = 0

    Public Sub DownloadTiles(TileURLList As List(Of String),
                             TilePathList As List(Of String))

        Dim LoopOptions As New ParallelOptions With {.CancellationToken = myCancellationToken,
                                                     .MaxDegreeOfParallelism = MaxConcurrentDownloads}
        Try
            Dim LoopResult As ParallelLoopResult = Parallel.For(0,
                                                                TileURLList.Count,
                                                                LoopOptions,
                                                                Sub(i)
                                                                    If Not IO.File.Exists(TilePathList(i)) Then
                                                                        Call DownloadSingleTile(TileURLList(i), TilePathList(i))
                                                                    End If
                                                                    Threading.Interlocked.Increment(TilesDownloaded)
                                                                End Sub)
        Catch ex As OperationCanceledException
        End Try

    End Sub

    Private Sub DownloadSingleTile(TileURL As String, TilePath As String)

        Dim TrialCount As Integer = 0
        Dim Succeeded As Boolean = False
        Dim TILEWIDTH As Integer = 256

        Do
            Try
                Dim myWebClient As New Net.WebClient
                myWebClient.DownloadFile(TileURL, TilePath)
                Succeeded = True
            Catch ex As Net.WebException When CType(ex.Response, Net.HttpWebResponse).StatusCode = Net.HttpStatusCode.NotFound
                Succeeded = False
                TrialCount = Integer.MaxValue
                Exit Try
            Catch ex As Net.WebException 'Retry a few times with a small wait in between.
                Succeeded = False
                Threading.Thread.Sleep(RetryDelayMilliSeconds)
                TrialCount += 1
                Exit Try
            Catch ex As Exception 'This handles all other exceptions. No need to wait in this case.
                Succeeded = False
                TrialCount = Integer.MaxValue
            End Try
        Loop Until Succeeded OrElse TrialCount >= MaxRetries
        If Not Succeeded Then
            Dim aBitmap As New Bitmap(TILEWIDTH, TILEWIDTH, Imaging.PixelFormat.Format32bppArgb)
            aBitmap.Save(TilePath, Imaging.ImageFormat.Png)
        End If

    End Sub

End Module