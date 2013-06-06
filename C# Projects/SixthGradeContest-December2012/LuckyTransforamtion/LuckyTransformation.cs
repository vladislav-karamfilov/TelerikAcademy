using System;
using System.Text;

class LuckyTransformation
{
    static void Main()
    {
        StringBuilder input1 = new StringBuilder(Console.ReadLine());
        string input2 = Console.ReadLine();
        int length = input2.Length;
        int transformations = 0;
        char temp = new char();
        for (int i = 0; i < length; i++)
        {
            if (input1[i] != input2[i])
            {
                bool flag = false;
                for (int j = i; j < length; j++)
                {
                    if (input2[i] == input1[j] && input1[j] != input2[j])  // Exchanging the digits
                    {
                        flag = true;
                        temp = input1[j];
                        input1[j] = input1[i];
                        input1[i] = temp;
                        transformations++;
                        break;
                    }
                }
                if (flag == false) // Changing the digit in input1
                {
                    input1[i] = input2[i];
                    transformations++;
                }
            }
        }
        Console.WriteLine(transformations);
    }
}
