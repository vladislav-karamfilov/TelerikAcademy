namespace BiDictionary
{
    using System;
    using System.Collections.Generic;

    public class BiDictionaryDemo
    {
        private static readonly Person[] people = new Person[]
        {
            new Person("Ivan", "Ivanov", 22),
            new Person("Pesho", "Peshov", 20),
            new Person("Pesho", "Peshov", 22),
            new Person("Pesho", "Ivanov", 33),
            new Person("Lili", "Marinova", 19),
            new Person("Ana", "Georgieva", 21),
            new Person("Lili", "Petrova", 30),
            new Person("Gosho", "Goshov", 11),
            new Person("Gosho", "Goshov", 17),
            new Person("Pesho", "Goshov", 29),
            new Person("Gosho", "Ivanov", 25),
            new Person("Ivan", "Dimitrov", 22)
        };

        public static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Presenting the functionality of the data structure 'BiDictionary' - allows");
            Console.WriteLine("adding values by two keys, searching by a single key or by both keys and");
            Console.WriteLine("removing values by both keys***");
            Console.Write(decorationLine);

            BiDictionary<string, string, Person> peopleDictionary =
                new BiDictionary<string, string, Person>();

            Console.WriteLine("---Test add operation---");
            foreach (Person person in people)
            {
                peopleDictionary.Add(person.FirstName, person.LastName, person);
            }

            Console.WriteLine("Count after addition: {0}", peopleDictionary.Count);
            Console.WriteLine();

            Console.WriteLine("---Test get values by first key---");
            string firstName = "Gosho";
            Console.WriteLine("All people with first name '{0}' are:", firstName);
            PrintPeopleOnConsole(peopleDictionary.GetByFirstKey(firstName));
            Console.WriteLine();

            Console.WriteLine("---Test get values by second key---");
            string lastName = "Peshov";
            Console.WriteLine("All people with last name '{0}' are:", lastName);
            PrintPeopleOnConsole(peopleDictionary.GetBySecondKey(lastName));
            Console.WriteLine();

            Console.WriteLine("---Test get values by first key and second key---");
            string firstKey = "Gosho";
            string secondKey = "Goshov";
            Console.WriteLine("All people with first name '{0}' and last name '{1}' are:",
                firstKey,
                secondKey);
            PrintPeopleOnConsole(peopleDictionary.GetByBothKeys(firstKey, secondKey));
            Console.WriteLine();

            Console.WriteLine("---Test remove operation---");
            Console.WriteLine("Removing all people with first key '{0}' and second key '{1}'",
                firstKey,
                secondKey);
            peopleDictionary.Remove(firstKey, secondKey);
            Console.WriteLine("Count of people after removal: {0}", peopleDictionary.Count);
            Console.WriteLine("Count of people with first name '{0}' after removal: {1}",
                firstKey,
                peopleDictionary.GetByFirstKey(firstKey).Count);
            Console.WriteLine("Count of people with last name '{0}' after removal: {1}",
                secondKey,
                peopleDictionary.GetBySecondKey(secondKey).Count);
            Console.WriteLine();

            Console.WriteLine("---Test clear operation---");
            peopleDictionary.Clear();
            Console.WriteLine("Count of people after clearing the dictionary: {0}", peopleDictionary.Count);
        }

        private static void PrintPeopleOnConsole(IEnumerable<Person> people)
        {
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
