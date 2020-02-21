using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler62
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<ulong>> dictionary = new Dictionary<string, List<ulong>>();
            for(ulong i = 1; i < 10000; i++)
            {
                ulong temp = i*i*i;
                List<char> list = new List<char>(temp.ToString().ToCharArray());
                list.Sort();
                string sorted = "";
                foreach(char c in list)
                {
                    sorted += c;
                }
                if(dictionary.ContainsKey(sorted))
                {
                    dictionary[sorted].Add(temp);
                    if(dictionary[sorted].Count == 5)
                    {
                        List<ulong> answerList = dictionary[sorted];
                        answerList.Sort();

                        Console.WriteLine(answerList[0]);
                        break;
                    }
                }
                else
                {
                    List<ulong> tempList = new List<ulong>();
                    tempList.Add(temp);
                    dictionary.Add(sorted, tempList);
                }
            }
        }
    }
}
