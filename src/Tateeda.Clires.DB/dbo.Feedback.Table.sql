USE [_cliresV4]
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([Id], [Uri], [Comment], [LikeScore], [CreatedOn], [CreatedBy]) VALUES (1, N'/Dashboard/Tasks/LeaveFeedback', N'test', -1, CAST(N'2013-04-15 02:52:06.787' AS DateTime), N'admin')
INSERT [dbo].[Feedback] ([Id], [Uri], [Comment], [LikeScore], [CreatedOn], [CreatedBy]) VALUES (2, N'/Subject/Info/LeaveFeedback', N'test', 7, CAST(N'2013-10-11 18:46:29.557' AS DateTime), N'appuser')
SET IDENTITY_INSERT [dbo].[Feedback] OFF
