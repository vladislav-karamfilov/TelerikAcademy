using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CategoriesWithProducts
{
    class CategoriesWithProductsUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Getting the categories and the prodcuts in them");
            Console.WriteLine("from the 'Northwind' database***");
            Console.Write(decorationLine);

            SqlConnection dbConnection = new SqlConnection(Settings.Default.DBConnectionString);

            IEnumerable<string> categoriesWithProducts = GetCategoriesWithProducts(dbConnection);
            Console.WriteLine("The categories and the products in them are:");
            foreach (string categoryProductPair in categoriesWithProducts)
            {
                Console.WriteLine("{0}", categoryProductPair);
            }
        }

        static IEnumerable<string> GetCategoriesWithProducts(SqlConnection dbConnection)
        {
            IList<string> categoryProductPairs = new List<string>();
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand getCategoryProductPairsQuery = new SqlCommand(
                    @"SELECT c.CategoryName, p.ProductName
                      FROM Categories c JOIN Products p
	                     ON p.CategoryID = c.CategoryID", dbConnection);

                SqlDataReader dbInfo = getCategoryProductPairsQuery.ExecuteReader();
                using (dbInfo)
                {
                    StringBuilder categoryProductPair = new StringBuilder();
                    while (dbInfo.Read())
                    {
                        categoryProductPair.AppendFormat(
                            "Category: {0} - Product: {1}",
                            (string)dbInfo["CategoryName"],
                            (string)dbInfo["ProductName"]);
                        categoryProductPairs.Add(categoryProductPair.ToString());
                        categoryProductPair.Clear();
                    }
                }
            }

            return categoryProductPairs;
        }
    }
}
