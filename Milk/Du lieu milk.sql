-- Insert into Country
INSERT INTO Country (CountryName) VALUES ('USA'), ('Vietnam'), ('France'), ('Germany'), ('Japan');

-- Insert into Company
INSERT INTO Company (CompanyName, CountryID) VALUES ('Company1', 1), ('Company2', 2), ('Company3', 3), ('Company4', 4), ('Company5', 5);

-- Insert into BrandMilk
INSERT INTO BrandMilk (BrandName, CompanyID) VALUES ('Brand1', 1), ('Brand2', 2), ('Brand3', 3), ('Brand4', 4), ('Brand5', 5);

-- Insert into Admin
INSERT INTO Admin (Username, Password) VALUES ('admin1', 'password1'), ('admin2', 'password2'), ('admin3', 'password3');

-- Insert into Customer
INSERT INTO Customer (CustomerName, Email, Password) VALUES ('customer1', 'customer1@example.com', 'customer1pass'), ('customer2', 'customer2@example.com', 'customer2pass');

-- Insert into Storage
INSERT INTO Storage (StorageName) VALUES ('Storage1'), ('Storage2'), ('Storage3');

-- Insert into DeliveryMan
INSERT INTO DeliveryMan (DeliveryName, DeliveryStatus, PhoneNumber, StorageID) VALUES ('DeliveryMan1', 'Active', '1234567890', 1), ('DeliveryMan2', 'Inactive', '0987654321', 2);

-- Insert into Product
INSERT INTO Product (ProductName, BrandMilkID, AdminID) VALUES ('Product1', 1, 1), ('Product2', 2, 2), ('Product3', 3, 3);

-- Insert into AgeRange
INSERT INTO AgeRange (Baby, Mama, ProductID) VALUES ('0-6 months', '6-12 months', 1), ('0-6 months', '12-24 months', 2);

-- Insert into ProductItem
INSERT INTO ProductItem (Benefit, Description, Image, ItemName, Price, Weight, ProductID) VALUES ('Benefit1', 'Description1', 'image1.jpg', 'Item1', 10.00, 1.5, 1), ('Benefit2', 'Description2', 'image2.jpg', 'Item2', 15.00, 2.0, 2);

-- Insert into [Order]
INSERT INTO [Order] (AdminID, CustomerID, DeliveryManID, OrderDate, ShippingAddress, TotalAmount, StorageID) VALUES (1, 1, 1, '2024-06-14', 'Address1', 100.00, 1), (2, 2, 2, '2024-06-14', 'Address2', 200.00, 2);

-- Insert into Payment
INSERT INTO Payment (Amount, PaymentMethod, OrderID) VALUES (100.00, 'Credit Card', 1), (200.00, 'PayPal', 2);

-- Insert into OrderDetail
INSERT INTO OrderDetail (OrderID, ProductItemID, Quantity, Price, OrderDetailStatus) VALUES (1, 1, 2, 20.00, 'Shipped'), (2, 2, 3, 30.00, 'Processing');
