﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace ProjectEuler29
{
    class Program
    {
        /*
         * How many distinct terms are in the sequence generated by a^b for 2 ≤ a ≤ 100 and 2 ≤ b ≤ 100?
         */
        static void Main(string[] args)
        {
            HashSet<BigInteger> powers = new HashSet<BigInteger>();
            for (BigInteger a = 2; a <= 100; a++)
            {
                BigInteger number = a;
                for (BigInteger b = 2; b <= 100; b++)
                {
                    number *= a;
                    powers.Add(number);
                }
            }

            Console.WriteLine(powers.Count);
        }
    }
}