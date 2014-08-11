CREATE TABLE [dbo].[GenderType]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT   [CK_GenderType_Unique] UNIQUE  ([Name])
)
