CREATE TABLE [dbo].[AppUser] (
[Id] Int Identity(1,1) NOT NULL,
[MembershipUserId] UNIQUEIDENTIFIER NOT NULL,
    [SiteId]    INT            NOT NULL,
	[RoleId] UNIQUEIDENTIFIER NOT NULL,
	[ContactId] INT NOT NULL,
    [Title]     VARCHAR (100)  NULL,
    [SortOrder] INT            CONSTRAINT [DF__AppUser__SortOrd__753864A1] DEFAULT ((0)) NOT NULL,
    [Comments]  NVARCHAR (MAX) NULL,
    [Status]    INT            CONSTRAINT [DF__AppUser__Status__762C88DA] DEFAULT ((1)) NOT NULL,
    [UpdatedOn] DATETIME       NULL DEFAULT GETUTCDATE(),
	[CreatedOn] DATETIME       NULL DEFAULT GETUTCDATE(),
    [UpdatedBy] NVARCHAR (100) NULL,    
    [CreatedBy] NVARCHAR (100) NULL,
	[IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_AppUser_Site] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([Id]),
    CONSTRAINT [PK_AppUser] PRIMARY KEY ([Id]),    
    CONSTRAINT [FK_AppUser_User] FOREIGN KEY ([MembershipUserId]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_AppUser_Role] FOREIGN KEY ([RoleId]) REFERENCES [Roles]([RoleId]), 
    CONSTRAINT [FK_AppUser_Contact] FOREIGN KEY ([ContactId]) REFERENCES [Contact]([Id])
);


GO

CREATE INDEX [IX_AppUser_Column] ON [dbo].[AppUser] ([Id],[MembershipUserId], [SiteId])
