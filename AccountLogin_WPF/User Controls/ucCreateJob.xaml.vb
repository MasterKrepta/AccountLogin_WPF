Public Class ucCreateJob
    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        Dim main = New MainWindow()
        Dim parent = Utilities.GetParentWindow(Me)
        Utilities.ShowHide(parent, main)
    End Sub

    Private Sub OnLoad()
        newNum.Text = GetData.FinalizedJobs.Count + 1
    End Sub
    Private Sub btnCreate_Click(sender As Object, e As RoutedEventArgs) Handles btnCreate.Click
        Dim newJob As New Job()

        newJob.SalesNum = newNum.Text
        newJob.ProductSold = GetData.ConvertToProduct(newProd.Text)
        newJob.QtySold = newQty.Text
        newJob.TotalMatCost = newCost.Text
        newJob.FinalSale = newSalePrice.Text

        GetData.FinalizedJobs.Add(newJob)
        GetData.InsertJob(newJob)

    End Sub
End Class