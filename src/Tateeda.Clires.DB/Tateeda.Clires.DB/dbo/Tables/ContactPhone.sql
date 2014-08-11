CREATE TABLE [dbo].[ContactPhone]
(
	[ContactId] INT NOT NULL , 
    [PhoneId] INT NOT NULL, 
    PRIMARY KEY ([PhoneId], [ContactId]), 
    CONSTRAINT [FK_ContactPhone_Contact] FOREIGN KEY ([ContactId]) REFERENCES [Contact]([Id]), 
    CONSTRAINT [FK_ContactPhone_Phone] FOREIGN KEY ([PhoneId]) REFERENCES [Phone]([Id])
)
