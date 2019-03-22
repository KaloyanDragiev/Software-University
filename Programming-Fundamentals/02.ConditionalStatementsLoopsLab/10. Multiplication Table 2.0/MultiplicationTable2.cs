namespace _10.Multiplication_Table_2._0
{
    using System;
  
    public class MultiplicationTable2
    {
        public static void Main()
        {
            byte number = byte.Parse(Console.ReadLine());

            byte startMultiplayAt = byte.Parse(Console.ReadLine());

            for (byte i = startMultiplayAt; i <= 10; i++)
            {
                Console.WriteLine($"{number} X {i} = {number * i}");
            }

            if (startMultiplayAt > 10)
            {
                Console.WriteLine($"{number} X {startMultiplayAt} = {number * startMultiplayAt}");
            }
        }
    }
}
