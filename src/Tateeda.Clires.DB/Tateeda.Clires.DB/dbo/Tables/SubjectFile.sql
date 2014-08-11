CREATE TABLE [dbo].[SubjectFile]
(
	[SubjectId] INT NOT NULL , 
    [FileGuid] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_SubjectFile_Subject] FOREIGN KEY ([SubjectId]) REFERENCES [Subject]([Id]), 
    CONSTRAINT [FK_SubjectFile_File] FOREIGN KEY ([FileGuid]) REFERENCES [File]([FileGuid]), 
    PRIMARY KEY ([FileGuid], [SubjectId])
)
