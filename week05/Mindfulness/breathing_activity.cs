using System;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    protected override string GetDescription()
    {
        return "This activity will help you relax by guiding you through slow breathing.";
    }

    protected override void DoActivity()
    {
        int cycleTime = 6;
        int cycles = Duration / cycleTime;

        for (int i = 0; i < cycles; i++)
        {
            Console.Write("Breathe in... ");
            Countdown(3);
            Console.Write("Breathe out... ");
            Countdown(3);
        }
    }
}
