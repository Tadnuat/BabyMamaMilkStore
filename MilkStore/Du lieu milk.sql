USE Milk;
GO

-- Insert data into Country table
INSERT INTO Country (CountryID, CountryName)
VALUES 
(1, 'USA'),
(2, 'Canada'),
(3, 'France'),
(4, 'Germany'),
(5, 'Australia'),
(6, 'Japan'),
(7, 'China'),
(8, 'India'),
(9, 'Brazil'),
(10, 'UK');

-- Insert data into Company table
INSERT INTO Company (CompanyID, CompanyName, CountryID)
VALUES 
(1, 'Company A', 1),
(2, 'Company B', 2),
(3, 'Company C', 3),
(4, 'Company D', 4),
(5, 'Company E', 5),
(6, 'Company F', 6),
(7, 'Company G', 7),
(8, 'Company H', 8),
(9, 'Company I', 9),
(10, 'Company J', 10);

-- Insert data into BrandMilk table
INSERT INTO BrandMilk (BrandMilkID, BrandName, CompanyID)
VALUES 
(1, 'Brand A', 1),
(2, 'Brand B', 2),
(3, 'Brand C', 3),
(4, 'Brand D', 4),
(5, 'Brand E', 5),
(6, 'Brand F', 6),
(7, 'Brand G', 7),
(8, 'Brand H', 8),
(9, 'Brand I', 9),
(10, 'Brand J', 10);

-- Insert data into Admin table
INSERT INTO Admin (AdminID, Username, Password, Role)
VALUES 
(1, 'admin1', 'password1', 'Manager'),
(2, 'admin2', 'password2', 'Manager'),
(3, 'admin3', 'password3', 'Staff'),
(4, 'admin4', 'password4', 'Staff'),
(5, 'admin5', 'password5', 'Manager'),
(6, 'admin6', 'password6', 'Staff'),
(7, 'admin7', 'password7', 'Manager'),
(8, 'admin8', 'password8', 'Staff'),
(9, 'admin9', 'password9', 'Manager'),
(10, 'admin10', 'password10', 'Staff');

-- Insert data into Customer table
INSERT INTO Customer (CustomerID, CustomerName, Email, Password, Phone)
VALUES 
(1, 'Customer A', 'customerA@example.com', 'custpassword1', '1234567890'),
(2, 'Customer B', 'customerB@example.com', 'custpassword2', '1234567891'),
(3, 'Customer C', 'customerC@example.com', 'custpassword3', '1234567892'),
(4, 'Customer D', 'customerD@example.com', 'custpassword4', '1234567893'),
(5, 'Customer E', 'customerE@example.com', 'custpassword5', '1234567894'),
(6, 'Customer F', 'customerF@example.com', 'custpassword6', '1234567895'),
(7, 'Customer G', 'customerG@example.com', 'custpassword7', '1234567896'),
(8, 'Customer H', 'customerH@example.com', 'custpassword8', '1234567897'),
(9, 'Customer I', 'customerI@example.com', 'custpassword9', '1234567898'),
(10, 'Customer J', 'customerJ@example.com', 'custpassword10', '1234567899');

-- Insert data into Storage table
INSERT INTO Storage (StorageID, StorageName)
VALUES 
(1, 'Storage A'),
(2, 'Storage B'),
(3, 'Storage C'),
(4, 'Storage D'),
(5, 'Storage E'),
(6, 'Storage F'),
(7, 'Storage G'),
(8, 'Storage H'),
(9, 'Storage I'),
(10, 'Storage J');

-- Insert data into DeliveryMan table
INSERT INTO DeliveryMan (DeliveryManID, DeliveryName, DeliveryStatus, PhoneNumber, StorageID)
VALUES 
(1, 'DeliveryMan A', 'Available', '1234567890', 1),
(2, 'DeliveryMan B', 'Busy', '1234567891', 2),
(3, 'DeliveryMan C', 'Available', '1234567892', 3),
(4, 'DeliveryMan D', 'Busy', '1234567893', 4),
(5, 'DeliveryMan E', 'Available', '1234567894', 5),
(6, 'DeliveryMan F', 'Busy', '1234567895', 6),
(7, 'DeliveryMan G', 'Available', '1234567896', 7),
(8, 'DeliveryMan H', 'Busy', '1234567897', 8),
(9, 'DeliveryMan I', 'Available', '1234567898', 9),
(10, 'DeliveryMan J', 'Busy', '1234567899', 10);

-- Insert data into ProductItem table
INSERT INTO ProductItem (ProductItemID, Benefit, Description, Image, ItemName, Price, Weight, BrandMilkID, Baby, Mama, BrandName, CountryName, CompanyName)
VALUES 
(1, 'Benefit A', 'Description A', 'Image A', 'Item A', 10.00, 1.0, 1, '6', 'No', 'Brand A', 'USA', 'Company A'),
(2, 'Benefit B', 'Description B', 'Image B', 'Item B', 15.00, 1.2, 2, 'No', '6', 'Brand B', 'Canada', 'Company B'),
(3, 'Benefit C', 'Description C', 'Image C', 'Item C', 20.00, 1.5, 3, '8', 'No', 'Brand C', 'France', 'Company C'),
(4, 'Benefit D', 'Description D', 'Image D', 'Item D', 25.00, 1.1, 4, 'No', '8', 'Brand D', 'Germany', 'Company D'),
(5, 'Benefit E', 'Description E', 'Image E', 'Item E', 30.00, 1.3, 5, '10', 'No', 'Brand E', 'Australia', 'Company E'),
(6, 'Benefit F', 'Description F', 'Image F', 'Item F', 35.00, 1.4, 6, 'No', '10', 'Brand F', 'Japan', 'Company F'),
(7, 'Benefit G', 'Description G', 'Image G', 'Item G', 40.00, 1.6, 7, '12', 'No', 'Brand G', 'China', 'Company G'),
(8, 'Benefit H', 'Description H', 'Image H', 'Item H', 45.00, 1.7, 8, 'No', '12', 'Brand H', 'India', 'Company H'),
(9, 'Benefit I', 'Description I', 'Image I', 'Item I', 50.00, 1.8, 9, '14', 'No', 'Brand I', 'Brazil', 'Company I'),
(10, 'Benefit J', 'Description J', 'Image J', 'Item J', 55.00, 1.9, 10, 'No', '14', 'Brand J', 'UK', 'Company J');

-- Insert data into AgeRange table
INSERT INTO AgeRange (AgeRangeID, Baby, Mama, ProductItemID)
VALUES 
(1, '6', 'No', 1),
(2, 'No', '6', 2),
(3, '8', 'No', 3),
(4, 'No', '8', 4),
(5, '10', 'No', 5),
(6, 'No', '10', 6),
(7, '12', 'No', 7),
(8, 'No', '12', 8),
(9, '14', 'No', 9),
(10, 'No', '14', 10);

-- Insert data into Order table
INSERT INTO [Order] (OrderID, CustomerID, DeliveryManID, OrderDate, ShippingAddress, TotalAmount, StorageID)
VALUES 
(1, 1, 1, GETDATE(), 'Address A', 100.00, 1),
(2, 2, 2, GETDATE(), 'Address B', 150.00, 2),
(3, 3, 3, GETDATE(), 'Address C', 200.00, 3),
(4, 4, 4, GETDATE(), 'Address D', 250.00, 4),
(5, 5, 5, GETDATE(), 'Address E', 300.00, 5),
(6, 6, 6, GETDATE(), 'Address F', 350.00, 6),
(7, 7, 7, GETDATE(), 'Address G', 400.00, 7),
(8, 8, 8, GETDATE(), 'Address H', 450.00, 8),
(9, 9, 9, GETDATE(), 'Address I', 500.00, 9),
(10, 10, 10, GETDATE(), 'Address J', 550.00, 10);

-- Insert data into Payment table
INSERT INTO Payment (PaymentID, Amount, PaymentMethod, OrderID)
VALUES 
(1, 100.00, 'Credit Card', 1),
(2, 150.00, 'PayPal', 2),
(3, 200.00, 'Credit Card', 3),
(4, 250.00, 'PayPal', 4),
(5, 300.00, 'Credit Card', 5),
(6, 350.00, 'PayPal', 6),
(7, 400.00, 'Credit Card', 7),
(8, 450.00, 'PayPal', 8),
(9, 500.00, 'Credit Card', 9),
(10, 550.00, 'PayPal', 10);

-- Insert data into OrderDetail table
INSERT INTO OrderDetail (OrderDetailID, CustomerID, OrderID, ProductItemID, ItemName, Image, Quantity, Price, OrderStatus)
VALUES 
(1, 1, 1, 1, 'Item A', 'Image A', 1, 10.00, 1),
(2, 2, 2, 2, 'Item B', 'Image B', 2, 15.00, 1),
(3, 3, 3, 3, 'Item C', 'Image C', 3, 20.00, 1),
(4, 4, 4, 4, 'Item D', 'Image D', 4, 25.00, 1),
(5, 5, 5, 5, 'Item E', 'Image E', 5, 30.00, 1),
(6, 6, 6, 6, 'Item F', 'Image F', 6, 35.00, 1),
(7, 7, 7, 7, 'Item G', 'Image G', 7, 40.00, 1),
(8, 8, 8, 8, 'Item H', 'Image H', 8, 45.00, 1),
(9, 9, 9, 9, 'Item I', 'Image I', 9, 50.00, 1),
(10, 10, 10, 10, 'Item J', 'Image J', 10, 55.00, 1);
