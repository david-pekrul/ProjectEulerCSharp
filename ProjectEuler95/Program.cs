using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;

namespace ProjectEuler95
{
    class Program
    {
        private static List<int> primes = Numbers.findPrimesBelowInt(1000000);
        private static Dictionary<int, int> numberToSumOfDivisors = new Dictionary<int, int>();
        private static Dictionary<int, HashSet<int>> numberToChainLength = new Dictionary<int, HashSet<int>>();
        private static readonly int million = 1000000;
        private static List<FactorTree> factorTrees;


        static void Main(string[] args)
        {
            factorTrees = Numbers.createFactorTree(million);
            int testNumber = 12496;
            Console.WriteLine(factorTrees[testNumber - 2].rootValue());
            foreach (int i in factorTrees[testNumber - 2].getPrimeFactors())
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("HERE: " + getSumOfDivisors(testNumber));


            int minimumStartingNumber = 0;
            int minimumContainedNumber = 0;
            HashSet<int> maxChain = new HashSet<int>();
            for (int i = 2; i < million; i++)
            {
                if(i == 12496)
                {
                    Console.WriteLine("HERE!");
                }
                Tuple<bool, HashSet<int>> value = getChainLengthForStartingNumber(i);
                if (value.Item1 &&  value.Item2.Count > maxChain.Count)
                {
                    Console.WriteLine(i);
                    maxChain = value.Item2;
                    minimumStartingNumber = i;
                    minimumContainedNumber = value.Item2.Min();
                }
            }
            Console.WriteLine("ANSWER: " + minimumContainedNumber);

        }

        public static Tuple<bool,HashSet<int>> getChainLengthForStartingNumber(int number)
        {
           

            HashSet<int> usedNumbers = new HashSet<int>() { number };
            int nextNumber = getSumOfDivisors(number);
            while (!usedNumbers.Contains(nextNumber))
            {
                if (nextNumber > million)
                {
                    return new Tuple<bool, HashSet<int>>(false, usedNumbers);
                }
                usedNumbers.Add(nextNumber);
                nextNumber = getSumOfDivisors(nextNumber);
            }

            numberToChainLength.Add(number, usedNumbers);
            return new Tuple<bool, HashSet<int>>((nextNumber == number),usedNumbers);
        }

        public static int getSumOfDivisors(int number)
        {
            if (numberToSumOfDivisors.ContainsKey(number))
            {
                return numberToSumOfDivisors[number];
            }
            if(number == 1)
            {
                return 1;
            }

            int sumOfDivisors = 1;

            FactorTree tree = factorTrees[number - 2];
            
            Dictionary<int, int> primeToCount = new Dictionary<int, int>();
            foreach(int p in tree.getPrimeFactors())
            {
                if(p == 1)
                {
                    continue;
                }
                if(primeToCount.ContainsKey(p))
                {
                    primeToCount[p]++;
                }    
                else
                {
                    primeToCount.Add(p, 1);
                }
            }

            foreach(KeyValuePair<int, int> x in primeToCount)
            {
                int value = (int) ((Math.Pow(x.Key, x.Value + 1) - 1)/(x.Key - 1));
                sumOfDivisors *= value;
            }

            sumOfDivisors -= number;

            numberToSumOfDivisors.Add(number, sumOfDivisors);
            return sumOfDivisors;
        }

        //public static HashSet<int> getDivisors(int number)
        //{
        //    HashSet<int> divisors = new HashSet<int>(){1};
        //    int numbercopy = number;
        //    foreach (int prime in primes)
        //    {
        //        if (numbercopy % prime == 0)
        //        {
        //            divisors.Add(prime);
        //            int product = 2 * prime;
        //            while (product <= numbercopy / 2)
        //            {
        //                if (numbercopy % product == 0)
        //                {
        //                    divisors.Add(product);
        //                }
        //                product += prime;
        //            }
        //            numbercopy /= prime;
        //        }
        //    }

        //    return divisors;
        //}



    }
}