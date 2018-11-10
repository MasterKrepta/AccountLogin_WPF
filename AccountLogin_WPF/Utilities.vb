Module Utilities
    Public Sub ShowHide(oldWin As Window, newWin As Window)
        oldWin.Hide()
        newWin.Show()
    End Sub

    Public Sub FindJob(query As String)

    End Sub

    Public Function GetParentWindow(ByVal child As DependencyObject) As Window
        Dim parentObject As DependencyObject = VisualTreeHelper.GetParent(child)

        If parentObject Is Nothing Then
            Return Nothing
        End If

        Dim parent As Window = TryCast(parentObject, Window)
        If parent IsNot Nothing Then
            Return parent
        Else
            Return GetParentWindow(parentObject)
        End If
    End Function
End Module
