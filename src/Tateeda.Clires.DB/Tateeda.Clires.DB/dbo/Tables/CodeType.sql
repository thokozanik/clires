CREATE TABLE [dbo].[CodeType] (
    [Id]  INT            NOT NULL,
    [Name]        NVARCHAR (64)  NOT NULL,
    [Description] NVARCHAR (500) NULL,
	[SortOrder]   INT            DEFAULT ((0)) NOT NULL,
	[CreatedOn] DATETIME NULL DEFAULT GETUTCDATE(), 
    [UpdatedOn] DATETIME NULL DEFAULT GETUTCDATE(), 
    [CreatedBy] NVARCHAR(100) NULL, 
    [UpdatedBy] NVARCHAR(100) NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1,
    PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90),
    UNIQUE NONCLUSTERED ([Name] ASC) WITH (FILLFACTOR = 90)
);


GO

CREATE INDEX [IX_CodeType_Id] ON [dbo].[CodeType] ([Id],[Name])
