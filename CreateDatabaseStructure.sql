﻿CREATE DATABASE CustomersInquiryDB;

USE  [CustomersInquiryDB]

CREATE TABLE Customer(
	CustomerID NUMERIC(10) NOT NULL PRIMARY KEY, 
	[Name] VARCHAR(30) NOT NULL, 
	Email VARCHAR(25) NOT NULL, 
	MobilePhone NUMERIC(10)
);

CREATE TABLE StatusLookup(
	StatusID INT IDENTITY(1, 1) PRIMARY KEY,
	[Text] VARCHAR (10) NOT NULL
);

CREATE TABLE [Transaction](
	TransactionID INT IDENTITY(1, 1) PRIMARY KEY,
	[Date] DATETIME, 
	Amount DECIMAL (5, 2) NOT NULL,
	CurrencyCode VARCHAR (3) NOT NULL DEFAULT 'USD',
	[StatusID] INT FOREIGN KEY REFERENCES StatusLookup(StatusID),
	CustomerID INT FOREIGN KEY REFERENCES Customer(CustomerID)
);