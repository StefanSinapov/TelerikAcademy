USE Company

SELECT CONCAT(Employees.FirstName, ' ', Employees.LastName) AS [FullName], 
		Projects.Name AS [Project], Departments.Name AS [Department],
		 EmployeesProjects.StarDate, EmployeesProjects.EndDate, COUNT(Reports.Id) AS [Reports]
FROM Employees
	JOIN EmployeesProjects
		ON Employees.Id = EmployeesProjects.EmployeeId
	JOIN Projects
		ON Projects.Id = EmployeesProjects.ProjectId
	JOIN Departments
		ON Employees.DepartmentId = Departments.Id
	JOIN Reports
		ON Employees.Id = Reports.EmployeeId 
			AND Reports.TimeOfReporting >= EmployeesProjects.StarDate
			AND Reports.TimeOfReporting <= EmployeesProjects.EndDate

GROUP BY CONCAT(Employees.FirstName, ' ', Employees.LastName), Projects.Name, Departments.Name,
		 EmployeesProjects.StarDate, EmployeesProjects.EndDate, Employees.Id, Projects.Id
ORDER BY Employees.Id , Projects.Id