using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using EulerLibrary;
using System.Threading.Tasks;

/*
 * The primes 3, 7, 109, and 673, are quite remarkable. By taking any two primes and concatenating them in any order the result will always be prime. 
 * For example, taking 7 and 109, both 7109 and 1097 are prime. The sum of these four primes, 792, represents the lowest sum for a set of four primes with this property.
 * Find the lowest sum for a set of five primes for which any two primes concatenate to produce another prime.
 */
//ANSWERS: 13 5197 5701 6733 8389 => SUM
namespace ProjectEuler60
{
    class Program
    {
        private static HashSet<string> primeHash;
        static void Main(string[] args)
        {
            List<BigInteger> primes = Numbers.findPrimesBelowBigInt(83896734);
            primes.Remove(2);
            Console.WriteLine("Done finding primes");
            primeHash = new HashSet<string>();
            foreach (int p in primes)
            {
                primeHash.Add(p.ToString());
            }


            //primes = validPrimes(primes);
            //Console.WriteLine("Done pruning primes");

            primes = primes.Where(x => x.ToString().Length < 5).ToList();
            
            
            int maxIndex = primes.Count;

            //find good value between index 0 and index 1
            for (int a = 0; a < maxIndex; a++)
            {
                for (int b = a + 1; b < maxIndex; b++)
                {
                    if (twoPrimesWork(primes[a], primes[b]))
                    {
                        Console.WriteLine(primes[a] + " " + primes[b]);
                        for (int c = b + 1; c < maxIndex; c++)
                        {
                            if (twoPrimesWork(primes[a], primes[c]))
                            {
                                if (twoPrimesWork(primes[b], primes[c]))
                                {
                                    Console.WriteLine(primes[a] + " " + primes[b] + " " + primes[c]);
                                    for (int d = c + 1; d < maxIndex; d++)
                                    {
                                        if (twoPrimesWork(primes[a], primes[d]))
                                        {
                                            if (twoPrimesWork(primes[b], primes[d]))
                                            {
                                                if (twoPrimesWork(primes[c], primes[d]))
                                                {
                                                    Console.WriteLine(primes[a] + " " + primes[b] +
                                                                                          " " +
                                                                                          primes[c] +
                                                                                          " " + primes[d]);
                                                    for (int e = d + 1; e < maxIndex; e++)
                                                    {
                                                        if (twoPrimesWork(primes[e], primes[a])) 
                                                        {
                                                            if (twoPrimesWork(primes[e], primes[b]))
                                                            {
                                                                if (twoPrimesWork(primes[e], primes[c]))
                                                                {
                                                                    if (twoPrimesWork(primes[e], primes[d]))
                                                                    {
                                                                        Console.WriteLine(primes[a] + " " + primes[b] +
                                                                                          " " +
                                                                                          primes[c] +
                                                                                          " " + primes[d] + " " +
                                                                                          primes[e]);
                                                                        BigInteger sum = primes[a] + primes[b] +

                                                                                         primes[c] +
                                                                                         primes[d] +
                                                                                         primes[e];
                                                                        Console.WriteLine("ANSWER: " + sum);
                                                                        return;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        public static List<BigInteger> validPrimes(List<BigInteger> primes)
        {
            List<BigInteger> valid = new List<BigInteger>();
            List<string> primeStrings = new List<string>();
            foreach(BigInteger prime in primes)
            {
                primeStrings.Add(prime.ToString());
            }
            int longestPrimeLength = primes[primes.Count - 1].ToString().Length;
            Parallel.ForEach(primes, prime =>
                                         {
                                             string pS = prime.ToString();
                                             int minLength = pS.Length;
                                             if (minLength == longestPrimeLength)
                                             {
                                                 return;
                                             }
                                             foreach (string str in primeStrings)
                                             {
                                                 if (intAtBeginningOrEnd(pS, str))
                                                 {
                                                     lock (valid)
                                                     {
                                                         valid.Add(prime);
                                                     }
                                                     return;
                                                 }
                                             }
                                         });
            //foreach(int prime in primes)
            //{
            //    if(prime.ToString().Length == longestPrimeLength)
            //    {
            //        break;
            //    }
            //    foreach(string str in primeStrings)
            //    {
            //        if(intAtBeginningOrEnd(prime,str))
            //        {
            //            valid.Add(prime);
            //            break;
            //        }
            //    }
            //}

            return valid;
        }

        public static bool intAtBeginningOrEnd(string pS, string str)
        {
            if(pS.Length >= str.Length)
            {
                return false;
            }
            if (pS[0] == str[0] || pS[pS.Length - 1] == str[str.Length - 1])
            {
                if (str.Substring(0, pS.Length) == pS || str.Substring(str.Length - pS.Length) == pS)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool twoPrimesWork(BigInteger a, BigInteger b)
        {
            string temp = "" + a + "" + b;
            if(primeHash.Contains(temp))
            {
                temp = "" + b + "" + a;
                if(primeHash.Contains(temp))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
