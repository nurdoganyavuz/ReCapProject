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
	[UserId]        INT           IDENTITY (1, 1) NOT NULL,
    [UserFirstName] NVARCHAR (25) NOT NULL,
    [UserLastName]  NVARCHAR (25) NOT NULL,
    [Email]         NVARCHAR (50) NOT NULL,
    [Password]      NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
)

CREATE TABLE Customers
(
	[CustomerId]  INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      INT           NOT NULL,
    [CompanyName] NVARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    CONSTRAINT [FK_Customers_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
   
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

INSERT INTO Cars
VALUES (1, 1, 'Octavia','2014', 450, 'Manuel'),
       (1, 2, 'Fabia', '2015', 550, 'Manuel'),
       (2, 2, 'Clio', '2016', 560, 'Otomatik'),
       (2, 3, 'Duster', '2017', 650, 'Manuel'),
       (3, 3, 'Q7', '2018', 750, 'Otomatik'),
       (3, 4, 'Q8', '2018', 670, 'Manuel'),
       (4, 5, 'Citan', '2019', 750, 'Otomatik'),
       (4, 5, 'GLE', '2020', 950, 'Otomatik'),
       (5, 6, 'Sedan', '2012', 550, 'Manuel'),
       (5, 6, 'Roadster', '2019', 850, 'Otomatik');

INSERT INTO Brands
VALUES ('Skoda'),
       ('Renault'),
       ('Audi'),
       ('Mercedes'),
       ('BMW');

INSERT INTO Colors
VALUES ('Kırmızı'),
       ('Lacivert'),
       ('Siyah'),
       ('Yeşil'),
       ('Beyaz'),
       ('Kahverengi');

--Delete Brands
--Delete Cars
--Delete Colors
