CREATE TABLE [dbo].[CssType]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CssClassName] NVARCHAR(100) NULL, 
    [InputType] NVARCHAR(50) NOT NULL, 
    [Html] NVARCHAR(MAX) NULL    
)
