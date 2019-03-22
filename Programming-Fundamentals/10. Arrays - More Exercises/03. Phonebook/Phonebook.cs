namespace _03.Phonebook
{
    using System;

    public class Phonebook
    {
        public static void Main()
        {
            var phones = Console.ReadLine().Split();
            var names = Console.ReadLine().Split();
            var name = Console.ReadLine();
            var index = 0;
            while (name != "done")
            {
                index = IndexOf(name, names);
                Console.WriteLine("{0} -> {1}", name, phones[index]);
                name = Console.ReadLine();
            }
        }

        private static int IndexOf(string name, string[] names)
        {
            var index = 0;
            var counter = names.Length;
            for (index = 0; index < counter; index++)
            {
                if (names[index] == name)
                {
                    break;
                }
            }
            return index;
        }
    }
}
