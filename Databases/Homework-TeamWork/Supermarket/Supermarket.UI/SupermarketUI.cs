namespace Supermarket.UI
{
    using System;
    using System.Data.Entity;
    using Supermarket.Data;
    using Supermarket.Data.Migrations;

    public class SupermarketUI
    {
        private const string ReportsFilePath = "../../Sample-Sales-Reports.zip";
        private const string AggregatedSalesReportsPath = "../../Aggregated-Sales-Reports";
        private const string SalesByVendorsReportFilePath = "../../Sales-by-Vendors-Report.xml";
        private const string VendorsExpensesFilePath = "../../Vendors-Expenses.xml";
        private const string ProductReportsDirectoryPath = "../../Product-Reports/";

        internal static void Main()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<SupermarketContext, Configuration>());

            // Task 1 - Load Excel Reports from ZIP File
            DataMigrator dataMigrator = new DataMigrator();
            Console.WriteLine("Migrating data from MySQL to SQL Server...");
            dataMigrator.MigrateDataFromMySqlToSqlServer();
            Console.WriteLine();
            Console.WriteLine("Migrating data from Excel files to SQL Server...");
            dataMigrator.MigrateDataFromExcelFiles(ReportsFilePath);
            Console.WriteLine();

            // Task 2 - Generate PDF Aggregated Sales Reports
            PdfAggregatedSalesReportsCreator salesReportsCreator =
                new PdfAggregatedSalesReportsCreator();
            Console.WriteLine("Generating PDF Aggregated Sales Reports...");            
            salesReportsCreator.CreatePdfAggregatedSalesReports(AggregatedSalesReportsPath);
            Console.WriteLine();

            // Task 3 - Generate XML Sales Report by Vendors
            XmlSalesReportByVendorsCreator salesReportsByVendorsCreator =
                new XmlSalesReportByVendorsCreator();
            Console.WriteLine("Generating XML Sales Report by Vendors...");
            salesReportsByVendorsCreator
                .CreateXmlSalesByVendorsReport(SalesByVendorsReportFilePath);
            Console.WriteLine();

            // Task 4 - Product Reports
            MongoDBProductReportsLoader productReportsLoader = new MongoDBProductReportsLoader();
            Console.WriteLine("Generating Product Reports to MongoDB database...");
            productReportsLoader.LoadReports(ProductReportsDirectoryPath);
            Console.WriteLine();

            // Task 5 - Load Vendor Expenses from XML
            XmlVendorExpensesLoader vendorExpensesLoader =
                new XmlVendorExpensesLoader();
            Console.WriteLine("Loading Vendor Expenses from XML...");
            vendorExpensesLoader.LoadVendorsExpensesFromXml(VendorsExpensesFilePath);
            Console.WriteLine();

            // Task 6 - Vendors Total Report
            VendorsTotalReportCreator vendorsTotalReportCreator =
                new VendorsTotalReportCreator();
            Console.WriteLine("Creating Vendors Total Report to Excel file...");
            vendorsTotalReportCreator.CreateVendorsTotalReport();
        }
    }
}
