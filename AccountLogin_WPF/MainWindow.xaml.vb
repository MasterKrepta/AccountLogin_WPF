Imports System.Data
Imports System.Data.SQLite
Class MainWindow

    Public Sub OnLoad(sender As Object, e As RoutedEventArgs)
        'Dim conn As New SQLiteConnection("Data Source=DATA\main.db3;Version=3")
        Try
            Dim cmd As SQLiteCommand = Nothing
            Dim employees As New List(Of Employee)()
            Dim entity As Employee = Nothing

            cmd = New SQLiteCommand("SELECT * FROM Employees")
            Using conn As SQLiteConnection = New SQLiteConnection("Data Source=DATA\main.db3;Version=3")
                cmd.Connection = conn
                cmd.Connection.Open()
                'MessageBox.Show("Connection established")
                Dim adapter As New SQLiteDataAdapter(cmd)
                Dim dt As DataTable = New DataTable
                adapter.Fill(dt)
                TestGrid.ItemsSource = dt.DefaultView
                'Using reader As SQLiteDataReader = cmd.ExecuteReader()
                '    'MessageBox.Show("Reader open")

                '    While reader.Read()

                '        entity = New Employee()
                '        entity.Name = reader.GetString(0)
                '        entity.Type = reader.GetString(1)
                '        entity.Title = reader.GetString(2)
                '        entity.PayRate = reader.GetDouble(3)

                '        employees.Add(entity)
                '    End While
                '    cmd.Connection.Close()
                '    TestGrid.ItemsSource = employees.ToList()
                '    System.Windows.MessageBox.Show("ALL IS GOOD")
                'End Using

            End Using
        Catch ex As Exception
            System.Windows.MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class
