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
        var previouslyBellowSeaLevel = false;
        for (var step = 0; step < steps; step++)
        {
            theJourney += IsClimbing(path[step]) ? CLIMBING : DOWN;
            if (previouslyBellowSeaLevel && JourneyHitTheSeaLevel(theJourney)) numberOfValleys++;
            previouslyBellowSeaLevel = IsJourneyBellowSeaLevel(theJourney);
        }

        return numberOfValleys;
    }

    private static bool IsClimbing(char step) => step == 'U';

    private static bool JourneyHitTheSeaLevel(int journey) => journey == SEA_LEVEL;

    private static bool IsJourneyBellowSeaLevel(int journey) => journey < 0;
}

internal class Solution
{
    public static void Main()
    {
        var steps = 20;
        var path = "DDUUUDDDUUUDDDUUUDDU";
        var result = Result.CountingValleys(steps, path);
        Console.WriteLine(result);
        Console.ReadKey();
    }
}