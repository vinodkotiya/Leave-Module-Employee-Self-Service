<%@ Page Language="VB" AutoEventWireup="false" CodeFile="leavemanage.aspx.vb" Inherits="leavemanage" %>
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
        <!-- Tab container start -->
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
      <ContentTemplate >
        <asp:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="4" Height="600px" 
          Width="700px"  
          AutoPostBack="true" >

          <!-- Start of Nevigation Tab -->
           <asp:TabPanel runat="server" HeaderText="Navigation" ID="TabPanel9"     >
                <ContentTemplate > 
                <div class="post">
 <h2 class="title"><a href="#">Navigation</a></h2>
				<div class="entry">
					<asp:UpdatePanel ID="up_Nevigation" runat="server"  >
          <ContentTemplate> 
             <table width =500 >
             <tr > <td height="50">
						<a href="leavemanage.aspx?mode=leaverequest"> <img src="images/dots.png" alt="->"/>  Leave Request</a> </td><td>
						<a href="leavemanage.aspx?mode=leaveapproval"><img src="images/dots.png" alt="->"/>Leave Approval</a>  </td>
                        </tr> <tr><td height="50">
						<a href="leavemanage.aspx?mode=leavecancelation"><img src="images/dots.png" alt="->"/>Leave Cancelation</a></td><td>
                        <a href="leavemanage.aspx?mode=leavecancelation"><img src="images/dots.png" alt="->"/>Leave Tracker</a> </td>
                         </tr> <tr><td height="50">
						<a href="leavemanage.aspx?mode=leavebalanceoverview"><img src="images/dots.png" alt="->"/>Leave Balance Overview</a></td><td>
						<a href="leavemanage.aspx?mode=viewattendance"><img src="images/dots.png" alt="->"/>View Attendance</a> </td>
                         </tr> <tr><td height="50">
						<a href="leavemanage.aspx?mode=leaveencashment"><img src="images/dots.png" alt="->"/>Leave Encashment</a></td><td>
						<a href="leavemanage.aspx?mode=salencashment"><img src="images/dots.png" alt="->"/>SAL Encashment</a> </td>
                         </tr> <tr><td height="50">
						<a href="leavemanage.aspx?mode=viewsubattendance"><img src="images/dots.png" alt="->"/>View Subordinate Attendance</a></td><td>
                        <a href="leavemanage.aspx?mode=calendermaster"><img src="images/dots.png" alt="->"/>Calender Master</a> </td>
                         </tr> <tr><td height="50">
                        <a href="leavemanage.aspx?mode=leavequotamaster"><img src="images/dots.png" alt="->"/>Leave Quota Master</a></td><td> </td>
                         </tr> 
				</table>	
                  </ContentTemplate> 
   </asp:UpdatePanel>  <!-- end ofNevigation main update panel -->             
                               </div> <!-- end of div entry -->
						</div>   <!-- end of div post -->
            </ContentTemplate>	
          </asp:TabPanel>  <!-- end # of tab  panel Nevigation-->
           
           <!-- Leave request module start -->
          <asp:TabPanel runat="server" HeaderText="Leave Request" ID="TabPanel1"     >
          <ContentTemplate >

        
		  <div class="post">
				<h2 class="title"><a href="#">Leave Request</a></h2>
             
				<div class="entry">
					<asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
					<asp:UpdatePanel ID="up_Leavereq_Main" runat="server"  >
          <ContentTemplate>
         <asp:UpdatePanel ID="up_Leavereq1" runat="server" ChildrenAsTriggers = "true">
          <ContentTemplate>
           <br />
            <asp:Label ID="lbl_RH_GH" runat="server" Font-Bold="False"   
                  ForeColor="#006600" Text="RH This Month " ></asp:Label> <br />
              <br />
              <asp:Label ID="Label3" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="Date *: " ></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txtDate" runat="server" CssClass= "tbox" Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False" Width="94px"></asp:TextBox>
              <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                  Enabled="True" TargetControlID="txtDate" Format="dd.MM.yyyy" >
              </asp:CalendarExtender>
              &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="To: " ></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txtDate2" runat="server" CssClass= "tbox" Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False" Width="94px"></asp:TextBox>
              <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                  Enabled="True" TargetControlID="txtDate2" Format="dd.MM.yyyy" >
              </asp:CalendarExtender>
              <br />
              <br />
     <asp:Label ID="Label2" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="Type of Leave: " ></asp:Label>

                  <asp:DropDownList ID="ddlLeaves" runat="server" cssclass="ddlbox">
              </asp:DropDownList>

                  <br />

                  <br />
                    <asp:Label ID="Label5" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="Time : " ></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txtTime" runat="server" CssClass= "tbox" Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False"  Width="94px" 
                  Text="00:00:00" MaxLength="8"></asp:TextBox>
                    <asp:Label ID="Label6" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="To : " ></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txtTime2" runat="server" CssClass= "tbox" Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False"  Width="94px" 
                  Text="00:00:00" MaxLength="8"></asp:TextBox>

                  
                  <br />

                  <br />

                  <asp:Label ID="Label4" runat="server" Font-Bold="True"   
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
              <asp:Button ID="btnNext1" runat="server" Text="Next--&gt;&gt;" 
                  CausesValidation="False" ValidationGroup="leaverequest" />
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
                  Text="&lt;&lt;-- Prev Step" Width="124px" CausesValidation="False" 
                  ValidationGroup="leaverequest" />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnNext2" runat="server" Text="Send" CausesValidation="False" 
                  ValidationGroup="leaverequest" />
           </ContentTemplate> 
        </asp:UpdatePanel> 

     </ContentTemplate> 
   </asp:UpdatePanel>  <!-- end of leave request main update panel -->
                    </div> <!-- end of div entry -->
					
			</div>   <!-- end of div post -->
		
          </ContentTemplate>	
          </asp:TabPanel>  

           <asp:TabPanel runat="server" HeaderText="Calender Master" ID="TabPanel2"     >
                <ContentTemplate >
                <div class="post">
					<h2 class="title"><a href="#">Calender Master Entry</a></h2>		
				<div class="entry">
					<asp:UpdatePanel ID="up_calendermaster" runat="server"  >
          <ContentTemplate>
               <asp:Label ID="Label8" runat="server" Text="Calender Year" Font-Bold="True"   
                  ForeColor="#6666FF"></asp:Label>
              <asp:TextBox  CssClass= "tbox" ID="txtCalender" runat="server" Text="2011" MaxLength="4" 
                   Width="41px"></asp:TextBox>
              <br /> <br />
               <asp:Label ID="Label7" runat="server" Text="Personal Area" Font-Bold="True"   
                  ForeColor="#6666FF"></asp:Label>
              <asp:TextBox  CssClass= "tbox" ID="txtPerarea" runat="server" Text="1002" MaxLength="4" 
                   Width="40px"></asp:TextBox>
              <asp:Label ID="Label9" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="Holiday Date: " ></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txtHolidate" runat="server" CssClass= "tbox" Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False"  Width="94px" 
                   ValidationGroup="calendermaster"></asp:TextBox>
              <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                  Enabled="True" TargetControlID="txtHolidate" Format="dd.MM.yyyy" >
              </asp:CalendarExtender>
                  <br />  <br /> 
     <asp:Label ID="Label10" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="Type of Leave: " ></asp:Label>

                  <asp:DropDownList ID="ddl_Levecode" runat="server" cssclass="ddlbox">
                      <asp:ListItem Value="RH">Restricted Holiday</asp:ListItem>
                      <asp:ListItem Value="GH">Govt Holiday</asp:ListItem>
              </asp:DropDownList>
                 <br /> <br />  <br /> 
              <asp:Button ID="btnSubmitCalenderMaster" runat="server" Text="Submit" 
                   CausesValidation="False" ValidationGroup="calendermaster" />
                    <br />  <br /> 
               <asp:Label ID="lblError2" runat="server" ForeColor="Red" Text="Click Here To Bulk upload through Excel Sheet."></asp:Label>
              <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="uploadexcel.aspx">Upload</asp:HyperLink>

              </ContentTemplate> 
   </asp:UpdatePanel>  <!-- end of calender master main update panel -->             
                               </div> <!-- end of div entry -->
						</div>   <!-- end of div post -->
            </ContentTemplate>	
          </asp:TabPanel>  
           <asp:TabPanel runat="server" HeaderText="Leave Quota Master" ID="TabPanel3"     >
                <ContentTemplate >
                <div class="post">
                <h2 class="title"><a href="#">Leave Quota Master Entry</a></h2>
				<div class="entry">
					<asp:UpdatePanel ID="up_LeaveQuota" runat="server"  >
          <ContentTemplate>
               <asp:Label ID="Label11" runat="server" Text="Employee No:" Font-Bold="True"   
                  ForeColor="#6666FF"></asp:Label>
              <asp:TextBox  CssClass= "tbox" ID="txt_LQ_eid" runat="server"  MaxLength="6" 
                    Width="74px"></asp:TextBox>
                       
              <asp:Label ID="Label14" runat="server" Text="Seq:" Font-Bold="True"   
                  ForeColor="#6666FF"></asp:Label>
              <asp:TextBox  CssClass= "tbox" ID="txt_LQ_seq" runat="server" Text="1"  
                   Width="41px"></asp:TextBox>
              <br /> <br />
              <asp:Label ID="Label13" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="Type of Leave: " ></asp:Label>

                  <asp:DropDownList ID="ddl_LQ_leavetype" runat="server" cssclass="ddlbox">
                     
              </asp:DropDownList>
                 
              <asp:Label ID="Label15" runat="server" Text="Leave Quota:" Font-Bold="True"   
                  ForeColor="#6666FF"></asp:Label>
              <asp:TextBox  CssClass= "tbox" ID="txt_LQ_quota" runat="server"  MaxLength="3" 
                   Width="41px"></asp:TextBox>
              <br /> <br />
              <asp:Label ID="Label16" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="Begin Date: " ></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txt_LQ_begdate" runat="server" CssClass= "tbox" Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False"  Width="94px" 
                   ValidationGroup="calendermaster"></asp:TextBox>
              <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                  Enabled="True" TargetControlID="txt_LQ_begdate" Format="dd.MM.yyyy" >
              </asp:CalendarExtender>
                  <br />  <br /> 
                  <asp:Label ID="Label17" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="End Date: " ></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txt_LQ_enddate" runat="server" CssClass= "tbox" Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False"  Width="94px" 
                   ValidationGroup="calendermaster"></asp:TextBox>
              <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                  Enabled="True" TargetControlID="txt_LQ_enddate" Format="dd.MM.yyyy" >
              </asp:CalendarExtender>
                  <br />  <br /> 
              <asp:Label ID="Label12" runat="server" Text="Claimed:" Font-Bold="True"   
                  ForeColor="#6666FF"></asp:Label>
              <asp:TextBox  CssClass= "tbox" ID="txt_LQ_claimed" runat="server" Text="0" MaxLength="3" 
                   Width="41px"></asp:TextBox>
              <br /> <br />
              <asp:Label ID="lbl_LQ_Detail" runat="server" Text="Created on/userid/ipadress:" Font-Bold="True"   
                  ForeColor="#6666FF"></asp:Label>
                   <br /> <br />  <br /> 
              <asp:Button ID="btn_LQ_submit" runat="server" Text="Submit" 
                   CausesValidation="False" ValidationGroup="leavequotamaster" />
                    <br />  <br /> 
               <asp:Label ID="lblErrorLeaveQuota" runat="server" ForeColor="Red" Text="Click Here To Bulk upload through Excel Sheet."></asp:Label>
                  </ContentTemplate>  
   </asp:UpdatePanel>  <!-- end of leave quota main update panel -->             
                               </div> <!-- end of div entry -->
						</div>   <!-- end of div post -->
            </ContentTemplate>	
          </asp:TabPanel>  
           <asp:TabPanel runat="server" HeaderText="Leave Balance Overview" ID="TabPanel4"     >
                <ContentTemplate > 
                <div class="post">
 <h2 class="title"><a href="#">Leave Balance Overview</a></h2>
				<div class="entry">
					<asp:UpdatePanel ID="up_LeaveBalanceOverview" runat="server"  >
          <ContentTemplate> 
               <asp:GridView ID="gvBalance" runat="server" Height="109px" PageSize="10" 
              Width="611px" AllowPaging="True" 
                 AutoGenerateColumns="False" 
                        EmptyDataText="No records found" GridLines="None" 
              BorderWidth="2px">
                        <Columns>
                             <asp:BoundField DataField="Sub_type"  ShowHeader="False" 
                                 HeaderText="Leave Type" >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Font-Size="8pt" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Claimed"  ShowHeader="False" 
                                 HeaderText="Claimed" >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Font-Size="8pt" />
                             </asp:BoundField>
                        <asp:BoundField DataField="Begda"  ShowHeader="False" HeaderText="Beg Date" >
                            <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="20%" Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Endda"  ShowHeader="False" HeaderText="End Date" >
                            <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="20%" Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quota"  ShowHeader="False" 
                                 HeaderText="Balance Quota" >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Font-Size="8pt" />
                             </asp:BoundField>
                            
                      </Columns>
                      <AlternatingRowStyle BackColor="#E6E6E6"  />
                     </asp:GridView>
                  </ContentTemplate> 
   </asp:UpdatePanel>  <!-- end of leave balance overview main update panel -->             
                               </div> <!-- end of div entry -->
						</div>   <!-- end of div post -->
            </ContentTemplate>	
          </asp:TabPanel>  
           <asp:TabPanel runat="server" HeaderText="Leave Approver" ID="TabPanel5"     >
                <ContentTemplate > 
                <div class="post">
 <h2 class="title"><a href="#">Leave Approver</a></h2>
				<div class="entry">
					<asp:UpdatePanel ID="up_LeaveApprover" runat="server"  >
          <ContentTemplate> 
              <asp:GridView ID="gvApprove" runat="server" Height="109px" PageSize="10" 
              Width="611px" AllowPaging="True" 
                 AutoGenerateColumns="False" 
                        EmptyDataText="No records found" GridLines="None" ShowHeader="True"
              BorderWidth="2px">
                        <Columns>
                             <asp:BoundField DataField="Emp_no"  ShowHeader="False" 
                                 HeaderText="Emp No" >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Font-Size="8pt" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Leave_type"  ShowHeader="False" 
                                 HeaderText="Leave Type" >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Font-Size="8pt" />
                             </asp:BoundField>
                        <asp:BoundField DataField="Leave_st_date"  ShowHeader="False" HeaderText="Beg Date" >
                            <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="20%" Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Leave_end_dt"  ShowHeader="False" HeaderText="End Date" >
                            <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="20%" Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status"  ShowHeader="False" 
                                 HeaderText="Status" >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Font-Size="8pt" />
                             </asp:BoundField>
                            <asp:TemplateField HeaderText="Decision">
        <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lb_Leave_Approve" Text="Approve/Reject"  ToolTip='<%# Eval("Tx_no") %>'  OnClick = "lb_Leave_Approve_Click" />
                      
        </ItemTemplate>
         <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="20%" Font-Size="8pt" />
    </asp:TemplateField>
                      </Columns>
                      <AlternatingRowStyle BackColor="#E6E6E6"  />
                     </asp:GridView>
             
 <asp:Label ID="lblLeaveApprove_info" runat="server" ForeColor="Red" Text="InfoBar"></asp:Label>

<!-- Start of Modal Popup for Leave approval just below the concerned grid view -->
              <asp:Button runat="server" ID="btnShowModalPopup" style="display:none"/>    
          <asp:ModalPopupExtender ID="ModalPopupExtender_Approve" runat="server" TargetControlID="btnShowModalPopup" PopupControlID="up_Modal_Approve" BackgroundCssClass="modalBackground" dropshadow="true"  PopupDragHandleControlID="panelDragHandle"  ></asp:ModalPopupExtender>
    <div id="LeaveApproveModalSection">
     <asp:UpdatePanel ID="up_Modal_Approve" runat="server" CssClass="modalpopup"  style="display:none">
   <ContentTemplate>
   <div class="insidemodalpopup">
   <asp:Panel runat="Server" ID="panelDragHandle" CssClass="drag">
                           Hold to Drag 
                    </asp:Panel>
              <center>    <h3> Leave Approve </h3> <br /> </center> 
       <asp:Label ID="Label32" runat="server" Text="Leave Transaction No: "></asp:Label>
               <asp:Label ID="lbl_Approve_Tx" runat="server" Text="Loading Leave Details "></asp:Label>
                <br /> 
                 
       <asp:Label ID="Label25" runat="server" Text="Employee No: " Font-Bold="True"></asp:Label><asp:Label
           ID="lbl_Approve_eid" runat="server" Text=""></asp:Label> <br />
           <asp:Label ID="Label26" runat="server" Text="Leave Type: " Font-Bold="True"></asp:Label><asp:Label
           ID="lbl_Approve_holicode" runat="server" Text=""></asp:Label> <br />
           <asp:Label ID="Label27" runat="server" Text="Leave Beg Date: " Font-Bold="True"></asp:Label><asp:Label
           ID="lbl_Approve_begdate" runat="server" Text=""></asp:Label> <br />
            <asp:Label ID="Label28" runat="server" Text="Leave End Date: " Font-Bold="True"></asp:Label><asp:Label
           ID="lbl_Approve_enddate" runat="server" Text=""></asp:Label> <br />
           <asp:Label ID="Label29" runat="server" Text="Total No Of Leaves: " Font-Bold="True"></asp:Label><asp:Label
           ID="lbl_Approve_leavedays" runat="server" Text=""></asp:Label> <br />
            <asp:Label ID="Label30" runat="server" Text="Remarks: " Font-Bold="True"></asp:Label><asp:Label
           ID="lbl_Approve_remark" runat="server" Text=""></asp:Label> <br />
           <asp:Label ID="Label31" runat="server" Text="Leave Status: " Font-Bold="True"></asp:Label><asp:Label
           ID="lbl_Approve_status" runat="server" Text=""></asp:Label> <br />
                <br />
           <center>    <asp:Button ID="btn_Approve_Approved" runat="server" Text="Approve"  
                   BorderWidth="2px" BorderColor="Green" 
                   CausesValidation="False" 
                   ValidationGroup="vg1" />
           <asp:Button ID="btn_Approve_Reject" runat="server" Text="Reject"  BorderWidth="2px" BorderColor="Green" CausesValidation="False" 
                   ValidationGroup="vg2"/> <asp:Button ID="btn_LA_NoDecision" runat="server" Text="<<--Back"  BorderWidth="2px" BorderColor="Green" CausesValidation="False" 
                   ValidationGroup="vg2"/></center>  
   </div>
   </ContentTemplate>
     </asp:UpdatePanel>
    
        </div>
          <!-- end #of Modal Popup for Leave approval -->

           <br />  <br /> 
              

                  </ContentTemplate> 
   </asp:UpdatePanel>  <!-- end of Leave Approver main update panel -->             
                               </div> <!-- end of div entry -->
						</div>   <!-- end of div post -->
            </ContentTemplate>	
          </asp:TabPanel>  

          <asp:TabPanel runat="server" HeaderText="Leave Cancelation and Tracker" ID="TabPanel6"     >
                <ContentTemplate > 
                <div class="post">
 <h2 class="title"><a href="#">Leave Tracker/Cancelation</a></h2>
				<div class="entry">
					<asp:UpdatePanel ID="up_LeaveTrackerCancel" runat="server"  >
          <ContentTemplate> 
              <asp:GridView ID="gvLeaveTrackerCancel" runat="server" Height="109px" PageSize="10" 
              Width="611px" AllowPaging="True" 
                 AutoGenerateColumns="False" 
                        EmptyDataText="No records found" GridLines="None" 
              BorderWidth="2px">
                        <Columns>
                             
                             <asp:BoundField DataField="Leave_type"  ShowHeader="False" 
                                 HeaderText="Leave Type" >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Font-Size="8pt" />
                             </asp:BoundField>
                        <asp:BoundField DataField="Leave_st_date"  ShowHeader="False" HeaderText="Beg Date" >
                            <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="20%" Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Leave_end_dt"  ShowHeader="False" HeaderText="End Date" >
                            <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="20%" Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="leavedays"  ShowHeader="False" 
                                 HeaderText="No of Days" >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Font-Size="8pt" />
                             </asp:BoundField>
                            <asp:BoundField DataField="Status"  ShowHeader="False" 
                                 HeaderText="Status" >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Font-Size="8pt" />
                             </asp:BoundField>
                            <asp:TemplateField HeaderText="Request">
        <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lb_Leave_Cancel" Text="Cancel Leave"  ToolTip='<%# Eval("Tx_no") %>'  OnClick = "lb_Leave_Cancel_Click" />
                      
        </ItemTemplate>
         <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="20%" Font-Size="8pt" />
    </asp:TemplateField>
                      </Columns>
                      <AlternatingRowStyle BackColor="#E6E6E6"  />
                     </asp:GridView>
             
 <asp:Label ID="lbl_LeaveCancelerror" runat="server" ForeColor="Red" Text="InfoBar"></asp:Label>

<!-- Start of Modal Popup for Leave cancelation just below the concerned grid view -->
              <asp:Button runat="server" ID="btnShowMPCancel" style="display:none"/>    
          <asp:ModalPopupExtender ID="ModalPopupExtender_LeaveCancel" runat="server" TargetControlID="btnShowMPCancel" PopupControlID="up_Modal_Cancel" BackgroundCssClass="modalBackground" dropshadow="true"  PopupDragHandleControlID="panel_CancelDragHandle"  ></asp:ModalPopupExtender>
    <div id="Div1">
     <asp:UpdatePanel ID="up_Modal_Cancel" runat="server" CssClass="modalpopup"  style="display:none">
   <ContentTemplate>
   <div class="insidemodalpopup">
   <asp:Panel runat="Server" ID="panel_CancelDragHandle" CssClass="drag">
                            Hold to Drag 
                    </asp:Panel>
              <center>    <h3> Leave Cancelation </h3> <br /> </center> 
               <asp:Label ID="lbl_Cancel_Tx" runat="server" Text="Loading Leave Details "></asp:Label>
                <br /> 
                  <asp:Label ID="lbl_Cancel_Detail" runat="server" Text=" "></asp:Label>
                <br />
           <center>    <asp:Button ID="btn_LeaveCancel" runat="server" Text="Request Cancelation"  
                   BorderWidth="2px" BorderColor="Green" 
                   CausesValidation="False" 
                   ValidationGroup="vg3" />
           <asp:Button ID="btn_LC_close" runat="server" Text="<<-Back"  BorderWidth="2px" BorderColor="Green" CausesValidation="False" 
                   ValidationGroup="vg3"/></center>  
   </div>
   </ContentTemplate>
     </asp:UpdatePanel>
     
        </div>
          <!-- end #of Modal Popup for Leave cancelation -->

           <br />  <br /> 
              

                  </ContentTemplate> 
   </asp:UpdatePanel>  <!-- end of Leave cancelationr main update panel -->             
                               </div> <!-- end of div entry -->
						</div>   <!-- end of div post -->
            </ContentTemplate>	
          </asp:TabPanel>  

          <!-- Start of Leave Encashment Tab -->
           <asp:TabPanel runat="server" HeaderText="Leave Encashment" ID="TabPanel7"     >
                <ContentTemplate > 
                <div class="post">
 <h2 class="title"><a href="#">Leave Encashment</a></h2>
				<div class="entry">
					<asp:UpdatePanel ID="up_Leave_Encashment" runat="server"  >
          <ContentTemplate> 
          <asp:Label ID="Label19" runat="server" Text="No of Leave To Encash" Font-Bold="True"   
                  ForeColor="#6666FF"></asp:Label>
              <asp:TextBox ID="txt_Leave_Encash" runat="server" Text="00" MaxLength="3" 
                   CssClass= "tbox" Width="41px"></asp:TextBox>
              <br /> <br />
               <asp:Label ID="Label18" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="Type of Leave To Encash: " ></asp:Label>

                  <asp:DropDownList ID="ddl_Leave_Encash" runat="server" cssclass="ddlbox">
                      <asp:ListItem Value="EL">Earned Leave</asp:ListItem>
                      <asp:ListItem Value="SAL">Special Additional Leave</asp:ListItem>
              </asp:DropDownList>
              <br /> <br />  <br /> 
              <asp:Button ID="btn_Leave_Encash" runat="server" Text="Submit" 
                   CausesValidation="False" ValidationGroup="vg_encash" />
                    <br />  <br /> 
                   <asp:Label ID="Label20" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="Balance Earned Leave (As on Date)" ></asp:Label> <asp:Label ID="lbl_Leave_Encash_EL" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="" ></asp:Label>
                  <br /> 
                   <asp:Label ID="Label21" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="Balance Special Additional Leave Leave (As on Date)" ></asp:Label> <asp:Label ID="lbl_Leave_Encash_SAL" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="" ></asp:Label>  <br /> 
               <asp:Label ID="lbl_Leave_Encasherror" runat="server" ForeColor="Red" Text="InfoBar"></asp:Label>

               <!-- Start of Modal Popup for Leave Encashment just below the concerned grid view -->
              <asp:Button runat="server" ID="btn_mp_Leave_Encashment" style="display:none"/>    
          <asp:ModalPopupExtender ID="ModalPopupExtender_Leave_Encashment" runat="server" TargetControlID="btn_mp_Leave_Encashment" PopupControlID="up_Modal_Leave_Encashment" BackgroundCssClass="modalBackground" dropshadow="true"  PopupDragHandleControlID="panel_Leave_Encashment"  ></asp:ModalPopupExtender>
    <div id="Div2">
     <asp:UpdatePanel ID="up_Modal_Leave_Encashment" runat="server" CssClass="modalpopup"  style="display:none">
   <ContentTemplate>
   <div class="insidemodalpopup">
   <asp:Panel runat="Server" ID="panel_Leave_Encashment" CssClass="drag">
                            Hold to Drag 
                    </asp:Panel>
              <center>    <h3> Leave Encashment </h3> <br /> </center> 
            
                  <asp:Label ID="lbl_Leave_Encash_Detail" runat="server" Text=" "></asp:Label>
                <br />
           <center>    <asp:Button ID="btn_Leave_Encash_Send" runat="server" Text="Submit To Encash."  
                   BorderWidth="2px" BorderColor="Green" 
                   CausesValidation="False" 
                   ValidationGroup="vg_encash" />
           <asp:Button ID="btn_Leave_Encash_Back" runat="server" Text="<<-Back"  BorderWidth="2px" BorderColor="Green" CausesValidation="False" 
                   ValidationGroup="vg_encash"/></center>  
   </div>
   </ContentTemplate>
     </asp:UpdatePanel>
     
        </div>
          <!-- end #of Modal Popup for Leave Encashment -->

           <br />  <br /> 

                  </ContentTemplate> 
   </asp:UpdatePanel>  <!-- end of Leave Encashment main update panel -->             
                               </div> <!-- end of div entry -->
						</div>   <!-- end of div post -->
            </ContentTemplate>	
          </asp:TabPanel>  <!-- end # of tab  panel Leave Encashment-->

          <!-- Start of View Attendance Tab -->
           <asp:TabPanel runat="server" HeaderText="View Attendance" ID="TabPanel8"     >
                <ContentTemplate > 
                <div class="post">
 <h2 class="title"><a href="#">View Attendance</a></h2> <a href="leavemanage.aspx?mode=viewsubattendance" style="left: auto">View Subordinate Attendance</a>
				<div class="entry">
					<asp:UpdatePanel ID="up_View_Attendance" runat="server"  >
          <ContentTemplate> 
              <asp:Panel ID="Panel_View_Attendance" runat="server">
              
              <asp:Label ID="Label22" runat="server" Text="Enter Month:" Font-Bold="True"   
                  ForeColor="#6666FF"></asp:Label>
              <asp:TextBox ID="txt_View_Attendance_Month" runat="server" Text="" MaxLength="2" 
                  CssClass= "tbox" Width="41px"></asp:TextBox>
               <asp:Label ID="Label23" runat="server" Font-Bold="True"   
                  ForeColor="#6666FF" Text="Enter Year: " ></asp:Label>
                   <asp:TextBox ID="txt_View_Attendance_year" runat="server" Text="" MaxLength="4" 
                  CssClass= "tbox" Width="41px"></asp:TextBox>
                    <br /> <br />
                   <asp:Label ID="Label24" runat="server" Text="Emp No:" Font-Bold="True"   
                  ForeColor="#6666FF"></asp:Label>
              <asp:TextBox ID="txt_ViewAttendance_Subord_ID" runat="server" Text="" MaxLength="6" 
                  CssClass= "tbox" Width="41px"></asp:TextBox>
             
                   <br /> <br />  <br /> 
              <asp:Button ID="btn_View_Attendance" runat="server" Text="Execute" 
                   CausesValidation="False" ValidationGroup="vg_atte" />
                    <br />  <br /> 
                    </asp:Panel>
                      <asp:Label ID="lbl_View_Attendance_error" runat="server" ForeColor="Red" Text="InfoBar"></asp:Label>

                     <asp:GridView ID="gvAttandance" runat="server" Height="109px" PageSize="31" 
              Width="611px" AllowPaging="false" 
                 AutoGenerateColumns="False" 
                        EmptyDataText="No records found" GridLines="None" 
              BorderWidth="2px">
                        <Columns>
                             <asp:BoundField DataField="date"  ShowHeader="False" 
                                 HeaderText="Date" >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Width="20%" Font-Size="8pt" Font-Bold="true" />
                             </asp:BoundField>
                             <asp:BoundField DataField="timein"  ShowHeader="False" 
                                 HeaderText="Time In" >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Width="20%" Font-Size="8pt" />
                             </asp:BoundField>
                        <asp:BoundField DataField="timeout"  ShowHeader="False" HeaderText="Time Out" >
                            <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="20%" Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="duration"  ShowHeader="False" HeaderText="Duration" >
                            <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="10%" Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="status"  ShowHeader="False" 
                                 HeaderText="Status" >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Font-Size="8pt" />
                             </asp:BoundField>
                            <asp:BoundField DataField="indicator"  ShowHeader="False" 
                                 HeaderText="Regularization Indicator" >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Font-Size="8pt" />
                             </asp:BoundField>
                      </Columns>
                      <AlternatingRowStyle BackColor="#E6E6E6"  />
                     </asp:GridView>
                  

                  </ContentTemplate> 
   </asp:UpdatePanel>  <!-- end of View Attendance main update panel -->             
                               </div> <!-- end of div entry -->
						</div>   <!-- end of div post -->
            </ContentTemplate>	
          </asp:TabPanel>  <!-- end # of tab  panel View Attendance-->

          </asp:TabContainer> <!-- end # of tab container -->
          </ContentTemplate>
          </asp:UpdatePanel> <!-- end # of  update panel for tabcontainer -->
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
