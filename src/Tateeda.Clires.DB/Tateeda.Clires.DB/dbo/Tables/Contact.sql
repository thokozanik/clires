CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [ContactTypeId] INT NOT NULL , 
    [FirstName] NVARCHAR(100) NULL, 
    [MiddleName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(100) NULL,
	[SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Contact_ContactType] FOREIGN KEY ([ContactTypeId]) REFERENCES [ContactType]([Id]), 
)
