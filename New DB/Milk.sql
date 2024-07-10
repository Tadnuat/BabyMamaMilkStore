USE master;
GO

-- Create database Milk
CREATE DATABASE Milk;
GO

-- Switch to Milk database
USE Milk;
GO

-- Create tables in the correct order
-- la so 0 thi bi xoa, so 1 hien ra, khi xoa thi update delete = 0
CREATE TABLE Country (
    CountryID INT PRIMARY KEY,
    CountryName NVARCHAR(MAX) NOT NULL,
    [Delete] INT NOT NULL DEFAULT 1,
    Image NVARCHAR(MAX)
);

CREATE TABLE Company (
    CompanyID INT PRIMARY KEY,
    CompanyName NVARCHAR(MAX) NOT NULL,
    CountryID INT,
    FOREIGN KEY (CountryID) REFERENCES Country(CountryID),
    [Delete] INT NOT NULL DEFAULT 1,
    Image NVARCHAR(MAX)
);

CREATE TABLE BrandMilk (
    BrandMilkID INT PRIMARY KEY,
    BrandName NVARCHAR(MAX) NOT NULL,
    CompanyID INT,
    FOREIGN KEY (CompanyID) REFERENCES Company(CompanyID),
    [Delete] INT NOT NULL DEFAULT 1,
    Image NVARCHAR(MAX)
);

CREATE TABLE Admin (
    AdminID INT PRIMARY KEY,
    Username NVARCHAR(MAX) NOT NULL,
    Password NVARCHAR(MAX) NOT NULL,
    Role NVARCHAR(MAX) NOT NULL,
    [Delete] INT NOT NULL DEFAULT 1
);

CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY,
    CustomerName NVARCHAR(MAX) NOT NULL,
    Email NVARCHAR(MAX) NOT NULL,
    Password NVARCHAR(MAX) NOT NULL,
    Phone VARCHAR(15) NOT NULL,
    [Delete] INT NOT NULL DEFAULT 1
);

CREATE TABLE Storage (
    StorageID INT PRIMARY KEY,
    StorageName NVARCHAR(MAX) NOT NULL,
    [Delete] INT NOT NULL DEFAULT 1
);

CREATE TABLE DeliveryMan (
    DeliveryManID INT PRIMARY KEY,
    DeliveryName NVARCHAR(MAX) NOT NULL,
    DeliveryStatus NVARCHAR(MAX),
    PhoneNumber VARCHAR(15) NOT NULL,
    StorageID INT,
    StorageName NVARCHAR(MAX) NOT NULL,
    [Delete] INT NOT NULL DEFAULT 1,
    FOREIGN KEY (StorageID) REFERENCES Storage(StorageID)
);

-- Define ProductItem table before referencing it in AgeRange
CREATE TABLE ProductItem (
    ProductItemID INT PRIMARY KEY,
    Benefit NVARCHAR(MAX),
    Description NVARCHAR(MAX),
    Image1 NVARCHAR(MAX),
    Image2 NVARCHAR(MAX),
    Image3 NVARCHAR(MAX),
    ItemName NVARCHAR(MAX) NOT NULL,
    Price DECIMAL(10, 2),
    Discount DECIMAL(5, 2), -- Discount as a percentage
    Weight FLOAT,
    BrandMilkID INT,
    Baby NVARCHAR(MAX),
    Mama NVARCHAR(MAX),
    BrandName NVARCHAR(MAX) NOT NULL,
    CountryName NVARCHAR(MAX) NOT NULL,
    CompanyName NVARCHAR(MAX) NOT NULL,
    SoldQuantity INT,
    StockQuantity INT,
    [Delete] INT NOT NULL DEFAULT 1,
    FOREIGN KEY (BrandMilkID) REFERENCES BrandMilk(BrandMilkID)
);

-- Now define AgeRange table which references ProductItem
CREATE TABLE AgeRange (
    AgeRangeID INT PRIMARY KEY,
    Baby NVARCHAR(MAX),
    Mama NVARCHAR(MAX),
    ProductItemID INT,
    FOREIGN KEY (ProductItemID) REFERENCES ProductItem(ProductItemID),
    [Delete] INT NOT NULL DEFAULT 1
);

CREATE TABLE [Order] (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    DeliveryManID INT NULL, 
    DeliveryName NVARCHAR(MAX) NULL, 
    DeliveryPhone VARCHAR(15) NULL, 
    OrderDate DATETIME,
    ShippingAddress NVARCHAR(MAX) NOT NULL,
    TotalAmount DECIMAL(10, 2),
    PaymentMethod NVARCHAR(MAX) NOT NULL,
    StorageID INT NULL, --null
    [Status] NVARCHAR(MAX) NOT NULL, 
    [Delete] INT NOT NULL DEFAULT 1,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (DeliveryManID) REFERENCES DeliveryMan(DeliveryManID),
    FOREIGN KEY (StorageID) REFERENCES Storage(StorageID)
);

CREATE TABLE Payment (
    PaymentID INT PRIMARY KEY,
    Amount DECIMAL(10, 2) NOT NULL,
    PaymentMethod NVARCHAR(MAX) NOT NULL,
    OrderID INT,
    [Delete] INT NOT NULL DEFAULT 1,
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID)
);

CREATE TABLE OrderDetail (
    OrderDetailID INT PRIMARY KEY,
    CustomerID INT,
    OrderID INT NULL, --null 
    ProductItemID INT,
    ItemName NVARCHAR(MAX) NOT NULL,
    Image NVARCHAR(MAX),
    Quantity INT,
    Price DECIMAL(10, 2),
    Discount DECIMAL(5, 2), -- Discount as a percentage
    OrderStatus INT,
    StockQuantity INT,
    [Delete] INT NOT NULL DEFAULT 1,
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (ProductItemID) REFERENCES ProductItem(ProductItemID)
);
