DECLARE @CustomerID NUMERIC(10)
DECLARE @Date DATETIME = GETDATE()

INSERT INTO Customer([Name], Email, MobilePhone)
VALUES ('J. Smolenko', 'j.smolenko@gmail.com', 4958948394)

SET @CustomerID = @@IDENTITY

INSERT INTO [Transaction] ([Date], Amount, CurrencyCode,[Status], CustomerID)
VALUES (@Date, 485.23, 'UAH', 'Success', @CustomerID),
		(@Date, 34.00, 'UAH', 'Success', @CustomerID),
		(@Date, 134.00, 'UAH', 'Failure', @CustomerID)


INSERT INTO Customer([Name], Email, MobilePhone)
VALUES ('Petro Ivanenko', 'p.ivanenko@gmail.com', 4958905394)

SET @CustomerID = @@IDENTITY

INSERT INTO [Transaction] ([Date], Amount, CurrencyCode,[Status], CustomerID)
VALUES (@Date, 985.23, 'UAH', 'Failure', @CustomerID),
		(@Date, 634.00, 'UAH', 'Cancelled',  @CustomerID),
		(@Date, 104.69, 'UAH', 'Success', @CustomerID)


INSERT INTO Customer([Name], Email, MobilePhone)
VALUES ('Ivan Lupin', 'lupin@gmail.com', 4859203856)