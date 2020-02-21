using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace ProjectEuler34
{
    /*
     * 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.

Find the sum of all numbers which are equal to the sum of the factorial of their digits.

Note: as 1! = 1 and 2! = 2 are not sums they are not included.

     */

    class Program
    {
        static List<BigInteger> factorials = new List<BigInteger>();
        static void Main(string[] args)
        {
            object locking = new object();
            for (BigInteger i = 0; i < 10; i++)
            {
                factorials.Add(factorial(i));
            }
            List<BigInteger> allNumbers = new List<BigInteger>();
            for (BigInteger i = 3; i < 1000000; i++)
            {
                allNumbers.Add(i);
            }

            BigInteger answer = 0;

            Parallel.ForEach(allNumbers, number =>
                {
                    BigInteger value = sumOfDigitPowers(number);
                    if (value == number)
                    {
                        lock (locking)
                        {
                            answer += number;
                        }
                    }
                });

            Console.WriteLine(answer);

        }

        static BigInteger sumOfDigitPowers(BigInteger number)
        {
            BigInteger value = 0;
            foreach (char c in number.ToString())
            {
                int index = Int32.Parse(c.ToString());
                value += factorials[index];
            }
            return value;
        }

        static BigInteger factorial(BigInteger number)
        {
            BigInteger fact = 1;
            BigInteger numberCopy = number;
            for (BigInteger i = 0; i < number; i++)
            {
                fact *= numberCopy;
                numberCopy--;
            }

            return fact;
        }
    }
}

