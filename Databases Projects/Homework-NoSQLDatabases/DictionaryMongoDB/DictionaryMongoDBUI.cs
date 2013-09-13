namespace DictionaryMongoDB
{
    using System;
    using System.Linq;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    
    class DictionaryMongoDBUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Dictionary application with options for adding a new entry,");
            Console.WriteLine("listing all entries from it and finding the translation of a given word***");
            Console.Write(decorationLine);

            // Start MongoDB server
            var mongoClient = new MongoClient(Settings.Default.MongoDBConnectionString);
            var mongoServer = mongoClient.GetServer();
            var dictionaryDB = mongoServer.GetDatabase("DictionaryDB");
            var dictionary = dictionaryDB.GetCollection<DictionaryEntry>("Dictionary");

            ConsoleKeyInfo command = new ConsoleKeyInfo();
            while (true)
            {
                DisplayMenu();

                command = Console.ReadKey();
                if (command.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    break;
                }

                ProccessCommand(dictionary, command);
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("---Dictionary Menu---");
            Console.WriteLine("1. Press 'A' to add a new entry to the dictionary");
            Console.WriteLine("2. Press 'L' to list all entries in the dictionary");
            Console.WriteLine("3. Press 'F' to find the translation of a word");
            Console.WriteLine("4. Press 'Esc' to exit the application");
            Console.Write("Enter command: ");
        }

        static void ProccessCommand(MongoCollection<DictionaryEntry> dictionary, ConsoleKeyInfo command)
        {
            switch (command.Key)
            {
                case ConsoleKey.A:
                    {
                        Console.Write("\nEnter a word: ");
                        string word = Console.ReadLine();
                        Console.Write("Enter translation: ");
                        string translation = Console.ReadLine();
                        AddNewEntry(dictionary, word, translation);
                        Console.WriteLine("Entry added!\n");
                        break;
                    }

                case ConsoleKey.L:
                    {
                        Console.WriteLine();
                        PrintAllEntries(dictionary);
                        Console.WriteLine();
                        break;
                    }

                case ConsoleKey.F:
                    {
                        Console.Write("\nEnter the word to find translation: ");
                        string word = Console.ReadLine();
                        var translation = GetTranslation(dictionary, word);
                        if (translation != null)
                        {
                            Console.WriteLine("The translation of the word '{0}' is: {1}", word, translation);
                        }
                        else
                        {
                            Console.WriteLine("There is no word '{0}' in the dictionary...", word);
                        }

                        Console.WriteLine();
                        break;
                    }

                default:
                    Console.WriteLine("\n\nInvalid command!");
                    break;
            }
        }

        static string GetTranslation(MongoCollection<DictionaryEntry> dictionary, string word)
        {
            var entry = dictionary.AsQueryable<DictionaryEntry>()
                .FirstOrDefault(e => e.Word == word);
            if (entry != null)
            {
                return entry.Translation;
            }

            return null;
        }

        static void AddNewEntry(MongoCollection<DictionaryEntry> dictionary, string word, string translation)
        {
            DictionaryEntry newEntry = new DictionaryEntry(word, translation);
            dictionary.Insert(newEntry);
        }

        static void PrintAllEntries(MongoCollection<DictionaryEntry> dictionary)
        {
            foreach (var entry in dictionary.FindAll())
            {
                Console.WriteLine(entry);
            }       
        }
    }
}
