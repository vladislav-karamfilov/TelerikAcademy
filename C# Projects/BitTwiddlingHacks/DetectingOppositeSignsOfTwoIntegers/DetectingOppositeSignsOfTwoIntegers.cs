using System;

class DetectingOppositeSignsOfTwoIntegers
{
    static void Main()
    {
        int a = -123;
        int b = 3;
        bool check = (a ^ b) < 0; // True if the integers have opposite signs
        Console.WriteLine(check);
    }
}