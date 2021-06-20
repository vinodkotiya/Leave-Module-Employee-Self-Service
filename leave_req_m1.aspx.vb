Imports LeaveClass

Partial Class leave_req_m1
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
                ddlLeaves.Items.Add(New ListItem(leaves(i).ToString, holicodes(i).ToString))
                i = i + 1
            End While
        End If

        'below code  will be executed every time any event happen on web page
    End Sub

    Protected Sub btnNext1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext1.Click
        ' major ovehaul reqired in datetime operation
        ' let user see date in dd/MM/yyyy format but use default date in background
        Dim isLeaveValid As Boolean = False
        Dim leavedays As String
        Dim begdate As Date
        begdate = Date.Parse(txtDate.Text).Date
        begdate = Date.Parse(begdate.ToString("dd/MM/yyyy") & " " & txtTime.Text) '
        Dim enddate As Date
        '' this perfect code gives error if conflict in OS default time format.

        If IsDate(txtDate2.Text) Then
            enddate = Date.Parse(txtDate2.Text).Date
            enddate = Date.Parse(enddate.ToString("dd/MM/yyyy") & " " & txtTime2.Text)
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
                "<br /> <br />  <b> Date     : </b>    From " + begdate.ToString + "   To  " + enddate.ToString & _
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
        Dim tmp = InsertLeaveTransaction(Session("begdate"), Session("enddate"), Session("eid"), Session("eid") + Now.ToString, Session("holi_code"), Session("remarks"), Session("work_flow_id"), "New", Session("leavedays"), Now.ToString, Session("myIP"))
        If tmp = "ok" Then
            lblReview.Text = "<b> Your Leave Request has been sent to Approving Authority. </b>"
        Else
            lblReview.Text = tmp
        End If
        Image3.ImageUrl = "images/green3.png"
        Image2.ImageUrl = "images/red2.png"
        btnNext2.Text = "Done"
        btnNext2.Enabled = False
        btnPrev2.Visible = False

    End Sub
End Class
