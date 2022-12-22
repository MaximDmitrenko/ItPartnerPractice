CREATE DATABASE [ItPartner10]
GO
USE [ItPartner10]
GO
CREATE TABLE [Users]
(
	UserId int identity(1,1) PRIMARY KEY NOT NULL,
	UserLogin nvarchar(16) UNIQUE NOT NULL,
	UserPassword nvarchar(100) NOT NULL,
	UserName nvarchar(50) NOT NULL,
	UserSurname nvarchar(50) NOT NULL,
	RoleId int NOT NULL
);
CREATE TABLE [Roles]
(
	RoleId int identity(1,1) PRIMARY KEY NOT NULL,
	RoleName nvarchar(50) NOT NULL
);
CREATE TABLE [Services]
(
	ServiceId int identity(1,1) PRIMARY KEY NOT NULL,
	ServiceName nvarchar(300) NOT NULL,
	ServiceDescription nvarchar(999) NOT NULL,
	ServicePrice int NOT NULL,
	ServicePhoto nvarchar(200)
);
CREATE TABLE [Orders]
(
	OrderId int identity(1,1) PRIMARY KEY NOT NULL,
	OrderStatusId int NOT NULL,
	ClientId int NOT NULL
);
CREATE TABLE [ServicesInOrders]
(
	ServiceId int NOT NULL,
	OrderId int NOT NULL,
	Quantity int NOT NULL
);
CREATE TABLE [Clients]
(
	ClientId int identity(1,1) PRIMARY KEY NOT NULL,
	ClientName nvarchar(150) NOT NULL,
	ClientPhone nvarchar(50) NOT NULL,
	ClientMail nvarchar(50) NOT NULL
);
ALTER TABLE [ServicesInOrders] ADD PRIMARY KEY(ServiceId,OrderId);
CREATE TABLE [OrderStatus]
(
	OrderStatusId int identity(1,1) PRIMARY KEY NOT NULL,
	OrderStatusName nvarchar(50) NOT NULL
);

/*Заполнение*/
INSERT INTO [Roles] VALUES
	('Admin'),
	('Manager');
INSERT INTO [Users] VALUES
	('User1','Password1','Maksim','Dmitrenko',1),
	('User2','Password2','Dmitry','Chernik',2);
INSERT INTO [Services] VALUES
	('Service1','Description1',1,'Images\Service1.jpg'),
	('Service2','Description2',2,'Images\Service2.jpg'),
	('Service3','Description3',3,'Images\Service3.png');
INSERT INTO [OrderStatus] VALUES
	('Принят'),
	('Исполнен'),
	('В работе'),
	('Отменён');
INSERT INTO [Clients] VALUES
	('Клиент1','номер1','почта1'),
	('Клиент2','номер2','почта2'),
	('Клиент3','номер3','почта3');
INSERT INTO [Orders] VALUES
	(1,1),
	(2,2),
	(3,3),
	(4,1);
INSERT INTO [ServicesInOrders] VALUES
	(1,1,1),
	(2,2,2),
	(3,3,3),
	(1,4,4);
/*Связи*/
ALTER TABLE [Users] ADD FOREIGN KEY (RoleId)
REFERENCES [Roles] (RoleId);

ALTER TABLE [Orders] ADD FOREIGN KEY (OrderStatusId)
REFERENCES [OrderStatus] (OrderStatusId);

ALTER TABLE [Orders] ADD FOREIGN KEY (ClientId)
REFERENCES [Clients] (ClientId)
ON DELETE CASCADE;

ALTER TABLE [ServicesInOrders] ADD FOREIGN KEY (ServiceId)
REFERENCES [Services] (ServiceId)
ON DELETE CASCADE;

ALTER TABLE [ServicesInOrders] ADD FOREIGN KEY (OrderId)
REFERENCES [Orders] (OrderId)
ON DELETE CASCADE;
/*ff*/