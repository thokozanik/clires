﻿CREATE TABLE [dbo].[VisitType]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT 1
)