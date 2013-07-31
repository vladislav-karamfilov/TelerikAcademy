namespace HashTable.UI
{
    using System;
    using HashTable.Common;

    public class HashTableDemo
    {
        internal static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Presenting the functionality of the data structure 'Hash table'***");
            Console.Write(decorationLine);

            HashTable<string, int> clubsPoints = new HashTable<string, int>();

            Console.WriteLine("---Add operation---");
            clubsPoints.Add("Rabbits-O!", 15);
            clubsPoints.Add("Frogssy", 19);
            clubsPoints.Add("Puma Runners", 17);
            clubsPoints.Add("Lion Kings", 33);
            Console.WriteLine("Count = " + clubsPoints.Count);
            Console.WriteLine();

            Console.WriteLine("---Iterator functionality---");
            PrintClubsPoints(clubsPoints);
            Console.WriteLine();

            Console.WriteLine("---Remove operation---");
            bool isRemoved = clubsPoints.Remove("Frogssy");
            Console.WriteLine("Are 'Frogssy' removed: " + isRemoved);
            Console.WriteLine("Count = " + clubsPoints.Count);
            Console.WriteLine("Hash table after removal:");
            PrintClubsPoints(clubsPoints);
            Console.WriteLine();

            Console.WriteLine("---Indexer---");
            Console.WriteLine("'Lion Kings' points so far: " + clubsPoints["Lion Kings"]);
            clubsPoints["Rabbits-O!"] += 3;
            Console.WriteLine("'Rabbits-O!' points after a win: " + clubsPoints["Rabbits-O!"]);
            Console.WriteLine();

            Console.WriteLine("---Find operation---");
            Console.WriteLine("Info about 'Puma Runners'" + clubsPoints.Find("Puma Runners"));
            Console.WriteLine();

            Console.WriteLine("---ContainsKey operation---");
            Console.WriteLine("Is there a club 'Birdy'? - " + clubsPoints.ContainsKey("Birdy"));
            Console.WriteLine("Is there a club 'Rabbits-O!'? - " + clubsPoints.ContainsKey("Rabbits-O!"));
            Console.WriteLine();

            Console.WriteLine("---Keys property---");
            Console.Write("All clubs names are: ");
            Console.WriteLine(string.Join(", ", clubsPoints.Keys));
            Console.WriteLine();

            Console.WriteLine("---Values property---");
            Console.Write("All club's points are: ");
            Console.WriteLine(string.Join(", ", clubsPoints.Values));
            Console.WriteLine();

            Console.WriteLine("---Clear operation---");
            clubsPoints.Clear();
            Console.WriteLine("Elements count after clearing: " + clubsPoints.Count);
        }

        private static void PrintClubsPoints(HashTable<string, int> clubsPoints)
        {
            foreach (KeyValuePair<string, int> clubPoints in clubsPoints)
            {
                Console.WriteLine(clubPoints);
            }
        }
    }
}
 