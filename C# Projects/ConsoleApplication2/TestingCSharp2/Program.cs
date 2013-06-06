using System;
using System.Globalization;
using System.Threading;

class TestingCSharp2
{
    static void Main()
    {
        //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        //double pi = 3.14159123123123157578;
        //Console.WriteLine("{0,25:0.00000000000000000}", pi);
        //Console.WriteLine("{0,12:N15}", 1123);
        //int ch = Console.Read();
        //char ch1 = (char)ch;
        //Console.WriteLine(ch1 + " " + ch);
        //ConsoleKeyInfo key = Console.ReadKey();
        //Console.WriteLine();
        //Console.WriteLine("{0}\n{1}", key.KeyChar, key.Modifiers);
        //Console.WriteLine("{0}", key.Key);
        //char zero = '0';
        //char one = '1';
        //char two = '2';
        //char three = '3';
        //char four = '4';
        //char five = '5';
        //char six = '6';
        //char seven = '7';
        //char eight = '8';
        //char nine = '9';
        //string stringNumber = (nine + two + five).ToString();
        //double a = 123.3;
        //int b = (nine - '0') * 100 + 10 * (two - '0') + five - '0';
        //Console.WriteLine(b);
        //Console.WriteLine(stringNumber);
        //byte number = 145;
        ////for (int i = 0; i <= 32; i++)
        ////{
        ////    number >>= i;
        ////    for (int j = 0; j >= -32; j--)
        ////    {
        ////        number <<= Math.Abs(j);
        ////    }
        ////}
        //Console.WriteLine(number);
        //uint trying1 = 3;
        //Console.WriteLine(number << trying1);
        double first = 0.0f;
        double second = 0.0;
        for (int i = 0; i < 3; i++)
        {
            first += 0.4;
        }
        for (int i = 0; i < 1; i++)
        {
            second += 1.2;
        }
        Console.WriteLine(first == second);
        Console.WriteLine(3 % -2);
        Console.WriteLine(Environment.);
    }
}
