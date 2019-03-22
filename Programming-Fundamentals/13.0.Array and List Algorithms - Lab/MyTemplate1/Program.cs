namespace MyTemplate1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            var arr = new int[] { 1, 2, 3, 4 };
            var temp = arr[arr.Length - 1];
            for (int i = arr.Length - 1; i > 0; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[0] = temp;
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
