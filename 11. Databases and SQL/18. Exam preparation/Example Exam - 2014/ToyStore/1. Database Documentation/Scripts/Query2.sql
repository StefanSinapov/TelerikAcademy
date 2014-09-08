USE ToyStore

SELECT Manufacturers.Name, COUNT(Toys.Id)
FROM Manufacturers
	JOIN Toys
		ON Manufacturers.Id = Toys.ManufacturerId
	JOIN AgeRanges
		ON AgeRanges.Id = Toys.AgeRangeId
	WHERE  5 < AgeRanges.MinAge AND AgeRanges.MaxAge < 10 
GROUP BY Manufacturers.Name