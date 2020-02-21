using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EulerLibrary;

namespace ProjectEuler21
{
    class Program
    {
        static void Main(string[] args)
        {
            for (ulong i = 2; i < 10000; i++)
            {
                Console.Write(i + ": ");
                foreach (ulong d in Numbers.findDivisors(i))
                {
                    Console.Write(d + " ");
                }
                Console.WriteLine();
            }
        }
    }

    class AmicableNumber
    {
        ulong number;
        ulong partner;
        ulong sumOfDivisors;
        List<ulong> divisors;

        public AmicableNumber()
        {
            partner = 0;
            sumOfDivisors = 0;
            divisors = new List<ulong>();
        }

        public int numberOfDivisors
        {
            get { return divisors.Count; }
        }

        public void calculateDivisors()
        {
            divisors = Numbers.findDivisors(number);
        }
    }
}
