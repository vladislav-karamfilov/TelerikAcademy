using System;

class TestingCSharp
{
    static void Main()
    {
        // VARIABLES AND DATA TYPES
        //ulong var = 0UL;
        //Console.WriteLine(var);
        //double big = double.Epsilon;
        //Console.WriteLine("{0}", big);
        //Console.WriteLine(0 < double.Epsilon);
        //byte var1 = 1;
        //Console.WriteLine(var1);
        //float a = 1f;
        //float b = 0.33f;
        //float c = 1.33f;
        //Console.WriteLine((a + b) == c);
        //char ch = (char)Console.Read();
        //object var2 = null;
        //ulong var3 = 12312312312312123123UL;
        //Console.WriteLine(var3);
        //Console.WriteLine(var2);
        //Console.WriteLine("{0:x}", var3);
        //float real1 = 1.37f;
        //float real2 = 0.137e+1f;
        //Nullable<int> nullVar = null;
        //Console.WriteLine(nullVar+4);
        //Console.WriteLine(real1 == real2);
        ////if (char.IsLetter(ch) && char.IsLower(ch))
        //{
        //    Console.WriteLine(ch);   
        //}

        //object obj = typeof(int);
        //Console.WriteLine(double.PositiveInfinity % 2);
        //Console.WriteLine(4 < 5 ^ 2 == 3);
        //float asd = 4f;
        //bool check = asd is float;
        //Console.WriteLine(check);
        //ulong? var = new ulong?();    
        ////Console.WriteLine(var.GetType());    Does not work!
        //bool check = var is ulong?;
        //Console.WriteLine(check);
        //string name = "Vladislav";
        //check = name is string;
        //object var1 = 23.132123123;
        //double tryingAs = asd as float;
        int d = 3;
        object obj = 4;
        //int resulttt = d + obj;
        //Console.WriteLine(int.Parse(null));
        Console.WriteLine(--d == d++);
        //Console.WriteLine(sizeof(bool));
        //Console.WriteLine(tryingAs); // Works only with reference data types
        //Console.WriteLine(0/0.0);
        //int a = 5;
        //int b = 3;
        //int c = ++b;
        //Console.WriteLine(c);
        //Console.WriteLine(a+++ ++c);
        //Console.WriteLine(c + " " + a);
        //Console.WriteLine(-25 >> 2);
        //bool trueA = true;
        //bool trueB = true;
        //bool falseA = false;
        //Console.WriteLine(trueA && falseA ^ trueA);
        //int var2 = 3;
        //var2 *= var2 += var2 = var2 += 1;
        //Console.WriteLine(var2);
        //Console.WriteLine("{0}", var2);
        //long longa = 1231231231231231231L;
        //int inta = (int)longa;
        //Console.WriteLine(inta);
        //double aDouble = 0.0f;
        //double bDouble = 0.0;
        //for (int i = 0; i < 12; i++)
        //{
        //    aDouble += 0.1;
        //}
        //for (int i = 0; i < 4; i++)
        //{
        //    bDouble += 0.3;
        //}
        //Console.WriteLine(aDouble == bDouble);
        //int s = 2, p = 3, f = 4, d = 2, e = 5;
        //int x = s | p & f << d ^ e;
        //Console.WriteLine(x);
        //double try1 = 5.7;
        //double try2 = 5.7f;
        //Console.WriteLine(try1 == try2);
        //double a = 0.0f;
        //double b = 0.0;
        //double sum1 = new double();
        //double sum2 = new double();
        //for (int i = 0; i < 4; i++)
        //{
        //    a += 0.3;
        //    Console.WriteLine("{0}", a);
        //}
        //for (int j = 0; j < 12; j++)
        //{
        //    b += 0.1;
        //    Console.WriteLine("{0}", b);
        //}
        //Console.WriteLine(a);
        //Console.WriteLine(b);
        //Console.WriteLine(a == b);
        //    a = 5.7f;
        //    b = 5.7;
        //    Console.WriteLine(a == b);
        //    string binary = "10110011001100110011010";
        //    //int num1 = Convert.ToInt32(binary, 2);
        //    //Console.WriteLine(num1);
        //    decimal num = 0m;
        //    for (int i = binary.Length - 1; i >= 0; i--)
        //    {
        //        num += 1 / (decimal)Math.Pow(2, i) * (binary[binary.Length - 1 - i] - '0');
        //    }
        //    Console.WriteLine(num);
        //    Console.WriteLine(Convert.ToSingle("11000000110110011001100110011010"));
        //    // For loops
        //    string[] days = { "Monday", "Tuesday", "Wednesday" };
        //    //foreach (var item in days)
        //    //{
        //    //    item = "new";
        //    //}
        double a = 0.3;
        double b = 0.33f;
        double sum = a + b;
        Console.WriteLine(sum == 1.33);
        Console.WriteLine(sum);
        char ch = 'a';
        Console.WriteLine(ch);
        int? obj1 = null;
        Console.WriteLine(obj1 + 11234);
        const string obj2 = "3";
        // bool res = obj1 == obj2;
        //obj2 = "123";
        //ch = Convert.ToChar("a123");
        Console.WriteLine(ch);
        sbyte x = -128;
        Console.WriteLine(Convert.ToString((sbyte)(x | (x - 1)), 2) + " " + (x | (x - 1)));
    }
}
