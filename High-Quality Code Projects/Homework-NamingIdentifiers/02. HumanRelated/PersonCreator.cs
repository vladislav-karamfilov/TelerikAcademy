using System;

public class PersonCreator
{
    public enum Gender
    {
        Male, Female
    }

    public class Person
    {
        public Gender Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }

    public void CreatePerson(int age)
    {
        Person newPerson = new Person();
        newPerson.Age = age;
        if (age % 2 == 0)
        {
            newPerson.Name = "Pesho Peshov";
            newPerson.Gender = Gender.Male;
        }
        else
        {
            newPerson.Name = "Ani Petrova";
            newPerson.Gender = Gender.Female;
        }
    }

    public static void Main()
    {
        // Used only for compiling purpose
    }
}
