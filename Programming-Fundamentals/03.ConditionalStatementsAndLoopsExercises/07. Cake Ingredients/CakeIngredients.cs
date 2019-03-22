namespace _07.Cake_Ingredients
{
    using System;
   
    public class CakeIngredients
    {
        public static void Main()
        {
            string inputIngredient = Console.ReadLine();

            int ingredientsCounter = 0;

            while (inputIngredient != "Bake!")
            {
                ingredientsCounter++;

                Console.WriteLine("Adding ingredient {0}.", inputIngredient);

                inputIngredient = Console.ReadLine();
            }

            Console.WriteLine("Preparing cake with {0} ingredients.", ingredientsCounter);
        }
    }
}
