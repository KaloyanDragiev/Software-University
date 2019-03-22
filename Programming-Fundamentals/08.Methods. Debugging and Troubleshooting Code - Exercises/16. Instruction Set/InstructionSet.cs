using System;
using System.Numerics;

namespace _15.Instruction_Set
{
    class InstructionSet
    {
        static void Main(string[] args)
        {
            string opCode = Console.ReadLine();

            while (opCode != "END")
            {
                string[] codeArgs = opCode.Split(' ');
                long operandOne = 0;
                long operandTwo = 0;
                BigInteger result = 0;
                switch (codeArgs[0])
                {
                    case "INC":
                        operandOne = long.Parse(codeArgs[1]);
                        result = ++operandOne;
                        break;

                    case "DEC":
                        operandOne = long.Parse(codeArgs[1]);
                        result = --operandOne;
                        break;

                    case "ADD":
                        operandOne = long.Parse(codeArgs[1]);
                        operandTwo = long.Parse(codeArgs[2]);
                        result = operandOne + operandTwo;
                        break;

                    case "MLA":
                        operandOne = long.Parse(codeArgs[1]);
                        operandTwo = long.Parse(codeArgs[2]);
                        result = operandOne * operandTwo;
                        break;

                }
                Console.WriteLine(result);
                opCode = Console.ReadLine();
            }
        }
    }
}