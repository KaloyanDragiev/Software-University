namespace _10.Data_Overflow
{
    using System;
   
    public class DataOverflow
    {
        public static void Main()
        {
            //(byte, ushort, uint, ulong)
            ulong firstNumber = ulong.Parse(Console.ReadLine());
            ulong secondNumber = ulong.Parse(Console.ReadLine());

            ulong maxOne = Math.Max(firstNumber, secondNumber);
            ulong minOne = Math.Min(firstNumber, secondNumber);

            string maxNumType = maxOne >= byte.MinValue && maxOne <= byte.MaxValue ? "byte" :
                maxOne >= ushort.MinValue && maxOne <= ushort.MaxValue ? "ushort" :
                maxOne >= uint.MinValue && maxOne <= uint.MaxValue ? "uint" : "ulong";

            string minNumType = minOne >= byte.MinValue && minOne <= byte.MaxValue ? "byte" :
                minOne >= ushort.MinValue && minOne <= ushort.MaxValue ? "ushort" :
                minOne >= uint.MinValue && minOne <= uint.MaxValue ? "uint" : "ulong";

            double minValue = minNumType == "byte" ? byte.MaxValue :
                minNumType == "ushort" ? ushort.MaxValue :
                minNumType == "uint" ? uint.MaxValue : ulong.MaxValue;

            double overflows = Math.Round(maxOne / minValue);

            Console.WriteLine($"bigger type: {maxNumType}");
            Console.WriteLine($"smaller type: {minNumType}");
            Console.WriteLine($"{maxOne} can overflow {minNumType} {overflows} times");
        }
    }
}
