using System;

class JoroTheRabbit
{
    static void Main()
    {
        string[] terrainNumbersStrings = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int terrainLength = terrainNumbersStrings.Length;
        int[] terrainNumbers = new int[terrainLength];
        for (int index = 0; index < terrainLength; index++)
        {
            terrainNumbers[index] = int.Parse(terrainNumbersStrings[index]);
        }

        int maxJumps = 0;
        int currentPosition = 0;
        int currentJumpsCount = 0;
        int nextPosition = 0;
        for (int startPosition = 0; startPosition < terrainLength; startPosition++)
        {
            for (int step = 1; step <= terrainLength; step++)
            {
                currentPosition = startPosition;
                currentJumpsCount = 1;
                nextPosition = (currentPosition + step) % terrainLength;
                while (nextPosition != startPosition && terrainNumbers[currentPosition] < terrainNumbers[nextPosition])
                {
                    currentJumpsCount++;
                    currentPosition = nextPosition;
                    nextPosition = (currentPosition + step) % terrainLength;
                }
                if (currentJumpsCount > maxJumps)
                {
                    maxJumps = currentJumpsCount;
                }
            }
        }

        Console.WriteLine(maxJumps);
    }
}
