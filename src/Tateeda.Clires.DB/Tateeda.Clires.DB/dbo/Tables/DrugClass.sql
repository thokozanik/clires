CREATE TABLE [dbo].[DrugClass] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [DrugCategoryId] INT            NOT NULL,
    [Name]           NVARCHAR (64)  NULL,    
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
    CONSTRAINT [FK_DrugClass_DrugCategory] FOREIGN KEY ([DrugCategoryId]) REFERENCES [dbo].[DrugCategory] ([Id])
);

