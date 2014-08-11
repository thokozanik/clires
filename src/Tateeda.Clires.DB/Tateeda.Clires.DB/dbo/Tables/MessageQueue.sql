CREATE TABLE [dbo].[MessageQueue] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [TemplateId]      INT            NOT NULL,
    [PriorityId]      INT            NOT NULL,
    [Data]            NVARCHAR (MAX) NULL,
    [RecipientId]     INT            NOT NULL,
    [SenderId]        INT            NOT NULL,
    [StatusId]        INT            NOT NULL,
    [QueuedOn]        DATETIME       DEFAULT (GETUTCDATE()) NOT NULL,
    [LastProcessedOn] DATETIME       NULL,
    [TriesCount]      INT            DEFAULT ((0)) NOT NULL,
    [Description] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_MessageQueue] PRIMARY KEY CLUSTERED ([Id] ASC),   
    CONSTRAINT [FK_MessageQueue_Template] FOREIGN KEY ([TemplateId]) REFERENCES [dbo].[MessageTemplate] ([Id])
);

