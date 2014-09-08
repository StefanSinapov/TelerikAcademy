-------------------------
-- 3. Add a full text index for the text column. 
-- Try to search with and without the full-text index and compare the speed.
-------------------------
USE PerformanceHomeworkDB
GO

-------------------------
-- Searching without text index
-------------------------
SELECT * FROM Logs
WHERE Message LIKE '%123%'


-------------------------
-- Create Full text index
-------------------------
CREATE FULLTEXT CATALOG MessagesFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Logs([Message])
KEY INDEX PK_Logs
ON MessagesFullTextCatalog
WITH CHANGE_TRACKING AUTO

------------------------
-- Search with full text index
------------------------
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM Logs
WHERE CONTAINS(Message,'123')
GO
