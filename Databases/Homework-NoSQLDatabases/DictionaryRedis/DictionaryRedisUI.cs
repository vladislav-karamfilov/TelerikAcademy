namespace DictionaryRedis
{
    using System;
    using ServiceStack.Redis;
    using ServiceStack.Redis.Generic;

    class DictionaryRedisUI
    {
        const string DictionaryStructure = "Dictionary";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Dictionary application with options for adding a new entry,");
            Console.WriteLine("listing all entries from it and finding the translation of a given word***");
            Console.Write(decorationLine);

            // Start Redis server
            using (var redisClient = new RedisClient("127.0.0.1:6379"))
            {
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

                    ProccessCommand(redisClient, command);
                }
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

        static void ProccessCommand(RedisClient redisClient, ConsoleKeyInfo command)
        {
            switch (command.Key)
            {
                case ConsoleKey.A:
                    {
                        Console.Write("\nEnter a word: ");
                        string word = Console.ReadLine();
                        Console.Write("Enter translation: ");
                        string translation = Console.ReadLine();
                        AddNewEntry(redisClient, word, translation);
                        Console.WriteLine("Entry added!\n");
                        break;
                    }

                case ConsoleKey.L:
                    {
                        Console.WriteLine();
                        PrintAllEntries(redisClient);
                        Console.WriteLine();
                        break;
                    }

                case ConsoleKey.F:
                    {
                        Console.Write("\nEnter the word to find translation: ");
                        string word = Console.ReadLine();
                        var translation = GetTranslation(redisClient, word);
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

        static string GetTranslation(RedisClient redisClient, string word)
        {
            if (redisClient.HExists(DictionaryStructure, Extensions.ToAsciiCharArray(word)) != 0)
            {
                return Extensions.StringFromByteArray(
                    redisClient.HGet(DictionaryStructure, Extensions.ToAsciiCharArray(word)));
            }

            return null;
        }

        static void AddNewEntry(RedisClient redisClient, string word, string translation)
        {
            redisClient.HSet(
                DictionaryStructure,
                Extensions.ToAsciiCharArray(word),
                Extensions.ToAsciiCharArray(translation));
        }

        static void PrintAllEntries(RedisClient redisClient)
        {
            var entries = redisClient.HGetAll(DictionaryStructure);
            for (int i = 0; i < entries.Length; i += 2)
            {
                Console.WriteLine(
                    "{0} -> {1}",
                    Extensions.StringFromByteArray(entries[i]),
                    Extensions.StringFromByteArray(entries[i + 1]));
            }
        }
    }
}
