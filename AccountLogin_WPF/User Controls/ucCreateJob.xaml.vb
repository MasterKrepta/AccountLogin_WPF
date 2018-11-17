Public Class ucCreateJob
    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        Dim main = New MainWindow()
        Dim parent = Utilities.GetParentWindow(Me)
        Utilities.ShowHide(parent, main)
    End Sub

    Private Sub OnLoad()
        newNum.Text = (GetData.FinalizedJobs.Count + GetData.OpenJobs.Count) + 1
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As RoutedEventArgs) Handles btnCreate.Click
        Dim newJob As New Job()
        Try
            newJob.SalesNum = newNum.Text

            'TODO need to use Polymorphism here with a base class
            newJob.ProductSold = GetData.GetRawMaterial(newProd.Text.ToUpper())
            If newJob.ProductSold Is Nothing Then
                MessageBox.Show("Not a raw material, trying finished")
                newJob.ProductSold = GetData.GetFinishedGood(newProd.Text.ToUpper())
            End If
            If newJob.ProductSold Is Nothing Then
                MessageBox.Show("Please enter a valid raw or finished good")
                newProd.Text = Nothing
                newQty.Text = Nothing
                Return
            End If


            newJob.QtySold = newQty.Text

            newJob.TotalMatCost = newJob.ProductSold.Cost
            newJob.FinalSale = CalculateTotalSale(newJob.ProductSold, newJob.QtySold)
            GetData.FinalizedJobs.Add(newJob)
            GetData.InsertJob(newJob)
        Catch ex As Exception
            MessageBox.Show(ex.Message + " prod is not found.")

            Return
        End Try
    End Sub


    Function CalculateTotalSale(productSold As Sellable, qtySold As Integer)
        Dim sum As Double = productSold.SalePrice * qtySold
        Return sum
    End Function
End Class