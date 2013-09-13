USE Bank
GO

-- 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance). 
-- Insert few records for testing. Write a stored procedure that selects the full names of all persons.
CREATE PROCEDURE usp_SelectPeopleFullNames
AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM People
GO

EXEC usp_SelectPeopleFullNames 
GO

-- 2. Create a stored procedure that accepts a number as a parameter and returns all persons who have
-- more money in their accounts than the supplied number.
CREATE PROCEDURE usp_SelectPeopleWithMoreThanSpecifiedMoney(@money money = 1000)
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Full Name], a.Balance
	FROM People p JOIN Accounts a
		ON p.PersonID = a.PersonID
	WHERE a.Balance > @money
GO

EXEC usp_SelectPeopleWithMoreThanSpecifiedMoney 1777 
GO

-- 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
-- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
CREATE FUNCTION ufn_CalculateSumWithInterestRate(@sum money, @yearlyRate float, @months int) 
	RETURNS money
AS
BEGIN
	RETURN @sum * (1 + ((@yearlyRate / 100.0) / 12.0) * @months)
END
GO

SELECT dbo.ufn_CalculateSumWithInterestRate(Balance, 6.5, 12), Balance 
	FROM Accounts
GO

-- 4. Create a stored procedure that uses the function from the previous example to give an interest to a person's 
-- account for one month. It should take the AccountId and the interest rate as parameters.
CREATE PROCEDURE usp_UpdatePersonsBalanceWithOneMonthRate(@accountID int, @yearlyRate float)
AS
	UPDATE Accounts
	SET Balance = dbo.ufn_CalculateSumWithInterestRate(Balance, @yearlyRate, 1)
	WHERE AccountID = @accountID	
GO

EXEC usp_UpdatePersonsBalanceWithOneMonthRate 1, 6.5
GO

-- 5. Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.
CREATE PROCEDURE usp_WithdrawMoney(@accountID int, @money money)
AS
	DECLARE @currentBalance money;
	SET @currentBalance = (SELECT Balance FROM Accounts
						   WHERE AccountID = @accountID)
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = @currentBalance - @money
		WHERE AccountID = @accountID

		IF ((@currentBalance >= @money) AND (@money >= 0))
			COMMIT TRAN
		ELSE
			ROLLBACK TRAN
GO

EXEC usp_WithdrawMoney 1, 200
GO

CREATE PROCEDURE usp_DepositMoney(@accountID int, @money money)
AS
	DECLARE @currentBalance money;
	SET @currentBalance = (SELECT Balance FROM Accounts
						   WHERE AccountID = @accountID)
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = @currentBalance + @money
		WHERE AccountID = @accountID

		IF (@money >= 0)
			COMMIT TRAN
		ELSE
			ROLLBACK TRAN
GO

EXEC usp_DepositMoney 1, 220
GO

-- 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum). Add a trigger to the Accounts table that 
-- enters a new entry into the Logs table every time the sum on an account changes.
CREATE TRIGGER tr_AccountSumChange ON Accounts FOR UPDATE
AS
	IF UPDATE (Balance)
	BEGIN
		INSERT INTO Logs (AccountID, OldSum, NewSum)
		VALUES
			((SELECT AccountID FROM Inserted), (SELECT Balance FROM Deleted), (SELECT Balance FROM Inserted))
	END
GO

UPDATE Accounts
SET Balance = 22222
WHERE AccountID = 1

-- 7. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) 
-- and all town's names that are comprised of given set of letters. Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
CREATE FUNCTION dbo.ufn_NameContainingLetters(@Name NVARCHAR(50),  @Letters NVARCHAR(50))
        RETURNS bit
AS
BEGIN
        DECLARE @Contains bit
        SET @Contains = 1
        DECLARE @Counter INT
        SET @Counter = 1
 
        WHILE(@counter <= LEN(@Name))
                BEGIN
                IF (CHARINDEX(SUBSTRING(@Name, @Counter, 1), @Letters) = 0)
                        SET @Contains = 0
                SET @Counter = @Counter + 1
                END
        RETURN @Contains
END

CREATE PROC dbo.usp_FindFirstNames(@LettersToSearch NVARCHAR(50))
        AS
                DECLARE @Valid bit
                SET @Valid = 0
                                       
                        SELECT e.FirstName AS [First name]
                        FROM Employees e
                        WHERE
                                1 = (SELECT dbo.ufn_NameContainingLetters(e.FirstName, @LettersToSearch))
        GO

CREATE PROC dbo.usp_FindMiddleNames(@LettersToSearch NVARCHAR(50))
AS
    DECLARE @Valid bit
    SET @Valid = 0

		SELECT e.FirstName AS [Middle name]
		FROM Employees e
		WHERE
		    1 = (SELECT dbo.ufn_NameContainingLetters(e.FirstName, @LettersToSearch))
GO

CREATE PROC dbo.usp_FindLastNames(@LettersToSearch NVARCHAR(50))
AS
    DECLARE @Valid bit
    SET @Valid = 0

		SELECT e.FirstName AS [Last name]
		FROM Employees e
		WHERE
		    1 = (SELECT dbo.ufn_NameContainingLetters(e.FirstName, @LettersToSearch))
GO

CREATE PROC dbo.usp_FindTowns(@LettersToSearch NVARCHAR(50))
AS
    DECLARE @Valid bit
    SET @Valid = 0

		SELECT t.Name AS [Town]
		FROM Towns t
		WHERE
		    1 = (SELECT dbo.ufn_NameContainingLetters(t.Name, @LettersToSearch))
GO

EXEC dbo.usp_FindFirstNames 'oistmiahf'
EXEC dbo.usp_FindMiddleNames 'oistmiahf'
EXEC dbo.usp_FindLastNames 'asgas'
EXEC dbo.usp_FindTowns 'oistmiahf'

-- 8. Using database cursor write a T-SQL script that scans all employees and their addresses 
-- and prints all pairs of employees that live in the same town.
DECLARE empCursor CURSOR READ_ONLY FOR
        SELECT e1.FirstName, e1.LastName, t.Name,
                e2.FirstName, e2.LastName
        FROM Employees e1
                INNER JOIN Addresses a
                        ON a.AddressID = e1.AddressID
                INNER JOIN Towns t
                        ON t.TownID = a.TownID,
        Employees e2
                INNER JOIN Addresses a1
                        ON a1.AddressID = e2.AddressID
                INNER JOIN Towns t1
                        ON t1.TownID = a1.TownID               
 
        OPEN empCursor
        DECLARE @e1fname NVARCHAR(50)
        DECLARE @e1lname NVARCHAR(50)
        DECLARE @e2fname NVARCHAR(50)
        DECLARE @e2lname NVARCHAR(50)
        DECLARE @town NVARCHAR(50)

-- Get all permutations of two employees in one town
        FETCH NEXT FROM empCursor
                INTO @e1fname, @e1lname, @e2fname, @e2lname, @town
 
        WHILE @@FETCH_STATUS = 0
                BEGIN
                        PRINT @town + ': ' + @e1fname + ' ' + @e1lname + ' ' + @e2fname + ' ' + @e2lname
                        FETCH NEXT FROM empCursor
                                INTO @e1fname, @e1lname, @e2fname, @e2lname, @town
                END
 
CLOSE empCursor
DEALLOCATE empCursor

-- 9. * Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output:
-- Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
-- Ottawa -> Jose Saraiva
CREATE TABLE UsersTowns (ID INT IDENTITY, FullName NVARCHAR(50), TownName NVARCHAR(50))
INSERT INTO UsersTowns
SELECT e.FirstName + ' ' + e.LastName, t.Name
                FROM Employees e
                        INNER JOIN Addresses a
                                ON a.AddressID = e.AddressID
                        INNER JOIN Towns t
                                ON t.TownID = a.TownID
                GROUP BY t.Name, e.FirstName, e.LastName

-- Nested cursors to fetch info
DECLARE @name NVARCHAR(50)
DECLARE @town NVARCHAR(50)
 
DECLARE empCursor1 CURSOR READ_ONLY FOR
        SELECT DISTINCT ut.TownName
                FROM UsersTowns ut     
 
OPEN empCursor1
FETCH NEXT FROM empCursor1
        INTO @town
 
        WHILE @@FETCH_STATUS = 0
        BEGIN
                PRINT @town
 
                DECLARE empCursor2 CURSOR READ_ONLY FOR
                        SELECT ut.FullName
                        FROM UsersTowns ut
                                WHERE ut.TownName = @town
                OPEN empCursor2
                       
                FETCH NEXT FROM empCursor2
                        INTO @name
                               
                        WHILE @@FETCH_STATUS = 0
                        BEGIN
                                PRINT '   ' + @name
                                FETCH NEXT FROM empCursor2 INTO @name
                        END
 
                        CLOSE empCursor2
                        DEALLOCATE empCursor2
                FETCH NEXT FROM empCursor1 INTO @town
        END
 
CLOSE empCursor1
DEALLOCATE empCursor1

-- 10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string 
-- that consists of the input strings separated by ','. For example the following SQL statement should return a single string:
-- SELECT StrConcat(FirstName + ' ' + LastName)
-- FROM Employees
DECLARE @name nvarchar(MAX);
SET @name = N'';
SELECT @name+=e.FirstName+N','
FROM Employees e
SELECT LEFT(@name,LEN(@name)-1);