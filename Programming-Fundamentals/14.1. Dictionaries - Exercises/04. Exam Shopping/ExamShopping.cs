namespace _04.Exam_Shopping
{
    using System;
    using System.Collections.Generic;

    public class ExamShopping
    {
        public static void Main()
        {
            var productQuantityCollection = new Dictionary<string, Int32>();
            var product = string.Empty;
            var quantity = 0;
            for (int infiniatly = 0; ; infiniatly++)
            {
                var enteredData = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (enteredData[0] == "exam")
                {
                    Print(productQuantityCollection);
                    return;
                }
                else if (enteredData[0] == "stock")
                {
                    product = enteredData[1];
                    quantity = Convert.ToInt32(enteredData[2]);
                    StockeAllProducts(productQuantityCollection, product, quantity);
                }
                else if (enteredData[0] == "buy")
                {
                    product = enteredData[1];
                    quantity = Convert.ToInt32(enteredData[2]);
                    SaleProducts(productQuantityCollection, product, quantity);
                }
            }
        }

        private static void StockeAllProducts(
            Dictionary<string, Int32> productQuantityCollection, string product, int quantity)
        {
            if (!productQuantityCollection.ContainsKey(product))
            {
                productQuantityCollection[product] = 0;
            }
            productQuantityCollection[product] += quantity;
        }

        private static void SaleProducts(
            Dictionary<string, Int32> productQuantityCollection, string product, int quantity)
        {
            if (!productQuantityCollection.ContainsKey(product))
            {
                Console.WriteLine($"{product} doesn't exist");
            }
            else if (productQuantityCollection.ContainsKey(product) && productQuantityCollection[product] > 0)
            {
                productQuantityCollection[product] -= quantity;
            }
            else if (productQuantityCollection.ContainsKey(product) && productQuantityCollection[product] <= 0)
            {
                Console.WriteLine($"{product} out of stock");
            }
        }

        static void Print(Dictionary<string, Int32> productQuantityCollection)
        {
            foreach (var item in productQuantityCollection)
            {
                var name = item.Key;
                var value = item.Value;
                if (value > 0)
                {
                    Console.WriteLine($"{name} -> {value}");
                }
            }
        }
    }
}
