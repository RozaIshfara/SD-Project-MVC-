use frr

--=== Users ====
CREATE TABLE [dbo].[tblUser] (
    [UserId]   INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NULL,
    [Email]    VARCHAR (50) NULL,
    [Password] VARCHAR (50) NULL,
    [RoleType] INT          NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

--=== Categories ====
CREATE TABLE [dbo].[tblCategory] (
    [CatId] INT          IDENTITY (1, 1) NOT NULL,
    [Name]  VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([CatId] ASC)
);


--=== Categories ====
CREATE TABLE [dbo].[tblProduct]
(
    [ProID] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NULL, 
    [Description] VARCHAR(50) NULL, 
    [Unit] INT NULL, 
    [Image] NVARCHAR(MAX) NULL, 
    [CatId] INT NULL, 
    FOREIGN KEY ([CatId]) REFERENCES [tblCategory]([CatId])
)

--=== Order ====
CREATE TABLE [dbo].[tblOrder]
(
    [OrderId] INT NOT NULL PRIMARY KEY identity(1,1), 
    [ProID] INT NULL, 
    [Contact] VARCHAR(50) NULL, 
    [Address] VARCHAR(100) NULL, 
    [Unit] INT NULL, 
    [Qty] INT NULL, 
    [Total] INT NULL, 
    [OrderDate] DATE NULL, 
    [PayMethod] VARCHAR(50) NULL, 
    [UserId] INT NULL, 
    FOREIGN KEY ([ProID]) REFERENCES [tblProduct]([ProID]),
    FOREIGN KEY ([UserId]) REFERENCES [tblUser]([UserId])

)

--=== Invoice ====
CREATE TABLE [dbo].[tblInvoice]
(
	[InvoiceId] INT NOT NULL PRIMARY KEY identity, 
    [OrderId] INT NULL, 
    [UserId] INT NULL, 
    [Bill] INT NULL, 
    [Payment] VARCHAR(50) NULL, 
    [InvoiceDate] DATE NULL, 
    FOREIGN KEY ([UserId]) REFERENCES [tblUser]([UserId]),
	 FOREIGN KEY ([OrderId]) REFERENCES [tblOrder]([OrderId])

)
Create Table [dbo].[tblContact]
(
[contactId] int not null primary key identity(1,1),
  [UserId] INT NULL, 
    [Name] varchar (50) null,
    [Message] VARCHAR(100) NULL, 
    FOREIGN KEY ([UserId]) REFERENCES [tblUser]([UserId]),
)