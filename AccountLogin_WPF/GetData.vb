Imports System.Data
Imports System.Data.SQLite
Imports AccountLogin_WPF

Module GetData

    Dim path As String = My.Application.Info.DirectoryPath + "\DATA\"
    Dim fileName As String = "main.db3"
    Dim fullPath As String = IO.Path.Combine(path, fileName)
    'TODO This affects the file in the debug folder, is this correct or do I need to tweak it for final release

    Public connPath As String = String.Format("Data Source={0}", fullPath)

    Friend Sub ShowEmployee(emp As Employee)
        MessageBox.Show("Show the employee here")
    End Sub

    'Public Sub GetEmployee(emp As Employee, cbx As ComboBox)
    '    Try
    '        Dim cmd As SQLiteCommand = Nothing
    '        Dim employees As New List(Of Employee)()
    '        Dim entity As Employee = Nothing

    '        'mycommand = New SqlCommand("insert into tbl_cus([name],[class],[phone],[address]) 
    '        'values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')", myconnection)
    '        cmd = New SQLiteCommand("INSERT INTO Employees ([Name], [Type], [Title], [PayRate])
    '                                VALUES ('" & emp.Name & "','" & emp.Type & "','" & emp.Title & "','" & Convert.ToDouble(emp.PayRate))


    '        Using conn As SQLiteConnection = New SQLiteConnection("Data Source=DATA\main.db3;Version=3")
    '            cmd.Connection = conn
    '            cmd.Connection.Open()
    '            'MessageBox.Show("Connection established")
    '            Dim adapter As New SQLiteDataAdapter(cmd)
    '            MessageBox.Show("New Row Inserted")

    '            Dim dt As DataTable = New DataTable
    '            adapter.Fill(dt)
    '            cbx.ItemsSource = dt.DefaultView
    '            'TestGrid.ItemsSource = dt.DefaultView


    '        End Using
    '    Catch ex As Exception
    '        System.Windows.MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Public Sub InsertEmployee(emp As Employee)
        Using conn As SQLiteConnection = New SQLiteConnection(connPath)
            Dim insertString As String = "INSERT INTO Employees(Name, Type, Title, PayRate, Active) VALUES (@Name, @Type, @Title, @Pay, @Active)"
            Dim cmd As New SQLiteCommand(insertString, conn)

            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = emp.Name
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = emp.Type
            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = emp.Title
            cmd.Parameters.Add("@Pay", SqlDbType.Real).Value = emp.PayRate
            cmd.Parameters.Add("@Active", SqlDbType.Int).Value = 1

            conn.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show(emp.Name + " has been added")


            conn.Close()
        End Using
    End Sub
End Module