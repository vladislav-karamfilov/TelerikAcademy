namespace Supermarket.UI
{
    using System;
    using System.Data.OleDb;
    using System.Linq;
    using MongoDB.Driver;
    using Supermarket.Data;
    using Supermarket.Model.SQLite;

    public class VendorsTotalReportCreator
    {
        public void CreateVendorsTotalReport()
        {
            using (var productsReportEntities = new ProductEntities())
            {
                var mongoClient = new MongoClient("mongodb://localhost/");
                var mongoServer = mongoClient.GetServer();
                var supermarket = mongoServer.GetDatabase("supermarket");
                var productReportsCollection = supermarket.GetCollection<ProductReport>("productReports");

                foreach (var productReport in productReportsCollection.FindAll())
                {
                    productsReportEntities.ProductsReports.Add(new ProductsReport()
                    {
                        ProductName = productReport.ProductName,
                        TotalIncomes = productReport.TotalIncomes,
                        TotalQuantitySold = productReport.TotalQuantitySold,
                        VendorName = productReport.VendorName
                    });
                }

                productsReportEntities.SaveChanges();

                // var productsTaxes = productsReportEntities.ProductsTaxes.ToList();

                using (var supermarketContex = new SupermarketContext())
                {
                    DateTime currentDate = DateTime.Now;
                    var vendorsIncomes =
                        (from product in supermarketContex.Products
                         join sale in supermarketContex.Sales
                             on product.ID equals sale.ProductID
                         join vendor in supermarketContex.Vendors
                             on product.VendorID equals vendor.ID
                         where (sale.Date.Year == currentDate.Year && sale.Date.Month == currentDate.Month)
                         group sale by vendor.VendorName into salesPerVendor
                         select new
                         {
                             VendorName = salesPerVendor.Key,
                             Incomes = salesPerVendor.Sum(x => x.Sum)
                         }).ToList();

                    var vendorsExpenses =
                        (from expense in supermarketContex.Expenses
                         join vendor in supermarketContex.Vendors
                            on expense.VendorID equals vendor.ID
                         where (expense.Month.Year == currentDate.Year && expense.Month.Month == currentDate.Month)
                         group expense by vendor.VendorName into g
                         select new
                         {
                             VendorName = g.Key,
                             Expenses = g.Sum(x => x.Value) / g.Count()
                         }).ToList();

                    // TODO: Find Vendors Taxes!!!

                    OleDbConnection excelConnection =
                        new OleDbConnection(Settings.Default.ExcelWriteConnectionString);
                    excelConnection.Open();
                    using (excelConnection)
                    {
                        OleDbCommand createTableCommand = new OleDbCommand(@"CREATE TABLE ProductsTotalReport ([Vendor] string, [Incomes] string, 
                        [Expenses] string, [Taxes] string, [Financial Result] string)", excelConnection);
                        createTableCommand.ExecuteNonQuery();

                        for (int i = 0; i < vendorsExpenses.Count; i++)
                        {
                            AddRow(
                                excelConnection,
                                vendorsExpenses[i].VendorName,
                                vendorsIncomes[i].Incomes.ToString(),
                                vendorsExpenses[i].Expenses.ToString(),
                                51.ToString(),
                                (vendorsIncomes[i].Incomes - vendorsExpenses[i].Expenses - 51).ToString());
                        }
                    }
                }
            }
        }

        private void AddRow(OleDbConnection dbCon, string vendor, string incomes, string expenses, string taxes, string result)
        {
            OleDbCommand cmdInsert = new OleDbCommand("insert into [ProductsTotalReport$](Vendor, Incomes, Expenses, Taxes, [Financial Result]) " +
                "VALUES (@vendor,  @incomes, @expenses, @taxes, @results)", dbCon);
            cmdInsert.Parameters.AddWithValue("@vendor", vendor);
            cmdInsert.Parameters.AddWithValue("@incomes", incomes);
            cmdInsert.Parameters.AddWithValue("@expenses", expenses);
            cmdInsert.Parameters.AddWithValue("@taxes", taxes);
            cmdInsert.Parameters.AddWithValue("@[Financial Result]", result);
            cmdInsert.ExecuteNonQuery();
        }
    }
}
