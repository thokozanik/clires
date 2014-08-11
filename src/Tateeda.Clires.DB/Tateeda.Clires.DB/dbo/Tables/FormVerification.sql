CREATE TABLE [dbo].[FormVerification]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[FormId] INT NOT NULL,
    [VerifiedBy] NVARCHAR(100) NULL, 
    [VerifiedOn] DATETIME NULL, 
    [ResultStatus] INT NULL, 
    [CreatedBy] NVARCHAR(100) NOT NULL, 
    [CreatedOn] DATETIME NOT NULL DEFAULT GETUTCDATE(), 
    CONSTRAINT [FK_FormVerificationRequest_Form] FOREIGN KEY ([FormId]) REFERENCES [Form]([Id])
)
