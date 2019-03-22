namespace _07.Training_Hall_Equipment
{
    using System;
   
    public class TrainingHallEquipment
    {
        public static void Main()
        {
            double budget = double.Parse(Console.ReadLine());

            int itemsToBuy = int.Parse(Console.ReadLine());

            double totalSum = 0;

            for (int i = 0; i < itemsToBuy; i++)
            {
                string itemName = Console.ReadLine();

                double itemPrice = double.Parse(Console.ReadLine());

                int itemCount = int.Parse(Console.ReadLine());

                if (itemCount != 1)
                {
                    itemName += "s";
                }

                totalSum += itemPrice * itemCount; 

                Console.WriteLine($"Adding {itemCount} {itemName} to cart.");
            }

            Console.WriteLine("Subtotal: ${0:F2}", totalSum);

            if (budget >= totalSum)
            {  
                Console.WriteLine("Money left: ${0:F2}", budget - totalSum);
            }
            else
            {
                Console.WriteLine("Not enough. We need ${0:F2} more.", totalSum - budget);
            }
        }
    }
}
