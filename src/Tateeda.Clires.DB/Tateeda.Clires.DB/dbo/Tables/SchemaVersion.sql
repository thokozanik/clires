CREATE TABLE [dbo].[SchemaVersion] (
    [DbVersion] NVARCHAR (100) NULL,
    [CreatedOn] DATETIME       DEFAULT (GETUTCDATE()) NOT NULL,
    [UpdatedOn] DATETIME       NULL
);

