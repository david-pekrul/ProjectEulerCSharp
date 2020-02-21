using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler40
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dn = new int[7];
            dn[0] = 1;

            int n = 0;
            int i = 1;
            int breakingPoint = 1;
            int index = 0;
            while (n < 1000000)
            {
                string line = i.ToString();
                int linelength = line.Length;
                if (n + linelength == breakingPoint)
                {
                    int value = Convert.ToInt32(line[linelength-1]) - 48;//from ord to int
                    dn[index] = value;
                    index++;
                    breakingPoint *= 10;
                }
                else if (n + linelength > breakingPoint)
                {
                    int lineIndex = (breakingPoint - n);
                    int value = Convert.ToInt32(line[lineIndex-1]) - 48;//from ord to int 
                    dn[index] = value;
                    index++;
                    breakingPoint *= 10;
                }
                n += linelength;

                i++;
            }

            int mult = 1;
            foreach (int x in dn)
            {
                mult *= x;
                Console.WriteLine(x);
            }
            Console.WriteLine("\nmult: " + mult);
        }
    }
}
