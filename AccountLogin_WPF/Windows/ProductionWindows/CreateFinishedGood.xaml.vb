Public Class CreateFinishedGood

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        Dim main = New MainWindow()
        Dim parent = Utilities.GetParentWindow(Me)
        Utilities.ShowHide(parent, main)
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As RoutedEventArgs) Handles btnCreate.Click
        Dim fin As FinishedGood = New FinishedGood()
        Try
            'TODO set up error checking in real time
            fin.finName = newName.Text.ToUpper()
            fin.rawMaterials.Add(GetData.GetProduct(newRaw1.Text.ToUpper()))
            fin.rawMaterials.Add(GetData.GetProduct(newRaw2.Text.ToUpper()))
            fin.rawMaterials.Add(GetData.GetProduct(newRaw3.Text.ToUpper()))
            fin.rawMaterials.Add(GetData.GetProduct(newRaw4.Text.ToUpper()))
            fin.rawMaterials.Add(GetData.GetProduct(newRaw5.Text.ToUpper()))
            For Each mat In fin.rawMaterials
                fin.matCost += mat.Cost
            Next
            fin.SalePrice = Convert.ToDouble(newSalePrice.Text)

            GetData.CreateFinshedGood(fin)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        Dim main As New MainWindow()
        Dim parent As Window = Window.GetWindow(Me)
        Utilities.ShowHide(parent, main)
    End Sub
End Class
