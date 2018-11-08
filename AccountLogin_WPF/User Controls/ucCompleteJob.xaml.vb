Public Class ucCompleteJob
    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        Dim main As New MainWindow()
        Dim parent As Window = Window.GetWindow(Me)
        Utilities.ShowHide(parent, main)
    End Sub
End Class
