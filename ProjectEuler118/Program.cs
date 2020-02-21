using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;

namespace ProjectEuler118
{
    class Program
    {
        private static List<int> primes;
        private static int primeCount;
        private static int big = 1000000000;
        
        static void Main(string[] args)
        {
            


            int maxPrime = big;
            //primes = Numbers.findPrimesBelowInt(100000);
            primes = Numbers.findPrimesBelowIntFAST(100000);
            primes.Remove(1);
            List<int> culledPrimes = new List<int>();
            foreach(int prime in primes)
            {
                if(noDuplicateDigits(prime))
                {
                    culledPrimes.Add(prime);
                }
            }

            primes = culledPrimes;

            Console.WriteLine("Getting Big Primes");
            primes.AddRange(getFiveToNineDigitPrimes());
            primes.Sort();
            primeCount = primes.Count;
            Console.WriteLine("STARTING SETS");

            int answer = accumulateSets(new HashSet<int>(), 0);
            Console.WriteLine("ANSWER: " + answer);

        }

        static int accumulateSets(HashSet<int> numberSet, int startingIndex)
        {
           
            if(startingIndex >= primeCount)
            {
                return 0;
            }
           

            
            int setsWithThisRoot = 0;
            int remainingNumberSize = 9 - getDigitHash(numberSet).Count;
            int tenpow = (int) Math.Pow(10, remainingNumberSize);
            for (int newStartingIndex = startingIndex; newStartingIndex < primeCount; newStartingIndex++)
            {
                if(primes[newStartingIndex] > tenpow)
                {
                    break;
                }
                

                if (canAddNumberToSetWithoutDuplicatingDigit(numberSet, primes[newStartingIndex]))
                {
                    HashSet<int> copyNumberSet = new HashSet<int>(numberSet);
                    copyNumberSet.Add(primes[newStartingIndex]);
                    if (isPandigital(copyNumberSet))
                    {
                        //foreach (int i in copyNumberSet)
                        //{
                        //    Console.Write(i + ", ");
                        //}
                        //Console.WriteLine();
                        setsWithThisRoot++;
                    }
                    else
                    {
                        setsWithThisRoot += accumulateSets(copyNumberSet, newStartingIndex + 1);
                    }
                }
            }

            return setsWithThisRoot;
        }

        static bool canAddNumberToSetWithoutDuplicatingDigit(HashSet<int> numberSet, int number)
        {
            HashSet<int> hash = new HashSet<int>();
            int n;
            
            foreach(int i in numberSet)
            {
                n = i;
                while(n > 0)
                {
                    if (n != 0)
                    {
                        hash.Add(n % 10);
                    }
                    
                    n /= 10;
                }
            }
            

            n = number;
            while(n > 0)
            {
                if(hash.Contains(n%10))
                {
                    return false;
                }
                n /= 10;
            }

            return true;
        }

        static bool canAddNumberToSetWithoutDuplicatingDigit(int originalNumber, int number)
        {
            HashSet<int> hash = new HashSet<int>();
            int n;


            n = originalNumber;
                while (n > 0)
                {
                    if (n != 0)
                    {
                        hash.Add(n % 10);
                    }

                    n /= 10;
                }
            


            n = number;
            while (n > 0)
            {
                if (hash.Contains(n % 10))
                {
                    return false;
                }
                n /= 10;
            }

            return true;
        }

        static bool isPandigital(HashSet<int> numberSet)
        {
           return getDigitHash(numberSet).Count == 9;
        }

        static bool noDuplicateDigits(int number)
        {
            HashSet<int> hash = new HashSet<int>();
            while(number > 0)
            {
                int n = number%10;
                number /= 10;
                if(n == 0)
                {
                    return false; //can't have a zero in the number
                }
                if(hash.Contains(n))
                {
                    return false;
                }
                hash.Add(n);
            }
            return true;
        }

        static HashSet<int> getDigitHash(HashSet<int> numbers)
        {
            HashSet<int> hash = new HashSet<int>();
            int n;
            foreach (int i in numbers)
            {
                n = i;
                while (n > 0)
                {
                    if (n == 0)
                    {
                        continue;
                    }
                    hash.Add(n % 10);
                    n /= 10;
                }
            }
            return hash;
        }

        static List<int> getFiveToNineDigitPrimes()
        {
            //100000
            //1000000000

            HashSet<int> validNumbers = new HashSet<int>();
            Stack<int> stack = new Stack<int>();
            for(int i = 1; i < 10; i++)
            {
                stack.Push(i);
            }

            while(stack.Count != 0)
            {
                int current = stack.Pop();
                for(int i = 1; i < 10; i++)
                {
                    if(canAddNumberToSetWithoutDuplicatingDigit(current,i))
                    {
                        int next = current*10 + i;
                        if(next > 99999999 && next < 10000000000)
                        {
                            continue;
                            //Console.WriteLine("BIG NUMBER: " + next);
                        }
                        if(next < 0)
                        {
                            throw new Exception("overflow");
                        }
                        if(next > 100000)
                        {
                            validNumbers.Add(next);
                        }
                        stack.Push(next);
                    }
                }
            }

            HashSet<int> hash = new HashSet<int>();
            foreach(int number in validNumbers)
            {
             
                if(Numbers.isPrime(number))
                {
                    hash.Add(number);
                }
            }

            List<int> bigPrimes = new List<int>(hash);
            bigPrimes.Sort();

            return bigPrimes;
        }



        public static int hashSetToInt(HashSet<int> hash)
        {
            List<int> list = new List<int>(hash);
            list.Sort();
            int result = 0;
            string s = "";
            foreach (int i in list)
            {
                s = s + i;
            }
            result = int.Parse(s);
            return result;
        }
    }
}
