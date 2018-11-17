Public Class CreateFinishedGood

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        Dim main = New MainWindow()
        'Dim parent = Utilities.GetParentWindow(Me)
        Utilities.ShowHide(Me, main)
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As RoutedEventArgs) Handles btnCreate.Click
        Dim fin As FinishedGood = New FinishedGood()
        Try
            'TODO set up error checking in real time
            fin.Name = newName.Text.ToUpper()
            fin.rawMaterials.Add(GetData.GetRawMaterial(newRaw1.Text.ToUpper()))
            fin.rawMaterials.Add(GetData.GetRawMaterial(newRaw2.Text.ToUpper()))
            fin.rawMaterials.Add(GetData.GetRawMaterial(newRaw3.Text.ToUpper()))
            fin.rawMaterials.Add(GetData.GetRawMaterial(newRaw4.Text.ToUpper()))
            fin.rawMaterials.Add(GetData.GetRawMaterial(newRaw5.Text.ToUpper()))
            For Each mat In fin.rawMaterials
                fin.Cost += mat.Cost
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
