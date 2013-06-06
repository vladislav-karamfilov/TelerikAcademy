using System;

class Anacci
{
    static void Main()
    {
        char first = char.Parse(Console.ReadLine());
        char second = char.Parse(Console.ReadLine());
        byte lines = byte.Parse(Console.ReadLine());
        if (lines == 1)
        {
            Console.WriteLine(first);
            return;
        }
        else
        {
            char temp = new char();
            Console.WriteLine(first);
            Console.WriteLine(second + "" + next(first, second));
            temp = next(first, second);
            first = second;
            second = temp;
            for (int i = 1; i < lines - 1; i++)
            {
                Console.Write(next(first, second));
                Console.Write(new string(' ', i));
                temp = next(first, second);
                first = second;
                second = temp;
                Console.WriteLine(next(first, second));
                temp = next(first, second);
                first = second;
                second = temp;
            }
        }    
    }
    static char next(char first, char second)
    {
        char result = (char)(first + second - 'A' + 1);
        if (result > 'Z')
        {
            int result1 = result - 'A';
            result1 %= 26;
            result = (char)(result1 + 'A');
        }
        return result;
    }
}
