using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler52
{
    /*
     * It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.

Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.
*/
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 10; i < 1000000; i++)
            {
                if (checkNumber(i))
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }

        static bool checkNumber(int number)
        {
            //ASSUMPTION: Each digit can only appear once. This is a valid assumption for this problem. (SOLVED)
            HashSet<char> usedDigits = new HashSet<char>();
            int length = number.ToString().Length;
            foreach (char c in number.ToString())
            {
                if (usedDigits.Contains(c))
                {
                    return false;
                }
                usedDigits.Add(c);
            }

            for (int i = 2; i < 7; i++)
            {
                int temp = number * i;
                string tempString = temp.ToString();
                if (tempString.Length != length)
                {
                    return false;
                }
                foreach (char c in tempString)
                {
                    if (!usedDigits.Contains(c))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
