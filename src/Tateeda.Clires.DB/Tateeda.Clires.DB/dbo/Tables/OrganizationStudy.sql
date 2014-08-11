CREATE TABLE [dbo].[OrganizationStudy]
(
	[OrganizationId] INT NOT NULL ,
	[StudyId] INT NOT NULL , 
    CONSTRAINT [FK_OrganizationStudy_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [Organization]([Id]), 
    CONSTRAINT [FK_OrganizationStudy_Study] FOREIGN KEY ([StudyId]) REFERENCES [Study]([Id]), 
    CONSTRAINT [PK_OrganizationStudy] PRIMARY KEY ([OrganizationId], [StudyId])
)
