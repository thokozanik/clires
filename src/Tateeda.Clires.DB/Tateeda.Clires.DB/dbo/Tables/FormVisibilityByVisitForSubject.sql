CREATE TABLE [dbo].[FormVisibilityByVisitForSubject] (
[Id] INT IDENTITY(1,1) NOT NULL,
    [FormId]           INT NOT NULL,
    [VisitId]          INT NOT NULL,
    [DaysPriorToVisit] INT NOT NULL,
    [DaysAfterVisit]   INT NOT NULL,
	[Description] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_FormVisibilityByVisitForSubject] PRIMARY KEY CLUSTERED ([FormId] ASC, [VisitId] ASC),
    CONSTRAINT [FK_FormVisibilityByVisitForSubject_Form] FOREIGN KEY ([FormId]) REFERENCES [dbo].[Form] ([Id]),
    CONSTRAINT [FK_FormVisibilityByVisitForSubject_Visit] FOREIGN KEY ([VisitId]) REFERENCES [dbo].[Visit] ([Id])
);

