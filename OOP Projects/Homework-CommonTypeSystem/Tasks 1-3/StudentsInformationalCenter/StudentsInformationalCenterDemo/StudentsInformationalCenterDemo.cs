using System;

namespace StudentsInformationalCenterDemo
{
    class StudentsInformationalCenterDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Creating some student objects and performing some operations over them***");
            Console.Write(decorationLine);

            // Creating the students
            Student student1 = new Student("Ivan", "Ivanov", "Ivanov", "1234567890", "Sofia, street: \"Street name\" #15", "0888888888",
                "i.ivanov@email.com", 2, University.SofiaUniversity, Faculty.FacultyOfLaw, Specialty.Law);
            Student student2 = new Student("Petar", "Petrov", "Petrov", "0987654321", "Plovdiv, street: \"Unknown street\" #9", "0899999999",
                "p.petrov@email.com", 4, University.PlovdivUniversity, Faculty.FacultyOfMathematicsAndInformatics, Specialty.Mathematics);

            Console.WriteLine("***Printing the information about two students***");
            // The ToString() method demonstration
            Console.WriteLine(student1);
            Console.WriteLine(student2);

            Console.WriteLine("***Comparing the students with Equals()***");
            Console.WriteLine("Result of comparison: " + student1.Equals(student2));
            Console.WriteLine();

            Console.WriteLine("***Testing the GetHashCode() method***");
            Console.WriteLine("First student's hash code: " + student1.GetHashCode());
            Console.WriteLine("Second student's has code: " + student2.GetHashCode());
            Console.WriteLine();

            Console.WriteLine("***Testing the operators '==' and '!='***");
            Console.WriteLine("first student == second student -> " + (student1 == student2));
            Console.WriteLine("first student != second student -> " + (student1 != student2));
            Console.WriteLine();

            Console.WriteLine("***Cloning the first student and printing the clone***");
            Student cloneStudent = student1.Clone();
            Console.WriteLine(cloneStudent);
            Console.WriteLine("***Changing original's address and clone's mobile phone and priniting both***");
            student1.Address = "Sofia, street \"New street\" #34";
            cloneStudent.MobilePhone = "0877777777";
            Console.WriteLine(student1);
            Console.WriteLine(cloneStudent);

            Console.WriteLine("***Comparing first student with second student by CompareTo() method***");
            if (student1.CompareTo(student2) == 0)
            {
                Console.WriteLine("Both students are equal!");
            }
            else if (student1.CompareTo(student2) < 0)
            {
                Console.WriteLine("The first student is before the second one!");
            }
            else
            {
                Console.WriteLine("The first student is after the second one!");
            }
        }
    }
}
