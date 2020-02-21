using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace ProjectEuler48
{
    /*The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.

      Find the last ten digits of the series, ^11 + 2^2 + 3^3 + ... + 1000^1000.

     */
    class Program
    {
        static BigInteger tenDigit = 10000000000;
        static void Main(string[] args)
        {
            object locking = new object();
            List<BigInteger> allnums = new List<BigInteger>();
            for (int i = 1; i <= 1000; i++)
            {
                allnums.Add(i);
            }

            BigInteger answer = 0;

            Parallel.ForEach(allnums, number => 
            {
                BigInteger value = power(number);
                lock (locking)
                {
                    answer += value;
                }
            });

            Console.WriteLine(answer%tenDigit);

        }

        static BigInteger power(BigInteger number)
        {
            BigInteger pow = 1;

            for (int i = 0; i < number; i++)
            {
                pow *= number;
                pow = pow % tenDigit;
            }

            return pow;
        }
    }
}
