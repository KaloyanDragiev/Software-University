namespace _02.Change_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ChangeList
    {
        public static void Main()
        {
            var currentSequense = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var action = Console.ReadLine().Split();
            for (int index = 0; ; index++)
            {
                if (action[0] == "Delete")
                {
                    Delete(currentSequense, action);
                }
                else if (action[0] == "Insert")
                {
                    Insert(currentSequense, action);
                }
                else if (action[0] == "Odd")
                {
                    currentSequense = currentSequense
                        .FindAll(x => Convert.ToInt32(x) % 2 == 1).ToList();
                    Console.WriteLine(string.Join(" ", currentSequense));
                    break;
                }
                else if (action[0] == "Even")
                {
                    currentSequense = currentSequense
                        .FindAll(x => Convert.ToInt32(x) % 2 == 0).ToList();
                    Console.WriteLine(string.Join(" ", currentSequense));
                    break;
                }
                action = Console.ReadLine().Split();
            }
        }

        //Delete {element};
        private static void Delete(List<string> currentSequense, string[] action)
        {
            var toRemove = action[1];
            currentSequense.RemoveAll(x => x == toRemove);
        }

        //Insert {element} {position};
        private static void Insert(List<string> currentSequense, string[] action)
        {
            var index = int.Parse(action[2]);
            var element = action[1];
            currentSequense.Insert(index, element);
        }

    }
}
