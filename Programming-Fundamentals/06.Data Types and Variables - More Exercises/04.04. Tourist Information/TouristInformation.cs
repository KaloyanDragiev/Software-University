namespace _04._04.Tourist_Information
{
    using System;
  
    public class TouristInformation
    {
        public static void Main()
        {
            string unitToConvert = Console.ReadLine();

            double valueToConvert = double.Parse(Console.ReadLine());

            if (unitToConvert == "miles")
            {
                Console.WriteLine($"{valueToConvert} {unitToConvert} = {valueToConvert * 1.6:F2} kilometers");
            }
            else if (unitToConvert == "inches")
            {
                Console.WriteLine($"{valueToConvert} {unitToConvert} = {valueToConvert * 2.54:F2} centimeters");
            }       
            else if (unitToConvert == "feet")
            {
                Console.WriteLine($"{valueToConvert} {unitToConvert} = {valueToConvert * 30:F2} centimeters");
            }
            else if (unitToConvert == "yards")
            {
                Console.WriteLine($"{valueToConvert} {unitToConvert} = {valueToConvert * 0.91:F2} meters");
            }
            else
            {
                Console.WriteLine($"{valueToConvert} {unitToConvert} = {valueToConvert * 3.8:F2} liters");
            }
        }
    }
}
