using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AllProductsContainingString
{
    class AllProductsContainingStringUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Reading a string from the console and finding all products containing it***"); 
            Console.Write(decorationLine);

            Console.Write("Enter the searched string: ");
            string searched = Console.ReadLine();

            SqlConnection dbConnection = new SqlConnection(Settings.Default.DBConnectionString);

            IEnumerable<string> productsContainingString = GetProductsContainingString(searched, dbConnection);
            Console.WriteLine("All products containing '{0}' are: {1}",
                searched, string.Join(", ", productsContainingString));
        }

        static IEnumerable<string> GetProductsContainingString(string searched, SqlConnection dbConnection)
        {
            searched = searched.Replace("%", "[%]");
            searched = searched.Replace("_", "[_]");

            dbConnection.Open();
            using (dbConnection)
            {
                IList<string> productsContainingString = new List<string>();

                SqlCommand productsContainingStringCommand = new SqlCommand(
                    @"SELECT ProductName FROM Products
                      WHERE ProductName LIKE @searched",
                    dbConnection);
                productsContainingStringCommand.Parameters.AddWithValue("@searched", string.Format("%{0}%", searched));

                SqlDataReader productsInfo = productsContainingStringCommand.ExecuteReader();
                using (productsInfo)
                {
                    while (productsInfo.Read())
                    {
                        productsContainingString.Add((string)productsInfo["ProductName"]);
                    }
                }

                return productsContainingString;
            }
        }
    }
}
