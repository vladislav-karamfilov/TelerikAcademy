USE TelerikAcademy

-- 1. Write a SQL query to find the names and salaries of the employees that take the minimal 
-- salary in the company. Use a nested SELECT statement.
SELECT FirstName, LastName, MiddleName, Salary
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

-- 2. Write a SQL query to find the names and salaries of the employees that have a salary that 
-- is up to 10% higher than the minimal salary for the company.
SELECT FirstName, LastName, MiddleName, Salary
FROM Employees
WHERE Salary <= (SELECT MIN(Salary) * 1.1 FROM Employees)

-- 3. Write a SQL query to find the full name, salary and department of the employees that take 
-- the minimal salary in their department. Use a nested SELECT statement.
SELECT e.FirstName + ' ' + e.MiddleName + ' ' + e.LastName AS [Full Name], e.Salary, d.Name
FROM Employees AS e JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = 
	(SELECT Min(Salary) FROM Employees
	 WHERE DepartmentID = e.DepartmentID)

-- 4. Write a SQL query to find the average salary in the department #1.
SELECT d.Name AS Department, AVG(e.Salary) AS [Average Salary]
FROM Employees AS e JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE e.DepartmentID = 1
GROUP BY d.Name

-- 5. Write a SQL query to find the average salary in the "Sales" department.
SELECT d.Name AS Department, AVG(e.Salary) AS [Average Salary]
FROM Employees AS e JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

-- 6. Write a SQL query to find the number of employees in the "Sales" department.
SELECT d.Name AS Department, COUNT(*) AS [Employees Count]
FROM Employees AS e JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

-- 7. Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(ManagerID) AS [Employees With Manager Count]
FROM Employees

-- 8. Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) AS [Employees Without Manager Count]
FROM Employees
WHERE ManagerID IS NULL

-- 9. Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name, AVG(e.Salary) AS [Average Salary]
FROM Departments d JOIN Employees e
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

-- 10. Write a SQL query to find the count of all employees in each department and for each town.
SELECT t.Name [Town], d.Name [Department], COUNT(*) AS [Employees Count]
FROM Employees e
	JOIN Addresses a 
		ON e.AddressID = a.AddressID
	JOIN Departments d 
		ON d.DepartmentID = e.DepartmentID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.Name, d.Name

-- 11. Write a SQL query to find all managers that have exactly 5 employees. 
-- Display their first name and last name.
SELECT m.FirstName [First Name], m.LastName [Last Name]
FROM Employees m JOIN Employees e
	ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(e.ManagerID) = 5

-- 12. Write a SQL query to find all employees along with their managers. 
-- For employees that do not have manager display the value "(no manager)".
SELECT (e.FirstName + ' ' + e.LastName) AS Employee,
	   ISNULL((m.FirstName + ' ' + m.LastName), '(no manager)') AS Manager
FROM Employees e LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID

-- 13. Write a SQL query to find the names of all employees whose last name is 
-- exactly 5 characters long. Use the built-in LEN(str) function.
SELECT FirstName, MiddleName, LastName
FROM Employees
WHERE LEN(LastName) = 5

-- 14. Write a SQL query to display the current date and time in the following format 
-- "day.month.year hour:minutes:seconds:milliseconds". Search in Google to find how to format dates in SQL Server.
SELECT CONVERT(varchar, GETDATE(), 113) AS [Current Date and Time]

-- 15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. 
-- Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint. 
-- Define the primary key column as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. 
-- Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users (
	UserID int IDENTITY,
	UserName nvarchar(30) NOT NULL UNIQUE,
	[Password] nvarchar(50) NOT NULL,
	FullName nvarchar(50) NOT NULL,
	LastLoginTime datetime,
	CONSTRAINT PK_Users PRIMARY KEY(UserID),
	CONSTRAINT PasswordMinLength CHECK (DATALENGTH([Password]) > 4) 
)
GO

INSERT INTO Users(UserName, [Password], FullName, LastLoginTime)
VALUES
('Pesho', 'pesho', 'Pesho Peshov', GETDATE()),
('Gosho', 'gosho', 'Gosho Goshov', GETDATE() - 22),
('Ivan', 'vankata', 'Ivan Ivanov', GETDATE() - 2222),
('Lili', 'lilcheto', 'Lili Marinova', GETDATE()),
('Penka', 'pepito', 'Penka Petkova', GETDATE() - 15),
('Gergana', 'geritoooo', 'Gergana Kirova', GETDATE() - 365)
GO

-- 16. Write a SQL statement to create a view that displays the users from the 
-- Users table that have been in the system today. Test if the view works correctly.
CREATE VIEW [Logged In Today] AS
SELECT UserName FROM Users
WHERE DATEDIFF(day, LastLoginTime, GETDATE()) = 0
GO

-- 17. Write a SQL statement to create a table Groups. Groups should have unique name 
-- (use unique constraint). Define primary key and identity column.
CREATE TABLE Groups (
	GroupID int IDENTITY,
	Name nvarchar(50) NOT NULL UNIQUE,
	CONSTRAINT PK_Groups PRIMARY KEY(GroupID)
)
GO

-- 18. Write a SQL statement to add a column GroupID to the table Users. Fill some data in this new column
-- and as well in the Groups table. Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users ADD GroupID int
GO

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
	FOREIGN KEY(GroupID)
	REFERENCES Groups(GroupID)

-- 19. Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Users(UserName, [Password], FullName, LastLoginTime, GroupID)
VALUES
('Marinski', 'marinski', 'Marin Georgiev', GETDATE() - 12, 2),
('Vancheto', 'vancheto', 'Ivana Georgieva', GETDATE(), 1),
('Minka', 'minka', 'Minka Peshova', GETDATE() - 7, 3)
GO

INSERT INTO Groups(Name)
VALUES
('Group5'),
('Group6'),
('Group7')

-- 20. Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET FullName = 'Minka Gerova'
WHERE FullName = 'Minka Peshova'

UPDATE Users
SET FullName = 'Pesho Goshov'
WHERE FullName = 'Pesho Peshov'

UPDATE Groups
SET Name = 'Group11'
WHERE GroupID = 1

UPDATE Groups
SET Name = 'Group33'
WHERE GroupID = 4

-- 21. Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE UserID = 2

DELETE FROM Users
WHERE FullName = 'Pesho Goshov'

DELETE FROM Groups
WHERE GroupID = 2

DELETE FROM Groups
WHERE Name = 'Group11'

-- 22. Write SQL statements to insert in the Users table the names of all employees from the Employees table. 
-- Combine the first and last names as a full name. For username use the first letter of the first name + the last name 
-- (in lowercase). Use the same for the password, and NULL for last login time.
INSERT INTO Users(UserName, [Password], FullName)
SELECT LOWER(FirstName + LastName), LOWER(FirstName + LastName), FirstName + ' ' LastName
FROM Employees

-- 23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
ALTER TABLE Users
ALTER COLUMN [Password] nvarchar(50) NULL

UPDATE Users
SET Password = NULL
WHERE LastLoginTime IN
	(SELECT LastLoginTime
	 FROM Users
	 WHERE LastLoginTime < CAST('2010-03-10 00:00:00.000' AS datetime))

-- 24. Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users
WHERE Password IS NULL

-- 25. Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name, e.JobTitle, AVG(e.Salary) AS [Average Salary]
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

-- 26. Write a SQL query to display the minimal employee salary by department and
-- job title along with the name of some of the employees that take it.
SELECT d.Name, e.JobTitle, e.Salary AS [Minimal Salary], 
	(e.FirstName + ' ' + e.LastName) AS Employee
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = 
	(SELECT MIN(Salary) 
	 FROM Employees
	 WHERE JobTitle = e.JobTitle)
GROUP BY d.Name, e.JobTitle, e.Salary, e.FirstName, e.LastName

-- 27. Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name AS Town, COUNT(*) AS [Employees Count]
FROM Employees e 
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.Name 
ORDER BY COUNT(*) DESC

-- 28. Write a SQL query to display the number of managers from each town.
SELECT t.Name, Count(*) [Managers Count]
FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
WHERE e.EmployeeID IN 
	(SELECT DISTINCT ManagerID FROM Employees)
GROUP BY t.Name

-- 29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). 
-- Don't forget to define identity, primary key and appropriate foreign key. 
-- Issue few SQL statements to insert, update and delete of some data in the table.
-- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. For each change keep the old record 
-- data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHours(
	EmployeeID int IDENTITY,
	[Date] datetime,
	Task nvarchar(50),
	[Hours] int,
	Comment nvarchar(50),
	CONSTRAINT PK_WorkHours PRIMARY KEY(EmployeeID),
	CONSTRAINT FK_WorkHours_Employees FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
)
GO

INSERT INTO WorkHours(Date, Task, Hours)
VALUES
	(getdate(), 'Sample Task1', 23),
	(getdate(), 'Sample Task2', 3)
GO

DELETE FROM WorkHours
WHERE Task LIKE '%Task1'
GO

UPDATE WorkHours
SET HOURS = 10
WHERE Task = 'Sample Task2'
GO

CREATE TABLE WorkHoursLog(
	Id int IDENTITY,
	OldRecord nvarchar(100) NOT NULL,
	NewRecord nvarchar(100) NOT NULL,
	Command nvarchar(10) NOT NULL,
	EmployeeId int NOT NULL,
	CONSTRAINT PK_WorkHoursLog PRIMARY KEY(Id),
	CONSTRAINT FK_WorkHoursLogs_WorkHours FOREIGN KEY(EmployeeId) REFERENCES WorkHours(EmployeeID)
)
GO

ALTER TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
	INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
	Values(' ',
		   (SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + 
		   ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + ISNULL(Comment, ' ') FROM Inserted),
		   'INSERT',
		   (SELECT EmployeeID FROM Inserted))
GO

ALTER TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
	INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
	Values((SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + 
		   ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + ISNULL(Comment, ' ') FROM Deleted),
		   (SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + 
		   ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + ISNULL(Comment, ' ') FROM Inserted),
		   'UPDATE', (SELECT EmployeeID FROM Inserted))
GO

ALTER TRIGGER tr_WorkHoursDelete ON WorkHours FOR DELETE
AS
	INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
	Values((SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + 
	       ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + ISNULL(Comment, ' ') FROM Deleted),
		   ' ', 'DELETE', (SELECT EmployeeID FROM Deleted))
GO

INSERT INTO WorkHours([Date], Task, Hours, Comment)
VALUES(GETDATE(), 'Random task4', 12, 'Comment4')
GO

DELETE FROM WorkHours
WHERE Task = 'Random task4'
GO

UPDATE WorkHours
SET Task = 'Random task4'
WHERE EmployeeID = 8
GO

-- 30. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records 
-- from the pother tables. At the end rollback the transaction.
BEGIN TRAN
DELETE FROM Employees
	SELECT d.Name
	FROM Employees e JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	GROUP BY d.Name
ROLLBACK TRAN

-- 31. Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?
BEGIN TRAN
	DROP TABLE EmployeesProjects
ROLLBACK TRAN

-- 32. Find how to use temporary tables in SQL Server. Using temporary tables backup all records from EmployeesProjects and 
-- restore them back after dropping and re-creating the table.
CREATE TABLE #TemporaryTable (
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL
)
GO

INSERT INTO #TemporaryTable
	SELECT EmployeeID, ProjectID
	FROM EmployeesProjects
GO

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL,
	CONSTRAINT PK_EmployeesProjects 
		PRIMARY KEY(EmployeeID, ProjectID),
	CONSTRAINT FK_EP_Employee 
		FOREIGN KEY(EmployeeID) 
		REFERENCES Employees(EmployeeID),
	CONSTRAINT FK_EP_Project 
		FOREIGN KEY(ProjectID) 
		REFERENCES Projects(ProjectID)
)
GO

INSERT INTO EmployeesProjects
	SELECT EmployeeID, ProjectID
	FROM #TemporaryTable