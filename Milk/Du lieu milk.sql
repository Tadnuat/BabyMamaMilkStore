USE Milk;
GO

-- Insert sample data into Country
INSERT INTO Country (CountryID, CountryName) VALUES
(1, 'USA'),
(2, 'France'),
(3, 'Japan');

-- Insert sample data into Company
INSERT INTO Company (CompanyID, CompanyName, CountryID) VALUES
(1, 'Dairy Farmers', 1),
(2, 'Lactalis', 2),
(3, 'Meiji', 3);

-- Insert sample data into BrandMilk
INSERT INTO BrandMilk (BrandMilkID, BrandName, CompanyID) VALUES
(1, 'Milk Brand A', 1),
(2, 'Milk Brand B', 2),
(3, 'Milk Brand C', 3);

-- Insert sample data into Admin
INSERT INTO Admin (AdminID, Username, Password) VALUES
(1, 'admin1', 'password1'),
(2, 'admin2', 'password2');

-- Insert sample data into Customer
INSERT INTO Customer (CustomerID, CustomerName, Email, Password, Phone) VALUES
(1, 'John Doe', 'john@example.com', 'password123', 1234567890),
(2, 'Jane Smith', 'jane@example.com', 'password456', 2345678901);

-- Insert sample data into Storage
INSERT INTO Storage (StorageID, StorageName) VALUES
(1, 'Main Storage'),
(2, 'Secondary Storage');

-- Insert sample data into DeliveryMan
INSERT INTO DeliveryMan (DeliveryManID, DeliveryName, DeliveryStatus, PhoneNumber, StorageID) VALUES
(1, 'Mike Johnson', 'Available', '3456789012', 1),
(2, 'Tom Hanks', 'On Duty', '4567890123', 2);

-- Insert sample data into ProductItem
INSERT INTO ProductItem (ProductItemID, Benefit, Description, Image, ItemName, Price, Weight, BrandMilkID, Baby, Mama, BrandName, CountryName, CompanyName) VALUES
(1, 'Rich in calcium', 'A high-quality milk product', 'image1.jpg', 'Milk A', 2.50, 1.0, 1, 'Yes', 'No', 'Milk Brand A', 'USA', 'Dairy Farmers'),
(2, 'Vitamin D enriched', 'Tasty and healthy', 'image2.jpg', 'Milk B', 3.00, 1.0, 2, 'No', 'Yes', 'Milk Brand B', 'France', 'Lactalis'),
(3, 'Organic', 'Best for babies', 'image3.jpg', 'Milk C', 4.00, 1.0, 3, 'Yes', 'Yes', 'Milk Brand C', 'Japan', 'Meiji');

-- Insert sample data into AgeRange
INSERT INTO AgeRange (AgeRangeID, Baby, Mama, ProductItemID) VALUES
(1, 'Yes', 'No', 1),
(2, 'No', 'Yes', 2),
(3, 'Yes', 'Yes', 3);

-- Insert sample data into [Order]
INSERT INTO [Order] (OrderID, CustomerID, DeliveryManID, OrderDate, ShippingAddress, TotalAmount, StorageID) VALUES
(1, 1, 1, '2024-01-15', '123 Main St', 5.00, 1),
(2, 2, 2, '2024-01-16', '456 Oak St', 7.00, 2);

-- Insert sample data into Payment
INSERT INTO Payment (PaymentID, Amount, PaymentMethod, OrderID) VALUES
(1, 5.00, 'Credit Card', 1),
(2, 7.00, 'PayPal', 2);

-- Insert sample data into OrderDetail
INSERT INTO OrderDetail (OrderDetailID, OrderID, ProductItemID, Quantity, Price) VALUES
(1, 1, 1, 2, 2.50),
(2, 2, 2, 2, 3.00);
