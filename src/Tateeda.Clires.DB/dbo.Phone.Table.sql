USE [_cliresV4]
GO
SET IDENTITY_INSERT [dbo].[Phone] ON 

INSERT [dbo].[Phone] ([Id], [CountryCode], [AreaCode], [Number], [Telephone], [PhoneTypeId], [SortOrder], [Status], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'1', 0, 0, NULL, 4, 0, 1, CAST(N'2013-02-19 06:50:48.983' AS DateTime), NULL, N'admin', NULL, 1)
INSERT [dbo].[Phone] ([Id], [CountryCode], [AreaCode], [Number], [Telephone], [PhoneTypeId], [SortOrder], [Status], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (2, N'1', 0, 0, NULL, 4, 0, 1, CAST(N'2013-03-08 18:59:45.687' AS DateTime), NULL, N'admin', NULL, 1)
INSERT [dbo].[Phone] ([Id], [CountryCode], [AreaCode], [Number], [Telephone], [PhoneTypeId], [SortOrder], [Status], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (3, N'1', 0, 0, NULL, 4, 0, 1, CAST(N'2013-10-28 02:58:11.117' AS DateTime), NULL, N'admin', NULL, 1)
SET IDENTITY_INSERT [dbo].[Phone] OFF
