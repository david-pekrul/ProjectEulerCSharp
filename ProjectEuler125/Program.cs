using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler125
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> palendromicNumbers = new HashSet<int>();
            Stack<string> stack = new Stack<string>();

            int maxPower = 8;
            int maxValue = (int)(Math.Pow(10, maxPower));
            Console.WriteLine(maxPower);
            Console.WriteLine(maxValue);

            stack.Push("");
            stack.Push("0");
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            stack.Push("4");
            stack.Push("5");
            stack.Push("6");
            stack.Push("7");
            stack.Push("8");
            stack.Push("9");
            List<char> digits = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            while (stack.Count != 0)
            {
                string temp = stack.Pop();
                if (temp.Length > maxPower)
                {
                    continue;
                }
                if (temp.Length >= 1 && temp[0] != '0')
                {
                    palendromicNumbers.Add(Int32.Parse(temp));
                }
                foreach (char c in digits)
                {
                    string next = c + temp + c;
                    stack.Push(next);
                }
            }


            Console.WriteLine("Size: " + palendromicNumbers.Count);

            List<int> squares = new List<int>();
            for (int i = 1; i < maxValue; i++)
            {
                squares.Add(i * i);
            }

            ulong sum = 0;
            foreach (int i in palendromicNumbers)
            {
                if (addable(i, squares))
                {
                    //Console.WriteLine(i);
                    sum += (ulong)i;
                }
            }

            Console.WriteLine("ANSWER: " + sum);


        }

        static bool addable(int palendrome, List<int> squares)
        {

            int upperIndex = 0;
            int lowerIndex = 0;
            int sum = squares[0];
            bool done = false;

            while (!done)
            {
                if (sum == palendrome)
                {
                    done = true;
                }
                if (lowerIndex > upperIndex)
                {
                    done = true;
                }
                if (sum < palendrome)
                {
                    upperIndex++;
                    sum += squares[upperIndex];
                }
                if (sum > palendrome)
                {
                    sum -= squares[lowerIndex];
                    lowerIndex++;
                }
            }
            bool answer = sum == palendrome && lowerIndex != upperIndex;
            if (answer)
            {
                Console.WriteLine(palendrome);
            }
            return answer;
        }
    }
}
