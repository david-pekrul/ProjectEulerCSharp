using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler53
{
    /*
     *  There are exactly ten ways of selecting three from five, 12345:

        123, 124, 125, 134, 135, 145, 234, 235, 245, and 345

        In combinatorics, we use the notation, 5C3 = 10.

        In general,
        nCr = 	
        n!
        r!(n−r)!
	        ,where r ≤ n, n! = n×(n−1)×...×3×2×1, and 0! = 1.

        It is not until n = 23, that a value exceeds one-million: 23C10 = 1144066.

        How many, not necessarily distinct, values of  nCr, for 1 ≤ n ≤ 100, are greater than one-million?

     */
    class Program
    {
        static void Main(string[] args)
        {
            //Zero stands for the values greater than 1,000,000.
            int total = 0;
            List<BigInteger> line = new List<BigInteger>();
            line.Add(1);

            for (int i = 0; i <= 100; i++)
            {
                total += line.Where(num => num == 0).ToList().Count;
                line = calculateNextLine(line);
            }


            Console.WriteLine("TOTAL: " + total);
        }

        public static List<BigInteger> calculateNextLine(List<BigInteger> previous)
        {
            int size = previous.Count;
            List<BigInteger> next = new List<BigInteger>(previous);
            next.Add(1);
            for (int i = 0; i < size-1; i++)
            {
                BigInteger value = 0;
                if (previous[i] == 0 || next[i + 1] == 0)
                {
                    value = 0;
                }
                else
                {
                    value = previous[i] + next[i + 1];
                    if (value > 1000000)
                    {
                        value = 0;
                    }
                }
                next[i + 1] = value;
                
                
            }
            //Console.WriteLine("-----------------------------------");
            //foreach (BigInteger num in next)
            //{
            //    Console.Write("" + num + " ");
            //}
            return next;
        }
    }
}
