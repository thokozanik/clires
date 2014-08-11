CREATE TABLE [dbo].[CountryState]
(
	[CountryId] INT NOT NULL , 
    [StateId] INT NOT NULL, 
    PRIMARY KEY ([StateId], [CountryId]), 
    CONSTRAINT [FK_CountryState_Country] FOREIGN KEY ([CountryId]) REFERENCES [Country]([Id]), 
    CONSTRAINT [FK_CountryState_State] FOREIGN KEY ([StateId]) REFERENCES [State]([Id])
)
