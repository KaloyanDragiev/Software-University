namespace _10.Сръбско_Unleashed
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class СръбскоUnleashed
    {
        public static void Main()
        {
            var salaryCollection = new Dictionary<string, Dictionary<string, double>>();
            for (int infiniatly = 0; ; infiniatly++)
            {
                var enteredData = Console.ReadLine();
                if (enteredData == "End")
                {
                    PrintAllParticipants(salaryCollection);
                    return;
                }
                var splited = enteredData.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var ticketsQuantity = 0.0;
                if (!double.TryParse(splited[splited.Length - 1], out ticketsQuantity))
                {
                    continue;
                }

                var ticketsPrice = 0.0;
                if (!double.TryParse(splited[splited.Length - 2], out ticketsPrice))
                {
                    continue;
                }

                var location = string.Empty;
                if (!ParseLocation(splited, ref location))
                {
                    continue;
                }

                var singer = string.Empty;
                if (!ParseSinger(splited, ref singer))
                {
                    continue;
                }

                if (!salaryCollection.ContainsKey(location))
                {
                    salaryCollection[location] = new Dictionary<string, double>();
                }
                if (!salaryCollection[location].ContainsKey(singer))
                {
                    salaryCollection[location][singer] = 0;
                }
                salaryCollection[location][singer] += ticketsQuantity * ticketsPrice;
            }
        }

        private static bool ParseLocation(string[] splited, ref string location)
        {
            var isKlemove = false;
            var isFirst = true;
            for (int index = 0; index < splited.Length - 2; index++)
            {
                if (splited[index][0] == '@')
                {
                    isKlemove = true;
                }
                if (isKlemove && isFirst)
                {
                    isFirst = false;
                    location += splited[index].Remove(0, 1);
                    continue;
                }
                else if (isKlemove && !isFirst)
                {
                    location += $" {splited[index]}";
                }
            }
            return location.Length > 0;
        }

        private static bool ParseSinger(string[] splited, ref string singer)
        {
            var isFirst = true;
            for (int index = 0; index < splited.Length - 2; index++)
            {
                if (singer.Contains("@"))
                {
                    singer = string.Empty;
                    return false;
                }
                if (splited[index][0] == '@')
                {
                    break;
                }
                if (isFirst)
                {
                    isFirst = false;
                    singer += splited[index];
                    continue;
                }
                singer += $" {splited[index]}";
            }
            return singer.Length > 0;
        }

        private static void PrintAllParticipants(Dictionary<string, Dictionary<string, double>> salaryCollection)
        {
            foreach (var location in salaryCollection)
            {
                Console.WriteLine(location.Key);
                var orderedByDescending = location.Value.OrderByDescending(x => x.Value);
                foreach (var line in orderedByDescending)
                {
                    Console.WriteLine($"#  {line.Key} -> {line.Value}");
                }
            }
        }
    }
}
