namespace Northwind.DataAccessLayer
{
    using System;
    using System.Linq;
    using Northwind.Data;
    using System.Collections.Generic;
    using System.Data.Objects;

    public class CustomerDAO
    {
        public static void AddCustomer(string id, string companyName)
        {
            AddCustomer(id, companyName, null, null, null, null, null, null, null, null, null);
        }

        public static void AddCustomer(
            string id,
            string companyName,
            string contactName,
            string contactTitle,
            string address,
            string city,
            string region,
            string postalCode,
            string country,
            string phone,
            string fax)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                Customer newCustomer = new Customer()
                {
                    CustomerID = id,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };

                northwindEntities.Customers.Add(newCustomer);
                northwindEntities.SaveChanges();
            }
        }

        public static bool DeleteCustomer(string id)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                Customer customerToDelete = northwindEntities.Customers.Find(id);
                if (customerToDelete != null)
                {
                    northwindEntities.Customers.Remove(customerToDelete);
                    northwindEntities.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public static bool ModifyCustomer(
            string id,
            string newCompanyName,
            string newContactName,
            string newContactTitle,
            string newAddress,
            string newCity,
            string newRegion,
            string newPostalCode,
            string newCountry,
            string newPhone,
            string newFax)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                Customer customerToModify = northwindEntities.Customers.Find(id);
                if (customerToModify != null)
                {
                    customerToModify.CompanyName = newCompanyName ?? customerToModify.CompanyName;
                    customerToModify.ContactName = newContactName ?? customerToModify.ContactName;
                    customerToModify.ContactTitle = newContactTitle ?? customerToModify.ContactTitle;
                    customerToModify.Address = newAddress ?? customerToModify.Address;
                    customerToModify.City = newCity ?? customerToModify.City;
                    customerToModify.Region = newRegion ?? customerToModify.Region;
                    customerToModify.PostalCode = newPostalCode ?? customerToModify.PostalCode;
                    customerToModify.Country = newCountry ?? customerToModify.Country;
                    customerToModify.Phone = newPhone ?? customerToModify.Phone;
                    customerToModify.Fax = newFax ?? customerToModify.Fax;
                    northwindEntities.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public static IEnumerable<string> GetCustomersByOrdersYearAndShipCountry(int year, string shipCountry)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                IEnumerable<string> customers = northwindEntities.Orders
                    .Where(o => o.OrderDate.Value.Year == year && o.ShipCountry == shipCountry)
                    .Select(c => c.Customer.ContactName).Distinct().ToList();

                return customers;
            }
        }

        public static IEnumerable<string> GetCustomersByOrdersYearAndShipCountrySQL(int year, string shipCountry)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                IEnumerable<string> customers = northwindEntities.Database.SqlQuery<string>(
                    @"SELECT DISTINCT c.ContactName AS [Customer Name]
                      FROM Orders AS o JOIN Customers AS c
	                    ON o.CustomerID = c.CustomerID
                      WHERE YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1}", year, shipCountry).ToList();

                return customers;
            }
        }
    }
}
