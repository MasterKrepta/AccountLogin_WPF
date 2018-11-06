Public Class Product

    Public Name As String
    Public Desc As String
    Public Location As String
    Public Cost As Double
    Public SalePrice As Double
    Public QtyOnHand As Integer

    Public Sub New()

    End Sub
    Public Sub New(name As String, desc As String, loc As String, cost As Double, salePrice As Double, qty As Integer)
        Me.Name = name
        Me.Desc = desc
        Me.Location = loc
        Me.Cost = cost
        Me.SalePrice = salePrice
        Me.QtyOnHand = qty

    End Sub

    '?Should this be in a seperate clase or controlled here and product passed to a func?
    'Increase Inventory
    'Decrease Inventory

    Public Sub Description()
        Console.WriteLine("Product Name: " + Name)
        Console.WriteLine("-----------------------")
        Console.WriteLine("Product Location: " + Location)
        Console.WriteLine("Cost: " + Cost)
        Console.WriteLine("Sales Price: " + SalePrice)
        Console.WriteLine("QTY on hand: " + QtyOnHand)
    End Sub

End Class
