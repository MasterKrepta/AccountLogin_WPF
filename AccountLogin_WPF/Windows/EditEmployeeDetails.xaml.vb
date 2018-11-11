Public Class EditEmployeeDetails
    Dim employee As Employee = Nothing

    Public Sub OnLoad()
        empName.Text = employee.Name
        newType.Text = employee.Type
        newTitle.Text = employee.Title
        newPay.Text = employee.PayRate.ToString()
        'TODO active issue again
    End Sub

    Public Sub GetEmployee(emp As Employee)
        employee = emp
    End Sub

    Private Sub btnConfirmChange_Click(sender As Object, e As RoutedEventArgs) Handles btnConfirmChange.Click
        employee.Type = newType.Text
        employee.Title = newTitle.Text
        employee.PayRate = Convert.ToDouble(newPay.Text)
        'TODO active settings
        GetData.UpdateEmployee(employee)
        Me.Close()
    End Sub

    Private Sub btnCancelChange_Click(sender As Object, e As RoutedEventArgs) Handles btnCancelChange.Click
        Me.Close()
    End Sub

End Class
