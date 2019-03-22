namespace _19.DebuggingExerciseTrickyStrings
{
    using System;
    using System.Text;

    public class TrickyStrings
    {
        public static void Main()
        {
            var delimiter = Console.ReadLine();
            var rotations = Convert.ToInt16(Console.ReadLine()) - 1;
            var sb = new StringBuilder();
            var givenString = Console.ReadLine();
            var endString = sb.Append(givenString);
            for (int count = 0; count < rotations; count++)
            {
                givenString = Console.ReadLine();
                endString.Append(delimiter);
                endString.Append(givenString);
            }

            Console.WriteLine(endString);
        }
    }
}
