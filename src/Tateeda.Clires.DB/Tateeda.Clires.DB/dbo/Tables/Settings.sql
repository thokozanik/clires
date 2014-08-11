CREATE TABLE [dbo].[Settings] (
    [Id]   INT NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Value]       NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME        NOT NULL DEFAULT (GETUTCDATE()),
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE INDEX [IX_Settings_Id] ON [dbo].[Settings] ([Id])
