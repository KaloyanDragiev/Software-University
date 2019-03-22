namespace _15.Fast_Prime_Checker
{
    using System;
   
    public class FastPrimeChecker
    {
        public static void Main()
        {
            int ___Do___ = int.Parse(Console.ReadLine());
            for (int DAVIDIM = 2; DAVIDIM <= ___Do___; DAVIDIM++)
            {
                bool TowaLIE = true;
                for (int delio = 2; delio <= Math.Sqrt(DAVIDIM); delio++)
                {
                    if (DAVIDIM % delio == 0)
                    {
                        TowaLIE = false;
                        break;
                    }
                }
                Console.WriteLine($"{DAVIDIM} -> {TowaLIE}");
            }
        }
    }
}
