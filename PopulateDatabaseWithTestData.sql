INSERT INTO StatusLookup([Text])
VALUES ('Success'),
		('Failure'),
		('Cancelled')

DECLARE @CustomerID NUMERIC(10)
DECLARE @Date DATETIME = GETDATE()

INSERT INTO Customer(CustomerID, [Name], Email, MobilePhone)
VALUES (3485948290, 'J. Smolenko', 'j.smolenko@gmail.com', 4958948394)

SET @CustomerID = @@IDENTITY

INSERT INTO [Transaction] ([Date], Amount, CurrencyCode,[StatusID], CustomerID)
VALUES (@Date, 485.23, 'UAH', 2, @CustomerID),
		(@Date, 34.00, 'UAH', 1, @CustomerID),
		(@Date, 134.00, 'UAH', 1, @CustomerID)


INSERT INTO Customer(CustomerID, [Name], Email, MobilePhone)
VALUES (3485912290, 'Petro Ivanenko', 'p.ivanenko@gmail.com', 4958905394)

SET @CustomerID = @@IDENTITY

INSERT INTO [Transaction] ([Date], Amount, CurrencyCode,[StatusID], CustomerID)
VALUES (@Date, 985.23, 'UAH', 3, @CustomerID),
		(@Date, 634.00, 'UAH', 1, @CustomerID),
		(@Date, 104.69, 'UAH', 2, @CustomerID)