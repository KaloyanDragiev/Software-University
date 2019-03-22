namespace _04.Hotel
{
    using System;

    public class Hotel
    {
        public static void Main()
        {
            string monthOfHollyday = Console.ReadLine();

            uint nightsToStay = uint.Parse(Console.ReadLine());

            double studio = 0;

            double doble = 0;

            double suite = 0;

            if (nightsToStay > 14)//June, September * 0.9; / July, August, December * 0.85;
            {
                switch (monthOfHollyday)
                {
                    case "May":
                        studio = 50 * 0.95 * nightsToStay;
                        doble = 65 * nightsToStay;
                        suite = 75 * nightsToStay;
                        break;

                    case "June":
                        studio = 60 * nightsToStay;
                        doble = 72 * 0.9 * nightsToStay;
                        suite = 82 * nightsToStay;
                        break;

                    case "July":
                        studio = 68 * nightsToStay;
                        doble = 77 * nightsToStay;
                        suite = 89 * 0.85 * nightsToStay;
                        break;

                    case "August":
                        studio = 68 * nightsToStay;
                        doble = 77 * nightsToStay;
                        suite = 89 * 0.85 * nightsToStay;
                        break;

                    case "September":
                        studio = 60 * (nightsToStay - 1);
                        doble = 72 * 0.9 * nightsToStay;
                        suite = 82 * nightsToStay;
                        break;

                    case "October":
                        studio = 50 * 0.95 * (nightsToStay - 1);
                        doble = 65 * nightsToStay;
                        suite = 75 * nightsToStay;
                        break;

                    case "December":
                        studio = 68 * nightsToStay;
                        doble = 77 * nightsToStay;
                        suite = 89 * 0.85 * nightsToStay;
                        break;
                }
            }
            else if (nightsToStay > 7)//Mai, October * 0.95/ September, October -1 night
            {
                switch (monthOfHollyday)
                {
                    case "May":
                        studio = 50 * 0.95 * nightsToStay;
                        doble = 65 * nightsToStay;
                        suite = 75 * nightsToStay;
                        break;

                    case "June":
                        studio = 60 * nightsToStay;
                        doble = 72 * nightsToStay;
                        suite = 82 * nightsToStay;
                        break;

                    case "July":
                        studio = 68 * nightsToStay;
                        doble = 77 * nightsToStay;
                        suite = 89 * nightsToStay;
                        break;

                    case "August":
                        studio = 68 * nightsToStay;
                        doble = 77 * nightsToStay;
                        suite = 89 * nightsToStay;
                        break;

                    case "September":
                        studio = 60 * (nightsToStay - 1);
                        doble = 72 * nightsToStay;
                        suite = 82 * nightsToStay;
                        break;

                    case "October":
                        studio = 50 * 0.95 * (nightsToStay - 1);
                        doble = 65 * nightsToStay;
                        suite = 75 * nightsToStay;
                        break;

                    case "December":
                        studio = 68 * nightsToStay;
                        doble = 77 * nightsToStay;
                        suite = 89 * nightsToStay;
                        break;
                }
            }
            else
            {
                switch (monthOfHollyday)
                {
                    case "May":
                        studio = 50 * nightsToStay;
                        doble = 65 * nightsToStay;
                        suite = 75 * nightsToStay;
                        break;

                    case "June":
                        studio = 60 * nightsToStay;
                        doble = 72 * nightsToStay;
                        suite = 82 * nightsToStay;
                        break;

                    case "July":
                        studio = 68 * nightsToStay;
                        doble = 77 * nightsToStay;
                        suite = 89 * nightsToStay;
                        break;

                    case "August":
                        studio = 68 * nightsToStay;
                        doble = 77 * nightsToStay;
                        suite = 89 * nightsToStay;
                        break;

                    case "September":
                        studio = 60 * nightsToStay;
                        doble = 72 * nightsToStay;
                        suite = 82 * nightsToStay;
                        break;

                    case "October":
                        studio = 50 * nightsToStay;
                        doble = 65 * nightsToStay;
                        suite = 75 * nightsToStay;
                        break;

                    case "December":
                        studio = 68 * nightsToStay;
                        doble = 77 * nightsToStay;
                        suite = 89 * nightsToStay;
                        break;
                }
            }

            Console.WriteLine($"Studio: {studio:F2} lv.");

            Console.WriteLine($"Double: {doble:F2} lv.");

            Console.WriteLine($"Suite: {suite:F2} lv.");
        }
    }
}
