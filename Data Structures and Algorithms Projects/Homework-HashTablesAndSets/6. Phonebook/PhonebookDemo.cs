namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class PhonebookDemo
    {
        private static readonly Phonebook phonebook = new Phonebook();

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Constructing a phonebook from a file and finding entries by name only");
            Console.WriteLine("and by name and town together***");
            Console.Write(decorationLine);

            string entriesFilePath = @"../../phones.txt";
            GetPhonebookEntries(entriesFilePath);

            Console.WriteLine("Entries with name: 'Pesho'");
            IEnumerable<PhonebookEntry> byPeshoName = phonebook.Find("Pesho");
            PrintEntries(byPeshoName);
            Console.WriteLine();

            Console.WriteLine("Entries with name: 'Kiril'");
            IEnumerable<PhonebookEntry> byKirilName = phonebook.Find("Kiril");
            PrintEntries(byKirilName);
            Console.WriteLine();

            Console.WriteLine("Entries with name: 'Goshov'");
            IEnumerable<PhonebookEntry> byGoshovName = phonebook.Find("Goshov");
            PrintEntries(byGoshovName);
            Console.WriteLine();

            Console.WriteLine("Entries with nickname: 'Bliznaka'");
            IEnumerable<PhonebookEntry> byBliznakaNickname = phonebook.Find("Bliznaka");
            PrintEntries(byBliznakaNickname);
            Console.WriteLine();

            Console.WriteLine("Entries with name: 'Pesho' and town: 'Asenovgrad'");
            IEnumerable<PhonebookEntry> byPeshoNameAndAsenovgradTown = phonebook.Find("Pesho", "Asenovgrad");
            PrintEntries(byPeshoNameAndAsenovgradTown);
            Console.WriteLine();

            Console.WriteLine("Entries with name: 'Dimitrov' and town: 'Ruse'");
            IEnumerable<PhonebookEntry> byDimitrovNameAndRuseTown = phonebook.Find("Dimitrov", "Ruse");
            PrintEntries(byDimitrovNameAndRuseTown);
        }

        private static void GetPhonebookEntries(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    PhonebookEntry newEntry = PhonebookEntry.Parse(currentLine);
                    phonebook.Add(newEntry);

                    currentLine = reader.ReadLine();
                }
            }
        }

        private static void PrintEntries(IEnumerable<PhonebookEntry> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
