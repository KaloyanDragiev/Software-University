namespace _03._03.Water_Overflow
{
    using System;
   
    public class WaterOverflow
    {
        public static void Main()
        {
            byte timesToInput = byte.Parse(Console.ReadLine());

            byte result = 0;

            for (int time = 0; time < timesToInput; time++)
            {
                short commingLiters = short.Parse(Console.ReadLine());

                if (result + commingLiters > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    result += (byte)commingLiters;
                }
            }

            Console.WriteLine(result);
        }
    }
}
