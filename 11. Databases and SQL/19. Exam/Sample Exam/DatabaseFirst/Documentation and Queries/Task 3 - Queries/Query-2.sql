USE Company

SELECT Departments.Name, COUNT(Employees.Id)
FROM Departments
	JOIN Employees
	ON Departments.Id = Employees.DepartmentId
GROUP BY Departments.Name
ORDER BY COUNT(Employees.Id)