CREATE TABLE [dbo].[VisitForms] (
    [VisitId]   INT NOT NULL,
    [FormId]    INT NOT NULL,
    [SortOrder] INT NULL DEFAULT 0, 
    CONSTRAINT [PK_VisitForms] PRIMARY KEY CLUSTERED ([VisitId] ASC, [FormId] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_VisitForms_Form] FOREIGN KEY ([FormId]) REFERENCES [dbo].[Form] ([Id]),
    CONSTRAINT [RefVisit26] FOREIGN KEY ([VisitId]) REFERENCES [dbo].[Visit] ([Id])
);


GO

CREATE NONCLUSTERED INDEX [IX_VisitForms_Id] ON [dbo].[VisitForms] ([VisitId], [FormId] )  INCLUDE ([SortOrder])
