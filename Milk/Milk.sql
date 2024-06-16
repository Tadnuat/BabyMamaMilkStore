CREATE DATABASE Milk;
GO

CREATE TABLE Country (
    CountryID INT IDENTITY(1,1) PRIMARY KEY,
    CountryName NVARCHAR(255) NOT NULL
);

CREATE TABLE Company (
    CompanyID INT IDENTITY(1,1) PRIMARY KEY,
    CompanyName NVARCHAR(255) NOT NULL,
    CountryID INT,
    FOREIGN KEY (CountryID) REFERENCES Country(CountryID)
);

CREATE TABLE BrandMilk (
    BrandMilkID INT IDENTITY(1,1) PRIMARY KEY,
    BrandName NVARCHAR(255) NOT NULL,
    CompanyID INT,
    FOREIGN KEY (CompanyID) REFERENCES Company(CompanyID)
);

CREATE TABLE Admin (
    AdminID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL
);

CREATE TABLE Customer (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL
);

CREATE TABLE Storage (
    StorageID INT IDENTITY(1,1) PRIMARY KEY,
    StorageName NVARCHAR(255) NOT NULL
);

CREATE TABLE DeliveryMan (
    DeliveryManID INT IDENTITY(1,1) PRIMARY KEY,
    DeliveryName NVARCHAR(255) NOT NULL,
    DeliveryStatus NVARCHAR(255),
    PhoneNumber NVARCHAR(255) NOT NULL,
    StorageID INT,
    FOREIGN KEY (StorageID) REFERENCES Storage(StorageID)
);

CREATE TABLE Product (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(255) NOT NULL,
    BrandMilkID INT,
    AdminID INT,
    FOREIGN KEY (BrandMilkID) REFERENCES BrandMilk(BrandMilkID),
    FOREIGN KEY (AdminID) REFERENCES Admin(AdminID)
);

CREATE TABLE AgeRange (
    AgeRangeID INT IDENTITY(1,1) PRIMARY KEY,
    Baby NVARCHAR(255),
    Mama NVARCHAR(255),
    ProductID INT,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

CREATE TABLE ProductItem (
    ProductItemID INT IDENTITY(1,1) PRIMARY KEY,
    Benefit NVARCHAR(255),
    Description NVARCHAR(255),
    Image NVARCHAR(255),
    ItemName NVARCHAR(255) NOT NULL,
    Price DECIMAL(10, 2),
    Weight FLOAT,
    ProductID INT,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

CREATE TABLE [Order] (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    AdminID INT,
    CustomerID INT,
    DeliveryManID INT,
    OrderDate DATE,
    ShippingAddress NVARCHAR(255) NOT NULL,
    TotalAmount DECIMAL(10, 2),
    StorageID INT,
    FOREIGN KEY (AdminID) REFERENCES Admin(AdminID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (DeliveryManID) REFERENCES DeliveryMan(DeliveryManID),
    FOREIGN KEY (StorageID) REFERENCES Storage(StorageID)
);

CREATE TABLE Payment (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    Amount DECIMAL(10, 2) NOT NULL,
    PaymentMethod NVARCHAR(255) NOT NULL,
    OrderID INT,
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID)
);

CREATE TABLE OrderDetail (
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT,
    ProductItemID INT,
    Quantity INT,
    Price DECIMAL(10, 2),
    OrderDetailStatus NVARCHAR(255),
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID),
    FOREIGN KEY (ProductItemID) REFERENCES ProductItem(ProductItemID)
);
