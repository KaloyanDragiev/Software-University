namespace _05.CharacterStats
{
    using System;

    public class CharacterStats
    {
        public static void Main()
        {
            string gamerName = Console.ReadLine();

            int currentHealt = int.Parse(Console.ReadLine());

            int maximumHealt = int.Parse(Console.ReadLine());

            int currentEnergy = int.Parse(Console.ReadLine());

            int maximumEnergy = int.Parse(Console.ReadLine());

            Console.WriteLine("Name: {0}\nHealth: |{1}{2}|\nEnergy: |{3}{4}|", gamerName,

                   new string('|', currentHealt),

                       new string('.', maximumHealt - currentHealt),

                           new string('|', currentEnergy),

                               new string('.', maximumEnergy - currentEnergy));
        }
    }
}


