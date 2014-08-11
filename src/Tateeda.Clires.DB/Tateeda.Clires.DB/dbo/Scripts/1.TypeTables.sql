
GO

INSERT INTO [dbo].[AddressType]
		   ([Id]
		   ,[Name]           
		   ,[IsActive])
	 VALUES
			(1,'Office',1),
			(2,'Home'  ,1)
GO
INSERT INTO [dbo].[PhoneType]
		   ([Id]
		   ,[Name]
		   ,[IsActive])
	 VALUES
			(1,'Office',1),
			(2,'Home',1),
			(3,'Cell',1),
			(4,'N/A',1)
GO
INSERT INTO [dbo].[FormType]
		   ([Id]
		   ,[Name]
		   ,[IsActive])
	 VALUES
			(1,'Survey Form',1),
			(2,'Lab Form',1)
GO
INSERT INTO [dbo].[AppointmentFormStatusType]
		   ([Id]
		   ,[Name]
		   ,[IsActive])
	 VALUES
			(1,'Completed',1),
			(2,'In Progress',1),
			(3,'Canceled',1),
			(4,'Not Started',1),
			(5,'Forced Close',1),
			(6,'Needs Review',1),
			(7,'Needs Approval',1),
			(8,'Rejected',1)
GO
INSERT INTO [dbo].[VisitType]
		   ([Id]
		   ,[Name]
		   ,[IsActive])
	 VALUES
			(1,'Office Visit',1),
			(2,'Walk-In',1),
			(3,'Online Remote',1),
			(4,'On Behalf Of',1)
GO
GO
INSERT INTO [dbo].[ApointmentStatusType]
		   ([Id]
		   ,[Name]
		   ,[IsActive])
	 VALUES
			(1,'Scheduled',1),
			(2,'In Progress',1),
			(3,'Needs Follow Up Visit',1),
			(4,'Completed',1),
			(5,'Require More Data',1),
			(6,'Canceled',1),
			(7,'No Show',1)
GO
INSERT INTO [dbo].[FormLayoutType]
		   ([Id]
		   ,[Name]
		   ,[IsActive])
	 VALUES
			(1,'Horizontal',1),
			(2,'Vertical',1),
			(3,'2-Tabs',1),
			(4,'3-Tabs',1)
GO
INSERT INTO [dbo].[CssType]
		   ([Id]
		   ,[CssClassName]
		   ,[InputType]
		   ,[Html])
	 VALUES
			(1,'radio','radio',NULL),
			(2,'checkbox','checkbox',NULL),
			(3,'input-small','text',NULL),
			(4,'input-xlarge','text',NULL),
			(5,'input-large','text',NULL),
			(6,'select','select',NULL),
			(7,'input-small number','number',NULL),
			(8,'input-small date','date',NULL),
			(9,'input-xxlarge','textarea',NULL)
GO
INSERT INTO [dbo].[FieldDataType]
		   ([Id]
		   ,[Name]
		   ,[IsActive])
	 VALUES
			(1,'radio',1),
			(2,'checkbox',1),
			(3,'text-short',1),
			(4,'text-long',1),
			(5,'text-medium',1),
			(6,'select',1),
			(7,'number',1),
			(8,'date',1)
GO
INSERT INTO [dbo].[MessageStatusType]
		   ([Id]
		   ,[Name]
		   ,[IsActive])
	 VALUES
			(1,'Delivered',1),
			(2,'In Progress',1),
			(3,'Failed',1),
			(4,'Re-Trying',1)
GO
INSERT INTO [dbo].[DrugType]
		   ([Id]
		   ,[Name]
		   ,[IsActive])
	 VALUES
			(1,'Prescription',1),
			(2,'OTC',1),
			(3,'Recreational',1)
GO
INSERT INTO [dbo].[EntityStatusType]
		   ([Id]
		   ,[Name]
		   ,[IsActive])
	 VALUES
			(1,'Current',1),
			(2,'Deleted',1),
			(3,'Disabled',1),
			(4,'Archived',1),
			(5, 'Terminated', 1)
GO
INSERT INTO [dbo].[GenderType]
		   ([Id]
		   ,[Name]
		   ,[IsActive])
	 VALUES
			(1,'Male',1),
			(2,'Female',1) 
GO
INSERT INTO [dbo].[ContactType]
		   ([Id]
		   ,[Name]
		   ,[IsActive])
	 VALUES
			(1,'Subject', 1),
			(2,'AppUser',1),
			(3,'Other',1)
						