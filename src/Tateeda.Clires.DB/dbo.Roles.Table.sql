USE [_cliresV4]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [ApplicationId], [RoleId], [RoleName], [Description]) VALUES (1, N'ec8abab6-2445-4d94-827f-9a8535f13fc9', N'8d77a6e3-912f-47a7-bcb9-09edf0afc8df', N'Site Admin', N'Site Admin')
INSERT [dbo].[Roles] ([Id], [ApplicationId], [RoleId], [RoleName], [Description]) VALUES (2, N'ec8abab6-2445-4d94-827f-9a8535f13fc9', N'41cc545b-d0b5-4b32-9dab-71dd6d2b0bc2', N'Guest', N'Guest')
INSERT [dbo].[Roles] ([Id], [ApplicationId], [RoleId], [RoleName], [Description]) VALUES (3, N'ec8abab6-2445-4d94-827f-9a8535f13fc9', N'3ab436a7-a29b-426c-b945-8ffeaede229f', N'Subject', N'Site Subject')
INSERT [dbo].[Roles] ([Id], [ApplicationId], [RoleId], [RoleName], [Description]) VALUES (4, N'ec8abab6-2445-4d94-827f-9a8535f13fc9', N'967f2d1b-5de4-4d49-9292-a89ffdf266f9', N'Sys Admin', N'App Sys Admin')
INSERT [dbo].[Roles] ([Id], [ApplicationId], [RoleId], [RoleName], [Description]) VALUES (5, N'ec8abab6-2445-4d94-827f-9a8535f13fc9', N'522ce0c4-8147-4fc3-bee4-a8a4ce6edd9d', N'App User', N'Site App User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
