CREATE TABLE [dbo].[Roles] (
[Id] INT IDENTITY(1,1) NOT NULL,
    [ApplicationId] UNIQUEIDENTIFIER NOT NULL,
    [RoleId]        UNIQUEIDENTIFIER NOT NULL,
    [RoleName]      NVARCHAR (256)   NOT NULL,
    [Description]   NVARCHAR (256)   NULL,
    CONSTRAINT [RoleApplication] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[Applications] ([ApplicationId]), 
    CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleId])
);

