Public Class FinishedGood
    Inherits Sellable

    Public rawMaterials As List(Of RawMaterial) = New List(Of RawMaterial)

    Sub New()

    End Sub

    Public Sub New(name As String, matRequired As List(Of RawMaterial), cost As Double, salePrice As Double)

        Me.Name = name
        For Each mat In matRequired
            mat.Name = mat.Name.ToUpper()
            Me.rawMaterials.Add(mat)
            Me.Cost += mat.Cost
        Next
        Me.SalePrice = salePrice
        'Update database with finished good
        GetData.CreateFinshedGood(Me)
    End Sub

End Class
