USE NORTHWND
GO

CREATE PROC usp_GetTotalIncomesBySupplierNameAndPeriod(@supplierName NVARCHAR(40), @startDate DATETIME, @endDate DATETIME)
AS
	SELECT SUM(od.UnitPrice) AS [Total Incomes]
	FROM [Order Details] AS od 
	JOIN Products AS p
		ON od.ProductID = p.ProductID
	JOIN Suppliers AS s
		ON p.SupplierID = s.SupplierID
	JOIN Orders AS o
		ON od.OrderID = o.OrderID
	WHERE (o.ShippedDate BETWEEN @startDate AND @endDate) AND s.CompanyName = @supplierName
GO