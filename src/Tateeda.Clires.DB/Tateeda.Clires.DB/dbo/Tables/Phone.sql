CREATE TABLE [dbo].[Phone]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CountryCode] NVARCHAR(10) NOT NULL DEFAULT '1', 
    [AreaCode] INT NOT NULL DEFAULT 0, 
    [Number] INT NOT NULL DEFAULT 0,
	[Telephone] nvarchar(50) NULL, 
    [PhoneTypeId] INT NULL,
	[SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Phone_PhoneType] FOREIGN KEY ([PhoneTypeId]) REFERENCES [PhoneType]([Id]), 
)
