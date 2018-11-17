Public Class FinishedGood

    Public finName As String

    Public rawMaterials As List(Of RawMaterial) = New List(Of RawMaterial)
    Public matCost As Double
    Public SalePrice As Double

    Sub New()

    End Sub

    Public Sub New(name As String, matRequired As List(Of RawMaterial), cost As Double, salePrice As Double)
        Me.finName = name
        For Each mat In matRequired
            mat.Name = mat.Name.ToUpper()
            Me.rawMaterials.Add(mat)
            Me.matCost += mat.Cost
        Next
        Me.SalePrice = salePrice
        'Update database with finished good
        GetData.CreateFinshedGood(Me)
    End Sub

End Class
