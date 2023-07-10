CREATE TABLE [dbo].[UserTable]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] varchar(50) not null,
    [LastName] VARCHAR(50) NULL, 
    [Email] VARCHAR(100) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL, 
    [DateTime] DATETIME NOT NULL
)