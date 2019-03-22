namespace _04.Hotel3
{
    using System;
 
    public class Hotel3
    {
        public static void Main()
        {
            string monthOfHollyday = Console.ReadLine();

            uint nightsToStay = uint.Parse(Console.ReadLine());

            double studio = 0;
            double doble = 0;
            double suite = 0;

            if (monthOfHollyday == "May" || monthOfHollyday == "October")
            {
                studio = 50;
                doble = 65;
                suite = 75;
            }
            if (monthOfHollyday == "June" || monthOfHollyday == "September")
            {
                studio = 60;
                doble = 72;
                suite = 82;
            }
            if (monthOfHollyday == "July" || monthOfHollyday == "August" || monthOfHollyday == "December")
            {
                studio = 68;
                doble = 77;
                suite = 89;
            }

            double totalStudio = studio * nightsToStay;
            double totalDouble = doble * nightsToStay;
            double totalSuite = suite * nightsToStay;

            if (nightsToStay > 7 && monthOfHollyday == "May")
            {
                totalStudio *= 0.95;
            }
            if (nightsToStay > 7 && monthOfHollyday == "October")
            {
                totalStudio = totalStudio * 0.95 - studio * 0.95;
            }
            if (nightsToStay > 7 && monthOfHollyday == "September")
            {
                totalStudio = totalStudio - studio;
            }
            if (nightsToStay > 14 && (monthOfHollyday == "June" || monthOfHollyday == "September"))
            {
                totalDouble *= 0.9;
            }
            if (nightsToStay > 14 && 
                (monthOfHollyday == "July" || monthOfHollyday == "August" || monthOfHollyday == "December"))
            {
                        totalSuite *= 0.85;
            }

            Console.WriteLine($"Studio: {totalStudio:F2} lv.");
            Console.WriteLine($"Double: {totalDouble:F2} lv.");
            Console.WriteLine($"Suite: {totalSuite:F2} lv.");
        }
    }
}
