CREATE TABLE [dbo].[SubjectAltNumber] (
    [Id] INT            IDENTITY (1, 1) NOT NULL,
    [SubjectId]          INT            NOT NULL,
    [AltId]              NVARCHAR (100) NOT NULL,
    [Description]        NVARCHAR (250) NULL,
    [Comment]            NVARCHAR (MAX) NULL,
    [Directions] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_SubjectAltNumber] PRIMARY KEY CLUSTERED ([Id] ASC)
);

