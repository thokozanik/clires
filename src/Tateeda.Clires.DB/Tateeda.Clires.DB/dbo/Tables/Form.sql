CREATE TABLE [dbo].[Form] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
	[StudyId]		INT					NOT NULL,
    [Name]              NVARCHAR (64)   NOT NULL,
    [Code]              NVARCHAR (32)   NULL,
    [FormTypeId]          INT             DEFAULT ((0)) NOT NULL,
    [Title]             NVARCHAR (500)  NULL,
    [Directions]        NVARCHAR (1000) NULL,
    [Header]            NVARCHAR (1000) NULL,
    [Trailer]           NVARCHAR (1000) NULL,
    [IsFilledBySubject] BIT             DEFAULT ((0)) NOT NULL,
    [ShowTotalScore]    BIT             DEFAULT ((0)) NOT NULL,
    [LayoutTypeId]        INT             NOT NULL,    
    [IsDoubleChecked]     BIT             CONSTRAINT [DF_Form_DoubleChecked] DEFAULT ((0)) NULL,
	[Description] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [NotifyOnChange] BIT NOT NULL DEFAULT 0, 
    [NotifyOnCompletion] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Form] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [UX_Form_Name] UNIQUE NONCLUSTERED ([Name] ASC) WITH (FILLFACTOR = 90), 
    CONSTRAINT [FK_Form_Study] FOREIGN KEY ([StudyId]) REFERENCES [Study]([Id])
);


GO

CREATE INDEX [IX_Form_Id] ON [dbo].[Form] ([Id], [Name], [FormTypeId])
