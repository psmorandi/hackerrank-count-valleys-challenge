using System;

internal class Result
{
    /*
     * Complete the 'countingValleys' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER steps
     *  2. STRING path
     */

    private static readonly int SEA_LEVEL = 0;
    private static readonly int CLIMBING = 1;
    private static readonly int DOWN = -1;

    public static int CountingValleys(int steps, string path)
    {
        var theJourney = SEA_LEVEL;
        var numberOfValleys = 0;
        var isBellowSeaLevel = false;
        for (var step = 0; step < steps; step++)
        {
            theJourney += IsClimbing(path[step]) ? CLIMBING : DOWN;
            if (JourneyHitTheSeaLevel(theJourney) && isBellowSeaLevel) numberOfValleys++;
            isBellowSeaLevel = theJourney < 0;
        }

        return numberOfValleys;
    }

    private static bool IsClimbing(char step) => step == 'U';

    private static bool JourneyHitTheSeaLevel(int theJourney) => theJourney == SEA_LEVEL;
}

internal class Solution
{
    public static void Main(string[] args)
    {
        var steps = 20;
        var path = "DDUUUDDDUUUDDDUUUDDU";
        var result = Result.CountingValleys(steps, path);
        Console.WriteLine(result);
        Console.ReadKey();
    }
}