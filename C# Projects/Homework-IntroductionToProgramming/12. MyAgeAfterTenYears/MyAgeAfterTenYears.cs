using System;

class MyAgeAfterTenYears
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating your age after 10 years***");
        Console.Write(decorationLine);
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());
        int yearOfBirth = DateTime.Now.Year - age;
        DateTime yearAfterTenYears = DateTime.Now.AddYears(10);
        int ageAfterTenYears = yearAfterTenYears.Year - yearOfBirth;
        Console.WriteLine("After ten years you will be {0} years old.", ageAfterTenYears);
    }
}
