using System;
using System.Collections.Generic;
using System.Text;

class MessagesInABottle
{
    static Dictionary<string, char> lettersCodes =
        new Dictionary<string, char>();
    static SortedSet<string> originalMessages = new SortedSet<string>();
    static string secretMessage = null;

    static void Main()
    {
        secretMessage = Console.ReadLine();
        GetLettersWithCodes(Console.ReadLine());

        GetOriginalMessages(0, new StringBuilder());
        
        Console.WriteLine(originalMessages.Count);
        foreach (var message in originalMessages)
        {
            Console.WriteLine(message);
        }
    }

    static void GetOriginalMessages(int indexInSecretMessage, StringBuilder decoded)
    {
        if (indexInSecretMessage == secretMessage.Length)
        {
            originalMessages.Add(decoded.ToString());
            return;
        }

        foreach (var letterCode in lettersCodes)
        {
            if (secretMessage.Substring(indexInSecretMessage).StartsWith(letterCode.Key))
            {
                decoded.Append(letterCode.Value);
                GetOriginalMessages(indexInSecretMessage + letterCode.Key.Length, decoded);
                decoded.Length--;
            }
        }
    }

    static void GetLettersWithCodes(string cipher)
    {
        StringBuilder currentCode = new StringBuilder();
        char currentLetter = cipher[0];
        for (int i = 1; i < cipher.Length; i++)
        {
            if (char.IsLetter(cipher[i]))
            {
                lettersCodes.Add(currentCode.ToString(), currentLetter);
                currentLetter = cipher[i];
                currentCode.Clear();
            }
            else
            {
                currentCode.Append(cipher[i]);
            }
        }

        lettersCodes.Add(currentCode.ToString(), currentLetter);
    }
}
