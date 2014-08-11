USE [_cliresV4]
GO
SET IDENTITY_INSERT [dbo].[Study] ON 

INSERT [dbo].[Study] ([Id], [Name], [Description], [StartDate], [EndDate], [Target], [Goal], [Budget], [SortOrder], [Status], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'Initial Study', N'Please change this study to your specification', CAST(N'2013-10-12 00:00:00.000' AS DateTime), CAST(N'2014-11-06 00:00:00.000' AS DateTime), N'Study targets information', N'Study goals', 10000000.0000, 0, 1, CAST(N'2013-02-19 05:32:16.313' AS DateTime), CAST(N'2013-10-14 05:31:39.523' AS DateTime), N'SYSTEM', N'admin', 1)
SET IDENTITY_INSERT [dbo].[Study] OFF
