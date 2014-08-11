CREATE TABLE [dbo].[AnswerChildQuestion]
(
	[AnswerId] INT NOT NULL , 
    [QuestionId] INT NOT NULL, 
    [IsActive] BIT NULL DEFAULT 1, 
    CONSTRAINT [FK_AnswerChildQuestion_Answer] FOREIGN KEY ([AnswerId]) REFERENCES [Answer]([Id]), 
    CONSTRAINT [FK_AnswerChildQuestion_Question] FOREIGN KEY ([QuestionId]) REFERENCES [Question]([Id]), 
    CONSTRAINT [PK_AnswerChildQuestion] PRIMARY KEY ([AnswerId], [QuestionId])
)
