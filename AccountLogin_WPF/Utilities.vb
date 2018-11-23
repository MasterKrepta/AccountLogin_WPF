Module Utilities
    Public Sub ShowHide(oldWin As Window, newWin As Window)
        oldWin.Hide()
        newWin.Show()
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

    Public Sub BackToMain(win As Window)
        Dim main As New MainWindow()
        Utilities.ShowHide(win, main)
    End Sub

    Public Sub BackToEmployee(win As Window)
        Dim main As New EmployeeManagement()
        Utilities.ShowHide(win, main)
    End Sub

    Public Sub BackToInventory(win As Window)
        Dim main As New InventoryManagement()
        Utilities.ShowHide(win, main)
    End Sub

    Public Sub BackToProduction(win As Window)
        Dim main = New ProductionManagement()
        Utilities.ShowHide(win, main)
    End Sub
End Module
