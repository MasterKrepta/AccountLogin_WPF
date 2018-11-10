Imports System.Data.SQLite
Imports System.Data
Public Class EmployeeManagement
    Public Sub OnLoad(sender As Object, e As RoutedEventArgs)
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
    Private Sub btnCreate_Click(sender As Object, e As RoutedEventArgs) Handles btnCreate.Click
        Dim create As New CreateEmployee()
        Utilities.ShowHide(Me, create)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        Dim main As New MainWindow()
        Utilities.ShowHide(Me, main)
    End Sub

    Private Sub btnChange_Click(sender As Object, e As RoutedEventArgs) Handles btnChange.Click
        Dim changeEmp As New ChangeEmployee()
        Utilities.ShowHide(Me, changeEmp)
    End Sub
End Class
