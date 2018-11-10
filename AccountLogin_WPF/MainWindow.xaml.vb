Imports System.Data
Imports System.Data.SQLite
Class MainWindow

    Public Sub OnLoad(sender As Object, e As RoutedEventArgs)
        If GetData.FinalizedJobs.Count = 0 Then
            GetData.GetFinalJobs()
        End If

        Try
            Dim cmd As SQLiteCommand = Nothing
            Dim employees As New List(Of Employee)()
            Dim entity As Employee = Nothing

            cmd = New SQLiteCommand("SELECT * FROM Employees")
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

    Private Sub btnEmployee_Click(sender As Object, e As RoutedEventArgs) Handles btnEmployee.Click
        Dim empManage As New EmployeeManagement()
        Utilities.ShowHide(Me, empManage)
    End Sub

    Private Sub btnInventory_Click(sender As Object, e As RoutedEventArgs) Handles btnInventory.Click
        Dim invManage As New InventoryManagement()
        Utilities.ShowHide(Me, invManage)
    End Sub

    Private Sub btnProduction_Click(sender As Object, e As RoutedEventArgs) Handles btnProduction.Click
        Dim prodManage As New ProductionManagement()
        Utilities.ShowHide(Me, prodManage)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As RoutedEventArgs) Handles btnExit.Click
        Environment.Exit(0)
    End Sub
End Class
