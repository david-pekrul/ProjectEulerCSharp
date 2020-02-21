using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

//answer 8739992577
namespace ProjectEuler97
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = 1;
            for (int i = 1; i <= 7830457; i++)
            {
                number *= 2;
                number = getLastTenDigits(number);
            }

            number *= 28433;
            number = getLastTenDigits(number);
            number += 1;
            number = getLastTenDigits(number);
            Console.WriteLine(number);
        }

        static BigInteger getLastTenDigits(BigInteger x)
        {
            string str = x.ToString();
            if (str.Length <= 10)
            {
                return x;
            }

            str = str.Substring(str.Length - 10);
            return BigInteger.Parse(str);
        }
    }
}
