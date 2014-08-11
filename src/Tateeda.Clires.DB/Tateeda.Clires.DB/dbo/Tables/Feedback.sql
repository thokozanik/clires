CREATE TABLE [dbo].[Feedback]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Uri] nvarchar(500) NOT NULL,
	[Comment] nvarchar(max) not null,
	[LikeScore] int NOT null default 0,
	[CreatedOn] DATETIME DEFAULT (GETUTCDATE()) NOT NULL, 
    [CreatedBy] NVARCHAR(100) NULL
)
