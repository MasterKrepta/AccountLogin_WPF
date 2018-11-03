Public Class Product

    Dim Name As String
    Dim Location As String
    Dim Cost As Double
    Dim SalePrice As Double
    Dim QtyOnHand As Integer

    Public Sub New(name As String, loc As String, cost As Double, salePrice As Double, qty As Integer)
        Me.Name = name
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
