USE master;
GO

-- Create database Milk
CREATE DATABASE Milk;
GO

-- Switch to Milk database
USE Milk;
GO

-- Create tables in the correct order

CREATE TABLE Country (
    CountryID INT PRIMARY KEY, -- Ensure CountryID is not negative
    CountryName NVARCHAR(MAX) NOT NULL -- Ensure CountryName is not NULL
);

CREATE TABLE Company (
    CompanyID INT PRIMARY KEY, -- Ensure CompanyID is not negative
    CompanyName NVARCHAR(MAX) NOT NULL, -- Ensure CompanyName is not NULL
    CountryID INT, -- Ensure CountryID is not negative
    FOREIGN KEY (CountryID) REFERENCES Country(CountryID)
);

CREATE TABLE BrandMilk (
    BrandMilkID INT PRIMARY KEY, -- Ensure BrandMilkID is not negative
    BrandName NVARCHAR(MAX) NOT NULL, -- Ensure BrandName is not NULL
    CompanyID INT, -- Ensure CompanyID is not negative
    FOREIGN KEY (CompanyID) REFERENCES Company(CompanyID)
);

CREATE TABLE Admin (
    AdminID INT PRIMARY KEY, -- Ensure AdminID is not negative
    Username NVARCHAR(MAX) NOT NULL, -- Ensure Username is not NULL
    Password NVARCHAR(MAX) NOT NULL, -- Ensure Password is not NULL
    Role NVARCHAR(MAX) NOT NULL -- Ensure Role is not NULL
);

CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY, -- Ensure CustomerID is not negative
    CustomerName NVARCHAR(MAX) NOT NULL, -- Ensure CustomerName is not NULL
    Email NVARCHAR(MAX) NOT NULL, -- Ensure email ends with @gmail.com
    Password NVARCHAR(MAX) NOT NULL, -- Ensure Password is not NULL
    Phone VARCHAR(15) NOT NULL -- Phone must be exactly 10 digits
);

CREATE TABLE Storage (
    StorageID INT PRIMARY KEY, -- Ensure StorageID is not negative
    StorageName NVARCHAR(MAX) NOT NULL -- Ensure StorageName is not NULL
);

CREATE TABLE DeliveryMan (
    DeliveryManID INT PRIMARY KEY, -- Ensure DeliveryManID is not negative
    DeliveryName NVARCHAR(MAX) NOT NULL, -- Ensure DeliveryName is not NULL
    DeliveryStatus NVARCHAR(MAX), -- Ensure DeliveryStatus is not NULL
    PhoneNumber VARCHAR(15) NOT NULL, -- Phone must be exactly 10 digits
    StorageID INT, -- Ensure StorageID is not negative
    FOREIGN KEY (StorageID) REFERENCES Storage(StorageID)
);

-- Define ProductItem table before referencing it in AgeRange
CREATE TABLE ProductItem (
    ProductItemID INT PRIMARY KEY, -- Ensure ProductItemID is not negative
    Benefit NVARCHAR(MAX), -- Ensure Benefit is not NULL
    Description NVARCHAR(MAX), -- Ensure Description is not NULL
    Image NVARCHAR(MAX), -- Ensure Image is not NULL
    ItemName NVARCHAR(MAX) NOT NULL, -- Ensure ItemName is not NULL
    Price DECIMAL(10, 2), -- Ensure Price is not NULL and non-negative
    Weight FLOAT, -- Ensure Weight is not NULL and non-negative
    BrandMilkID INT, -- Ensure BrandMilkID is not negative
    Baby NVARCHAR(MAX), -- Ensure Baby is not NULL
    Mama NVARCHAR(MAX), -- Ensure Mama is not NULL
    BrandName NVARCHAR(MAX) NOT NULL, -- Ensure BrandName is not NULL
    CountryName NVARCHAR(MAX) NOT NULL, -- Ensure CountryName is not NULL
    CompanyName NVARCHAR(MAX) NOT NULL, -- Ensure CompanyName is not NULL
    FOREIGN KEY (BrandMilkID) REFERENCES BrandMilk(BrandMilkID)
);

-- Now define AgeRange table which references ProductItem
CREATE TABLE AgeRange (
    AgeRangeID INT PRIMARY KEY, -- Ensure AgeRangeID is not negative
    Baby NVARCHAR(MAX), -- Ensure Baby is not NULL
    Mama NVARCHAR(MAX), -- Ensure Mama is not NULL
    ProductItemID INT, -- Ensure ProductItemID is not negative
    FOREIGN KEY (ProductItemID) REFERENCES ProductItem(ProductItemID)
);

CREATE TABLE [Order] (
    OrderID INT PRIMARY KEY, -- Ensure OrderID is not negative
    CustomerID INT, -- Ensure CustomerID is not negative
    DeliveryManID INT, -- Ensure DeliveryManID is not negative
    OrderDate DATETIME, -- Ensure OrderDate is not NULL
    ShippingAddress NVARCHAR(MAX) NOT NULL, -- Ensure ShippingAddress is not NULL
    TotalAmount DECIMAL(10, 2), -- Ensure TotalAmount is not NULL and non-negative
    StorageID INT, -- Ensure StorageID is not negative
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (DeliveryManID) REFERENCES DeliveryMan(DeliveryManID),
    FOREIGN KEY (StorageID) REFERENCES Storage(StorageID)
);

CREATE TABLE Payment (
    PaymentID INT PRIMARY KEY, -- Ensure PaymentID is not negative
    Amount DECIMAL(10, 2) NOT NULL, -- Ensure Amount is not NULL and non-negative
    PaymentMethod NVARCHAR(MAX) NOT NULL, -- Ensure PaymentMethod is not NULL
    OrderID INT, -- Ensure OrderID is not negative
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID)
);

CREATE TABLE OrderDetail (
    OrderDetailID INT PRIMARY KEY, -- Ensure OrderDetailID is not negative
    CustomerID INT, -- Ensure CustomerID is not negative
    OrderID INT, -- Ensure OrderID is not negative
    ProductItemID INT, -- Ensure ProductItemID is not negative
    ItemName NVARCHAR(MAX) NOT NULL, -- Ensure ItemName is not NULL
    Image NVARCHAR(MAX), -- Ensure Image is not NULL
    Quantity INT, -- Quantity cannot be negative
    Price DECIMAL(10, 2), -- Ensure Price is not NULL and non-negative
    OrderStatus INT, -- Ensure OrderStatus is not negative
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (ProductItemID) REFERENCES ProductItem(ProductItemID)
);
