CREATE TABLE [dbo].[Answer] (
    [Id]   INT             IDENTITY (1, 1) NOT NULL,
    [QuestionId] INT             NOT NULL,
    [OptionText] NVARCHAR (1000) NOT NULL,
    [Code]       NVARCHAR (32)   NULL,
    [Score]      INT             NULL,
    [Header]     NVARCHAR (200)  NULL,
    [Trailer]    NVARCHAR (200)  NULL,
    [Directions] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Answer_Question] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id]), 
    CONSTRAINT [PK_Answer] PRIMARY KEY ([Id])
);


GO

CREATE INDEX [IX_Answer_Id] ON [dbo].[Answer] ([Id],[QuestionId])
