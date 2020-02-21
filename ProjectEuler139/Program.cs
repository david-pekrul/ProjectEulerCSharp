using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;

namespace ProjectEuler139
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 100000000;
            Stack<Lengths> lengths = new Stack<Lengths>();
            Lengths start = new Lengths(3, 4, 5);
            lengths.Push(start);

            int answer = 0;
            while (lengths.Count != 0)
            {
                Lengths current = lengths.Pop();

                if (current.mod() == 0)
                {
                    int trianglesFromThisOne = (max / current.getTotalLengths());
                    answer += trianglesFromThisOne;
                }
                foreach (Lengths l in current.generateNextLengths())
                {
                    if (l.getTotalLengths() <= max)
                    {
                        lengths.Push(l);
                    }
                }
            }
            Console.WriteLine("ANSWER: " + answer);


        }
    }

    class Lengths
    {
        int a, b, c;
        public Lengths(int x, int y, int z)
        {
            List<int> list = new List<int>() { x, y, z };
            list.Sort();
            a = list[0];
            b = list[1];
            c = list[2];
        }

        public HashSet<Lengths> generateNextLengths()
        {
            HashSet<Lengths> next = new HashSet<Lengths>();
            next.Add(new Lengths(a - 2 * b + 2 * c, 2 * a - b + 2 * c, 2 * a - 2 * b + 3 * c));
            next.Add(new Lengths(a + 2 * b + 2 * c, 2 * a + b + 2 * c, 2 * a + 2 * b + 3 * c));
            next.Add(new Lengths(-a + 2 * b + 2 * c, -2 * a + b + 2 * c, -2 * a + 2 * b + 3 * c));

            return next;
        }

        public int getTotalLengths()
        {
            return a + b + c;
        }

        public Lengths scale(int s)
        {
            return new Lengths(a * s, b * s, c * s);
        }

        public override string ToString()
        {
            return a + "_" + b + "_" + c;
        }

        public int mod()
        {
            return c % (b - a);
        }
    }
}