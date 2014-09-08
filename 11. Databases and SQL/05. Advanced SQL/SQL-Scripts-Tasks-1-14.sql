USE TelerikAcademy

-- 1. Write a SQL query to find the names and salaries of the employees that take 
-- the minimal salary in the company. Use a nested SELECT statement.
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name], Salary
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

-- 2. Write a SQL query to find the names and 
-- salaries of the employees that have a salary that
-- is up to 10% higher than the minimal salary for the company.
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name], Salary
FROM Employees
WHERE Salary <= 
				(SELECT MIN(Salary) + MIN(Salary) * 0.1 
				FROM Employees)

-- 3. Write a SQL query to find the full name, 
-- salary and department of the employees that take the
-- minimal salary in their department. 
-- Use a nested SELECT statement.
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name], e.Salary, d.Name
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
		(SELECT MIN(Salary) 
		FROM Employees emp 
		WHERE emp.DepartmentID = d.DepartmentID)
ORDER BY e.Salary

-- 4. Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) AS [Average salary], d.Name AS [Department Name]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = 1 AND d.DepartmentID = 1
GROUP BY d.Name

-- 5. Write a SQL query to find the average salary  in the "Sales" department.
SELECT AVG(Salary) AS [Average salary], d.Name AS [Department Name]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'
GROUP BY d.Name

-- 6. Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(e.EmployeeID) AS [Employees], d.Name AS [Department Name]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'
GROUP BY d.Name

-- 7. Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*) AS [Employees with Manager]
FROM Employees
WHERE ManagerID IS NOT NULL

-- 8. Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) AS [Employees without Manager]
FROM Employees
WHERE ManagerID IS NULL

-- 9. Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name AS [Department], AVG(e.Salary) AS [AVG Salary]
FROM Departments d
JOIN Employees e
	ON d.DepartmentID = e.EmployeeID
GROUP BY d.Name
ORDER BY AVG(e.Salary)

-- 10. Write a SQL query to find the count of all employees in each department and for each town.
SELECT COUNT(e.EmployeeID) AS [Employees], d.Name AS [Department], t.Name AS [Town]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
	ON e.AddressID = a.AddressID
JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY d.Name

-- 11. Write a SQL query to find all managers that have exactly 5 employees.
-- Display their first name and last name.
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Manager Name], COUNT(e.EmployeeID) AS [Employees]
FROM Employees m
	JOIN Employees e
	ON m.EmployeeID = e.ManagerID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(e.EmployeeID) = 5

-- 12. Write a SQL query to find all employees along with their managers. 
-- For employees that do not have manager display the value "(no manager)".
SELECT CONCAT(e.FirstName, ' ', e.LastName) as [Employee],
       ISNULL(m.FirstName + ' ' + m.LastName, 'No manager') as [Manager]
FROM Employees e 
LEFT JOIN Employees m
    ON e.ManagerID = m.EmployeeID

-- 13. Write a SQL query to find the names of all employees 
-- whose last name is exactly 5 characters long.
-- Use the built-in LEN(str) function.
SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name]
FROM Employees
WHERE LEN(LastName) = 5

-- 14. Write a SQL query to display the current date and time in 
-- the following format "day.month.year hour:minutes:seconds:milliseconds".
-- Search in Google to find how to format dates in SQL Server.
SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff') AS [DATE];