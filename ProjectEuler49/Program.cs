using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;

/*
 * The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: (i) each of the three terms are prime, and, (ii) each of the 4-digit numbers are permutations of one another.

There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.

What 12-digit number do you form by concatenating the three terms in this sequence?
 * 
 * THIS DOES NOT DETECT THE PERMUTATION, BUT THAT'S BECAUSE I'M LAZY AND DON'T WANT TO REWRITE CODE
 * ANSWER: 2969 6299 9629

 */
namespace ProjectEuler49
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> primes = Numbers.findPrimesBelowInt(10000);
            HashSet<int> primeHash = new HashSet<int>(primes);

            foreach (int prime in primes)
            {
                if (prime < 1000)
                {
                    continue;
                }
                int firstPrime = prime + 3330;

                if (primeHash.Contains(firstPrime) && Numbers.arePermutations(prime, firstPrime))
                {
                    int secondPrime = firstPrime + 3330;
                    if (primeHash.Contains(secondPrime) && Numbers.arePermutations(prime, secondPrime))
                    {
                        Console.WriteLine(prime + " " + firstPrime + " " + secondPrime);
                    }
                }
            }
        }
    }
}
