CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NCHAR(100) NOT NULL, 
    [Director] NCHAR(100) NOT NULL, 
    [DateReleased] DATETIME NOT NULL
)
