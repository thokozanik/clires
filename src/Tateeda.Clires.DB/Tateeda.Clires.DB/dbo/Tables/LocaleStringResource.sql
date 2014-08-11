CREATE TABLE [dbo].[LocaleStringResource] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [LanguageId]    INT             DEFAULT ((1)) NOT NULL,
    [ResourceName]  NVARCHAR (200)  NOT NULL,
    [ResourceValue] NVARCHAR (1000) NOT NULL,
    [Description] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LocaleStringResource_Language] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language] ([Id])
);

