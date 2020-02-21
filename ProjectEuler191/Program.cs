using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler191
{
    class Program
    {
        static void Main(string[] args)
        {
//THIS IS REALLY SLOW, on the order of 10(?) minutes?
            //can be optimized in terms of discrete math and inclusion-exclusion?
            DateTime start = DateTime.Now;
            Stack<PrizeString> q = new Stack<PrizeString>();
            q.Push(new PrizeString());
            PrizeString.MAX_LENGTH = 30;

            int count = 0;
            while (q.Count != 0)
            {
                PrizeString temp = q.Pop();
                if (temp.isFinished())
                {
                    if (temp.isValidForPrize())
                    {
                        count++;
                        if (count % 1000000 == 0)
                        {
                            Console.WriteLine(count);
                        }

                    }
                }
                else
                {
                    foreach (PrizeString p in temp.getNextPrizeString())
                    {
                        q.Push(p);
                    }
                }
            }
            DateTime end = DateTime.Now;

            Console.WriteLine("ANSWER: " + 30 + " => " + count);
            Console.WriteLine("TIME: " + (end - start).TotalMilliseconds);
            Console.WriteLine("\n");
            //}
        }
    }

    class PrizeString
    {
        public static int MAX_LENGTH = 4;
        string s;
        int days;
        int numberL;
        public PrizeString()
        {
            days = 0;
            s = "";
            numberL = 0;
        }

        private PrizeString(string input, int L, int d)
        {
            s = input;
            numberL = L;
            days = d;
        }


        public bool isFinished()
        {
            return days == MAX_LENGTH;
        }

        public List<PrizeString> getNextPrizeString()
        {
            List<PrizeString> list = new List<PrizeString>();
            PrizeString temp = new PrizeString("", this.numberL, this.days + 1);
            if (temp.isValidForPrize())
            {
                list.Add(temp);
            }

            temp = new PrizeString("a" + this.s, this.numberL, this.days + 1);
            if (temp.isValidForPrize())
            {
                list.Add(temp);
            }




            if (this.numberL == 0)
            {
                temp = new PrizeString("", 1, this.days + 1);
                list.Add(temp);
            }

            return list;

        }

        public bool isValidForPrize()
        {
            if (numberL > 1)
            {
                return false;
            }
            if (s.Length < 3)
            {
                return true;
            }
            if (s[0] == s[1] && s[1] == s[2] && s[2] == 'a')
            {
                return false;
            }
            return true;
        }
    }
}
