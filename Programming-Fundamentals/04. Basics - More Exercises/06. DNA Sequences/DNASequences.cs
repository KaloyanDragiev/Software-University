namespace _06.DNA_Sequences
{
    using System;
  
    public class DNASequences
    {
        public static void Main()
        {
            int controlNum = int.Parse(Console.ReadLine());

            char[] nucleicAcidSequences = new char[] { 'A', 'C', 'G', 'T' };

            int[] nucleicAcidValues = new int[] { 1, 2, 3, 4};

            int rowCount = 0;

            for (int a = 0; a < nucleicAcidSequences.Length; a++)
            {
                for (int b = 0; b < nucleicAcidSequences.Length; b++)
                {
                    for (int c = 0; c < nucleicAcidSequences.Length; c++)
                    {
                        rowCount++;
                        if (nucleicAcidValues[a] + nucleicAcidValues[b] + nucleicAcidValues[c] >= controlNum)
                        {
                            if (rowCount % 4 != 0)
                            {
                                Console.Write("O{0}{1}{2}O ",

                                nucleicAcidSequences[a], nucleicAcidSequences[b], nucleicAcidSequences[c]);
                            }
                            else
                            {
                                Console.WriteLine("O{0}{1}{2}O ",

                                nucleicAcidSequences[a], nucleicAcidSequences[b], nucleicAcidSequences[c]);
                            }
                        }
                        else
                        {
                            if (rowCount % 4 != 0)
                            {
                                Console.Write("X{0}{1}{2}X ",

                                nucleicAcidSequences[a], nucleicAcidSequences[b], nucleicAcidSequences[c]);
                            }
                            else
                            {
                                Console.WriteLine("X{0}{1}{2}X ",

                                nucleicAcidSequences[a], nucleicAcidSequences[b], nucleicAcidSequences[c]);
                            }
                        }
                    }
                }
            }
        }
    }
}
