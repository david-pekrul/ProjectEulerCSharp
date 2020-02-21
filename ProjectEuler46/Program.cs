using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;

/*
 * It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.

9 = 7 + 2×12
15 = 7 + 2×22
21 = 3 + 2×32
25 = 7 + 2×32
27 = 19 + 2×22
33 = 31 + 2×12

It turns out that the conjecture was false.

What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?

 */
namespace ProjectEuler46
{
    class Program
    {
        private static List<ulong> primes;
        private static List<ulong> twiceSquares;
        static void Main(string[] args)
        {
            primes = Numbers.findPrimesBelow(10000);

            twiceSquares = new List<ulong>();
            for (ulong i = 1; i < 10000; i++)
            {
                twiceSquares.Add(2* i * i);
            }

            ulong firstEvenNumberThatCantBeMade = 4;
            for (ulong i = 3; i < 10000; i += 2)
            {
                if(primes.Contains(i))
                {
                    continue;
                }
                if(!findNumbers(i))
                {
                    Console.WriteLine("Answer " + i);
                    break;
                }

            }
        }
        
        public static bool findNumbers(ulong composite)
        {
            foreach(ulong prime in primes)
            {
                if(prime > composite)
                {
                    return false;
                }
                foreach(ulong twiceSquare in twiceSquares)
                {
                    if(twiceSquare > composite)
                    {
                        break;
                    }
                    if (twiceSquare + prime == composite)
                    {
                        //Console.WriteLine(composite + " = " + prime + "+" + twiceSquare);
                        return true;
                    }
                    
                }
            }
            return false;
        }
    }
}
