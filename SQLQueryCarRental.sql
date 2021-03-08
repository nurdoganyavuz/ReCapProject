CREATE TABLE Cars(
	[Id]          INT          IDENTITY (1, 1) NOT NULL,
    [BrandId]     INT          NOT NULL,
    [ColorId]     INT          NOT NULL,
    [CarName]     NCHAR (10)   NOT NULL,
    [ModelYear]   CHAR (4)     NOT NULL,
    [DailyPrice]  DECIMAL (18) NOT NULL,
    [Description] NCHAR (10)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cars_Brands] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId]),
    CONSTRAINT [FK_Cars_Colors] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId]) 
    
)
CREATE TABLE Brands(

    [BrandId]   INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([BrandId] ASC)
)
CREATE TABLE Colors(

    [ColorId]   INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([ColorId] ASC)

)

CREATE TABLE Users
(
	[Id]        INT           IDENTITY (1, 1) NOT NULL,
    [UserFirstName] VARCHAR (50) NOT NULL,
    [UserLastName]  VARCHAR (50) NOT NULL,
    [Email]         VARCHAR (50) NOT NULL,
    [PasswordHash]      VARBINARY (500) NOT NULL,
    [PasswordSalt]      VARBINARY (500) NOT NULL,
    [Status] BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
CREATE TABLE OperationClaims
(
	[Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
CREATE TABLE UserOperationClaims
(
	[Id]        INT           IDENTITY (1, 1) NOT NULL,
    [UserId] INT  NOT NULL,
    [OperationClaimId] INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserOperationClaims_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_UserOperationClaims_OperationClaims] FOREIGN KEY ([OperationClaimId]) REFERENCES [dbo].[OperationClaims] ([Id])

)


CREATE TABLE Customers
(
	[CustomerId]  INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      INT           NOT NULL,
    [CompanyName] NVARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    CONSTRAINT [FK_Customers_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
   
)

CREATE TABLE Rentals (
    
    [RentalId] INT  IDENTITY (1, 1) NOT NULL,
    [CarId] INT NOT NULL,
    [CustomerId] INT NOT NULL,
    [RentDate] DATETIME NOT NULL,
    [ReturnDate] DATETIME,
    PRIMARY KEY CLUSTERED ([RentalId] ASC),
    CONSTRAINT [FK_Rentals_Cars] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id]),
    CONSTRAINT [FK_Rentals_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])

)

CREATE TABLE CarImages(

    [ImageId] INT IDENTITY (1,1) NOT NULL,
    [CarId] INT NOT NULL,
    [ImagePath] NVARCHAR (50) NOT NULL,
    [ImageUploadDate] DATETIME NOT NULL
    PRIMARY KEY CLUSTERED ([ImageId] ASC),
    CONSTRAINT [FK_CarImages_Cars] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id])

)


--Delete Brands
--Delete Cars
--Delete Colors

--Delete Users
--Delete Customers
