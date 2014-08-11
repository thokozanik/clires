CREATE TABLE [dbo].[VisitStep] (
    [Id] INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NOT NULL,
	[ArmId]		 INT NOT NULL,
	[Directions] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_VisitStep] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_VisitStep_Arm] FOREIGN KEY ([ArmId]) REFERENCES [Arm]([Id])
);

