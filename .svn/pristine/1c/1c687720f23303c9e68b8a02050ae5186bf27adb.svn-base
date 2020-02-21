using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using EulerLibrary;
using System.Threading.Tasks;

namespace ProjectEuler37
{
    /*
     * 
     * The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. 
     * Similarly we can work from right to left: 3797, 379, 37, and 3.

     * Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

     * NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.

     */
    class Program
    {
        public static List<BigInteger> primes = Numbers.findPrimesBelowBigInt(1000000);
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            //Console.WriteLine(primes[primes.Count - 1]);
            List<BigInteger> truncatablePrimes = new List<BigInteger>();
            object locking = new object();
            //foreach (BigInteger prime in primes)
            Parallel.ForEach(primes, prime =>
            {
                if (prime > 10)
                {
                    TruncNumber tn = new TruncNumber(prime);
                    if (tn.isTruncatable())
                    {
                        lock (locking)
                        {
                            truncatablePrimes.Add(prime);
                            Console.WriteLine(prime);
                        }
                    }
                }
            });
            BigInteger sum = 0;
            foreach (BigInteger goodNumber in truncatablePrimes)
            {
                Console.WriteLine("Good: " + goodNumber);
                sum += goodNumber;
            }

            Console.WriteLine(sum);

        }
    }

    class TruncNumber
    {
        static List<char> badDigits = new List<char>() { '4', '6', '8'};
        BigInteger number;
        public TruncNumber(BigInteger num)
        {
            number = num;
        }

        public bool isTruncatable()
        {
            //Console.WriteLine(number);
            string dropFirst = number.ToString();
            //simple test to tell if it will fail later on at some intermediate step.
            foreach (char c in badDigits)
            {
                if(dropFirst.Contains(c))
                {
                    return false;
                }
            }
            BigInteger temp = 0;
            //drop the first digit (Most significant digit)
            while (dropFirst.Length != 1)
            {
                dropFirst = dropFirst.Substring(1);
                //Console.WriteLine("\t" + dropFirst);
                temp = BigInteger.Parse(dropFirst);
                if (!Program.primes.Contains(temp))
                {
                    return false;
                }
            }
            if (!Program.primes.Contains(BigInteger.Parse(dropFirst)))
            {
                return false;
            }


            //Console.WriteLine("\t--");
            
            string dropLast = number.ToString();

            while (dropLast.Length != 1)
            {
                dropLast = dropLast.Substring(0,dropLast.Length -1);
                //Console.WriteLine("\t" + dropLast);
                temp = BigInteger.Parse(dropLast);
                if (!Program.primes.Contains(temp))
                {
                    return false;
                }
            }
            if (!Program.primes.Contains(BigInteger.Parse(dropLast)))
            {
                return false;
            }
            
            return true;
        }
    }
}
