-----------------------------------------------------
-- Create Database
-----------------------------------------------------

USE master
GO

CREATE DATABASE PerformanceHomeworkDB
GO

USE PerformanceHomeworkDB
GO

CREATE TABLE [dbo].[Logs](
    [LogId] [int] IDENTITY(1,1) NOT NULL,
    [Message] nvarchar(300) NOT NULL,
    [PublishDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
 (
    [LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

-----------------------------------------------------
-- Insert 10 000 000 recors (~ 40 mins on my old laptop :) )
-----------------------------------------------------

SET NOCOUNT ON
DECLARE @RowCount int = 10000000 

WHILE @RowCount > 0
BEGIN
    DECLARE @Message nvarchar(100);
    SET @Message = 'Message :' + CONVERT(nvarchar(100), @RowCount)
    
    DECLARE @Date datetime;
    SET @Date = DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())

    INSERT INTO Logs([Message], PublishDate)
    VALUES(@Message, @Date)
    SET @RowCount = @RowCount - 1
END
SET NOCOUNT OFF

--------------------------------
-- Search by date range
--------------------------------
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT *
FROM Logs
WHERE PublishDate BETWEEN '1950-01-01' AND '2900-01-01'