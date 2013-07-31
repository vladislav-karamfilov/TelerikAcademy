namespace EmployeesInformation
{
    using System;
    using System.Linq;

    class EmployeesInformationUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Selecting all employees and printing their name, department and town***");
            Console.Write(decorationLine);

            // Without '.Include()' -> 340 SQL statements executed
            Console.WriteLine("---Getting the employees (slow version)---");
            using (TelerikAcademyEntities context = new TelerikAcademyEntities())
            {
                var employees = context.Employees;
                foreach (Employee employee in employees)
                {
                    Console.WriteLine("Name: {0} {1}; Department: {2}; Town: {3}",
                        employee.FirstName, employee.LastName, employee.Department.Name, employee.Address.Town.Name);
                }
            }

            Console.WriteLine();

            // With '.Include()' -> 1 SQL statement executed
            Console.WriteLine("---Getting the employees (fast version)---");
            using (TelerikAcademyEntities context = new TelerikAcademyEntities())
            {
                var employees = context.Employees.Include("Department").Include("Address.Town");
                foreach (var employee in employees)
                {
                    Console.WriteLine("Name: {0} {1}; Department: {2}; Town: {3}",
                        employee.FirstName, employee.LastName, employee.Department.Name, employee.Address.Town.Name);
                }
            }
        }
    }
}
