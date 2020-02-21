using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using EulerLibrary;

namespace ProjectEuler41
{
    /*
     * We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is also prime.
     * What is the largest n-digit pandigital prime that exists?

     */
    class Program
    {
        static List<char> digits = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static void Main(string[] args)
        {
            List<BigInteger> primes = Numbers.findPrimesBelowBigInt(10000000);
            Console.WriteLine("Primes calculated");
            BigInteger maxPandigital = 0;
            foreach (BigInteger prime in primes)
            {
                if (isNPandigital(prime))
                {
                    maxPandigital = prime;
                    Console.WriteLine(maxPandigital);
                }
            }



        }

        public static bool isNPandigital(BigInteger number)
        {
            string line = number.ToString();
            int size = line.Length;

            for (int i = 1; i <= size; i++)
            {
                char c = i.ToString()[0];
                if (!line.Contains(c))
                {   
                    return false;
                }
            }

            return true;
        }
    }
}
