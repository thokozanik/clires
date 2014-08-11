CREATE TABLE [dbo].[FormInProcess]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [FormId] INT NOT NULL, 
    [SubjectId] INT NOT NULL, 
    [AppUserId] INT NOT NULL, 
    [IsLocked] BIT NOT NULL DEFAULT 0, 
    [OpenendOn] DATETIME NOT NULL DEFAULT getdate(), 
    [ReleasedOn] DATETIME NULL DEFAULT getdate(), 
    [MaxLockTimeMin] INT NOT NULL DEFAULT 30, 
    [UnlockedByAppUserId] INT NOT NULL
)
