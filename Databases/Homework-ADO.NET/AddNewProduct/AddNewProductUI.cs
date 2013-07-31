using System;
using System.Data.SqlClient;

namespace AddNewProduct
{
    class AddNewProductUI
    {
        static readonly SqlConnection dbConnection =
            new SqlConnection(Settings.Default.DBConnectionString);

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Getting the count of the rows of the table 'Categories' from the 'Northwind' database***");
            Console.Write(decorationLine);

            Console.WriteLine("Adding a new product...");
            AddNewProduct("Product 51", 2, 5, "5 boxes", 55.5m, 33, 15, null, false);
            Console.WriteLine("Product added successfully!");
        }

        static void AddNewProduct(
            string name,
            int? supplierID,
            int? categoryID,
            string quantityPerUnit,
            decimal? unitPrice,
            short? unitsInStock,
            short? unitsOnOrder,
            short? reorderLevel,
            bool discontinued)
        {
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand insertNewProductCommand =
                    new SqlCommand(@"INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, 
			                            UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
                                 VALUES (@name, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, 
                                        @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)", dbConnection);

                insertNewProductCommand.Parameters.AddWithValue("@name", name);

                SqlParameter supplierIDParameter = new SqlParameter("@supplierID", supplierID);
                if (supplierID == null)
                {
                    supplierIDParameter.Value = DBNull.Value;
                }

                insertNewProductCommand.Parameters.Add(supplierIDParameter);

                SqlParameter categoryIDParameter = new SqlParameter("@categoryID", categoryID);
                if (categoryID == null)
                {
                    categoryIDParameter.Value = DBNull.Value;
                }

                insertNewProductCommand.Parameters.Add(categoryIDParameter);

                SqlParameter quantityPerUnitParameter = new SqlParameter("@quantityPerUnit", quantityPerUnit);
                if (quantityPerUnit == null)
                {
                    quantityPerUnitParameter.Value = DBNull.Value;
                }

                insertNewProductCommand.Parameters.Add(quantityPerUnitParameter);

                SqlParameter unitPriceParameter = new SqlParameter("@unitPrice", unitPrice);
                if (unitPrice == null)
                {
                    unitPriceParameter.Value = DBNull.Value;
                }

                insertNewProductCommand.Parameters.Add(unitPriceParameter);

                SqlParameter unitsInStockParameter = new SqlParameter("@unitsInStock", unitsInStock);
                if (unitsInStock == null)
                {
                    unitsInStockParameter.Value = DBNull.Value;
                }

                insertNewProductCommand.Parameters.Add(unitsInStockParameter);

                SqlParameter unitsOnOrderParameter = new SqlParameter("@unitsOnOrder", unitsOnOrder);
                if (unitsOnOrder == null)
                {
                    unitsOnOrderParameter.Value = DBNull.Value;
                }

                insertNewProductCommand.Parameters.Add(unitsOnOrderParameter);

                SqlParameter reorderLevelParameter = new SqlParameter("@reorderLevel", reorderLevel);
                if (reorderLevel == null)
                {
                    reorderLevelParameter.Value = DBNull.Value;
                }

                insertNewProductCommand.Parameters.Add(reorderLevelParameter);

                insertNewProductCommand.Parameters.AddWithValue("@discontinued", discontinued);

                insertNewProductCommand.ExecuteNonQuery();
            }
        }
    }
}
