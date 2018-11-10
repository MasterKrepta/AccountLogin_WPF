Public Class ucCreateProducts

    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        Dim main = New MainWindow()
        Dim parent = Utilities.GetParentWindow(Me)
        Utilities.ShowHide(parent, main)
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As RoutedEventArgs) Handles btnCreate.Click
        Dim prod As Product = New Product()
        Dim dg As DataGrid = newProduct

        prod.Name = newName.Text
        prod.Desc = newDesc.Text
        prod.Location = newLoc.Text
        prod.Cost = Double.Parse(newCost.Text)
        prod.SalePrice = Double.Parse(newSalePrice.Text)
        prod.QtyOnHand = Integer.Parse(newQty.Text)



        GetData.InsertProduct(prod)
        'GetData.ShowEmployee(emp)
        Dim main As New MainWindow()
        Dim parent As Window = Window.GetWindow(Me)
        Utilities.ShowHide(parent, main)
    End Sub
End Class
