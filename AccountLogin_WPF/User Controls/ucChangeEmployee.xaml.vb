Imports System.Data
Imports System.Data.SQLite

Public Class ucChangeEmployee
    Dim employee As New Employee()


    Private Sub btnGet_Click(sender As Object, e As RoutedEventArgs) Handles btnGet.Click
        Dim empName As String

        If Not searchBox.Text Is Nothing Then
            empName = searchBox.Text
            DisplaySearch(empName.ToUpper(), SelectedEmployee)
        End If


    End Sub

    Private Sub btnClear_Click(sender As Object, e As RoutedEventArgs) Handles btnClear.Click
        searchBox.Clear()
        SelectedEmployee.ItemsSource = Nothing
        employee = New Employee()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click

        Dim parent = Utilities.GetParentWindow(Me)
        Utilities.BackToMain(parent)
    End Sub

    Sub DisplaySearch(query As String, grid As DataGrid)
        Dim cmd As SQLiteCommand = Nothing

        cmd = New SQLiteCommand("SELECT * FROM Employees WHERE upper(Name) = @Query")
        Using conn As SQLiteConnection = New SQLiteConnection(GetData.connPath)
            cmd.Connection = conn
            cmd.Connection.Open()
            cmd.Parameters.Add("@Query", SqlDbType.VarChar).Value = query

            Using reader As SQLiteDataReader = cmd.ExecuteReader()
                While reader.Read()
                    employee.Name = Convert.ToString(reader("Name"))

                    employee.Type = Convert.ToString(reader("Type"))
                    employee.Title = Convert.ToString(reader("Title"))
                    employee.PayRate = Convert.ToDouble(reader("PayRate"))
                    'TODO Figure out if the active status will be an issue
                    'Currently Assuming all employees are created active
                End While
            End Using

            Dim adapter As New SQLiteDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adapter.Fill(dt)

            grid.ItemsSource = dt.DefaultView()
        End Using
    End Sub

    Private Sub btnChange_Click(sender As Object, e As RoutedEventArgs) Handles btnChange.Click

        If Not employee Is Nothing And Not employee.Name Is Nothing Then
            Dim editEmployee = New EditEmployeeDetails()
            editEmployee.GetEmployee(employee)
            editEmployee.Show()
        Else
            MessageBox.Show("No employee Selected")
            Return
        End If

    End Sub
End Class
