using System;
using System.Collections.Generic;
using System.IO;

class OrderingCoursesAndStudents
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Reading from a file courses and students in them and printing");
        Console.WriteLine("the courses ordered by name and the students in them ordered by");
        Console.WriteLine("last name and then by first name***");
        Console.Write(decorationLine);

        SortedDictionary<string, SortedSet<Student>> coursesAndStudents =
            new SortedDictionary<string, SortedSet<Student>>();
        string filePath = "../../students.txt";
        char[] separators = new char[] { '|', ' ' };
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    string[] studentAndCourse =
                        currentLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    string course = studentAndCourse[2];
                    if (!coursesAndStudents.ContainsKey(course))
                    {
                        coursesAndStudents.Add(course, new SortedSet<Student>(new StudentsComparer()));
                    }

                    Student student = new Student(studentAndCourse[0], studentAndCourse[1]);
                    coursesAndStudents[course].Add(student);

                    currentLine = reader.ReadLine();
                }
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The entered file path is not correct!");
            return;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file '{0}' was not found!", filePath);
            return;
        }
        catch (IOException)
        {
            Console.WriteLine("Error while opening the file occured!");
            return;
        }

        PrintCoursesAndStudents(coursesAndStudents);
    }

    private static void PrintCoursesAndStudents(SortedDictionary<string, SortedSet<Student>> coursesAndStudents)
    {
        foreach (var courseAndStudents in coursesAndStudents)
        {
            Console.WriteLine("{0} -> {1}",
                courseAndStudents.Key, string.Join(", ", courseAndStudents.Value));
        }
    }
}
