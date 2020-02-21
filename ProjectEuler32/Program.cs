using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler32
{
    /*We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.

The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.

Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.

     */
    class Program
    {

        static void Main(string[] args)
        {
            int lengthEye = 0;
            bool check = new NumberSet(39, 186).isPandigital();
            HashSet<BigInteger> goodNumbers = new HashSet<BigInteger>();
            for (int i = 1; i < 200000; i++)
            {
                lengthEye = i.ToString().Length;
                for (int j = i; j < 200000; j++)
                {
                    int lengthJay = j.ToString().Length;
                    if (lengthEye + lengthJay > 5)
                    {
                        break;
                    }
                    NumberSet temp = new NumberSet(i, j);
                    if (temp.isPandigital())
                    {
                        goodNumbers.Add(temp.product);
                    }
                }
            }
            List<BigInteger> sorted = goodNumbers.ToList();
            sorted.Sort();
            BigInteger total = 0;
            foreach (BigInteger num in sorted)
            {
                total += num;
                Console.WriteLine(num);
            }

            Console.WriteLine("\n\nTotal: " + total);

        }
    }
    

    class NumberSet
    {
        static List<char> allDigits = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        BigInteger mult1;
        BigInteger mult2;
        public BigInteger product;

        public NumberSet(BigInteger m1, BigInteger m2)
        {
            mult1 = m1;
            mult2 = m2;
            product = m1 * m2;
        }

        public bool isPandigital()
        {
            string line = "" + mult1 + mult2 + product;
            if (line.Length != 9)
            {
                return false;
            }
            foreach (char c in allDigits)
            {
                if (!line.Contains(c))
                {
                    return false;
                    
                }
            }

            Console.WriteLine("M1: " + mult1 + "\tM2: " + mult2 + "\tProd: " + product);
            return true;
        }

        public override int GetHashCode()
        {
            return (int)product;
        }


    }


}
