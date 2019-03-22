namespace _04.Flip_List_Sides
{
    using System;

    public class FlipListSides
    {
        public static void Main(string[] args)
        {
            var currentSequens = Console.ReadLine().Split();
            var temporaryElement = string.Empty;
            var loopIterations = currentSequens.Length / 2;
            for (int index = 1; index < loopIterations; index++)
            {
                temporaryElement = currentSequens[index];
                currentSequens[index] = currentSequens[currentSequens.Length - index - 1];
                currentSequens[currentSequens.Length - index - 1] = temporaryElement;
            }
            Console.WriteLine(string.Join(" ", currentSequens));
        }
    }
}
