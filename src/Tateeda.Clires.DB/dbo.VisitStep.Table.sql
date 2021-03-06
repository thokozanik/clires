
SET IDENTITY_INSERT [dbo].[VisitStep] ON 

INSERT [dbo].[VisitStep] ([Id], [Name], [ArmId], [Directions], [SortOrder], [Status], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'Pre-Screening', 1, N'Pre screening process', 0, 1, CAST(N'2013-02-19 06:48:51.640' AS DateTime), NULL, N'admin', NULL, 1)
INSERT [dbo].[VisitStep] ([Id], [Name], [ArmId], [Directions], [SortOrder], [Status], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (2, N'Main Study', 1, N'Phase I visits', 0, 1, CAST(N'2013-02-19 06:49:15.353' AS DateTime), NULL, N'admin', NULL, 1)
INSERT [dbo].[VisitStep] ([Id], [Name], [ArmId], [Directions], [SortOrder], [Status], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (3, N'Final Steps', 1, N'', 0, 1, CAST(N'2013-04-19 03:57:50.530' AS DateTime), NULL, N'admin', NULL, 1)
SET IDENTITY_INSERT [dbo].[VisitStep] OFF
