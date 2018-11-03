Imports AccountLogin_WPF

Public Class Employee

    Public Enum EmployeeType
        Production
        Office
        Supervisor
        Manager
    End Enum

    Public Name As String
    Public Type As String
    Public Title As String
    Public PayRate As Double

    Public Sub New()

    End Sub
    Public Sub New(name As String, type As EmployeeType, title As String, pay As Double)
        Me.Name = name
        Me.Type = type
        Me.Title = title
        Me.PayRate = pay
        'TODO Add this to the data employees list/ Wichi is the database in this version
    End Sub

    Public Sub Description()
        Console.WriteLine("Employee Name: " + Name)
        Console.WriteLine("-----------------------")
        Console.WriteLine("Employee Type: " + Type)
        Console.WriteLine("Job Title: " + Title)
        Console.WriteLine("PayRate: " + PayRate + " per Hour.")
    End Sub
End Class
