namespace _18.Ballistics_Training
{
    using System;

    public class BallisticsTraining
    {
        public static void Main()
        {
            var target = Console.ReadLine().Split();
            var X = 0d;
            var Y = 0d;
            var pointingValue = 0d;
            var pointingAt = Console.ReadLine().Split(' ');
            var pointingCount = pointingAt.Length;
            for (int index = 0; index < pointingCount - 1; index += 2)
            {
                pointingValue = Convert.ToDouble(pointingAt[index + 1]);
                if (pointingAt[index] == "up")
                {
                    Y += pointingValue;
                }
                if (pointingAt[index] == "down")
                {
                    Y -= pointingValue;
                }
                if (pointingAt[index] == "right")
                {
                    X += pointingValue;
                }
                if (pointingAt[index] == "left")
                {
                    X -= pointingValue;
                }
            }
            
            if (X.ToString() == target[0] && Y.ToString() == target[1])
            {
                Console.WriteLine("firing at [{0}, {1}]\r\ngot 'em!", X, Y);
            }
            else
            {
                Console.WriteLine("firing at [{0}, {1}]\r\nbetter luck next time...", X, Y);
            }
        }
    }
}
