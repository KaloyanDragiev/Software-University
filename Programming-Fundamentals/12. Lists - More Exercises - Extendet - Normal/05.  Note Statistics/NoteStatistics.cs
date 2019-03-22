namespace _05.Note_Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NoteStatistics
    {
        public static void Main()
        {
            var letters = new List<string>()
            { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};

            var frequence = new List<double>()
            { 261.63, 277.18, 293.66, 311.13, 329.63, 349.23, 369.99, 392.00, 415.30, 440.00, 466.16, 493.88 };

            var givenFrequences = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            var noteFrequence = new string[givenFrequences.Length];
            for (int count = 0; count < givenFrequences.Length; count++)
            {
                var currentFrequence = givenFrequences[count];
                var index = frequence.IndexOf(currentFrequence);
                noteFrequence[count] = letters[index];
            }

            var sumNaturals = 0.0;
            var sumSharps = 0.0;

            for (int count = 0; count < givenFrequences.Length; count++)
            {
                if (noteFrequence[count].Contains("#"))
                {
                    sumSharps += givenFrequences[count];
                }
                else
                {
                    sumNaturals += givenFrequences[count];
                }
            }
            Console.WriteLine($"Notes: {string.Join(" ", noteFrequence)}");
            Console.WriteLine($"Naturals: {string.Join(", ", noteFrequence.Where(x => !x.Contains("#")))}");
            Console.WriteLine($"Sharps: {string.Join(", ", noteFrequence.Where(x => x.Contains("#")))}");
            Console.WriteLine($"Naturals sum: {sumNaturals}");
            Console.WriteLine($"Sharps sum: {sumSharps}");
        }
    }
}

//using System;
//using System.Linq;
//using System.Collections.Generic;
//namespace NoteStatistics
//{
//    public class noteStatistics
//    {
//        public static void Main()
//        {
//            List<string> letters = new List<string>
//            { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};
//            List<double> frequence = new List<double>
//            { 261.63, 277.18, 293.66, 311.13, 329.63, 349.23, 369.99, 392.00, 415.30, 440.00, 466.16, 493.88 };
//            List<double> input = Console.ReadLine().Split().Select(double.Parse).ToList();

//            List<int> index = GettingIndex(frequence, input);
//            List<string> result = TakeTheResult(index, letters, frequence);

//            Console.WriteLine(string.Join(Environment.NewLine, result));
//        }

//        private static List<string> TakeTheResult(List<int> index, List<string> letters, List<double> frequence)
//        {
//            string output = "Notes: ";
//            double nSum = 0;
//            string naturalsSum = "Naturals sum: ";
//            double sSum = 0;
//            string sharpsSum = "Sharps sum: ";

//            List<string> naturals = new List<string>();
//            List<string> sharps = new List<string>();
//            List<string> result = new List<string>();

//            for (int i = 0; i < index.Count; i++)
//            {
//                output += (letters[index[i]]) + " ";
//                if (letters[index[i]].Length > 1)
//                {
//                    sSum += frequence[index[i]];
//                    sharps.Add(letters[index[i]]);
//                }
//                else
//                {
//                    nSum += frequence[index[i]];
//                    naturals.Add(letters[index[i]]);
//                }

//            }
//            string naturalsN = "Naturals: " + string.Join(", ", naturals);
//            string sharpsS = "Sharps: " + string.Join(", ", sharps);

//            sharpsSum += sSum.ToString();
//            naturalsSum += nSum.ToString();

//            result.Add(output);
//            result.Add(naturalsN);
//            result.Add(sharpsS);
//            result.Add(naturalsSum);
//            result.Add(sharpsSum);

//            return result;
//        }

//        private static List<int> GettingIndex(List<double> frequence, List<double> input)
//        {
//            List<int> index = new List<int>();
//            for (int a = 0; a < input.Count; a++)
//            {
//                for (int b = 0; b < frequence.Count; b++)
//                {
//                    if (input[a] == frequence[b])
//                    {
//                        index.Add(b);
//                        break;
//                    }
//                }
//            }
//            return index;
//        }
//    }
//}
