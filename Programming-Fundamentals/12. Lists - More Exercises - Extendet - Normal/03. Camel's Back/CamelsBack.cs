/// <summary>
/// Recursive solution --- 100 / 100
/// </summary>
//namespace _03.Camel_s_Back
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    public class CamelsBack
//    {
//        public static void Main()
//        {
//            var currentSequence = Console.ReadLine().Split().ToList();
//            var neededElements = Convert.ToInt16(Console.ReadLine());
//            PrintRemainingSequense(currentSequence, neededElements);
//        }

//        static byte rundCounter;

//        private static void PrintRemainingSequense(List<string> currentSequence, short neededElements)
//        {
//            if (currentSequence.Count == neededElements && rundCounter == 0)
//            {
//                Console.WriteLine($"already stable: {string.Join(" ", currentSequence)}");
//                return;
//            }
//            else if (currentSequence.Count > neededElements)
//            {
//                rundCounter++;
//                currentSequence.RemoveAt(0);
//                currentSequence.RemoveAt(currentSequence.Count - 1);
//                PrintRemainingSequense(currentSequence, neededElements);
//            }
//            else
//            {
//                Console.WriteLine($"{rundCounter} rounds");
//                Console.WriteLine($"remaining: {string.Join(" ", currentSequence)}");
//                return;
//            }
//        }
//    }
//}

namespace _03.Camel_s_Back
{
    using System;
    using System.Linq;

    public class CamelsBack
    {
        public static void Main()
        {
            var currentSequence = Console.ReadLine().Split().ToList();
            var neededElements = Convert.ToInt16(Console.ReadLine());
            var rundCounter = 0;
            for (int indexer = 0; ; indexer++)
            {
                if (currentSequence.Count == neededElements && rundCounter == 0)
                {
                    Console.WriteLine($"already stable: {string.Join(" ", currentSequence)}");
                    return;
                }
                else if (currentSequence.Count == neededElements && rundCounter > 0)
                {
                    Console.WriteLine($"{rundCounter} rounds");
                    Console.WriteLine($"remaining: {string.Join(" ", currentSequence)}");
                    return;
                }
                rundCounter++;
                currentSequence.RemoveAt(0);
                currentSequence.RemoveAt(currentSequence.Count - 1);
            }
        }        
    }
}

