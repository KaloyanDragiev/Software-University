namespace _08._08.House_Builder
{
    using System;
  
    public class HouseBuilder
    {
        public static void Main()
        {
            string firstNumberAsString = Console.ReadLine();

            string lastNumberAsString = Console.ReadLine();

            sbyte someSbyte = 0;

            if (sbyte.TryParse(firstNumberAsString, out someSbyte))
            {
                Console.WriteLine(someSbyte * 4 + long.Parse(lastNumberAsString) * 10);
            }
            else
            {
                Console.WriteLine(long.Parse(lastNumberAsString) * 4 + long.Parse(firstNumberAsString) * 10);
            }

        }
    }
}
