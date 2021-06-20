<%@ Page Language="VB" AutoEventWireup="false" CodeFile="leave_req_m1.aspx.vb" Inherits="leave_req_m1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Employee Self Service</title>
<meta name="keywords" content="" />
<meta name="description" content="" />
<link href="style.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
            
    </div>

    <div id="logo">
		<h1><a href="#">Employee Self Service  </a></h1>
		<p><em> Welcome <a href="#"> : Employee No</a></em></p>
	</div>
	<hr />
	<!-- end #logo -->
	<div id="header">
		<div id="menu">
			<ul>
				<li><a href="#" class="first">Home</a></li>
				<li class="current_page_item"><a href="#">Leave</a></li>
				<li><a href="#">Loan</a></li>
				<li><a href="#">Travel</a></li>
			</ul>
		</div>
		<!-- end #menu -->
		<div id="search">
			
				<fieldset>
				<input type="text" name="s" id="search-text" size="15" />
				<input type="submit" id="search-submit" value="GO" />
				</fieldset>
			
		</div>
		<!-- end #search -->
	</div>
	<!-- end #header -->
	<!-- end #header-wrapper -->
	<div id="page">
		<div id="content">
		  <div class="post">
				<h2 class="title"><a href="#">Leave Request</a></h2>
				<div class="entry">
					<asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers = "true">
          <ContentTemplate>
              <asp:Image ID="Image1" runat="server" ImageUrl="images/green1.png" />
              <asp:Image ID="Image2" runat="server" ImageUrl="images/red2.png" />
              <asp:Image ID="Image3" runat="server" ImageUrl="images/red3.png" />
          
          </ContentTemplate> 
        </asp:UpdatePanel>
			</div>
		  </div>
			<div class="post">
								
				<div class="entry">
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
              <asp:Label ID="lblError1" runat="server" ForeColor="Red" 
                  Text="InfoBar: Fill the above details to apply leave..." Font-Bold="True"></asp:Label>
              <br />

     </ContentTemplate> 
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="up_Leavereq2" runat="server" ChildrenAsTriggers = "true" 
             Visible="False">
          <ContentTemplate>
           <br />
              <asp:Label ID="lblReview" runat="server" Text="Label" ForeColor="#3366FF"></asp:Label>
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
					
			</div>
			
		</div><!-- end #content -->
		<div id="sidebar">
			<ul>
				<li>
					<h2>Leave & Attendance</h2>
					<p>Balance leaves report.Linkage with leave encashment.Status of applied leave request.Other various MIS / DSS reports for management.Leave Ledger.List of rejected leave.Employee Absence.</p>
				</li>
				<li>
					<h2>Nevigation </h2>
					<ul>
						<li><a href="#">Leave Request</a></li>
						<li><a href="#">Leave Approval</a></li>
						<li><a href="#">Leave Cancelation</a></li>
						<li><a href="#">Leave Balance Overview</a></li>
						<li><a href="#">View Attendance</a></li>
						<li><a href="#">Leave Encashment</a></li>
						<li><a href="#">SAL Encashment</a></li>
						<li><a href="#">View Subordinate Attendance</a></li>
					</ul>
				</li>
				
			</ul>
		</div>
		<!-- end #sidebar -->
		<div style="clear: both;">&nbsp;</div>
	</div>
	<!-- end #page -->
	<div id="footer">
		<p>Copyright (c) 2008 vinodkotiya.com. All rights reserved. Design by <a href="http://www.vinodkotiya.com/"> License under creative commons</a>.</p>
	</div>
	<!-- end #footer -->
    </form>
</body>
</html>
