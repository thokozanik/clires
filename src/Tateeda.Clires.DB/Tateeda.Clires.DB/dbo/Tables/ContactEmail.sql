CREATE TABLE [dbo].[ContactEmail]
(
	[ContactId] INT NOT NULL , 
    [EmailId] INT NOT NULL, 
    PRIMARY KEY ([EmailId], [ContactId]), 
    CONSTRAINT [FK_ContactEmail_Contact] FOREIGN KEY ([ContactId]) REFERENCES [Contact]([Id]), 
    CONSTRAINT [FK_ContactEmail_Email] FOREIGN KEY ([EmailId]) REFERENCES [Email]([Id])
)
