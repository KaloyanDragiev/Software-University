namespace _05.Array_Manipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArrayManipulator
    {
        public static void Main()
        {
            var currentSequence = Console.ReadLine().Split().Select(int.Parse).ToList();
            var currentAction = Console.ReadLine().Split();
            var firstAction = currentAction[0];
            for (int counter = 0; ; counter++)
            {
                if (firstAction == "add")//add <index> <element>
                {
                    var index = Convert.ToInt32(currentAction[1]);
                    var element = Convert.ToInt32(currentAction[2]);
                    currentSequence.Insert(index, element);
                }
                if (firstAction == "addMany")//addMany <index> <element 1> <element 2> … <element n>
                {
                    var index = Convert.ToInt32(currentAction[1]);
                    var elements = currentAction.Skip(2).Select(int.Parse).ToArray();
                    currentSequence.InsertRange(index, elements);
                }
                if (firstAction == "contains")//contains <element>
                {
                    var givenElement = Convert.ToInt32(currentAction[1]);
                    Console.WriteLine(currentSequence.IndexOf(givenElement));
                }
                if (firstAction == "remove")//remove <index>
                {
                    var givenIndex = Convert.ToInt16(currentSequence[1]);
                    currentSequence.RemoveAt(givenIndex);
                }
                if (firstAction == "shift")//shift <positions> – shifts every element
                {
                    var positions = Convert.ToInt16(currentAction[1]) % currentSequence.Count;
                    currentSequence = Shift(currentSequence, positions);
                }
                if (firstAction == "sumPairs")//sumPairs
                {
                    currentSequence = SumPairs(currentSequence);
                }
                if (firstAction == "print")//print the last state of the array and break;
                {
                    Console.WriteLine($"[{string.Join(", ", currentSequence)}]");
                }
                currentAction = Console.ReadLine().Split();
            }
        }

        //shift <positions> – shifts every element
        private static List<int> Shift(List<int> currentSequence, int positions)
        {
            for (int index = 0; index < positions; index++)
            {
                currentSequence.Add(currentSequence[0]);
                currentSequence.RemoveAt(0);
            }
            return currentSequence;
        }

        private static List<int> SumPairs(List<int> currentSequence)
        {
            var sumPairs = 0;
            var iterations = 0;
            var tempList = new List<int>();
            iterations -= currentSequence.Count % 2 == 1 ? 1 : 0;
            for (int index = 0; index < iterations / 2; index++)
            {
                sumPairs = currentSequence[index] + currentSequence[index + 1];
                tempList.Add(sumPairs);
            }

            if (currentSequence.Count % 2 == 1)
            {
                tempList.Add(currentSequence[currentSequence.Count - 1]);
            }
            return tempList;
        }
    }
}
