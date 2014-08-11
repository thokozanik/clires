CREATE TABLE [dbo].[Drug] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [DrugClassId] INT            NOT NULL,
    [DrugTypeId]  INT            NULL,
	[StudyId] INT NOT NULL,
    [Name]        NVARCHAR (500) NOT NULL,    
    [Directions]  NVARCHAR (500) NULL,
    [Status]      INT            DEFAULT ((1)) NOT NULL,
    [Description] NVARCHAR (500) NULL,	
	[SortOrder]   INT            DEFAULT ((0)) NOT NULL,
	[CreatedOn] DATETIME NULL DEFAULT GETUTCDATE(), 
    [UpdatedOn] DATETIME NULL DEFAULT GETUTCDATE(), 
    [CreatedBy] NVARCHAR(100) NULL, 
    [UpdatedBy] NVARCHAR(100) NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1,
    PRIMARY KEY CLUSTERED ([Id]) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_Drug_DrugClass] FOREIGN KEY ([DrugClassId]) REFERENCES [dbo].[DrugClass] ([Id]),
    UNIQUE NONCLUSTERED ([Name] ASC) WITH (FILLFACTOR = 90), 
    CONSTRAINT [FK_Drug_Study] FOREIGN KEY ([StudyId]) REFERENCES [Study]([Id])
);

