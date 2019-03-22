namespace _04.Ununion_Lists
{
    using System;
    using System.Linq;

    public class UnunionLists
    {
        public static void Main()
        {
            var workSequenceElements = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var commingSequences = Convert.ToInt16(Console.ReadLine());
            for (int count = 0; count < commingSequences; count++)
            {
                var nextSequence = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList();
                for (int index = 0; index < nextSequence.Count; index++)
                {
                    var currentElement = nextSequence[index];
                    if (workSequenceElements.Contains(currentElement))
                    {
                        nextSequence.RemoveAll(x => x == currentElement);
                        workSequenceElements.RemoveAll(x => x == currentElement);
                        index--;
                    }
                }
                workSequenceElements.AddRange(nextSequence);
            }
            workSequenceElements.Sort();
            Console.WriteLine(string.Join(" ", workSequenceElements));
        }
    }
}


//using System;
//using System.Linq;
//using System.Collections.Generic;
//namespace UnunionLists
//{
//    public class ununionLists
//    {
//        public static void Main()
//        {
//            List<int> first = Console.ReadLine().Split().Select(int.Parse).ToList();
//            int ctr = int.Parse(Console.ReadLine());
//            for (int i = 0; i < ctr; i++)
//            {
//                List<int> next = Console.ReadLine().Split().Select(int.Parse).ToList();
//                first = ChekingNumbers(first, next);
//            }
//            first.Sort();
//            Console.WriteLine(string.Join(" ", first));
//        }

//        private static List<int> ChekingNumbers(List<int> first, List<int> next)
//        {
//            for (int a = 0; a < next.Count; a++)
//            {
//                if (first.Contains(next[a]))
//                {
//                    RemoveAllEquals(first, next[a]);
//                }
//                else
//                {
//                    first.Add(next[a]);
//                }
//            }
//            return first;
//        }

//        private static List<int> RemoveAllEquals(List<int> list, int n)
//        {
//            for (int i = 0; i < list.Count; i++)
//            {
//                list.Remove(n);
//            }
//            return list;
//        }
//    }
//}
