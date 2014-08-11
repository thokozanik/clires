CREATE TABLE [dbo].[UserSettings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [AppUserId] INT NOT NULL, 
    [SettingName] NVARCHAR(255) NOT NULL, 
    [SettingValue] NVARCHAR(MAX) NOT NULL, 
	[CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_UserSettings_AppUser] FOREIGN KEY ([AppUserId]) REFERENCES [AppUser]([Id])
)
