namespace Supermarket.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using MongoDB.Driver;
    using Supermarket.Data;
    
    public class XmlVendorExpensesLoader
    {
        private IList<string[]> ReadVendorsExpenses(string sourceFilePath)
        {
            var expenses = new List<string[]>();
            using (XmlReader reader = XmlReader.Create(sourceFilePath))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "sale"))
                    {
                        string vendorName = reader.GetAttribute("vendor");

                        if (reader.ReadToDescendant("expenses"))
                        {
                            string month = reader.GetAttribute("month");
                            string expenseValue = reader.ReadElementString();

                            expenses.Add(new string[] { vendorName, month, expenseValue });

                            while (reader.ReadToNextSibling("expenses"))
                            {
                                month = reader.GetAttribute("month");
                                expenseValue = reader.ReadElementString();

                                expenses.Add(new string[] { vendorName, month, expenseValue });
                            }
                        }
                    }
                }
            }

            return expenses;
        }

        private void LoadVendorExpensesToSqlServer(IList<string[]> expenses)
        {
            using (var supermarketContext = new SupermarketContext())
            {
                foreach (var expense in expenses)
                {
                    string vendorName = expense[0];
                    int vendorID = supermarketContext.Vendors.First(v => v.VendorName == vendorName).ID;
                    decimal value = decimal.Parse(expense[2]);

                    Models.Expense newExpense = new Models.Expense()
                    {
                        VendorID = vendorID,
                        Month = DateTime.Parse(expense[1]),
                        Value = value
                    };

                    supermarketContext.Expenses.Add(newExpense);
                }

                supermarketContext.SaveChanges();
            }
        }

        private void LoadVendorExpensesToMongoDB(IList<string[]> expenses)
        {
            var mongoClient = new MongoClient("mongodb://localhost/");
            var mongoServer = mongoClient.GetServer();
            var supermarket = mongoServer.GetDatabase("supermarket");
            var expensesCollection = supermarket.GetCollection<Model.Mongo.Expense>("expenses");

            foreach (var expense in expenses)
            {
                Model.Mongo.Expense newExpense = 
                    new Model.Mongo.Expense(expense[0], decimal.Parse(expense[2]), DateTime.Parse(expense[1]));

                expensesCollection.Insert(newExpense);
            }
        }

        public void LoadVendorsExpensesFromXml(string sourceFilePath)
        {
            var expenses = ReadVendorsExpenses(sourceFilePath);
            LoadVendorExpensesToSqlServer(expenses);
            LoadVendorExpensesToMongoDB(expenses);
        }
    }
}
