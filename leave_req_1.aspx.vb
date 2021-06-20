Imports LeaveClass

Partial Class leave_req_1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            'this code be executed only first time any event happen on web page

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

        '' lets check leave applied is valid or not.. accordingly show the errors...
        Dim errormsg = checkLeaveRuleBook(begdate, enddate, Int(leavedays), "009383", "1002", ddlLeaves.SelectedValue)
        If errormsg = "ok" Then
            isLeaveValid = True
        End If
        lblError1.Text = errormsg

        ''##################################################################
        '''' This is the next level if every logic checked above is fine
        If isLeaveValid Then
            up_Leavereq1.Visible = False
            up_Leavereq2.Visible = True
            lblStatus2.BackColor = Drawing.Color.Lime
            lblStatus1.BackColor = Drawing.Color.Red

            lblReview.Text = "  Type of Leave     : " + ddlLeaves.SelectedItem.Text & _
                "<br /> <br /> Date     :    From " + begdate.ToString + "   To  " + enddate.ToString & _
             " <br /> <br /> Duration     :   " + leavedays + " Days" & _
             " <br /> <br /> Approving Authority :    " & _
               " <br /> <br /> Note for Approver :    " & txtRemark.Text
        End If
    End Sub

    Protected Sub btnPrev2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev2.Click
        up_Leavereq1.Visible = True
        up_Leavereq2.Visible = False
        lblStatus2.BackColor = Drawing.Color.Red
        lblStatus1.BackColor = Drawing.Color.Lime
    End Sub
End Class
