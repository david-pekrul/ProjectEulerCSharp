using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;
using System.Numerics;

namespace ProjectEuler58
{
    /*
Starting with 1 and spiralling anticlockwise in the following way, a square spiral with side length 7 is formed.

37 36 35 34 33 32 31
38 17 16 15 14 13 30
39 18  5  4  3 12 29
40 19  6  1  2 11 28
41 20  7  8  9 10 27
42 21 22 23 24 25 26
43 44 45 46 47 48 49

It is interesting to note that the odd squares lie along the bottom right diagonal, but what is more interesting 
is that 8 out of the 13 numbers lying along both diagonals are prime; that is, a ratio of 8/13 ≈ 62%.

If one complete new layer is wrapped around the spiral above, a square spiral with side length 9 will be formed. 
If this process is continued, what is the side length of the square spiral for which the ratio of primes 
along both diagonals first falls below 10%?

     */
    class Program
    {
        static void Main(string[] args)
        {
            //                                                      688590081
            //The largest number you need to check if it is prime or not is 688590081
            List<BigInteger> primes = Numbers.findPrimesBelowBigInt(688590082);
            
            HashSet<BigInteger> primesHash = new HashSet<BigInteger>(primes);
            BigInteger largestPrime = primes[primes.Count - 1];
            Console.WriteLine("Largest Prime: " + largestPrime);
            Console.WriteLine("Done calculating primes.");
            BigInteger atNumber = 1;
            int numberToSkip = 2;
            int primesFound = 0;

            for (int layer = 1; layer < 14000; layer++)
            {
                for(int i = 0; i < 4; i++)
                {
                    atNumber += numberToSkip;
                    
                    Console.Write(atNumber + " ");
                    if(primesHash.Contains(atNumber))
                    {
                        primesFound++;
                    }
                    else
                    {
                        if(atNumber > largestPrime)
                        {
                            Console.WriteLine("TOO FUCKING BIG! " + atNumber);
                            throw new Exception("out of range");
                        }
                    }
                }
                numberToSkip += 2;
                //Console.WriteLine();
                int countInDiagonals = 4*layer + 1;
                

                if(10*primesFound < countInDiagonals)
                {
                    Console.WriteLine("SideLength: " + (layer*2+1));
                    break;
                }
                //else
                //{
                //    double t1 = primesFound;
                //    double t2 = countInDiagonals;
                //    //Console.WriteLine("" + t1 + "/" + t2 + " = \t" + (t1/t2) + "\tLayer: " + layer + "\tSideLength: " + (layer*2+1));
                //}

            }

            
        }
    }
}
