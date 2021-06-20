Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports dboperations  'class required for few database operation
''##########################################################################
''' <summary>
'''   ' class contains the validation and rules for applying leaves and data entry in leave tables.
'''  Written by Vinod Kotiya
''' www.vinodkotiya.com
''' +919411103810
''' </summary>
''' <remarks></remarks>
Public Class LeaveClass     ' class contains the validation and rules for applying leaves
    Public Shared Function getHolidayTypes(ByVal groupid As String) As String()

        '' this function will return array of leave types to populate the text part of drop down
        Dim leaves() As String

        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim i As Integer = 0


            Try
                'connection.Close()
                connection.Open()
                sqlComm = New SqlCommand("select Holi_Type from holiday_type_master ORDER BY Holi_Type ASC", connection)  ' fname + ' ' + lname AS name
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                ReDim leaves(dt.Rows.Count)
                While i < dt.Rows.Count
                    leaves(i) = dt.Rows(i).Item("Holi_Type").ToString
                    'temp = temp + dt.Rows(i).Item("cell").ToString

                    i = i + 1
                End While
                sqlComm.Dispose()
                connection.Close()
                Return leaves

            Catch e As Exception

                connection.Close()
                ' cellnos(0) = "Databse fail: " + e.Message
                Return {"ERROR Databse fail: " + e.Message}
            End Try

        End Using
    End Function
    Public Shared Function getHolidayCodes(ByVal groupid As String) As String()
        '' this function will return array of leave codes to populate value part of the drop down
        Dim leaves() As String

        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim i As Integer = 0


            Try
                'connection.Close()
                connection.Open()
                sqlComm = New SqlCommand("select Holi_code from holiday_type_master ORDER BY Holi_Type ASC", connection)  ' fname + ' ' + lname AS name
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                ReDim leaves(dt.Rows.Count)
                While i < dt.Rows.Count
                    leaves(i) = dt.Rows(i).Item("Holi_code").ToString
                    'temp = temp + dt.Rows(i).Item("cell").ToString

                    i = i + 1
                End While
                sqlComm.Dispose()
                connection.Close()
                Return leaves

            Catch e As Exception

                connection.Close()
                ' cellnos(0) = "Databse fail: " + e.Message
                Return {"ERROR Databse fail: " + e.Message}
            End Try

        End Using
    End Function
    Public Shared Function checkLeaveRuleBook(ByVal begdate As Date, ByVal enddate As Date, ByVal leavedays As Integer, ByVal eid As String, ByVal perarea As String, ByVal holi_code As String) As String
        ' this function will check the validity of leave appied as per rules.. have few supporting functions too
        If leavedays < 1 Then
            Return " Error: End Date is less than begin date."
        End If


        ' check leave is already approved/inprocess in leavetransaction
        If IsLeaveTransactionsExist(begdate, enddate, eid) = "ok" Then
            Return " Error: Leaves for given date is already in process/approved. Apply leave for different date or check leave log."
        End If

        '############################################
        '' check RH <=6 , CL <=12 , EL <=30 SAL <=10
        Dim quota As String


        If holi_code = "CLHD" Then   '' let the CLHD to be adjusted from CL quota
            quota = getLeaveQuota(eid, "CL")
        ElseIf holi_code = "HPL_C" Then    'let the Commuted-HPL (HPL_C) be adjusted from HPL
            quota = getLeaveQuota(eid, "HPL")
        ElseIf holi_code = "HPL_C_P" Then    'let the Commuted-HPL (HPL_C_P) be adjusted from HPL_P
            quota = getLeaveQuota(eid, "HPL_P")
        Else                         ' other leaves as it is
            quota = getLeaveQuota(eid, holi_code)
        End If





        ' Start of RH --->>>>>>>>>>>>>
        If holi_code = "RH" And leavedays <= 6 Then
            '' check his leave quota
            If leavedays <= Int(quota) Then
                ' Now check from calander master about validity of leavedates
                If checkCalenderMaster(begdate, holi_code, perarea) Then
                    'for date range also check the enddate
                    If leavedays > 1 Then
                        If checkCalenderMaster(enddate, holi_code, perarea) Then
                            Return "ok"
                        Else
                            Return " Error: You can't apply for " & holi_code & " on Date " & enddate.ToString("dd.MM.yyyy")
                        End If

                        'for single date
                    ElseIf leavedays = 1 Then
                        Return "ok"
                    End If
                Else
                    Return " Error: You can't apply for " & holi_code & " on Date " & begdate.ToString("dd.MM.yyyy") '+ " " + "select * from calander_master WHERE (Per_area = '" + perarea + "') AND (Holi_code = '" + holi_code + "') AND (CONVERT(varchar, Holi_Date, 103) = '" + begdate.ToString("dd/MM/yyyy") + "') "
                End If

            Else
                Return " Error: You can't apply for " & holi_code & " of more than " & Int(quota) & " days quota."
            End If

        ElseIf holi_code = "RH" And leavedays > 6 Then
            Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days."
        End If
        '<<<<<<--------------------- End of RH

        ' Start of GH --->>>>>>>>>>>>>
        If holi_code = "GH" And leavedays <= 6 Then
            '' check his leave quota
            'If leavedays <= Int(quota) Then   'GH dosent have quota
            ' Now check from calander master about validity of leavedates
            If checkCalenderMaster(begdate, holi_code, perarea) Then
                'for date range also check the enddate
                If leavedays > 1 Then
                    If checkCalenderMaster(enddate, holi_code, perarea) Then
                        Return "ok"
                    Else
                        Return " Error: You can't apply for " & holi_code & " on Date " & enddate.ToString("dd.MM.yyyy")
                    End If

                    'for single date
                ElseIf leavedays = 1 Then
                    Return "ok"
                End If
            Else
                Return " Error: You can't apply for " & holi_code & " on Date " & begdate.ToString("dd.MM.yyyy") '+ " " + "select * from calander_master WHERE (Per_area = '" + perarea + "') AND (Holi_code = '" + holi_code + "') AND (CONVERT(varchar, Holi_Date, 103) = '" + begdate.ToString("dd/MM/yyyy") + "') "
            End If

            'Else
            '    Return " Error: You can't apply for " & holi_code & " of more than " & Int(quota) & " days quota."
            ' End If

            'ElseIf holi_code = "GH" And leavedays > 6 Then
            '    Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days."
        End If
        '<<<<<<--------------------- End of GH


        ' Start of CL --->>>>>>>>>>>>>
        If holi_code = "CL" And leavedays <= 12 Then  'first IF is only for if there is alimitation of leave applied at once eg.. u can't go for 13 days CL
            '' check his leave quota

            If Int(quota) >= leavedays Then
                Return "ok"
            Else
                Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days. It exceeds your balance leave quota of " & quota
            End If
        ElseIf holi_code = "CL" And leavedays > 12 Then
            Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days."
        End If
        '<<<<<<--------------------- End of CL

        ' Start of CLHD --->>>>>>>>>>>>>
        If holi_code = "CLHD" And leavedays <= 1 Then  'take half CL once a day. check actual quota ie double of CL from Database...
            '' check his leave quota

            If Int(quota * 2) >= leavedays Then
                Return "ok"
            Else
                Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days. It exceeds your balance leave quota of " & (Int(quota) * 2).ToString
            End If
        ElseIf holi_code = "CLHD" And leavedays > 1 Then
            Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days at once."
        End If
        '<<<<<<--------------------- End of CLHD

        ' Start of EL_E --->>>>>>>>>>>>>
        If holi_code = "EL_E" And leavedays <= Int(quota) Then
            '' check his leave quota

            If Int(quota) >= leavedays Then
                Return "ok"
            Else
                Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days. It exceeds your balance leave quota of " & quota
            End If
        ElseIf holi_code = "EL_E" And leavedays > Int(quota) Then
            Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days."
        End If
        '<<<<<<--------------------- End of EL_E

        ' Start of EL_NE --->>>>>>>>>>>>>
        If holi_code = "EL_NE" And leavedays <= Int(quota) Then
            '' check his leave quota

            If Int(quota) >= leavedays Then
                Return "ok"
            Else
                Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days. It exceeds your balance leave quota of " & quota
            End If
        ElseIf holi_code = "EL_NE" And leavedays > Int(quota) Then
            Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days."
        End If
        '<<<<<<--------------------- End of EL_NE

        ' Start of HPL --->>>>>>>>>>>>>
        If holi_code = "HPL" And leavedays <= Int(quota) Then  'first IF is only for if there is alimitation of leave applied at once eg.. u can't go for 13 days CL
            '' check his leave quota

            If Int(quota) >= leavedays Then
                Return "ok"
            Else
                Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days. It exceeds your balance leave quota of " & quota
            End If
        ElseIf holi_code = "HPL" And leavedays > Int(quota) Then
            Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days."
        End If
        '<<<<<<--------------------- End of HPL

        

        ' Start of HPL_C --->>>>>>>>>>>>> Commuted-HPL
        If holi_code = "HPL_C" And (leavedays * 2) <= Int(quota) Then
            '' check his leave quota

            If Int(quota) >= (leavedays * 2) Then
                Return "ok"
            Else
                Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days. It exceeds your balance leave quota of HPL " & quota
            End If
        ElseIf holi_code = "HPL_C" And leavedays > Int(quota) Then
            Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days."
        End If
        '<<<<<<--------------------- End of HPL_C

        ' Start of HPL_C_P --->>>>>>>>>>>>> Commuted-HPL prev
        If holi_code = "HPL_C_P" And (leavedays * 2) <= Int(quota) Then
            '' check his leave quota

            If Int(quota) >= (leavedays * 2) Then
                Return "ok"
            Else
                Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days. It exceeds your balance leave quota of HPL (Prev Employer) " & quota
            End If
        ElseIf holi_code = "HPL_C_P" And leavedays > Int(quota) Then
            Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days."
        End If
        '<<<<<<--------------------- End of HPL_C_P

        ' Start of HPL_P --->>>>>>>>>>>>>
        If holi_code = "HPL_P" And leavedays <= Int(quota) Then
            '' check his leave quota

            If Int(quota) >= leavedays Then
                Return "ok"
            Else
                Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days. It exceeds your balance leave quota of " & quota
            End If
        ElseIf holi_code = "HPL_P" And leavedays > Int(quota) Then
            Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days."
        End If
        '<<<<<<--------------------- End of HPL_P

        ' Start of SAL --->>>>>>>>>>>>>
        If holi_code = "SAL" And leavedays <= 10 Then
            '' check his leave quota

            If Int(quota) >= leavedays Then
                Return "ok"
            Else
                Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days. It exceeds your balance leave quota of " & quota
            End If
        ElseIf holi_code = "SAL" And leavedays > 10 Then
            Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days."
        End If
        '<<<<<<--------------------- End of SAL


        ' Start of OD --->>>>>>>>>>>>>  No logic define so let user carry on
        If holi_code = "OD" And leavedays <= 1 Then
            Return "ok"
        ElseIf holi_code = "OD" And leavedays > 1 Then
            Return " Error: You can't apply for " & holi_code & " of " & leavedays.ToString & " days at once."
        End If
        '<<<<<<--------------------- End of OD 

        ' Start of  OT OTRWT OTRWNT--->>>>>>>>>>>>>  No logic define so let user carry on
        If holi_code = "OT" Or holi_code = "OTRWNT" Or holi_code = "OTRWT" Then
            Return "ok"
        End If
        '<<<<<<--------------------- End of OT OTRWT OTRWNT

        Return "Error: End of Function Rulebook "
    End Function

    Public Shared Function getLeaveQuota(ByVal eid As String, ByVal holi_code As String) As String
        ''this function will check the leave quota for applied leave.. part of rulebook
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim quota As String

            Try
                'connection.Close()
                connection.Open()
                sqlComm = New SqlCommand("select sum(Quota) as Quota from leave_quota_master WHERE Emp_no = '" + eid + "' AND Sub_type = '" + holi_code + "' ", connection)  ' fname + ' ' + lname AS name
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                sqlComm.Dispose()
                If dt.Rows.Count > 0 Then
                    quota = dt.Rows(0).Item("Quota")
                    connection.Close()
                    getLeaveQuota = quota

                Else
                    connection.Close()
                    getLeaveQuota = "-404"  ' database not access
                End If
                sqlReader.Close()
            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                getLeaveQuota = "-405" 'database not open
            End Try
            connection.Close()
        End Using
    End Function
    Public Shared Function checkCalenderMaster(ByVal thedate As Date, ByVal holi_code As String, ByVal perarea As String) As Boolean
        ''this function will check from calender master for applied leave.. part of rulebook
        Return checkDatabase("select * from calander_master WHERE (Per_area = '" + perarea + "') AND (Holi_code = '" + holi_code + "') AND (CONVERT(varchar, Holi_Date, 101) = '" + thedate.ToString("MM/dd/yyyy") + "') ")
        'Return checkDatabase("select * from calander_master WHERE (Per_area = '" + perarea + "') AND (Holi_code = '" + holi_code + "') AND  Holi_Date = '" + thedate + "') ")

       
    End Function

    Public Shared Function IsLeaveTransactionsExist(ByVal begdate As Date, ByVal enddate As Date, ByVal eid As String) As String
        ''this function will check leave is already approved/inprocess in leavetransaction.. part of rulebook
        If checkDatabase("select * from leave_transaction WHERE (Emp_no = '" + eid + "') AND ((CONVERT(varchar, Leave_st_date, 101) = '" + begdate.ToString("MM/dd/yyyy") + "') OR (CONVERT(varchar, Leave_end_dt, 101) = '" + enddate.ToString("MM/dd/yyyy") + "')) ") Then
            Return "ok"
        Else

            Return "select * from leave_transaction WHERE (Emp_no = '" + eid + "') AND ((CONVERT(varchar, Leave_st_date, 101) = '" + begdate.ToString("MM/dd/yyyy") + "') OR (CONVERT(varchar, Leave_end_dt, 101) = '" + enddate.ToString("MM/dd/yyyy") + "')) "

        End If




    End Function
    Public Shared Function InsertLeaveTransaction(ByVal begdate As Date, ByVal enddate As Date, ByVal eid As String, ByVal Tx_no As String, ByVal holi_code As String, ByVal remarks As String, ByVal work_flow_id As String, ByVal status As String, ByVal leavedays As String, ByVal currdate As Date, ByVal ipaddress As String) As String
        '' this function will insert the transaction data for new leave
        Dim mysql As String = "Insert Into leave_transaction ( Emp_no, Tx_no, Leave_st_date , Leave_end_dt, Leave_type, Remarks, Work_flow_ID, Status, leavedays, Cratedon, userID, ipAddress)" & _
      " VALUES  (" & _
               "'" & Replace(eid, "'", "''") & "', " & _
               "'" & Replace(Tx_no, "'", "''") & "', " & _
               "'" & Replace(begdate, "'", "''") & "', " & _
               "'" & Replace(enddate, "'", "''") & "', " & _
               "'" & Replace(holi_code, "'", "''") & "', " & _
               "'" & Replace(remarks, "'", "''") & "', " & _
               "'" & Replace(work_flow_id, "'", "''") & "', " & _
               "'" & Replace(status, "'", "''") & "', " & _
               "'" & Replace(leavedays, "'", "''") & "', " & _
               "'" & Replace(currdate, "'", "''") & "', " & _
               "'" & Replace(eid, "'", "''") & "', " & _
                                "'" & Replace(ipaddress, "'", "''") & "') "
        Dim tmp = insertRecord(mysql)
        If tmp = "ok" Then
            Return "ok"
        Else
            Return tmp & mysql
        End If
    End Function

    Public Shared Function InsertINCalenderMaster(ByVal holidate As Date, ByVal holi_code As String, ByVal calyear As String, ByVal perarea As String) As String
        '' this function will insert the data for calender master
        Dim mysql As String = "Insert Into calander_master ( Cal_year, Per_area, Holi_code , Holi_Date)" & _
      " VALUES  (" & _
               "'" & Replace(calyear, "'", "''") & "', " & _
               "'" & Replace(perarea, "'", "''") & "', " & _
               "'" & Replace(holi_code, "'", "''") & "', " & _
                         "'" & Replace(holidate.ToString("MM/dd/yyyy"), "'", "''") & "') "
        Dim tmp = insertRecord(mysql)
        If tmp = "ok" Then
            Return "ok"
        Else
            Return tmp & mysql
        End If
    End Function
    Public Shared Function InsertINLeaveQuotaMaster(ByVal eid As String, ByVal holi_code As String, ByVal begdate As Date, ByVal enddate As Date, ByVal seq As String, ByVal quota As String, ByVal claimed As String, ByVal createdon As Date, ByVal userid As String, ByVal ipaddress As String) As String
        '' this function will insert the data for leave quota master
        Dim mysql As String = "Insert Into leave_quota_master ( Emp_no, Sub_type, Begda , Endda, Seq, Quota, Claimed, Cratedon, userID, ipAddress)" & _
      " VALUES  (" & _
               "'" & Replace(eid, "'", "''") & "', " & _
               "'" & Replace(holi_code, "'", "''") & "', " & _
               "'" & Replace(begdate.ToString("MM/dd/yyyy"), "'", "''") & "', " & _
               "'" & Replace(enddate.ToString("MM/dd/yyyy"), "'", "''") & "', " & _
               "'" & Replace(seq, "'", "''") & "', " & _
               "'" & Replace(quota, "'", "''") & "', " & _
               "'" & Replace(claimed, "'", "''") & "', " & _
               "'" & Replace(createdon.ToString("MM/dd/yyyy"), "'", "''") & "', " & _
               "'" & Replace(userid, "'", "''") & "', " & _
                                     "'" & Replace(ipaddress, "'", "''") & "') "
        Dim tmp = insertRecord(mysql)
        If tmp = "ok" Then
            Return "ok"
        Else
            Return tmp & mysql
        End If
    End Function
    Public Shared Function GetLeaveTransactionDetails(ByVal tx_no As String) As String
        '' this function will get the leave transaction details as per Tx _ no
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim detail As String

            Try
                'connection.Close()
                connection.Open()
                sqlComm = New SqlCommand("SELECT Emp_no, convert(varchar, Leave_st_date, 104) as Leave_st_date, convert(varchar, Leave_end_dt, 104) as Leave_end_dt, Tx_no, leavedays, Status, Remarks, Leave_type from leave_transaction WHERE Tx_no ='" & tx_no & "'", connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                sqlComm.Dispose()
                If dt.Rows.Count = 1 Then  'format {009383} [CL] (2) ^New* is required for searching
                    'detail = "<br /><b>Employee No: </b>{" & dt.Rows(0).Item("Emp_no") & _
                    '     "} <br /> <b> Leave Type: </b>[" & dt.Rows(0).Item("Leave_type") & _
                    '     "]<br /> <b> Leave Beg Date: </b>" & dt.Rows(0).Item("Leave_st_date") & _
                    '     "<br /> <b> Leave End Date:</b>" & dt.Rows(0).Item("Leave_end_dt") & _
                    '     "<br /> <b> Remarks :</b>" & dt.Rows(0).Item("Remarks") & _
                    '     "<br /> <b> Leave Days : </b>(" & dt.Rows(0).Item("leavedays") & _
                    '     ")<br /> <b> Status : </b>^" & dt.Rows(0).Item("Status") & "*<br /><br /> "
                    'return 009383*CLHD*7/23/2011 12:00:00 AM*7/23/2011 12:00:00 AM*May approve*1*New
                    detail = "" & dt.Rows(0).Item("Emp_no") & _
                        "*" & dt.Rows(0).Item("Leave_type") & _
                        "*" & dt.Rows(0).Item("Leave_st_date") & _
                        "*" & dt.Rows(0).Item("Leave_end_dt") & _
                        "*" & dt.Rows(0).Item("Remarks") & _
                        "*" & dt.Rows(0).Item("leavedays") & _
                        "*" & dt.Rows(0).Item("Status")
                    connection.Close()
                    GetLeaveTransactionDetails = detail

                Else
                    connection.Close()
                    GetLeaveTransactionDetails = "Duplicate or no values found for " + tx_no
                End If
                sqlReader.Close()
            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                GetLeaveTransactionDetails = "Database not open " + tx_no + e.Message
            End Try
            connection.Close()
        End Using
    End Function
    Public Shared Function SetLeaveTransactionDetails(ByVal tx_no As String, ByVal status As String, ByVal ref_tx_no As String) As String
        '' this function will update the leave transaction details as per Tx _ no
        Dim mysql As String = "UPDATE leave_transaction set Status= '" & status & "', Ref_tx_id='" & ref_tx_no & "' where Tx_no='" & tx_no & "'"
        Dim tmp = insertRecord(mysql)
        If tmp = "ok" Then
            Return "ok"
        Else
            Return tmp & mysql
        End If
    End Function
    Public Shared Function SetLeaveQuotaMasterOnApproval(ByVal eid As String, ByVal leavecode As String, ByVal leavedays As String, ByVal cancel As Boolean) As String
        '' this function will update the leave quota master on event of approval
        'will debit leave if cancel is false, credit leacve if canlcel is true
        '' This function needs to be refined further for entry of applied leave in different rows after split.
        If leavecode = "CLHD" Then  'for halfday CL only dedct/add 0.5 from CL quota
            leavecode = "CL"
            leavedays = (Int(leavedays) / 2).ToString
        ElseIf leavecode = "HPL_C" Then  'for commulative HPL deduct twice of leavedays from HPL
            leavecode = "HPL"
            leavedays = (Int(leavedays) * 2).ToString
        ElseIf leavecode = "HPL_P_C" Then
            leavecode = "HPL_P"
            leavedays = (Int(leavedays) * 2).ToString
        End If
        Dim mysql As String
        If cancel Then  'on approval of leave cancelation request add to quota
            mysql = "UPDATE leave_quota_master SET Quota = Quota + " & leavedays & ", Claimed = Claimed - " & leavedays & " WHERE        (Sub_type = '" & leavecode & "') AND Emp_no = '" & eid & "'"
        Else 'on approval of leave  request subtract from  quota
            mysql = "UPDATE leave_quota_master SET Quota = Quota - " & leavedays & ", Claimed = Claimed + " & leavedays & " WHERE        (Sub_type = '" & leavecode & "') AND Emp_no = '" & eid & "'"
        End If


        Dim tmp = insertRecord(mysql)
        If tmp = "ok" Then
            Return "ok"
        Else
            Return tmp & mysql
        End If
    End Function
  
    Public Shared Function InsertINAttendanceMaster(ByVal eid As String, ByVal status As String, ByVal begdate As Date, ByVal enddate As Date) As String
        '' this function will insert the data for attendance master
        Dim dtLoop As Date = begdate
        Dim mysql As String = "Insert Into leave_quota_master ( Emp_no, Intime, Outtime , Duration, Status)" & _
         " VALUES "
        ' I wanna do INSERT INTO tbl_name (a,b,c) VALUES(1,2,3),(4,5,6),(7,8,9);

        While dtLoop <= enddate
            mysql = mysql & "  (" & _
                   "'" & Replace(eid, "'", "''") & "', " & _
                   "'" & Replace(begdate, "'", "''") & "', " & _
                   "'" & Replace(enddate, "'", "''") & "', " & _
                   "'" & Replace("24:00:00", "'", "''") & "', " & _
                         "'" & Replace(status, "'", "''") & "') "
            If dtLoop < enddate Then
                mysql = mysql & ","   'don't put , for last set of values
            End If
            dtLoop = dtLoop.AddDays(1)
        End While

        Dim tmp = insertRecord(mysql)
        If tmp = "ok" Then
            Return "ok"
        Else
            Return tmp & mysql
        End If
    End Function
    Public Shared Function GetAttendanceMasterDetails(ByVal eid As String, ByVal month As String, ByVal year As String) As String
        '' this function will get the leave transaction details as per Tx _ no
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim detail As String = String.Empty

            Try
                'connection.Close()
                connection.Open()
                'sqlComm = New SqlCommand("SELECT Emp_no, convert(varchar, Intime, 104) as Intime, convert(varchar, Outtime, 104) as Outtime, Duration, Status from attendance_master WHERE Emp_no ='" & eid & "' And Month(Intime) = " & month, connection)
                sqlComm = New SqlCommand("SELECT Emp_no,  Intime,  Outtime, Duration, Status from attendance_master WHERE Emp_no ='" & eid & "' And Month(Intime) = " & month, connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                sqlComm.Dispose()
                Dim i = dt.Rows.Count
                Dim j As Integer = 0
                If i > 1 Then  'format  009383*13.05.2011*13.05.2011*24:00*CL*009383*15.05.2011*15.05.2011*24:00*OD is required for splitting
                    While j < i
                        detail = detail & dt.Rows(j).Item("Emp_no") & _
                             "*" & dt.Rows(j).Item("Intime").ToString & _
                             "*" & dt.Rows(j).Item("Outtime").ToString & _
                             "*" & dt.Rows(j).Item("Duration").ToString & _
                             "*" & dt.Rows(j).Item("Status")
                        j = j + 1
                        If j < i Then
                            detail = detail & "*"
                        End If
                    End While
                    connection.Close()
                    GetAttendanceMasterDetails = detail
                Else
                    connection.Close()
                    GetAttendanceMasterDetails = "notfound"
                End If
                sqlReader.Close()
            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                GetAttendanceMasterDetails = "Database not open " & eid & month & e.Message
            End Try
            connection.Close()
        End Using
    End Function
End Class

'convert(varchar, yourtablecolumnfield, 100) as yourtablecolumnfield - mon dd yyyy hh:mmAM (or PM)
'convert(varchar, yourtablecolumnfield, 101) as yourtablecolumnfield - mm/dd/yyyy - 10/02/2008
'convert(varchar, yourtablecolumnfield, 102) as yourtablecolumnfield - yyyy.mm.dd as yourtablecolumnfield - 2008.10.02
'convert(varchar, yourtablecolumnfield, 103) as yourtablecolumnfield - dd/mm/yyyy
'convert(varchar, yourtablecolumnfield, 104) as yourtablecolumnfield - dd.mm.yyyy
'convert(varchar, yourtablecolumnfield, 105) as yourtablecolumnfield - dd-mm-yyyy
'convert(varchar, yourtablecolumnfield, 106) as yourtablecolumnfield - dd mon yyyy
'convert(varchar, yourtablecolumnfield, 107) as yourtablecolumnfield - mon dd, yyyy
'convert(varchar, yourtablecolumnfield, 108) as yourtablecolumnfield - hh:mm:ss
'convert(varchar, yourtablecolumnfield, 109) as yourtablecolumnfield - mon dd yyyy hh:mm:ss:mmmAM (or PM)
'convert(varchar, yourtablecolumnfield, 110) as yourtablecolumnfield - mm-dd-yyyy
'convert(varchar, yourtablecolumnfield, 111) as yourtablecolumnfield - yyyy/mm/dd
'convert(varchar, yourtablecolumnfield, 112) as yourtablecolumnfield - yyyymmdd
'convert(varchar, yourtablecolumnfield, 113) as yourtablecolumnfield - dd mon yyyy hh:mm:ss:mmm
'convert(varchar, yourtablecolumnfield, 114) as yourtablecolumnfield - hh:mm:ss:mmm(24h)
'convert(varchar, yourtablecolumnfield, 120) as yourtablecolumnfield - yyyy-mm-dd hh:mm:ss(24h)
'convert(varchar, yourtablecolumnfield, 121) as yourtablecolumnfield - yyyy-mm-dd hh:mm:ss.mmm
'convert(varchar, yourtablecolumnfield, 126) as yourtablecolumnfield - yyyy-mm-ddThh:mm:ss.mmm
'//     Culture      , Date: 11/30/2007 00:00:00 ----> this is InvariantCulture or empty name "" in CultureInfo constructor
'     //     Culture da-DK, Date: 30-11-2007 00:00:00
'     //     Culture en-US, Date: 11/30/2007 12:00:00 AM
'     //     Culture fr-CA, Date: 2007-11-30 00:00:00
'     //     Culture en-GB, Date: 30/11/2007 00:00:00
'     //     Culture en-CA, Date: 30/11/2007 12:00:00 AM
'     //     Culture fr-FR, Date: 30/11/2007 00:00:00
'     //     Culture fr-CH, Date: 30.11.2007 00:00:00