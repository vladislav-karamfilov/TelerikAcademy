namespace Supermarket.UI
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using Supermarket.Data;

    public class XmlSalesReportByVendorsCreator
    {
        private void WriteSalesByVendor(
            XmlTextWriter writer, DbSet<Models.Sale> sales, Models.Vendor vendor)
        {
            writer.WriteStartElement("sale");
            writer.WriteAttributeString("vendor", vendor.VendorName);
            foreach (var date in sales.Where(s => s.Product.VendorID == vendor.ID)
                .Select(s => s.Date).Distinct().ToList())
            {
                writer.WriteStartElement("summary");
                writer.WriteAttributeString("date", date.ToShortDateString());
                writer.WriteAttributeString("total-sum", sales.Where(s => s.Date == date &&
                    s.Product.VendorID == vendor.ID).Sum(s => s.Sum).ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        public void CreateXmlSalesByVendorsReport(string destinationFilePath)
        {
            Encoding encoding = Encoding.GetEncoding("utf-8");
            using (var supermarketContext = new SupermarketContext())
            {
                using (var writer = new XmlTextWriter(destinationFilePath, encoding))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("sales");
                    foreach (var vendor in supermarketContext.Vendors.ToList())
                    {
                        WriteSalesByVendor(writer, supermarketContext.Sales, vendor);
                    }

                    writer.WriteEndDocument();
                }
            }
        }
    }
}
