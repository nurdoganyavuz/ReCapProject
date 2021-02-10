CREATE TABLE Cars(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BrandId] INT NOT NULL, 
    [ColorId] INT NOT NULL, 
    [CarName] NVARCHAR(25) NOT NULL,
    [ModelYear] CHAR(4) NOT NULL, 
    [DailyPrice] DECIMAL NOT NULL, 
    [Description] NCHAR(10) NOT NULL, 
    

)
CREATE TABLE Brands(

[BrandId] INT NOT NULL PRIMARY KEY IDENTITY, 
[BrandName] NVARCHAR(25) NOT NULL,

)
CREATE TABLE Colors(

[ColorId] INT NOT NULL PRIMARY KEY IDENTITY, 
[ColorName] NVARCHAR(15) NOT NULL,


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
