CREATE TABLE [dbo].[Subject] (
    [Id]      INT             IDENTITY (1000, 1) NOT NULL,
    [SiteId]         INT             NOT NULL,
	[ContactId]		 INT		NOT NULL,
	[StudyId]		 INT NOT NULL,
    [Nickname]       NVARCHAR (100)  NULL,
    [FamilyId]       NVARCHAR (100)   NULL,
    [Notes]          NVARCHAR (1000) NULL,
    [NIMHID]         NVARCHAR (100)  NULL,
    [GenderTypeId]         INT        NOT NULL,
    [YearBorn]       INT             NOT NULL,
    [DateOfBirth]    NVARCHAR (50)   NULL,
	[SSN]			 NVARCHAR (40)   NULL,
	[SSNEnc]		 VARBINARY(256)   NULL,
    [FirstNameEnc]   VARBINARY (256) NULL,
    [LastNameEnc]    VARBINARY (256) NULL,
    [DateOfBirthEnc] VARBINARY (256) NULL,
	[Directions] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Subject_Site] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([Id]),
    CONSTRAINT [PK_Subject] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Subject_Contact] FOREIGN KEY ([ContactId]) REFERENCES [Contact]([Id]), 
    CONSTRAINT [FK_Subject_StudyId] FOREIGN KEY ([StudyId]) REFERENCES [Study]([Id]), 
    CONSTRAINT [FK_Subject_Gender] FOREIGN KEY ([GenderTypeId]) REFERENCES [GenderType]([Id])
);


GO

CREATE INDEX [IX_Subject_Id] ON [dbo].[Subject] ([Id], [SiteId], [StudyId])
