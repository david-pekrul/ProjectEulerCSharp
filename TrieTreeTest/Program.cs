using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EulerLibrary;

namespace ProjectEuler59
{
    class Program
    {
        public static void Main(string[] args)
        {
            TrieTree tree = new TrieTree();
            StreamReader reader = new StreamReader("C:\\words.txt");

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                tree.addWord(line);
            }
            reader.Close();

            reader = new StreamReader("C:\\cipher1.txt");
            string wholeLine = reader.ReadLine();
            reader.Close();
            //Console.WriteLine(wholeLine);
            string[] array = wholeLine.Split(',');
            List<string> list = new List<string>(array);


            int start = 'a';
            int end = 'z';

            //103 111 100
            
            bool writeLine = false;
            for (int i = start; i <= end; i++)
            {
                //Console.WriteLine(i);
                for (int j = start; j <= end; j++)
                {
                    for (int k = start; k <= end; k++)
                    {
                        //Console.WriteLine("" + (char)i + "" + (char)j + "" + (char)k);
                        if (writeLine)
                        {
                            //Console.WriteLine();
                            writeLine = false;
                        }
                        string sbuilder = "";
                        string completeMessage = "";
                        int sum = 0;
                        int lastIndex = 0;
                        for (int index = 0; index < list.Count; index++)
                        {
                            lastIndex = index;
                            //char thing = (char)Int32.Parse(list[index]);
                            int thing = Int32.Parse(list[index]);


                            char x = ' ';
                            int modValue = index % 3;
                            switch (modValue)
                            {
                                case 0:
                                    x = (char)(thing ^ i);
                                    break;
                                case 1: x = (char)(thing ^ j);
                                    break;
                                case 2:
                                    x = (char)(thing ^ k);
                                    break;
                            }

                            if (x == ' ')
                            {
                                //writeLine = true;
                                //Console.Write(sbuilder + " ");
                                sbuilder = "";
                            }
                            else if (Char.IsLetter(x))
                            {
                                writeLine = true;
                                //Console.Write(x);
                                sbuilder += x;
                                sbuilder = sbuilder.ToLower();
                                if (!tree.canBeAWord(sbuilder))
                                {
                                    break;
                                }
                            }
                            else
                            {
                                writeLine = true;
                                //Console.Write(x);
                            }
                            sum += (int) x;
                            completeMessage += x;
                        }
                        if(lastIndex == list.Count-1)
                        {
                            Console.WriteLine(completeMessage);
                            Console.WriteLine("ANSWER: " + sum);
                        }
                        
                    }
                }
            }





            //zombi
            //zombie
            //zombies
        }
    }
}
