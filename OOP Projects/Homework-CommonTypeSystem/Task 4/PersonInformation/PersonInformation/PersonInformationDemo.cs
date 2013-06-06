using System;

namespace PersonInformation
{
    class PersonInformationDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Printing information about people's names and ages***");
            Console.Write(decorationLine);

            // Creating two people with different constructors
            Person person1 = new Person("Ivan", "Ivanov", "Ivanov");
            Person person2 = new Person("Dimityr", "Georgiev", "Dimitrov", 22);

            // Printing the information about the people
            Console.WriteLine(person1);
            Console.WriteLine(person2);
        }
    }
}
