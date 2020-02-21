using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;


namespace ProjectEuler134
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ulong> primes = new List<ulong>();
            Numbers.findPrimesBelowIntFAST(1000100).ForEach(a => primes.Add((ulong)a));

            ulong total = 0;
            for(int i = 0; i < primes.Count; i++)
            {
                ulong p1 = primes[i];
                if (p1 < 5){continue;}
                if(p1 > 1000000)
                {
                    break;
                }
                total += findNumber(p1, primes[i + 1]);
            }
            Console.WriteLine("ANSWER: " + total);
        }

        /// <summary>
        /// Find a number that ends with p1 and that is divisible by p2
        /// </summary>
        /// <param name="p1">prime 1</param>
        /// <param name="p2">prime 2</param>
        /// <returns></returns>
        static ulong findNumber(ulong p1, ulong p2)
        {
            ulong ooM = orderOfMagnitude(p1);
            ulong multiplierOrderOfMagnitude = 0;
            ulong multiplier = 0;

            while ((p2 * multiplier) % ooM != p1)
            {
                ulong incrementer = (ulong) Math.Pow(10, multiplierOrderOfMagnitude);
                ulong mod = incrementer*10;
                for (ulong i = 0; i < 10; i++)
                {
                    multiplier += incrementer;
                    if((p2 * multiplier) % mod == p1 % mod)
                    {
                        break;
                    }
                }
                multiplierOrderOfMagnitude++;
            }
            return p2*multiplier;
        }

        static ulong orderOfMagnitude(ulong n)
        {
            return (ulong)Math.Pow(10,(int)Math.Floor(Math.Log10(n))+1);
        }
    }
}