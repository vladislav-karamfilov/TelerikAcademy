namespace Supermarket.UI
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Linq;
    using ICSharpCode.SharpZipLib.Core;
    using ICSharpCode.SharpZipLib.Zip;
    using Supermarket.Data;
    using Supermarket.Model.MySQL;

    public class DataMigrator
    {
        private const string TempFolderForExtract = @"../../Temp";

        private ICollection<Models.Sale> GetSalesFromExcelFiles(
            string directory, SupermarketContext supermarketContext)
        {
            IList<Models.Sale> sales = new List<Models.Sale>();

            string[] excelFilesPaths = Directory.GetFiles(directory, "*.xls");
            foreach (var excelFilePath in excelFilesPaths)
            {
                string excelConnectionString = string.Format(
                    Settings.Default.ExcelReadConnectionString, excelFilePath);

                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                excelConnection.Open();
                DataSet dataSet = new DataSet();
                using (excelConnection)
                {
                    string selectAllRowsCommandString = "SELECT * FROM [Sales$]";
                    OleDbCommand selectAllRowsCommand = new OleDbCommand(selectAllRowsCommandString, excelConnection);

                    OleDbDataAdapter excelAdapter = new OleDbDataAdapter(selectAllRowsCommand);
                    excelAdapter.Fill(dataSet, "Sales");
                }

                DataRowCollection excelRows = dataSet.Tables["Sales"].Rows;

                string supermarketName = excelRows[0][0].ToString();
                if (!supermarketContext.Supermarkets.Any(s => s.Name == supermarketName))
                {
                    supermarketContext.Supermarkets.Add(new Models.SupermarketBranch()
                    {
                        Name = supermarketName
                    });
                    supermarketContext.SaveChanges();
                }

                for (int i = 2; i < excelRows.Count - 2; i++)
                {
                    int productID = 0;
                    int.TryParse(excelRows[i][0].ToString(), out productID);

                    if (productID != 0)
                    {
                        int quantity = 0;
                        int.TryParse(excelRows[i][1].ToString(), out quantity);

                        decimal unitPrice = 0;
                        decimal.TryParse(excelRows[i][2].ToString(), out unitPrice);

                        decimal sum = 0;
                        decimal.TryParse(excelRows[i][3].ToString(), out sum);

                        int supermarketID =
                            supermarketContext.Supermarkets.First(s => s.Name == supermarketName).ID;
                        string saleDateString = Path.GetFileName(Path.GetDirectoryName(excelFilePath));
                        sales.Add(new Models.Sale()
                        {
                            Date = DateTime.Parse(saleDateString),
                            Product = supermarketContext.Products.Find(productID),
                            Quantity = quantity,
                            Sum = sum,
                            Supermarket = supermarketContext.Supermarkets.Find(supermarketID),
                            UnitPrice = unitPrice
                        });
                    }
                }
            }

            return sales;
        }

        private void GetSales(string directory,
            SupermarketContext supermarketContext, IList<Models.Sale> allSales)
        {
            foreach (var sale in GetSalesFromExcelFiles(directory, supermarketContext))
            {
                allSales.Add(sale);
            }

            string[] subDirectories = Directory.GetDirectories(directory);
            if (subDirectories.Length > 0)
            {
                for (int i = 0; i < subDirectories.Length; i++)
                {
                    GetSales(subDirectories[i], supermarketContext, allSales);
                }
            }
        }

        private void ExtractZipFile(string filepath)
        {
            FileStream fileReadStream = File.OpenRead(filepath);
            ZipFile zipFile = new ZipFile(fileReadStream);
            using (zipFile)
            {
                foreach (ZipEntry zipEntry in zipFile)
                {
                    if (zipEntry.IsFile)
                    {
                        String entryFileName = zipEntry.Name;

                        byte[] buffer = new byte[4096];
                        Stream zipStream = zipFile.GetInputStream(zipEntry);

                        string fullZipToPath = Path.Combine(TempFolderForExtract, entryFileName);
                        string directoryName = Path.GetDirectoryName(fullZipToPath);
                        if (directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(directoryName);
                        }

                        using (FileStream streamWriter = File.Create(fullZipToPath))
                        {
                            StreamUtils.Copy(zipStream, streamWriter, buffer);
                        }
                    }
                }
            }
        }

        public void MigrateDataFromExcelFiles(string zipFilePath)
        {
            ExtractZipFile(zipFilePath);

            using (var supermarketContext = new SupermarketContext())
            {
                IList<Models.Sale> allSales = new List<Models.Sale>();
                GetSales(TempFolderForExtract, supermarketContext, allSales);

                foreach (var sale in allSales)
                {
                    supermarketContext.Sales.Add(sale);
                }

                supermarketContext.SaveChanges();
            }

            Directory.Delete(TempFolderForExtract, true);
        }

        public void MigrateDataFromMySqlToSqlServer()
        {
            using (var supermarketContextSqlServer = new SupermarketContext())
            {
                using (var supermarketContextMySql = new SupermarketModel())
                {
                    foreach (var measureMySql in supermarketContextMySql.Measures)
                    {
                        if (!supermarketContextSqlServer.Measures
                            .Any(m => m.MeasureName == measureMySql.MeasureName))
                        {
                            supermarketContextSqlServer.Measures.Add(new Models.Measure()
                            {
                                MeasureName = measureMySql.MeasureName
                            });
                        }
                    }

                    foreach (var vendorMySql in supermarketContextMySql.Vendors)
                    {
                        if (!supermarketContextSqlServer.Vendors
                            .Any(v => v.VendorName == vendorMySql.VendorName))
                        {
                            supermarketContextSqlServer.Vendors.Add(new Models.Vendor()
                            {
                                VendorName = vendorMySql.VendorName
                            });
                        }
                    }

                    supermarketContextSqlServer.SaveChanges();

                    foreach (var productMySql in supermarketContextMySql.Products)
                    {
                        if (!supermarketContextSqlServer.Products
                            .Any(p => p.Name == productMySql.ProductName))
                        {
                            var vendorSqlServer = supermarketContextSqlServer.Vendors
                                .First(v => v.VendorName == productMySql.Vendor.VendorName);
                            var measureSqlServer = supermarketContextSqlServer.Measures
                                .First(m => m.MeasureName == productMySql.Measure.MeasureName);

                            supermarketContextSqlServer.Products.Add(new Models.Product()
                            {
                                BasePrice = productMySql.BasePrice,
                                Name = productMySql.ProductName,
                                Measure = measureSqlServer,
                                Vendor = vendorSqlServer,
                            });
                        }
                    }
                }

                supermarketContextSqlServer.SaveChanges();
            }
        }
    }
}