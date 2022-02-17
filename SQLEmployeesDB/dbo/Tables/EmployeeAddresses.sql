CREATE TABLE [dbo].[EmployeeAddresses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EmployeeId] INT NOT NULL, 
    [AddressId] INT NOT NULL
)
