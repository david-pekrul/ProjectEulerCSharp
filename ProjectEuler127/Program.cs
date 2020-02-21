using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;
namespace ProjectEuler127
{
    class Program
    {
        static void Main(string[] args)
        {
            EulerLibrary.Numbers.prepareStaticPrimeList(12000);
            for(int i = 4; i < 12000; i++)
            {
                Console.WriteLine(i);
                List<ulong> primes = Numbers.findPrimeFactors((ulong) i);
                primes.RemoveAt(0);
                if(primes.Count != 3)
                {
                    continue;
                }
            }
        }

        private static bool aPlusBEqualC(ulong a, ulong b, ulong c)
        {
            return a + b == c;
        }

        private static bool rad(ulong a, ulong b, ulong c)
        {
            return a*b*c < c;
        }
    }
}
