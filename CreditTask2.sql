CREATE DATABASE CreditTask2
USE CreditTask2

CREATE TABLE Item (
	ItemID varchar(5) PRIMARY KEY,
	ItemName varchar(50),
	Size varchar(10),
	Price varchar(10),
	Quantity varchar(10)
);

CREATE TABLE Agent (
	AgentID varchar(5) PRIMARY KEY,
	AgentName varchar(50),
	Address varchar(50)
);

CREATE TABLE Orders (
	OrderID varchar(5) PRIMARY KEY,
	OrderDate varchar(10),
	AgentID varchar(5)
);

CREATE TABLE OrderDetail (
	ID varchar(5) PRIMARY KEY,
	OrderID varchar(5),
	ItemID varchar(5),
	Quantity varchar(10),
	UnitAmount varchar(10)
);

CREATE TABLE Users (
	UserID varchar(5) PRIMARY KEY,
	Username varchar(50),
	Pass varchar(20)
);

ALTER TABLE Orders
	ADD FOREIGN KEY (AgentID) REFERENCES Agent(AgentID);

ALTER TABLE OrderDetail
	ADD FOREIGN KEY (OrderID) REFERENCES Orders(OrderID);

ALTER TABLE OrderDetail
	ADD FOREIGN KEY (ItemID) REFERENCES Item(ItemID);

INSERT INTO Item (ItemID, ItemName, Size, Price, Quantity)
VALUES 
('ITM01', 'T-Shirt', 'S', '10.99', '100'),
('ITM02', 'T-Shirt', 'M', '10.99', '150'),
('ITM03', 'T-Shirt', 'L', '10.99', '200'),
('ITM04', 'Hoodie', 'S', '25.99', '50'),
('ITM05', 'Hoodie', 'M', '25.99', '75'),
('ITM06', 'Hoodie', 'L', '25.99', '100'),
('ITM07', 'Backpack', 'OneSize', '29.99', '80'),
('ITM08', 'Water Bottle', '20 oz', '9.99', '200'),
('ITM09', 'Coffee Mug', '12 oz', '7.99', '150'),
('ITM10', 'Notebooks (set of 3)', 'OneSize', '12.99', '120'),
('ITM11', 'Phone Case', 'S', '5.99', '300'),
('ITM12', 'Socks', 'M', '4.99', '250'),
('ITM13', 'Sneakers', 'L', '79.99', '50'),
('ITM14', 'Sunglasses', 'OneSize', '19.99', '120'),
('ITM15', 'Laptop Bag', 'OneSize', '39.99', '90');

INSERT INTO Agent (AgentID, AgentName, Address)
VALUES 
('AGT01', 'John Smith', '123 Main St'),
('AGT02', 'Jane Doe', '456 Elm St'),
('AGT03', 'Bob Johnson', '789 Oak St'),
('AGT04', 'Sara Lee', '101 Pine St'),
('AGT05', 'Tom Jones', '321 Maple St'),
('AGT06', 'Mary Brown', '555 Cedar St'),
('AGT07', 'James Lee', '777 Walnut St'),
('AGT08', 'Karen White', '888 Elmwood St'),
('AGT09', 'Mark Smith', '444 Broad St'),
('AGT10', 'Lisa Johnson', '555 Fifth Ave'),
('AGT11', 'David Davis', '666 Sixth St'),
('AGT12', 'Sarah Johnson', '777 Seventh St'),
('AGT13', 'Anna Smith', '888 Eighth St'),
('AGT14', 'Peter Brown', '999 Ninth St'),
('AGT15', 'Chris Green', '111 Tenth St');

INSERT INTO Orders (OrderID, OrderDate, AgentID)
VALUES 
('ORD01', '2022-01-01', 'AGT01'),
('ORD02', '2022-01-05', 'AGT02'),
('ORD03', '2022-01-10', 'AGT03'),
('ORD04', '2022-01-15', 'AGT04'),
('ORD05', '2022-01-20', 'AGT05'),
('ORD06', '2022-01-25', 'AGT06'),
('ORD07', '2022-02-01', 'AGT07'),
('ORD08', '2022-02-05', 'AGT08'),
('ORD09', '2022-02-10', 'AGT09'),
('ORD10', '2022-02-15', 'AGT10'),
('ORD11', '2022-02-20', 'AGT11'),
('ORD12', '2022-02-25', 'AGT12'),
('ORD13', '2022-03-01', 'AGT13'),
('ORD14', '2022-03-05', 'AGT14'),
('ORD15', '2022-03-10', 'AGT15');

INSERT INTO OrderDetail (ID, OrderID, ItemID, Quantity, UnitAmount)
VALUES 
('OD001', 'ORD01', 'ITM01', '10', '10.99'),
('OD002', 'ORD01', 'ITM02', '5', '10.99'),
('OD003', 'ORD02', 'ITM03', '2', '10.99'),
('OD004', 'ORD02', 'ITM04', '3', '25.99'),
('OD005', 'ORD03', 'ITM05', '4', '25.99'),
('OD006', 'ORD03', 'ITM06', '2', '25.99'),
('OD007', 'ORD04', 'ITM07', '1', '29.99'),
('OD008', 'ORD04', 'ITM08', '5', '9.99'),
('OD009', 'ORD05', 'ITM09', '3', '7.99'),
('OD010', 'ORD05', 'ITM10', '2', '12.99'),
('OD011', 'ORD06', 'ITM11', '6', '5.99'),
('OD012', 'ORD06', 'ITM12', '8', '4.99'),
('OD013', 'ORD07', 'ITM13', '2', '79.99'),
('OD014', 'ORD07', 'ITM14', '3', '19.99'),
('OD015', 'ORD08', 'ITM15', '1', '39.99');

INSERT INTO Users VALUES ('USR01', 'Admin', 'admin123')