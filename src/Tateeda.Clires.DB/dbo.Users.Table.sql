USE [_cliresV4]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [ApplicationId], [UserId], [UserName], [IsAnonymous], [LastActivityDate]) VALUES (3, N'ec8abab6-2445-4d94-827f-9a8535f13fc9', N'6645d10f-83d4-466a-ae62-1724271e9ced', N'dclark', 0, CAST(N'2013-03-08 18:59:45.780' AS DateTime))
INSERT [dbo].[Users] ([Id], [ApplicationId], [UserId], [UserName], [IsAnonymous], [LastActivityDate]) VALUES (2, N'ec8abab6-2445-4d94-827f-9a8535f13fc9', N'476847c1-4fcb-4e08-bbd2-410842bafc51', N'appuser', 0, CAST(N'2014-07-14 02:26:33.187' AS DateTime))
INSERT [dbo].[Users] ([Id], [ApplicationId], [UserId], [UserName], [IsAnonymous], [LastActivityDate]) VALUES (4, N'ec8abab6-2445-4d94-827f-9a8535f13fc9', N'c4d7d9c1-e96f-4bcf-89c4-8f3928abb7eb', N'demo', 0, CAST(N'2014-07-17 01:12:29.477' AS DateTime))
INSERT [dbo].[Users] ([Id], [ApplicationId], [UserId], [UserName], [IsAnonymous], [LastActivityDate]) VALUES (1, N'ec8abab6-2445-4d94-827f-9a8535f13fc9', N'82d9823a-0bfa-4fff-97bf-d54d3a222cd5', N'admin', 0, CAST(N'2014-06-11 13:08:33.380' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
