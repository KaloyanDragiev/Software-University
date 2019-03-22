namespace _02.Integer_Insertion
{
    using System;
    using System.Linq;

    public class IntegerInsertion
    {
        public static void Main()
        {
            var currentNumbers = Console.ReadLine().Split().ToList();
            var nextNumber = Console.ReadLine();
            var place = 0;
            for (int index = 0; ; index++)
            {
                if (nextNumber == "end")
                {
                    Console.WriteLine(string.Join(" ", currentNumbers));
                    return;
                }
                place = Convert.ToInt16(nextNumber[0].ToString());
                currentNumbers.Insert(place, nextNumber);
                nextNumber = Console.ReadLine();
            }
        }
    }
}
