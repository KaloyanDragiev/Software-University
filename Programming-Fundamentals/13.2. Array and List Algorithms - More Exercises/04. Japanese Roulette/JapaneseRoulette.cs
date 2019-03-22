namespace _04.Japanese_Roulette
{
    using System;

    public class JapaneseRoulette
    {
        public static void Main()
        {
            var cylinderPlaces = Console.ReadLine().Split(' ');
            var currentPlayers = Console.ReadLine().Split(' ');

            var buletPlace = 0;
            for (int index = 0; index < cylinderPlaces.Length; index++)
            {
                if (cylinderPlaces[index] == "1")
                {
                    buletPlace = index + 1; break;
                }
            }

            for (int currentPlayer = 0; currentPlayer < currentPlayers.Length; currentPlayer++)
            {
                var player = currentPlayers[currentPlayer].Split(',');
                var direction = player[1];
                var strenght = Convert.ToInt32(player[0]);

                if (direction == "Left")
                {
                    buletPlace = 6 - Math.Abs(strenght - buletPlace) % 6;
                }
                else if (direction == "Right")
                {
                    buletPlace = (strenght + buletPlace) % 6;
                }

                if (buletPlace == 3)
                {
                    Console.WriteLine($"Game over! Player {currentPlayer} is dead.");
                    return;
                }
                    buletPlace = (buletPlace + 1) % 6;
            }
            Console.WriteLine("Everybody got lucky!");
        }
    }
}
