CREATE TABLE [dbo].[StudySite]
(
	[StudyId] INT NOT NULL , 
    [SiteId] INT NOT NULL, 
    PRIMARY KEY ([SiteId], [StudyId]), 
    CONSTRAINT [FK_StudySite_Study] FOREIGN KEY ([StudyId]) REFERENCES [Study]([Id]), 
    CONSTRAINT [FK_StudySite_Site] FOREIGN KEY ([SiteId]) REFERENCES [Site]([Id])
)

GO

CREATE INDEX [IX_StudySite_ID] ON [dbo].[StudySite] ([StudyId],[SiteId])
