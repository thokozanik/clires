CREATE TABLE [dbo].[Language] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (100) NOT NULL,
    [LanguageCulture]   NVARCHAR (20)  NOT NULL,
    [UniqueSeoCode]     NVARCHAR (2)   NULL,
    [FlagImageFileName] NVARCHAR (50)  NULL,
    [Published]         BIT            NOT NULL,
    [Description] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

