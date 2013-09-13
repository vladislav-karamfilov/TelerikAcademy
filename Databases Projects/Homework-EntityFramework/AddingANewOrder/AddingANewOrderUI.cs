namespace AddingANewOrder
{
    using System;
    using System.Transactions;
    using Northwind.Data;
    using System.Collections.Generic;

    class AddingANewOrderUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Adding a new order in the 'Northwind' database***");
            Console.Write(decorationLine);

            int orderInfosCount = 5;
            IEnumerable<object[]> orderInfos = GetOrderInfos(orderInfosCount);

            try
            {
                AddNewOrders(orderInfos);
                Console.WriteLine("Successfully added!");
            }
            catch (TransactionAbortedException)
            {
                Console.WriteLine("Adding orders failed. All changes are reversed!");
            }
        }

        static void AddNewOrders(IEnumerable<object[]> orderInfos)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (object[] orderInfo in orderInfos)
                    {
                        Order order = new Order()
                        {
                            CustomerID = (orderInfo[0] as string),
                            EmployeeID = (orderInfo[1] as int?),
                            OrderDate = (orderInfo[2] as DateTime?),
                            RequiredDate = (orderInfo[3] as DateTime?),
                            ShippedDate = (orderInfo[4] as DateTime?),
                            ShipVia = (orderInfo[5] as int?),
                            Freight = (orderInfo[6] as decimal?),
                            ShipName = (orderInfo[7] as string),
                            ShipAddress = (orderInfo[8] as string),
                            ShipCity = (orderInfo[9] as string),
                            ShipRegion = (orderInfo[10] as string),
                            ShipPostalCode = (orderInfo[11] as string),
                            ShipCountry = (orderInfo[12] as string),
                        };

                        northwindEntities.Orders.Add(order);
                    }

                    northwindEntities.SaveChanges();
                    scope.Complete();
                }
            }
        }

        static IEnumerable<object[]> GetOrderInfos(int orderInfosCount)
        {
            IList<object[]> orderInfos = new List<object[]>();
            for (int i = 0; i < orderInfosCount; i++)
            {
                object[] orderInfo = new object[13];
                orderInfo[0] = null;
                orderInfo[1] = i + 1;
                orderInfo[2] = DateTime.Now.Subtract(new TimeSpan(i + 1, 0, 0));
                orderInfo[3] = DateTime.Now.Subtract(new TimeSpan(i + 3, 0, 0));
                orderInfo[4] = null;
                orderInfo[5] = null;
                orderInfo[6] = (decimal)(12.2 + i);
                orderInfo[7] = null;
                orderInfo[8] = null;
                orderInfo[9] = null;
                orderInfo[10] = null;
                orderInfo[11] = null;
                orderInfo[12] = null;

                orderInfos.Add(orderInfo);
            }

            return orderInfos;
        }
    }
}
