Public Class Job

    Public SalesNum As Integer
    Public ProductSold As Sellable
    Public QtySold As Integer
    Public TotalMatCost As Double
    Public FinalSale As Double

    Public Sub New()
        'TODO this is broken at the moment, handle it differently since sales nums auto increment
        Me.SalesNum = GetData.FinalizedJobs.Count + 1
    End Sub
    Public Sub New(num As Integer, product As Sellable, qty As Integer, cost As Double, final As Double)
        Me.SalesNum = GetData.FinalizedJobs.Count + 1
        Me.ProductSold = product
        Me.QtySold = qty
        Me.TotalMatCost = cost
        Me.FinalSale = final
    End Sub

    Public Sub Description()

    End Sub

End Class
