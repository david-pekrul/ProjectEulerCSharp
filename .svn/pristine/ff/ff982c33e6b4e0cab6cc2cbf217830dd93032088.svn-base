using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler75
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 1500000;
            int count = 1;
            Stack<Lengths> lengths = new Stack<Lengths>();
            Dictionary<int, int> lengthToCount = new Dictionary<int, int>();
            Lengths start = new Lengths(3, 4, 5);
            //lengthToCount.Add(12, 1);
            lengths.Push(start);
            Lengths temp1 = new Lengths(3, 4, 5);
            int z = 2;
            while (temp1.getTotalLengths() <= max)
            {
                int len = temp1.getTotalLengths();
                if (lengthToCount.ContainsKey(len))
                {
                    lengthToCount[len]++;
                }
                else
                {
                    lengthToCount.Add(len, 1);
                }
                //lengths.Push(temp);

                temp1 = start.scale(z++);
            }


            while (lengths.Count != 0)
            {
                Lengths current = lengths.Pop();
                foreach (Lengths l in current.generateNextLengths())
                {
                    Lengths temp = l;
                    int scale = 2;
                    while (temp.getTotalLengths() <= max)
                    {
                        int len = temp.getTotalLengths();
                        if (lengthToCount.ContainsKey(len))
                        {
                            lengthToCount[len]++;
                        }
                        else
                        {
                            lengthToCount.Add(len, 1);
                        }
                        //lengths.Push(temp);

                        temp = l.scale(scale++);
                    }
                    if (l.getTotalLengths() <= max)
                    {
                        lengths.Push(l);
                    }
                }
            }


            Console.WriteLine("ANSWER: " + lengthToCount.Count(entry => entry.Value == 1));


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
    }
}
