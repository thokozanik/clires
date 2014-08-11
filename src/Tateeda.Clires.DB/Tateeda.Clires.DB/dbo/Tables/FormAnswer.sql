CREATE TABLE [dbo].[FormAnswer] (
[Id] INT IDENTITY(1,1) NOT NULL,
    [AppointmentFormId] INT            NOT NULL,
    [AnswerId]          INT            NOT NULL,
    [QuestionId]        INT            NOT NULL,
    [FreeTextAnswer]    NVARCHAR (MAX) NULL,
    [Notes]             NVARCHAR (MAX) NULL,
    [CreatedOn]         DATETIME       DEFAULT (GETUTCDATE()) NOT NULL,
    [UpdatedOn]         DATETIME       DEFAULT (GETUTCDATE()) NULL,
	[CreatedBy]			NVARCHAR(100)  NOT NULL,
	[UpdatedBy]			NVARCHAR(100)  NULL,
    CONSTRAINT [PK_FormAnswer] PRIMARY KEY CLUSTERED ([AppointmentFormId] ASC, [AnswerId] ASC, [QuestionId] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_FormAnswer_AppointmentForm] FOREIGN KEY ([AppointmentFormId]) REFERENCES [dbo].[AppointmentForm] ([Id])
);


GO

CREATE INDEX [IX_FormAnswer_Id] ON [dbo].[FormAnswer] ([Id],[AppointmentFormId],[AnswerId],[QuestionId])
