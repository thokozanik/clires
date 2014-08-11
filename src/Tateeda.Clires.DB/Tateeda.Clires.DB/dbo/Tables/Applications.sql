﻿CREATE TABLE [dbo].[Applications] (
    [ApplicationName] NVARCHAR (235)   NOT NULL,
    [ApplicationId]   UNIQUEIDENTIFIER NOT NULL,
    [Description]     NVARCHAR (256)   NULL,
    PRIMARY KEY CLUSTERED ([ApplicationId] ASC)
);

