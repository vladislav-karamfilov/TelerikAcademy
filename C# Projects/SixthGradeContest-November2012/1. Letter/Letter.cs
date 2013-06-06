using System;

class Letter
{
    static void Main()
    {
        string word1 = Console.ReadLine();
        string word2 = Console.ReadLine();
        char[] word1Letters = word1.ToCharArray();
        char[] word2Letters = word2.ToCharArray();
        int answer = int.MinValue;
        char letter = (char)255;
        for (int i = 0; i < word1Letters.Length; i++)
        {
            byte count = 0;
            for (int j = 0; j < word2Letters.Length; j++)
            {
                if (word1Letters[i] == word2Letters[j])
                {
                    count++;
                    if (answer == count && letter > word1Letters[i])
                    {
                        letter = word1Letters[i];
                    }
                    if (answer < count)
                    {
                        answer = count;
                        letter = word1Letters[i];
                    }
                }
            }
        }
        if (letter != (char)255)
        {
            Console.WriteLine(letter);
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}
