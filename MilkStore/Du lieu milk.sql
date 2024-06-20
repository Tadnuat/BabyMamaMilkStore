INSERT INTO Country (CountryID, CountryName) VALUES
(1, 'USA'),
(2, 'Canada'),
(3, 'Germany'),
(4, 'France'),
(5, 'Italy');
INSERT INTO Company (CompanyID, CompanyName, CountryID) VALUES
(1, 'Company A', 1),
(2, 'Company B', 2),
(3, 'Company C', 3),
(4, 'Company D', 4),
(5, 'Company E', 5);

INSERT INTO BrandMilk (BrandMilkID, BrandName, CompanyID) VALUES
(1, 'Brand 1', 1),
(2, 'Brand 2', 2),
(3, 'Brand 3', 3),
(4, 'Brand 4', 4),
(5, 'Brand 5', 5);
-- Insert 10 records into the Admin table
INSERT INTO Admin (AdminID, Username, Password, Role) VALUES 
(1, 'admin1', 'password1', 'admin'),
(2, 'manager1', 'password2', 'manager'),
(3, 'admin2', 'password3', 'admin'),
(4, 'manager2', 'password4', 'manager'),
(5, 'admin3', 'password5', 'admin'),
(6, 'manager3', 'password6', 'manager'),
(7, 'admin4', 'password7', 'admin'),
(8, 'manager4', 'password8', 'manager'),
(9, 'admin5', 'password9', 'admin'),
(10, 'manager5', 'password10', 'manager');

INSERT INTO Customer (CustomerID, CustomerName, Email, Password, Phone) VALUES
(1, 'Customer 1', 'customer1@example.com', 'password1', '1234567890'),
(2, 'Customer 2', 'customer2@example.com', 'password2', '2345678901'),
(3, 'Customer 3', 'customer3@example.com', 'password3', '3456789012'),
(4, 'Customer 4', 'customer4@example.com', 'password4', '4567890123'),
(5, 'Customer 5', 'customer5@example.com', 'password5', '5678901234');
INSERT INTO Storage (StorageID, StorageName) VALUES
(1, 'Storage 1'),
(2, 'Storage 2'),
(3, 'Storage 3'),
(4, 'Storage 4'),
(5, 'Storage 5');
INSERT INTO DeliveryMan (DeliveryManID, DeliveryName, DeliveryStatus, PhoneNumber, StorageID) VALUES
(1, 'Delivery Man 1', 'Active', '1234567890', 1),
(2, 'Delivery Man 2', 'Inactive', '2345678901', 2),
(3, 'Delivery Man 3', 'Active', '3456789012', 3),
(4, 'Delivery Man 4', 'Inactive', '4567890123', 4),
(5, 'Delivery Man 5', 'Active', '5678901234', 5);
INSERT INTO ProductItem (ProductItemID, Benefit, Description, Image, ItemName, Price, Weight, BrandMilkID, Baby, Mama, BrandName, CountryName, CompanyName) VALUES
(1, 'Benefit 1', 'Description 1', 'Image1.jpg', 'Item 1', 10.00, 1.0, 1, 'Yes', 'No', 'Brand 1', 'USA', 'Company A'),
(2, 'Benefit 2', 'Description 2', 'Image2.jpg', 'Item 2', 20.00, 2.0, 2, 'No', 'Yes', 'Brand 2', 'Canada', 'Company B'),
(3, 'Benefit 3', 'Description 3', 'Image3.jpg', 'Item 3', 30.00, 3.0, 3, 'Yes', 'No', 'Brand 3', 'Germany', 'Company C'),
(4, 'Benefit 4', 'Description 4', 'Image4.jpg', 'Item 4', 40.00, 4.0, 4, 'No', 'Yes', 'Brand 4', 'France', 'Company D'),
(5, 'Benefit 5', 'Description 5', 'Image5.jpg', 'Item 5', 50.00, 5.0, 5, 'Yes', 'No', 'Brand 5', 'Italy', 'Company E');
INSERT INTO AgeRange (AgeRangeID, Baby, Mama, ProductItemID) VALUES
(1, 'Yes', 'No', 1),
(2, 'No', 'Yes', 2),
(3, 'Yes', 'No', 3),
(4, 'No', 'Yes', 4),
(5, 'Yes', 'No', 5);
INSERT INTO [Order] (OrderID, CustomerID, DeliveryManID, OrderDate, ShippingAddress, TotalAmount, StorageID) VALUES
(1, 1, 1, '2023-06-01', 'Address 1', 100.00, 1),
(2, 2, 2, '2023-06-02', 'Address 2', 200.00, 2),
(3, 3, 3, '2023-06-03', 'Address 3', 300.00, 3),
(4, 4, 4, '2023-06-04', 'Address 4', 400.00, 4),
(5, 5, 5, '2023-06-05', 'Address 5', 500.00, 5);
INSERT INTO Payment (PaymentID, Amount, PaymentMethod, OrderID) VALUES
(1, 100.00, 'Credit Card', 1),
(2, 200.00, 'PayPal', 2),
(3, 300.00, 'Credit Card', 3),
(4, 400.00, 'PayPal', 4),
(5, 500.00, 'Credit Card', 5);
INSERT INTO OrderDetail (OrderDetailID, OrderID, ProductItemID, ItemName, Image, Quantity, Price) VALUES
(1, 1, 1, 'Item 1', 'Image1.jpg', 1, 10.00),
(2, 2, 2, 'Item 2', 'Image2.jpg', 2, 20.00),
(3, 3, 3, 'Item 3', 'Image3.jpg', 3, 30.00),
(4, 4, 4, 'Item 4', 'Image4.jpg', 4, 40.00),
(5, 5, 5, 'Item 5', 'Image5.jpg', 5, 50.00),
(6, 1, 2, 'Item 2', 'Image2.jpg', 1, 20.00),
(7, 2, 3, 'Item 3', 'Image3.jpg', 2, 30.00),
(8, 3, 4, 'Item 4', 'Image4.jpg', 3, 40.00),
(9, 4, 5, 'Item 5', 'Image5.jpg', 4, 50.00),
(10, 5, 1, 'Item 1', 'Image1.jpg', 5, 10.00),
(11, 1, 3, 'Item 3', 'Image3.jpg', 1, 30.00),
(12, 2, 4, 'Item 4', 'Image4.jpg', 2, 40.00),
(13, 3, 5, 'Item 5', 'Image5.jpg', 3, 50.00),
(14, 4, 1, 'Item 1', 'Image1.jpg', 4, 10.00),
(15, 5, 2, 'Item 2', 'Image2.jpg', 5, 20.00);
