CREATE TABLE [dbo].[VisitStepVisitSequence] (
    [VisitStepId]  INT NOT NULL,
    [VisitId]      INT NOT NULL,
    [DaysFromBase] INT CONSTRAINT [DF_VisitStepVisitSequence_DaysFromBase] DEFAULT ((0)) NOT NULL,
    [IsActive]     BIT CONSTRAINT [DF_VisitStepVisitSequence_IsActive] DEFAULT ((1)) NOT NULL,
    [Deviation] INT NOT NULL DEFAULT 0, 
    [SortOrder] INT NOT NULL DEFAULT 0, 
    [IsTermination] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_VisitStepVisitSequence] PRIMARY KEY CLUSTERED ([VisitStepId] ASC, [VisitId] ASC),
    CONSTRAINT [FK_VisitStepVisitSequence_Visit] FOREIGN KEY ([VisitId]) REFERENCES [dbo].[Visit] ([Id]),
    CONSTRAINT [FK_VisitStepVisitSequence_VisitStep] FOREIGN KEY ([VisitStepId]) REFERENCES [dbo].[VisitStep] ([Id])
);

