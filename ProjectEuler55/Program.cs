using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace ProjectEuler55
{
    /*
     * If we take 47, reverse and add, 47 + 74 = 121, which is palindromic.

Not all numbers produce palindromes so quickly. For example,

349 + 943 = 1292,
1292 + 2921 = 4213
4213 + 3124 = 7337

That is, 349 took three iterations to arrive at a palindrome.

Although no one has proved it yet, it is thought that some numbers, like 196, never produce a palindrome. 
     * A number that never forms a palindrome through the reverse and add process is called a Lychrel number. 
     * Due to the theoretical nature of these numbers, and for the purpose of this problem, we shall assume that a number is Lychrel until proven otherwise. 
     * In addition you are given that for every number below ten-thousand, it will either 
     *      (i) become a palindrome in less than fifty iterations, or, 
     *      (ii) no one, with all the computing power that exists, has managed so far to map it to a palindrome. 
     * In fact, 10677 is the first number to be shown to require over fifty iterations before producing a palindrome: 4668731596684224866951378664 (53 iterations, 28-digits).

Surprisingly, there are palindromic numbers that are themselves Lychrel numbers; the first example is 4994.

How many Lychrel numbers are there below ten-thousand?
     */
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Lychrel> allNumbers = new LinkedList<Lychrel>();
            object locking = new object();
            int count = 0;

            for (int i = 1; i < 10000; i++)
            {
                allNumbers.AddLast(new Lychrel(i));
            }


           // Parallel.ForEach(allNumbers, L => 
            foreach(Lychrel L in allNumbers)
            {
                if (!L.isLycheral())
                {
                    lock (locking)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);

        }
    }

    class Lychrel
    {
        BigInteger baseNumber;
        BigInteger number;
        LinkedList<BigInteger> permutations;
        int itteration;

        public Lychrel(BigInteger num)
        {
            itteration = 0;
            number = num;
            baseNumber = num;
            permutations = new LinkedList<BigInteger>();
        }

        public bool isLycheral()
        {
            permutations.AddLast(number);
            number = number + reverseNumber();
            permutations.AddLast(number);
            itteration++;
            if (isPalendrome())
            {
                return true;
            }
            while (itteration < 51 && !isPalendrome())
            {
                number = number + reverseNumber();
                permutations.AddLast(number);
                itteration++;
                if (isPalendrome())
                {
                    return true;
                }
            }
            return false;
        }

        public bool isPalendrome()
        {
            string line = number.ToString();
            while (line.Length > 1)
            {
                if (line[0] != line[line.Length - 1])
                {
                    return false;
                }
                line = line.Substring(1, line.Length - 2);
            }
            return true;
        }

        public BigInteger reverseNumber()
        {
            string line = number.ToString();
            string reverse = "";
            foreach (char c in line)
            {
                reverse = c + reverse;
            }
            return BigInteger.Parse(reverse);
        }

        public override string ToString()
        {
            return baseNumber.ToString();
        }
            


    }
}
