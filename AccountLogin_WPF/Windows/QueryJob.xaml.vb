Imports System.Data
Imports System.Data.SQLite

Public Class QueryJob
    'Dim job As New Job()
    Private Sub btnGet_Click(sender As Object, e As RoutedEventArgs) Handles btnGet.Click
        Dim jobNum As String

        If Not searchBox.Text Is Nothing Then
            jobNum = searchBox.Text
        End If

        DisplaySearch(jobNum, SelectedJob)
    End Sub
    Sub DisplaySearch(query As String, grid As DataGrid)
        Dim cmd As SQLiteCommand = Nothing

        'cmd = New SQLiteCommand("SELECT * FROM Sales WHERE SaleNumber = @Query")
        cmd = New SQLiteCommand("SELECT * FROM Sales WHERE SaleNumber = @Query")
        Using conn As SQLiteConnection = New SQLiteConnection(GetData.connPath)
            cmd.Connection = conn
            cmd.Connection.Open()
            cmd.Parameters.Add("@Query", SqlDbType.VarChar).Value = query

            Using reader As SQLiteDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim job As New Job()
                    job.SalesNum = Convert.ToInt32(reader("SaleNumber"))
                    job.ProductSold = GetData.ConvertToProduct(reader("ProductSold"))
                    job.QtySold = Convert.ToInt32(reader("QtySold"))
                    job.FinalSale = Convert.ToDouble(reader("FinalSalePrice"))

                End While
            End Using

            Dim adapter As New SQLiteDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adapter.Fill(dt)

            grid.ItemsSource = dt.DefaultView()
        End Using
    End Sub


    Private Sub btnClear_Click(sender As Object, e As RoutedEventArgs) Handles btnClear.Click
        searchBox.Clear()
        SelectedJob.ItemsSource = Nothing
        'job = New Job()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        Dim main = New MainWindow()
        Dim parent = Utilities.GetParentWindow(Me)
        Utilities.ShowHide(parent, main)
    End Sub
End Class
