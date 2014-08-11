CREATE TABLE [dbo].[Appointment] (
    [Id] INT             IDENTITY (1, 1) NOT NULL,
    [SubjectId]     INT             NOT NULL,
    [VisitId]       INT             NOT NULL,
    [SiteId]        INT             NOT NULL,
    [AppUserId]     INT             NOT NULL,
    [Title]         NVARCHAR (200)  NULL,
    [Location]      NVARCHAR (200)  NULL,
    [Description]   NVARCHAR (2000) NULL,
    [StartDate]     DATE        NOT NULL,
	[StartTime]		TIME NULL,
    [EndDate]       DATE        NOT NULL,
	[EndTime]		TIME NULL,
    [VisitStepId]   INT             NOT NULL,
    [Status]        INT             CONSTRAINT [DF__Appointme__Statu__047AA831] DEFAULT ((0)) NOT NULL,
    [CreatedBy]		NVARCHAR (100)  NULL,
    [CreatedOn]     DATETIME        CONSTRAINT [DF__Appointme__Creat__056ECC6A] DEFAULT (GETUTCDATE()) NOT NULL,
    [UpdatedOn]     DATETIME        NULL,
	[UpdatedBy]		NVARCHAR(100) NULL,
	[IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_VisitSchedule] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_Appointment_Visit] FOREIGN KEY ([VisitId]) REFERENCES [dbo].[Visit] ([Id])
);


GO

CREATE INDEX [IX_Appointment_Id] ON [dbo].[Appointment] ([Id],[SubjectId],[VisitId],[SiteId],[AppUserId])
