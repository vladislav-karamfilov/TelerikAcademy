namespace Supermarket.UI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Supermarket.Data;

    public class MongoDBProductReportsLoader
    {
        private const string ProductReportQuery =
                                "SELECT DISTINCT p.ID AS ProductID, p.[Product Name] AS ProductName, v.[Vendor Name] AS VendorName, " +
                                "COUNT(p.ID) AS TotalQuantitySold, SUM(p.BasePrice) AS TotalIncomes " +
                                "FROM Products p " +
                                "JOIN Sales s " +
                                    "ON s.ProductID = p.ID " +
                                "JOIN Vendors v " +
                                    "ON p.VendorID = v.ID " +
                                "GROUP BY p.ID, p.[Product Name], v.[Vendor Name]";

        private List<ProductReport> GetProductReports()
        {
            using (SupermarketContext context = new SupermarketContext())
            {
                List<ProductReport> productReports = new List<ProductReport>();
                productReports = context.Database.SqlQuery<ProductReport>(ProductReportQuery).ToList();
                return productReports;
            }
        }

        public void LoadReports(string destionationDirectoryPath)
        {
            List<ProductReport> productReports = GetProductReports();
            LoadReportsToFileSystem(destionationDirectoryPath, productReports);
            LoadReportsToMongoDBServer(productReports);
        }

        private void LoadReportsToFileSystem(string destinationPath, List<ProductReport> productReports)
        {
            foreach (var productReport in productReports)
            {
                using (StreamWriter writer = File.CreateText(destinationPath + productReport.ProductID + ".json"))
                {
                    var productReportString = productReport.ToJson();
                    writer.Write(productReportString);
                }
            }
        }

        private void LoadReportsToMongoDBServer(List<ProductReport> productReports)
        {
            var mongoClient = new MongoClient("mongodb://localhost/");
            var mongoServer = mongoClient.GetServer();
            var supermarket = mongoServer.GetDatabase("supermarket");
            var productReportsCollection = supermarket.GetCollection<ProductReport>("productReports");

            foreach (var productReport in productReports)
            {
                productReportsCollection.Insert(productReport);
            }
        }
    }
}
