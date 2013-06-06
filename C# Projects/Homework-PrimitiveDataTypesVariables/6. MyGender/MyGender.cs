using System;

class MyGender
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Declaring a boolean variable \"isFemale\" and assigning it\nwith the value corresponding to my gender***");
        Console.Write(decorationLine);
        bool isFemale = false;
        if (isFemale == true)
        {
            Console.WriteLine("I am a female.");
        }
        else
        {
            Console.WriteLine("I am a male.");
        }
    }
}
