-- 4. Create the same table in MySQL and partition it by date (1990, 2000, 2010). 
-- Fill 1 000 000 log entries. Compare the searching speed in 
-- all partitions (random dates) to certain partition (e.g. year 1995).
CREATE DATABASE DatabasePerformance;

USE DatabasePerformance;

CREATE TABLE Logs(
	LogId int NOT NULL AUTO_INCREMENT,
	LogDate datetime,
	LogText nvarchar(100),
	CONSTRAINT PK_Logs_LogId PRIMARY KEY(LogId)
);

DELIMITER $$
CREATE PROCEDURE PopulateDB()
BEGIN
	DECLARE counter INT DEFAULT 0;
	DECLARE minDate datetime;
	DECLARE maxDate datetime;
	SET minDate = '1980-01-01 00:00:00';
	SET maxDate = '2014-01-01 00:00:00';
	START TRANSACTION;
	WHILE counter < 1000000 DO
		INSERT INTO Logs(LogDate, LogText)
		VALUES(TIMESTAMPADD(SECOND, FLOOR(RAND() * TIMESTAMPDIFF(SECOND, minDate, maxDate)), minDate), 
				CONCAT('Text', CAST(counter as CHAR)));
		SET counter = counter + 1;
	END WHILE;
	COMMIT;
END $$
DROP PROCEDURE PopulateDB

CALL PopulateDB()

CREATE DATABASE PartitioningDB;

USE PartitioningDB;

CREATE TABLE Logs(
	LogId int NOT NULL AUTO_INCREMENT,
	LogDate datetime,
	LogText nvarchar(100),
	CONSTRAINT PK_Logs_LogId PRIMARY KEY(LogId, LogDate)
) PARTITION BY RANGE(YEAR(LogDate))(
	PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p2 VALUES LESS THAN (2000),
	PARTITION p3 VALUES LESS THAN (2010),
	PARTITION p4 VALUES LESS THAN MAXVALUE
);

CALL PopulateDB()

SELECT * FROM Logs PARTITION (p0)

USE DatabasePerformance;
SELECT * FROM Logs
WHERE LogDate < '1990-01-01'

USE PartitioningDB
SELECT * FROM Logs PARTITION(p0)
WHERE LogDate < '1990-01-01'