namespace Northwind.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Northwind.DataAccessLayer;

    class NorthwindUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Performing various operations over the 'Northwind' database");
            Console.WriteLine("through DAO classes***");
            Console.Write(decorationLine);

            Console.WriteLine("---Inserting a new customer---");
            CustomerDAO.AddCustomer(
                "ABCDE", "Pesho OOD", "Dilqna Marinova", null, null, "Sofia", "Sofia", null, "Bulgaria", null, null);
            Console.WriteLine("Customer successfully added!\n");

            Console.WriteLine("---Deleting a customer---");
            string customerIdToDelete = "BOLID";
            if (CustomerDAO.DeleteCustomer(customerIdToDelete))
            {
                Console.WriteLine("Customer successfully deleted!\n");
            }
            else
            {
                Console.WriteLine("Customer with ID '{0}' not found.\n", customerIdToDelete);
            }

            Console.WriteLine("---Modifying a customer---");
            string customerIdToModify = "ABCDE";
            if (CustomerDAO.ModifyCustomer(customerIdToModify, "Gosho OOD", null,
                "Dilqna.Marinova", null, null, null, null, null, "123456789", "555-555-55"))
            {
                Console.WriteLine("Customer successfully modified!\n");
            }
            else
            {
                Console.WriteLine("Customer with ID '{0}' not found.\n", customerIdToModify);
            }

            Console.WriteLine("---Finding customers with orders made in a specified year and country---");
            IEnumerable<string> customersByOrdersYearAndCountry = CustomerDAO.GetCustomersByOrdersYearAndShipCountry(1997, "Canada");
            // IEnumerable<string> customersWithSpecificOrders = CustomerDAO.GetCustomersByOrdersYearAndShipCountrySQL(1997, "Canada");
            Console.WriteLine(string.Join(Environment.NewLine, customersByOrdersYearAndCountry));
            Console.WriteLine();

            Console.WriteLine("---Finding all sales by specified region and period---");
            var salesByRegionAndPeriod = SaleDAO.GetSalesByRegionAndPeriod("RJ", new DateTime(1996, 07, 10), new DateTime(1996, 8, 10));
            Console.WriteLine(string.Join(Environment.NewLine, salesByRegionAndPeriod));
        }
    }
}
