namespace EmployeeTerritoryAccessing
{
    using System;
    using System.Data.Linq;
    using System.Linq;
    using Northwind.Data;

    class EmployeeTerritoryAccessingUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Accessing an employee's corresponding territories through");
            Console.WriteLine("a property of type EntitySet<T> in the Northwind database***");
            Console.Write(decorationLine);

            NorthwindEntities northwindEntities = new NorthwindEntities();
            int employeeID = 1;
            Employee employee = northwindEntities.Employees.Find(employeeID);
            // Property added at Northwind.Data ExtendedEmployee file
            EntitySet<Territory> territories = employee.EntityTerritories;
            Console.WriteLine("All territories for employee with ID {0} are:", employeeID);
            foreach (var territory in territories)
            {
                Console.WriteLine(territory.TerritoryDescription);
            }
        }
    }
}
