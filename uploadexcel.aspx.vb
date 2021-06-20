Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports GridManager

Partial Class uploadexcel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            'this code be executed only first time any event happen on web page
            Session("eid") = "009383"
            Session("perarea") = "1002"
            Session("work_flow_id") = "009383"
            Session("myIP") = Request.UserHostAddress


        End If

        'below code  will be executed every time any event happen on web page


    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If (afuFile.HasFile) Then
            'check file is attached or not
            Dim TheFile As String = Strings.LCase(Replace(System.IO.Path.GetFileName(afuFile.FileName), " ", "_"))
            Session("thefile") = TheFile
            Try


                afuFile.SaveAs(Server.MapPath("~/upload/") + TheFile)
                lblError1.Text = TheFile + " uploaded! from : " + Request.UserHostAddress  '+ mysql
                ' rebindGridView(Session("CurrentQuery"), gvCirculars)
                Return
            Catch Exc As Exception

                lblError1.Text = "File not uploaded: " + Exc.Message
                Return
            End Try
        Else
            lblError1.Text = "File not attached " & afuFile.FileName
        End If

    End Sub
    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, ByVal isHDR As String)
        Dim conStr As String = ""
        Select Case Extension
            Case ".xls"
                'Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings("xlsCon").ConnectionString
                Exit Select
            Case ".xlsx"
                'Excel 07
                conStr = ConfigurationManager.ConnectionStrings("xlsxCon").ConnectionString
                Exit Select
        End Select
        conStr = String.Format(conStr, FilePath, isHDR)

        Dim excelData As New DataTable

        Using connExcel As New OleDbConnection(conStr)
            'Get the name of First Sheet
            connExcel.Open()
            Dim dtExcelSchema As DataTable
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
            connExcel.Close()
            'Get all data from the InventoryData worksheet 
            Dim myCommand As New OleDbCommand
            myCommand.CommandText = "SELECT * From [" & SheetName & "]"
            myCommand.Connection = connExcel

            'Read data into DataTable 
            Dim myAdapter As New OleDbDataAdapter
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(excelData)

            connExcel.Close()

        End Using

        

        

        'Bind Data to GridView
        GridView1.Caption = Session("thefile").ToString
        GridView1.DataSource = excelData
        GridView1.DataBind()

        'bulk copy
        Using destinationConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("vinCon").ConnectionString)
            destinationConnection.Open()

            Using bulkCopy As New SqlBulkCopy(destinationConnection)
                bulkCopy.DestinationTableName = "holiday_code_master"

                bulkCopy.WriteToServer(excelData)
            End Using

            destinationConnection.Close()
        End Using
    End Sub
    Protected Sub PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
        Dim FileName As String = GridView1.Caption
        ' Dim Extension As String = Path.GetExtension(FileName)
        Dim FilePath As String = Server.MapPath(FolderPath + FileName)

        ' Import_To_Grid(FilePath, Extension, "Yes")
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub




End Class
