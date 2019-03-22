namespace _14.BoatSimulator
{
    using System;

    public class BoatSimulator
    {
        public static void Main()
        {
            char firstBoat = char.Parse(Console.ReadLine());
            char secondBoat = char.Parse(Console.ReadLine());

            byte followingLines = byte.Parse(Console.ReadLine());

            byte movesCounterFirstBoat = 0;
            byte movesCounterSecondBoat = 0;

            byte firstBoatSpeed = 0;
            byte secondBoatSpeed = 0;

            for (int line = 1; line <= followingLines; line++)
            {
                string boatSpeed = Console.ReadLine();

                if (boatSpeed == "UPGRADE")
                {
                    firstBoat = (char)(firstBoat + 3);
                    secondBoat = (char)(secondBoat + 3);
                    continue;
                }

                if (line % 2 == 1)
                {
                    firstBoatSpeed += (byte)boatSpeed.Length;
                    if (firstBoatSpeed >= 50)
                    {
                        Console.WriteLine(firstBoat);
                        break;
                    }
                    movesCounterFirstBoat++;
                }
                else
                {
                    secondBoatSpeed += (byte)boatSpeed.Length;
                    if (secondBoatSpeed >= 50)
                    {
                        Console.WriteLine(secondBoat);
                        break;
                    }
                    movesCounterSecondBoat++;
                }
            }

            if (firstBoatSpeed < 50 && secondBoatSpeed < 50)
            {
                Console.WriteLine(movesCounterFirstBoat > movesCounterSecondBoat ? firstBoat : secondBoat);
            }
        }
    }
}
