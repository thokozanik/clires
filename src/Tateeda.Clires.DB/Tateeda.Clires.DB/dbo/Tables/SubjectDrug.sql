CREATE TABLE [dbo].[SubjectDrug] (
    [Id]      INT             IDENTITY (1, 1) NOT NULL,
    [SubjectId]          INT             NOT NULL,
    [DrugId]             INT             NOT NULL,
    [AppointmentId]      INT             NOT NULL,
    [StartDate]          DATETIME        NULL,
    [EndDate]            DATETIME        NULL,
    [MultipleTrialsId]   INT             NULL,
    [DurationUsed]       INT             NULL,
    [ReasonStoppedId]    INT             NOT NULL,
    [ReasonTypeId]       INT             NOT NULL,
    [TreatmentInducedId] INT             NOT NULL,
    [DosageFrequencyId]  INT             NOT NULL,
    [IsCurrent]          BIT             DEFAULT ((0)) NOT NULL,
    [IsChanged]          BIT             DEFAULT ((0)) NOT NULL,
    [IsStopped]          BIT             DEFAULT ((0)) NOT NULL,
    [IsBeforeStudy]      BIT             DEFAULT ((0)) NOT NULL,
    [Dosage]             NVARCHAR (200)  NULL,
    [DosageType]         NVARCHAR (200)  NULL,
    [Notes]              NVARCHAR (1000) NULL,
    [MdNotes]            NVARCHAR (MAX)  NULL,
    [Comments]           NVARCHAR (MAX)  NULL,
    [Directions] NVARCHAR (500)  NULL,
    [SortOrder]  INT             DEFAULT ((0)) NOT NULL,
    [Status]     INT             DEFAULT ((1)) NOT NULL,
    [CreatedOn]  DATETIME    DEFAULT (GETUTCDATE())     NOT NULL,
    [UpdatedOn]  DATETIME        DEFAULT (GETUTCDATE()) NULL,
    [CreatedBy]  NVARCHAR (100)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100)  NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_SubjectDrug_Drug] FOREIGN KEY ([DrugId]) REFERENCES [dbo].[Drug] ([Id]), 
    CONSTRAINT [FK_SubjectDrug_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [Subject]([Id])
);


GO

-- =============================================
-- Author:		Author,,Name>
-- Create date: Create Date,
-- Description:	Description,
-- =============================================
CREATE TRIGGER [dbo].[SubjectDrugChengeHistory_TRG]
   ON  [dbo].[SubjectDrug]
   AFTER DELETE,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @Record AS TABLE(
		    SubjectDrugId int
           ,SubjectId int
           ,DrugId int
           ,AppointmentId int
           ,StartDate datetime
           ,EndDate datetime
           ,MultipleTrialsId int
           ,DurationUsed int
           ,ReasonStoppedId int
           ,ReasonTypeId int
           ,TreatmentInducedId int
           ,DosageFrequencyId int
           ,IsCurrent bit
           ,IsChanged bit
           ,IsStopped bit
           ,IsBeforeStudy bit
           ,Dosage nvarchar(200)
           ,DosageType nvarchar(200)
           ,Notes nvarchar(1000)
           ,MdNotes nvarchar(max)
           ,Comments nvarchar(max)
           ,Status int
           ,CreatedOn datetime
           ,UpdatedOn datetime
	)
	
	INSERT INTO @Record
	SELECT  
			[Id]
           ,SubjectId
           ,DrugId
           ,AppointmentId
           ,StartDate 
           ,EndDate 
           ,MultipleTrialsId
           ,DurationUsed
           ,ReasonStoppedId
           ,ReasonTypeId
           ,TreatmentInducedId
           ,DosageFrequencyId
           ,IsCurrent 
           ,IsChanged 
           ,IsStopped 
           ,IsBeforeStudy 
           ,Dosage 
           ,DosageType 
           ,Notes 
           ,MdNotes 
           ,Comments 
           ,Status
           ,CreatedOn 
           ,UpdatedOn
	FROM 
			inserted 
	
	INSERT INTO @Record
	SELECT  
			[Id]
           ,SubjectId           
           ,DrugId
           ,AppointmentId
           ,StartDate 
           ,EndDate 
           ,MultipleTrialsId
           ,DurationUsed
           ,ReasonStoppedId
           ,ReasonTypeId
           ,TreatmentInducedId
           ,DosageFrequencyId
           ,IsCurrent 
           ,IsChanged 
           ,IsStopped 
           ,IsBeforeStudy 
           ,Dosage 
           ,DosageType 
           ,Notes 
           ,MdNotes 
           ,Comments 
           ,Status
           ,CreatedOn 
           ,UpdatedOn
	FROM 
			deleted 
	

INSERT INTO [SubjectDrugHistory]
	(		[SubjectDrugId]
           ,[SubjectId]
           ,[DrugId]
           ,[AppointmentId]
           ,[StartDate]
           ,[EndDate]
           ,[MultipleTrialsId]
           ,[DurationUsed]
           ,[ReasonStoppedId]
           ,[ReasonTypeId]
           ,[TreatmentInducedId]
           ,[DosageFrequencyId]
           ,[IsCurrent]
           ,[IsChanged]
           ,[IsStopped]
           ,[IsBeforeStudy]
           ,[Dosage]
           ,[DosageType]
           ,[Notes]
           ,[MdNotes]
           ,[Comments]
           ,[Status]
           ,[CreatedOn]
           ,[UpdatedOn]
           ,[SavedOn]
       )
SELECT 
           SubjectDrugId
           ,SubjectId           
           ,DrugId
           ,AppointmentId
           ,StartDate 
           ,EndDate 
           ,MultipleTrialsId
           ,DurationUsed
           ,ReasonStoppedId
           ,ReasonTypeId
           ,TreatmentInducedId
           ,DosageFrequencyId
           ,IsCurrent 
           ,IsChanged 
           ,IsStopped 
           ,IsBeforeStudy 
           ,Dosage 
           ,DosageType 
           ,Notes 
           ,MdNotes 
           ,Comments 
           ,Status
           ,CreatedOn 
           ,UpdatedOn
           ,GETUTCDATE()
	FROM 
			@Record
END




