Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class dboperations
    ''##########################################################################
    ''' <summary>
    '''   ' class contains the function required for database operation.
    '''  Written by Vinod Kotiya
    ''' www.vinodkotiya.com
    ''' +919411103810
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function insertRecord(ByVal mysql As String) As String
        ' This function will insert/update the record based on mysql
        'Create Connection String
        'Dim DBConn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\intradb.mdf;Integrated Security=True;User Instance=True")
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader


            Try
                'connection.Close()
                connection.Open()
                sqlComm = New SqlCommand(mysql, connection)

                sqlReader = sqlComm.ExecuteReader()
                'Add Insert Statement
                sqlComm.Dispose()
                'Add Database Parameters
                'DBCmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = txtName.Text
                'DBCmd.Parameters.Add("@ContactNumber", SqlDbType.NChar).Value = txtCNumber.Text
                'DBCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txtAddress.Text
                'DBCmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = ddlCountry.SelectedItem.Text

                'lbldebug.text = "inserted"
                connection.Close()
                insertRecord = "ok"
                'Set the value of DataAdapter
                'DBAdap = New SqlDataAdapter("SELECT * FROM table1", DBConn)
                'Fill the DataSet
                'DBAdap.Fill(DS)
                'Bind with GridView control and Display the Record
                'gvShowRecord.DataSource = DS
                'gvShowRecord.DataBind()

            Catch exp As Exception
                'lbldebug.Text = exp.Message
                connection.Close()
                insertRecord = exp.Message

            End Try
            'Close Database connection
            'and Dispose Database objects
        End Using

    End Function
    Public Shared Function checkDatabase(ByVal myQuery As String) As Boolean
        ''this function will check any record exist or not in table according to myQuery
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            ' connection.Close()
            connection.Open()
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim dataTableRowCount As Integer
            Try
                sqlComm = New SqlCommand(myQuery, connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                dataTableRowCount = dt.Rows.Count
                sqlReader.Close()
                sqlComm.Dispose()
                If dataTableRowCount = 1 Then

                    connection.Close()
                    Return True
                Else
                    connection.Close()
                    Return False
                End If

            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                Return False
            End Try
            connection.Close()
        End Using
    End Function
End Class
'<WebMethod()> _
'Public Sub ExecuteNonquery(ByVal commandText As String, ByVal commandType As CommandType, ByVal params As SqlParameterCollection)
'    Dim cmd As New SqlCommand
'    cmd.CommandType = commandType
'    cmd.CommandText = commandText
'    For Each p As SqlParameter In params
'        cmd.Parameters.Add(p)
'    Next
'    Dim conn As New SqlConnection(strConn)
'    cmd.Connection = conn
'    conn.Open()
'    cmd.ExecuteNonQuery()
'    conn.Close()
'End Sub

'<WebMethod()> _
'Public Function PopulateDataset(ByVal commandText As String, ByVal commandType As CommandType, ByVal params As SqlParameterCollection) As DataSet
'    Dim cmd As New SqlCommand
'    cmd.CommandText = commandText
'    cmd.CommandType = commandType
'    For Each p As SqlParameter In params
'        cmd.Parameters.Add(p)
'    Next
'    cmd.Connection = New SqlConnection(strConn)
'    Dim da As New SqlDataAdapter(cmd)
'    Dim ds As New DataSet
'    da.Fill(ds)
'    Return ds
'End Function