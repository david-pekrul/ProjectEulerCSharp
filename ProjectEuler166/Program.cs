using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace ProjectEuler166
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] a = {6, 3, 3, 0};
            int[] b = {5, 0, 4, 3};
            int[] c = {0, 7, 1, 4};
            int[] d = {1, 2, 4, 5};
            Console.WriteLine(sumsWork(12, a, b, c, d));


            Dictionary<int, List<int[]>> dictionary = new Dictionary<int, List<int[]>>();
            for (int i = 0; i <= 36; i++ )
            {
                dictionary.Add(i, new List<int[]>());
            }
            for (int i = 0; i <= 9999; i++)
            {
                if(i == 714 || i == 5043 || i == 6330 || i ==1245)
                {
                    Console.WriteLine(i);
                }
                int[] arr = convertNumberToIntArray(i);
                int sum = arr.Sum();
                dictionary[arr.Sum()].Add(arr);
            }

            int total = 0;
            
            for(int i = 0; i <= 36; i++)
            {
                Console.WriteLine(i + "__" + dictionary[i].Count + "\t");
            }

            foreach(int[] x in dictionary[12])
            {
                if(x[0] == 6 && x[1] == 3 && x[2] == 3 && x[3] == 0)
                {
                    Console.WriteLine("FOUND!");
                }
            
            }

            for (int i = 0; i <= 36; i++)
            {
                int totalForI = numberOfWorkingGridsForValue(i, dictionary[i]);
                Console.WriteLine(i + "\t" + dictionary[i].Count + "\t" + totalForI);
                total += totalForI;

            }
            Console.WriteLine("Total: " + total);


        }

        static int[] convertNumberToIntArray(int n)
        {
            int[] arr = new int[4];
            for(int i = 3; i >= 0; i--)
            {
                arr[i] = n%10;
                n /= 10;
            }
            return arr;
        }

        static void printArray(int[] arr)
        {
            foreach(int i in arr)
            {
                Console.Write(i + "_");
            }
            Console.WriteLine();
        }

        static int numberOfWorkingGridsForValue(int value, List<int[]> arrays)
        {
            int count = arrays.Count;
            int sum = 0;
            for(int a = 0; a < count; a++)
            {
                for(int b = 0; b < count; b++)
                {
                    for(int c = 0; c < count;c++)
                    {
                        for(int d =0; d < count; d++)
                        {
                            if(sumsWork(value, arrays[a], arrays[b], arrays[c], arrays[d]))
                            {
                                sum++;
                            }
                        }
                    }
                }
            }
            return sum;
        }

        static bool sumsWork(int sum, int[] a, int[] b, int[] c, int[] d)
        {
            for(int i = 0; i < 4; i++)
            {
                if(a[i] + b[i] + c[i] + d[i] != sum)
                {
                    return false;
                }
            }
            if (a[0] + b[1] + c[2] + d[3] != sum)
            {
                return false;
            }
            if(a[3] + b[2] + c[1] + d[0] != sum)
            {
                return false;
            }
            if (a[0] == 6 && a[1] == 3 && a[2] == 3 && a[3] == 0)
            {
                Console.WriteLine("------------------\r\n" + sum);
                printArray(a);
                printArray(b);
                printArray(c);
                printArray(d);    
            }
            
            return true;
        }

        
    }
}
