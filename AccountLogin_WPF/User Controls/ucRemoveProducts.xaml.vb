Imports System.Data
Imports System.Data.SQLite

Public Class ucRemoveProducts

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        Dim parent = Utilities.GetParentWindow(Me)
        Utilities.BackToInventory(parent)
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As RoutedEventArgs) Handles btnConfirm.Click
        ProcessRemove(searchBox.Text)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As RoutedEventArgs) Handles btnClear.Click
        searchBox.Clear()
    End Sub

    Private Sub btnGet_Click(sender As Object, e As RoutedEventArgs) Handles btnGet.Click
        Dim partNum As String

        If Not searchBox.Text Is Nothing Then
            partNum = searchBox.Text
        End If

        DisplaySearch(partNum, SelectedPart)
    End Sub

    Sub DisplaySearch(query As String, grid As DataGrid)
        Dim cmd As SQLiteCommand = Nothing

        'cmd = New SQLiteCommand("SELECT * FROM Sales WHERE SaleNumber = @Query")
        cmd = New SQLiteCommand("SELECT * FROM Products WHERE Name = @Query")
        Using conn As SQLiteConnection = New SQLiteConnection(GetData.connPath)
            cmd.Connection = conn
            cmd.Connection.Open()
            cmd.Parameters.Add("@Query", SqlDbType.VarChar).Value = query.ToUpper()

            Dim adapter As New SQLiteDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adapter.Fill(dt)

            grid.ItemsSource = dt.DefaultView()
        End Using
    End Sub

    Sub ProcessRemove(query As String)
        Dim cmd As SQLiteCommand = Nothing

        'cmd = New SQLiteCommand("SELECT * FROM Sales WHERE SaleNumber = @Query")
        cmd = New SQLiteCommand("DELETE * FROM Products WHERE Name = @Query")
        Using conn As SQLiteConnection = New SQLiteConnection(GetData.connPath)
            cmd.Connection = conn
            cmd.Connection.Open()
            cmd.Parameters.Add("@Query", SqlDbType.VarChar).Value = query

            MessageBox.Show("Part: " + query + " has been removed!")

        End Using
    End Sub
End Class
