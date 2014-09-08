-- 1. Create a database with two tables: 
-- Persons(Id(PK), FirstName, LastName, SSN) and 
-- Accounts(Id(PK), PersonId(FK), Balance). 
-- Insert few records for testing.
-- Write a stored procedure that selects the full names of all persons.

USE master
GO

CREATE DATABASE BankDBHomework
GO

USE BankDBHomework
GO

-- Persons Table
CREATE TABLE Persons (
	PersonId int IDENTITY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	SSN nvarchar(9) NOT NULL,
	CONSTRAINT PK_Persons PRIMARY KEY(PersonId)
) 
GO

-- Accounts Table
CREATE TABLE Accounts (
	AccountId int IDENTITY,
	PersonId int NOT NULL,
	Balance money NOT NULL,
	CONSTRAINT PK_Accounts PRIMARY KEY(AccountId),
	CONSTRAINT FK_Persons_Accounts
        FOREIGN KEY (PersonId)
        REFERENCES Persons(PersonId)
)
GO


-- Populate tables
DECLARE @counter INT
SET @counter = 1
WHILE @counter <= 20
BEGIN
	INSERT INTO Persons (FirstName, LastName, SSN)
	VALUES ('Pesho' + CONVERT(nvarchar, @counter), 
			'Peshov' + CONVERT(nvarchar, @counter), 
			CONVERT(nvarchar, 120000000 + @counter))
	
	INSERT INTO Accounts (PersonId, Balance)
	VALUES (@counter,
			CAST(RAND() * 100000 AS MONEY))
	
	SET @counter = @counter + 1
END
GO

-- Stored Procedure
CREATE PROC usp_SelectFullNamePersons
AS
	SELECT CONCAT(FirstName, ' ', LastName) as [FullName]
	FROM Persons
GO

EXEC usp_SelectFullNamePersons
GO


-- 02. Create a stored procedure that accepts a number 
-- as a parameter and returns all persons who have 
-- more money in their accounts than the supplied number.
CREATE PROC usp_SelectAllWithGreaterBalanceThan (@money money)
AS
	SELECT e.PersonId, e.FirstName, e.LastName, e.SSN, a.Balance
	FROM Persons e
	JOIN Accounts a
		ON e.PersonId = a.PersonId
	WHERE a.Balance >= @money
GO

EXEC usp_SelectAllWithGreaterBalanceThan[15000]
GO

-- 03. Create a function that accepts as parameters – sum, 
-- yearly interest rate and number of months. 
-- It should calculate and return the new sum. 
-- Write a SELECT to test whether the function works as expected.
CREATE FUNCTION dbo.fn_CalculateInterests(@sum MONEY, @yearlyInterestRate REAL, @months int)
	RETURNS money
AS
BEGIN
	RETURN @sum + (@yearlyInterestRate / 12) * @months * @sum
END
GO

SELECT Balance, dbo.fn_CalculateInterests(Balance / 12, 0.1, 4) as Bonus
FROM Accounts
GO

-- 04. Create a stored procedure that uses the function 
-- from the previous example to give an interest to a 
-- person's account for one month. 
-- It should take the AccountId and the interest rate as parameters.
CREATE PROCEDURE dbo.usp_CalculateMonthInterest (@accountId INT, @yearlyInterestRate  REAL)
AS
	DECLARE @balance MONEY
	SELECT @balance = Balance
	FROM Accounts
	WHERE AccountId = @accountId
	
	DECLARE @newBalance MONEY
	SELECT @newBalance = dbo.fn_CalculateInterests(@balance, @yearlyInterestRate, 1)
	
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = @newBalance
		WHERE AccountId = @accountId
	COMMIT TRAN
	
	SELECT p.FirstName, p.LastName, a.Balance, @balance AS [Old Balance]
	FROM Persons p
	JOIN Accounts a
		ON p.PersonId = a.PersonId
	WHERE a.AccountId = @accountId
GO

EXEC dbo.usp_CalculateMonthInterest 3, 0.2
GO

-- 05. Add two more stored procedures WithdrawMoney( AccountId, money) and 
-- DepositMoney (AccountId, money) that operate in transactions.
CREATE PROCEDURE dbo.usp_WithdrawMoney (@accountId INT, @money MONEY)
AS
	BEGIN TRAN
        UPDATE Accounts
        SET Balance -= @money
        WHERE AccountId = @accountId
    IF (SELECT Balance FROM Accounts WHERE AccountId = @accountId) < 0
		BEGIN
			ROLLBACK TRAN
		END
	ELSE
		BEGIN
			COMMIT TRAN
		END
GO

CREATE PROCEDURE dbo.usp_DepositMoney (@accountId INT, @money MONEY)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance += @money
		WHERE AccountId = @accountId
	COMMIT TRAN
GO

EXEC dbo.usp_WithdrawMoney 1, 5000
EXEC dbo.usp_DepositMoney 2, 3000
GO


-- 06. Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
-- Add a trigger to the Accounts table that enters a new entry into the 
-- Logs table every time the sum on an account changes.

-- Table Logs
CREATE TABLE Logs (
	LogId int IDENTITY,
	AccountId int NOT NULL,
	OldSum money NOT NULL,
	NewSum money NOT NULL,
	CONSTRAINT PK_Logs PRIMARY KEY(LogId),
	CONSTRAINT FK_Logs_Accounts
        FOREIGN KEY (AccountId)
        REFERENCES Accounts(AccountId)
)
GO

-- Trigger
CREATE TRIGGER tr_AccountsLog ON Accounts FOR UPDATE
AS
	DECLARE @oldSum MONEY;
    SELECT @oldSum = Balance FROM deleted;

    INSERT INTO Logs(AccountId, OldSum, NewSum)
        SELECT AccountId, @oldSum, Balance
        FROM inserted
GO

EXEC dbo.usp_WithdrawMoney 1, 5000
EXEC dbo.usp_DepositMoney 2, 3000
GO
