CREATE TABLE [dbo].[Addresses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StreetAddress] NCHAR(100) NOT NULL, 
    [City] NCHAR(50) NOT NULL, 
    [State] NCHAR(50) NOT NULL, 
    [ZipCode] NCHAR(10) NOT NULL
)
