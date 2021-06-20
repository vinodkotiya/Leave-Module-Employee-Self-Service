Imports System.Linq
Imports System.ServiceModel.Web
Imports Microsoft.VisualBasic
Imports System.Web.HttpContext
Imports System.Web.Caching
Imports System.Data
Imports System.Data.SqlClient


Public Class GridManager
    ''##########################################################################
    ''' <summary>
    '''   ' class contains the fuctions to show datagrid in webpage.
    '''  Written by Vinod Kotiya
    ''' www.vinodkotiya.com
    ''' +919411103810
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GetCompareStatement(ByVal firstValue As String, ByVal secondValue As String, ByVal operation As String) As String
        Select Case operation
            Case "Contains"
                Return "LIKE '%" + firstValue + "%' "
            Case "Begins with"
                Return "LIKE '" + firstValue + "%' "
            Case "Ends with"
                Return "LIKE '%" + firstValue + "' "
            Case "Equals"
                Return "= '" + firstValue + "' "
            Case "Date Equals"
                Return "= CONVERT(DATETIME, '" + firstValue + "', 101) "
            Case "After"
                Return "> CONVERT(DATETIME, '" + firstValue + "', 101) "
            Case "Before"
                Return "< CONVERT(DATETIME, '" + firstValue + "', 101) "
            Case "Between"
                Return "BETWEEN CONVERT(DATETIME, '" + firstValue + "', 101) AND CONVERT(DATETIME, '" + secondValue + "', 101) "
            Case Else
                Return ""
        End Select
    End Function

    Public Shared Sub rebindGridView(ByVal query As String, ByVal gridViewControl As GridView)
        'Binds Paging/Sorting GridView with data from the specified query
        ' Bind GridView to current query & always store ur query into session("currentquery") before calling
        ' reason is whenever page indexed changed or sort.. then it will show data from currentquery

        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim dataTableRowCount As Integer
            Try
                'connection.Close()
                connection.Open()
                sqlComm = New SqlCommand(query, connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                sqlComm.Dispose()
                dataTableRowCount = dt.Rows.Count

                If dataTableRowCount > 0 Then
                    '   Dim vincache As Cache
                    '  vincache.Insert("cache" + gridName, dt, vbNull, Now.AddMinutes(10), TimeSpan.Zero)
                    gridViewControl.DataSource = dt
                    gridViewControl.DataBind()
                End If

                sqlReader.Close()
            Catch e As Exception
                'lblDebug.text = e.Message

                connection.Close()
            End Try


            connection.Close()
        End Using
    End Sub

    Public Shared Sub rebindListview(ByVal query As String, ByVal ListviewControl As ListView)
        'Binds Paging/Sorting GridView with data from the specified query
        ' Bind GridView to current query & always store ur query into session("currentquery") before calling
        ' reason is whenever page indexed changed or sort.. then it will show data from currentquery

        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim dataTableRowCount As Integer
            Try
                'connection.Close()
                connection.Open()
                sqlComm = New SqlCommand(query, connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                sqlComm.Dispose()
                dataTableRowCount = dt.Rows.Count

                If dataTableRowCount > 0 Then
                    ListviewControl.DataSource = dt
                    ListviewControl.DataBind()
                End If
                sqlReader.Close()
            Catch e As Exception
                'lblDebug.text = e.Message

                connection.Close()
            End Try


            connection.Close()
        End Using
    End Sub

    Public Shared Function SortDataTable(ByVal dataTable As DataTable, ByVal isPageIndexChanging As Boolean) As DataView
        If Not dataTable Is Nothing Then
            Dim dataView As New DataView(dataTable)
            If GridViewSortExpression <> String.Empty Then
                If isPageIndexChanging Then
                    dataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GridViewSortDirection)
                Else
                    dataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GetSortDirection())
                End If
            End If
            Return dataView
        Else
            Return New DataView()
        End If
    End Function

    Public Shared Property GridViewSortExpression() As String
        Get
            Return IIf(Current.Session("SortExpression") = Nothing, String.Empty, Current.Session("SortExpression"))
        End Get

        Set(ByVal value As String)
            Current.Session("SortExpression") = value
        End Set
    End Property

    Private Shared Function GetSortDirection() As String
        Select Case GridViewSortDirection
            Case "ASC"
                GridViewSortDirection = "DESC"
            Case "DESC"
                GridViewSortDirection = "ASC"
        End Select
        Return GridViewSortDirection
    End Function

    Public Shared Property GridViewSortDirection() As String
        Get
            Return IIf(Current.Session("SortDirection") = Nothing, "ASC", Current.Session("SortDirection"))
        End Get
        Set(ByVal value As String)
            Current.Session("SortDirection") = value
        End Set
    End Property


    

End Class
