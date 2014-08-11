CREATE TABLE [dbo].[StudySetupMap]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [OrganizationId] INT NULL, 
    [StudyId] INT NULL, 
    [StudySetupStepId] INT NULL, 
    [StepSetupStatus] INT NULL, 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [UpdatedBy] NVARCHAR(50) NULL, 
    [CreatedOn] DATETIME NOT NULL DEFAULT getdate(), 
    [UpdatedOn] DATETIME NULL DEFAULT getdate(), 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_StudySetupMap_StudySetupSteps] FOREIGN KEY ([StudySetupStepId]) REFERENCES [StudySetupSteps]([Id])
)
