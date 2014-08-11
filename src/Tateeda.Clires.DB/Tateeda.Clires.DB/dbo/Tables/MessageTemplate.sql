CREATE TABLE [dbo].[MessageTemplate] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (200)  NOT NULL,
    [BccEmailAddresses] NVARCHAR (200)  NULL,
    [Subject]           NVARCHAR (1000) NULL,
    [Body]              NVARCHAR (MAX)  NULL,    
    [LanguageId]        INT             DEFAULT ((1)) NOT NULL,
    [MessageProviderId] INT             DEFAULT ((1)) NOT NULL,
	[Description] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_MessageTemplate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MessageTemplate_Language] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language] ([Id]),
    CONSTRAINT [FK_MessageTemplate_MessageProvider] FOREIGN KEY ([MessageProviderId]) REFERENCES [dbo].[MessageProvider] ([Id])
);

