CREATE TABLE [dbo].[Study]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR (100)  NULL,
	[Description] NVARCHAR (500)  NULL,
	[StartDate]  DATETIME        NOT NULL DEFAULT GETUTCDATE(),
	[EndDate]  DATETIME          NULL,
	[Target] NVARCHAR(MAX)		 NULL,
	[Goal] NVARCHAR(MAX)	     NULL,
	[Budget] MONEY null,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME        NOT NULL DEFAULT GETUTCDATE(),
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
)
