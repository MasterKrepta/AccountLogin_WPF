Imports System.Data
Imports System.Data.SQLite
Imports AccountLogin_WPF

Module GetData

    'DataBase Connections
    Dim path As String = My.Application.Info.DirectoryPath + "\DATA\"
    Dim fileName As String = "main.db3"
    Dim fullPath As String = IO.Path.Combine(path, fileName)
    Public connPath As String = String.Format("Data Source={0}", fullPath)
    'TODO This affects the file in the debug folder, is this correct or do I need to tweak it for final release

    Public FinalizedJobs As List(Of Job) = New List(Of Job)

    Friend Sub ShowEmployee(emp As Employee)
        MessageBox.Show("Show the employee here")
    End Sub

    Public Sub UpdateEmployee(employee As Employee)
        'TODO this will only work with the same name because we dont have a employee number var
        Dim cmd As SQLiteCommand = Nothing
        '"INSERT INTO Employees(Name, Type, Title, PayRate, Active) VALUES (@Name, @Type, @Title, @Pay, @Active)"
        cmd = New SQLiteCommand("Update Employees SET Type = @NewType, Title = @NewTitle, PayRate = @NewPayRate, Active = @Active WHERE Name= @Name")
        'UPDATE Customers
        'SET ContactName = 'Alfred Schmidt', City= 'Frankfurt'
        'WHERE CustomerID = 1;
        Using conn As SQLiteConnection = New SQLiteConnection(GetData.connPath)
            cmd.Connection = conn
            cmd.Connection.Open()
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = employee.Name
            cmd.Parameters.Add("@NewType", SqlDbType.VarChar).Value = employee.Type
            cmd.Parameters.Add("@NewTitle", SqlDbType.VarChar).Value = employee.Title
            cmd.Parameters.Add("@NewPayRate", SqlDbType.Real).Value = employee.PayRate
            cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = employee.Active

            cmd.ExecuteNonQuery()
            MessageBox.Show(employee.Name + " has been changed")

        End Using
    End Sub

    Public Function FindEmployee(query As Integer, grid As DataGrid)
        Dim cmd As SQLiteCommand = Nothing

        cmd = New SQLiteCommand("SELECT * FROM Employees WHERE Name = @Query")
        Using conn As SQLiteConnection = New SQLiteConnection(GetData.connPath)
            cmd.Connection = conn
            cmd.Connection.Open()
            cmd.Parameters.Add("@Query", SqlDbType.VarChar).Value = query.ToString()

            Dim adapter As New SQLiteDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adapter.Fill(dt)

            grid.ItemsSource = dt.DefaultView()
        End Using
    End Function

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

    Public Sub InsertProduct(prod As RawMaterial)
        Using conn As SQLiteConnection = New SQLiteConnection(connPath)
            Dim insertString As String = "INSERT INTO RawMaterials(Name, Description, Location, Cost, SalePrice, QtyOnHand) 
                                                        VALUES (@Name, @Desc, @Loc, @Cost, @SalePrice, @Qty)"
            Dim cmd As New SQLiteCommand(insertString, conn)

            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = prod.Name.ToUpper()
            cmd.Parameters.Add("@Desc", SqlDbType.VarChar).Value = prod.Desc.ToUpper()
            cmd.Parameters.Add("@Loc", SqlDbType.VarChar).Value = prod.Location.ToUpper()
            cmd.Parameters.Add("@Cost", SqlDbType.Real).Value = prod.Cost
            cmd.Parameters.Add("@SalePrice", SqlDbType.Real).Value = prod.SalePrice
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = prod.QtyOnHand

            conn.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show(prod.Name + " has been added")

            conn.Close()
        End Using
    End Sub

    Public Sub CreateFinshedGood(fin As FinishedGood)
        Using conn As SQLiteConnection = New SQLiteConnection(connPath)
            Dim insertString As String = "INSERT INTO FinishedGoods(FinishedName, RawMaterial_01, RawMaterial_02, 
                                                                    RawMaterial_03, RawMaterial_04, RawMaterial_05,
                                                                    MatCost, SalePrice) 
                                                        VALUES (@Name, @raw_01, @raw_02, @raw_03, 
                                                                @raw_04, @raw_05, @Cost, @SalePrice)"
            Dim cmd As New SQLiteCommand(insertString, conn)

            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = fin.finName.ToUpper()
            cmd.Parameters.Add("@raw_01", SqlDbType.VarChar).Value = fin.rawMaterials(0).Name
            cmd.Parameters.Add("@raw_02", SqlDbType.VarChar).Value = fin.rawMaterials(1).Name
            cmd.Parameters.Add("@raw_03", SqlDbType.VarChar).Value = fin.rawMaterials(2).Name
            cmd.Parameters.Add("@raw_04", SqlDbType.VarChar).Value = fin.rawMaterials(3).Name
            cmd.Parameters.Add("@raw_05", SqlDbType.VarChar).Value = fin.rawMaterials(4).Name
            cmd.Parameters.Add("@Cost", SqlDbType.Real).Value = fin.matCost
            cmd.Parameters.Add("@SalePrice", SqlDbType.Real).Value = fin.SalePrice

            conn.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show(fin.finName + " has been added")

            conn.Close()
        End Using
    End Sub
    Public Function GetProduct(prodName As String)
        Using conn As SQLiteConnection = New SQLiteConnection(connPath)
            Dim query As String = "SELECT * FROM RawMaterials WHERE Name = @Query"
            Dim cmd As New SQLiteCommand(query, conn)
            cmd.Parameters.Add("@Query", SqlDbType.VarChar).Value = prodName
            conn.Open()
            cmd.ExecuteNonQuery()

            Using reader As SQLiteDataReader = cmd.ExecuteReader()
                Dim prod As New RawMaterial()
                While reader.Read()
                    prod.Name = Convert.ToString(reader("Name")).ToUpper()
                    prod.Desc = Convert.ToString(reader("Description"))
                    prod.Location = Convert.ToString(reader("Location"))
                    prod.Cost = Convert.ToDouble(reader("Cost"))
                    prod.SalePrice = Convert.ToDouble(reader("Cost"))
                    prod.QtyOnHand = Convert.ToInt32(reader("QtyOnHand"))
                    Return prod
                    'TODO Manage Error Handleing
                End While
            End Using
            conn.Close()
        End Using
    End Function
    Public Sub InsertJob(job As Job)
        Using conn As SQLiteConnection = New SQLiteConnection(connPath)
            Dim insertString As String = "INSERT INTO Sales(SaleNumber, ProductSold, QtySold, TotalMatCost, FinalSalePrice) 
                                                    VALUES (@SaleNum, @Product, @Qty, @TotalCost, @FinalSale)"
            Dim cmd As New SQLiteCommand(insertString, conn)

            cmd.Parameters.Add("@SaleNum", SqlDbType.Int).Value = job.SalesNum
            cmd.Parameters.Add("@Product", SqlDbType.VarChar).Value = job.ProductSold.Name

            cmd.Parameters.Add("@Qty", SqlDbType.VarChar).Value = job.QtySold
            cmd.Parameters.Add("@TotalCost", SqlDbType.Real).Value = job.TotalMatCost
            cmd.Parameters.Add("@FinalSale", SqlDbType.Real).Value = job.FinalSale

            conn.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Work Order # " + job.SalesNum.ToString() + " has been added")

            conn.Close()
        End Using
    End Sub
    Public Function GetFinalJobs()
        Dim cmd As SQLiteCommand = Nothing

        cmd = New SQLiteCommand("SELECT * FROM CompletedJobs")
        Using conn As SQLiteConnection = New SQLiteConnection(GetData.connPath)
            cmd.Connection = conn
            cmd.Connection.Open()

            Using reader As SQLiteDataReader = cmd.ExecuteReader()
                Dim newJob As Job = New Job()
                While reader.Read()
                    newJob.SalesNum = Convert.ToInt32(reader("SaleNumber"))
                    Dim prodNum As String = Convert.ToString(reader("ProductSold"))
                    newJob.ProductSold = GetData.ConvertToRawMat(prodNum)
                    newJob.QtySold = Convert.ToInt32(reader("QtySold"))
                    newJob.TotalMatCost = Convert.ToDouble(reader("TotalMatCost"))
                    newJob.FinalSale = Convert.ToDouble(reader("FinalSalePrice"))
                    FinalizedJobs.Add(newJob)
                End While
            End Using
        End Using
    End Function

    Public Function FindJob(query As Integer, grid As DataGrid)
        Dim cmd As SQLiteCommand = Nothing

        cmd = New SQLiteCommand("SELECT * FROM Sales WHERE SaleNumber = @Query")
        Using conn As SQLiteConnection = New SQLiteConnection(GetData.connPath)
            Dim job As New Job()
            cmd.Connection = conn
            cmd.Connection.Open()
            cmd.Parameters.Add("@Query", SqlDbType.Int).Value = query

            Using reader As SQLiteDataReader = cmd.ExecuteReader()
                While reader.Read()

                    job.SalesNum = Convert.ToInt32(reader("SaleNumber"))
                    job.ProductSold = ConvertToRawMat(reader("ProductSold"))
                    job.QtySold = Convert.ToInt32(reader("QtySold"))
                    job.FinalSale = Convert.ToDouble(reader("FinalSalePrice"))

                End While
            End Using
            Dim adapter As New SQLiteDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adapter.Fill(dt)

            grid.ItemsSource = dt.DefaultView()
            Return job
        End Using
    End Function

    Public Function ConvertToRawMat(query As String)
        Dim cmd As SQLiteCommand = Nothing
        'Dim product As New Product()

        cmd = New SQLiteCommand("SELECT * FROM RawMaterials WHERE Name = @Query")
        Using conn As SQLiteConnection = New SQLiteConnection(GetData.connPath)
            cmd.Connection = conn
            cmd.Connection.Open()
            cmd.Parameters.Add("@Query", SqlDbType.VarChar).Value = query

            Using reader As SQLiteDataReader = cmd.ExecuteReader()
                Dim product As New RawMaterial()
                While reader.Read()

                    product.Name = Convert.ToString(reader("Name"))
                    product.Desc = Convert.ToString(reader("Description"))
                    product.Location = Convert.ToString(reader("Location"))
                    product.Cost = Convert.ToDouble(reader("Cost"))
                    product.SalePrice = Convert.ToDouble(reader("SalePrice"))
                    product.QtyOnHand = Convert.ToInt32(reader("QtyOnHand"))
                    Return product
                End While
            End Using
        End Using
    End Function

    Public Sub CompleteJob(job As Job)
        Using conn As SQLiteConnection = New SQLiteConnection(connPath)
            Dim insertString As String = "INSERT INTO CompletedJobs(SaleNumber, ProductSold, QtySold, TotalMatCost, FinalSalePrice) 
                                                    VALUES (@SaleNum, @Product, @Qty, @TotalCost, @FinalSale)"
            Dim cmd As New SQLiteCommand(insertString, conn)

            cmd.Parameters.Add("@SaleNum", SqlDbType.Int).Value = job.SalesNum
            cmd.Parameters.Add("@Product", SqlDbType.VarChar).Value = job.ProductSold.Name

            cmd.Parameters.Add("@Qty", SqlDbType.VarChar).Value = job.QtySold
            cmd.Parameters.Add("@TotalCost", SqlDbType.Real).Value = job.TotalMatCost
            cmd.Parameters.Add("@FinalSale", SqlDbType.Real).Value = job.FinalSale

            conn.Open()
            'ADD to completed Jobs
            cmd.ExecuteNonQuery()
            MessageBox.Show("Work Order # " + job.SalesNum.ToString() + " has been Completed")
            FinalizedJobs.Add(job)
            'Remove from the active sales jobs
            RemoveJob(job)
            conn.Close()
        End Using
    End Sub

    Public Sub RemoveJob(job As Job)
        Using conn As SQLiteConnection = New SQLiteConnection(connPath)
            Dim insertString As String = "DELETE FROM Sales WHERE @Query"
            Dim cmd As New SQLiteCommand(insertString, conn)

            cmd.Parameters.Add("@Query", SqlDbType.Int).Value = job.SalesNum

            conn.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Work Order # " + job.SalesNum.ToString() + " has been added")

            conn.Close()
        End Using
    End Sub

    Sub UpdateCardex(prod As RawMaterial, changedField As String, oldVal As String, newVal As String)
        'TODO This needs planned out better, currently not changing products at all in this application
        'I will need to change the system: What exactly do i want the cardex tracking
        '1: Track changes using a join comparing changes between products
        '2: Maybe we need an order pull system first to assign raw materials to work orders
        Using conn As SQLiteConnection = New SQLiteConnection(connPath)
            Dim insertString As String = ("INSERT INTO Cardex(Product, ChangedField, DateTime, OldValue, NewValue)
                                             VALUES(@Product, @ChangedField, @DateTime, @OldValue, @NewValue)")
            Dim cmd As New SQLiteCommand(insertString, conn)

            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = prod.Name.ToUpper()
            cmd.Parameters.Add("@ChangedField", SqlDbType.VarChar).Value = changedField
            cmd.Parameters.Add("@DateTime", SqlDbType.Time).Value = DateTime.Now.ToShortDateString()
            cmd.Parameters.Add("@OldValue", SqlDbType.VarChar).Value = oldVal
            cmd.Parameters.Add("@NewValue", SqlDbType.VarChar).Value = newVal

            conn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Module