USE Company

SELECT CONCAT(Employees.FirstName, ' ', Employees.LastName) AS [Full Name], Employees.YearSalary
FROM Employees
WHERE Employees.YearSalary >= 100000 AND Employees.YearSalary <= 150000