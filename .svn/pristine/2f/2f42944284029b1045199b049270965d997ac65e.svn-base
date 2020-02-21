using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EulerLibrary;

namespace ProjectEuler42
{
    class Program
    {
        private static readonly Dictionary<char,ulong> dictionaryCharToInt = new Dictionary<char, ulong>()
        {
            {'A',1},
            {'B',2},
            {'C',3},
            {'D',4},
            {'E',5},
            {'F',6},
            {'G',7},
            {'H',8},
            {'I',9},
            {'J',10},
            {'K',11},
            {'L',12},
            {'M',13},
            {'N',14},
            {'O',15},
            {'P',16},
            {'Q',17},
            {'R',18},
            {'S',19},
            {'T',20},
            {'U',21},
            {'V',22},
            {'W',23},
            {'X',24},
            {'Y',25},
            {'Z',26}

        };
        static void Main(string[] args)
        {
            ReadWordFile readFile = new ReadWordFile("words.txt");
            List<string> wordList = readFile.getWords();
            List<ulong> triangularNumber = Numbers.findTriangularNumbersBelow(10000);
            int foundTriangularWords = 0;
            Object lockObject = new object();
            Parallel.ForEach(wordList, word =>
                                           {
                                               if(triangularNumber.Contains(calculateTriangularNumber(word)))
                                               {
                                                   lock(lockObject)
                                                   {
                                                       Console.WriteLine(word);
                                                       foundTriangularWords += 1;
                                                   }
                                               }
                                           });
            Console.WriteLine(foundTriangularWords);
            Console.WriteLine("Done");
        }

        public static ulong calculateTriangularNumber(string word)
        {
            ulong number = 0;
            foreach(char c in word)
            {
                number += dictionaryCharToInt[c];
            }
            return number;
        }
    }

    class ReadWordFile
    {
        //Format of the file is "Word","Word","Word"....
        private List<string> words;
        private StreamReader reader;
        public ReadWordFile(string fileName)
        {
            reader = new StreamReader(fileName);
            words = new List<string>();
        }

        public List<string> getWords()
        {
            string line = "";
            while(!reader.EndOfStream)
            {
                line = reader.ReadLine();
                line = line.Replace("\"", "");
                words.AddRange(line.Split(','));
            }
            
            return words;
        }
    }
}
