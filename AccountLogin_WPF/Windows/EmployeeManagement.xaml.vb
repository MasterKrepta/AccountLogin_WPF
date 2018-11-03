Public Class EmployeeManagement
    Private Sub btnCreate_Click(sender As Object, e As RoutedEventArgs) Handles btnCreate.Click
        Dim create As New CreateEmployee()
        Utilities.ShowHide(Me, create)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        Dim main As New MainWindow()
        Utilities.ShowHide(Me, main)
    End Sub
End Class
