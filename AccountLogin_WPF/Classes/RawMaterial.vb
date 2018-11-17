Public Class RawMaterial
    Inherits Sellable

    Public Desc As String
    Public Location As String
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
        Console.WriteLine("Raw Material Name: " + Name)
        Console.WriteLine("-----------------------")
        Console.WriteLine(" Location: " + Location)
        Console.WriteLine("Cost: " + Cost)
        Console.WriteLine("Sales Price: " + SalePrice)
        Console.WriteLine("QTY on hand: " + QtyOnHand)
    End Sub

End Class
