CREATE TABLE [dbo].[CTGovSubmission] (
    [Id] INT            IDENTITY (1, 1) NOT NULL,
    [Title]             NVARCHAR (250) NOT NULL,
    [SubmissionXML]     XML            NULL,
    [Description] NVARCHAR (500) NULL,	
	[SortOrder]   INT            DEFAULT ((0)) NOT NULL,
	[CreatedOn] DATETIME NULL DEFAULT GETUTCDATE(), 
    [UpdatedOn] DATETIME NULL DEFAULT GETUTCDATE(), 
    [CreatedBy] NVARCHAR(100) NULL, 
    [UpdatedBy] NVARCHAR(100) NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_CTGovSubmission] PRIMARY KEY CLUSTERED ([Id] ASC)
);

