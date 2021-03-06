USE [master]
GO
/****** Object:  Database [Tateeda.Clires.v4]    Script Date: 8/11/2012 11:48:45 PM ******/
CREATE DATABASE [Tateeda.Clires.v4] ON  PRIMARY 
( NAME = N'Tateeda.Clires.v4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Tateeda.Clires.v4.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Tateeda.Clires.v4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Tateeda.Clires.v4_log.LDF' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Tateeda.Clires.v4] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Tateeda.Clires.v4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Tateeda.Clires.v4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET ARITHABORT OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET RECOVERY FULL 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET  MULTI_USER 
GO
ALTER DATABASE [Tateeda.Clires.v4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Tateeda.Clires.v4] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Tateeda.Clires.v4', N'ON'
GO
USE [Tateeda.Clires.v4]
GO
/****** Object:  StoredProcedure [dbo].[uspGetSubjectById]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[uspGetSubjectById] 
    @SubjectId int
AS 
	BEGIN
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	-- SubjectKey must be created previously
	OPEN SYMMETRIC KEY SubjectKey
		DECRYPTION BY CERTIFICATE SubjectCert;

	SELECT [SubjectId], [SiteId],  [Nickname], [FamilyId], [Notes], 
		   [NIMHID], [Gender], [YearBorn], [Status], [SortOrder], 
		   CONVERT(nvarchar, DecryptByKey(FirstNameEnc)) AS [FirstName], 
		   CONVERT(nvarchar, DecryptByKey(LastNameEnc))  AS [LastName], 
		   CONVERT(nvarchar, DecryptByKey(DateOfBirthEnc)) AS [DateOfBirth], 
		   NULL AS [FirstNameEnc],		-- no need for encrypted values
		   NULL AS [LastNameEnc], 
		   NULL AS [DateOfBirthEnc], 
		   [CreatedOn], [UpdatedOn]
	FROM   [dbo].[Subject] 
	WHERE  SubjectId = @SubjectId
	ORDER BY FirstName, LastName

	COMMIT
	END


GO
/****** Object:  StoredProcedure [dbo].[uspGetSubjectBySiteId]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[uspGetSubjectBySiteId] 
    @SiteId int
AS 
	BEGIN
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	-- SubjectKey must be created previously
	OPEN SYMMETRIC KEY SubjectKey
		DECRYPTION BY CERTIFICATE SubjectCert;

	SELECT [SubjectId], [SiteId], [Nickname], [FamilyId], [Notes], 
		   [NIMHID], [Gender], [YearBorn], [Status], [SortOrder], 
		   CONVERT(nvarchar, DecryptByKey(FirstNameEnc)) AS [FirstName], 
		   CONVERT(nvarchar, DecryptByKey(LastNameEnc))  AS [LastName], 
		   CONVERT(nvarchar, DecryptByKey(DateOfBirthEnc)) AS [DateOfBirth], 
		   NULL AS [FirstNameEnc],		-- no need for encrypted values
		   NULL AS [LastNameEnc], 
		   NULL AS [DateOfBirthEnc], 
		   [CreatedOn], [UpdatedOn]
	FROM   [dbo].[Subject] 
	WHERE  SiteId = @SiteId
	ORDER BY FirstName, LastName

	COMMIT
	END


GO
/****** Object:  StoredProcedure [dbo].[uspSubjectFindByFirstLastName]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[uspSubjectFindByFirstLastName] 
    @SiteId int,
    @FirstName nvarchar(100) = NULL,
    @LastName nvarchar(100) = NULL
AS 
	BEGIN
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	-- SubjectKey must be created previously
	OPEN SYMMETRIC KEY SubjectKey
		DECRYPTION BY CERTIFICATE SubjectCert;

	SELECT [SubjectId], [SiteId],   [Nickname], [FamilyId], [Notes], 
		   [NIMHID], [Gender], [YearBorn], [Status], [SortOrder], 
		   CONVERT(nvarchar, DecryptByKey(FirstNameEnc)) AS [FirstName], 
		   CONVERT(nvarchar, DecryptByKey(LastNameEnc))  AS [LastName], 
		   CONVERT(nvarchar, DecryptByKey(DateOfBirthEnc)) AS [DateOfBirth], 
		   NULL AS [FirstNameEnc],		-- no need for encrypted values
		   NULL AS [LastNameEnc], 
		   NULL AS [DateOfBirthEnc], 
		   [CreatedOn], [UpdatedOn]
	FROM   [dbo].[Subject] 
	WHERE  (CONVERT(nvarchar, DecryptByKey(FirstNameEnc)) LIKE @FirstName + '%' OR @FirstName IS NULL) 
			AND
		   (CONVERT(nvarchar, DecryptByKey(LastNameEnc)) LIKE @LastName + '%' OR @LastName IS NULL) 
	ORDER BY FirstName, LastName

	COMMIT
	END

/* Unit test

EXEC	[dbo].[uspSubjectFindByFirstLastName]
		@SiteId = 1,
		@FirstName = N'Ivo',
		@LastName = N'Stoyanov'

EXEC	[dbo].[uspSubjectFindByFirstLastName]
		@SiteId = 1,
		@FirstName = N'Ivo'

-- test partial match
EXEC	[dbo].[uspSubjectFindByFirstLastName]
		@SiteId = 1,
		@FirstName = N'I'

EXEC	[dbo].[uspSubjectFindByFirstLastName]
		@SiteId = 1,
		@LastName = N'Stoy'

 */


GO
/****** Object:  StoredProcedure [dbo].[uspSubjectInsert]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[uspSubjectInsert] 
    @SiteId int,
    @Nickname nvarchar(100),
    @FamilyId nvarchar(100),
    @Notes nvarchar(1000),
    @NIMHID nvarchar(100),
    @Gender char(1),
    @YearBorn int,
    @Status int,
    @SortOrder int,
	-- cleartext
    @FirstName nvarchar(100),		-- will be encrypted
    @LastName nvarchar(100),			-- will be encrypted
    @DateOfBirth nvarchar(32)			-- will be encrypted
AS 
  BEGIN
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

    DECLARE @FirstNameEnc varbinary(256),
			@LastNameEnc varbinary(256),
			@DateOfBirthEnc varbinary(256)

	-- SubjectKey must be created previously
	OPEN SYMMETRIC KEY SubjectKey
		DECRYPTION BY CERTIFICATE SubjectCert;

	SET @FirstNameEnc   = EncryptByKey(Key_GUID('SubjectKey'), @FirstName)
	SET @LastNameEnc    = EncryptByKey(Key_GUID('SubjectKey'), @LastName)
	SET @DateOfBirthEnc = EncryptByKey(Key_GUID('SubjectKey'), @DateOfBirth)
	
	BEGIN TRAN

	   INSERT INTO [dbo].[Subject] (
				[SiteId],   [Nickname], [FamilyId], [Notes], 
				[NIMHID], [Gender], [YearBorn], [Status], [SortOrder], 
				[FirstNameEnc], [LastNameEnc], [DateOfBirthEnc], 
				[CreatedOn])
	   SELECT	@SiteId,  @Nickname, @FamilyId, 
				@Notes, @NIMHID, @Gender, @YearBorn, @Status, @SortOrder, 
				@FirstNameEnc, @LastNameEnc, @DateOfBirthEnc, 
				GETDATE()
	COMMIT
	SELECT SCOPE_IDENTITY()
 END

/* Unit test

EXEC	[dbo].[uspSubjectInsert]
		@SiteId = 1,
		@Nickname = N'ivo',
		@FamilyId = NULL,
		@Notes = NULL,
		@NIMHID = NULL,
		@Gender = N'M',
		@YearBorn = 1970,
		@Status = 1,
		@SortOrder = 1,
		@FirstName = N'Ivo',
		@LastName = N'Stoyanov',
		@DateOfBirth = N'19701231'

SELECT * FROM dbo.Subject
 */


GO
/****** Object:  StoredProcedure [dbo].[uspSubjectUpdate]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[uspSubjectUpdate] 
    @SubjectId int,
    @SiteId int,
    @Nickname nvarchar(100),
    @FamilyId nvarchar(100),
    @Notes nvarchar(1000),
    @NIMHID nvarchar(100),
    @Gender char(1),
    @YearBorn int,
    @Status int,
    @SortOrder int,
	-- cleartext
    @FirstName nvarchar(100),		-- will be encrypted
    @LastName nvarchar(100),			-- will be encrypted
    @DateOfBirth nvarchar(32)			-- will be encrypted
AS 
  BEGIN

	SET NOCOUNT ON 
	SET XACT_ABORT ON  

    DECLARE @FirstNameEnc varbinary(256),
			@LastNameEnc varbinary(256),
			@DateOfBirthEnc varbinary(128)

	-- SubjectKey must be created previously
	OPEN SYMMETRIC KEY SubjectKey
		DECRYPTION BY CERTIFICATE SubjectCert;

	SET @FirstNameEnc   = EncryptByKey(Key_GUID('SubjectKey'), @FirstName)
	SET @LastNameEnc    = EncryptByKey(Key_GUID('SubjectKey'), @LastName)
	SET @DateOfBirthEnc = EncryptByKey(Key_GUID('SubjectKey'), @DateOfBirth)
	
	BEGIN TRAN

		UPDATE  [dbo].[Subject]
		   SET	[SiteId] = @SiteId, 
				[Nickname] = @Nickname, [FamilyId] = @FamilyId, [Notes] = @Notes, [NIMHID] = @NIMHID, 
				[Gender] = @Gender, [YearBorn] = @YearBorn, [Status] = @Status, [SortOrder] = @SortOrder, 
				[FirstNameEnc] = @FirstNameEnc, [LastNameEnc] = @LastNameEnc, [DateOfBirthEnc] = @DateOfBirthEnc, 
				[UpdatedOn] = GETDATE()
		WHERE   [SubjectId] = @SubjectId
	
	COMMIT TRAN

	SELECT @SubjectId
 END

/* Unit test

EXEC	[dbo].[uspSubjectUpdate]
		@SubjectId = 2010,
		@SiteId = 1,
		@Nickname = N'ivo',
		@FamilyId = NULL,
		@Notes = NULL,
		@NIMHID = NULL,
		@Gender = N'M',
		@YearBorn = 1992,
		@Status = 1,
		@SortOrder = 1,
		@FirstName = N'Victor',
		@LastName = N'Stoyanoff',
		@DateOfBirth = N'19920716',

EXEC	[dbo].[uspSubjectFindByFirstLastName]
		@SiteId = 1,
		@LastName = N'Stoy'
 */


GO
/****** Object:  Table [dbo].[Answer]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[OptionText] [nvarchar](1000) NOT NULL,
	[Code] [nvarchar](32) NULL,
	[Score] [int] NULL,
	[Header] [nvarchar](200) NULL,
	[Trailer] [nvarchar](200) NULL,
	[Directions] [nvarchar](500) NULL,
	[SortOrder] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[UpdatedBy] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC,
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Applications]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[ApplicationName] [nvarchar](235) NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[AppointmentId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[VisitId] [int] NOT NULL,
	[SiteId] [int] NOT NULL,
	[AppUserId] [int] NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Location] [nvarchar](200) NULL,
	[Description] [nvarchar](2000) NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Duration] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[ScheduledBy] [nvarchar](100) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_VisitSchedule] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppointmentForm]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentForm](
	[AppointmentFormId] [int] IDENTITY(1,1) NOT NULL,
	[FormId] [int] NOT NULL,
	[AppointmentId] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Comments] [nvarchar](max) NULL,
	[TotalScore] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[SortOrder] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[UpdatedBy] [nvarchar](100) NULL,
 CONSTRAINT [PK_Score] PRIMARY KEY CLUSTERED 
(
	[AppointmentFormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppUser]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AppUser](
	[SiteId] [int] NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Title] [varchar](100) NULL,
	[SortOrder] [int] NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
 CONSTRAINT [UX_AppUser_LoginName] UNIQUE NONCLUSTERED 
(
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Arm]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Arm](
	[ArmId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [char](1) NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_Arm] PRIMARY KEY CLUSTERED 
(
	[ArmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Code]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Code](
	[CodeId] [int] IDENTITY(1,1) NOT NULL,
	[CodeTypeId] [int] NOT NULL,
	[EnumId] [int] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[CodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CodeType]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CodeType](
	[CodeTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[CodeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTGovSubmission]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTGovSubmission](
	[CTGovSubmissionId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[SubmissionXML] [xml] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_CTGovSubmission] PRIMARY KEY CLUSTERED 
(
	[CTGovSubmissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Drug]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drug](
	[DrugId] [int] IDENTITY(1,1) NOT NULL,
	[DrugClassId] [int] NOT NULL,
	[DrugTypeId] [int] NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Directions] [nvarchar](500) NULL,
	[SortOrder] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[DrugId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DrugCategory]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrugCategory](
	[DrugCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Code] [nvarchar](32) NULL,
	[Directions] [nvarchar](500) NULL,
	[SortOrder] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[DrugCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DrugClass]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrugClass](
	[DrugClassId] [int] IDENTITY(1,1) NOT NULL,
	[DrugCategoryId] [int] NOT NULL,
	[Name] [nvarchar](64) NULL,
	[Description] [nvarchar](500) NULL,
	[Directions] [nvarchar](500) NULL,
	[SortOrder] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[DrugClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DrugType]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrugType](
	[DrugTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NULL,
	[Description] [nvarchar](500) NULL,
	[Directions] [nvarchar](500) NULL,
	[SortOrder] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[DrugTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FieldDataType]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldDataType](
	[FieldDataTypeId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_FieldDataType] PRIMARY KEY CLUSTERED 
(
	[FieldDataTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Form]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Form](
	[FormId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Code] [nvarchar](32) NULL,
	[FormType] [int] NOT NULL,
	[Title] [nvarchar](500) NULL,
	[Description] [nvarchar](1000) NULL,
	[Directions] [nvarchar](1000) NULL,
	[Header] [nvarchar](1000) NULL,
	[Trailer] [nvarchar](1000) NULL,
	[IsFilledBySubject] [bit] NOT NULL,
	[ShowTotalScore] [bit] NOT NULL,
	[LayoutType] [int] NULL,
	[SortOrder] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[UpdatedBy] [nvarchar](100) NOT NULL,
	[DoubleChecked] [bit] NULL,
	[DoubleCheckedOn] [datetime] NULL,
	[DoubleCheckedBy] [nvarchar](100) NULL,
 CONSTRAINT [PK_Form] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [UX_Form_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormAnswer]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormAnswer](
	[AppointmentFormId] [int] NOT NULL,
	[AnswerId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[FreeTextAnswer] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_FormAnswer] PRIMARY KEY CLUSTERED 
(
	[AppointmentFormId] ASC,
	[AnswerId] ASC,
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormVisibilityByVisitForSubject]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormVisibilityByVisitForSubject](
	[FormId] [int] NOT NULL,
	[VisitId] [int] NOT NULL,
	[DaysPriorToVisit] [int] NOT NULL,
	[DaysAfterVisit] [int] NOT NULL,
 CONSTRAINT [PK_FormVisibilityByVisitForSubject] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC,
	[VisitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Language]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LanguageCulture] [nvarchar](20) NOT NULL,
	[UniqueSeoCode] [nvarchar](2) NULL,
	[FlagImageFileName] [nvarchar](50) NULL,
	[Published] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LocaleStringResource]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocaleStringResource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[ResourceName] [nvarchar](200) NOT NULL,
	[ResourceValue] [nvarchar](1000) NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Memberships]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Memberships](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastPasswordChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NOT NULL,
	[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[FailedPasswordAnswerAttemptWindowsStart] [datetime] NOT NULL,
	[Comment] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageProvider]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageProvider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[LicenseKey] [nvarchar](1000) NULL,
	[AccountName] [nvarchar](200) NULL,
	[AccountPassword] [nvarchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[ServiceUri] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageQueue]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageQueue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TemplateId] [int] NOT NULL,
	[PriorityId] [int] NOT NULL,
	[Data] [nvarchar](max) NULL,
	[RecipientId] [int] NOT NULL,
	[SenderId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[QueuedOn] [datetime] NOT NULL,
	[LastProcessedOn] [datetime] NULL,
	[TriesCount] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_MessageQueue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageStatusType]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageStatusType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageTemplate]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[BccEmailAddresses] [nvarchar](200) NULL,
	[Subject] [nvarchar](1000) NULL,
	[Body] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[MessageProviderId] [int] NOT NULL,
 CONSTRAINT [PK_MessageTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[UserId] [uniqueidentifier] NOT NULL,
	[PropertyNames] [nvarchar](4000) NOT NULL,
	[PropertyValueStrings] [nvarchar](4000) NOT NULL,
	[PropertyValueBinary] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Question]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[FormId] [int] NOT NULL,
	[QuestionTypeId] [int] NOT NULL,
	[FieldDataTypeId] [int] NOT NULL,
	[LabtestId] [int] NULL,
	[QuestionText] [nvarchar](max) NOT NULL,
	[Code] [nvarchar](32) NULL,
	[Directions] [nvarchar](1000) NULL,
	[SortOrder] [int] NOT NULL,
	[Header] [nvarchar](1000) NULL,
	[Trailer] [nvarchar](1000) NULL,
	[Status] [int] NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[UpdatedBy] [nvarchar](100) NOT NULL,
	[ParentQuestionId] [int] NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuestionType]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionType](
	[QuestionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Header] [nvarchar](1000) NULL,
	[Trailer] [nvarchar](1000) NULL,
	[Directions] [nvarchar](1000) NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_QuestionType] PRIMARY KEY CLUSTERED 
(
	[QuestionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [UX_QuestionType_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RecreationalDrugOrSubstance]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RecreationalDrugOrSubstance](
	[RecreationalDrugOrSubstanceId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[Dose] [nvarchar](50) NULL,
	[Unit] [nvarchar](20) NULL,
	[Frequency] [int] NULL,
	[FrequencyUnit] [nvarchar](20) NULL,
	[TypeName] [nvarchar](50) NULL,
	[UseStartDate] [date] NULL,
	[UseEndDate] [date] NULL,
	[AppointementId] [int] NULL,
	[Status] [int] NOT NULL,
	[Comments] [varchar](500) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[Createdby] [varchar](100) NOT NULL,
	[UpdatedBy] [varchar](100) NULL,
 CONSTRAINT [PK_RecreationalDrugOrSubstance] PRIMARY KEY CLUSTERED 
(
	[RecreationalDrugOrSubstanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rule]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rule](
	[RuleId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Action] [nvarchar](max) NULL,
	[IsActive] [char](1) NOT NULL,
 CONSTRAINT [PK_Rule] PRIMARY KEY CLUSTERED 
(
	[RuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RuleMap]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RuleMap](
	[RuleId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[ItemType] [int] NOT NULL,
 CONSTRAINT [PK_RuleMap] PRIMARY KEY CLUSTERED 
(
	[RuleId] ASC,
	[ItemId] ASC,
	[ItemType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ScheduleSubjectVisit]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleSubjectVisit](
	[SubjectId] [int] NOT NULL,
	[VisitId] [int] NOT NULL,
 CONSTRAINT [PK_ScheduleSubjectVisit] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC,
	[VisitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SchemaVersion]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchemaVersion](
	[DbVersion] [nvarchar](100) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Settings]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[SettingId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[SettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Site]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site](
	[SiteId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Code] [nvarchar](32) NULL,
	[Description] [nvarchar](500) NULL,
	[Status] [int] NOT NULL,
	[TimeZoneId] [nvarchar](50) NULL,
	[TimeZoneOffset] [int] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [UX_Site_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectId] [int] IDENTITY(1848408,1) NOT NULL,
	[SiteId] [int] NOT NULL,
	[Nickname] [nvarchar](100) NULL,
	[FamilyId] [nvarchar](50) NULL,
	[Notes] [nvarchar](1000) NULL,
	[NIMHID] [nvarchar](100) NULL,
	[Gender] [char](1) NOT NULL,
	[YearBorn] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[DateOfBirth] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[FirstNameEnc] [varbinary](256) NULL,
	[LastNameEnc] [varbinary](256) NULL,
	[DateOfBirthEnc] [varbinary](256) NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SubjectAltNumber]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectAltNumber](
	[SubjectAltNumberId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[AltId] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Comment] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_SubjectAltNumber] PRIMARY KEY CLUSTERED 
(
	[SubjectAltNumberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectDrug]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectDrug](
	[SubjectDrugId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[DrugId] [int] NOT NULL,
	[AppointmentId] [int] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[MultipleTrialsId] [int] NULL,
	[DurationUsed] [int] NULL,
	[ReasonStoppedId] [int] NOT NULL,
	[ReasonTypeId] [int] NOT NULL,
	[TreatmentInducedId] [int] NOT NULL,
	[DosageFrequencyId] [int] NOT NULL,
	[IsCurrent] [bit] NOT NULL,
	[IsChanged] [bit] NOT NULL,
	[IsStopped] [bit] NOT NULL,
	[IsBeforeStudy] [bit] NOT NULL,
	[Dosage] [nvarchar](200) NULL,
	[DosageType] [nvarchar](200) NULL,
	[Notes] [nvarchar](1000) NULL,
	[MdNotes] [nvarchar](max) NULL,
	[Comments] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectDrugId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectDrugHistory]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectDrugHistory](
	[SubjectDrugId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[DrugId] [int] NOT NULL,
	[AppointmentId] [int] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[MultipleTrialsId] [int] NULL,
	[DurationUsed] [int] NULL,
	[ReasonStoppedId] [int] NOT NULL,
	[ReasonTypeId] [int] NOT NULL,
	[TreatmentInducedId] [int] NOT NULL,
	[DosageFrequencyId] [int] NOT NULL,
	[IsCurrent] [bit] NOT NULL,
	[IsChanged] [bit] NOT NULL,
	[IsStopped] [bit] NOT NULL,
	[IsBeforeStudy] [bit] NOT NULL,
	[Dosage] [nvarchar](200) NULL,
	[DosageType] [nvarchar](200) NULL,
	[Notes] [nvarchar](1000) NULL,
	[MdNotes] [nvarchar](max) NULL,
	[Comments] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[SavedOn] [datetime2](7) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[IsAnonymous] [bit] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsersInRoles]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Visit]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visit](
	[VisitId] [int] IDENTITY(1,1) NOT NULL,
	[VisitTypeId] [int] NOT NULL,
	[ArmId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Code] [nvarchar](32) NULL,
	[Description] [nvarchar](500) NULL,
	[DayFrom] [int] NULL,
	[DayTo] [int] NULL,
	[SortOrder] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Visit] PRIMARY KEY CLUSTERED 
(
	[VisitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [UX_Visit_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VisitForms]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitForms](
	[VisitId] [int] NOT NULL,
	[FormId] [int] NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_VisitForms] PRIMARY KEY CLUSTERED 
(
	[VisitId] ASC,
	[FormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VisitStep]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitStep](
	[VisitStepId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_VisitStep] PRIMARY KEY CLUSTERED 
(
	[VisitStepId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VisitStepMapping]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitStepMapping](
	[VisitStepId] [int] NOT NULL,
	[VisitId] [int] NOT NULL,
 CONSTRAINT [PK_VisitStepMapping] PRIMARY KEY CLUSTERED 
(
	[VisitStepId] ASC,
	[VisitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VisitStepVisitSequence]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitStepVisitSequence](
	[VisitStepId] [int] NOT NULL,
	[VisitId] [int] NOT NULL,
	[DaysFromBase] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_VisitStepVisitSequence] PRIMARY KEY CLUSTERED 
(
	[VisitStepId] ASC,
	[VisitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VisitType]    Script Date: 8/11/2012 11:48:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitType](
	[VisitTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Code] [nvarchar](32) NULL,
	[Description] [nvarchar](1000) NULL,
	[DayFrom] [int] NULL,
	[DayTo] [int] NULL,
	[SortOrder] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_VisitType] PRIMARY KEY CLUSTERED 
(
	[VisitTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [UX_VisitType_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Answer] ADD  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Answer] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Answer] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[Appointment] ADD  CONSTRAINT [DF__Appointme__Durat__038683F8]  DEFAULT ((1)) FOR [Duration]
GO
ALTER TABLE [dbo].[Appointment] ADD  CONSTRAINT [DF__Appointme__Statu__047AA831]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Appointment] ADD  CONSTRAINT [DF__Appointme__Creat__056ECC6A]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[AppointmentForm] ADD  CONSTRAINT [DF__Appointme__Total__084B3915]  DEFAULT ((0)) FOR [TotalScore]
GO
ALTER TABLE [dbo].[AppUser] ADD  CONSTRAINT [DF__AppUser__SortOrd__753864A1]  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[AppUser] ADD  CONSTRAINT [DF__AppUser__Status__762C88DA]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Code] ADD  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Drug] ADD  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Drug] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Drug] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[DrugCategory] ADD  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[DrugCategory] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[DrugCategory] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[DrugClass] ADD  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[DrugClass] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[DrugClass] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[DrugType] ADD  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[DrugType] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[DrugType] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Form] ADD  DEFAULT ((0)) FOR [FormType]
GO
ALTER TABLE [dbo].[Form] ADD  DEFAULT ((0)) FOR [IsFilledBySubject]
GO
ALTER TABLE [dbo].[Form] ADD  DEFAULT ((0)) FOR [ShowTotalScore]
GO
ALTER TABLE [dbo].[Form] ADD  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Form] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Form] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Form] ADD  CONSTRAINT [DF_Form_DoubleChecked]  DEFAULT ((0)) FOR [DoubleChecked]
GO
ALTER TABLE [dbo].[FormAnswer] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[LocaleStringResource] ADD  DEFAULT ((1)) FOR [LanguageId]
GO
ALTER TABLE [dbo].[LocaleStringResource] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[MessageProvider] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[MessageQueue] ADD  DEFAULT (getdate()) FOR [QueuedOn]
GO
ALTER TABLE [dbo].[MessageQueue] ADD  DEFAULT ((0)) FOR [TriesCount]
GO
ALTER TABLE [dbo].[MessageQueue] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[MessageTemplate] ADD  DEFAULT ((1)) FOR [LanguageId]
GO
ALTER TABLE [dbo].[MessageTemplate] ADD  DEFAULT ((1)) FOR [MessageProviderId]
GO
ALTER TABLE [dbo].[Question] ADD  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Question] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Question] ADD  DEFAULT ((0)) FOR [IsRequired]
GO
ALTER TABLE [dbo].[Question] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[QuestionType] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[RecreationalDrugOrSubstance] ADD  CONSTRAINT [DF__Recreatio__Creat__0B27A5C0]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Rule] ADD  CONSTRAINT [DF_Rule_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[SchemaVersion] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Site] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Site] ADD  DEFAULT ((0)) FOR [TimeZoneOffset]
GO
ALTER TABLE [dbo].[Site] ADD  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Site] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Subject] ADD  CONSTRAINT [DF__Subject__Status__43A1090D]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Subject] ADD  CONSTRAINT [DF__Subject__SortOrd__44952D46]  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Subject] ADD  CONSTRAINT [DF__Subject__Created__4589517F]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[SubjectAltNumber] ADD  CONSTRAINT [DF_SubjectAltNumber_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[SubjectAltNumber] ADD  CONSTRAINT [DF_SubjectAltNumber_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[SubjectDrug] ADD  DEFAULT ((0)) FOR [IsCurrent]
GO
ALTER TABLE [dbo].[SubjectDrug] ADD  DEFAULT ((0)) FOR [IsChanged]
GO
ALTER TABLE [dbo].[SubjectDrug] ADD  DEFAULT ((0)) FOR [IsStopped]
GO
ALTER TABLE [dbo].[SubjectDrug] ADD  DEFAULT ((0)) FOR [IsBeforeStudy]
GO
ALTER TABLE [dbo].[SubjectDrug] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[SubjectDrug] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[SubjectDrugHistory] ADD  CONSTRAINT [DF_SubjectDrugHistory_IsCurrent]  DEFAULT ((0)) FOR [IsCurrent]
GO
ALTER TABLE [dbo].[SubjectDrugHistory] ADD  CONSTRAINT [DF_SubjectDrugHistory_IsChanged]  DEFAULT ((0)) FOR [IsChanged]
GO
ALTER TABLE [dbo].[SubjectDrugHistory] ADD  CONSTRAINT [DF_SubjectDrugHistory_IsStopped]  DEFAULT ((0)) FOR [IsStopped]
GO
ALTER TABLE [dbo].[SubjectDrugHistory] ADD  CONSTRAINT [DF_SubjectDrugHistory_IsBeforeStudy]  DEFAULT ((0)) FOR [IsBeforeStudy]
GO
ALTER TABLE [dbo].[SubjectDrugHistory] ADD  CONSTRAINT [DF_SubjectDrugHistory_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[SubjectDrugHistory] ADD  CONSTRAINT [DF_SubjectDrugHistory_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[SubjectDrugHistory] ADD  CONSTRAINT [DF_SubjectDrugHistory_SavedOn]  DEFAULT (getdate()) FOR [SavedOn]
GO
ALTER TABLE [dbo].[Visit] ADD  CONSTRAINT [DF__Visit__ArmId__4959E263]  DEFAULT ((1)) FOR [ArmId]
GO
ALTER TABLE [dbo].[Visit] ADD  CONSTRAINT [DF__Visit__DayFrom__4A4E069C]  DEFAULT ((0)) FOR [DayFrom]
GO
ALTER TABLE [dbo].[Visit] ADD  CONSTRAINT [DF__Visit__DayTo__4B422AD5]  DEFAULT ((0)) FOR [DayTo]
GO
ALTER TABLE [dbo].[Visit] ADD  CONSTRAINT [DF__Visit__SortOrder__4C364F0E]  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Visit] ADD  CONSTRAINT [DF__Visit__Status__4D2A7347]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Visit] ADD  CONSTRAINT [DF__Visit__CreatedOn__4E1E9780]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[VisitForms] ADD  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[VisitStep] ADD  CONSTRAINT [DF_VisitStep_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[VisitStepVisitSequence] ADD  CONSTRAINT [DF_VisitStepVisitSequence_DaysFromBase]  DEFAULT ((0)) FOR [DaysFromBase]
GO
ALTER TABLE [dbo].[VisitStepVisitSequence] ADD  CONSTRAINT [DF_VisitStepVisitSequence_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[VisitType] ADD  DEFAULT ((0)) FOR [DayFrom]
GO
ALTER TABLE [dbo].[VisitType] ADD  DEFAULT ((0)) FOR [DayTo]
GO
ALTER TABLE [dbo].[VisitType] ADD  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[VisitType] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[VisitType] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([QuestionId])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Subject]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Visit] FOREIGN KEY([VisitId])
REFERENCES [dbo].[Visit] ([VisitId])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Visit]
GO
ALTER TABLE [dbo].[AppointmentForm]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentForm_Appointment] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[Appointment] ([AppointmentId])
GO
ALTER TABLE [dbo].[AppointmentForm] CHECK CONSTRAINT [FK_AppointmentForm_Appointment]
GO
ALTER TABLE [dbo].[AppointmentForm]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentForm_Form] FOREIGN KEY([FormId])
REFERENCES [dbo].[Form] ([FormId])
GO
ALTER TABLE [dbo].[AppointmentForm] CHECK CONSTRAINT [FK_AppointmentForm_Form]
GO
ALTER TABLE [dbo].[AppUser]  WITH CHECK ADD  CONSTRAINT [FK_AppUser_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([SiteId])
GO
ALTER TABLE [dbo].[AppUser] CHECK CONSTRAINT [FK_AppUser_Site]
GO
ALTER TABLE [dbo].[Code]  WITH CHECK ADD  CONSTRAINT [FK_Code_CodeType] FOREIGN KEY([CodeTypeId])
REFERENCES [dbo].[CodeType] ([CodeTypeId])
GO
ALTER TABLE [dbo].[Code] CHECK CONSTRAINT [FK_Code_CodeType]
GO
ALTER TABLE [dbo].[Drug]  WITH CHECK ADD  CONSTRAINT [FK_Drug_DrugClass] FOREIGN KEY([DrugClassId])
REFERENCES [dbo].[DrugClass] ([DrugClassId])
GO
ALTER TABLE [dbo].[Drug] CHECK CONSTRAINT [FK_Drug_DrugClass]
GO
ALTER TABLE [dbo].[Drug]  WITH CHECK ADD  CONSTRAINT [FK_Drug_DrugType] FOREIGN KEY([DrugTypeId])
REFERENCES [dbo].[DrugType] ([DrugTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Drug] CHECK CONSTRAINT [FK_Drug_DrugType]
GO
ALTER TABLE [dbo].[DrugClass]  WITH CHECK ADD  CONSTRAINT [FK_DrugClass_DrugCategory] FOREIGN KEY([DrugCategoryId])
REFERENCES [dbo].[DrugCategory] ([DrugCategoryId])
GO
ALTER TABLE [dbo].[DrugClass] CHECK CONSTRAINT [FK_DrugClass_DrugCategory]
GO
ALTER TABLE [dbo].[FormAnswer]  WITH CHECK ADD  CONSTRAINT [FK_FormAnswer_AppointmentForm] FOREIGN KEY([AppointmentFormId])
REFERENCES [dbo].[AppointmentForm] ([AppointmentFormId])
GO
ALTER TABLE [dbo].[FormAnswer] CHECK CONSTRAINT [FK_FormAnswer_AppointmentForm]
GO
ALTER TABLE [dbo].[FormVisibilityByVisitForSubject]  WITH CHECK ADD  CONSTRAINT [FK_FormVisibilityByVisitForSubject_Form] FOREIGN KEY([FormId])
REFERENCES [dbo].[Form] ([FormId])
GO
ALTER TABLE [dbo].[FormVisibilityByVisitForSubject] CHECK CONSTRAINT [FK_FormVisibilityByVisitForSubject_Form]
GO
ALTER TABLE [dbo].[FormVisibilityByVisitForSubject]  WITH CHECK ADD  CONSTRAINT [FK_FormVisibilityByVisitForSubject_Visit] FOREIGN KEY([VisitId])
REFERENCES [dbo].[Visit] ([VisitId])
GO
ALTER TABLE [dbo].[FormVisibilityByVisitForSubject] CHECK CONSTRAINT [FK_FormVisibilityByVisitForSubject_Visit]
GO
ALTER TABLE [dbo].[LocaleStringResource]  WITH CHECK ADD  CONSTRAINT [FK_LocaleStringResource_Language] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([Id])
GO
ALTER TABLE [dbo].[LocaleStringResource] CHECK CONSTRAINT [FK_LocaleStringResource_Language]
GO
ALTER TABLE [dbo].[Memberships]  WITH CHECK ADD  CONSTRAINT [MembershipApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Memberships] CHECK CONSTRAINT [MembershipApplication]
GO
ALTER TABLE [dbo].[Memberships]  WITH CHECK ADD  CONSTRAINT [MembershipUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Memberships] CHECK CONSTRAINT [MembershipUser]
GO
ALTER TABLE [dbo].[MessageQueue]  WITH CHECK ADD  CONSTRAINT [FK_MessageQueue_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[MessageStatusType] ([Id])
GO
ALTER TABLE [dbo].[MessageQueue] CHECK CONSTRAINT [FK_MessageQueue_Status]
GO
ALTER TABLE [dbo].[MessageQueue]  WITH CHECK ADD  CONSTRAINT [FK_MessageQueue_Template] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[MessageTemplate] ([Id])
GO
ALTER TABLE [dbo].[MessageQueue] CHECK CONSTRAINT [FK_MessageQueue_Template]
GO
ALTER TABLE [dbo].[MessageTemplate]  WITH CHECK ADD  CONSTRAINT [FK_MessageTemplate_Language] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([Id])
GO
ALTER TABLE [dbo].[MessageTemplate] CHECK CONSTRAINT [FK_MessageTemplate_Language]
GO
ALTER TABLE [dbo].[MessageTemplate]  WITH CHECK ADD  CONSTRAINT [FK_MessageTemplate_MessageProvider] FOREIGN KEY([MessageProviderId])
REFERENCES [dbo].[MessageProvider] ([Id])
GO
ALTER TABLE [dbo].[MessageTemplate] CHECK CONSTRAINT [FK_MessageTemplate_MessageProvider]
GO
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [UserProfile]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_FieldDataType] FOREIGN KEY([FieldDataTypeId])
REFERENCES [dbo].[FieldDataType] ([FieldDataTypeId])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_FieldDataType]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Form] FOREIGN KEY([FormId])
REFERENCES [dbo].[Form] ([FormId])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Form]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_QuestionType] FOREIGN KEY([QuestionTypeId])
REFERENCES [dbo].[QuestionType] ([QuestionTypeId])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_QuestionType]
GO
ALTER TABLE [dbo].[RecreationalDrugOrSubstance]  WITH CHECK ADD  CONSTRAINT [FK_RecreationalDrugOrSubstance_Appointment] FOREIGN KEY([AppointementId])
REFERENCES [dbo].[Appointment] ([AppointmentId])
GO
ALTER TABLE [dbo].[RecreationalDrugOrSubstance] CHECK CONSTRAINT [FK_RecreationalDrugOrSubstance_Appointment]
GO
ALTER TABLE [dbo].[RecreationalDrugOrSubstance]  WITH CHECK ADD  CONSTRAINT [FK_RecreationalDrugOrSubstance_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[RecreationalDrugOrSubstance] CHECK CONSTRAINT [FK_RecreationalDrugOrSubstance_Subject]
GO
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD  CONSTRAINT [RoleApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Roles] CHECK CONSTRAINT [RoleApplication]
GO
ALTER TABLE [dbo].[ScheduleSubjectVisit]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleSubjectVisit_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[ScheduleSubjectVisit] CHECK CONSTRAINT [FK_ScheduleSubjectVisit_Subject]
GO
ALTER TABLE [dbo].[ScheduleSubjectVisit]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleSubjectVisit_Visit] FOREIGN KEY([VisitId])
REFERENCES [dbo].[Visit] ([VisitId])
GO
ALTER TABLE [dbo].[ScheduleSubjectVisit] CHECK CONSTRAINT [FK_ScheduleSubjectVisit_Visit]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK_Subject_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([SiteId])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_Site]
GO
ALTER TABLE [dbo].[SubjectAltNumber]  WITH CHECK ADD  CONSTRAINT [FK_SubjectAltNumber_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[SubjectAltNumber] CHECK CONSTRAINT [FK_SubjectAltNumber_Subject]
GO
ALTER TABLE [dbo].[SubjectDrug]  WITH CHECK ADD  CONSTRAINT [FK_SubjectDrug_Drug] FOREIGN KEY([DrugId])
REFERENCES [dbo].[Drug] ([DrugId])
GO
ALTER TABLE [dbo].[SubjectDrug] CHECK CONSTRAINT [FK_SubjectDrug_Drug]
GO
ALTER TABLE [dbo].[SubjectDrug]  WITH CHECK ADD  CONSTRAINT [FK_SubjectDrug_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[SubjectDrug] CHECK CONSTRAINT [FK_SubjectDrug_Subject]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [UserApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [UserApplication]
GO
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [UsersInRoleRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [UsersInRoleRole]
GO
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [UsersInRoleUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [UsersInRoleUser]
GO
ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [FK_Visit_Arm1] FOREIGN KEY([ArmId])
REFERENCES [dbo].[Arm] ([ArmId])
GO
ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [FK_Visit_Arm1]
GO
ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [RefVisitType32] FOREIGN KEY([VisitTypeId])
REFERENCES [dbo].[VisitType] ([VisitTypeId])
GO
ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [RefVisitType32]
GO
ALTER TABLE [dbo].[VisitForms]  WITH CHECK ADD  CONSTRAINT [FK_VisitForms_Form] FOREIGN KEY([FormId])
REFERENCES [dbo].[Form] ([FormId])
GO
ALTER TABLE [dbo].[VisitForms] CHECK CONSTRAINT [FK_VisitForms_Form]
GO
ALTER TABLE [dbo].[VisitForms]  WITH CHECK ADD  CONSTRAINT [RefVisit26] FOREIGN KEY([VisitId])
REFERENCES [dbo].[Visit] ([VisitId])
GO
ALTER TABLE [dbo].[VisitForms] CHECK CONSTRAINT [RefVisit26]
GO
ALTER TABLE [dbo].[VisitStepMapping]  WITH CHECK ADD  CONSTRAINT [FK_VisitStepMapping_Visit] FOREIGN KEY([VisitId])
REFERENCES [dbo].[Visit] ([VisitId])
GO
ALTER TABLE [dbo].[VisitStepMapping] CHECK CONSTRAINT [FK_VisitStepMapping_Visit]
GO
ALTER TABLE [dbo].[VisitStepMapping]  WITH CHECK ADD  CONSTRAINT [FK_VisitStepMapping_VisitStep] FOREIGN KEY([VisitStepId])
REFERENCES [dbo].[VisitStep] ([VisitStepId])
GO
ALTER TABLE [dbo].[VisitStepMapping] CHECK CONSTRAINT [FK_VisitStepMapping_VisitStep]
GO
ALTER TABLE [dbo].[VisitStepVisitSequence]  WITH CHECK ADD  CONSTRAINT [FK_VisitStepVisitSequence_Visit] FOREIGN KEY([VisitId])
REFERENCES [dbo].[Visit] ([VisitId])
GO
ALTER TABLE [dbo].[VisitStepVisitSequence] CHECK CONSTRAINT [FK_VisitStepVisitSequence_Visit]
GO
ALTER TABLE [dbo].[VisitStepVisitSequence]  WITH CHECK ADD  CONSTRAINT [FK_VisitStepVisitSequence_VisitStep] FOREIGN KEY([VisitStepId])
REFERENCES [dbo].[VisitStep] ([VisitStepId])
GO
ALTER TABLE [dbo].[VisitStepVisitSequence] CHECK CONSTRAINT [FK_VisitStepVisitSequence_VisitStep]
GO
USE [master]
GO
ALTER DATABASE [Tateeda.Clires.v4] SET  READ_WRITE 
GO
