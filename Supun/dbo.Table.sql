CREATE TABLE [dbo].[Table]
(
	[Id] INT NULL PRIMARY KEY IDENTITY, 
    [custId] NVARCHAR(MAX) NULL, 
    [custName] NVARCHAR(MAX) NULL, 
    [custNic] NVARCHAR(MAX) NULL, 
    [email] NVARCHAR(MAX) NULL, 
    [address] NVARCHAR(MAX) NULL, 
    [contact] INT NULL
)
