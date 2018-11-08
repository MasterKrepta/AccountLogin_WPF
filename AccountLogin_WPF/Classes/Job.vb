Public Class Job

    Public SalesNum As Integer
    Public ProductSold As String
    Public QtySold As Integer
    Public TotalMatCost As Double
    Public FinalSale As Double

    Public Sub New()

    End Sub
    Public Sub New(num As Integer, product As String, qty As Integer, cost As Double, final As Double)
        Me.SalesNum = num
        Me.ProductSold = product
        Me.QtySold = qty
        Me.TotalMatCost = cost
        Me.FinalSale = final
    End Sub

    Public Sub Description()

    End Sub
End Class
