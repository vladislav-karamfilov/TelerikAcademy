using System;
using System.Collections.Generic;
using System.Text;
// TODO: Implement removing, not traversing the list!!!
class DecodedState
{
    public string decoded;
    public string leftToDecode;
    public DecodedState()
    {
        decoded = null;
        leftToDecode = null;
    }
    public DecodedState(string decoded, string leftToDecode)
    {
        this.decoded = decoded;
        this.leftToDecode = leftToDecode;
    }
}

class LetterCode
{
    public char letter;
    public string code;
    public LetterCode(char letter, string code)
    {
        this.letter = letter;
        this.code = code;
    }
}

class MessagesInABottle
{
    static void Main()
    {
        string secretMessage = Console.ReadLine();
        string cipher = Console.ReadLine();
        List<LetterCode> lettersCodes = GetLettersCodes(cipher);
        List<string> originalMessages = DecodeSecretMessage(secretMessage, lettersCodes);
        originalMessages.Sort();
        Console.WriteLine(originalMessages.Count);
        foreach (string originalMessage in originalMessages)
        {
            Console.WriteLine(originalMessage);
        }
    }

    static List<string> DecodeSecretMessage(string secretMessage, List<LetterCode> lettersCodes)
    {
        List<string> result = new List<string>();
        List<DecodedState> currentStates = new List<DecodedState>();
        currentStates.Add(new DecodedState("", secretMessage));
        int index = 0;
        while (index < currentStates.Count)
        {
            foreach (LetterCode letterCode in lettersCodes)
            {
                if (currentStates[index].leftToDecode.StartsWith(letterCode.code))
                {
                    DecodedState newState = new DecodedState();
                    newState.decoded = currentStates[index].decoded + letterCode.letter.ToString();
                    newState.leftToDecode = currentStates[index].leftToDecode.Remove(0, letterCode.code.Length);
                    if (newState.leftToDecode.Length == 0)
                    {
                        result.Add(newState.decoded);
                    }
                    else
                    {
                        currentStates.Add(newState);
                    }
                }
            }
            index++;
        }
        return result;
    }

    static List<LetterCode> GetLettersCodes(string cipher)
    {
        List<LetterCode> result = new List<LetterCode>();
        StringBuilder currentLetterCode = new StringBuilder();
        char currentLetter = cipher[0]; // The cipher always starts with letter
        foreach (char symbol in cipher)
        {
            if (char.IsDigit(symbol))
            {
                currentLetterCode.Append(symbol);
            }
            else // The symbol is the letter to be coded
            {
                if (currentLetterCode.Length != 0)
                {
                    result.Add(new LetterCode(currentLetter, currentLetterCode.ToString()));
                    currentLetterCode.Clear();
                    currentLetter = symbol;
                }
            }
        }
        result.Add(new LetterCode(currentLetter, currentLetterCode.ToString())); // Adding the last letter-code pair
        return result;
    }
}