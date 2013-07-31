namespace PerformingConcurrentChanges
{
    using System;
    using Northwind.Data;

    class PerformingConcurrentChangesUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Performing concurrent changes over the same records");
            Console.WriteLine("using two data contexts***");
            Console.Write(decorationLine);

            using (NorthwindEntities northwindEntities1 = new NorthwindEntities())
            {
                using (NorthwindEntities northwindEntities2 = new NorthwindEntities())
                {
                    Customer customerByFirstDataContext = northwindEntities1.Customers.Find("CHOPS");
                    customerByFirstDataContext.Region = "SW";

                    Customer customerBySecondDataContext = northwindEntities2.Customers.Find("CHOPS");
                    customerBySecondDataContext.Region = "SSWW";

                    northwindEntities1.SaveChanges();
                    northwindEntities2.SaveChanges();
                }
            }

            Console.WriteLine("Changes successfully made!");
        }
    }
}
