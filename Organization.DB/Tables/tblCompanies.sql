﻿CREATE TABLE [dbo].[tblCompanies]
(
	[Id] VARCHAR(22) NOT NULL,
	[PagingOrder] INT NOT NULL IDENTITY(1,1),
	[Name] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(60) NOT NULL,
	[Country] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [UK_Companies_PagingOrder] UNIQUE NONCLUSTERED (PagingOrder),
	INDEX [IX_Companies_Name] NONCLUSTERED (Name)
)