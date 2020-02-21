using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;

using EulerLibrary;

namespace ProjectEuler12
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Lowest;
            //List<BigInteger> triOne = Numbers.getTriangularNumbersBigInt(100);
            //foreach (ulong num in triOne)
            //{
            //    Console.WriteLine(num);
            //}
            //ulong number = 85;
            DateTime start = DateTime.Now;
            List<BigInteger> allNumbers = new List<BigInteger>();
            for (BigInteger i = 1; i < 1000000; i++)
            {
                allNumbers.Add(i);
            }

            List<BigInteger> triangularNumbers = Numbers.getTriangularNumbersBigInt(100000000);

            Parallel.ForEach(triangularNumbers, number =>
            {
                //foreach(BigInteger number in allNumbers)
                //{
                //List<ulong> thing = Numbers.findDivisors(number);

                //foreach (ulong num in thing)
                //{
                //    Console.Write(num + " ");
                //}
                //Console.Write(" | \t\t\t" + thing.Count);
                // Console.Write("--");
                BigInteger count = Numbers.findNumberOfPrimeFactorsExcludingOne(number);
                if (count > 500)
                {
                    Console.WriteLine(number + "\t" + count);
                }
                //Console.WriteLine(number + "\t" + Numbers.findNumberOfPrimeFactorsExcludingOne(number));
            });
            Console.WriteLine("Time: " + (DateTime.Now - start).TotalSeconds);
        }
    }
}
