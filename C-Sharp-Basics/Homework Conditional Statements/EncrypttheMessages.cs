using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

class EncryptMessages
{
    static void Main(string[] args)
    {
        int e = 0;
        List<string> se = new List<string>();
        bool noStart = true;
        string m = Console.ReadLine();

        for (int tottalMessages = 0; tottalMessages < 102; tottalMessages++)
        {
            while (noStart)
            {
                if (m.ToUpper() == "START")
                {
                    noStart = false;
                    break;
                }
                m = Console.ReadLine();
            }

            m = Console.ReadLine();

            if (m == "END" || m == "end")
            {
                break;
            }
            else if (!string.IsNullOrWhiteSpace(m))
            {
                e++;
                StringBuilder buil = new StringBuilder(m);
                for (int i = 0; i < m.Length; i++)
                {
                    char symbol = Convert.ToString(m)[i];
                    if (symbol > 77 && symbol < 91)
                    {
                        buil[i] = (char)(symbol - 13);
                    }
                    else if (symbol > 64 && symbol < 78)
                    {
                        buil[i] = (char)(symbol + 13);
                    }
                    else if (symbol > 96 && symbol < 110)
                    {
                        buil[i] = (char)(symbol + 13);
                    }
                    else if (symbol > 109 && symbol < 123)
                    {
                        buil[i] = (char)(symbol - 13);
                    }
                    else
                    {
                        switch (symbol)
                        {
                            case ',':
                                buil[i] = (char)(symbol - 7);

                                break;
                            case '.':
                                buil[i] = (char)(symbol - 8);
                                break;
                            case '?':
                                buil[i] = (char)(symbol - 28);
                                break;
                            case '!':
                                buil[i] = (char)(symbol + 3);
                                break;
                            case ' ':
                                buil[i] = '+';
                                break;
                        }
                    }
                }
                se.Add(buil.ToString());
            }
        }
        if (e != 0)
        {
            Console.WriteLine("Total: {0}", e);
            for (int i = 0; i < se.Count; i++)
            {
                string output = se[i];
                for (int j = output.Length - 1; j >= 0; j--)
                {
                    Console.Write(output[j]);
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No..");
        }
    }
}
