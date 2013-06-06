using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3
{
    class Program
    {
        static void Main(string[] args)
        {
            //int a = 3;
            //Console.WriteLine(Convert.ToString(7, 2));
            //int b = a << 1;
            //Console.WriteLine(Convert.ToString(-7, 2));
            //float c = 12.5f;
            //float d = 1.25e+1f;
            //Console.WriteLine(c == d);
            //char ch = '\u0055';
            //Console.WriteLine(ch);
            //Console.WriteLine((true && false) == (true ^ true));
            //long f = 1;
            //for (int i = 1; i < 75; i++)
            //{
            //    f *= i;
            //}
            //Console.WriteLine(f);
            //Console.WriteLine(4 > 5 ^ a == b);
            //int? ab = null;
            //int? bc = 3;
            //Console.WriteLine(ab + bc);
            //float dd = 1.74f;
            //int asd = 213123;
            //Console.WriteLine("{0:#.####}", 00.1212424);
            //    char ch = Convert.ToChar('a' | 'b' | 'c');
            //    Console.WriteLine(ch);
            //    switch (ch)
            //    {
            //        case 'A':
            //        case 'a':
            //            Console.WriteLine("case A | case a");
            //            break;

            //        case 'B':
            //        case 'b':
            //            Console.WriteLine("case B | case b");
            //            break;

            //        case 'C':
            //        case 'c':
            //        case 'D':
            //        case 'd':
            //            Console.WriteLine("case D | case d");
            //            break;
            //    }
            //    int a = 3;
            //    String res;
            //    res = a % 2 == 0 ? "Even" : "Odd";
            //    Console.WriteLine(res);
            //    bool check = false;
            //    switch (check)
            //    {
            //        case true:
            //            Console.WriteLine("yes");
            //            break;
            //        default:
            //            Console.WriteLine("no");
            //            break;
            //    }
            //    Console.WriteLine(Convert.ToBoolean("123"));
            //}
            //int i;
            //for (i = 0; i <= 10; i++)
            //{
            //    if (i == 4)
            //    {
            //        Console.Write(i + " "); continue;
            //    }
            //    else if (i != 4)
            //        Console.Write(i + " ");
            //    else
            //        break;
            //}
            //Console.WriteLine(~1.2);
            //Console.Write("{0,10}{1,-10}{2,5}", 10, 12.33, "niki");
            //Console.WriteLine("hi");
            //int asd = 3;
            //Console.WriteLine(true ^ false && false);
            int mask = 15;
            int number = 1241251;
            if (false)
            {
                number |= mask;
            }
            else
            {
                number &= ~mask;
            }
            Console.WriteLine(number);
        }
    }
}
