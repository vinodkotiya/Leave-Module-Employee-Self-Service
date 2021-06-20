<%@ Page Language="VB" AutoEventWireup="false" CodeFile="leave_req_1.aspx.vb" Inherits="leave_req_1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="vinstyles.css" />
    <style type="text/css">
        .tbox
        {}
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div>
    
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
    
        
    </div>
    <div id="container">
  <div id="header">
    <h2><a href="http://vinodkotiya.blogspot.com">Employee Self Service </a></h2>
        
  </div>
  <div id="wrapper">
      <div id="content">
          <p>
              <strong><a href="http://vinodkotiya.blogspot.com">Leave and Attendance Module   </a>
      </strong> </p> 
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers = "true">
          <ContentTemplate>

          
              <asp:Label ID="lblStatus1" runat="server" BackColor="Lime" 
                  Text="--&gt; [1] Display and Edit---"></asp:Label>
              <asp:Label ID="lblStatus2" runat="server" BackColor="Red" 
                  Text="---[2] Review and Send---"></asp:Label>
              <asp:Label ID="lblStatus3" runat="server" BackColor="Red" 
                  Text="---[3] Completed---#"></asp:Label>

          
          </ContentTemplate> 
        </asp:UpdatePanel>
    </div>
  </div>
  <div id="navigation">
    <p><strong>Navigation Here</strong></p>
    <ul>
      <li><a href="http://vinodkotiya.blogspot.com/">Leave Balance</a></li>
      <li><a href="http://vinodkotiya.blogspot.com"> Leave Encash</a></li>
    </ul>
  </div>
  <div id="extra">
   <asp:UpdatePanel ID="up_Leavereq_Main" runat="server" ChildrenAsTriggers = "true"  >
          <ContentTemplate>
         <asp:UpdatePanel ID="up_Leavereq1" runat="server" ChildrenAsTriggers = "true">
          <ContentTemplate>
           <br />
              <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                  ForeColor="#6666FF" Text="Date *: " ></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txtDate" runat="server" CssClass= "tbox" Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False" Height="16px" Width="94px"></asp:TextBox>
              <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                  Enabled="True" TargetControlID="txtDate" Format="dd/MM/yyyy" >
              </asp:CalendarExtender>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                  ControlToValidate="txtDate" ErrorMessage="Enter Date" ForeColor="Red"></asp:RequiredFieldValidator>
                 
                  <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                  ForeColor="#6666FF" Text="To: " ></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txtDate2" runat="server" CssClass= "tbox" Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False" Height="16px" Width="94px"></asp:TextBox>
              <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                  Enabled="True" TargetControlID="txtDate2" Format="dd/MM/yyyy" >
              </asp:CalendarExtender>
              <br />
              <br />
     <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                  ForeColor="#6666FF" Text="Type of Leave: " ></asp:Label>

                  <asp:DropDownList ID="ddlLeaves" runat="server">
              </asp:DropDownList>

                  <br />

                  <br />
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                  ForeColor="#6666FF" Text="Time : " ></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txtTime" runat="server" CssClass= "tbox" Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False" Height="16px" Width="94px" 
                  Text="00:00:00" MaxLength="8"></asp:TextBox>
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" 
                  ForeColor="#6666FF" Text="To : " ></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txtTime2" runat="server" CssClass= "tbox" Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False" Height="16px" Width="94px" 
                  Text="00:00:00" MaxLength="8"></asp:TextBox>

                  
                  <br />

                  <br />

                  <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                  ForeColor="#6666FF" Text="Note for Approver: " ></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txtRemark" runat="server"  Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False" Height="100px" Width="200px" 
                  TextMode="MultiLine"></asp:TextBox>

              <br />
              <br />

              <br />
              <asp:Button ID="btnPrev1" runat="server" Enabled="False" 
                  Text="&lt;&lt;-- Prev Step" Width="124px" />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnNext1" runat="server" Text="Next--&gt;&gt;" />
              <br />
              <asp:Label ID="lblError1" runat="server" ForeColor="Red" Text="Label"></asp:Label>
              <br />

     </ContentTemplate> 
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="up_Leavereq2" runat="server" ChildrenAsTriggers = "true" 
             Visible="False">
          <ContentTemplate>
           <br />
              <asp:Label ID="lblReview" runat="server" Text="Label"></asp:Label>
              <br /> <br />
            <asp:Button ID="btnPrev2" runat="server" 
                  Text="&lt;&lt;-- Prev Step" Width="124px" />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnNext2" runat="server" Text="Send" />
           </ContentTemplate> 
        </asp:UpdatePanel>

     </ContentTemplate> 
   </asp:UpdatePanel>
  </div>
  <div id="footer">
    <p>Footer</p>
  </div>
</div>
</form>
</body>
</html>
