using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;

namespace ProjectEuler10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ulong> primes = Numbers.findPrimesBelow(2000000);
            

            ulong sum = 0;
            foreach (ulong prime in primes)
            {
                sum += prime;
            }

            Console.WriteLine(sum);

            Console.ReadKey(false);

        }
    }

    
}
