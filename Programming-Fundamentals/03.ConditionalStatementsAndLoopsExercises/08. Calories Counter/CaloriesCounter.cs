namespace _08.Calories_Counter
{
    using System;

    public class CaloriesCounter
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double calories = 0;

            for (int i = 0; i < n; i++)
            {
                string ingredients = Console.ReadLine().ToLower();

                switch (ingredients)
                {
                    case "cheese": calories += 500; break;

                    case "tomato sauce": calories += 150; break;

                    case "salami": calories += 600; break;

                    case "pepper": calories += 50; break;
                }
            }

            Console.WriteLine($"Total calories: {calories}");
        }
    }
}
