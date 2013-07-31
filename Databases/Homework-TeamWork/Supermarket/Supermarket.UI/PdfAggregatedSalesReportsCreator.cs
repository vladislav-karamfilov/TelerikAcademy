namespace Supermarket.UI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Supermarket.Data;
    using iTextSharp.text;
    using iTextSharp.text.pdf;

    public class PdfAggregatedSalesReportsCreator
    {
        private void AddSaleReportRow(float fontSize, Font.FontFamily fontFamily,
            IList<PdfPCell> cells, Models.Sale sale, string measure, string productName, string location)
        {
            cells.Add(new PdfPCell(new Phrase(productName, new Font(fontFamily, fontSize, Font.BOLD)))
            {
                PaddingBottom = 10,
                PaddingTop = 10,
                HorizontalAlignment = 1
            });

            cells.Add(new PdfPCell(new Phrase(string.Format("{0} {1}", sale.Quantity, measure),
                new Font(fontFamily, fontSize, Font.BOLD)))
            {
                PaddingBottom = 10,
                PaddingTop = 10,
                HorizontalAlignment = 1
            });

            cells.Add(new PdfPCell(new Phrase(sale.UnitPrice.ToString(),
                new Font(fontFamily, fontSize, Font.BOLD)))
            {
                PaddingBottom = 10,
                PaddingTop = 10,
                HorizontalAlignment = 1
            });

            cells.Add(new PdfPCell(new Phrase(location,
                new Font(fontFamily, fontSize, Font.BOLD)))
            {
                PaddingBottom = 10,
                PaddingTop = 10,
                HorizontalAlignment = 1
            });

            cells.Add(new PdfPCell(new Phrase(sale.Sum.ToString(),
                new Font(fontFamily, fontSize, Font.BOLD)))
            {
                PaddingBottom = 10,
                PaddingTop = 10,
                HorizontalAlignment = 1
            });
        }

        private void AddTitleRows(float fontSize, Font.FontFamily fontFamily, DateTime date, IList<PdfPCell> cells)
        {
            cells.Add(new PdfPCell(new Phrase("Aggregated Sales Report", new Font(fontFamily, fontSize, Font.BOLD)))
            {
                Colspan = 5,
                PaddingBottom = 10,
                PaddingTop = 10,
                HorizontalAlignment = 1
            });

            cells.Add(new PdfPCell(new Phrase("Date: " + date.ToShortDateString(), new Font(fontFamily, fontSize)))
            {
                Colspan = 5,
                BackgroundColor = new BaseColor(217, 217, 217),
                PaddingBottom = 10,
                PaddingTop = 10,
            });

            cells.Add(new PdfPCell(new Phrase("Product", new Font(fontFamily, fontSize, Font.BOLD)))
            {
                BackgroundColor = new BaseColor(217, 217, 217),
                PaddingBottom = 10,
                PaddingTop = 10,
                HorizontalAlignment = 1
            });

            cells.Add(new PdfPCell(new Phrase("Quantity", new Font(fontFamily, fontSize, Font.BOLD)))
            {
                BackgroundColor = new BaseColor(217, 217, 217),
                PaddingBottom = 10,
                PaddingTop = 10,
                HorizontalAlignment = 1
            });

            cells.Add(new PdfPCell(new Phrase("UnitPrice", new Font(fontFamily, fontSize, Font.BOLD)))
            {
                BackgroundColor = new BaseColor(217, 217, 217),
                PaddingBottom = 10,
                PaddingTop = 10,
                HorizontalAlignment = 1
            });

            cells.Add(new PdfPCell(new Phrase("Location", new Font(fontFamily, fontSize, Font.BOLD)))
            {
                BackgroundColor = new BaseColor(217, 217, 217),
                PaddingBottom = 10,
                PaddingTop = 10,
                HorizontalAlignment = 1
            });

            cells.Add(new PdfPCell(new Phrase("Sum", new Font(fontFamily, fontSize, Font.BOLD)))
            {
                BackgroundColor = new BaseColor(217, 217, 217),
                PaddingBottom = 10,
                PaddingTop = 10,
                HorizontalAlignment = 1
            });
        }

        public void CreatePdfAggregatedSalesReports(string destinationDirectoryPath)
        {
            float fontSize = 12f;
            Font.FontFamily fontFamily = new Font.FontFamily();
            fontFamily = Font.FontFamily.COURIER;

            using (var supermarketContext = new SupermarketContext())
            {
                var distinctDates = supermarketContext.Sales
                    .Select(s => s.Date).Distinct().ToList();
                foreach (var date in distinctDates)
                {
                    using (var currentAggregateSalesReport = new Document())
                    {
                        PdfWriter.GetInstance(currentAggregateSalesReport, new FileStream(
                            string.Format("{0}/Aggregated-Sales-Report-{1}.pdf",
                            destinationDirectoryPath, date.ToShortDateString()), FileMode.Create));
                        currentAggregateSalesReport.Open();
                        PdfPTable table = new PdfPTable(5);
                        IList<PdfPCell> cells = new List<PdfPCell>();

                        AddTitleRows(fontSize, fontFamily, date, cells);

                        var sales = supermarketContext.Sales.Include("Product")
                            .Include("Supermarket").Where(s => s.Date == date).ToList();
                        var measures = supermarketContext.Measures;
                        foreach (var sale in sales)
                        {
                            string productName = supermarketContext.Products
                                .Find(sale.ProductID).Name;
                            string location = supermarketContext.Supermarkets
                                .Find(sale.SupermarketID).Name;
                            string measure = measures.Find(sale.Product.MeasureID).MeasureName;

                            AddSaleReportRow(fontSize, fontFamily, cells, sale, measure, productName, location);
                        }

                        foreach (var cell in cells)
                        {
                            table.AddCell(cell);
                        }

                        currentAggregateSalesReport.Add(table);
                    }
                }
            }
        }
    }
}
