GO
SET IDENTITY_INSERT [dbo].[Site] ON 

INSERT [dbo].[Site] ([Id], [Name], [Code], [TimeZoneId], [IsPrimary], [Directions], [SortOrder], [Status], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'UCSD', N'UCSD', 11, 1, N'Main site', 0, 1, CAST(N'2013-02-19 06:48:04.480' AS DateTime), CAST(N'2013-02-19 06:48:04.480' AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[Site] ([Id], [Name], [Code], [TimeZoneId], [IsPrimary], [Directions], [SortOrder], [Status], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (2, N'NYU', N'NYU', 8, 0, NULL, 0, 1, CAST(N'2013-03-08 18:58:17.577' AS DateTime), CAST(N'2013-03-08 18:58:17.577' AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[Site] ([Id], [Name], [Code], [TimeZoneId], [IsPrimary], [Directions], [SortOrder], [Status], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (3, N'Demo', N'D', 11, 0, NULL, 0, 1, CAST(N'2013-10-14 05:27:24.387' AS DateTime), CAST(N'2013-10-14 05:27:24.387' AS DateTime), N'admin', N'admin', 1)
SET IDENTITY_INSERT [dbo].[Site] OFF
