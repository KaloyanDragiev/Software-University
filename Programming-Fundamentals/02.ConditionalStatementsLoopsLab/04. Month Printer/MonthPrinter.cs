namespace _04.Month_Printer
{
    using System;
    using System.Globalization;
   
    public class MonthPrinter
    {
        public static void Main()
        {
            int month = int.Parse(Console.ReadLine());

            if (month >= 1 && month <= 12)
            {
                DateTime monthInWords = new DateTime(2017, month, 01);

                Console.WriteLine(monthInWords.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-EN")));
            }
            else
            {

                Console.WriteLine("Error!");
            }
        }
    }
}
