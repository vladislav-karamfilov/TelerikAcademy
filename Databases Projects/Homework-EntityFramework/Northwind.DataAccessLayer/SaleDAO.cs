namespace Northwind.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Northwind.Data;

    public class SaleDAO
    {
        public static IEnumerable<string> GetSalesByRegionAndPeriod(string region, DateTime startDate, DateTime endDate)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                var specifiedSales = northwindEntities.Invoices.Where(s => s.Region == region &&
                    s.ShippedDate.Value.CompareTo(startDate) >= 0 && s.ShippedDate.Value.CompareTo(endDate) <= 0)
                    .Select(s => new
                    {
                        Product = s.ProductName,
                        Customer = s.CustomerName,
                        Quantity = s.Quantity,
                        ShippedDate = s.ShippedDate,
                    });

                IList<string> sales = new List<string>();
                foreach (var sale in specifiedSales)
                {
                    sales.Add(string.Format("Product: {0}{4}Customer: {1}{4}Quantity: {2}{4}Shipped date: {3}{4}",
                        sale.Product, sale.Customer, sale.Quantity,
                        sale.ShippedDate.Value.ToShortDateString(), Environment.NewLine));
                }

                return sales;
            }
        }
    }
}
