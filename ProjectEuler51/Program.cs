using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;
/*
 * By replacing the 1st digit of *3, it turns out that six of the nine possible values: 13, 23, 43, 53, 73, and 83, are all prime.

By replacing the 3rd and 4th digits of 56**3 with the same digit, this 5-digit number is the first example having seven primes among the ten generated numbers, yielding the family: 56003, 56113, 56333, 56443, 56663, 56773, and 56993. Consequently 56003, being the first member of this family, is the smallest prime with this property.

Find the smallest prime which, by replacing part of the number (not necessarily adjacent digits) with the same digit, is part of an eight prime value family.
 */
namespace ProjectEuler51
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            List<int> primes = Numbers.findPrimesBelowInt(1000000);
            DateTime start = DateTime.Now;
            
            HashSet<int> primesWithDoubleDigit = new HashSet<int>();
            
            foreach (int prime in primes)
            {
                if (hasTwoOfTheSameDigit(prime))
                {
                    //Console.WriteLine(prime);
                    primesWithDoubleDigit.Add(prime);
                    count++;
                }
            }

            HashSet<string> maskedNumbers = new HashSet<string>();
            foreach (int prime in primesWithDoubleDigit)
            {
                HashSet<string> result = maskDigits(prime);
                foreach (string r in result)
                {
                    maskedNumbers.Add(r);
                }
            }

            foreach (string eightMatch in maskedNumbers)
            {
                List<string> goodNumbers = new List<string>();
                int failCount = 0;
                for (int i = 0; i < 10; i++)
                {
                    string temp = eightMatch;
                    temp = temp.Replace('*', i.ToString()[0]);
                    int tempInt = Int32.Parse(temp);
                    if (!primesWithDoubleDigit.Contains(tempInt))
                    {
                        failCount++;
                    }
                    else
                    {
                        goodNumbers.Add(temp);
                    }
                    if (failCount == 3)
                    {
                        break;
                    }
                }
                if (failCount < 3)
                {
                    foreach (string s in goodNumbers)
                    {
                        Console.Write(s + ", ");
                    }
                    Console.WriteLine();
                }
            }

            DateTime end = DateTime.Now;

            Console.WriteLine("time: " + (end - start).TotalMilliseconds);
        }

        public static bool hasTwoOfTheSameDigit(int number)
        {
            string s = number.ToString();
            foreach (char c in s)
            {
                if (s.Count(a => a == c) > 1)
                {
                    return true;
                }
            }
            return false;
        }

        public static HashSet<string> maskDigits(int number)
        {
            string str = number.ToString();
            int length = str.Length;
            Stack<string> stack = new Stack<string>();
            stack.Push("");
            HashSet<string> result = new HashSet<string>();
            while (stack.Count != 0)
            {
                string temp = stack.Pop();
                int l = temp.Length;
                if (l == length)
                {
                    if (!(temp.Count(c => c == '*') == length) && temp.Contains('*'))
                    {
                        result.Add(temp);
                    }
                }
                else 
                {
                    char nextChar = str[l];
                    stack.Push(temp + nextChar);
                    stack.Push(temp + '*');
                }
            }

            return result;
        }

        public static bool numberFitsMask(int number, string mask)
        {
            string nString = number.ToString();
            int nl = nString.Length;
            int ml = mask.Length;
            if (ml != nl)
            {
                return false;
            }

            for (int i = 0; i < ml; i++)
            {
                if (mask[i] != '*' && mask[i] != nString[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
