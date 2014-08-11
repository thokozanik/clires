USE [_cliresV4]
GO
SET IDENTITY_INSERT [dbo].[AppUser] ON 

INSERT [dbo].[AppUser] ([Id], [MembershipUserId], [SiteId], [RoleId], [ContactId], [Title], [SortOrder], [Comments], [Status], [UpdatedOn], [CreatedOn], [UpdatedBy], [CreatedBy], [IsActive]) VALUES (1, N'476847c1-4fcb-4e08-bbd2-410842bafc51', 1, N'522ce0c4-8147-4fc3-bee4-a8a4ce6edd9d', 1, N'Application User', 0, NULL, 1, CAST(N'2013-03-01 20:03:03.430' AS DateTime), NULL, N'admin', NULL, 1)
INSERT [dbo].[AppUser] ([Id], [MembershipUserId], [SiteId], [RoleId], [ContactId], [Title], [SortOrder], [Comments], [Status], [UpdatedOn], [CreatedOn], [UpdatedBy], [CreatedBy], [IsActive]) VALUES (2, N'6645d10f-83d4-466a-ae62-1724271e9ced', 2, N'8d77a6e3-912f-47a7-bcb9-09edf0afc8df', 4, N'DR', 0, NULL, 1, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[AppUser] ([Id], [MembershipUserId], [SiteId], [RoleId], [ContactId], [Title], [SortOrder], [Comments], [Status], [UpdatedOn], [CreatedOn], [UpdatedBy], [CreatedBy], [IsActive]) VALUES (3, N'c4d7d9c1-e96f-4bcf-89c4-8f3928abb7eb', 3, N'967f2d1b-5de4-4d49-9292-a89ffdf266f9', 9, N'Demo User', 0, NULL, 1, NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[AppUser] OFF
