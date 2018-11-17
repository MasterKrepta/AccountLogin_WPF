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
        Try
            newJob.SalesNum = newNum.Text
            newJob.ProductSold = GetData.GetProduct(newProd.Text)
            newJob.QtySold = newQty.Text

            newJob.TotalMatCost = newJob.ProductSold.Cost
            newJob.FinalSale = CalculateTotalSale(newJob.ProductSold, newJob.QtySold)
            GetData.FinalizedJobs.Add(newJob)
            GetData.InsertJob(newJob)
        Catch ex As Exception
            MessageBox.Show("Product " + newProd.Text + " is not found.")
            Return
        End Try
    End Sub


    Function CalculateTotalSale(productSold As RawMaterial, qtySold As Integer)
        Dim sum As Double = productSold.SalePrice * qtySold
        Return sum
    End Function
End Class