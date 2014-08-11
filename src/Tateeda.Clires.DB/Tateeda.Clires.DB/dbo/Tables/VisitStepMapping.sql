CREATE TABLE [dbo].[VisitStepMapping] (
    [VisitStepId] INT NOT NULL,
    [VisitId]     INT NOT NULL,
    CONSTRAINT [PK_VisitStepMapping] PRIMARY KEY CLUSTERED ([VisitStepId] ASC, [VisitId] ASC),
    CONSTRAINT [FK_VisitStepMapping_Visit] FOREIGN KEY ([VisitId]) REFERENCES [dbo].[Visit] ([Id]),
    CONSTRAINT [FK_VisitStepMapping_VisitStep] FOREIGN KEY ([VisitStepId]) REFERENCES [dbo].[VisitStep] ([Id])
);

