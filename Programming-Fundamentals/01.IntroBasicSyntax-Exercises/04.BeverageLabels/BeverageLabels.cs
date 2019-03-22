namespace _04.BeverageLabels
{
    using System;
   
    public class BeverageLabels
    {
        public static void Main()
        {
            string productName = Console.ReadLine();

            double productVolume = double.Parse(Console.ReadLine());

            double productEnergyContent = double.Parse(Console.ReadLine());

            double produktSugerContent = double.Parse(Console.ReadLine());

            double energy = productVolume * productEnergyContent / 100;

            double suger = productVolume * produktSugerContent / 100;

            Console.WriteLine("{0}ml {1}:\n{2}kcal, {3}g sugars", productVolume, productName, energy, suger);
        }
    }
}
