namespace _06.Winecraft
{
    using System;
    using System.Linq;

    public class Winecraft
    {
        public static void Main()
        {
            var grapes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => Convert.ToInt32(x)).ToArray();
            var rounds = Convert.ToInt32(Console.ReadLine());
            var grapesCounter = grapes.Length;
            var grapesKind = new Int32[grapesCounter];
            //---spin for each season until the grapes are less or equal than rounds---
            while (grapesCounter >= rounds)
            {
                //---count the rounds---
                for (int counter = 0; counter < rounds; counter++)
                {
                    //---calculate the grapes---
                    for (int index = 0; index < grapes.Length; index++)
                    {
                        // -1 => lesser, 0 => normal, 1 => greater 
                        for (int kindIndex = 1; kindIndex < grapes.Length - 1; kindIndex++)
                        {
                            if (grapes[kindIndex] > grapes[kindIndex - 1] && grapes[kindIndex] > grapes[kindIndex + 1])
                            {
                                grapesKind[kindIndex] = 1;
                                grapesKind[kindIndex - 1] = -1;
                                grapesKind[kindIndex + 1] = -1;
                            }
                        }
                        if (grapesKind[index] == 0 && grapes[index] > 0)
                        {
                            grapes[index]++;
                        }
                        else if (grapesKind[index] == 1)
                        {
                            grapes[index]++;
                            if (grapes[index - 1] > 0)
                            {
                                grapes[index - 1]--;
                                grapes[index]++;
                            }
                            if (grapes[index + 1] > 0)
                            {
                                grapes[index + 1]--;
                                grapes[index]++;
                            }
                            index++;
                        }
                    }
                }
                grapesCounter = grapes.Length;
                for (int index = 0; index < grapes.Length; index++)
                {
                    if (grapes[index] <= rounds)
                    {
                        grapes[index] = 0;
                        grapesCounter--;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", grapes.Where(x => x > 0)));
        }
    }
}