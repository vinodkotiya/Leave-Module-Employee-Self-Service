/****** Object:  Table [dbo].[attendance_master]    Script Date: 07/04/2011 16:13:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[attendance_master]') AND type in (N'U'))
DROP TABLE [dbo].[attendance_master]
GO
/****** Object:  Table [dbo].[calander_master]    Script Date: 07/04/2011 16:13:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[calander_master]') AND type in (N'U'))
DROP TABLE [dbo].[calander_master]
GO
/****** Object:  Table [dbo].[holiday_type_master]    Script Date: 07/04/2011 16:13:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[holiday_type_master]') AND type in (N'U'))
DROP TABLE [dbo].[holiday_type_master]
GO
/****** Object:  Table [dbo].[leave_quota_master]    Script Date: 07/04/2011 16:13:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[leave_quota_master]') AND type in (N'U'))
DROP TABLE [dbo].[leave_quota_master]
GO
/****** Object:  Table [dbo].[leave_transaction]    Script Date: 07/04/2011 16:13:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[leave_transaction]') AND type in (N'U'))
DROP TABLE [dbo].[leave_transaction]
GO
/****** Object:  Table [dbo].[leave_transaction]    Script Date: 07/04/2011 16:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[leave_transaction]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[leave_transaction](
	[Emp_no] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Tx_no] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Leave_st_date] [datetime] NOT NULL,
	[Leave_end_dt] [datetime] NOT NULL,
	[Leave_type] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Remarks] [nvarchar](max) COLLATE Latin1_General_CI_AI NULL,
	[Work_flow_ID] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Status] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Ref_tx_id] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[leavedays] [int] NOT NULL,
	[Cratedon] [datetime] NOT NULL,
	[userID] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[ipAddress] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f1] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f2] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f3] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f4] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
 CONSTRAINT [PK_leave_transaction_1] PRIMARY KEY CLUSTERED 
(
	[Emp_no] ASC,
	[Tx_no] ASC,
	[Leave_st_date] ASC,
	[Leave_end_dt] ASC,
	[Leave_type] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[leave_transaction] ([Emp_no], [Tx_no], [Leave_st_date], [Leave_end_dt], [Leave_type], [Remarks], [Work_flow_ID], [Status], [Ref_tx_id], [leavedays], [Cratedon], [userID], [ipAddress], [f1], [f2], [f3], [f4]) VALUES (N'009383', N'0093836/24/2011 12:29:45 PM', CAST(0x00009F0500000000 AS DateTime), CAST(0x00009F0500000000 AS DateTime), N'GH', N'', N'009383', N'New', NULL, 1, CAST(0x00009F0C00CDECCC AS DateTime), N'009383', N'127.0.0.1', NULL, NULL, NULL, NULL)
INSERT [dbo].[leave_transaction] ([Emp_no], [Tx_no], [Leave_st_date], [Leave_end_dt], [Leave_type], [Remarks], [Work_flow_ID], [Status], [Ref_tx_id], [leavedays], [Cratedon], [userID], [ipAddress], [f1], [f2], [f3], [f4]) VALUES (N'119383', N'0093836/11/2011 2:55:05 PM', CAST(0x00009F0300000000 AS DateTime), CAST(0x00009F0600000000 AS DateTime), N'CL', N'ytryt', N'009383', N'Approved', N'0093836/13/2011 11:35:23 AM', 4, CAST(0x00009EFF00F5913C AS DateTime), N'009383', N'127.0.0.1', NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[leave_quota_master]    Script Date: 07/04/2011 16:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[leave_quota_master]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[leave_quota_master](
	[Emp_no] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Sub_type] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Begda] [datetime] NOT NULL,
	[Endda] [datetime] NOT NULL,
	[Seq] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Quota] [float] NOT NULL,
	[Claimed] [float] NULL,
	[Cratedon] [datetime] NULL,
	[userID] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[ipAddress] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f1] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f2] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f3] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f4] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
 CONSTRAINT [PK_leave_quota_master] PRIMARY KEY CLUSTERED 
(
	[Emp_no] ASC,
	[Sub_type] ASC,
	[Begda] ASC,
	[Endda] ASC,
	[Seq] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[leave_quota_master] ([Emp_no], [Sub_type], [Begda], [Endda], [Seq], [Quota], [Claimed], [Cratedon], [userID], [ipAddress], [f1], [f2], [f3], [f4]) VALUES (N'009383', N'CL', CAST(0x00009EB800000000 AS DateTime), CAST(0x0000A02500000000 AS DateTime), N'1', 11, 1, CAST(0x00009EB800000000 AS DateTime), N'008483', N'191.254.186.32', NULL, NULL, NULL, NULL)
INSERT [dbo].[leave_quota_master] ([Emp_no], [Sub_type], [Begda], [Endda], [Seq], [Quota], [Claimed], [Cratedon], [userID], [ipAddress], [f1], [f2], [f3], [f4]) VALUES (N'009383', N'EL_E', CAST(0x00009EB800000000 AS DateTime), CAST(0x0000A02500000000 AS DateTime), N'1', 18, 2, CAST(0x00009EB800000000 AS DateTime), N'008484', N'191.254.186.32', NULL, NULL, NULL, NULL)
INSERT [dbo].[leave_quota_master] ([Emp_no], [Sub_type], [Begda], [Endda], [Seq], [Quota], [Claimed], [Cratedon], [userID], [ipAddress], [f1], [f2], [f3], [f4]) VALUES (N'009383', N'EL_NE', CAST(0x00009EB800000000 AS DateTime), CAST(0x00009EB700000000 AS DateTime), N'1', 14, 0, CAST(0x00009EB800000000 AS DateTime), N'8484', N'191.254.186.231', NULL, NULL, NULL, NULL)
INSERT [dbo].[leave_quota_master] ([Emp_no], [Sub_type], [Begda], [Endda], [Seq], [Quota], [Claimed], [Cratedon], [userID], [ipAddress], [f1], [f2], [f3], [f4]) VALUES (N'009383', N'HPL', CAST(0x00009EB800000000 AS DateTime), CAST(0x00009EB700000000 AS DateTime), N'1', 12, 8, CAST(0x00009EB800000000 AS DateTime), N'8484', N'191.254.186.233', NULL, NULL, NULL, NULL)
INSERT [dbo].[leave_quota_master] ([Emp_no], [Sub_type], [Begda], [Endda], [Seq], [Quota], [Claimed], [Cratedon], [userID], [ipAddress], [f1], [f2], [f3], [f4]) VALUES (N'009383', N'HPL_P', CAST(0x00009EB800000000 AS DateTime), CAST(0x00009EB700000000 AS DateTime), N'1', 30, 0, CAST(0x00009EB800000000 AS DateTime), N'8484', N'191.254.186.236', NULL, NULL, NULL, NULL)
INSERT [dbo].[leave_quota_master] ([Emp_no], [Sub_type], [Begda], [Endda], [Seq], [Quota], [Claimed], [Cratedon], [userID], [ipAddress], [f1], [f2], [f3], [f4]) VALUES (N'009383', N'RH', CAST(0x00009EB800000000 AS DateTime), CAST(0x0000A02500000000 AS DateTime), N'1', 6, 0, CAST(0x00009EB800000000 AS DateTime), N'008483', N'191.254.186.32', NULL, NULL, NULL, NULL)
INSERT [dbo].[leave_quota_master] ([Emp_no], [Sub_type], [Begda], [Endda], [Seq], [Quota], [Claimed], [Cratedon], [userID], [ipAddress], [f1], [f2], [f3], [f4]) VALUES (N'009383', N'SAL', CAST(0x00009EB800000000 AS DateTime), CAST(0x00009EB700000000 AS DateTime), N'1', 5, 5, CAST(0x00009EB800000000 AS DateTime), N'8484', N'191.254.186.237', NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[holiday_type_master]    Script Date: 07/04/2011 16:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[holiday_type_master]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[holiday_type_master](
	[Holi_code] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Holi_Type] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Nature] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Payment] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f1] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f2] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f3] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f4] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
 CONSTRAINT [PK_holiday_type_master] PRIMARY KEY CLUSTERED 
(
	[Holi_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'CL', N'Casual Leave', N'R', N'no', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'CLHD', N'Casual Leave Half Day', N'R', N'no', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'EL_E', N'Earned Leave (Encashable)', N'R', N'yes', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'EL_NE', N'Earned Leave (NonEncashable)', N'R', N'no', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'EOL', N'Extra Ordinary Leave', N'R', N'no', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'GH', N'Govt Holiday', N'NR', N'no', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'HPL', N'Half Pay Leave', N'R', N'no', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'HPL_C', N'Commuted-HPL', N'R', N'no', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'HPL_C_P', N'Commuted-HPL-Prev', N'R', N'no', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'HPL_P', N'HPL Prev Emp', N'R', N'no', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'OD', N'On Duty', N'R', N'no', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'OT', N'On Tour', N'R', N'no', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'OTRWNT', N'On Training Without Tour', N'R', N'no', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'OTRWT', N'On Training With Tour', N'R', N'no', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'RH', N'Restricted Holiday', N'R', N'no', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'SAL', N'Special Additional Leave', N'R', N'yes', NULL, NULL, NULL, NULL)
INSERT [dbo].[holiday_type_master] ([Holi_code], [Holi_Type], [Nature], [Payment], [f1], [f2], [f3], [f4]) VALUES (N'SL', N'Study Leave', N'R', N'no', NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[calander_master]    Script Date: 07/04/2011 16:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[calander_master]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[calander_master](
	[Cal_year] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Per_area] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Holi_code] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Holi_Date] [datetime] NOT NULL,
	[f1] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f2] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f3] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
	[f4] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
 CONSTRAINT [PK_calander_master] PRIMARY KEY CLUSTERED 
(
	[Cal_year] ASC,
	[Per_area] ASC,
	[Holi_code] ASC,
	[Holi_Date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[calander_master] ([Cal_year], [Per_area], [Holi_code], [Holi_Date], [f1], [f2], [f3], [f4]) VALUES (N'2011', N'1002', N'GH', CAST(0x00009F0500000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[calander_master] ([Cal_year], [Per_area], [Holi_code], [Holi_Date], [f1], [f2], [f3], [f4]) VALUES (N'2011', N'1002', N'GH', CAST(0x00009F0700000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[calander_master] ([Cal_year], [Per_area], [Holi_code], [Holi_Date], [f1], [f2], [f3], [f4]) VALUES (N'2011', N'1002', N'GH', CAST(0x00009F4000000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[calander_master] ([Cal_year], [Per_area], [Holi_code], [Holi_Date], [f1], [f2], [f3], [f4]) VALUES (N'2011', N'1002', N'GH', CAST(0x00009F4100000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[calander_master] ([Cal_year], [Per_area], [Holi_code], [Holi_Date], [f1], [f2], [f3], [f4]) VALUES (N'2011', N'1002', N'RH', CAST(0x00009EFC00000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[calander_master] ([Cal_year], [Per_area], [Holi_code], [Holi_Date], [f1], [f2], [f3], [f4]) VALUES (N'2011', N'1002', N'RH', CAST(0x00009F0400000000 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[calander_master] ([Cal_year], [Per_area], [Holi_code], [Holi_Date], [f1], [f2], [f3], [f4]) VALUES (N'2011', N'1002', N'RH', CAST(0x00009F0B00000000 AS DateTime), NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[attendance_master]    Script Date: 07/04/2011 16:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[attendance_master]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[attendance_master](
	[Emp_no] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Intime] [datetime] NOT NULL,
	[Outtime] [datetime] NOT NULL,
	[Duration] [time](7) NULL,
	[Status] [nvarchar](50) COLLATE Latin1_General_CI_AI NULL,
 CONSTRAINT [PK_attendance_master] PRIMARY KEY CLUSTERED 
(
	[Emp_no] ASC,
	[Intime] ASC,
	[Outtime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[attendance_master] ([Emp_no], [Intime], [Outtime], [Duration], [Status]) VALUES (N'009383', CAST(0x00009EE200000000 AS DateTime), CAST(0x00009EE200000000 AS DateTime), CAST(0x07007AA606C90000 AS Time), N'CL')
INSERT [dbo].[attendance_master] ([Emp_no], [Intime], [Outtime], [Duration], [Status]) VALUES (N'009383', CAST(0x00009EE400000000 AS DateTime), CAST(0x00009EE400000000 AS DateTime), CAST(0x07007AA606C90000 AS Time), N'CL')
INSERT [dbo].[attendance_master] ([Emp_no], [Intime], [Outtime], [Duration], [Status]) VALUES (N'009383', CAST(0x00009EEA00000000 AS DateTime), CAST(0x00009EEA00000000 AS DateTime), CAST(0x07007AA606C90000 AS Time), N'OD')
