CREATE DATABASE dbInventario;
USE dbInventario;

CREATE TABLE rol (
	idRol INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	rol VARCHAR(50),
);

CREATE TABLE userAccess(
	idUser INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	idRol INT NOT NULL,
	frsName VARCHAR(100),
	lstName VARCHAR(150),
	usrName VARCHAR(30),
	usrHash NVARCHAR(MAX),
	refreshToken NVARCHAR(MAX),
	refreshTokenExpireTime DATETIME
	FOREIGN KEY (idRol) REFERENCES rol(idRol)
);

CREATE TABLE categoryProd(
	idCategory INT IDENTITY(1,1) PRIMARY KEY,
	category VARCHAR(60),
	descrip VARCHAR(130)
);

CREATE TABLE warehouse(
	idWarehouse INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	whName VARCHAR(60),
	whAddress VARCHAR(150)
);

CREATE TABLE products(
	idProduct INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	idCategory INT  NOT NULL,
	prodName VARCHAR(60),
	prodDescrip VARCHAR(150),
	prodPrice DECIMAL(7,2)
	FOREIGN KEY (idCategory) REFERENCES categoryProd(idCategory) 
);

CREATE TABLE stocks(
	idProduct INT NOT NULL,
	idWarehouse INT NOT NULL,
	qty INT,
	FOREIGN KEY (idProduct) REFERENCES products(idProduct),
	FOREIGN KEY (idWarehouse) REFERENCES warehouse(idWarehouse)
);