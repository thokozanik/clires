USE [_cliresV4]
GO
SET IDENTITY_INSERT [dbo].[Arm] ON 

INSERT [dbo].[Arm] ([Id], [StudyId], [Code], [Name], [Description], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, 1, N'A', N'Phase I', N'Phase I Arm', CAST(N'2013-02-19 05:32:16.487' AS DateTime), CAST(N'2013-02-19 05:32:16.487' AS DateTime), N'Admin', N'Admin', 1)
SET IDENTITY_INSERT [dbo].[Arm] OFF
