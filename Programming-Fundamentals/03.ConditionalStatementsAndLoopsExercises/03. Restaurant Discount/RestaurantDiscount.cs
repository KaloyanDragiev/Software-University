namespace _03.Restaurant_Discount
{
    using System;

    public class RestaurantDiscount
    {
        public static void Main()
        {
            int groupOfPeople = int.Parse(Console.ReadLine());

            string package = Console.ReadLine();

            string offer = string.Empty;

            double pricePerPerson = 0;

            if (groupOfPeople > 120)
            {
                offer = "We do not have an appropriate hall.";
            }
            else if (groupOfPeople < 121 && groupOfPeople > 100)
            {
                switch (package)
                {
                    case "Normal": pricePerPerson = (7500 + 500) * 0.95 / groupOfPeople; break;

                    case "Gold": pricePerPerson = (7500 + 750) * 0.9 / groupOfPeople; break;

                    case "Platinum": pricePerPerson = (7500 + 1000) * 0.85 / groupOfPeople; break;
                }

                offer = $"We can offer you the Great Hall\nThe price per person is {pricePerPerson:F2}$";

            }
            else if (groupOfPeople < 101 && groupOfPeople > 50)
            {
                switch (package)
                {
                    case "Normal": pricePerPerson = (5000 + 500) * 0.95 / groupOfPeople; break;

                    case "Gold": pricePerPerson = (5000 + 750) * 0.9 / groupOfPeople; break;

                    case "Platinum": pricePerPerson = (5000 + 1000) * 0.85 / groupOfPeople; break;
                }

                offer = $"We can offer you the Terrace\nThe price per person is {pricePerPerson:F2}$";
            }
            else
            {
                switch (package)
                {
                    case "Normal": pricePerPerson = (2500 + 500) * 0.95 / groupOfPeople; break;

                    case "Gold": pricePerPerson = (2500 + 750) * 0.9 / groupOfPeople; break;

                    case "Platinum": pricePerPerson = (2500 + 1000) * 0.85 / groupOfPeople; break;
                }

                offer = $"We can offer you the Small Hall\nThe price per person is {pricePerPerson:F2}$";
            }

            Console.WriteLine(offer);
        }
    }
}
