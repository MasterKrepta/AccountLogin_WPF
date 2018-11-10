Imports System.Data
Imports System.Data.SQLite

Public Class ucChangeEmployee
    Private Sub btnGet_Click(sender As Object, e As RoutedEventArgs) Handles btnGet.Click
        Dim empName As String

        If Not searchBox.Text Is Nothing Then
            empName = searchBox.Text
        End If

        DisplaySearch(empName, SelectedPart)
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As RoutedEventArgs) Handles btnConfirm.Click

    End Sub

    Private Sub btnClear_Click(sender As Object, e As RoutedEventArgs) Handles btnClear.Click
        searchBox.Clear()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        Dim main = New MainWindow()
        Dim parent = Utilities.GetParentWindow(Me)
        Utilities.ShowHide(parent, main)
    End Sub

    Sub DisplaySearch(query As String, grid As DataGrid)
        Dim cmd As SQLiteCommand = Nothing

        'cmd = New SQLiteCommand("SELECT * FROM Sales WHERE SaleNumber = @Query")
        cmd = New SQLiteCommand("SELECT * FROM Employees WHERE Name = @Query")
        Using conn As SQLiteConnection = New SQLiteConnection(GetData.connPath)
            cmd.Connection = conn
            cmd.Connection.Open()
            cmd.Parameters.Add("@Query", SqlDbType.VarChar).Value = query

            Dim adapter As New SQLiteDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adapter.Fill(dt)

            grid.ItemsSource = dt.DefaultView()
        End Using
    End Sub
End Class
