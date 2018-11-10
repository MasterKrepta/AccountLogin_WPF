

Public Class ucShowEmployee
    Private Sub btnCreate_Click(sender As Object, e As RoutedEventArgs) Handles btnCreate.Click
        Dim emp As Employee = New Employee()
        Dim dg As DataGrid = newEmployee
        emp.Name = newName.Text
        emp.Type = newType.Text
        emp.Title = newTitle.Text

        Try
            emp.PayRate = Double.Parse(newPay.Text)
            'MessageBox.Show("Can Parse " + emp.PayRate.ToString())
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        GetData.InsertEmployee(emp)
        'GetData.ShowEmployee(emp)
        Dim main As New MainWindow()
        Dim parent As Window = Window.GetWindow(Me)
        Utilities.ShowHide(parent, main)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        Dim main = New MainWindow()
        Dim parent = Utilities.GetParentWindow(Me)
        Utilities.ShowHide(parent, main)
    End Sub
End Class
