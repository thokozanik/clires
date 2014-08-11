CREATE TABLE [dbo].[DrugCategory] (
    [Id] INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (64)  NOT NULL,    
    [Code]           NVARCHAR (32)  NULL,
    [Directions]     NVARCHAR (500) NULL,
    [Description] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90),
    UNIQUE NONCLUSTERED ([Name] ASC) WITH (FILLFACTOR = 90)
);

