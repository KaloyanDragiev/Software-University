namespace _12.Beer_Kegs
{
    using System;
   
    public class Program
    {
        public static void Main()
        {
            byte nTimes = byte.Parse(Console.ReadLine());

            double volumeOfTheBigestKeg = 0;
            double tempVolume = 0;
            string modelAtTheBiggestKeg = string.Empty;

            for (int interation = 1; interation <= nTimes; interation++)
            {
                string modelOfTheCurrentKeg = Console.ReadLine();
                double radiusOfCurrentTheKeg = double.Parse(Console.ReadLine());
                int heightOfTheCurrentKeg = int.Parse(Console.ReadLine());

                tempVolume = Math.PI * Math.Pow(radiusOfCurrentTheKeg, 2) * heightOfTheCurrentKeg;

                if (volumeOfTheBigestKeg < tempVolume)
                {
                    volumeOfTheBigestKeg = tempVolume;
                    modelAtTheBiggestKeg = modelOfTheCurrentKeg;
                }
            }

            Console.WriteLine(modelAtTheBiggestKeg);
        }
    }
}
