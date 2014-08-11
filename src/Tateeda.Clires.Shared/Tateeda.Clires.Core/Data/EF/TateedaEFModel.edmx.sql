
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/15/2014 23:46:08
-- Generated from EDMX file: C:\dev\TFS\Clires4\Dev\Tateeda.Clires.Shared\Tateeda.Clires.Core\Data\EF\TateedaEFModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Tateeda.Clires.DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Answer_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answer] DROP CONSTRAINT [FK_Answer_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_AnswerChildQuestion_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AnswerChildQuestion] DROP CONSTRAINT [FK_AnswerChildQuestion_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_AnswerChildQuestion_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AnswerChildQuestion] DROP CONSTRAINT [FK_AnswerChildQuestion_Question];
GO
IF OBJECT_ID(N'[dbo].[FK_Appointment_Visit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appointment] DROP CONSTRAINT [FK_Appointment_Visit];
GO
IF OBJECT_ID(N'[dbo].[FK_AppointmentForm_Appointment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AppointmentForm] DROP CONSTRAINT [FK_AppointmentForm_Appointment];
GO
IF OBJECT_ID(N'[dbo].[FK_AppointmentForm_Form]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AppointmentForm] DROP CONSTRAINT [FK_AppointmentForm_Form];
GO
IF OBJECT_ID(N'[dbo].[FK_AppUser_Contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AppUser] DROP CONSTRAINT [FK_AppUser_Contact];
GO
IF OBJECT_ID(N'[dbo].[FK_AppUser_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AppUser] DROP CONSTRAINT [FK_AppUser_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_AppUser_Site]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AppUser] DROP CONSTRAINT [FK_AppUser_Site];
GO
IF OBJECT_ID(N'[dbo].[FK_AppUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AppUser] DROP CONSTRAINT [FK_AppUser_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Arm_Study]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Arm] DROP CONSTRAINT [FK_Arm_Study];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactAddress_Address]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactAddress] DROP CONSTRAINT [FK_ContactAddress_Address];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactAddress_Contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactAddress] DROP CONSTRAINT [FK_ContactAddress_Contact];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactEmail_Contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactEmail] DROP CONSTRAINT [FK_ContactEmail_Contact];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactEmail_Email]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactEmail] DROP CONSTRAINT [FK_ContactEmail_Email];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactPhone_Contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactPhone] DROP CONSTRAINT [FK_ContactPhone_Contact];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactPhone_Phone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactPhone] DROP CONSTRAINT [FK_ContactPhone_Phone];
GO
IF OBJECT_ID(N'[dbo].[FK_CountryState_Country]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CountryState] DROP CONSTRAINT [FK_CountryState_Country];
GO
IF OBJECT_ID(N'[dbo].[FK_CountryState_State]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CountryState] DROP CONSTRAINT [FK_CountryState_State];
GO
IF OBJECT_ID(N'[dbo].[FK_Drug_DrugClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Drug] DROP CONSTRAINT [FK_Drug_DrugClass];
GO
IF OBJECT_ID(N'[dbo].[FK_Drug_Study]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Drug] DROP CONSTRAINT [FK_Drug_Study];
GO
IF OBJECT_ID(N'[dbo].[FK_DrugClass_DrugCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugClass] DROP CONSTRAINT [FK_DrugClass_DrugCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_Form_Study]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Form] DROP CONSTRAINT [FK_Form_Study];
GO
IF OBJECT_ID(N'[dbo].[FK_FormAnswer_AppointmentForm]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormAnswer] DROP CONSTRAINT [FK_FormAnswer_AppointmentForm];
GO
IF OBJECT_ID(N'[dbo].[FK_FormVerificationRequest_Form]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormVerification] DROP CONSTRAINT [FK_FormVerificationRequest_Form];
GO
IF OBJECT_ID(N'[dbo].[FK_FormVisibilityByVisitForSubject_Form]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormVisibilityByVisitForSubject] DROP CONSTRAINT [FK_FormVisibilityByVisitForSubject_Form];
GO
IF OBJECT_ID(N'[dbo].[FK_FormVisibilityByVisitForSubject_Visit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormVisibilityByVisitForSubject] DROP CONSTRAINT [FK_FormVisibilityByVisitForSubject_Visit];
GO
IF OBJECT_ID(N'[Library].[FK_LibraryAnswer_Question]', 'F') IS NOT NULL
    ALTER TABLE [Library].[LibraryAnswer] DROP CONSTRAINT [FK_LibraryAnswer_Question];
GO
IF OBJECT_ID(N'[Library].[FK_LibraryQuestion_FieldDataType]', 'F') IS NOT NULL
    ALTER TABLE [Library].[LibraryQuestion] DROP CONSTRAINT [FK_LibraryQuestion_FieldDataType];
GO
IF OBJECT_ID(N'[Library].[FK_LibraryQuestion_Form]', 'F') IS NOT NULL
    ALTER TABLE [Library].[LibraryQuestion] DROP CONSTRAINT [FK_LibraryQuestion_Form];
GO
IF OBJECT_ID(N'[dbo].[FK_LocaleStringResource_Language]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LocaleStringResource] DROP CONSTRAINT [FK_LocaleStringResource_Language];
GO
IF OBJECT_ID(N'[dbo].[FK_MessageQueue_Template]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageQueue] DROP CONSTRAINT [FK_MessageQueue_Template];
GO
IF OBJECT_ID(N'[dbo].[FK_MessageTemplate_Language]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageTemplate] DROP CONSTRAINT [FK_MessageTemplate_Language];
GO
IF OBJECT_ID(N'[dbo].[FK_MessageTemplate_MessageProvider]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageTemplate] DROP CONSTRAINT [FK_MessageTemplate_MessageProvider];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationStudy_Organization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationStudy] DROP CONSTRAINT [FK_OrganizationStudy_Organization];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationStudy_Study]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationStudy] DROP CONSTRAINT [FK_OrganizationStudy_Study];
GO
IF OBJECT_ID(N'[dbo].[FK_Question_FieldDataType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question] DROP CONSTRAINT [FK_Question_FieldDataType];
GO
IF OBJECT_ID(N'[dbo].[FK_Question_Form]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question] DROP CONSTRAINT [FK_Question_Form];
GO
IF OBJECT_ID(N'[dbo].[FK_RecreationalDrugOrSubstance_Appointment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecreationalDrugOrSubstance] DROP CONSTRAINT [FK_RecreationalDrugOrSubstance_Appointment];
GO
IF OBJECT_ID(N'[dbo].[FK_ScheduleSubjectVisit_Visit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduleSubjectVisit] DROP CONSTRAINT [FK_ScheduleSubjectVisit_Visit];
GO
IF OBJECT_ID(N'[dbo].[FK_Site_TimeZone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Site] DROP CONSTRAINT [FK_Site_TimeZone];
GO
IF OBJECT_ID(N'[dbo].[FK_StudyFile_File]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudyFile] DROP CONSTRAINT [FK_StudyFile_File];
GO
IF OBJECT_ID(N'[dbo].[FK_StudyFile_Study]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudyFile] DROP CONSTRAINT [FK_StudyFile_Study];
GO
IF OBJECT_ID(N'[dbo].[FK_StudySetupMap_StudySetupSteps]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudySetupMap] DROP CONSTRAINT [FK_StudySetupMap_StudySetupSteps];
GO
IF OBJECT_ID(N'[dbo].[FK_StudySite_Site]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudySite] DROP CONSTRAINT [FK_StudySite_Site];
GO
IF OBJECT_ID(N'[dbo].[FK_StudySite_Study]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudySite] DROP CONSTRAINT [FK_StudySite_Study];
GO
IF OBJECT_ID(N'[dbo].[FK_Subject_Contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subject] DROP CONSTRAINT [FK_Subject_Contact];
GO
IF OBJECT_ID(N'[dbo].[FK_Subject_Site]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subject] DROP CONSTRAINT [FK_Subject_Site];
GO
IF OBJECT_ID(N'[dbo].[FK_Subject_StudyId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subject] DROP CONSTRAINT [FK_Subject_StudyId];
GO
IF OBJECT_ID(N'[dbo].[FK_SubjectDrug_Drug]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubjectDrug] DROP CONSTRAINT [FK_SubjectDrug_Drug];
GO
IF OBJECT_ID(N'[dbo].[FK_SubjectDrug_SubjectId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubjectDrug] DROP CONSTRAINT [FK_SubjectDrug_SubjectId];
GO
IF OBJECT_ID(N'[dbo].[FK_SubjectFile_File]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubjectFile] DROP CONSTRAINT [FK_SubjectFile_File];
GO
IF OBJECT_ID(N'[dbo].[FK_SubjectFile_Subject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubjectFile] DROP CONSTRAINT [FK_SubjectFile_Subject];
GO
IF OBJECT_ID(N'[dbo].[FK_UserSettings_AppUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSettings] DROP CONSTRAINT [FK_UserSettings_AppUser];
GO
IF OBJECT_ID(N'[dbo].[FK_Visit_Arm]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Visit] DROP CONSTRAINT [FK_Visit_Arm];
GO
IF OBJECT_ID(N'[dbo].[FK_Visit_ParentVisit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Visit] DROP CONSTRAINT [FK_Visit_ParentVisit];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitForms_Form]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VisitForms] DROP CONSTRAINT [FK_VisitForms_Form];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitStep_Arm]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VisitStep] DROP CONSTRAINT [FK_VisitStep_Arm];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitStepMapping_Visit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VisitStepMapping] DROP CONSTRAINT [FK_VisitStepMapping_Visit];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitStepMapping_VisitStep]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VisitStepMapping] DROP CONSTRAINT [FK_VisitStepMapping_VisitStep];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitStepVisitSequence_Visit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VisitStepVisitSequence] DROP CONSTRAINT [FK_VisitStepVisitSequence_Visit];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitStepVisitSequence_VisitStep]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VisitStepVisitSequence] DROP CONSTRAINT [FK_VisitStepVisitSequence_VisitStep];
GO
IF OBJECT_ID(N'[dbo].[FK_MembershipUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Memberships] DROP CONSTRAINT [FK_MembershipUser];
GO
IF OBJECT_ID(N'[dbo].[FK_RefVisit26]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VisitForms] DROP CONSTRAINT [FK_RefVisit26];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Profiles] DROP CONSTRAINT [FK_UserProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersInRoleRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersInRoles] DROP CONSTRAINT [FK_UsersInRoleRole];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersInRoleUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersInRoles] DROP CONSTRAINT [FK_UsersInRoleUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address];
GO
IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[AnswerChildQuestion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AnswerChildQuestion];
GO
IF OBJECT_ID(N'[dbo].[Appointment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Appointment];
GO
IF OBJECT_ID(N'[dbo].[AppointmentForm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AppointmentForm];
GO
IF OBJECT_ID(N'[dbo].[AppUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AppUser];
GO
IF OBJECT_ID(N'[dbo].[Arm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Arm];
GO
IF OBJECT_ID(N'[dbo].[Code]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Code];
GO
IF OBJECT_ID(N'[dbo].[Contact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contact];
GO
IF OBJECT_ID(N'[dbo].[ContactAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactAddress];
GO
IF OBJECT_ID(N'[dbo].[ContactEmail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactEmail];
GO
IF OBJECT_ID(N'[dbo].[ContactPhone]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactPhone];
GO
IF OBJECT_ID(N'[dbo].[Country]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Country];
GO
IF OBJECT_ID(N'[dbo].[CountryState]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CountryState];
GO
IF OBJECT_ID(N'[dbo].[CssType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CssType];
GO
IF OBJECT_ID(N'[dbo].[CTGovSubmission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CTGovSubmission];
GO
IF OBJECT_ID(N'[dbo].[Drug]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Drug];
GO
IF OBJECT_ID(N'[dbo].[DrugCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DrugCategory];
GO
IF OBJECT_ID(N'[dbo].[DrugClass]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DrugClass];
GO
IF OBJECT_ID(N'[dbo].[Email]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Email];
GO
IF OBJECT_ID(N'[TateedaCliresDBModelStoreContainer].[ErrorLog]', 'U') IS NOT NULL
    DROP TABLE [TateedaCliresDBModelStoreContainer].[ErrorLog];
GO
IF OBJECT_ID(N'[dbo].[Feedback]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Feedback];
GO
IF OBJECT_ID(N'[dbo].[File]', 'U') IS NOT NULL
    DROP TABLE [dbo].[File];
GO
IF OBJECT_ID(N'[dbo].[Form]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Form];
GO
IF OBJECT_ID(N'[dbo].[FormAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormAnswer];
GO
IF OBJECT_ID(N'[dbo].[FormInProcess]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormInProcess];
GO
IF OBJECT_ID(N'[dbo].[FormQuestionAnswerImport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormQuestionAnswerImport];
GO
IF OBJECT_ID(N'[dbo].[FormVerification]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormVerification];
GO
IF OBJECT_ID(N'[dbo].[FormVisibilityByVisitForSubject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormVisibilityByVisitForSubject];
GO
IF OBJECT_ID(N'[dbo].[Language]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Language];
GO
IF OBJECT_ID(N'[dbo].[LocaleStringResource]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocaleStringResource];
GO
IF OBJECT_ID(N'[dbo].[Memberships]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Memberships];
GO
IF OBJECT_ID(N'[dbo].[MessageProvider]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MessageProvider];
GO
IF OBJECT_ID(N'[dbo].[MessageQueue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MessageQueue];
GO
IF OBJECT_ID(N'[dbo].[MessageTemplate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MessageTemplate];
GO
IF OBJECT_ID(N'[dbo].[Organization]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Organization];
GO
IF OBJECT_ID(N'[dbo].[OrganizationStudy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationStudy];
GO
IF OBJECT_ID(N'[dbo].[Phone]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Phone];
GO
IF OBJECT_ID(N'[dbo].[Profiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profiles];
GO
IF OBJECT_ID(N'[dbo].[Question]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question];
GO
IF OBJECT_ID(N'[dbo].[RecreationalDrugOrSubstance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecreationalDrugOrSubstance];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[ScheduleSubjectVisit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScheduleSubjectVisit];
GO
IF OBJECT_ID(N'[dbo].[Settings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Settings];
GO
IF OBJECT_ID(N'[dbo].[Site]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Site];
GO
IF OBJECT_ID(N'[dbo].[State]', 'U') IS NOT NULL
    DROP TABLE [dbo].[State];
GO
IF OBJECT_ID(N'[dbo].[Study]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Study];
GO
IF OBJECT_ID(N'[dbo].[StudyFile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudyFile];
GO
IF OBJECT_ID(N'[dbo].[StudySetupMap]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudySetupMap];
GO
IF OBJECT_ID(N'[dbo].[StudySetupSteps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudySetupSteps];
GO
IF OBJECT_ID(N'[dbo].[StudySite]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudySite];
GO
IF OBJECT_ID(N'[dbo].[Subject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subject];
GO
IF OBJECT_ID(N'[dbo].[SubjectAltNumber]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubjectAltNumber];
GO
IF OBJECT_ID(N'[dbo].[SubjectDrug]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubjectDrug];
GO
IF OBJECT_ID(N'[TateedaCliresDBModelStoreContainer].[SubjectDrugHistory]', 'U') IS NOT NULL
    DROP TABLE [TateedaCliresDBModelStoreContainer].[SubjectDrugHistory];
GO
IF OBJECT_ID(N'[dbo].[SubjectFile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubjectFile];
GO
IF OBJECT_ID(N'[dbo].[TimeZone]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeZone];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[UserSettings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSettings];
GO
IF OBJECT_ID(N'[dbo].[UsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersInRoles];
GO
IF OBJECT_ID(N'[dbo].[Visit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Visit];
GO
IF OBJECT_ID(N'[dbo].[VisitForms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VisitForms];
GO
IF OBJECT_ID(N'[dbo].[VisitStep]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VisitStep];
GO
IF OBJECT_ID(N'[dbo].[VisitStepMapping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VisitStepMapping];
GO
IF OBJECT_ID(N'[dbo].[VisitStepVisitSequence]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VisitStepVisitSequence];
GO
IF OBJECT_ID(N'[Library].[LibraryAnswer]', 'U') IS NOT NULL
    DROP TABLE [Library].[LibraryAnswer];
GO
IF OBJECT_ID(N'[Library].[LibraryForm]', 'U') IS NOT NULL
    DROP TABLE [Library].[LibraryForm];
GO
IF OBJECT_ID(N'[Library].[LibraryQuestion]', 'U') IS NOT NULL
    DROP TABLE [Library].[LibraryQuestion];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AddressTypeId] int  NOT NULL,
    [Street] nvarchar(250)  NULL,
    [City] nvarchar(100)  NULL,
    [PostalCode] nvarchar(50)  NULL,
    [StateId] int  NULL,
    [CountryId] int  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Appointments'
CREATE TABLE [dbo].[Appointments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SubjectId] int  NOT NULL,
    [VisitId] int  NOT NULL,
    [SiteId] int  NOT NULL,
    [AppUserId] int  NOT NULL,
    [Title] nvarchar(200)  NULL,
    [Location] nvarchar(200)  NULL,
    [Description] nvarchar(2000)  NULL,
    [StartDate] datetime  NOT NULL,
    [StartTime] time  NULL,
    [EndDate] datetime  NOT NULL,
    [EndTime] time  NULL,
    [Status] int  NOT NULL,
    [CreatedBy] nvarchar(100)  NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL,
    [VisitStepId] int  NOT NULL
);
GO

-- Creating table 'AppointmentForms'
CREATE TABLE [dbo].[AppointmentForms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FormId] int  NOT NULL,
    [AppointmentId] int  NOT NULL,
    [FormStatusTypeId] int  NOT NULL,
    [Notes] nvarchar(max)  NULL,
    [Comments] nvarchar(max)  NULL,
    [TotalScore] int  NOT NULL,
    [Status] int  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [SortOrder] int  NOT NULL,
    [CreatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'AppUsers'
CREATE TABLE [dbo].[AppUsers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MembershipUserId] uniqueidentifier  NOT NULL,
    [SiteId] int  NOT NULL,
    [RoleId] uniqueidentifier  NOT NULL,
    [ContactId] int  NOT NULL,
    [Title] varchar(100)  NULL,
    [SortOrder] int  NOT NULL,
    [Comments] nvarchar(max)  NULL,
    [Status] int  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedOn] datetime  NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [CreatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Arms'
CREATE TABLE [dbo].[Arms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudyId] int  NOT NULL,
    [Code] nvarchar(50)  NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(1000)  NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Codes'
CREATE TABLE [dbo].[Codes] (
    [Id] int  NOT NULL,
    [CodeTypeId] int  NOT NULL,
    [EnumId] int  NOT NULL,
    [Name] nvarchar(64)  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [CreatedOn] datetime  NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ContactTypeId] int  NOT NULL,
    [FirstName] nvarchar(100)  NULL,
    [MiddleName] nvarchar(50)  NULL,
    [LastName] nvarchar(100)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [Id] int  NOT NULL,
    [Abbr] nvarchar(80)  NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Iso3] char(3)  NULL,
    [FlagImgUrl] nvarchar(max)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'CssTypes'
CREATE TABLE [dbo].[CssTypes] (
    [Id] int  NOT NULL,
    [CssClassName] nvarchar(100)  NULL,
    [InputType] nvarchar(50)  NOT NULL,
    [Html] nvarchar(max)  NULL
);
GO

-- Creating table 'CTGovSubmissions'
CREATE TABLE [dbo].[CTGovSubmissions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(250)  NOT NULL,
    [SubmissionXML] nvarchar(max)  NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [CreatedOn] datetime  NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Drugs'
CREATE TABLE [dbo].[Drugs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DrugClassId] int  NOT NULL,
    [DrugTypeId] int  NULL,
    [StudyId] int  NOT NULL,
    [Name] nvarchar(500)  NOT NULL,
    [Directions] nvarchar(500)  NULL,
    [Status] int  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [CreatedOn] datetime  NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'DrugCategories'
CREATE TABLE [dbo].[DrugCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(64)  NOT NULL,
    [Code] nvarchar(32)  NULL,
    [Directions] nvarchar(500)  NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'DrugClasses'
CREATE TABLE [dbo].[DrugClasses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DrugCategoryId] int  NOT NULL,
    [Name] nvarchar(64)  NULL,
    [Directions] nvarchar(500)  NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Emails'
CREATE TABLE [dbo].[Emails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(250)  NOT NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'FormAnswers'
CREATE TABLE [dbo].[FormAnswers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AppointmentFormId] int  NOT NULL,
    [AnswerId] int  NOT NULL,
    [QuestionId] int  NOT NULL,
    [FreeTextAnswer] nvarchar(max)  NULL,
    [Notes] nvarchar(max)  NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL
);
GO

-- Creating table 'FormVisibilityByVisitForSubjects'
CREATE TABLE [dbo].[FormVisibilityByVisitForSubjects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FormId] int  NOT NULL,
    [VisitId] int  NOT NULL,
    [DaysPriorToVisit] int  NOT NULL,
    [DaysAfterVisit] int  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Languages'
CREATE TABLE [dbo].[Languages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [LanguageCulture] nvarchar(20)  NOT NULL,
    [UniqueSeoCode] nvarchar(2)  NULL,
    [FlagImageFileName] nvarchar(50)  NULL,
    [Published] bit  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'LocaleStringResources'
CREATE TABLE [dbo].[LocaleStringResources] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LanguageId] int  NOT NULL,
    [ResourceName] nvarchar(200)  NOT NULL,
    [ResourceValue] nvarchar(1000)  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Memberships'
CREATE TABLE [dbo].[Memberships] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ApplicationId] uniqueidentifier  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [Password] nvarchar(128)  NOT NULL,
    [PasswordFormat] int  NOT NULL,
    [PasswordSalt] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [PasswordQuestion] nvarchar(256)  NULL,
    [PasswordAnswer] nvarchar(128)  NULL,
    [IsApproved] bit  NOT NULL,
    [IsLockedOut] bit  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [LastLoginDate] datetime  NOT NULL,
    [LastPasswordChangedDate] datetime  NOT NULL,
    [LastLockoutDate] datetime  NOT NULL,
    [FailedPasswordAttemptCount] int  NOT NULL,
    [FailedPasswordAttemptWindowStart] datetime  NOT NULL,
    [FailedPasswordAnswerAttemptCount] int  NOT NULL,
    [FailedPasswordAnswerAttemptWindowsStart] datetime  NOT NULL,
    [Comment] nvarchar(256)  NULL
);
GO

-- Creating table 'MessageProviders'
CREATE TABLE [dbo].[MessageProviders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [LicenseKey] nvarchar(1000)  NULL,
    [AccountName] nvarchar(200)  NULL,
    [AccountPassword] nvarchar(100)  NULL,
    [ServiceUri] nvarchar(max)  NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'MessageQueues'
CREATE TABLE [dbo].[MessageQueues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TemplateId] int  NOT NULL,
    [PriorityId] int  NOT NULL,
    [Data] nvarchar(max)  NULL,
    [RecipientId] int  NOT NULL,
    [SenderId] int  NOT NULL,
    [StatusId] int  NOT NULL,
    [QueuedOn] datetime  NOT NULL,
    [LastProcessedOn] datetime  NULL,
    [TriesCount] int  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'MessageTemplates'
CREATE TABLE [dbo].[MessageTemplates] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [BccEmailAddresses] nvarchar(200)  NULL,
    [Subject] nvarchar(1000)  NULL,
    [Body] nvarchar(max)  NULL,
    [LanguageId] int  NOT NULL,
    [MessageProviderId] int  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Profiles'
CREATE TABLE [dbo].[Profiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [PropertyNames] nvarchar(4000)  NOT NULL,
    [PropertyValueStrings] nvarchar(4000)  NOT NULL,
    [PropertyValueBinary] varbinary(max)  NOT NULL,
    [LastUpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'RecreationalDrugOrSubstances'
CREATE TABLE [dbo].[RecreationalDrugOrSubstances] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [SubjectId] int  NOT NULL,
    [Dose] nvarchar(50)  NULL,
    [Unit] nvarchar(20)  NULL,
    [Frequency] int  NULL,
    [FrequencyUnit] nvarchar(20)  NULL,
    [TypeName] nvarchar(50)  NULL,
    [UseStartDate] datetime  NULL,
    [UseEndDate] datetime  NULL,
    [AppointementId] int  NULL,
    [Comments] varchar(500)  NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ApplicationId] uniqueidentifier  NOT NULL,
    [RoleId] uniqueidentifier  NOT NULL,
    [RoleName] nvarchar(256)  NOT NULL,
    [Description] nvarchar(256)  NULL
);
GO

-- Creating table 'ScheduleSubjectVisits'
CREATE TABLE [dbo].[ScheduleSubjectVisits] (
    [SubjectId] int  NOT NULL,
    [VisitId] int  NOT NULL
);
GO

-- Creating table 'Sites'
CREATE TABLE [dbo].[Sites] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Code] nvarchar(32)  NULL,
    [TimeZoneId] int  NOT NULL,
    [IsPrimary] bit  NOT NULL,
    [Directions] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'States'
CREATE TABLE [dbo].[States] (
    [Id] int  NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Abbr] char(2)  NOT NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Studies'
CREATE TABLE [dbo].[Studies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NULL,
    [Description] nvarchar(500)  NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NULL,
    [Target] nvarchar(max)  NULL,
    [Goal] nvarchar(max)  NULL,
    [Budget] decimal(19,4)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'SubjectDrugs'
CREATE TABLE [dbo].[SubjectDrugs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SubjectId] int  NOT NULL,
    [DrugId] int  NOT NULL,
    [AppointmentId] int  NOT NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [MultipleTrialsId] int  NULL,
    [DurationUsed] int  NULL,
    [ReasonStoppedId] int  NOT NULL,
    [ReasonTypeId] int  NOT NULL,
    [TreatmentInducedId] int  NOT NULL,
    [DosageFrequencyId] int  NOT NULL,
    [IsCurrent] bit  NOT NULL,
    [IsChanged] bit  NOT NULL,
    [IsStopped] bit  NOT NULL,
    [IsBeforeStudy] bit  NOT NULL,
    [Dosage] nvarchar(200)  NULL,
    [DosageType] nvarchar(200)  NULL,
    [Notes] nvarchar(1000)  NULL,
    [MdNotes] nvarchar(max)  NULL,
    [Comments] nvarchar(max)  NULL,
    [Directions] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'TimeZones'
CREATE TABLE [dbo].[TimeZones] (
    [Id] int  NOT NULL,
    [Name] nvarchar(100)  NULL,
    [Description] nvarchar(500)  NULL,
    [Offset] decimal(18,2)  NOT NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ApplicationId] uniqueidentifier  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [IsAnonymous] bit  NOT NULL,
    [LastActivityDate] datetime  NOT NULL
);
GO

-- Creating table 'VisitForms'
CREATE TABLE [dbo].[VisitForms] (
    [VisitId] int  NOT NULL,
    [FormId] int  NOT NULL,
    [SortOrder] int  NULL
);
GO

-- Creating table 'Answers'
CREATE TABLE [dbo].[Answers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [QuestionId] int  NOT NULL,
    [OptionText] nvarchar(1000)  NOT NULL,
    [Code] nvarchar(32)  NULL,
    [Score] int  NULL,
    [Header] nvarchar(200)  NULL,
    [Trailer] nvarchar(200)  NULL,
    [Directions] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'AnswerChildQuestions'
CREATE TABLE [dbo].[AnswerChildQuestions] (
    [AnswerId] int  NOT NULL,
    [QuestionId] int  NOT NULL,
    [IsActive] bit  NULL
);
GO

-- Creating table 'Visits'
CREATE TABLE [dbo].[Visits] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [VisitTypeId] int  NOT NULL,
    [ArmId] int  NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Code] nvarchar(32)  NULL,
    [Directions] nvarchar(500)  NULL,
    [ParentVisitId] int  NULL,
    [IsBaseVisit] bit  NOT NULL,
    [CanRepeat] bit  NOT NULL,
    [CanMove] bit  NOT NULL,
    [HasChild] bit  NOT NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Forms'
CREATE TABLE [dbo].[Forms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudyId] int  NOT NULL,
    [Name] nvarchar(64)  NOT NULL,
    [Code] nvarchar(32)  NULL,
    [FormTypeId] int  NOT NULL,
    [Title] nvarchar(500)  NULL,
    [Directions] nvarchar(1000)  NULL,
    [Header] nvarchar(1000)  NULL,
    [Trailer] nvarchar(1000)  NULL,
    [IsFilledBySubject] bit  NOT NULL,
    [ShowTotalScore] bit  NOT NULL,
    [LayoutTypeId] int  NOT NULL,
    [IsDoubleChecked] bit  NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL,
    [NotifyOnChange] bit  NOT NULL,
    [NotifyOnCompletion] bit  NOT NULL
);
GO

-- Creating table 'FormVerifications'
CREATE TABLE [dbo].[FormVerifications] (
    [Id] int  NOT NULL,
    [FormId] int  NOT NULL,
    [VerifiedBy] nvarchar(100)  NULL,
    [VerifiedOn] datetime  NULL,
    [ResultStatus] int  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'Questions'
CREATE TABLE [dbo].[Questions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FormId] int  NOT NULL,
    [FieldDataTypeId] int  NOT NULL,
    [QuestionText] nvarchar(max)  NOT NULL,
    [Code] nvarchar(32)  NULL,
    [Directions] nvarchar(1000)  NULL,
    [Header] nvarchar(1000)  NULL,
    [Trailer] nvarchar(1000)  NULL,
    [IsRequired] bit  NOT NULL,
    [ParentQuestionId] int  NULL,
    [IsParent] bit  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL,
    [ValidationRule] nvarchar(max)  NULL
);
GO

-- Creating table 'VisitSteps'
CREATE TABLE [dbo].[VisitSteps] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [ArmId] int  NOT NULL,
    [Directions] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'VisitStepVisitSequences'
CREATE TABLE [dbo].[VisitStepVisitSequences] (
    [VisitStepId] int  NOT NULL,
    [VisitId] int  NOT NULL,
    [DaysFromBase] int  NOT NULL,
    [IsActive] bit  NOT NULL,
    [Deviation] int  NOT NULL,
    [SortOrder] int  NOT NULL,
    [IsTermination] bit  NOT NULL
);
GO

-- Creating table 'Settings'
CREATE TABLE [dbo].[Settings] (
    [Id] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Value] nvarchar(50)  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'SubjectAltNumbers'
CREATE TABLE [dbo].[SubjectAltNumbers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SubjectId] int  NOT NULL,
    [AltId] nvarchar(100)  NOT NULL,
    [Description] nvarchar(250)  NULL,
    [Comment] nvarchar(max)  NULL,
    [Directions] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Phones'
CREATE TABLE [dbo].[Phones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CountryCode] nvarchar(10)  NOT NULL,
    [AreaCode] int  NOT NULL,
    [Number] int  NOT NULL,
    [Telephone] nvarchar(50)  NULL,
    [PhoneTypeId] int  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Feedbacks'
CREATE TABLE [dbo].[Feedbacks] (
    [Id] int  NOT NULL,
    [Uri] nvarchar(500)  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [LikeScore] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [CreatedBy] nvarchar(100)  NULL
);
GO

-- Creating table 'Subjects'
CREATE TABLE [dbo].[Subjects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SiteId] int  NOT NULL,
    [ContactId] int  NOT NULL,
    [StudyId] int  NOT NULL,
    [Nickname] nvarchar(100)  NULL,
    [FamilyId] nvarchar(100)  NULL,
    [Notes] nvarchar(1000)  NULL,
    [NIMHID] nvarchar(100)  NULL,
    [GenderTypeId] int  NOT NULL,
    [YearBorn] int  NOT NULL,
    [DateOfBirth] nvarchar(50)  NULL,
    [SSN] nvarchar(40)  NULL,
    [SSNEnc] varbinary(256)  NULL,
    [FirstNameEnc] varbinary(256)  NULL,
    [LastNameEnc] varbinary(256)  NULL,
    [DateOfBirthEnc] varbinary(256)  NULL,
    [Directions] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'SubjectDrugHistories'
CREATE TABLE [dbo].[SubjectDrugHistories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SubjectDrugId] int  NOT NULL,
    [SubjectId] int  NOT NULL,
    [DrugId] int  NOT NULL,
    [AppointmentId] int  NOT NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [MultipleTrialsId] int  NULL,
    [DurationUsed] int  NULL,
    [ReasonStoppedId] int  NOT NULL,
    [ReasonTypeId] int  NOT NULL,
    [TreatmentInducedId] int  NOT NULL,
    [DosageFrequencyId] int  NOT NULL,
    [IsCurrent] bit  NOT NULL,
    [IsChanged] bit  NOT NULL,
    [IsStopped] bit  NOT NULL,
    [IsBeforeStudy] bit  NOT NULL,
    [Dosage] nvarchar(200)  NULL,
    [DosageType] nvarchar(200)  NULL,
    [Notes] nvarchar(1000)  NULL,
    [MdNotes] nvarchar(max)  NULL,
    [Comments] nvarchar(max)  NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [SavedOn] datetime  NOT NULL
);
GO

-- Creating table 'LibraryAnswers'
CREATE TABLE [dbo].[LibraryAnswers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [QuestionId] int  NOT NULL,
    [OptionText] nvarchar(1000)  NOT NULL,
    [Code] nvarchar(32)  NULL,
    [Score] int  NULL,
    [Header] nvarchar(200)  NULL,
    [Trailer] nvarchar(200)  NULL,
    [Directions] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'LibraryForms'
CREATE TABLE [dbo].[LibraryForms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(64)  NOT NULL,
    [Code] nvarchar(32)  NULL,
    [FormTypeId] int  NOT NULL,
    [Title] nvarchar(500)  NULL,
    [Directions] nvarchar(1000)  NULL,
    [Header] nvarchar(1000)  NULL,
    [Trailer] nvarchar(1000)  NULL,
    [IsFilledBySubject] bit  NOT NULL,
    [ShowTotalScore] bit  NOT NULL,
    [LayoutTypeId] int  NOT NULL,
    [IsDoubleChecked] bit  NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'LibraryQuestions'
CREATE TABLE [dbo].[LibraryQuestions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LibraryFormId] int  NOT NULL,
    [FieldDataTypeId] int  NOT NULL,
    [QuestionText] nvarchar(max)  NOT NULL,
    [Code] nvarchar(32)  NULL,
    [Directions] nvarchar(1000)  NULL,
    [Header] nvarchar(1000)  NULL,
    [Trailer] nvarchar(1000)  NULL,
    [IsRequired] bit  NOT NULL,
    [ParentQuestionId] int  NULL,
    [IsParent] bit  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [SortOrder] int  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [Id] int  NOT NULL,
    [FileGuid] uniqueidentifier  NOT NULL,
    [Name] nvarchar(500)  NOT NULL,
    [FileType] nvarchar(100)  NOT NULL,
    [FielContent] varbinary(max)  NOT NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'FormInProcesses'
CREATE TABLE [dbo].[FormInProcesses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FormId] int  NOT NULL,
    [SubjectId] int  NOT NULL,
    [AppUserId] int  NOT NULL,
    [IsLocked] bit  NOT NULL,
    [OpenendOn] datetime  NOT NULL,
    [ReleasedOn] datetime  NULL,
    [MaxLockTimeMin] int  NOT NULL,
    [UnlockedByAppUserId] int  NOT NULL
);
GO

-- Creating table 'ErrorLogs'
CREATE TABLE [dbo].[ErrorLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Message] nvarchar(max)  NULL,
    [StackTrace] nvarchar(max)  NULL,
    [CreatedOn] datetime  NULL
);
GO

-- Creating table 'Organizations'
CREATE TABLE [dbo].[Organizations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NOT NULL,
    [Description] nvarchar(1000)  NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'StudySetupMaps'
CREATE TABLE [dbo].[StudySetupMaps] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrganizationId] int  NULL,
    [StudyId] int  NULL,
    [StudySetupStepId] int  NULL,
    [StepSetupStatus] int  NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [UpdatedBy] nvarchar(50)  NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'StudySetupSteps'
CREATE TABLE [dbo].[StudySetupSteps] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrganizationId] int  NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ContextUrl] nvarchar(max)  NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [UpdatedBy] nvarchar(50)  NULL,
    [CreatedOn] nchar(10)  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [IsActive] bit  NULL,
    [SortOrder] int  NULL
);
GO

-- Creating table 'FormQuestionAnswerImports'
CREATE TABLE [dbo].[FormQuestionAnswerImports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FormId] int  NOT NULL,
    [FormName] nvarchar(max)  NOT NULL,
    [title] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [FormType] int  NOT NULL,
    [QuestionId] int  NOT NULL,
    [QuestionText] nvarchar(max)  NOT NULL,
    [QuestionTypeId] int  NOT NULL,
    [AnswerId] int  NOT NULL,
    [AnswerText] nvarchar(1000)  NOT NULL
);
GO

-- Creating table 'UserSettings'
CREATE TABLE [dbo].[UserSettings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AppUserId] int  NOT NULL,
    [SettingName] nvarchar(255)  NOT NULL,
    [SettingValue] nvarchar(max)  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [UpdatedBy] nvarchar(100)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'ContactAddress'
CREATE TABLE [dbo].[ContactAddress] (
    [Addresses_Id] int  NOT NULL,
    [Contacts_Id] int  NOT NULL
);
GO

-- Creating table 'ContactEmail'
CREATE TABLE [dbo].[ContactEmail] (
    [Contacts_Id] int  NOT NULL,
    [Emails_Id] int  NOT NULL
);
GO

-- Creating table 'CountryState'
CREATE TABLE [dbo].[CountryState] (
    [Countries_Id] int  NOT NULL,
    [States_Id] int  NOT NULL
);
GO

-- Creating table 'StudySite'
CREATE TABLE [dbo].[StudySite] (
    [Sites_Id] int  NOT NULL,
    [Studies_Id] int  NOT NULL
);
GO

-- Creating table 'UsersInRoles'
CREATE TABLE [dbo].[UsersInRoles] (
    [Roles_RoleId] uniqueidentifier  NOT NULL,
    [Users_UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'VisitStepMapping'
CREATE TABLE [dbo].[VisitStepMapping] (
    [Visits_Id] int  NOT NULL,
    [VisitSteps_Id] int  NOT NULL
);
GO

-- Creating table 'ContactPhone'
CREATE TABLE [dbo].[ContactPhone] (
    [Contacts_Id] int  NOT NULL,
    [Phones_Id] int  NOT NULL
);
GO

-- Creating table 'StudyFile'
CREATE TABLE [dbo].[StudyFile] (
    [Files_FileGuid] uniqueidentifier  NOT NULL,
    [Studies_Id] int  NOT NULL
);
GO

-- Creating table 'SubjectFile'
CREATE TABLE [dbo].[SubjectFile] (
    [Files_FileGuid] uniqueidentifier  NOT NULL,
    [Subjects_Id] int  NOT NULL
);
GO

-- Creating table 'OrganizationStudy'
CREATE TABLE [dbo].[OrganizationStudy] (
    [Organizations_Id] int  NOT NULL,
    [Studies_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [PK_Appointments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AppointmentForms'
ALTER TABLE [dbo].[AppointmentForms]
ADD CONSTRAINT [PK_AppointmentForms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AppUsers'
ALTER TABLE [dbo].[AppUsers]
ADD CONSTRAINT [PK_AppUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Arms'
ALTER TABLE [dbo].[Arms]
ADD CONSTRAINT [PK_Arms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Codes'
ALTER TABLE [dbo].[Codes]
ADD CONSTRAINT [PK_Codes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CssTypes'
ALTER TABLE [dbo].[CssTypes]
ADD CONSTRAINT [PK_CssTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CTGovSubmissions'
ALTER TABLE [dbo].[CTGovSubmissions]
ADD CONSTRAINT [PK_CTGovSubmissions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Drugs'
ALTER TABLE [dbo].[Drugs]
ADD CONSTRAINT [PK_Drugs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DrugCategories'
ALTER TABLE [dbo].[DrugCategories]
ADD CONSTRAINT [PK_DrugCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DrugClasses'
ALTER TABLE [dbo].[DrugClasses]
ADD CONSTRAINT [PK_DrugClasses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [PK_Emails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AppointmentFormId], [AnswerId], [QuestionId] in table 'FormAnswers'
ALTER TABLE [dbo].[FormAnswers]
ADD CONSTRAINT [PK_FormAnswers]
    PRIMARY KEY CLUSTERED ([AppointmentFormId], [AnswerId], [QuestionId] ASC);
GO

-- Creating primary key on [FormId], [VisitId] in table 'FormVisibilityByVisitForSubjects'
ALTER TABLE [dbo].[FormVisibilityByVisitForSubjects]
ADD CONSTRAINT [PK_FormVisibilityByVisitForSubjects]
    PRIMARY KEY CLUSTERED ([FormId], [VisitId] ASC);
GO

-- Creating primary key on [Id] in table 'Languages'
ALTER TABLE [dbo].[Languages]
ADD CONSTRAINT [PK_Languages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocaleStringResources'
ALTER TABLE [dbo].[LocaleStringResources]
ADD CONSTRAINT [PK_LocaleStringResources]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'Memberships'
ALTER TABLE [dbo].[Memberships]
ADD CONSTRAINT [PK_Memberships]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Id] in table 'MessageProviders'
ALTER TABLE [dbo].[MessageProviders]
ADD CONSTRAINT [PK_MessageProviders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MessageQueues'
ALTER TABLE [dbo].[MessageQueues]
ADD CONSTRAINT [PK_MessageQueues]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MessageTemplates'
ALTER TABLE [dbo].[MessageTemplates]
ADD CONSTRAINT [PK_MessageTemplates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [PK_Profiles]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Id] in table 'RecreationalDrugOrSubstances'
ALTER TABLE [dbo].[RecreationalDrugOrSubstances]
ADD CONSTRAINT [PK_RecreationalDrugOrSubstances]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [RoleId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [SubjectId], [VisitId] in table 'ScheduleSubjectVisits'
ALTER TABLE [dbo].[ScheduleSubjectVisits]
ADD CONSTRAINT [PK_ScheduleSubjectVisits]
    PRIMARY KEY CLUSTERED ([SubjectId], [VisitId] ASC);
GO

-- Creating primary key on [Id] in table 'Sites'
ALTER TABLE [dbo].[Sites]
ADD CONSTRAINT [PK_Sites]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'States'
ALTER TABLE [dbo].[States]
ADD CONSTRAINT [PK_States]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Studies'
ALTER TABLE [dbo].[Studies]
ADD CONSTRAINT [PK_Studies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubjectDrugs'
ALTER TABLE [dbo].[SubjectDrugs]
ADD CONSTRAINT [PK_SubjectDrugs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TimeZones'
ALTER TABLE [dbo].[TimeZones]
ADD CONSTRAINT [PK_TimeZones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [VisitId], [FormId] in table 'VisitForms'
ALTER TABLE [dbo].[VisitForms]
ADD CONSTRAINT [PK_VisitForms]
    PRIMARY KEY CLUSTERED ([VisitId], [FormId] ASC);
GO

-- Creating primary key on [Id] in table 'Answers'
ALTER TABLE [dbo].[Answers]
ADD CONSTRAINT [PK_Answers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AnswerId], [QuestionId] in table 'AnswerChildQuestions'
ALTER TABLE [dbo].[AnswerChildQuestions]
ADD CONSTRAINT [PK_AnswerChildQuestions]
    PRIMARY KEY CLUSTERED ([AnswerId], [QuestionId] ASC);
GO

-- Creating primary key on [Id] in table 'Visits'
ALTER TABLE [dbo].[Visits]
ADD CONSTRAINT [PK_Visits]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Forms'
ALTER TABLE [dbo].[Forms]
ADD CONSTRAINT [PK_Forms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormVerifications'
ALTER TABLE [dbo].[FormVerifications]
ADD CONSTRAINT [PK_FormVerifications]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [PK_Questions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VisitSteps'
ALTER TABLE [dbo].[VisitSteps]
ADD CONSTRAINT [PK_VisitSteps]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [VisitStepId], [VisitId] in table 'VisitStepVisitSequences'
ALTER TABLE [dbo].[VisitStepVisitSequences]
ADD CONSTRAINT [PK_VisitStepVisitSequences]
    PRIMARY KEY CLUSTERED ([VisitStepId], [VisitId] ASC);
GO

-- Creating primary key on [Id] in table 'Settings'
ALTER TABLE [dbo].[Settings]
ADD CONSTRAINT [PK_Settings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubjectAltNumbers'
ALTER TABLE [dbo].[SubjectAltNumbers]
ADD CONSTRAINT [PK_SubjectAltNumbers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Phones'
ALTER TABLE [dbo].[Phones]
ADD CONSTRAINT [PK_Phones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Feedbacks'
ALTER TABLE [dbo].[Feedbacks]
ADD CONSTRAINT [PK_Feedbacks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Subjects'
ALTER TABLE [dbo].[Subjects]
ADD CONSTRAINT [PK_Subjects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [SubjectDrugId], [SubjectId], [DrugId], [AppointmentId], [ReasonStoppedId], [ReasonTypeId], [TreatmentInducedId], [DosageFrequencyId], [IsCurrent], [IsChanged], [IsStopped], [IsBeforeStudy], [Status], [CreatedOn], [SavedOn] in table 'SubjectDrugHistories'
ALTER TABLE [dbo].[SubjectDrugHistories]
ADD CONSTRAINT [PK_SubjectDrugHistories]
    PRIMARY KEY CLUSTERED ([Id], [SubjectDrugId], [SubjectId], [DrugId], [AppointmentId], [ReasonStoppedId], [ReasonTypeId], [TreatmentInducedId], [DosageFrequencyId], [IsCurrent], [IsChanged], [IsStopped], [IsBeforeStudy], [Status], [CreatedOn], [SavedOn] ASC);
GO

-- Creating primary key on [Id] in table 'LibraryAnswers'
ALTER TABLE [dbo].[LibraryAnswers]
ADD CONSTRAINT [PK_LibraryAnswers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LibraryForms'
ALTER TABLE [dbo].[LibraryForms]
ADD CONSTRAINT [PK_LibraryForms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LibraryQuestions'
ALTER TABLE [dbo].[LibraryQuestions]
ADD CONSTRAINT [PK_LibraryQuestions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [FileGuid] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([FileGuid] ASC);
GO

-- Creating primary key on [Id] in table 'FormInProcesses'
ALTER TABLE [dbo].[FormInProcesses]
ADD CONSTRAINT [PK_FormInProcesses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ErrorLogs'
ALTER TABLE [dbo].[ErrorLogs]
ADD CONSTRAINT [PK_ErrorLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Organizations'
ALTER TABLE [dbo].[Organizations]
ADD CONSTRAINT [PK_Organizations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudySetupMaps'
ALTER TABLE [dbo].[StudySetupMaps]
ADD CONSTRAINT [PK_StudySetupMaps]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudySetupSteps'
ALTER TABLE [dbo].[StudySetupSteps]
ADD CONSTRAINT [PK_StudySetupSteps]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormQuestionAnswerImports'
ALTER TABLE [dbo].[FormQuestionAnswerImports]
ADD CONSTRAINT [PK_FormQuestionAnswerImports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSettings'
ALTER TABLE [dbo].[UserSettings]
ADD CONSTRAINT [PK_UserSettings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Addresses_Id], [Contacts_Id] in table 'ContactAddress'
ALTER TABLE [dbo].[ContactAddress]
ADD CONSTRAINT [PK_ContactAddress]
    PRIMARY KEY CLUSTERED ([Addresses_Id], [Contacts_Id] ASC);
GO

-- Creating primary key on [Contacts_Id], [Emails_Id] in table 'ContactEmail'
ALTER TABLE [dbo].[ContactEmail]
ADD CONSTRAINT [PK_ContactEmail]
    PRIMARY KEY CLUSTERED ([Contacts_Id], [Emails_Id] ASC);
GO

-- Creating primary key on [Countries_Id], [States_Id] in table 'CountryState'
ALTER TABLE [dbo].[CountryState]
ADD CONSTRAINT [PK_CountryState]
    PRIMARY KEY CLUSTERED ([Countries_Id], [States_Id] ASC);
GO

-- Creating primary key on [Sites_Id], [Studies_Id] in table 'StudySite'
ALTER TABLE [dbo].[StudySite]
ADD CONSTRAINT [PK_StudySite]
    PRIMARY KEY CLUSTERED ([Sites_Id], [Studies_Id] ASC);
GO

-- Creating primary key on [Roles_RoleId], [Users_UserId] in table 'UsersInRoles'
ALTER TABLE [dbo].[UsersInRoles]
ADD CONSTRAINT [PK_UsersInRoles]
    PRIMARY KEY CLUSTERED ([Roles_RoleId], [Users_UserId] ASC);
GO

-- Creating primary key on [Visits_Id], [VisitSteps_Id] in table 'VisitStepMapping'
ALTER TABLE [dbo].[VisitStepMapping]
ADD CONSTRAINT [PK_VisitStepMapping]
    PRIMARY KEY CLUSTERED ([Visits_Id], [VisitSteps_Id] ASC);
GO

-- Creating primary key on [Contacts_Id], [Phones_Id] in table 'ContactPhone'
ALTER TABLE [dbo].[ContactPhone]
ADD CONSTRAINT [PK_ContactPhone]
    PRIMARY KEY CLUSTERED ([Contacts_Id], [Phones_Id] ASC);
GO

-- Creating primary key on [Files_FileGuid], [Studies_Id] in table 'StudyFile'
ALTER TABLE [dbo].[StudyFile]
ADD CONSTRAINT [PK_StudyFile]
    PRIMARY KEY CLUSTERED ([Files_FileGuid], [Studies_Id] ASC);
GO

-- Creating primary key on [Files_FileGuid], [Subjects_Id] in table 'SubjectFile'
ALTER TABLE [dbo].[SubjectFile]
ADD CONSTRAINT [PK_SubjectFile]
    PRIMARY KEY CLUSTERED ([Files_FileGuid], [Subjects_Id] ASC);
GO

-- Creating primary key on [Organizations_Id], [Studies_Id] in table 'OrganizationStudy'
ALTER TABLE [dbo].[OrganizationStudy]
ADD CONSTRAINT [PK_OrganizationStudy]
    PRIMARY KEY CLUSTERED ([Organizations_Id], [Studies_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AppointmentId] in table 'AppointmentForms'
ALTER TABLE [dbo].[AppointmentForms]
ADD CONSTRAINT [FK_AppointmentForm_Appointment]
    FOREIGN KEY ([AppointmentId])
    REFERENCES [dbo].[Appointments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AppointmentForm_Appointment'
CREATE INDEX [IX_FK_AppointmentForm_Appointment]
ON [dbo].[AppointmentForms]
    ([AppointmentId]);
GO

-- Creating foreign key on [AppointementId] in table 'RecreationalDrugOrSubstances'
ALTER TABLE [dbo].[RecreationalDrugOrSubstances]
ADD CONSTRAINT [FK_RecreationalDrugOrSubstance_Appointment]
    FOREIGN KEY ([AppointementId])
    REFERENCES [dbo].[Appointments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RecreationalDrugOrSubstance_Appointment'
CREATE INDEX [IX_FK_RecreationalDrugOrSubstance_Appointment]
ON [dbo].[RecreationalDrugOrSubstances]
    ([AppointementId]);
GO

-- Creating foreign key on [AppointmentFormId] in table 'FormAnswers'
ALTER TABLE [dbo].[FormAnswers]
ADD CONSTRAINT [FK_FormAnswer_AppointmentForm]
    FOREIGN KEY ([AppointmentFormId])
    REFERENCES [dbo].[AppointmentForms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ContactId] in table 'AppUsers'
ALTER TABLE [dbo].[AppUsers]
ADD CONSTRAINT [FK_AppUser_Contact]
    FOREIGN KEY ([ContactId])
    REFERENCES [dbo].[Contacts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AppUser_Contact'
CREATE INDEX [IX_FK_AppUser_Contact]
ON [dbo].[AppUsers]
    ([ContactId]);
GO

-- Creating foreign key on [RoleId] in table 'AppUsers'
ALTER TABLE [dbo].[AppUsers]
ADD CONSTRAINT [FK_AppUser_Role]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AppUser_Role'
CREATE INDEX [IX_FK_AppUser_Role]
ON [dbo].[AppUsers]
    ([RoleId]);
GO

-- Creating foreign key on [SiteId] in table 'AppUsers'
ALTER TABLE [dbo].[AppUsers]
ADD CONSTRAINT [FK_AppUser_Site]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AppUser_Site'
CREATE INDEX [IX_FK_AppUser_Site]
ON [dbo].[AppUsers]
    ([SiteId]);
GO

-- Creating foreign key on [MembershipUserId] in table 'AppUsers'
ALTER TABLE [dbo].[AppUsers]
ADD CONSTRAINT [FK_AppUser_User]
    FOREIGN KEY ([MembershipUserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AppUser_User'
CREATE INDEX [IX_FK_AppUser_User]
ON [dbo].[AppUsers]
    ([MembershipUserId]);
GO

-- Creating foreign key on [StudyId] in table 'Arms'
ALTER TABLE [dbo].[Arms]
ADD CONSTRAINT [FK_Arm_Study]
    FOREIGN KEY ([StudyId])
    REFERENCES [dbo].[Studies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Arm_Study'
CREATE INDEX [IX_FK_Arm_Study]
ON [dbo].[Arms]
    ([StudyId]);
GO

-- Creating foreign key on [DrugClassId] in table 'Drugs'
ALTER TABLE [dbo].[Drugs]
ADD CONSTRAINT [FK_Drug_DrugClass]
    FOREIGN KEY ([DrugClassId])
    REFERENCES [dbo].[DrugClasses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Drug_DrugClass'
CREATE INDEX [IX_FK_Drug_DrugClass]
ON [dbo].[Drugs]
    ([DrugClassId]);
GO

-- Creating foreign key on [StudyId] in table 'Drugs'
ALTER TABLE [dbo].[Drugs]
ADD CONSTRAINT [FK_Drug_Study]
    FOREIGN KEY ([StudyId])
    REFERENCES [dbo].[Studies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Drug_Study'
CREATE INDEX [IX_FK_Drug_Study]
ON [dbo].[Drugs]
    ([StudyId]);
GO

-- Creating foreign key on [DrugId] in table 'SubjectDrugs'
ALTER TABLE [dbo].[SubjectDrugs]
ADD CONSTRAINT [FK_SubjectDrug_Drug]
    FOREIGN KEY ([DrugId])
    REFERENCES [dbo].[Drugs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectDrug_Drug'
CREATE INDEX [IX_FK_SubjectDrug_Drug]
ON [dbo].[SubjectDrugs]
    ([DrugId]);
GO

-- Creating foreign key on [DrugCategoryId] in table 'DrugClasses'
ALTER TABLE [dbo].[DrugClasses]
ADD CONSTRAINT [FK_DrugClass_DrugCategory]
    FOREIGN KEY ([DrugCategoryId])
    REFERENCES [dbo].[DrugCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DrugClass_DrugCategory'
CREATE INDEX [IX_FK_DrugClass_DrugCategory]
ON [dbo].[DrugClasses]
    ([DrugCategoryId]);
GO

-- Creating foreign key on [LanguageId] in table 'LocaleStringResources'
ALTER TABLE [dbo].[LocaleStringResources]
ADD CONSTRAINT [FK_LocaleStringResource_Language]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocaleStringResource_Language'
CREATE INDEX [IX_FK_LocaleStringResource_Language]
ON [dbo].[LocaleStringResources]
    ([LanguageId]);
GO

-- Creating foreign key on [LanguageId] in table 'MessageTemplates'
ALTER TABLE [dbo].[MessageTemplates]
ADD CONSTRAINT [FK_MessageTemplate_Language]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageTemplate_Language'
CREATE INDEX [IX_FK_MessageTemplate_Language]
ON [dbo].[MessageTemplates]
    ([LanguageId]);
GO

-- Creating foreign key on [UserId] in table 'Memberships'
ALTER TABLE [dbo].[Memberships]
ADD CONSTRAINT [FK_MembershipUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MessageProviderId] in table 'MessageTemplates'
ALTER TABLE [dbo].[MessageTemplates]
ADD CONSTRAINT [FK_MessageTemplate_MessageProvider]
    FOREIGN KEY ([MessageProviderId])
    REFERENCES [dbo].[MessageProviders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageTemplate_MessageProvider'
CREATE INDEX [IX_FK_MessageTemplate_MessageProvider]
ON [dbo].[MessageTemplates]
    ([MessageProviderId]);
GO

-- Creating foreign key on [TemplateId] in table 'MessageQueues'
ALTER TABLE [dbo].[MessageQueues]
ADD CONSTRAINT [FK_MessageQueue_Template]
    FOREIGN KEY ([TemplateId])
    REFERENCES [dbo].[MessageTemplates]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageQueue_Template'
CREATE INDEX [IX_FK_MessageQueue_Template]
ON [dbo].[MessageQueues]
    ([TemplateId]);
GO

-- Creating foreign key on [UserId] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [FK_UserProfile]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TimeZoneId] in table 'Sites'
ALTER TABLE [dbo].[Sites]
ADD CONSTRAINT [FK_Site_TimeZone]
    FOREIGN KEY ([TimeZoneId])
    REFERENCES [dbo].[TimeZones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Site_TimeZone'
CREATE INDEX [IX_FK_Site_TimeZone]
ON [dbo].[Sites]
    ([TimeZoneId]);
GO

-- Creating foreign key on [Addresses_Id] in table 'ContactAddress'
ALTER TABLE [dbo].[ContactAddress]
ADD CONSTRAINT [FK_ContactAddress_Address]
    FOREIGN KEY ([Addresses_Id])
    REFERENCES [dbo].[Addresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Contacts_Id] in table 'ContactAddress'
ALTER TABLE [dbo].[ContactAddress]
ADD CONSTRAINT [FK_ContactAddress_Contact]
    FOREIGN KEY ([Contacts_Id])
    REFERENCES [dbo].[Contacts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactAddress_Contact'
CREATE INDEX [IX_FK_ContactAddress_Contact]
ON [dbo].[ContactAddress]
    ([Contacts_Id]);
GO

-- Creating foreign key on [Contacts_Id] in table 'ContactEmail'
ALTER TABLE [dbo].[ContactEmail]
ADD CONSTRAINT [FK_ContactEmail_Contact]
    FOREIGN KEY ([Contacts_Id])
    REFERENCES [dbo].[Contacts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Emails_Id] in table 'ContactEmail'
ALTER TABLE [dbo].[ContactEmail]
ADD CONSTRAINT [FK_ContactEmail_Email]
    FOREIGN KEY ([Emails_Id])
    REFERENCES [dbo].[Emails]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactEmail_Email'
CREATE INDEX [IX_FK_ContactEmail_Email]
ON [dbo].[ContactEmail]
    ([Emails_Id]);
GO

-- Creating foreign key on [Countries_Id] in table 'CountryState'
ALTER TABLE [dbo].[CountryState]
ADD CONSTRAINT [FK_CountryState_Country]
    FOREIGN KEY ([Countries_Id])
    REFERENCES [dbo].[Countries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [States_Id] in table 'CountryState'
ALTER TABLE [dbo].[CountryState]
ADD CONSTRAINT [FK_CountryState_State]
    FOREIGN KEY ([States_Id])
    REFERENCES [dbo].[States]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryState_State'
CREATE INDEX [IX_FK_CountryState_State]
ON [dbo].[CountryState]
    ([States_Id]);
GO

-- Creating foreign key on [Sites_Id] in table 'StudySite'
ALTER TABLE [dbo].[StudySite]
ADD CONSTRAINT [FK_StudySite_Site]
    FOREIGN KEY ([Sites_Id])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Studies_Id] in table 'StudySite'
ALTER TABLE [dbo].[StudySite]
ADD CONSTRAINT [FK_StudySite_Study]
    FOREIGN KEY ([Studies_Id])
    REFERENCES [dbo].[Studies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudySite_Study'
CREATE INDEX [IX_FK_StudySite_Study]
ON [dbo].[StudySite]
    ([Studies_Id]);
GO

-- Creating foreign key on [Roles_RoleId] in table 'UsersInRoles'
ALTER TABLE [dbo].[UsersInRoles]
ADD CONSTRAINT [FK_UsersInRoles_Role]
    FOREIGN KEY ([Roles_RoleId])
    REFERENCES [dbo].[Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_UserId] in table 'UsersInRoles'
ALTER TABLE [dbo].[UsersInRoles]
ADD CONSTRAINT [FK_UsersInRoles_User]
    FOREIGN KEY ([Users_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersInRoles_User'
CREATE INDEX [IX_FK_UsersInRoles_User]
ON [dbo].[UsersInRoles]
    ([Users_UserId]);
GO

-- Creating foreign key on [AnswerId] in table 'AnswerChildQuestions'
ALTER TABLE [dbo].[AnswerChildQuestions]
ADD CONSTRAINT [FK_AnswerChildQuestion_Answer]
    FOREIGN KEY ([AnswerId])
    REFERENCES [dbo].[Answers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [VisitId] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_Appointment_Visit]
    FOREIGN KEY ([VisitId])
    REFERENCES [dbo].[Visits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Appointment_Visit'
CREATE INDEX [IX_FK_Appointment_Visit]
ON [dbo].[Appointments]
    ([VisitId]);
GO

-- Creating foreign key on [ArmId] in table 'Visits'
ALTER TABLE [dbo].[Visits]
ADD CONSTRAINT [FK_Visit_Arm]
    FOREIGN KEY ([ArmId])
    REFERENCES [dbo].[Arms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Visit_Arm'
CREATE INDEX [IX_FK_Visit_Arm]
ON [dbo].[Visits]
    ([ArmId]);
GO

-- Creating foreign key on [VisitId] in table 'FormVisibilityByVisitForSubjects'
ALTER TABLE [dbo].[FormVisibilityByVisitForSubjects]
ADD CONSTRAINT [FK_FormVisibilityByVisitForSubject_Visit]
    FOREIGN KEY ([VisitId])
    REFERENCES [dbo].[Visits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FormVisibilityByVisitForSubject_Visit'
CREATE INDEX [IX_FK_FormVisibilityByVisitForSubject_Visit]
ON [dbo].[FormVisibilityByVisitForSubjects]
    ([VisitId]);
GO

-- Creating foreign key on [VisitId] in table 'ScheduleSubjectVisits'
ALTER TABLE [dbo].[ScheduleSubjectVisits]
ADD CONSTRAINT [FK_ScheduleSubjectVisit_Visit]
    FOREIGN KEY ([VisitId])
    REFERENCES [dbo].[Visits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ScheduleSubjectVisit_Visit'
CREATE INDEX [IX_FK_ScheduleSubjectVisit_Visit]
ON [dbo].[ScheduleSubjectVisits]
    ([VisitId]);
GO

-- Creating foreign key on [ParentVisitId] in table 'Visits'
ALTER TABLE [dbo].[Visits]
ADD CONSTRAINT [FK_Visit_Visit]
    FOREIGN KEY ([ParentVisitId])
    REFERENCES [dbo].[Visits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Visit_Visit'
CREATE INDEX [IX_FK_Visit_Visit]
ON [dbo].[Visits]
    ([ParentVisitId]);
GO

-- Creating foreign key on [VisitId] in table 'VisitForms'
ALTER TABLE [dbo].[VisitForms]
ADD CONSTRAINT [FK_RefVisit26]
    FOREIGN KEY ([VisitId])
    REFERENCES [dbo].[Visits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FormId] in table 'AppointmentForms'
ALTER TABLE [dbo].[AppointmentForms]
ADD CONSTRAINT [FK_AppointmentForm_Form]
    FOREIGN KEY ([FormId])
    REFERENCES [dbo].[Forms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AppointmentForm_Form'
CREATE INDEX [IX_FK_AppointmentForm_Form]
ON [dbo].[AppointmentForms]
    ([FormId]);
GO

-- Creating foreign key on [StudyId] in table 'Forms'
ALTER TABLE [dbo].[Forms]
ADD CONSTRAINT [FK_Form_Study]
    FOREIGN KEY ([StudyId])
    REFERENCES [dbo].[Studies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Form_Study'
CREATE INDEX [IX_FK_Form_Study]
ON [dbo].[Forms]
    ([StudyId]);
GO

-- Creating foreign key on [FormId] in table 'FormVerifications'
ALTER TABLE [dbo].[FormVerifications]
ADD CONSTRAINT [FK_FormVerificationRequest_Form]
    FOREIGN KEY ([FormId])
    REFERENCES [dbo].[Forms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FormVerificationRequest_Form'
CREATE INDEX [IX_FK_FormVerificationRequest_Form]
ON [dbo].[FormVerifications]
    ([FormId]);
GO

-- Creating foreign key on [FormId] in table 'FormVisibilityByVisitForSubjects'
ALTER TABLE [dbo].[FormVisibilityByVisitForSubjects]
ADD CONSTRAINT [FK_FormVisibilityByVisitForSubject_Form]
    FOREIGN KEY ([FormId])
    REFERENCES [dbo].[Forms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FormId] in table 'VisitForms'
ALTER TABLE [dbo].[VisitForms]
ADD CONSTRAINT [FK_VisitForms_Form]
    FOREIGN KEY ([FormId])
    REFERENCES [dbo].[Forms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitForms_Form'
CREATE INDEX [IX_FK_VisitForms_Form]
ON [dbo].[VisitForms]
    ([FormId]);
GO

-- Creating foreign key on [QuestionId] in table 'Answers'
ALTER TABLE [dbo].[Answers]
ADD CONSTRAINT [FK_Answer_Question]
    FOREIGN KEY ([QuestionId])
    REFERENCES [dbo].[Questions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Answer_Question'
CREATE INDEX [IX_FK_Answer_Question]
ON [dbo].[Answers]
    ([QuestionId]);
GO

-- Creating foreign key on [QuestionId] in table 'AnswerChildQuestions'
ALTER TABLE [dbo].[AnswerChildQuestions]
ADD CONSTRAINT [FK_AnswerChildQuestion_Question]
    FOREIGN KEY ([QuestionId])
    REFERENCES [dbo].[Questions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AnswerChildQuestion_Question'
CREATE INDEX [IX_FK_AnswerChildQuestion_Question]
ON [dbo].[AnswerChildQuestions]
    ([QuestionId]);
GO

-- Creating foreign key on [ArmId] in table 'VisitSteps'
ALTER TABLE [dbo].[VisitSteps]
ADD CONSTRAINT [FK_VisitStep_Arm]
    FOREIGN KEY ([ArmId])
    REFERENCES [dbo].[Arms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitStep_Arm'
CREATE INDEX [IX_FK_VisitStep_Arm]
ON [dbo].[VisitSteps]
    ([ArmId]);
GO

-- Creating foreign key on [FieldDataTypeId] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [FK_Question_FieldDataType]
    FOREIGN KEY ([FieldDataTypeId])
    REFERENCES [dbo].[CssTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Question_FieldDataType'
CREATE INDEX [IX_FK_Question_FieldDataType]
ON [dbo].[Questions]
    ([FieldDataTypeId]);
GO

-- Creating foreign key on [FormId] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [FK_Question_Form]
    FOREIGN KEY ([FormId])
    REFERENCES [dbo].[Forms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Question_Form'
CREATE INDEX [IX_FK_Question_Form]
ON [dbo].[Questions]
    ([FormId]);
GO

-- Creating foreign key on [VisitId] in table 'VisitStepVisitSequences'
ALTER TABLE [dbo].[VisitStepVisitSequences]
ADD CONSTRAINT [FK_VisitStepVisitSequence_Visit]
    FOREIGN KEY ([VisitId])
    REFERENCES [dbo].[Visits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitStepVisitSequence_Visit'
CREATE INDEX [IX_FK_VisitStepVisitSequence_Visit]
ON [dbo].[VisitStepVisitSequences]
    ([VisitId]);
GO

-- Creating foreign key on [VisitStepId] in table 'VisitStepVisitSequences'
ALTER TABLE [dbo].[VisitStepVisitSequences]
ADD CONSTRAINT [FK_VisitStepVisitSequence_VisitStep]
    FOREIGN KEY ([VisitStepId])
    REFERENCES [dbo].[VisitSteps]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Visits_Id] in table 'VisitStepMapping'
ALTER TABLE [dbo].[VisitStepMapping]
ADD CONSTRAINT [FK_VisitStepMapping_Visit]
    FOREIGN KEY ([Visits_Id])
    REFERENCES [dbo].[Visits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [VisitSteps_Id] in table 'VisitStepMapping'
ALTER TABLE [dbo].[VisitStepMapping]
ADD CONSTRAINT [FK_VisitStepMapping_VisitStep]
    FOREIGN KEY ([VisitSteps_Id])
    REFERENCES [dbo].[VisitSteps]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VisitStepMapping_VisitStep'
CREATE INDEX [IX_FK_VisitStepMapping_VisitStep]
ON [dbo].[VisitStepMapping]
    ([VisitSteps_Id]);
GO

-- Creating foreign key on [Contacts_Id] in table 'ContactPhone'
ALTER TABLE [dbo].[ContactPhone]
ADD CONSTRAINT [FK_ContactPhone_Contact]
    FOREIGN KEY ([Contacts_Id])
    REFERENCES [dbo].[Contacts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Phones_Id] in table 'ContactPhone'
ALTER TABLE [dbo].[ContactPhone]
ADD CONSTRAINT [FK_ContactPhone_Phone]
    FOREIGN KEY ([Phones_Id])
    REFERENCES [dbo].[Phones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactPhone_Phone'
CREATE INDEX [IX_FK_ContactPhone_Phone]
ON [dbo].[ContactPhone]
    ([Phones_Id]);
GO

-- Creating foreign key on [ContactId] in table 'Subjects'
ALTER TABLE [dbo].[Subjects]
ADD CONSTRAINT [FK_Subject_Contact]
    FOREIGN KEY ([ContactId])
    REFERENCES [dbo].[Contacts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Subject_Contact'
CREATE INDEX [IX_FK_Subject_Contact]
ON [dbo].[Subjects]
    ([ContactId]);
GO

-- Creating foreign key on [SiteId] in table 'Subjects'
ALTER TABLE [dbo].[Subjects]
ADD CONSTRAINT [FK_Subject_Site]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Subject_Site'
CREATE INDEX [IX_FK_Subject_Site]
ON [dbo].[Subjects]
    ([SiteId]);
GO

-- Creating foreign key on [StudyId] in table 'Subjects'
ALTER TABLE [dbo].[Subjects]
ADD CONSTRAINT [FK_Subject_StudyId]
    FOREIGN KEY ([StudyId])
    REFERENCES [dbo].[Studies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Subject_StudyId'
CREATE INDEX [IX_FK_Subject_StudyId]
ON [dbo].[Subjects]
    ([StudyId]);
GO

-- Creating foreign key on [SubjectId] in table 'SubjectDrugs'
ALTER TABLE [dbo].[SubjectDrugs]
ADD CONSTRAINT [FK_SubjectDrug_SubjectId]
    FOREIGN KEY ([SubjectId])
    REFERENCES [dbo].[Subjects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectDrug_SubjectId'
CREATE INDEX [IX_FK_SubjectDrug_SubjectId]
ON [dbo].[SubjectDrugs]
    ([SubjectId]);
GO

-- Creating foreign key on [FieldDataTypeId] in table 'LibraryQuestions'
ALTER TABLE [dbo].[LibraryQuestions]
ADD CONSTRAINT [FK_LibraryQuestion_FieldDataType]
    FOREIGN KEY ([FieldDataTypeId])
    REFERENCES [dbo].[CssTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LibraryQuestion_FieldDataType'
CREATE INDEX [IX_FK_LibraryQuestion_FieldDataType]
ON [dbo].[LibraryQuestions]
    ([FieldDataTypeId]);
GO

-- Creating foreign key on [LibraryFormId] in table 'LibraryQuestions'
ALTER TABLE [dbo].[LibraryQuestions]
ADD CONSTRAINT [FK_LibraryQuestion_Form]
    FOREIGN KEY ([LibraryFormId])
    REFERENCES [dbo].[Forms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LibraryQuestion_Form'
CREATE INDEX [IX_FK_LibraryQuestion_Form]
ON [dbo].[LibraryQuestions]
    ([LibraryFormId]);
GO

-- Creating foreign key on [QuestionId] in table 'LibraryAnswers'
ALTER TABLE [dbo].[LibraryAnswers]
ADD CONSTRAINT [FK_LibraryAnswer_Question]
    FOREIGN KEY ([QuestionId])
    REFERENCES [dbo].[Questions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LibraryAnswer_Question'
CREATE INDEX [IX_FK_LibraryAnswer_Question]
ON [dbo].[LibraryAnswers]
    ([QuestionId]);
GO

-- Creating foreign key on [Files_FileGuid] in table 'StudyFile'
ALTER TABLE [dbo].[StudyFile]
ADD CONSTRAINT [FK_StudyFile_File]
    FOREIGN KEY ([Files_FileGuid])
    REFERENCES [dbo].[Files]
        ([FileGuid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Studies_Id] in table 'StudyFile'
ALTER TABLE [dbo].[StudyFile]
ADD CONSTRAINT [FK_StudyFile_Study]
    FOREIGN KEY ([Studies_Id])
    REFERENCES [dbo].[Studies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudyFile_Study'
CREATE INDEX [IX_FK_StudyFile_Study]
ON [dbo].[StudyFile]
    ([Studies_Id]);
GO

-- Creating foreign key on [Files_FileGuid] in table 'SubjectFile'
ALTER TABLE [dbo].[SubjectFile]
ADD CONSTRAINT [FK_SubjectFile_File]
    FOREIGN KEY ([Files_FileGuid])
    REFERENCES [dbo].[Files]
        ([FileGuid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Subjects_Id] in table 'SubjectFile'
ALTER TABLE [dbo].[SubjectFile]
ADD CONSTRAINT [FK_SubjectFile_Subject]
    FOREIGN KEY ([Subjects_Id])
    REFERENCES [dbo].[Subjects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectFile_Subject'
CREATE INDEX [IX_FK_SubjectFile_Subject]
ON [dbo].[SubjectFile]
    ([Subjects_Id]);
GO

-- Creating foreign key on [Organizations_Id] in table 'OrganizationStudy'
ALTER TABLE [dbo].[OrganizationStudy]
ADD CONSTRAINT [FK_OrganizationStudy_Organization]
    FOREIGN KEY ([Organizations_Id])
    REFERENCES [dbo].[Organizations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Studies_Id] in table 'OrganizationStudy'
ALTER TABLE [dbo].[OrganizationStudy]
ADD CONSTRAINT [FK_OrganizationStudy_Study]
    FOREIGN KEY ([Studies_Id])
    REFERENCES [dbo].[Studies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationStudy_Study'
CREATE INDEX [IX_FK_OrganizationStudy_Study]
ON [dbo].[OrganizationStudy]
    ([Studies_Id]);
GO

-- Creating foreign key on [StudySetupStepId] in table 'StudySetupMaps'
ALTER TABLE [dbo].[StudySetupMaps]
ADD CONSTRAINT [FK_StudySetupMap_StudySetupSteps]
    FOREIGN KEY ([StudySetupStepId])
    REFERENCES [dbo].[StudySetupSteps]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudySetupMap_StudySetupSteps'
CREATE INDEX [IX_FK_StudySetupMap_StudySetupSteps]
ON [dbo].[StudySetupMaps]
    ([StudySetupStepId]);
GO

-- Creating foreign key on [AppUserId] in table 'UserSettings'
ALTER TABLE [dbo].[UserSettings]
ADD CONSTRAINT [FK_UserSettings_AppUser]
    FOREIGN KEY ([AppUserId])
    REFERENCES [dbo].[AppUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserSettings_AppUser'
CREATE INDEX [IX_FK_UserSettings_AppUser]
ON [dbo].[UserSettings]
    ([AppUserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------