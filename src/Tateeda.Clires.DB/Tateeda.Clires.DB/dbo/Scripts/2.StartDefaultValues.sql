GO
INSERT INTO [dbo].[Applications]
           ([ApplicationName]
           ,[ApplicationId]
           ,[Description])
     VALUES
           ('Clires'
           ,'ec8abab6-2445-4d94-827f-9a8535f13fc9'
           ,'Clinical Trials/Study Research')
GO

INSERT INTO [dbo].[Roles]
           ([ApplicationId]
           ,[RoleId]
           ,[RoleName]
           ,[Description])
     VALUES
           ('ec8abab6-2445-4d94-827f-9a8535f13fc9','8d77a6e3-912f-47a7-bcb9-09edf0afc8df','Site Admin','Site Admin'),
		   ('ec8abab6-2445-4d94-827f-9a8535f13fc9','41cc545b-d0b5-4b32-9dab-71dd6d2b0bc2','Guest','Guest'),
		   ('ec8abab6-2445-4d94-827f-9a8535f13fc9','3ab436a7-a29b-426c-b945-8ffeaede229f','Subject','Site Subject'),
		   ('ec8abab6-2445-4d94-827f-9a8535f13fc9','967f2d1b-5de4-4d49-9292-a89ffdf266f9','Sys Admin','App Sys Admin'),
		   ('ec8abab6-2445-4d94-827f-9a8535f13fc9','522ce0c4-8147-4fc3-bee4-a8a4ce6edd9d','App User','Site App User')
GO

INSERT INTO [dbo].[Users]
           ([ApplicationId]
           ,[UserId]
           ,[UserName]
           ,[IsAnonymous]
           ,[LastActivityDate])
     VALUES
           ('ec8abab6-2445-4d94-827f-9a8535f13fc9'
           ,'82d9823a-0bfa-4fff-97bf-d54d3a222cd5'
           ,'admin'
           ,0
           ,GETUTCDATE())
GO

INSERT INTO [dbo].[Memberships]
           ([ApplicationId]
           ,[UserId]
           ,[Password]
           ,[PasswordFormat]
           ,[PasswordSalt]
           ,[Email]
           ,[PasswordQuestion]
           ,[PasswordAnswer]
           ,[IsApproved]
           ,[IsLockedOut]
           ,[CreateDate]
           ,[LastLoginDate]
           ,[LastPasswordChangedDate]
           ,[LastLockoutDate]
           ,[FailedPasswordAttemptCount]
           ,[FailedPasswordAttemptWindowStart]
           ,[FailedPasswordAnswerAttemptCount]
           ,[FailedPasswordAnswerAttemptWindowsStart]
           ,[Comment])
     VALUES
           ('ec8abab6-2445-4d94-827f-9a8535f13fc9'
		   ,'82d9823a-0bfa-4fff-97bf-d54d3a222cd5'
		   ,'Ty3VJBxmQvUQG5CuHMmYFZnsv3w1ASygtOr0u7u9Q7o=' --"password"
		   ,1
		   ,'2aKsLocqYJKfi6Zeai7n3Q=='
		   ,'admin@clires.com'	
		   ,NULL	
		   ,NULL	
		   ,1	
		   ,0
		   ,GETUTCDATE()
		   ,GETUTCDATE()
		   ,GETUTCDATE()
		   ,GETUTCDATE()
		   ,0
		   ,GETUTCDATE()
		   ,0
		   ,GETUTCDATE()
		   ,NULL		   
		   )
GO


GO

INSERT INTO [dbo].[UsersInRoles]
           ([UserId]
           ,[RoleId])
     VALUES
           ('82d9823a-0bfa-4fff-97bf-d54d3a222cd5'
           ,'967f2d1b-5de4-4d49-9292-a89ffdf266f9')
GO

INSERT INTO [dbo].[Study]
           ([Name]
           ,[Description]
           ,[StartDate]
           ,[EndDate]
           ,[Target]
           ,[Goal]
           ,[Budget]
           ,[SortOrder]
           ,[Status]
           ,[CreatedOn]
           ,[UpdatedOn]
           ,[CreatedBy]
           ,[UpdatedBy]
           ,[IsActive])
     VALUES
           ('Initial Study'
           ,'Please change this study to your specification'
           ,GETUTCDATE()
           ,(SELECT DateAdd(yy, 5, GetDate()))
           ,'Study targets information'
           ,'Study goals'
           ,'10000000.00'
           ,0
           ,1
           ,GETUTCDATE()
           ,GETUTCDATE()
           ,'SYSTEM'
           ,'SYSTEM'
           ,1)
GO

INSERT INTO [dbo].[Arm]
           ([StudyId]
           ,[Code]
           ,[Name]
           ,[Description]
           ,[CreatedOn]
           ,[UpdatedOn]
           ,[CreatedBy]
           ,[UpdatedBy]
           ,[IsActive])
     VALUES
           ((SELECT TOP 1 Id from Study), 'A', 'Phase I', 'Phase I Arm', GETUTCDATE(), GETUTCDATE(), 'Admin','Admin',1)
GO
INSERT INTO [dbo].[Settings]
           (Id
		   ,[Name]
           ,[Value]
           ,[Description]
           ,[SortOrder]
           ,[Status]
           ,[CreatedOn]
           ,[UpdatedOn]
           ,[CreatedBy]
           ,[UpdatedBy]
           ,[IsActive])
     VALUES
           (1
		   ,'CurrentStudyId'
           ,(SELECT Top 1 Id FROM Study)
           ,'Default Study'
           ,0
           ,1
           ,GETUTCDATE()
           ,GETUTCDATE()
           ,'ADMIN'
           ,'ADMIN'
           ,1)
GO