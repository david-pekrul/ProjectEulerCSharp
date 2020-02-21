using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

//http://www.btinternet.com/~se16/js/partition.java 
namespace ProjectEuler78
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100000;
            int depent = (int)Math.Sqrt(1.0d + n);
            int[] signArray = new int[2 * depent + 2];
            int[] pentArray = new int[2 * depent + 2];
            signArray[0] = -1; signArray[1] = 1;
            pentArray[0] = 0; pentArray[1] = 1;
            for (int i = 1; i <= depent; i++)
            {
                signArray[2 * i] = -signArray[2 * i - 2];
                signArray[2 * i + 1] = -signArray[2 * i - 1];
                pentArray[2 * i] = (i * (3 * i + 1)) / 2;
                pentArray[2 * i + 1] = ((i + 1) * (3 * i + 2)) / 2;
            }
            BigInteger[] partitionArray = new BigInteger[n + 1];
            partitionArray[0] = 1;
            for (long j = 1; j <= n; j++)
            {
                BigInteger partSum = 0;
                for (long k = 1; pentArray[k] <= j; k++)
                {
                    if (signArray[k] == 1)
                    {
                        partSum += partitionArray[j - pentArray[k]];
                    }
                    else
                    {
                        partSum -= partitionArray[j - pentArray[k]];
                    }
                }
                //                 messagebox.setText(Integer.toString(j));
                partitionArray[j] = partSum;
                if (partSum % 1000000 == 0)
                {
                    Console.WriteLine("Project Euler 78 => " + j);
                    break;

                }
            }        
            Console.WriteLine("Project Euler 76: " + (partitionArray[100] -1)); //minus 1 for the non-partitioned 100

        }
    }
}
