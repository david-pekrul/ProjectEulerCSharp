using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler90
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<List<byte>> stack = new Stack<List<byte>>();
            List<byte> digits = new List<byte>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            stack.Push(new List<byte>());
            HashSet<Dice> hashDice = new HashSet<Dice>();
            HashSet<string> hashString = new HashSet<string>();

            while (stack.Count != 0)
            {
                List<byte> temp = stack.Pop();
                temp.Sort((a, b) => digits.IndexOf(a).CompareTo(digits.IndexOf(b)));
                if (temp.Count == 6)
                {
                    Dice tDice = new Dice(temp);
                    string s = tDice.ToString();
                    if (!hashString.Contains(s))
                    {
                        hashString.Add(s);
                        hashDice.Add(tDice);
                    }

                    continue;
                }
                foreach (byte d in digits)
                {
                    if (!temp.Contains(d))
                    {
                        List<byte> next = new List<byte>(temp);
                        next.Add(d);
                        stack.Push(next);
                    }
                }
            }
            Console.WriteLine("Dice count: " + hashDice.Count);
            int count = 0;

            List<Dice> listDice = hashDice.ToList();
            for (int i = 0; i < listDice.Count; i++)
            {
                for (int j = i + 1; j < listDice.Count; j++)
                {
                    Dice d1 = listDice[i];
                    Dice d2 = listDice[j];
                    PairOfDice pod = new PairOfDice(d1, d2);
                    if (pod.canMakeAllSquares())
                    {
                        count++;
                    }
                }
            }



            Console.WriteLine("ANSWER: " + count);
        }
    }

    class PairOfDice
    {
        private Dice d1, d2;
        public PairOfDice(Dice x, Dice y)
        {
            d1 = x;
            d2 = y;
        }

        private bool canMakeNumnber(byte a, byte b)
        {
            if (!((d1.containsSide(a) && d2.containsSide(b)) || (d2.containsSide(a) && d1.containsSide(b))))
            {
                return false;
            }
            return true;
        }

        public bool canMakeAllSquares()
        {
            if (!canMakeNumnber(0, 1))
            {
                return false;
            }
            if (!canMakeNumnber(0, 4))
            {
                return false;
            }
            if (!canMakeNumnber(0, 9))
            {
                return false;
            }
            if (!canMakeNumnber(1, 6))
            {
                return false;
            }
            if (!canMakeNumnber(2, 5))
            {
                return false;
            }
            if (!canMakeNumnber(3, 6))
            {
                return false;
            }
            if (!canMakeNumnber(4, 9))
            {
                return false;
            }
            if (!canMakeNumnber(6, 4))
            {
                return false;
            }
            if (!canMakeNumnber(8, 1))
            {
                return false;
            }

            return true;
        }


    }

    class Dice
    {

        public List<byte> sides;
        public Dice(List<byte> s)
        {
            sides = new List<byte>(s);
        }

        public bool containsSide(byte b)
        {
            if (b == 6 || b == 9)
            {
                return sides.Contains(6) || sides.Contains(9);
            }
            return sides.Contains(b);
        }

        public override string ToString()
        {
            string s = "";
            foreach (byte c in sides)
            {
                s += c.ToString() + ",";
            }
            return s;
        }

        public override bool Equals(object obj)
        {
            if (!(obj.GetType() == typeof(Dice)))
            {
                return false;
            }
            Dice other = (Dice)obj;

            return other.sides.Equals(this.sides);
        }

        public override int GetHashCode()
        {
            int hash = 1;
            foreach (byte b in sides)
            {
                hash *= b.GetHashCode();
            }
            return hash;
        }

    }
}