CREATE TABLE [dbo].[Code] (
    [Id]      INT             NOT NULL,
    [CodeTypeId]  INT            NOT NULL,
    [EnumId]      INT            NOT NULL,    
    [Name]        NVARCHAR (64)  NOT NULL,
    [Description] NVARCHAR (500) NULL,	
	[SortOrder]   INT            DEFAULT ((0)) NOT NULL,
	[CreatedOn] DATETIME NULL DEFAULT GETUTCDATE(), 
    [UpdatedOn] DATETIME NULL DEFAULT GETUTCDATE(), 
    [CreatedBy] NVARCHAR(100) NULL, 
    [UpdatedBy] NVARCHAR(100) NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    PRIMARY KEY CLUSTERED ([Id]) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_Code_CodeType] FOREIGN KEY ([CodeTypeId]) REFERENCES [dbo].[CodeType] (Id)
);


GO

CREATE INDEX [IX_Code_TypeId] ON [dbo].[Code] ([CodeTypeId])
