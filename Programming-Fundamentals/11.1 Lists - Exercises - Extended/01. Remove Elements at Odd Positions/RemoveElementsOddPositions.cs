namespace _01.Remove_Elements_at_Odd_Positions
{
    using System;

    public class RemoveElementsOddPositions
    {
        public static void Main()
        {
            var currentList = Console.ReadLine().Split();
            //var newList = new List<string>();
            //var rotations = currentList.Count;
            var rotations = currentList.Length;

            for (int index = 1; index < rotations; index += 2)
            {
                //newList.Add(currentList[index]);
                Console.Write(currentList[index]);
            }
            //for (int index = 0; index < newList.Count; index++)
            //{
            //    Console.Write(newList[index]);
            //}
            //Console.WriteLine(string.Join("", newList));
        }
    }
}
