Imports System.Data.SQLite
Imports System.Data
Public Class InventoryManagement

    Public Sub OnLoad(sender As Object, e As RoutedEventArgs)
        Try
            Dim cmd As SQLiteCommand = Nothing
            Dim products As New List(Of Product)()
            Dim entity As Employee = Nothing

            cmd = New SQLiteCommand("SELECT * FROM Products")
            Using conn As SQLiteConnection = New SQLiteConnection(GetData.connPath)
                cmd.Connection = conn
                cmd.Connection.Open()

                Dim adapter As New SQLiteDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adapter.Fill(dt)
                TestGrid.ItemsSource = dt.DefaultView

            End Using
        Catch ex As Exception
            System.Windows.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        Dim main As New MainWindow()
        Utilities.ShowHide(Me, main)
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As RoutedEventArgs) Handles btnCreate.Click
        Dim newProd As New CreateProduct()
        Utilities.ShowHide(Me, newProd)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As RoutedEventArgs) Handles btnRemove.Click
        Dim remove As New RemoveProduct()
        Utilities.ShowHide(Me, remove)
    End Sub
End Class
