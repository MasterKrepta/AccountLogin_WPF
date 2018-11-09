Public Class ucCompleteJob
    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        Dim main As New MainWindow()
        Dim parent As Window = Window.GetWindow(Me)
        Utilities.ShowHide(parent, main)
    End Sub

    Private Sub btnComplete_Click(sender As Object, e As RoutedEventArgs) Handles btnComplete.Click

        Dim query As Integer
        Try
            query = Convert.ToInt32(txtQuery.Text)
        Catch ex As Exception
            Return
        End Try

        GetData.FindJob(query, completeJob)
    End Sub
End Class
