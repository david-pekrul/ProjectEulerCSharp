using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEuler36
{
    /*
     * The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.

Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

(Please note that the palindromic number, in either base, may not include leading zeros.)

     */
    class Program
    {
        static void Main(string[] args)
        {
            List<NumberPair> numbers = new List<NumberPair>();
            for (int i = 1; i < 1000000; i++)
            {
                numbers.Add(new NumberPair(i));
            }

            numbers = numbers.Where(n => n.isBaseTenAPalendrome()).ToList();

            Parallel.ForEach(numbers, n => n.calculateBinaryNumber());

            numbers = numbers.Where(n => n.isBinaryAPalendrome()).ToList();

            int total = 0;
            foreach (NumberPair np in numbers)
            {
                total += np.baseTenNumber;
            }

            Console.WriteLine("Total: " + total);


            
        }
    }

    class NumberPair
    {
        public int baseTenNumber;
        public string binaryNumber;

        public NumberPair(int number)
        {
            baseTenNumber = number;
            binaryNumber = "";
        }

        public void calculateBinaryNumber()
        {
            int temp = baseTenNumber;
            while (temp != 0)
            {
                if (temp % 2 == 0)
                {
                    binaryNumber = "0" + binaryNumber;
                }
                else
                {
                    binaryNumber = "1" + binaryNumber;
                }
                temp /= 2;
            }
        }

        public bool isBaseTenAPalendrome()
        {
            string line = baseTenNumber.ToString();
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

        public bool isBinaryAPalendrome()
        {
            string line = binaryNumber;
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

    }
}
