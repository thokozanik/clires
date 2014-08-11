CREATE TABLE [dbo].[Country]
(
	[Id] INT NOT NULL PRIMARY KEY,     
    [Abbr] NVARCHAR(80) NULL, 
	[Name] NVARCHAR(250) NOT NULL, 
	[Iso3] CHAR(3) NULL,
    [FlagImgUrl] NVARCHAR(MAX) NULL,
	[SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1
)

GO

CREATE INDEX [IX_Country_Name] ON [dbo].[Country] ([Name])
