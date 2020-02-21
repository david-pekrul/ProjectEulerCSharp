using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;

namespace ProjectEuler111
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            List<ulong> primes = Numbers.findPrimesBelow(9999999999);
            Console.WriteLine(primes.Count);

            DateTime end = DateTime.Now;
            Console.WriteLine("TIME: " + (end - start).TotalMilliseconds);
        }
    }
}
