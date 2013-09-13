using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CategoriesNamesAndDescriptions
{
    class CategoriesNamesAndDescriptionsUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Getting the names and the descriptions of the categories");
            Console.WriteLine("in the 'Northwind' database***");
            Console.Write(decorationLine);

            SqlConnection dbConnection = new SqlConnection(Settings.Default.DBConnectionString);

            IEnumerable<string> categoriesInfo = GetCategoriesInfo(dbConnection); 
            Console.WriteLine("The names and the descriptions of the categories are:");
            foreach (string categoryInfo in categoriesInfo)
            {
                Console.WriteLine("- {0}", categoryInfo);
            }
        }

        static IEnumerable<string> GetCategoriesInfo(SqlConnection dbConnection)
        {
            IList<string> categoriesInfo = new List<string>();
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand getCategoriesInfoQuery = new SqlCommand(
                    "SELECT CategoryName, Description FROM Categories", dbConnection);

                SqlDataReader dbInfo = getCategoriesInfoQuery.ExecuteReader();
                using (dbInfo)
                {
                    StringBuilder categoryInfo = new StringBuilder();
                    while (dbInfo.Read())
                    {
                        categoryInfo.AppendFormat(
                            "Name: {0} | Description: {1}",
                            (string)dbInfo["CategoryName"],
                            (string)dbInfo["Description"]);
                        categoriesInfo.Add(categoryInfo.ToString());
                        categoryInfo.Clear();
                    }
                }
            }

            return categoriesInfo;
        }
    }
}
