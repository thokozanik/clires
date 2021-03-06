USE [_cliresV4]
GO
SET IDENTITY_INSERT [dbo].[DrugCategory] ON 

INSERT [dbo].[DrugCategory] ([Id], [Name], [Code], [Directions], [Description], [SortOrder], [Status], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'Psychotropic', N'Psycho', N'', N'Psychotropic Prescription Drugs', 1, 1, CAST(N'2011-02-14 23:45:24.877' AS DateTime), CAST(N'2011-02-14 23:45:24.877' AS DateTime), N'SYSTEM', NULL, 1)
INSERT [dbo].[DrugCategory] ([Id], [Name], [Code], [Directions], [Description], [SortOrder], [Status], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (2, N'Non Psychotropic', N'NonPsycho', N'', N'Non Psychotropic Prescription Drugs', 2, 1, CAST(N'2011-02-14 23:45:24.890' AS DateTime), CAST(N'2011-02-14 23:45:24.890' AS DateTime), N'SYSTEM', NULL, 1)
INSERT [dbo].[DrugCategory] ([Id], [Name], [Code], [Directions], [Description], [SortOrder], [Status], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (3, N'Over Counter', N'OCT', N'', N'Over Counter Drugs', 3, 1, CAST(N'2011-02-14 23:45:24.890' AS DateTime), CAST(N'2011-02-14 23:45:24.890' AS DateTime), N'SYSTEM', NULL, 1)
INSERT [dbo].[DrugCategory] ([Id], [Name], [Code], [Directions], [Description], [SortOrder], [Status], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (4, N'Other', N'Other', N'', N'All Other Drugs', 4, 1, CAST(N'2011-02-14 23:45:24.907' AS DateTime), CAST(N'2011-02-14 23:45:24.907' AS DateTime), N'SYSTEM', NULL, 1)
SET IDENTITY_INSERT [dbo].[DrugCategory] OFF
