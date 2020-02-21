using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

using EulerLibrary;
/*
 * 
Euler published the remarkable quadratic formula:

n² + n + 41

It turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. However, when n = 40, 402 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, 
 * and certainly when n = 41, 41² + 41 + 41 is clearly divisible by 41.

Using computers, the incredible formula  n² − 79n + 1601 was discovered, 
 * which produces 80 primes for the consecutive values n = 0 to 79. 
 * The product of the coefficients, −79 and 1601, is −126479.

Considering quadratics of the form:

    n² + an + b, where |a| < 1000 and |b| < 1000

    where |n| is the modulus/absolute value of n
    e.g. |11| = 11 and |−4| = 4

Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.

 */
namespace ProjectEuler27
{
    class Program
    {
        public static List<ulong> primes = Numbers.findPrimesBelow(2000000);

        public static void Main(string[] args)
        {
            object locking = new object();
            List<Quadratic> allQuadratics = new List<Quadratic>();
            int maxLength = 0;
            Quadratic maxQuad = null;

            for (int a = -999; a < 1000; a++)
            {
                foreach (BigInteger prime in primes)
                {
                    if (prime < 1000)
                    {
                        allQuadratics.Add(new Quadratic(a, (int)prime));
                    }
                }
                //for (int b = 1; b < 1000; b++)//b can't be negative; If b was negative then n=0 would never be prime.
                //{
                //    allQuadratics.Add(new Quadratic(a,b));
                //}
            }

            Parallel.ForEach(allQuadratics, q =>
            {
                int theLength = q.findNumberOfConsecutivePrimes();
                if(theLength > maxLength)
                {
                    lock (locking)
                    {
                        if(theLength > maxLength)
                        {
                            Console.WriteLine(maxLength);
                            maxLength = theLength;
                            maxQuad = q;
                        }
                    }
                }
            });

            Console.WriteLine("max = " + maxLength);
            Console.WriteLine("a * b" + maxQuad.AtimesB());
            

        }
    }

    class Quadratic
    {
        int a;
        int b;
        int numberOfConsecutivePrimes;

        public Quadratic(int aValue, int bValue)
        {
            a = aValue;
            b = bValue;
            numberOfConsecutivePrimes = 0;
        }

        public int findNumberOfConsecutivePrimes()
        {
            for (int n = 0; n < 1000; n++)
            {
                int value = 0;
                value = n * n;
                value += n * a;
                value += b;
                if (value <= 0 || !Program.primes.Contains((ulong)value))
                {
                    break;
                }
                numberOfConsecutivePrimes++;
            }

            return numberOfConsecutivePrimes;
        }

        public int AtimesB()
        {
            return a*b;
        }
    }
}
