CREATE TABLE [dbo].[StudyFile]
(
	[StudyId] INT NOT NULL , 
    [FileGuid] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_StudyFile_Study] FOREIGN KEY ([StudyId]) REFERENCES [Study]([Id]), 
    CONSTRAINT [FK_StudyFile_File] FOREIGN KEY ([FileGuid]) REFERENCES [File]([FileGuid]), 
    PRIMARY KEY ([StudyId], [FileGuid])
)
