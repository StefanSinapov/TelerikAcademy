------------------------------------------
-- 2. Add an index to speed-up the search by date.
-- Test the search speed (after cleaning the cache).
------------------------------------------

USE PerformanceHomeworkDB
GO

CREATE INDEX IDX_Logs_PublishDate
ON Logs ( PublishDate )

--------------------------------
-- Search by date range
--------------------------------
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT *
FROM Logs
WHERE PublishDate BETWEEN '1950-01-01' AND '2900-01-01'