namespace _03.Back_in_30_Minutes
{
    using System;
   
    public class Backin30Minutes
    {
        public static void Main()
        {
            byte hh = byte.Parse(Console.ReadLine());

            byte mm = byte.Parse(Console.ReadLine());

            byte hhPlus = (byte)((mm + 30) / 60);

            byte totalMinutes = (byte)((mm + 30) % 60);

            Console.WriteLine(hh + hhPlus > 23? $"{hh + hhPlus - 24:0}:{totalMinutes:00}" : 
                
                $"{hh + hhPlus:0}:{totalMinutes:00}");
        }
    }
}
