using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public string firstName;
    public string familyName;
    public int jobRating;

    public Employee(string firstName, string familyName, int jobRating)
    {
        this.firstName = firstName;
        this.familyName = familyName;
        this.jobRating = jobRating;
    }
}

class Job
{
    public string jobName;
    public int jobRating;
    public Job(string jobName, int jobRating)
    {
        this.jobName = jobName;
        this.jobRating = jobRating;
    }
}

class Employees
{
    static void Main()
    {
        char[] separator = new char[] { '-' };
        int jobsCount = int.Parse(Console.ReadLine());
        List<Job> jobsRatings = new List<Job>(jobsCount);
        for (int count = 0; count < jobsCount; count++)
        {
            string[] jobRating = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            jobsRatings.Add(new Job(jobRating[0].Trim(), int.Parse(jobRating[1])));
        }
        int employeesCount = int.Parse(Console.ReadLine());
        List<Employee> employeesPositions = new List<Employee>(employeesCount);
        for (int count = 0; count < employeesCount; count++)
        {
            string[] employeePosition = Console.ReadLine().Split(separator);
            string[] names = employeePosition[0].Split(' ');
            int jobRating = FindJobRating(jobsRatings, employeePosition[1].Trim());
            employeesPositions.Add(new Employee(names[0].Trim(), names[1].Trim(), jobRating));
        }
        employeesPositions = employeesPositions.OrderByDescending(employee => employee.jobRating).
            ThenBy(employee => employee.familyName).ThenBy(employee => employee.firstName).ToList();
        foreach (var employee in employeesPositions)
        {
            Console.WriteLine("{0} {1}", employee.firstName, employee.familyName);
        }
    }

    static int FindJobRating(List<Job> jobsRatings, string job)
    {
        int rating = 0;
        foreach (Job jobRating in jobsRatings)
        {
            if (jobRating.jobName == job)
            {
                rating = jobRating.jobRating;
                break;
            }
        }
        return rating;
    }
}
