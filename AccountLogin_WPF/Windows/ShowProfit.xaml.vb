Imports System.Data
Imports System.Data.SQLite
Public Class ShowProfit
    Public Sub OnLoad()
        'Profits
        Dim totalSales As Double = 0
        Dim totalCost As Double = 0
        Dim numJobs As Integer = 0

        'Calculate

        For Each job In GetData.FinalizedJobs
            totalSales += job.FinalSale
            totalCost += job.TotalMatCost
            numJobs += 1
        Next

        'Update UI
        txtNumSales.Text = "Number Of Sales: " + numJobs.ToString()
        txtCost.Text = "Total Cost: " + totalCost.ToString()
        txtSales.Text = "Total Sales: " + totalSales.ToString()
        txtProfits.Text = "Total Profits: " + (totalSales - totalCost).ToString()

    End Sub

    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        Dim main As New MainWindow()
        Utilities.ShowHide(Me, main)
    End Sub
End Class
