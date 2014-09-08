USE ToyStore

SELECT Toys.Name, Toys.Price, Toys.Color, Categories.Name
FROM Toys
	JOIN ToysCategories
		ON Toys.Id = ToysCategories.ToyId
	JOIN Categories
		ON Categories.Id = ToysCategories.CategoryId
WHERE Categories.Name = 'boys'