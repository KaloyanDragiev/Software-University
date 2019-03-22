namespace _02.Choose_a_Drink_2._0
{
    using System;
  
    public class ChooseDrink2
    {
        public static void Main()
        {
            string profession = Console.ReadLine();

            double quantity = double.Parse(Console.ReadLine());

            string perfektDring = string.Empty;

            double hasToPay = 0;

            switch (profession)
            {
                case "Athlete":

                    perfektDring = "Water";

                    hasToPay = quantity * 0.7;

                    break;

                case "Businessman":

                case "Businesswoman":

                    perfektDring = "Coffee";

                    hasToPay = quantity;

                    break;

                case "SoftUni Student":

                    perfektDring = "Beer";

                    hasToPay = quantity * 1.7;

                    break;

                default:

                    perfektDring = "Tea";

                    hasToPay = quantity * 1.2;

                    break;

            }

            Console.WriteLine("The {0} has to pay {1:F2}.", profession, hasToPay);
        }
    }
}
