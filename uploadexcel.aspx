<%@ Page Language="VB" AutoEventWireup="false" CodeFile="uploadexcel.aspx.vb" Inherits="uploadexcel" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Employee Self Service</title>
<meta name="keywords" content="" />
<meta name="description" content="" />
<link href="reset.css" rel="stylesheet" type="text/css" media="screen" />
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
 <h2 class="title"><a href="#">Upload Excel Data</a></h2>
				<div class="entry">
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
      <ContentTemplate >
      <asp:AsyncFileUpload ID="afuFile" runat="server" UploaderStyle="Modern" 
                  CompleteBackColor="#0099CC" Font-Names="Arial" 
                  ForeColor="#0066FF" UploadingBackColor="#99FF99" Visible="True" 
                       FailedValidation="False"   />
                <asp:Button ID="btnUpload" runat="server" Text="Upload"
              OnClick="btnUpload_Click" />
                    <br />
                     <asp:Label ID="lblError1" runat="server" ForeColor="Red" 
                  Text="InfoBar: " Font-Bold="True"></asp:Label>

                    <asp:GridView ID="GridView1" runat="server"
                         AllowPaging = "true">
                       </asp:GridView>
          </ContentTemplate>
          </asp:UpdatePanel> <!-- end # of  update panel for tabcontainer -->
		
         </div> <!-- end of div entry -->
						</div>   <!-- end of div post -->
                        </div><!-- end #content -->
		<div id="sidebar">
			<ul>
				<li>
					<h2>Leave & Attendance</h2>
					<p>Balance leaves report. Linkage with leave encashment. Status of applied leave request. Other various MIS / DSS reports for management. Leave Ledger. List of rejected leave. Employee Absence.</p>
				</li>
				<li>
					<h2>Navigation </h2>
					<ul>
						<li><a href="leavemanage.aspx?mode=leaverequest">Leave Request</a></li>
						<li><a href="leavemanage.aspx?mode=leaveapproval">Leave Approval</a></li>
						<li><a href="leavemanage.aspx?mode=leavecancelation">Leave Cancelation</a></li>
                        <li><a href="leavemanage.aspx?mode=leavecancelation">Leave Tracker</a></li>
						<li><a href="leavemanage.aspx?mode=leavebalanceoverview">Leave Balance Overview</a></li>
						<li><a href="leavemanage.aspx?mode=viewattendance">View Attendance</a></li>
						<li><a href="leavemanage.aspx?mode=leaveencashment">Leave Encashment</a></li>
						<li><a href="leavemanage.aspx?mode=salencashment">SAL Encashment</a></li>
						<li><a href="leavemanage.aspx?mode=viewsubattendance">View Subordinate Attendance</a></li>
                        <li><a href="leavemanage.aspx?mode=calendermaster">Calender Master</a></li>
                        <li><a href="leavemanage.aspx?mode=leavequotamaster">Leave Quota Master</a></li>
					</ul>
				</li>
				
			</ul>
		</div>
		<!-- end #sidebar -->
		<div style="clear: both;">&nbsp;</div>
	</div>
	<!-- end #page -->
	<div id="footer">
		<p> Design by 2011 NTPC Limited <a href="http://www.vinodkotiya.com/"> License under creative commons</a>.</p>
	</div>
	<!-- end #footer -->

    

    </form>
</body>
</html>
