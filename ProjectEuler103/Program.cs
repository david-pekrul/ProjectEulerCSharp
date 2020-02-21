using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler103
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> array = new List<int>() { 4, 5, 6, 7, 8 };
            int count = 1;
            bool done = false;
            while (!done)
            {
                for (int x = 1; x < array.Count / 2 + 1; x++)
                {
                    count = x;
                    int leftSum = 0;
                    int rightSum = 0;
                    for (int i = 0; i <= count; i++)
                    {
                        leftSum += array[i];
                    }
                    for (int i = 0; i < count; i++)
                    {
                        rightSum += array[array.Count - 1 - i];
                    }

                    Console.WriteLine(leftSum + " ? " + rightSum);
                    if (leftSum <= rightSum)
                    {
                        Console.WriteLine("Problem: " + leftSum + " <= " + rightSum);
                        x = 1;
                        array = fixLeft(array, x, leftSum);
                    }
                }
            }
        }

        static List<int> fixLeft(List<int> array, int lastIndex, int leftSum)
        {
            int increasedLeftSum = leftSum + 1;
            int firstValue = increasedLeftSum/(lastIndex + 1);
            for (int i = 0; i <= lastIndex; i++)
            {
                array[i] = firstValue;
                firstValue++;
            }
            return removeDuplicates(array);
        }

        static List<int> fixRight(List<int> array, int firstIndex, int rightSum)
        {
            int increasedLeftSum = rightSum + 1;
            int firstValue = increasedLeftSum / (array.Count - firstIndex);
            for (int i = firstIndex; i < array.Count; i++)
            {
                array[i] = firstValue;
                firstValue++;
            }
            return removeDuplicates(array);
        }

        static List<int> removeDuplicates(List<int> array)
        {

            array.Sort();
            for (int i = 0; i < array.Count - 1; i++)
            {
                if(array[i] == array[i+1])
                {
                    array[i + 1]++;
                }
            }
            
            return array;
        }
    }
}
