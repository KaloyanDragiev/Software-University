namespace _16.Array_Symmetry
{
    using System;

    public class ArraySymmetry
    {
        public static void Main()
        {
            var sequence = Console.ReadLine().Split(' ');
            var interations = sequence.Length / 2;
            var index = 0;
            var position = sequence.Length - index - 1;
            for (index = 0; index < interations; index++)
            {
                if (sequence[index] != sequence[position])
                {
                    Console.WriteLine("No");
                    return;
                }
                position--;
            }
            Console.WriteLine("Yes");
        }
    }
}
