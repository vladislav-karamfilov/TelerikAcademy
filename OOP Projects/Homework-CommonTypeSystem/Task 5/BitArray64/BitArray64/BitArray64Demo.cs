using System;

namespace BitArray64
{
    class BitArray64Demo
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Testing BitArray64 functionality***");
            Console.Write(decorationLine);

            // Creating some bit arrays
            BitArray64 bitArray1 = new BitArray64(9152658268616102156UL);
            BitArray64 bitArray2 = new BitArray64(51251861512UL);

            Console.WriteLine("---Printing the bits from two bit arrays---");
            Console.WriteLine("The representation of {0} as bit array is:", 9152658268616102156UL);
            Console.WriteLine(bitArray1);
            Console.WriteLine("The representation of {0} as bit array is:", 51251861512UL);
            Console.WriteLine(bitArray2);

            Console.WriteLine("---Testing the implementation of IEnumerable<int> interface methods---");
            int onesCount = 0;
            foreach (int bit in bitArray1)
            {
                if (bit == 1)
                {
                    onesCount++;
                }
            }
            Console.WriteLine("The bits 1 in the first bit array are: " + onesCount);
            int zeroesCount = 0;
            foreach (int bit in bitArray2)
            {
                if (bit == 0)
                {
                    zeroesCount++;
                }
            }
            Console.WriteLine("The bits 0 in the second bit array are: " + zeroesCount);
            Console.WriteLine();

            Console.WriteLine("---Testing the methods Equals() and GetHashCode()---");
            Console.WriteLine("First bit array equals second one: " + bitArray1.Equals(bitArray2));
            Console.WriteLine("Hash code of second bit array: " + bitArray2.GetHashCode());
            Console.WriteLine();

            Console.WriteLine("---Testing the indexer over the second bit array---");
            Console.WriteLine("bit at index 11 -> " + bitArray2[11]);
            Console.WriteLine("bit at index 38 -> " + bitArray2[38]);
            Console.WriteLine("bit at index 63 -> " + bitArray2[63]);
            Console.WriteLine();

            Console.WriteLine("---Testing equality and inequality operators---");
            Console.WriteLine("The first bit array is equal to the second one -> " + (bitArray1 == bitArray2));
            Console.WriteLine("The first bit array is different from the second one -> " + (bitArray1 != bitArray2));
        }
    }
}
