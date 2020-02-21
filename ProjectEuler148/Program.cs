using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;

using EulerLibrary;
/*
We can easily verify that none of the entries in the first seven rows of Pascal's triangle are divisible by 7:
  	  	  	  	  	  	 1
  	  	  	  	  	 1 	  	 1
  	  	  	  	 1 	  	 2 	  	 1
  	  	  	 1 	  	 3 	  	 3 	  	 1
  	  	 1 	  	 4 	  	 6 	  	 4 	  	 1
  	 1 	  	 5 	  	10 	  	10 	  	 5 	  	 1
1 	  	 6 	  	15 	  	20 	  	15 	  	 6 	  	 1

However, if we check the first one hundred rows, we will find that only 2361 of the 5050 entries are not divisible by 7.

Find the number of entries which are not divisible by 7 in the first one billion (10^9) rows of Pascal's triangle.

 */
namespace ProjectEuler148
{
    class Program
    {
        public static Queue<TriangleLine> queue = new Queue<TriangleLine>();
        public static Semaphore sema = new Semaphore(1, 1);
        public static int waitingThreads = 0;
        public static BigInteger notDivisibleBySeven = 0;
        public static BigInteger maxValue = 56;
        public static bool done = false;
        public static object lockingNotDivisibleBySeven = new object();
        public static object lockingThreadStarting = new object();
        public static ulong something = 0;
        static void Main(string[] args)
        {
            
            DateTime start = DateTime.Now;
            Console.WriteLine("Total: " + (maxValue * (maxValue + 1) / 2));

            Thread t1 = new Thread(Producer);
            List<Thread> consumers = new List<Thread>();
            byte numConsumers = 7;
            for (byte x = 0; x < numConsumers; x++)
            {
                consumers.Add(new Thread(Consumer));
            }


            t1.Start();
            foreach (Thread t in consumers)
            {
                t.Start();
            }
            t1.Join();
            foreach (Thread t in consumers)
            {
                t.Join();
            }
            #region old code

            //DateTime startMakingNextRow, startCalculations;
           
            //BigInteger blockStart = 0;
            //BigInteger blockIncrement = 100;
            //BigInteger blockEnd = blockIncrement;

           
            //BigInteger value = 0;
            //List<BigInteger> startLine = new List<BigInteger>() { 1 };
            //TriangleLine startTriLine = new TriangleLine(startLine, false);
            
            //object locking = new object();
            //while (blockStart < maxValue)
            //{
            //    Console.WriteLine("------");
            //    Console.WriteLine(blockStart);
            //    startMakingNextRow = DateTime.Now;
            //    Stack<TriangleLine> stack = new Stack<TriangleLine>();
            //    for (BigInteger i = blockStart; i <= blockEnd; i++)
            //    {
            //        stack.Push(startTriLine);
            //        startTriLine = startTriLine.calculateNextTriangleLine();
            //    }
            //    Console.WriteLine("Done making next rows \t\t" + (DateTime.Now - startMakingNextRow).TotalSeconds);
            //    startCalculations = DateTime.Now;
            //    Parallel.ForEach(stack, tl =>
            //    {
            //        BigInteger notDiv7 = tl.howManyNotDivisibleBy7();
            //        lock (locking)
            //        {
            //            value += notDiv7;
            //        }
            //    });
            //    Console.WriteLine("Done calculating next rows \t" + (DateTime.Now - startCalculations).TotalSeconds);
            //    blockStart = blockEnd;
            //    blockEnd += blockIncrement;
            //}
            #endregion
            Console.WriteLine(something);
            Console.WriteLine("NotDivisibleBySeven: " + notDivisibleBySeven);
            Console.WriteLine("Time: " + (DateTime.Now - start).TotalMinutes);
        }

        private static void Producer()
        {
            DateTime lapTime = DateTime.Now;
            ulong lapSize = 1000;
            List<short> startLine = new List<short>() { 1 };
            TriangleLine startTriLine = new TriangleLine(startLine, false);
            for (BigInteger i = 1; i <= maxValue; i++)
            {
                if (i % lapSize == 0)
                {
                    Console.WriteLine(i + "\t" + (DateTime.Now - lapTime).TotalSeconds);
                    lapTime = DateTime.Now;
                }
                if (i == 50)
                {
                    short x = 2;
                }
                sema.WaitOne();
                queue.Enqueue(startTriLine);
                sema.Release();
                startTriLine = startTriLine.calculateNextTriangleLine();
            }
            done = true;
        }


        private static void Consumer()
        {
            while (!done || queue.Count > 0)
            {
                TriangleLine item = null;
                BigInteger nextValue = 0;
                sema.WaitOne(2000);
                if (queue.Count != 0)
                {
                    item = queue.Dequeue();
                    sema.Release();
                }
                else
                {
                    if (done && queue.Count == 0)
                    {
                        break;
                    }
                    sema.Release();
                    continue;
                }
                
                nextValue = item.howManyNotDivisibleBy7();        
                lock (lockingNotDivisibleBySeven)
                {
                    notDivisibleBySeven += nextValue;
                }
            }
        }
    }

    class TriangleLine
    {
        public bool even;
        List<short> values;
        public TriangleLine(List<short> v, bool isEven)
        {
            values = v;
            even = isEven;
        }

        public TriangleLine calculateNextTriangleLine()
        {
            
            int nextLength = this.values.Count + 1;
            List<short> nextValues = new List<short>();
            for (int i = 0; i < nextLength; i++)
            {
                nextValues.Add(0);
            }
            short value = 0;
            for (int i = 0; i < nextLength - 1; i++)
            {
                value = this.values[i];
                nextValues[i] += value;
                nextValues[i + 1] += value;
                if (nextValues[i] % 7 == 0)
                {
                    nextValues[i] = 0;
                }
            }
            if (nextValues[nextLength - 1] % 7 == 0) { nextValues[nextLength - 1] = 0; }
            if (!even) //remove the last value from the next list
            {
                nextValues.RemoveAt(nextLength - 1);
            }
            else //multiply the last value of the new list by 2
            {
                nextValues[nextLength - 1] *= 2;
            }

            return new TriangleLine(nextValues, !even);
        }

        public BigInteger howManyNotDivisibleBy7()
        {
            BigInteger num = 0;
            object locking = new object();

            Parallel.ForEach(values, value =>
            {
                if (value % 7 != 0)
                {
                    lock (locking)
                    {
                        num += 2;
                    }
                }
            });
            //foreach (BigInteger value in values)
            //{
            //    if (value % 7 != 0)
            //    {
            //        lock (locking)
            //        {
            //            num += 2;
            //        }
            //    }
            //}
            if (!even && values[values.Count - 1] != 0)
            {
                 num -= 1;      
            }
            if (num < 0)
            {
                int x = 3;
            }
            return num;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (BigInteger value in values)
            {
                sb.Append(value).Append(" ");
            }
            return sb.ToString();
        }

        public BigInteger maxValue()
        {
            return values[values.Count - 1];
        }
        
    }
}
