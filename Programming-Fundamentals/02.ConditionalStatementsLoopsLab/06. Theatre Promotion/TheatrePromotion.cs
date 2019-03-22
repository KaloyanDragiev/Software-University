namespace _06.Theatre_Promotion
{
    using System;
   
    public class TheatrePromotion
    {
        public static void Main()
        {
            string dayOfWeek = Console.ReadLine();

            int age = int.Parse(Console.ReadLine());

            string price = string.Empty;

            if (dayOfWeek == "Weekday")
            {
                if (age >= 0 && age <= 18) { price = "12$"; }

                else if (age >= 19 && age <= 64) { price = "18$"; }

                else if (age >= 65 && age <= 122) { price = "12$"; }

                else { price = "Error!"; }
            }
            else if (dayOfWeek == "Weekend")
            {
                if (age >= 0 && age <= 18) { price = "15$"; }

                else if (age >= 19 && age <= 64) { price = "20$"; }

                else if (age >= 65 && age <= 122) { price = "15$"; }

                else { price = "Error!"; }
            }
            else
            {
                if (age >= 0 && age <= 18) { price = "5$"; }

                else if (age >= 19 && age <= 64) { price = "12$"; }

                else if (age >= 65 && age <= 122) { price = "10$"; }

                else { price = "Error!"; }
            }

            Console.WriteLine(price);
        }
    }
}
