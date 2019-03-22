namespace _01.DebitCardNumber
{
    using System;

    public class DebitCardNumber
    {
        public static void Main()
        {
            int firstDigits = int.Parse(Console.ReadLine());

            int secondDigits = int.Parse(Console.ReadLine());

            int thirdDigits = int.Parse(Console.ReadLine());

            int fourthDigits = int.Parse(Console.ReadLine());

            Console.WriteLine("{0} {1} {2} {3}", firstDigits.ToString("0000"), secondDigits.ToString("0000"),

                    thirdDigits.ToString("0000"), fourthDigits.ToString("0000"));
        }
    }
}
