CREATE DATABASE Tictonic
GO

USE Tictonic
GO

CREATE TABLE Devochkas(
	ID int primary key identity(1, 1),
	Name_ varchar(100) NOT NULL,
	Dad bit NOT NULL,
	Age int NOT NULL
);
GO

CREATE TABLE Cars(
	ID int primary key identity(1, 1),
	Brand varchar(100) NOT NULL,
	Power_ int NOT NULL
);
GO

CREATE TABLE Phones(
	ID int primary key identity(1, 1),
	Brand varchar(100) NOT NULL,
	Model varchar(100) NOT NULL
);
GO

CREATE TABLE Users(
	ID int primary key identity(1, 1),
	Name_ varchar(100) NOT NULL,
	Password_ varchar(100) NOT NULL
);
GO

INSERT INTO Devochkas(Name_, Dad, Age)
Values
('Diana', 1, 12),
('Sofia', 0, 16);

INSERT INTO Cars(Brand, Power_)
Values
('BMW', 666),
('Mercedes-benz', 1222);

INSERT INTO Phones(Brand, Model)
Values
('Apple', 'iPhone 16 pro max'),
('Samsung', 'Galaxy S24 ultra');

INSERT INTO Users(Name_, Password_)
Values
('admin', '123'),
('qwerty321', 'generation');

SELECT * FROM Users
