namespace _01.Choose_a_Drink
{
    using System;

    public class ChooseDrink
    {
        public static void Main()
        {
            string profession = Console.ReadLine();

            string perfektDring = string.Empty;

            switch (profession)
            {
                case "Athlete": perfektDring = "Water"; break;

                case "Businessman":

                case "Businesswoman": perfektDring = "Coffee"; break;

                case "SoftUni Student": perfektDring = "Beer"; break;

                default: perfektDring = "Tea"; break;

            }

            Console.WriteLine(perfektDring);
        }
    }
}
