using System;

class LargestPalindromeProduct
{
    static void Main()
    {
        string temp;
        int answer = 0;
        for (int i = 999; i >= 100; i--)
        {
            for (int j = 999; j >= i; j--)
            {
                temp = (i * j).ToString();
                if (temp[0] == temp[temp.Length - 1] && temp[1] == temp[temp.Length - 2] && temp[2] == temp[temp.Length - 3])
                {
                    if (i * j > answer)
                    {
                        answer = i * j;
                    }
                }
            }
        }
        Console.WriteLine(answer);
    }
}

// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 * 99.

// Find the largest palindrome made from the product of two 3-digit numbers.
