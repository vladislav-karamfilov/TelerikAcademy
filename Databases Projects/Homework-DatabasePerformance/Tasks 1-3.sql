USE LogsDB
GO

-- 1. Create a table in SQL Server with 10 000 000 log entries (date + text). 
-- Search in the table by date range. Check the speed (without caching).
INSERT INTO Logs([Text], [Date])
VALUES ('Sample log 0', '1985-01-01 00:00:00.000'),
	   ('Sample log 1', '1995-09-02 00:00:00.000')
GO

DECLARE @Counter int = 0
WHILE (SELECT COUNT(*) FROM Logs) < 1000000
BEGIN
  INSERT INTO Logs([Text], [Date])
  SELECT [Text] + CONVERT(nvarchar, @Counter), DATEADD(month, @Counter + 3, [Date])
  FROM Logs
  SET @Counter = @Counter + 1
END

SELECT [Text], [Date] FROM Logs
WHERE [Date] BETWEEN '1995-01-01 00:00:00.000' AND '2020-01-01 00:00:00.000'

-- 2. Add an index to speed-up the search by date. 
-- Test the search speed (after cleaning the cache).
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

CREATE INDEX IDX_Logs_LogsDates ON Logs([Date])

SELECT [Text], [Date] FROM Logs
WHERE [Date] BETWEEN '1995-01-01 00:00:00.000' AND '2020-01-01 00:00:00.000'

-- 3. Add a full text index for the text column. Try to search with 
-- and without the full-text index and compare the speed.
SELECT * FROM Logs
WHERE [Text] > 'Sample log 0' AND [Text] < 'Sample log 01234'

CREATE FULLTEXT CATALOG LogsFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Logs([Text])
KEY INDEX PK_Logs
ON LogsFullTextCatalog
WITH CHANGE_TRACKING AUTO

SELECT * FROM Logs
WHERE [Text] > 'Sample log 0' AND [Text] < 'Sample log 01234'
