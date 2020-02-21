using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler88
{
    class Program
    {
        // 2 = k = 12000
        static void Main(string[] args)
        {
            int max = 6100;
            Stack<List<int>> stack = new Stack<List<int>>();
            HashSet<string> seenListStrings = new HashSet<string>();
            for (int i = 1; i < max; i++)
            {
                List<int> l = new List<int>() { i };
                stack.Push(l);
                seenListStrings.Add(listToString(l));
            }



            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            while (stack.Count != 0)
            {
                List<int> l = stack.Pop();
                l.Sort();

                string st = listToString(l);


                if (l.Count == 2 && (st == "3,4," || "4,3," == st))
                {
                    Console.WriteLine("HERE!");
                }
                for (int i = 2; i < max; i++)
                {
                    List<int> copy = new List<int>(l);
                    copy.Add(i);
                    int m = multiplyList(copy);
                    int s = sumList(copy);
                    if (m == s)
                    {
                        int k = copy.Count;
                        if (k == 7)
                        {
                            Console.WriteLine("7 seven");
                        }
                        if (dictionary.ContainsKey(k))
                        {
                            dictionary[k] = Math.Min(m, dictionary[k]);
                            // Console.WriteLine(k);
                        }
                        else
                        {
                            dictionary.Add(k, m);
                            // Console.WriteLine(k);
                        }
                    }
                    else
                    {
                        int numberOfOnes = m - s;
                        int k = copy.Count + numberOfOnes;
                        if (numberOfOnes > 0 && numberOfOnes + s == m && k <= 12000)
                        {

                            if (k == 7)
                            {
                                Console.WriteLine("7 seven");
                            }
                            if (dictionary.ContainsKey(k))
                            {
                                dictionary[k] = Math.Min(m, dictionary[k]);
                                //Console.WriteLine(k);
                            }
                            else
                            {
                                dictionary.Add(k, m);
                                Console.WriteLine(k);
                            }
                        }
                    }

                    if (m <= 12000 && copy.Count <= 12000)
                    {
                        copy.Sort();
                        string copystr = listToString(copy);
                        if (seenListStrings.Contains(copystr))
                        {
                            continue;
                        }
                        else
                        {
                            seenListStrings.Add(copystr);
                            stack.Push(copy);
                        }

                    }
                }
            }
            HashSet<int> numbers = new HashSet<int>();
            for (int i = 2; i <= 12000; i++)
            {
                Console.WriteLine(i + " = " + dictionary[i]);
                numbers.Add(dictionary[i]);
            }
            Console.WriteLine("ANSWER: " + numbers.Sum());
            Console.WriteLine("DONE!");
        }

        static int multiplyList(List<int> list)
        {
            int prod = 1;
            list.ForEach(a => prod *= a);
            return prod;
        }

        static int sumList(List<int> list)
        {
            return list.Sum();
        }

        static string listToString(List<int> list)
        {
            StringBuilder sb = new StringBuilder();
            list.ForEach(a => sb.Append(a + ","));
            return sb.ToString();
        }




    }
}
