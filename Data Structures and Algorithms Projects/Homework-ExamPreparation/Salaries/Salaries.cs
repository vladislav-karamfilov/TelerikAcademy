using System;

class Salaries
{
    static bool[,] employeesMatrix;
    static int employeesCount;
    static long[] calculatedSalaries;

    static void Main()
    {
        employeesCount = int.Parse(Console.ReadLine());
        employeesMatrix = new bool[employeesCount, employeesCount];
        calculatedSalaries = new long[employeesCount];
        for (int i = 0; i < employeesCount; i++)
        {
            string inputLine = Console.ReadLine();
            for (int j = 0; j < employeesCount; j++)
            {
                if (inputLine[j] == 'Y')
                {
                    employeesMatrix[i, j] = true;
                }
            }
        }

        long totalSalary = 0;
        for (int i = 0; i < employeesCount; i++)
        {
            totalSalary += GetSalary(i);
        }

        Console.WriteLine(totalSalary);
    }

    static long GetSalary(int employee)
    {
        if (calculatedSalaries[employee] > 0)
        {
            return calculatedSalaries[employee];
        }

        long salary = 0;
        for (int i = 0; i < employeesCount; i++)
        {
            if (employeesMatrix[employee, i])
            {
                salary += GetSalary(i);
            }
        }

        salary = (salary != 0 ? salary : 1);
        calculatedSalaries[employee] = salary;
        return salary;
    }
}