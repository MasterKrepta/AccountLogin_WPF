Public Class ucCreateProducts

    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click

        Dim parent = Utilities.GetParentWindow(Me)
        Utilities.BackToInventory(parent)
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As RoutedEventArgs) Handles btnCreate.Click
        Dim prod As RawMaterial = New RawMaterial()
        Dim dg As DataGrid = newProduct '?This may be unused

        prod.Name = newName.Text
        prod.Desc = newDesc.Text
        prod.Location = newLoc.Text
        prod.Cost = Double.Parse(newCost.Text)
        prod.SalePrice = Double.Parse(newSalePrice.Text)
        prod.QtyOnHand = Integer.Parse(newQty.Text)

        GetData.InsertProduct(prod)
        'GetData.ShowEmployee(emp)
        Dim parent = Utilities.GetParentWindow(Me)
        Utilities.BackToInventory(parent)
    End Sub
End Class
