namespace _05.Increasing_Crisis
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class IncreasingCrisis
    {
        public static void Main()
        {
            int lineToEnter = int.Parse(Console.ReadLine());
            List<int> result = new List<int>();

            for (int i = 0; i < lineToEnter; i++)
            {
                List<int> enter = Console.ReadLine().Split().Select(int.Parse).ToList();

                if (result.Count == 0)
                {
                    result.AddRange(enter);
                    continue;
                }

                int enterIndex = 0;
                bool isIncreasing = true;

                if (enter.Count > 1)
                {
                    for (int a = 1; a < enter.Count; a++)
                    {
                        if (enter[a - 1] > enter[a])
                        {
                            isIncreasing = false;
                            enterIndex = a;
                            break;
                        }
                    }

                    if (!isIncreasing)
                    {
                        for (int b = enterIndex; b < enter.Count; b++)
                        {
                            enter.RemoveAt(b);
                            b--;
                        }
                    }
                }

                int resultIndex = 0;

                for (int a = 0; a < result.Count; a++)
                {
                    if (result[a] <= enter[0])
                    {
                        resultIndex++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (enter.Count == 1)
                {
                    result.Insert(resultIndex, enter[0]);
                    if (!isIncreasing)
                    {
                        for (int a = enter.Count + resultIndex; a < result.Count; a++)
                        {
                            result.RemoveAt(a);
                            a--;
                        }
                    }
                    continue;
                }

                if (resultIndex == result.Count)
                {
                    result.AddRange(enter);
                    continue;
                }

                bool isResultIncreasing = true;
                int enterCounter = 0;

                for (int a = resultIndex; a < result.Count; a++)
                {
                    if (enter[enterCounter] <= result[a])
                    {
                        result.Insert(a, enter[enterCounter]);
                        enterCounter++;
                        if (enterCounter == enter.Count)
                        {
                            break;
                        }
                    }
                    else
                    {
                        result.Insert(a, enter[enterCounter]);
                        isResultIncreasing = false;
                        enterCounter = a + 1;
                        break;
                    }
                }

                if (!isResultIncreasing)
                {
                    for (int a = enterCounter; a < result.Count; a++)
                    {
                        result.RemoveAt(a);
                        a--;
                    }
                }

                if (!isIncreasing)
                {
                    for (int a = enter.Count + resultIndex; a < result.Count; a++)
                    {
                        result.RemoveAt(a);
                        a--;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
