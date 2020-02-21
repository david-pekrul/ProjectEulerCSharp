using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace ProjectEuler56
{
    /*
     * A googol (10100) is a massive number: one followed by one-hundred zeros; 100100 is almost unimaginably large: one followed by two-hundred zeros. Despite their size, the sum of the digits in each number is only 1.

Considering natural numbers of the form, ab, where a, b < 100, what is the maximum digital sum?

     */
    class Program
    {
        static void Main(string[] args)
        {
            List<NumberCollection> allNumbers = new List<NumberCollection>();
            object locking = new object();
            BigInteger maxValue = 0;

            for (int a = 2; a < 100; a++)
            {
                allNumbers.Add(new NumberCollection(a));
            }

            Parallel.ForEach(allNumbers, n =>
                {
                    BigInteger temp = n.findAllPowers();
                    lock (locking)
                    {
                        if (temp > maxValue)
                        {
                            maxValue = temp;
                        }
                    }
                });

            Console.WriteLine("Max Value: " + maxValue);
            

        }
    }

    class NumberCollection
    {
        BigInteger baseNumber;
        public BigInteger maxSum;
        public NumberCollection(BigInteger number)
        {
            baseNumber = number;
            maxSum = 0;
        }

        public void calculateDigitalSum(BigInteger number)
        {
            string line = number.ToString();
            BigInteger tempSum = 0;
            foreach (char c in line)
            {
                tempSum += Int32.Parse(c.ToString());
            }
            if(tempSum > maxSum)
            {
                maxSum = tempSum;
            }
        }

        public BigInteger findAllPowers()
        {
            BigInteger tempNumber = 1;
            for (int b = 1; b < 100; b++)
            {
                tempNumber *= baseNumber;
                calculateDigitalSum(tempNumber);
            }
            return maxSum;
        }
    }
}
