using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler99
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("baseexp.txt");
            string bestLine = "";
            double bestValue = 0;
            int lineNumber = 0;
            int bestLineNumber = 0;
            while (!reader.EndOfStream)
            {
                lineNumber++;
                string line = reader.ReadLine();
                string[] split = line.Split(',');
                double b = Double.Parse(split[0]);
                double exp = Double.Parse(split[1]);
                double value = Math.Log(b) * exp;
                if (value > bestValue)
                {
                    bestValue = value;
                    bestLine = line;
                    bestLineNumber = lineNumber;
                    Console.WriteLine(bestLine);
                }
            }

            Console.WriteLine(bestLine);
            Console.Write(bestLineNumber);
        }
    }
}
