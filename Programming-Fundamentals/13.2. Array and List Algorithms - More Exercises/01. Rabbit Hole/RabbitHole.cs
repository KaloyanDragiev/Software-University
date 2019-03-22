namespace _01.Rabbit_Hole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RabbitHole
    {
        static List<string> places;

        public static void Main()
        {
            places = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var mainPower = Convert.ToInt32(Console.ReadLine());

            var moveTo = 0;

            var wasBomb = false;

            for (int infinitely = 0; ; infinitely++)
            {
                wasBomb = false;

                var currentPlase = places[moveTo].Split('|');

                if (currentPlase[0] == "Left")
                {
                    JumpToTheLeft(currentPlase, ref mainPower, ref moveTo);
                }
                else if (currentPlase[0] == "Right")
                {
                    JumpToTheRight(currentPlase, ref mainPower, ref moveTo);
                }
                else if (currentPlase[0] == "RabbitHole")
                {
                    Console.WriteLine("You have 5 years to save Kennedy!"); return;
                }
                else
                {
                    AfterTheExplosion(currentPlase, ref mainPower, ref moveTo);
                    wasBomb = true;
                }
                if (mainPower <= 0 && wasBomb)
                {
                    Console.WriteLine("You are dead due to bomb explosion!"); return;
                }
                else if (mainPower <= 0 && !wasBomb)
                {
                    Console.WriteLine("You are tired. You can't continue the mission."); return;
                }
                AddBombAtTheEndOrReplaceIt(ref mainPower);
            }
        }

        private static void JumpToTheLeft(string[] currentPlace, ref int mainPower, ref int moveTo)
        {
            var power = Convert.ToInt32(currentPlace[1]);

            mainPower -= power;

            moveTo = (power - moveTo) % places.Count;
        }

        private static void JumpToTheRight(string[] currentPlace, ref int mainPower, ref int moveTo)
        {
            var power = Convert.ToInt32(currentPlace[1]);

            mainPower -= power;

            moveTo = (power + moveTo) % places.Count;
        }

        private static void AfterTheExplosion(string[] currentPlace, ref int mainPower, ref int moveTo)
        {
            mainPower -= Convert.ToInt32(currentPlace[1]);

            places.RemoveAt(moveTo);

            moveTo = 0;
        }

        private static void AddBombAtTheEndOrReplaceIt(ref int mainPower)
        {
            if (places[places.Count - 1] == "RabbitHole" && mainPower > 0)
            {
                places.Add($"Bomb|{mainPower}");
            }
            if (places[places.Count - 1] != "RabbitHole" && mainPower > 0)
            {
                places[places.Count - 1] = $"Bomb|{mainPower}";
            }
        }

    }
}
