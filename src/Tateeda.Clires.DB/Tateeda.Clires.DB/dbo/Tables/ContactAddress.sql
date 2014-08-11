CREATE TABLE [dbo].[ContactAddress]
(
	[ContactId] INT NOT NULL , 
    [AddressId] INT NOT NULL, 
    PRIMARY KEY ([ContactId], [AddressId]), 
    CONSTRAINT [FK_ContactAddress_Contact] FOREIGN KEY ([ContactId]) REFERENCES [Contact]([Id]), 
    CONSTRAINT [FK_ContactAddress_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id])
)
