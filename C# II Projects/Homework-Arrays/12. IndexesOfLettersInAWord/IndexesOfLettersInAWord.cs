using System;

class IndexesOfLettersInAWord
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Creating an array of all letters from the alphabet, reading a word \nand printing the indexes of its letters in the array***");
        Console.WriteLine("---The lowercase letters are before the uppercase letters in the array---");
        Console.Write(decorationLine);
        char[] letters = new char[52];
        for (int index = 0; index < 52; index++)
        {
            if (index < 26)
            {
                letters[index] = (char)('a' + index);
            }
            else
            {
                letters[index] = (char)('A' + index - 26);
            }
        }
        Console.Write("Enter the word you want: ");
        string word = Console.ReadLine();
        foreach (char letter in word)
        {
            for (int index = 0; index < 52; index++)
            {
                if (letter == letters[index])
                {
                    Console.WriteLine("The letter {0} has index {1}.", letter, index + 1);
                    break;
                }
            }
        }
    }
}