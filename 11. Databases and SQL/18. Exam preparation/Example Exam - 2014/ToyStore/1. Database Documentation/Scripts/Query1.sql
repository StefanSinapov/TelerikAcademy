USE ToyStore

SELECT Toys.Name, Toys.Price
FROM Toys
WHERE Toys.Type = 'puzzle' AND Toys.Price > 10
ORDER BY Toys.Price