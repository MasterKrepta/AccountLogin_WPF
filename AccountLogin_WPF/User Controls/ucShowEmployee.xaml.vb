Public Class ucShowEmployee
    Private Sub btnCreate_Click(sender As Object, e As RoutedEventArgs) Handles btnCreate.Click
        Dim emp As Employee = New Employee()
        Dim dg As DataGrid = newEmployee
        emp.Name = newName.Text
        emp.Type = newType.Text
        emp.Title = newTitle.Text

        Try
            emp.PayRate = Double.Parse(newPay.Text)
            GetData.InsertEmployee(emp)

            Dim parent As Window = Window.GetWindow(Me)
            Utilities.BackToEmployee(parent)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click

        Dim parent = Utilities.GetParentWindow(Me)
        Utilities.BackToEmployee(parent)
    End Sub
End Class