Public Class ucCompleteJob
    Dim foundJob As New Job()
    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        Dim main = New MainWindow()
        Dim parent = Utilities.GetParentWindow(Me)
        Utilities.ShowHide(parent, main)
    End Sub

    Private Sub btnComplete_Click(sender As Object, e As RoutedEventArgs) Handles btnComplete.Click
        If foundJob Is Nothing Then
            MessageBox.Show("No job Selected: Click Search")
            Return
        End If
        Try
            Dim query = Convert.ToInt32(txtQuery.Text)
            foundJob = GetData.FindJob(query, completeJob)
            GetData.CompleteJob(foundJob)
        Catch ex As Exception

            MessageBox.Show("job not found::: " + ex.Message)
        End Try

    End Sub

    Private Sub btnFind_Click(sender As Object, e As RoutedEventArgs) Handles btnFind.Click
        Dim query As Integer
        Try
            query = Convert.ToInt32(txtQuery.Text)
            foundJob = GetData.FindJob(query, completeJob)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return
        End Try


    End Sub
End Class
