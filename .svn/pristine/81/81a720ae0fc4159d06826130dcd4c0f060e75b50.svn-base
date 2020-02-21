using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EulerLibrary;

namespace ProjectEuler35
{
    class Program
    {
        static HashSet<string> stringPrimes = new HashSet<string>();
        static void Main(string[] args)
        {
            List<ulong> primes = Numbers.findPrimesBelow(1000000);
            
            foreach (ulong prime in primes)
            {
                stringPrimes.Add(prime.ToString());
            }

            int numberOfCircularPrimes = 0;
            foreach(string prime in stringPrimes)
            {
                if (isCircularPrime(prime))
                {
                    numberOfCircularPrimes++;
                }
            }

            Console.WriteLine(numberOfCircularPrimes);
        }

        static bool isCircularPrime(string prime)
        {
            int length = prime.Length;
            for (int i = 0; i < length; i++)
            {
                if (!stringPrimes.Contains(prime))
                {
                    return false;
                }
                prime = rotateString(prime);
            }
            return true;
        }

        static string rotateString(string input)
        {
            return input.Substring(1) + input[0];
        }
    }
}
