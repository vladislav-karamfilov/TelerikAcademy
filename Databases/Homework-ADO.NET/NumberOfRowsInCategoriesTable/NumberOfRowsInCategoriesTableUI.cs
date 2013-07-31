using System;
using System.Data.SqlClient;

namespace NumberOfRowsInCategoriesTable
{
    class NumberOfRowsInCategoriesTableUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Getting the number of the rows of the table 'Categories' from the 'Northwind' database***");
            Console.Write(decorationLine);

            SqlConnection dbConnection = new SqlConnection(Settings.Default.DBConnectionString);

            Console.WriteLine("The number of rows in 'Categories' table from the 'Northwind' database is {0}",
                GetRowsCountInCategoriesTable(dbConnection));
        }

        static int GetRowsCountInCategoriesTable(SqlConnection dbConnection)
        {
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand categoriesRowsCountQuery = new SqlCommand(
                    "SELECT COUNT(*) AS [Rows Count] FROM Categories", dbConnection);

                return (int)categoriesRowsCountQuery.ExecuteScalar();
            }
        }
    }
}