using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EulerLibrary;

namespace ProjectEuler23
{
    class Program
    {
        private const ulong maxValue = 28124;
        static void Main(string[] args)
        {
            List<ulong> abundantNumbers = new List<ulong>();
            HashSet<ulong> numbers = new HashSet<ulong>();
            for (ulong x = 1; x < maxValue; x++)
            {
                numbers.Add(x);
            }
            Parallel.ForEach(numbers, x =>
                                          {
                                              List<ulong> divisors = Numbers.findDivisors(x);
                                              ulong sum = 0;
                                              foreach (ulong d in divisors)
                                              {
                                                  sum += d;
                                              }
                                              if (sum > x)
                                              {
                                                  lock (abundantNumbers)
                                                  {
                                                      abundantNumbers.Add(x);
                                                  }
                                              }
                                          });

            abundantNumbers.Remove(2);

            //List<ulong> primes = Numbers.findPrimesBelow(maxValue);
            //Parallel.ForEach(primes, prime => abundantNumbers.Remove(prime));
            //Parallel.ForEach(abundantNumbers, n => numbers.Remove(n));
            abundantNumbers.Sort();
            int size = abundantNumbers.Count;
            Parallel.For(0, size, i =>
                                      //for (int i = 0; i < size; i++)
                                      {
                                          //Console.WriteLine(i);
                                          ulong first = abundantNumbers[i];
                                          for (int j = i; j < size; j++)
                                          {
                                              ulong second = abundantNumbers[j];
                                              ulong sum = first + second;
                                              numbers.Remove(sum);
                                          }
                                      });
            
            ulong total = 0;
            foreach (ulong num in numbers)
            {
                Console.WriteLine(total);
                total += num;
            }
            

            Console.WriteLine(total);
            Console.WriteLine("Done");
        }
    }
}
