CREATE TABLE [dbo].[Site] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (100) NOT NULL,
    [Code]           NVARCHAR (32)  NULL,
    [TimeZoneId]     INT  NOT NULL,
	[IsPrimary]		 BIT NOT NULL DEFAULT(0),
    [Directions] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [UX_Site_Name] UNIQUE NONCLUSTERED ([Name] ASC) WITH (FILLFACTOR = 90), 
    CONSTRAINT [FK_Site_TimeZone] FOREIGN KEY (TimeZoneId) REFERENCES [TimeZone]([Id])
);

