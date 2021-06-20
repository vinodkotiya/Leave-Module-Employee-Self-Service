Imports LeaveClass
Imports GridManager

Partial Class leavemanage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            'this code be executed only first time any event happen on web page
            Session("eid") = "009383"
            Session("perarea") = "1002"
            Session("work_flow_id") = "009383"
            Session("myIP") = Request.UserHostAddress

            ' lets populate the dropdown with holiday type as text and code as value.
            Dim leaves() As String = getHolidayTypes("1")
            Dim holicodes() As String = getHolidayCodes("1")
            Dim i As Integer = 0

            While i < (leaves.Length - 1)
                ddlLeaves.Items.Add(New ListItem(leaves(i).ToString, holicodes(i).ToString))  ' in leave request panel
                ddl_LQ_leavetype.Items.Add(New ListItem(leaves(i).ToString, holicodes(i).ToString)) ' in leave quoota master
                i = i + 1
            End While

            ' code for tabcontainer
            TabContainer2.ActiveTabIndex = 0  'let default tab be tabpanel9
            '''' Initially all submit buttons in tab panel have thier validation group set and causevalidation to false to work independentaly in each panel 
            If Request.Params("mode") = "leaverequest" Then
                TabContainer2.ActiveTabIndex = 1
            ElseIf Request.Params("mode") = "calendermaster" Then
                TabContainer2.ActiveTabIndex = 2
            ElseIf Request.Params("mode") = "leavequotamaster" Then
                TabContainer2.ActiveTabIndex = 3
            ElseIf Request.Params("mode") = "leavebalanceoverview" Then
                TabContainer2.ActiveTabIndex = 4
            ElseIf Request.Params("mode") = "leaveapproval" Then
                TabContainer2.ActiveTabIndex = 5
            ElseIf Request.Params("mode") = "leavecancelation" Then
                TabContainer2.ActiveTabIndex = 6
            ElseIf Request.Params("mode") = "leaveencashment" Or Request.Params("mode") = "salencashment" Then
                TabContainer2.ActiveTabIndex = 7
            ElseIf Request.Params("mode") = "viewattendance" Or Request.Params("mode") = "viewsubattendance" Then
                TabContainer2.ActiveTabIndex = 8
            ElseIf Request.Params("mode") = "profile" Then
                TabContainer2.ActiveTabIndex = 9
            End If


            '      <li><a href="leavemanage.aspx?mode=leaverequest">Leave Request</a></li>
            '<li><a href="leavemanage.aspx?mode=leaveapproval">Leave Approval</a></li>
            '<li><a href="leavemanage.aspx?mode=leavecancelation">Leave Cancelation</a></li>
            '                  <li><a href="leavemanage.aspx?mode=leavecancelation">Leave Tracker</a></li>
            '<li><a href="leavemanage.aspx?mode=leavebalanceoverview">Leave Balance Overview</a></li>
            '<li><a href="leavemanage.aspx?mode=viewattendance">View Attendance</a></li>
            '<li><a href="leavemanage.aspx?mode=leaveencashment">Leave Encashment</a></li>
            '<li><a href="leavemanage.aspx?mode=salencashment">SAL Encashment</a></li>
            '<li><a href="leavemanage.aspx?mode=viewsubattendance">View Subordinate Attendance</a></li>
            '                  <li><a href="leavemanage.aspx?mode=calendermaster">Calender Master</a></li>
            '                  <li><a href="leavemanage.aspx?mode=leavequotamaster">Leave Quota Master</a></li>
            '' code for grid
            ' Clear user paging/sort
            '>>>>>>>>> Leave rquest session
            Session("begdate") = Nothing
            Session("enddate") = Nothing
            Session("leavedays") = Nothing
            Session("holi_code") = Nothing
            Session("remarks") = Nothing
            up_Leavereq1.Visible = True
            up_Leavereq2.Visible = False
            Image1.ImageUrl = "images/green1.png"
            Image2.ImageUrl = "images/red2.png"
            Image3.ImageUrl = "images/red3.png"

            '<<<<<<<<<<< end of lave request


            Session("page_gvBalance") = 0
            Session("page_gvApprove") = 0
            Session("SortExpression") = Nothing
            Session("page_gvLeaveTrackerCancel") = 0


            GridViewSortDirection = "ASC"
            ' Set current query
            Session("CurrentQuery_gvBalance") = "SELECT Sub_type, convert(varchar, Begda, 104) as Begda, convert(varchar, Endda, 104) as Endda, Seq, Quota, Claimed from leave_quota_master where Emp_no = '" & Session("eid") & "' ORDER BY Sub_type ASC"
            Session("CurrentQuery_gvApprove") = "SELECT Emp_no, convert(varchar, Leave_st_date, 104) as Leave_st_date, convert(varchar, Leave_end_dt, 104) as Leave_end_dt, Tx_no, leavedays, Status, Remarks, Leave_type from  leave_transaction where Work_flow_ID = '" & Session("eid") & "' AND (Status='New' OR Status='ReqCancel') ORDER BY Cratedon ASC"
            Session("CurrentQuery_gvLeaveTrackerCancel") = "SELECT Emp_no, convert(varchar, Leave_st_date, 104) as Leave_st_date, convert(varchar, Leave_end_dt, 104) as Leave_end_dt, Tx_no, leavedays, Status, Remarks, Leave_type from  leave_transaction where Emp_no = '" & Session("eid") & "'  ORDER BY Cratedon ASC"

        End If

        'below code  will be executed every time any event happen on web page
        If TabContainer2.ActiveTabIndex = 1 Then
            lbl_RH_GH.text = "RH This Month 8 Jun, 16 Jun, 23 Jun <br /> GH This Month 17 Jun, 29 Jun "
        End If
        If TabContainer2.ActiveTabIndex = 3 Then
            txt_LQ_begdate.Text = "01.04." + Now.Year.ToString
            txt_LQ_enddate.Text = "31.03.9999"
            lbl_LQ_Detail.Text = "Created On:  " & Now.ToString("dd.MM.yyyy") & _
                " <br /><br /> userID : " & Session("eid") & _
                " <br /><br /> ipaddress : " & Session("myIP")
        End If
        If TabContainer2.ActiveTabIndex = 7 Then
            btn_Leave_Encash.Enabled = True
            lbl_Leave_Encash_EL.Text = getLeaveQuota(Session("eid"), "EL_E")
            lbl_Leave_Encash_SAL.Text = getLeaveQuota(Session("eid"), "SAL")

        End If
        'If TabContainer2.ActiveTabIndex = 8 Then
        '    txt_View_Attendance_Month.Text = "0" & (Now.Month - 1).ToString
        '    txt_View_Attendance_year.Text = Now.Year.ToString
        'End If

        If Request.Params("mode") = "salencashment" Then
            ddl_Leave_Encash.SelectedIndex = 1
          
        End If

        txt_ViewAttendance_Subord_ID.Text = Session("eid")
        txt_ViewAttendance_Subord_ID.Enabled = False
        If Request.Params("mode") = "viewsubattendance" Then
            txt_ViewAttendance_Subord_ID.Text = ""
            txt_ViewAttendance_Subord_ID.Enabled = True

        End If

        '' let the gridview be populated only when tab is clicked to enhance the page load time.
        If TabContainer2.ActiveTabIndex = 4 Then
            rebindGridView(Session("CurrentQuery_gvBalance"), gvBalance)
        End If
        If TabContainer2.ActiveTabIndex = 5 Then
            rebindGridView(Session("CurrentQuery_gvApprove"), gvApprove)
        End If
        If TabContainer2.ActiveTabIndex = 6 Then
            rebindGridView(Session("CurrentQuery_gvLeaveTrackerCancel"), gvLeaveTrackerCancel)
        End If


    End Sub
    ' ########################## Start of Leave request Code for web controls ############## --->>>>>>>>>>>>>>>>>>>>>>>
    Protected Sub btnNext1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext1.Click
        ' major ovehaul reqired in datetime operation
        ' let user see date in dd/MM/yyyy format but use default date in background

        Dim frProvider As IFormatProvider = New System.Globalization.CultureInfo("fr-CH")  ' fr style date dd.MM.yyyy
        Dim begdate As Date
        If txtDate.Text.Trim <> "" Then
            Try
                begdate = DateTime.Parse(txtDate.Text & " " & txtTime.Text, frProvider, System.Globalization.DateTimeStyles.NoCurrentDateDefault) '' it will convert dd.mm.yyyy to mm/dd/yyyy
            Catch
                lblError1.Text = "Error: Enter a valid date in dd/MM/yyyy format. "
                Exit Sub
            End Try
        Else
            lblError1.Text = "Error: Date Field Empty. "
            Exit Sub
        End If


        'If IsDate(txtDate.Text.Trim) Then
        '    begdate = Date.Parse(txtDate.Text).Date
        '    'begdate = Date.Parse(begdate.ToString("dd/MM/yyyy") & " " & txtTime.Text)
        '    'begdate = DateTime.Parse(txtDate.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat)
        '    begdate = DateTime.Parse(begdate.ToString("dd/MM/yyyy") & " " & txtTime.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat)
        '    ' this will convert dd/MM/yyyy to MM/dd/yyyy for programing use
        'Else
        '    lblError1.Text = "Error: Enter a valid date in dd/MM/yyyy format. "
        '    Exit Sub
        'End If


        Dim isLeaveValid As Boolean = False
        Dim leavedays As String
        Dim enddate As Date

        If txtDate2.Text.Trim <> "" Then
            Try
                enddate = DateTime.Parse(txtDate2.Text, frProvider, System.Globalization.DateTimeStyles.NoCurrentDateDefault) '' it will convert dd.mm.yyyy to mm/dd/yyyy
            Catch
                lblError1.Text = "Error: Enter a valid date in dd/MM/yyyy format. "
                Exit Sub
            End Try
        Else
            enddate = begdate
        End If
        leavedays = (DateDiff(DateInterval.Day, begdate, enddate) + 1).ToString
        Session("begdate") = begdate
        Session("enddate") = enddate
        Session("leavedays") = leavedays.ToString
        Session("holi_code") = ddlLeaves.SelectedValue
        Session("remarks") = txtRemark.Text

        '' lets check leave applied is valid or not.. accordingly show the errors...
        Dim errormsg = checkLeaveRuleBook(begdate, enddate, Int(leavedays), Session("eid"), Session("perarea"), Session("holi_code"))
        If errormsg = "ok" Then
            isLeaveValid = True
        End If
        lblError1.Text = errormsg

        ''##################################################################
        '''' This is the next level if every logic checked above is fine
        If isLeaveValid Then
            up_Leavereq1.Visible = False
            up_Leavereq2.Visible = True
            Image2.ImageUrl = "images/green2.png"
            Image1.ImageUrl = "images/red1.png"

            lblReview.Text = "  <b> Type of Leave     :</b>  " + ddlLeaves.SelectedItem.Text & _
                "<br /> <br />  <b> Date     : </b>    From " + begdate.ToString("dd.MM.yyyy") + "   To  " + enddate.ToString("dd.MM.yyyy") & _
             " <br /> <br />  <b> Duration     :  </b>  " + leavedays + " Days" & _
             " <br /> <br />  <b> Approving Authority : </b>    " + Session("work_flow_id") & _
               " <br /> <br /> <b>  Note for Approver :  </b>  " & txtRemark.Text
        End If
    End Sub

    Protected Sub btnPrev2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev2.Click
        up_Leavereq1.Visible = True
        up_Leavereq2.Visible = False
        Image2.ImageUrl = "images/red2.png"
        Image1.ImageUrl = "images/green1.png"
    End Sub

    Protected Sub btnNext2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext2.Click

        'Everything is ok so record a transaction 
        'let insert CLHD in transaction but reduce CL from quota, do same for HPL-HPL_C and HPL_P - HPL_C_P combination
        Dim tmp = InsertLeaveTransaction(Session("begdate"), Session("enddate"), Session("eid"), Session("eid") + Now.ToString, Session("holi_code"), Session("remarks"), Session("work_flow_id"), "New", Session("leavedays"), Now.ToString, Session("myIP"))
        If tmp = "ok" Then
            lblReview.Text = "<b> Your Leave Request has been sent to Approving Authority. </b> <br/>" & _
                "<a href=leavemanage.aspx?mode=leaverequest> <<--- Back </a>"
        Else
            lblReview.Text = tmp
        End If
        Image3.ImageUrl = "images/green3.png"
        Image2.ImageUrl = "images/red2.png"
        btnNext2.Text = "Done"
        btnNext2.Enabled = False
        btnPrev2.Visible = False

    End Sub
    '<<<<<<<<<<<<<<<<<<<<----------------- ########################## End of Leave request Code ############## 
    ' ########################## Start of calender master Code for web controls ############## --->>>>>>>>>>>>>>>>>>>>>>>
    Protected Sub btnSubmitCalenderMaster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmitCalenderMaster.Click

        Dim frProvider As IFormatProvider = New System.Globalization.CultureInfo("fr-CH")  ' fr style date dd.MM.yyyy
        Dim holidate As Date
        If txtHolidate.Text.Trim <> "" Then
            Try
                holidate = DateTime.Parse(txtHolidate.Text, frProvider, System.Globalization.DateTimeStyles.NoCurrentDateDefault) '' it will convert dd.mm.yyyy to mm/dd/yyyy
            Catch
                lblError2.Text = "Error: Enter a valid date in dd/MM/yyyy format. "
                Exit Sub
            End Try

        Else
            lblError2.Text = "Error: Date Field Empty. "
            Exit Sub
        End If

        '' all checks over now do the real stuff...
        Dim tmp = InsertINCalenderMaster(holidate, ddl_Levecode.SelectedValue, txtCalender.Text, txtPerarea.Text)
        If tmp = "ok" Then
            lblError2.Text = " Data Successfully Entered for " & txtHolidate.Text
            txtHolidate.Text = ""
        Else
            lblError2.Text = tmp
        End If

    End Sub
    '<<<<<<<<<<<<<<<<<<<<----------------- ########################## End of calender master Code for web controls ############## 

    ' ########################## Start of leave quota master Code  for web controls ############## --->>>>>>>>>>>>>>>>>>>>>>>
    Protected Sub btn_LQ_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_LQ_submit.Click
        ' let user see date in dd/MM/yyyy format but use default date in background

        Dim frProvider As IFormatProvider = New System.Globalization.CultureInfo("fr-CH")  ' fr style date dd.MM.yyyy
        Dim begdate As Date
        If txt_LQ_begdate.Text.Trim <> "" Then
            Try
                begdate = DateTime.Parse(txt_LQ_begdate.Text, frProvider, System.Globalization.DateTimeStyles.NoCurrentDateDefault) '' it will convert dd.mm.yyyy to mm/dd/yyyy
            Catch
                lblErrorLeaveQuota.Text = "Error: Enter a valid date in dd/MM/yyyy format. "
                Exit Sub
            End Try
        Else
            lblErrorLeaveQuota.Text = "Error: Beg Date Field Empty. "
            Exit Sub
        End If

        Dim enddate As Date

        If txt_LQ_enddate.Text.Trim <> "" Then
            Try
                enddate = DateTime.Parse(txt_LQ_enddate.Text, frProvider, System.Globalization.DateTimeStyles.NoCurrentDateDefault) '' it will convert dd.mm.yyyy to mm/dd/yyyy
            Catch
                lblErrorLeaveQuota.Text = "Error: Enter a valid date in dd/MM/yyyy format. "
                Exit Sub
            End Try
        Else
            lblErrorLeaveQuota.Text = "Error: End Date Field Empty. "
            Exit Sub
        End If

        If txt_LQ_eid.Text.Trim = "" Then
            lblErrorLeaveQuota.Text = "Error: Emp no Field Empty. "
            Exit Sub
        End If

        If txt_LQ_seq.Text.Trim = "" Then
            lblErrorLeaveQuota.Text = "Error: Seq Field Empty. "
            Exit Sub
        End If

        '' all checks over now do the real stuff...
        Dim tmp = InsertINLeaveQuotaMaster(txt_LQ_eid.Text, ddl_LQ_leavetype.SelectedValue, begdate, enddate, txt_LQ_seq.Text, txt_LQ_quota.Text, txt_LQ_claimed.Text, Now.ToString("MM/dd/yyyy"), Session("eid"), Session("myIP"))
        If tmp = "ok" Then
            lblErrorLeaveQuota.Text = " Data Successfully Entered for " & txtHolidate.Text
        Else
            lblErrorLeaveQuota.Text = tmp
        End If
    End Sub

    '<<<<<<<<<<<<<<<<<<<<----------------- ########################## End of leave quota master Code for web controls ############## 

    ' ########################## Start of End of leave balance overview  for web controls ############## --->>>>>>>>>>>>>>>>>>>>>>>
    Protected Sub gvBalance_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvBalance.PageIndexChanging
        If gvBalance.DataSource.GetType().ToString = "System.Data.DataTable" Then
            gvBalance.DataSource = SortDataTable(gvBalance.DataSource, True)
            gvBalance.PageIndex = e.NewPageIndex
            Session("page_gvBalance") = e.NewPageIndex
            gvBalance.DataBind()
        End If
    End Sub
    Protected Sub gvBalance_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvBalance.SelectedIndexChanged
        ' Bind current data
        gvBalance.DataSource = SortDataTable(gvBalance.DataSource, True)
        gvBalance.PageIndex = Session("page_gvBalance")
        gvBalance.DataBind()

        ' Clear session variables
        Session("page_gvBalance") = Nothing
        Session("SortExpression") = Nothing
        Session("CurrentQuery_gvBalance") = Nothing

    End Sub
    '<<<<<<<<<<<<<<<<<<<<----------------- ########################## End of leave balance overviewr Code for web controls ############## 
    ' ########################## Start of  leave approver  for web controls ############## --->>>>>>>>>>>>>>>>>>>>>>>
    Protected Sub gvApprove_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvApprove.PageIndexChanging
        If gvApprove.DataSource.GetType().ToString = "System.Data.DataTable" Then
            gvApprove.DataSource = SortDataTable(gvApprove.DataSource, True)
            gvApprove.PageIndex = e.NewPageIndex
            Session("page_gvApprove") = e.NewPageIndex
            gvApprove.DataBind()
        End If
    End Sub

   
    Protected Sub gvApprove_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvApprove.SelectedIndexChanged
        ' Bind current data
        gvApprove.DataSource = SortDataTable(gvApprove.DataSource, True)
        gvApprove.PageIndex = Session("page_gvApprove")
        gvApprove.DataBind()
        
        ' Clear session variables
        Session("page_gvApprove") = Nothing
        Session("SortExpression") = Nothing
        Session("CurrentQuery_gvApprove") = Nothing

    End Sub
    Protected Sub lb_Leave_Approve_Click(ByVal sender As Object, ByVal e As EventArgs)
     Dim lb As LinkButton = TryCast(sender, LinkButton)
        Dim Tx_no As String = lb.ToolTip
        lbl_Approve_Tx.Text = Tx_no ' should have only Tx_no nothing else
        ' lbl_Approve_Detail.Text = GetLeaveTransactionDetails(Tx_no)
        Dim tmp = GetLeaveTransactionDetails(Tx_no)
        Dim leave_detail As String()
        leave_detail = Split(tmp, "*")
        '' return as 009383*CLHD*7/23/2011 12:00:00 AM*7/23/2011 12:00:00 AM*May approve*1*New
        '             0      1      2                     3                    4         5  6   [[i Mod 5 = 1]]
        '' record not recursive , single row return
        lbl_Approve_eid.Text = leave_detail(0)
        lbl_Approve_holicode.Text = leave_detail(1)
        lbl_Approve_begdate.Text = leave_detail(2)
        lbl_Approve_enddate.Text = leave_detail(3)
        lbl_Approve_leavedays.Text = leave_detail(5)
        lbl_Approve_remark.text = leave_detail(4)
        lbl_Approve_status.Text = leave_detail(6)

        ModalPopupExtender_Approve.Show()


        'Dim row As GridViewRow = TryCast(sender, GridViewRow) '            ((GridViewRow)((ImageButton)sender).NamingContainer)
        '  lblLeaveApprove_info.Text = gvApprove.SelectedRow.Cells(1).Text
        'Dim mpe As AjaxControlToolkit.ModalPopupExtender = row.FindControl("txt")
        'mpe.Show()

    End Sub
    Protected Sub btn_Approve_Approved_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Approve_Approved.Click
        'To get the modal pop up buttons work you should remove the OkcontrolID and CancelControlID property
        'Dim searchstr = lbl_Approve_Detail.Text
        'Dim i = searchstr.IndexOf("^")
        'Dim j = searchstr.IndexOf("*")
        Dim status = lbl_Approve_status.Text ' searchstr.Substring(i + 1, (j - i) - 1)   'format {009383} [CL] (2) ^New* is required for searching
        Dim flag1 = ""  ' set to ok if set leave transaction details succesfull
        Dim flag2 = ""  ' '  set to ok if leave quta updated attendance master
        Dim flag3 = ""  ' set to ok if insert the attendance master.

        If status = "New" Then
            flag1 = SetLeaveTransactionDetails(lbl_Approve_Tx.Text, "Approved", Session("eid") + Now.ToString)
        ElseIf status = "ReqCancel" Then
            flag1 = SetLeaveTransactionDetails(lbl_Approve_Tx.Text, "Canceled", Session("eid") + Now.ToString)
        End If

        If flag1 = "ok" Then  'now set leave quota master

            Try


                Dim leavecode = lbl_Approve_holicode.Text '  
                ''approver can approve only these leaves/take the value from database and procede
                If leavecode = "CL" Or leavecode = "RH" Or leavecode = "HPL" Or leavecode = "EL_E" Or leavecode = "EL_NE" Or leavecode = "CLHD" Or leavecode = "HPL_C" Or leavecode = "HPL_C_P" Or leavecode = "HPL_P" Then
                   
                    Dim leavedays = lbl_Approve_leavedays.Text

                    Dim eid = lbl_Approve_eid.Text
                    If status = "New" Then
                        flag2 = SetLeaveQuotaMasterOnApproval(eid, leavecode, leavedays, False)
                    ElseIf status = "ReqCancel" Then
                        flag2 = SetLeaveQuotaMasterOnApproval(eid, leavecode, leavedays, True)
                    End If

                End If

                If flag2 = "ok" Then   ' now set attendance master
                    'flag3=InsertINAttendanceMaster (eid,leavecode,
                    lblLeaveApprove_info.Text = " Leave request Approved Succesfully for " & lbl_Approve_eid.Text
                    rebindGridView(Session("CurrentQuery_gvApprove"), gvApprove)
                Else
                    lblLeaveApprove_info.Text = " Unable to update leave quota" & flag2
                End If
            Catch
                lblLeaveApprove_info.Text = "Unable to Approve Leave"   'so reset the status to new
                flag1 = SetLeaveTransactionDetails(lbl_Approve_Tx.Text, "New", Session("eid") + Now.ToString)
            End Try


        Else
            lblLeaveApprove_info.Text = "Unable to Approve Leave" & flag1

        End If
        ModalPopupExtender_Approve.Hide()
    End Sub
    Protected Sub btn_Approve_Reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Approve_Reject.Click
        'To get the modal pop up buttons work you should remove the OkcontrolID and CancelControlID property
        Dim tmp = SetLeaveTransactionDetails(lbl_Approve_Tx.Text, "Rejected", Session("eid") + Now.ToString)
        If tmp = "ok" Then
            lblLeaveApprove_info.Text = " Leave Rejected Succesfully for " + lbl_Approve_eid.Text
            rebindGridView(Session("CurrentQuery_gvApprove"), gvApprove)
            ModalPopupExtender_Approve.Hide()
        Else
            lblLeaveApprove_info.Text = "Unable to Reject Leave" & tmp
            ModalPopupExtender_Approve.Show()
        End If

    End Sub
    '<<<<<<<<<<<<<<<<<<<<----------------- ########################## End of leave approver Code for web controls ##############
    ' ########################## Start of  leave cancelation  for web controls ############## --->>>>>>>>>>>>>>>>>>>>>>>

    Protected Sub lb_Leave_Cancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim lb As LinkButton = TryCast(sender, LinkButton)
        Dim Tx_no As String = lb.ToolTip
        lbl_Cancel_Tx.Text = Tx_no  ' should have only Tx_no nothing else
        Dim status As String ' = GetLeaveTransactionDetails(Tx_no)
        Dim tmp = GetLeaveTransactionDetails(Tx_no)
        Dim leave_detail As String()
        leave_detail = Split(tmp, "*")
        '' return as 009383*CLHD*7/23/2011 12:00:00 AM*7/23/2011 12:00:00 AM*May approve*1*New
        '             0      1      2                     3                    4         5  6   [[i Mod 5 = 1]]
        '' record not recursive , single row return

        'Dim i = status.IndexOf("^")
        'Dim j = status.IndexOf("*")
        'status = status.Substring(i + 1, (j - i) - 1)   'format {009383} [CL] (2) ^New* is required for searching
        status = leave_detail(6)
        lbl_Cancel_Detail.Text = status
        btn_LeaveCancel.Enabled = True
        If status <> "Approved" Then   'let approved leave to be canceled

            btn_LeaveCancel.Enabled = False
            lbl_Cancel_Detail.Text = "You Can Only Cancel The Leaves which are Approved.<br /><br />"
        End If
        ModalPopupExtender_LeaveCancel.Show()

    End Sub
    Protected Sub btn_LeaveCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_LeaveCancel.Click
        'To get the modal pop up buttons work you should remove the OkcontrolID and CancelControlID property

       
        Dim tmp = SetLeaveTransactionDetails(lbl_Cancel_Tx.Text, "ReqCancel", Session("eid") + Now.ToString)

            If tmp = "ok" Then

                lbl_LeaveCancelerror.Text = " Leave Sent for Cancelation to Approving Authority "
                rebindGridView(Session("CurrentQuery_gvLeaveTrackerCancel"), gvLeaveTrackerCancel)
            Else
            lbl_LeaveCancelerror.Text = "Unable to cancel Leave" & tmp

            End If

        ModalPopupExtender_LeaveCancel.Hide()
    End Sub
    Protected Sub gvLeaveTrackerCancel_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLeaveTrackerCancel.PageIndexChanging
        If gvLeaveTrackerCancel.DataSource.GetType().ToString = "System.Data.DataTable" Then
            gvLeaveTrackerCancel.DataSource = SortDataTable(gvLeaveTrackerCancel.DataSource, True)
            gvLeaveTrackerCancel.PageIndex = e.NewPageIndex
            Session("page_gvLeaveTrackerCancel") = e.NewPageIndex
            gvLeaveTrackerCancel.DataBind()
        End If
    End Sub


    Protected Sub gvLeaveTrackerCancel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvLeaveTrackerCancel.SelectedIndexChanged
        ' Bind current data
        gvLeaveTrackerCancel.DataSource = SortDataTable(gvLeaveTrackerCancel.DataSource, True)
        gvLeaveTrackerCancel.PageIndex = Session("page_gvLeaveTrackerCancel")
        gvLeaveTrackerCancel.DataBind()

        ' Clear session variables
        Session("page_gvLeaveTrackerCancel") = Nothing
        Session("SortExpression") = Nothing
        Session("CurrentQuery_gvLeaveTrackerCancel") = Nothing

    End Sub
    '<<<<<<<<<<<<<<<<<<<<----------------- ########################## End of leave cancelation  Code for web controls ##############
    ' ########################## Start of   Leave Encashment for web controls ############## --->>>>>>>>>>>>>>>>>>>>>>>
    Protected Sub btn_Leave_Encash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Leave_Encash.Click
        If IsNumeric(txt_Leave_Encash.Text) Then
            If (Convert.ToInt32(lbl_Leave_Encash_EL.Text) > Convert.ToInt32(txt_Leave_Encash.Text) And ddl_Leave_Encash.SelectedIndex = 0) Or (Convert.ToInt32(lbl_Leave_Encash_SAL.Text) > Convert.ToInt32(txt_Leave_Encash.Text) And ddl_Leave_Encash.SelectedIndex = 1) Then
                lbl_Leave_Encash_Detail.Text = " You Are Going to Encash " & txt_Leave_Encash.Text & " Nos. of " & ddl_Leave_Encash.SelectedItem.Text & _
                       " <br/> Are You Sure and Want to procede?"
                ModalPopupExtender_Leave_Encashment.Show()
            Else
                lbl_Leave_Encasherror.Text = "You can not encash more than your Balance Leave."
                Exit Sub
            End If
            
        Else
            lbl_Leave_Encasherror.Text = " Please Enter Leave to Encash only in Numeric."
        End If


    End Sub
    Protected Sub btn_Leave_Encash_Send_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Leave_Encash_Send.Click
        'To get the modal pop up buttons work you should remove the OkcontrolID and CancelControlID property
        Dim tmp = SetLeaveQuotaMasterOnApproval(Session("eid"), ddl_Leave_Encash.SelectedValue, txt_Leave_Encash.Text, False)
        If tmp = "ok" Then
            lbl_Leave_Encasherror.Text = txt_Leave_Encash.Text & " Nos. of " & ddl_Leave_Encash.SelectedItem.Text & _
                    " <br/> Has been forwarded for Leave Encashment."
            btn_Leave_Encash.Enabled = False
            lbl_Leave_Encash_EL.Text = getLeaveQuota(Session("eid"), "EL_E")
            lbl_Leave_Encash_SAL.Text = getLeaveQuota(Session("eid"), "SAL")
        Else
            lbl_Leave_Encasherror.Text = "Unable To update quota master. needs to be refined further for entry of applied leave in different rows after split. " & tmp
        End If

        ModalPopupExtender_Leave_Encashment.Hide()

    End Sub

    '<<<<<<<<<<<<<<<<<<<<----------------- ########################## End of  Leave Encashment  Code for web controls ##############
    ' ########################## Start of  view attendance  for web controls ############## --->>>>>>>>>>>>>>>>>>>>>>>
   
    Private Function BuildAttendanceGridView() As String
        'manually fill the gridview

        ' First extract the attnedance details from attendance master and fill the grid manually for empty dates
        
        Dim subeid = txt_ViewAttendance_Subord_ID.Text
        Dim va_month = txt_View_Attendance_Month.Text
        Dim va_Year = txt_View_Attendance_year.Text
        Dim tmp As String = GetAttendanceMasterDetails(subeid, va_month, va_Year)

        Dim flag1 As Boolean = True '' set to false if tmp="notfound"
        Dim att_detail As String()
        att_detail = Split(tmp, "*")
        '' return as 009383*13.05.2011*13.05.2011*24:00*CL*009383*15.05.2011*15.05.2011*24:00*OD
        '             0            1      2         3    4  5          6        7        8     9  [[i Mod 5 = 1]]
        '' record recursive at each 5 column

        If tmp = "notfound" Then   'no attndance record found so just generate dummy data
            flag1 = False
        End If
       
        Dim i As Integer
        Dim j_intime As Integer = 0
        Dim j_outtime As Integer = 0
        Dim j_status As Integer = 0
        Dim j_duration As Integer = 0

        Dim InTimefromatt_master(Int(att_detail.Length / 5)) As String  'contains intime dates only, att_detail.Length is already 4 times
        Dim OutTimefromatt_master(Int(att_detail.Length / 5)) As String  'contains outtime  only
        Dim StatusfromAtt_master(Int(att_detail.Length / 5)) As String   'contains status
        Dim DurationfromAtt_master(Int(att_detail.Length / 5)) As String  ' contains duration
        Try
           
            For i = 0 To att_detail.Length - 1
                If i Mod 5 = 1 Then  'take the In time date fields only 1,6,11,16,21 etc
                    InTimefromatt_master(j_intime) = att_detail(i).ToString
                    j_intime = j_intime + 1
                End If
                If i Mod 5 = 1 Then  'take the Out time date fields only 2,7,12,17,22 etc
                    OutTimefromatt_master(j_outtime) = att_detail(i).ToString
                    j_outtime = j_outtime + 1
                End If
                If i Mod 5 = 4 Then  'take the Holidaytype fields only 4,9,14,19 etc
                    StatusfromAtt_master(j_status) = att_detail(i).ToString
                    j_status = j_status + 1
                End If
                If i Mod 5 = 3 Then  'take the duration fields only 3,8,13,18 etc
                    DurationfromAtt_master(j_duration) = att_detail(i).ToString
                    j_duration = j_duration + 1
                End If
            Next

            '            lbl_View_Attendance_error.Text = Day(InTimefromatt_master(0)).ToString & "<br/>" & InTimefromatt_master(1) & "<br/>" & StatusfromAtt_master(0) & StatusfromAtt_master(1) & DurationfromAtt_master(0) & DurationfromAtt_master(1)
            'For i = 0 To InTimefromatt_master.Length - 1
            '    tmp = tmp & InTimefromatt_master(i) & " <br />"
            'Next
            'lbl_View_Attendance_error.Text = tmp & (InTimefromatt_master.Length - 1).ToString
            'Return "ok"

        Catch e1 As Exception
            Return "Error: at Formatting data from Attendance Master" & e1.Message
        End Try
        Dim j As Integer = 0
        Try
            Dim dt As New System.Data.DataTable()
            'Create three columns with string as their type
            dt.Columns.Add("date", String.Empty.GetType())
            dt.Columns.Add("timein", String.Empty.GetType())
            dt.Columns.Add("timeout", String.Empty.GetType())
            dt.Columns.Add("duration", String.Empty.GetType())
            dt.Columns.Add("status", String.Empty.GetType())
            dt.Columns.Add("indicator", String.Empty.GetType())

            Dim dataTableRowCount As Integer = 0

            Dim frProvider As IFormatProvider = New System.Globalization.CultureInfo("en-US")
            Dim begdate As Date
            Dim enddate As Date
            For dataTableRowCount = 1 To Date.DaysInMonth(Int(va_Year), Int(va_month))
                If flag1 Then  'record found in attendance master so put in grid
                    If dataTableRowCount = Day(InTimefromatt_master(j)) Then
                        begdate = DateTime.Parse(InTimefromatt_master(j).ToString, frProvider, System.Globalization.DateTimeStyles.NoCurrentDateDefault) '' it will convert dd.mm.yyyy to mm/dd/yyyy
                        enddate = DateTime.Parse(OutTimefromatt_master(j).ToString, frProvider, System.Globalization.DateTimeStyles.NoCurrentDateDefault) '' it will convert dd.mm.yyyy to mm/dd/yyyy
                        'OutTimefromatt_master
                        dt.Rows.Add(New String() {dataTableRowCount.ToString & "." & va_month & "." & va_Year, begdate.TimeOfDay.ToString, enddate.TimeOfDay.ToString, DurationfromAtt_master(j), StatusfromAtt_master(j), " "})

                        'dt.Rows.Add(New String() {dataTableRowCount.ToString & "Jun", begdate.TimeOfDay.ToString, "Column3", "Column4", "Column5", "Column6"})
                        If j < (InTimefromatt_master.Length - 2) Then
                            j = j + 1
                        End If
                    Else    ' generate remaining dummy data
                        'Weekday()
                        dt.Rows.Add(New String() {dataTableRowCount.ToString & "." & va_month & "." & va_Year, "00:00:00", "00:00:00", "00:00:00", "Absent", " "})

                    End If
                Else    'no attndance record found so just generate dummy data
                    dt.Rows.Add(New String() {dataTableRowCount.ToString & "." & va_month & "." & va_Year, "00:00:00", "00:00:00", "00:00:00", "Absent", " "})
                End If

            Next
            gvAttandance.DataSource = dt
            gvAttandance.DataBind()
            Return "ok"
        Catch e2 As Exception
            Return "Error: Making grid view block " & e2.Message '& InTimefromatt_master(j).ToString
        End Try

    End Function
    Protected Sub btn_View_Attendance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_View_Attendance.Click
        If Not IsNumeric(txt_View_Attendance_Month.Text) Then
            lbl_View_Attendance_error.Text = "Error: Please Enter Month in numeric only.e.g. 05 "
            Exit Sub
        ElseIf Not IsNumeric(txt_View_Attendance_year.Text) Then
            lbl_View_Attendance_error.Text = "Error: Please Enter Year in numeric only.e.g.2011 "
            Exit Sub
        End If
        Dim tmp = BuildAttendanceGridView()
        If tmp = "ok" Then
            Panel_View_Attendance.visible = False
        Else
            lbl_View_Attendance_error.Text = tmp
        End If

    End Sub
    '<<<<<<<<<<<<<<<<<<<<----------------- ########################## End of  view attendance   Code for web controls ##############
End Class
'<!-- Start of calender master Tab -->
'           <asp:TabPanel runat="server" HeaderText="Calender Master" ID="TabPanel2"     >
'                <ContentTemplate > 
'                <div class="post">
' <h2 class="title"><a href="#">Leave Quota Master Entry</a></h2>
'				<div class="entry">
'					<asp:UpdatePanel ID="up_calendermaster" runat="server"  >
'          <ContentTemplate> <!-- Put your controls for this tab in between -->
'               <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="8pt" 
'                              ForeColor="#6666FF" Height="20px" Text="Topic: " Width="75px"></asp:Label>
'                  </ContentTemplate> <!-- Put your controls for this tab in between -->
'   </asp:UpdatePanel>  <!-- end of calender master main update panel -->             
'                               </div> <!-- end of div entry -->
'						</div>   <!-- end of div post -->
'            </ContentTemplate>	
'          </asp:TabPanel>  <!-- end # of tab  panel Calender master-->