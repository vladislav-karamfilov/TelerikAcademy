using System;

class Card
{
    static void Main()
    {
        string[] numbers = Console.ReadLine().Split(' ');
        byte a = byte.Parse(numbers[0]);
        byte b = byte.Parse(numbers[1]);
        Console.WriteLine(
@"  #*#
  ***
  #*#
   {1}
{0}  {1}  {0}
 {0} {1} {0}
  {0}{1}{0}", a, b);
    }
}