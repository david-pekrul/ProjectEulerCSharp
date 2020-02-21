using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler24
{
    class Program
    {
        static List<string> digits = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            string start = "";
            
            SortedSet<string> sortedSet = new SortedSet<string>();

            foreach(string d in digits)
            {
                stack.Push(d);
            }

            while(stack.Count != 0)
            {
                string current = stack.Pop();
                if(current.Length != 10)
                {
                    List<string> nextItems = addDigitIntoString(current);
                    foreach(string item in nextItems)
                    {
                        stack.Push(item);
                    }
                }
                else
                {
                    sortedSet.Add(current);
                }
            }

            Console.WriteLine(sortedSet.ToList()[999999]);
            Console.WriteLine("Done");
        }

        static List<string> addDigitIntoString(string input)
        {
            List<string> newList = new List<string>();

            foreach(string d in digits)
            {
                if (!input.Contains(d))
                {
                    newList.Add(input + d);
                }
            }

            return newList;
        }
    }
}
