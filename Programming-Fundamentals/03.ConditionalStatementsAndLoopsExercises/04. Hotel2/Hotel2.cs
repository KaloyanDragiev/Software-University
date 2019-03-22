namespace _04.Hotel2
{
    using System;
 
    public class Hotel2
    {
        public static void Main()
        {
            string monthOfHollyday = Console.ReadLine();

            uint nightsToStay = uint.Parse(Console.ReadLine());

            double studio = 0;
            double doble = 0;
            double suite = 0;

            switch (monthOfHollyday)
            {
                case "May":
                case "October":
                    studio = 50;
                    doble = 65;
                    suite = 75;
                    break;

                case "June":
                case "September":
                    studio = 60;
                    doble = 72;
                    suite = 82;
                    break;

                case "July":
                case "August":
                case "December":
                    studio = 68;
                    doble = 77;
                    suite = 89;
                    break;
            }

            double totalStudio = studio * nightsToStay;
            double totalDouble = doble * nightsToStay;
            double totalSuite = suite * nightsToStay;

            if (nightsToStay > 7)
            {
                switch (monthOfHollyday)
                {
                    case "May":
                        totalStudio *= 0.95;
                        break;

                    case "October":
                        totalStudio = totalStudio * 0.95 - studio * 0.95;
                        break;

                    case "September":
                        totalStudio = totalStudio - studio;
                        break;
                }
            }
            if (nightsToStay > 14)
            {
                switch (monthOfHollyday)
                {
                    case "June":
                    case "September":
                        totalDouble *= 0.9;
                        break;

                    case "July":
                    case "August":
                    case "December":
                        totalSuite *= 0.85;
                        break;
                }
            }

            Console.WriteLine($"Studio: {totalStudio:F2} lv.");
            Console.WriteLine($"Double: {totalDouble:F2} lv.");
            Console.WriteLine($"Suite: {totalSuite:F2} lv.");
        }
    }
}
