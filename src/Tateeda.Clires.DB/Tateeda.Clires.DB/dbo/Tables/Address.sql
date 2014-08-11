CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[AddressTypeId] INT NOT NULL,
    [Street] NVARCHAR(250) NULL, 
    [City] NVARCHAR(100) NULL, 
	[PostalCode] NVARCHAR(50) NULL,
    [StateId] INT NULL, 
    [CountryId] INT NULL,
	[SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Address_AddressType] FOREIGN KEY ([AddressTypeId]) REFERENCES [AddressType]([Id]), 
)
