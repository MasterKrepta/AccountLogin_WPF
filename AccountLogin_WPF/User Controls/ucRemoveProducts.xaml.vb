Public Class ucRemoveProducts


    Private Sub btnBack_Click(sender As Object, e As RoutedEventArgs) Handles btnBack.Click
        Dim main = New MainWindow()
        Dim parent = TryCast(Me.Parent, Window)
        If Not parent Is Nothing Then
            parent.Hide()
        End If
        main.Show()
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As RoutedEventArgs) Handles btnConfirm.Click

    End Sub

    Private Sub btnClear_Click(sender As Object, e As RoutedEventArgs) Handles btnClear.Click

    End Sub

    Private Sub btnGet_Click(sender As Object, e As RoutedEventArgs) Handles btnGet.Click

    End Sub
End Class
