﻿CREATE TABLE [dbo].[FormType]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(50),
	[IsActive] BIT DEFAULT(1) NOT NULL
)