namespace _01.Distinct_List
{
    using System;
    using System.Linq;

    public class DistinctList
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList().Distinct();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

////---This solution give 100 / 100 too---
//namespace _01.Distinct_List
//{
//    using System;
//    using System.Linq;

//    public class DistinctList
//    {
//        public static void Main()
//        {
//            var numbers = Console.ReadLine()
//                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
//            for (int a = 0; a < numbers.Count; a++)
//            {
//                var currentNumber = numbers[a];
//                for (int i = a + 1; i < numbers.Count; i++)
//                {
//                    var nextNumber = numbers[i];
//                    if (currentNumber == nextNumber)
//                    {
//                        numbers.RemoveAt(i);
//                        i--;
//                    }
//                }
//            }
//            Console.WriteLine(string.Join(" ", numbers));
//        }
//    }
//}
