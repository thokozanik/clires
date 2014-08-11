CREATE TABLE [dbo].[FormQuestionAnswerImport]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FormId] [int] NOT NULL,
	[FormName] [nvarchar](MAX) NOT NULL,
	[title] [nvarchar](MAX) NULL,
	[Description] [nvarchar](MAX) NULL,
	[FormType] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[QuestionText] [nvarchar](MAX) NOT NULL,
	[QuestionTypeId] [int] NOT NULL,
	[AnswerId] [int] NOT NULL,
	[AnswerText] [nvarchar](1000) NOT NULL
) ON [PRIMARY]
