using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

using EulerLibrary;

namespace ProjectEuler47
{
    /*
     *The first two consecutive numbers to have two distinct prime factors are:

14 = 2 × 7
15 = 3 × 5

The first three consecutive numbers to have three distinct prime factors are:

644 = 2² × 7 × 23
645 = 3 × 5 × 43
646 = 2 × 17 × 19.

Find the first four consecutive integers to have four distinct primes factors. What is the first of these numbers?
*/
    class Program
    {
        static void Main(string[] args)
        {
            Numbers.primes = Numbers.findPrimesBelow(1000000);
            List<BigInteger> goodList = new List<BigInteger>();
            int count = 0;
            
            BigInteger starting = 0;
            for (BigInteger i = 2; i < 1000000; i++)
            {
                List<BigInteger> factors = Numbers.findPrimeFactorsBigInt(i);
                factors.Remove(1);
                if (factors.Count == 4)
                {
                    //Console.WriteLine(i);
                    if (goodList.Contains(i - 1))
                    {
                        goodList.Add(i);
                        Console.WriteLine("___" + i + "\t\t" + count++);
                    }
                    else
                    {
                        count = 1;
                        goodList.Clear();
                        goodList.Add(i);
                        Console.WriteLine("___" + i);
                    }

                    if (goodList.Count == 4)
                    {
                        foreach (BigInteger bi in goodList)
                        {
                            Console.WriteLine(bi);
                            foreach (BigInteger factor in Numbers.findPrimeFactorsBigInt(bi))
                            {
                                Console.WriteLine("\t" + factor);
                            }
                        }
                        Console.WriteLine("------");
                        break;
                    }
                }
            }

            foreach (BigInteger i in goodList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("done");
        }
    }
}
