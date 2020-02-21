using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using EulerLibrary;

/*
 * The prime 41, can be written as the sum of six consecutive primes:
41 = 2 + 3 + 5 + 7 + 11 + 13

This is the longest sum of consecutive primes that adds to a prime below one-hundred.

The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.

Which prime, below one-million, can be written as the sum of the most consecutive primes?

 */
namespace ProjectEuler50
{
    class Program
    {
        public static List<int> primes;
        public static int[,] sumOfPrimes;

        static void Main(string[] args)
        {
            //primes = Numbers.findPrimesBelowInt(1000000);
            primes = Numbers.findPrimesBelowInt(100);
            int primeSize = primes.Count;
            int longestChain = 0;
            int bestPrime = 0;
            //primes.Reverse();

            List<BigInteger> remainingCount = new List<BigInteger>();
            BigInteger totalSum = 0;

            for (int i = 0; i < primeSize; i++)
            {
                totalSum += primes[i];
                remainingCount.Add(totalSum);
            }
            Dictionary<int, int> primeToLength = new Dictionary<int, int>();

            for (int i = 0; i < primeSize; i++)
            {
                int prime = primes[i];
                bool doneWithPrime = false;
                int length = 0;
                for(int j = i; j >= 0; j--)
                {
                    
                }
            }

            Console.WriteLine(bestPrime);
        }
    }

}
