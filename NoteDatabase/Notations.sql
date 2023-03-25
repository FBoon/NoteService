CREATE TABLE [dbo].[Notations]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Name] nvarchar(255) NOT NULL,
	[Number] nchar(10) NOT NULL,
	[Message] nvarchar(MAX) NOT NULL,
	[Status] int NOT NULL,
	[EmployeeId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Notation_Employees FOREIGN KEY ([EmployeeId]) REFERENCES Employees([Id])
)
