CREATE TABLE [dbo].[AppointmentForm] (
    [Id] INT            IDENTITY (1, 1) NOT NULL,
    [FormId]            INT            NOT NULL,
    [AppointmentId]     INT            NOT NULL,
	[FormStatusTypeId]  INT			   NOT NULL,
    [Notes]             NVARCHAR (MAX) NULL,
    [Comments]          NVARCHAR (MAX) NULL,
    [TotalScore]        INT            DEFAULT ((0)) NOT NULL,
    [Status]            INT            NOT NULL,
    [UpdatedOn]         DATETIME       NULL DEFAULT GETUTCDATE(),
    [SortOrder]         INT            NOT NULL DEFAULT 0,
    [CreatedOn]         DATETIME       NULL DEFAULT GETUTCDATE(),
    [CreatedBy]         NVARCHAR (100) NULL,
    [UpdatedBy]         NVARCHAR (100) NULL,
	[IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Score] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_AppointmentForm_Appointment] FOREIGN KEY ([AppointmentId]) REFERENCES [dbo].[Appointment] ([Id]),
    CONSTRAINT [FK_AppointmentForm_Form] FOREIGN KEY ([FormId]) REFERENCES [dbo].[Form] ([Id]), 
    CONSTRAINT [FK_AppointmentForm_FormStatusType] FOREIGN KEY ([FormStatusTypeId]) REFERENCES [AppointmentFormStatusType]([Id])
);


GO

CREATE INDEX [IX_AppointmentForm_ID] ON [dbo].[AppointmentForm] ([Id],[FormId],[AppointmentId])
