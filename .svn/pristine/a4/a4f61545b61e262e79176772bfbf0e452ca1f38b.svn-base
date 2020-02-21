using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler20
{
    /*
n! means n × (n − 1) × ... × 3 × 2 × 1

For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Find the sum of the digits in the number 100!

     */
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= 100; i++)
            {
                factorial *= i;
                if (factorial % 10 == 0)
                {
                    factorial /= 10;
                }
            }

            BigInteger sum = 0;
            foreach (char c in factorial.ToString())
            {
                sum += Int32.Parse(c.ToString());
            }

            Console.WriteLine(sum);
        }
    }
}
