CREATE TABLE [dbo].[Question] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [FormId]           INT             NOT NULL,
    [FieldDataTypeId]  INT             NOT NULL,
    [QuestionText]     NVARCHAR (MAX)  NOT NULL,
    [Code]             NVARCHAR (32)   NULL,
    [Directions]       NVARCHAR (1000) NULL,    
    [Header]           NVARCHAR (1000) NULL,
    [Trailer]          NVARCHAR (1000) NULL,    
    [IsRequired]       BIT             DEFAULT ((0)) NOT NULL,    
    [ParentQuestionId] INT             NULL,
	[IsParent]		   BIT DEFAULT(0) NOT NULL,
	[ValidationRule]   NVARCHAR(MAX) NULL,
	[Description] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_Question_Form] FOREIGN KEY ([FormId]) REFERENCES [dbo].[Form] ([Id]), 
    CONSTRAINT [FK_Question_FieldDataType] FOREIGN KEY (FieldDataTypeId) REFERENCES [CssType]([Id])
);


GO

CREATE INDEX [IX_Question_Id] ON [dbo].[Question] ([Id], [FormId], [FieldDataTypeId])
