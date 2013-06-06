using System;

class MissCat2011
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] votesForACat = new int[10];
        int maxVotes = int.MinValue;
        byte winnerCat = 0;
        byte vote;
        for (int i = 0; i < n; i++)
        {
            vote = byte.Parse(Console.ReadLine());
            votesForACat[vote - 1]++;
            if (maxVotes < votesForACat[vote - 1])
            {
                maxVotes = votesForACat[vote - 1];
                winnerCat = vote;
            }
        }
        Console.WriteLine(winnerCat);
    }
}
