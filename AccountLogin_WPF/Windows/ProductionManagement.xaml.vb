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

    Private Sub btnComplete_Click(sender As Object, e As RoutedEventArgs) Handles btnComplete.Click
        Dim completeJob As New CompleteJob()
        Utilities.ShowHide(Me, completeJob)
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As RoutedEventArgs) Handles btnCreate.Click
        Dim createJob As New CreateJob()
        Utilities.ShowHide(Me, createJob)
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As RoutedEventArgs) Handles btnQuery.Click
        Dim queryJob As New QueryJob()
        Utilities.ShowHide(Me, queryJob)
    End Sub
End Class
