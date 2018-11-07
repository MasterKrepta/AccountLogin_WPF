Imports System.Data
Imports System.Data.SQLite
Public Class ProductionManagement

    Public Sub OnLoad(sender As Object, e As RoutedEventArgs)
        Try
            Dim cmd As SQLiteCommand = Nothing
            Dim employees As New List(Of Employee)()
            Dim entity As Employee = Nothing

            cmd = New SQLiteCommand("SELECT * FROM Sales")
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

    Private Sub btnProfits_Click(sender As Object, e As RoutedEventArgs) Handles btnProfits.Click
        Dim profit As New ShowProfit()
        Utilities.ShowHide(Me, profit)
    End Sub
End Class
