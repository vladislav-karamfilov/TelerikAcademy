using System;

class ChristmasParty
{
    static void Main()
    {
        string[] input1 = Console.ReadLine().Split();
        byte hb = byte.Parse(input1[0]);
        byte mb = byte.Parse(input1[1]);
        string[] input2 = Console.ReadLine().Split();
        byte he = byte.Parse(input2[0]);
        byte me = byte.Parse(input2[1]);
        ushort partyTimeInMinutes = (ushort)((he * 60 + me) - (hb * 60 + mb));
        Console.WriteLine(partyTimeInMinutes / 5);
    }
}
