CREATE TABLE [dbo].[StudySetupSteps]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	[OrganizationId] int NULL,
    [Name] NVARCHAR(50) NOT NULL, 
    [ContextUrl] NVARCHAR(MAX) NULL, 
	[SortOrder] int NULL DEFAULT 0,
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [UpdatedBy] NVARCHAR(50) NULL, 
    [CreatedOn] NCHAR(10) NOT NULL DEFAULT getdate(), 
    [UpdatedOn] DATETIME NULL DEFAULT getdate(), 
    [IsActive] BIT NULL DEFAULT 1

)
