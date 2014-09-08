USE TelerikAcademy

-- 15. Write a SQL statement to create a table Users. 
-- Users should have username, password, full name and last login time. 
-- Choose appropriate data types for the table fields. 
-- Define a primary key column with a primary key constraint. 
-- Define the primary key column as identity to facilitate inserting records.
-- Define unique constraint to avoid repeating usernames.
-- Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users (
  UserID int IDENTITY,
  Username nvarchar(100) NOT NULL,
  Password nvarchar(100) NOT NULL,
  Name nvarchar(50) NOT NULL,
  LastLoginTime datetime,
  CONSTRAINT PK_Users PRIMARY KEY(UserID),
  CONSTRAINT UQ_Username UNIQUE(Username),
  CONSTRAINT CHK_Password CHECK (LEN(Password) >= 5)
)
GO

-- 16. Write a SQL statement to create a view that displays the users 
-- from the Users table that have been in the system today. 
-- Test if the view works correctly.
CREATE VIEW [Users in system today] AS
SELECT Username FROM Users as u
WHERE DATEDIFF(day, LastLoginTime, GETDATE()) = 0
GO

--- 17. Write a SQL statement to create a table Groups. 
--- Groups should have unique name (use unique constraint). 
--- Define primary key and identity column.
CREATE TABLE Groups (
	GroupID int IDENTITY,
	Name nvarchar(100) NOT NULL,
	CONSTRAINT PK_Groups PRIMARY KEY(GroupID),
	CONSTRAINT UQ_Name UNIQUE(Name)
)
GO

--- 18. Write a SQL statement to add a column GroupID to the table Users.
 --- Fill some data in this new column and as well in the Groups table.
 --- Write a SQL statement to add a foreign key constraint 
 --- between tables Users and Groups tables.
 ALTER TABLE Users
	ADD GroupID int
GO
 
ALTER TABLE Users
    ADD CONSTRAINT FK_Users_Groups
    FOREIGN KEY (GroupID)
    REFERENCES Groups(GroupID)
GO


-- 19. Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups (Name)
VALUES ('Databases'),
	 ('C# Introduction'), 
	 ('C# II'),
	 ('JavaScript Fundamentals'),
	 ('OOP'),
	 ('High-Quality Code')
GO

INSERT INTO Users
VALUES 
	('pesho', 'parola', 'Pesho Peshev', '2014-02-25 10:30:22', 1),
	('gosho', 'password123', 'Gosho Goshov', '2014-08-25 10:30:22', 2),
	('ivan', 'parola123', 'Ivan Ivanov', '2014-08-25 15:30:22', 3),
	('pena123', 'penchetobe', 'Penka Penecheva', '2013-02-25 10:30:22', 5)
GO

-- 20. Write SQL statements to update some of the 
-- records in the Users and Groups tables.
UPDATE Users
SET Name = UPPER(Name)
WHERE UserID = 2

-- 21. Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE GroupID IN (3, 4, 5)

DELETE FROM Groups
WHERE GroupID IN (3, 4, 5)

--- 22. Write SQL statements to insert in the Users table the 
--- names of all employees from the Employees table. Combine the 
--- first and last names as a full name. For username use the first 
--- letter of the first name + the last name (in lowercase). 
--- Use the same for the password, and NULL for last login time.
DROP TABLE Users
GO

CREATE TABLE Users (
    UserId Int IDENTITY,
    Username nvarchar(50) NOT NULL,
    Password nvarchar(256) NOT NULL,
    Name nvarchar(50) NOT NULL,
    LastLoginTime DATETIME,
    CONSTRAINT PK_Users PRIMARY KEY(UserId)
) 
GO

INSERT INTO Users (Username, Name, Password) 
	(SELECT LOWER(CONCAT(LEFT(e.FirstName, 1), e.LastName)),
                CONCAT(e.FirstName, ' ', e.LastName),
                LOWER(CONCAT(LEFT(e.FirstName, 1), e.LastName))
        FROM Employees e)
GO

SELECT * FROM Users

--- 23. Write a SQL statement that changes the password to
--- NULL for all users that have not been in the system since 10.03.2010.
 DROP TABLE Users
 GO

 CREATE TABLE Users (
    UserId Int IDENTITY,
    Username nvarchar(50) NOT NULL,
    Password nvarchar(256),
    Name nvarchar(50) NOT NULL,
    LastLoginTime DATETIME,
    CONSTRAINT PK_Users PRIMARY KEY(UserId)
) 
GO

INSERT INTO Users (Username, Password, Name, LastLoginTime) 
VALUES
	('pesho', 'parola', 'Pesho Peshev', '2000-02-25 10:30:22'),
	('gosho', 'password123', 'Gosho Goshov', '2001-08-25 10:30:22'),
	('ivan', 'parola123', 'Ivan Ivanov', '2014-08-25 15:30:22'),
	('pena123', 'penchetobe', 'Penka Penecheva', '2013-02-25 10:30:22')
GO

SELECT * FROM Users

UPDATE Users
SET Password = NULL
WHERE DATEDIFF(DAY, LastLoginTime, '2010-03-10') > 1

SELECT * FROM Users

--- 24. Write a SQL statement that deletes all 
 --- users without passwords (NULL password).
 DELETE FROM Users
 WHERE Password IS NULL

-- 25. Write a SQL query to display the average 
-- employee salary by department and job title.
SELECT AVG(e.Salary) AS [Salary], e.JobTitle, d.Name AS [Department]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name

-- 26. Write a SQL query to display the minimal employee salary
-- by department and job title along with the name of some of the 
-- employees that take it.
SELECT MIN(e.Salary) AS [Salary], d.Name AS [Department],
	e.JobTitle, MIN(CONCAT(e.FirstName, ' ', e.LastName)) AS [Employee]
FROM Employees e 
JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY MIN(e.Salary)

-- 27. Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name AS [Town], COUNT(e.EmployeeID) AS [Employees Count]
FROM Towns t
JOIN Addresses a
	ON t.TownID = a.TownID
JOIN Employees e
	ON a.AddressID = e.AddressID
GROUP BY t.Name
ORDER BY COUNT(e.EmployeeID) DESC

-- 28 Write a SQL query to display the number of managers from each town.
SELECT t.Name AS [Town], COUNT(m.EmployeeID) AS [Managers Count]
FROM Towns t
JOIN Addresses a
	ON t.TownID = a.TownID
JOIN Employees m
	ON a.AddressID = m.AddressID
JOIN Employees e
	ON e.ManagerID = m.EmployeeID
GROUP BY t.Name

--- 29. Write a SQL to create table WorkHours to store work reports 
--- for each employee (employee id, date, task, hours, comments). 
--- Don't forget to define  identity, primary key and appropriate foreign key. 
---
--- Issue few SQL statements to insert, update and delete of some data in the table.
--- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
---
--- For each change keep the old record data, the new record data and the 
--- command (insert / update / delete).

--- TABLE: WorkHours
CREATE TABLE WorkHours (
    WorkReportId int IDENTITY,
    EmployeeId Int NOT NULL,
    OnDate DATETIME NOT NULL,
    Task nvarchar(256) NOT NULL,
    Hours Int NOT NULL,
    Comments nvarchar(256),
    CONSTRAINT PK_Id PRIMARY KEY(WorkReportId),
    CONSTRAINT FK_Employees_WorkHours 
        FOREIGN KEY (EmployeeId)
        REFERENCES Employees(EmployeeId)
) 
GO

--- INSERT
DECLARE @counter int;
SET @counter = 20;
WHILE @counter > 0
BEGIN
    INSERT INTO WorkHours(EmployeeId, OnDate, Task, [Hours])
    VALUES (@counter, GETDATE(), 'TASK: ' + CONVERT(varchar(10), @counter), @counter)
    SET @counter = @counter - 1
END

--- UPDATE
UPDATE WorkHours
SET Comments = 'WORK!'
WHERE [Hours] > 10

--- DELETE
DELETE FROM WorkHours
WHERE EmployeeId IN (1, 3, 5, 7, 13)

--- TABLE: WorkHoursLogs
CREATE TABLE WorkHoursLogs (
    WorkLogId int,
    EmployeeId Int NOT NULL,
    OnDate DATETIME NOT NULL,
    Task nvarchar(256) NOT NULL,
    Hours Int NOT NULL,
    Comments nvarchar(256),
    [Action] nvarchar(50) NOT NULL,
    CONSTRAINT FK_Employees_WorkHoursLogs
        FOREIGN KEY (EmployeeId)
        REFERENCES Employees(EmployeeId),
    CONSTRAINT [CC_WorkReportsLogs] CHECK ([Action] IN ('Insert', 'Delete', 'DeleteUpdate', 'InsertUpdate'))
) 
GO

--- TRIGGER FOR INSERT
CREATE TRIGGER tr_InsertWorkReports ON WorkHours FOR INSERT
AS
INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'Insert'
    FROM inserted
GO

--- TRIGGER FOR DELETE
CREATE TRIGGER tr_DeleteWorkReports ON WorkHours FOR DELETE
AS
INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'Delete'
    FROM deleted
GO

--- TRIGGER FOR UPDATE
CREATE TRIGGER tr_UpdateWorkReports ON WorkHours FOR UPDATE
AS
INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'InsertUpdate'
    FROM inserted

INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'DeleteUpdate'
    FROM deleted
GO

--- TEST TRIGGERS
DELETE FROM WorkHoursLogs

INSERT INTO WorkHours(EmployeeId, OnDate, Task, [Hours])
VALUES (25, GETDATE(), 'TASK: 25', 25)

DELETE FROM WorkHours
WHERE EmployeeId = 25

UPDATE WorkHours
SET Comments = 'Updated'
WHERE EmployeeId = 2

--- 30. Start a database transaction, delete all employees from 
--- the 'Sales' department along with all dependent records from 
--- the pother tables. At the end rollback the transaction.

BEGIN TRAN

ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees
GO

DELETE e FROM Employees e
JOIN Departments d
    ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--- ROLLBACK TRAN
--- COMMIT TRAN

--- 31. Start a database transaction and drop the table EmployeesProjects.
--- Now how you could restore back the lost table data?

BEGIN TRANSACTION

DROP TABLE EmployeesProjects

ROLLBACK TRANSACTION
--- COMMIT TRANSACTION

--- 32. Find how to use temporary tables in SQL Server. Using temporary 
--- tables backup all records from EmployeesProjects and restore them back 
--- after dropping and re-creating the table.

BEGIN TRANSACTION

SELECT * 
INTO #TempEmployeesProjects  --- Create new table
FROM EmployeesProjects

DROP TABLE EmployeesProjects

SELECT * 
INTO EmployeesProjects --- Create new table
FROM #TempEmployeesProjects;

DROP TABLE #TempEmployeesProjects

ROLLBACK TRANSACTION
-- COMMIT TRANSACTION
