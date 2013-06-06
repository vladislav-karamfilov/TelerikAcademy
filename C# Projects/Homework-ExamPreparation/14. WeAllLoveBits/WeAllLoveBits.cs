using System;

class WeAllLoveBits
{
    static uint ReverseBits(uint number)
    {
        char[] bits = Convert.ToString(number, 2).ToCharArray();
        char temp = new char();
        for (int i = 0; i < bits.Length / 2; i++)
        {
            temp = bits[i];
            bits[i] = bits[bits.Length - i - 1];
            bits[bits.Length - i - 1] = temp;
        }
        string temp1 = new string(bits);
        uint result = Convert.ToUInt32(temp1, 2); 
        return result;
    }

    static void Main()
    {
        ushort n = ushort.Parse(Console.ReadLine());
        uint[] pValues = new uint[n]; // The entered value of P
        uint[] pDots = new uint[n]; // The reversed value of P
        uint[] answers = new uint[n];
        for (ushort index = 0; index < n; index++)
        {
            pValues[index] = uint.Parse(Console.ReadLine());
            pDots[index] = ReverseBits(pValues[index]);
            answers[index] = (pValues[index] ^ (~pValues[index])) & pDots[index];
        }
        for (ushort index = 0; index < n; index++)
        {
            Console.WriteLine(answers[index]);
        }
    }
}
