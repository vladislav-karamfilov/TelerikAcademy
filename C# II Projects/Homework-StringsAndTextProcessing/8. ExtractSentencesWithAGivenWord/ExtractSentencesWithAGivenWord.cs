using System;
using System.Text;

class ExtractSentencesWithAGivenWord
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Extracting from a text all sentences that contain a specific word***");
        Console.Write(decorationLine);
        Console.Write("Enter the text: ");
        string text = Console.ReadLine();
        Console.Write("Enter the specific word: ");
        string word = Console.ReadLine();
        StringBuilder outputSentences = new StringBuilder();
        string[] allSentences = text.Split('.');
        foreach (string sentence in allSentences)
        {
            StringBuilder currentWord = new StringBuilder();
            bool addedSentence = false;
            foreach (char symbol in sentence)
            {
                if (char.IsLetterOrDigit(symbol) || symbol == '_') // Using the definition that words contain digits, letters and "_"
                {
                    currentWord.Append(symbol);
                }
                else
                {
                    if (currentWord.ToString() == word)
                    {
                        outputSentences.Append(sentence.TrimStart(' ') + ".\n");
                        addedSentence = true;
                        break;
                    }
                    currentWord.Clear();
                }
            }
            // Checking the last word
            if (!addedSentence && currentWord.Length != 0 && currentWord.ToString() == word)
            {
                outputSentences.Append(sentence.TrimStart(' ') + ".\n");
            }
        }
        Console.WriteLine("All sentences that contain {0} are: ", word);
        Console.Write(outputSentences);
    }
}
