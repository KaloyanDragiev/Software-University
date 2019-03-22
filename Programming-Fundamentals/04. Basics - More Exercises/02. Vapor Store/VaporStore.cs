namespace _02.Vapor_Store
{
    using System;
  
    public class VaporStore
    {
        public static void Main()
        {
            double balance = double.Parse(Console.ReadLine());

            string currentGame = Console.ReadLine();

            double restSum = balance;

            bool isOutOfMoney = false;

            while (currentGame != "Game Time")
            {
                double tempSum = restSum;

                if (currentGame == "OutFall 4" || currentGame == "RoverWatch Origins Edition")
                {
                    restSum -= 39.99;
                }
                else if (currentGame == "CS: OG")
                {
                    restSum -= 15.99;
                }
                else if (currentGame == "Zplinter Zell")
                {
                    restSum -= 19.99;
                }
                else if (currentGame == "Honored 2")
                {
                    restSum -= 59.99;
                }
                else if (currentGame == "RoverWatch")
                {
                    restSum -= 29.99;
                }
                else
                {
                    Console.WriteLine("Not Found");
                }

                if (restSum >= 0 && (currentGame == "OutFall 4" || currentGame == "CS: OG" ||

                    currentGame == "RoverWatch Origins Edition" || currentGame == "Zplinter Zell" ||

                    currentGame == "Honored 2" || currentGame == "RoverWatch"))
                {
                    Console.WriteLine($"Bought {currentGame}");
                }

                if (restSum == 0)
                {
                    Console.WriteLine("Out of money!");

                    isOutOfMoney = true;

                    break;
                }
                else if (restSum < 0)
                {
                    Console.WriteLine("Too Expensive");

                    restSum = tempSum;
                }

                currentGame = Console.ReadLine();
            }

            if (!isOutOfMoney)
            {
                Console.WriteLine($"Total spent: ${balance - restSum:F2}. Remaining: ${restSum:F2}");
            }
        }
    }
}
