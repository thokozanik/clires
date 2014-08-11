CREATE TABLE [dbo].[ScheduleSubjectVisit] (
    [SubjectId] INT NOT NULL,
    [VisitId]   INT NOT NULL,
    CONSTRAINT [PK_ScheduleSubjectVisit] PRIMARY KEY CLUSTERED ([SubjectId] ASC, [VisitId] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_ScheduleSubjectVisit_Visit] FOREIGN KEY ([VisitId]) REFERENCES [dbo].[Visit] ([Id])
);

