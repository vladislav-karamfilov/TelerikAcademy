namespace GetTotalIncomesBySupplierNameAndPeriod
{
    using System;
    using Northwind.Data;

    class GetTotalIncomesBySupplierNameAndPeriodUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Finding the total incomes from a specified supplier name and period***");
            Console.Write(decorationLine);

            string supplierName = "Exotic Liquids";
            DateTime startDate = new DateTime(1995, 1, 1);
            DateTime endDate = new DateTime(1997, 1, 1);

            decimal? totalIncomes =
                GetTotalIncomes(supplierName, startDate, endDate);
            if (totalIncomes != null)
            {
                Console.WriteLine("The total incomes of supplier {0} for perdiod from {1} to {2} is {3}",
                    supplierName, startDate.ToShortDateString(), endDate.ToShortDateString(), totalIncomes.Value);
            }
            else
            {
                Console.WriteLine("No result for provided supplier and provided");
            }
        }

        static decimal? GetTotalIncomes(string supplierName, DateTime? startDate, DateTime? endDate)
        {
            using (NorthwindEntities northwindEntites = new NorthwindEntities())
            {
                var totalIncomesSet = northwindEntites
                    .usp_GetTotalIncomesBySupplierNameAndPeriod(supplierName, startDate, endDate);

                foreach (var totalIncomes in totalIncomesSet)
                {
                    return totalIncomes;
                }
            }

            return null;
        }
    }
}
