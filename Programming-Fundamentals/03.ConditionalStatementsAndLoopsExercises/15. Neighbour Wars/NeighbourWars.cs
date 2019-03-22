namespace _15.Neighbour_Wars
{
    using System;
   
    public class NeighbourWars
    {
        public static void Main()
        {
            int peshosDemage = int.Parse(Console.ReadLine());

            int goshosDemage = int.Parse(Console.ReadLine());

            int peshosHealt = 100;

            int goshosHealt = 100;

            int roundsCounter = 0;

            while (true)
            {
                roundsCounter++;

                if (roundsCounter % 2 == 0)
                {                   
                    if (peshosHealt <= goshosDemage)
                    {
                        Console.WriteLine($"Gosho won in {roundsCounter}th round.");

                        break;
                    }

                    peshosHealt -= goshosDemage;

                    Console.Write($"Gosho used Thunderous fist and reduced Pesho to ");

                    Console.WriteLine($"{peshosHealt} health.");
                }
                else
                {             
                    if (goshosHealt <= peshosDemage)
                    {
                        Console.WriteLine($"Pesho won in {roundsCounter}th round.");

                        break;
                    }

                    goshosHealt -= peshosDemage;

                    Console.Write($"Pesho used Roundhouse kick and reduced Gosho to ");

                    Console.WriteLine($"{goshosHealt} health.");
                }
                
                if (roundsCounter % 3 == 0)
                {
                    goshosHealt += 10;

                    peshosHealt += 10;
                }
            }

        }
    }
}
