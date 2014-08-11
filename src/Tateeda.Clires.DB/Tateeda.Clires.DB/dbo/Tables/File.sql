﻿CREATE TABLE [dbo].[File]
(
	[Id] INT NOT NULL, 
	[FileGuid] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(500) NOT NULL, 
    [FileType] NVARCHAR(100) NOT NULL, 
    [FielContent] VARBINARY(MAX) NOT NULL, 
    [CreatedBy] NVARCHAR(100) NOT NULL, 
    [CreatedOn] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [CK_File_Column] UNIQUE (Id)
)