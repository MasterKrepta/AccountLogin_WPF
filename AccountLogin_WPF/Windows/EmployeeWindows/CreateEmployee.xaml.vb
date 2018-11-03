Public Class CreateEmployee
    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        Dim EM As New EmployeeManagement()
        Utilities.ShowHide(Me, EM)
    End Sub
End Class
