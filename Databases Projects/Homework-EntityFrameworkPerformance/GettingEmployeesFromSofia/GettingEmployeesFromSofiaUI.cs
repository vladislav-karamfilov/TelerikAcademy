namespace GettingEmployeesFromSofia
{
    using System;
    using System.Linq;
    using EmployeesInformation;

    class GettingEmployeesFromSofiaUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Getting information about the employees from Sofia***");
            Console.Write(decorationLine);

            // With '.ToList()' many times -> ~1000 SQL statements executed
            Console.WriteLine("---Getting the information (slow version)---");
            using (TelerikAcademyEntities context = new TelerikAcademyEntities())
            {
                var employeesFromSofia = context.Employees.ToList()
                    .Select(e => e.Address).ToList()
                    .Select(a => a.Town).ToList()
                    .Where(t => t.Name == "Sofia");

                Console.WriteLine("The employees from 'Sofia' are: {0}", employeesFromSofia.Count());
            }

            Console.WriteLine();

            // Without '.ToList()' -> 1 SQL statement executed
            Console.WriteLine("---Getting the information (fast version)---");
            using (TelerikAcademyEntities context = new TelerikAcademyEntities())
            {
                var employeesFromSofia =
                    from employee in context.Employees
                    where employee.Address.Town.Name == "Sofia"
                    select employee;

                foreach (var employee in employeesFromSofia)
                {
                    Console.WriteLine("{0} {1}", 
                        employee.FirstName, employee.LastName);
                }
            }
        }
    }
}
