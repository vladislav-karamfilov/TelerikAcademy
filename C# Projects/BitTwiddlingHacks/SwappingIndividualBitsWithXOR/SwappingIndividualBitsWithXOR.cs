using System;
// Just like "Flying bits" from a position to another
class SwappingIndividualBitsWithXOR
{
    static void Main()
    {
        int position1 = 2;
        int position2 = 22;
        int numberOfBitsToSwap = 7;
        uint number = 515701912;
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0') + "  " + number);
        uint temp = ((number >> position1) ^ (number >> position2)) & ((1U << numberOfBitsToSwap) - 1);
        uint result = number ^ ((temp << position1) | (temp << position2));
        Console.WriteLine(Convert.ToString(result, 2).PadLeft(32, '0') + "  " + result);
    }
}
