namespace _11.Dragon_Army
{
    using System;
    using System.Collections.Generic;

    public class DragonArmy
    {
        public static void Main()
        {
            var dragonsCollection = new Dictionary<string, SortedDictionary<string, double[]>>();

            var commingDragons = Convert.ToInt32(Console.ReadLine());
            for (int dragons = 0; dragons < commingDragons; dragons++)
            {
                var currentDragon = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var type = currentDragon[0];
                var name = currentDragon[1];

                var damage = 0.0; //currentDragon[2]; => 45
                if (!double.TryParse(currentDragon[2], out damage))
                {
                    damage = 45;
                }

                var health = 0.0; //currentDragon[3]; => 250
                if (!double.TryParse(currentDragon[3], out health))
                {
                    health = 250;
                }

                var armor = 0.0; //currentDragon[4];  => 10
                if (!double.TryParse(currentDragon[4], out armor))
                {
                    armor = 10;
                }

                if (!dragonsCollection.ContainsKey(type))
                {
                    dragonsCollection[type] = new SortedDictionary<string, double[]>();
                }
                if (!dragonsCollection[type].ContainsKey(name))
                {
                    dragonsCollection[type][name] = new double[3];
                }
                dragonsCollection[type][name][0] = damage;
                dragonsCollection[type][name][1] = health;
                dragonsCollection[type][name][2] = armor;
            }

            foreach (var type in dragonsCollection)
            {
                var averageDamage = 0.0;
                var averageHealth = 0.0;
                var averageArmor = 0.0;
                var counter = 0;
                foreach (var allInThisType in type.Value)
                {
                    averageDamage += allInThisType.Value[0];
                    averageHealth += allInThisType.Value[1];
                    averageArmor += allInThisType.Value[2];
                    counter++;
                }

                Console.WriteLine($"{type.Key}::({averageDamage / counter:F2}/{averageHealth / counter:F2}/{averageArmor / counter:F2})");
                foreach (var name in type.Value)
                {
                    var values = name.Value;
                    Console.WriteLine($"-{name.Key} -> damage: {values[0]}, health: {values[1]}, armor: {values[2]}");
                }
            }
        }
    }
}
