using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Consider the following "magic" 3-gon ring, filled with the numbers 1 to 6, and each line adding to nine.

Working clockwise, and starting from the group of three with the numerically lowest external node (4,3,2 in this example), each solution can be described uniquely. For example, the above solution can be described by the set: 4,3,2; 6,2,1; 5,1,3.

It is possible to complete the ring with four different totals: 9, 10, 11, and 12. There are eight solutions in total.
Total	Solution Set
9	4,2,3; 5,3,1; 6,1,2
9	4,3,2; 6,2,1; 5,1,3
10	2,3,5; 4,5,1; 6,1,3
10	2,5,3; 6,3,1; 4,1,5
11	1,4,6; 3,6,2; 5,2,4
11	1,6,4; 5,4,2; 3,2,6
12	1,5,6; 2,6,4; 3,4,5
12	1,6,5; 3,5,4; 2,4,6

By concatenating each group it is possible to form 9-digit strings; the maximum string for a 3-gon ring is 432621513.

Using the numbers 1 to 10, and depending on arrangements, it is possible to form 16- and 17-digit strings. What is the maximum 16-digit string for a "magic" 5-gon ring?

 */

//ANSWER: 6531031914842725
namespace ProjectEuler68
{
    class Program
    {
        static void Main(string[] args)
        {
            FiveGonRing start = new FiveGonRing();
            Stack<FiveGonRing> stack = new Stack<FiveGonRing>();
            stack.Push(start);
            HashSet<FiveGonRing> validRings = new HashSet<FiveGonRing>();

            while (stack.Count != 0)
            {
                FiveGonRing temp = stack.Pop();
                for (int i = 1; i <= 10; i++)
                {
                    FiveGonRing copy = temp.copy();
                    bool successful = copy.addNumber(i);
                    if(copy.finished())
                    {
                        //Console.WriteLine(copy);
                        validRings.Add(copy);
                    }
                    else if (successful)
                    {
                        stack.Push(copy);
                    }
                }
            }

            HashSet<string> strings = new HashSet<string>();
            foreach(FiveGonRing f in validRings)
            {
                string str = f.toOutputString().Replace(" ", "");
                if (str.Length == 16)
                {
                    strings.Add(str);
                }
            }
            List<string> listSTring = new List<string>(strings);
            listSTring.Sort();

            foreach (string s in listSTring)
            {
               Console.WriteLine(s);
            }
        }
    }

    class FiveGonRing
    {
        private int[] array;
        private int index;
        public FiveGonRing()
        {
            array = new int[10];
            index = 0;
        }

        public FiveGonRing copy()
        {
            FiveGonRing temp = new FiveGonRing();
            temp.index = this.index;
            Array.Copy(this.array, temp.array, temp.index);
            return temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(array[0] + " ");
            sb.Append(array[1]+" " );
            sb.Append(array[2]+" " );
                              
            sb.Append(array[3]+" " );
            sb.Append(array[2]+" " );
            sb.Append(array[4]+" " );
                               
            sb.Append(array[5]+" " );
            sb.Append(array[4]+" " );
            sb.Append(array[6]+" " );
                               
            sb.Append(array[7]+" " );
            sb.Append(array[6]+" " );
            sb.Append(array[8]+" " );
                               
            sb.Append(array[9]+" " );
            sb.Append(array[8]+" " );
            sb.Append(array[1]);

            return sb.ToString().Trim();
        }

        private void rotate()
        {
            int[] temp = new int[10];
            temp[0] = array[3];
            temp[1] = array[2];
            temp[2] = array[4];
            temp[3] = array[5];
            temp[4] = array[6];
            temp[5] = array[7];
            temp[6] = array[8];
            temp[7] = array[9];
            temp[8] = array[1];
            temp[9] = array[0];
            array = temp;
        }

        public string toOutputString()
        {
            int min = array[0];
            min = Math.Min(min, array[3]);
            min = Math.Min(min, array[5]);
            min = Math.Min(min, array[7]);
            min = Math.Min(min, array[9]);

            while(array[0] != min)
            {
                rotate();
            }

            return this.ToString();
        }

        public bool addNumber(int x)
        {
            if(index == array.Length)
            {
                return false;
            }
            if(array.Contains(x))
            {
                return false;
            }
            array[index++] = x;
            return constraintsHeld();
        }

        public bool finished()
        {
            return (index == 10 && constraintsHeld());
        }

        public bool constraintsHeld()
        {
            //check if first row is full
            if (array[0] == 0 || array[1] == 0 || array[2] == 0)
            {
                return true; // nothing to verify against
            }

            //first block non-zero
            int firstBlockSum = array[0] + array[1] + array[2];


            //---------------------------------------------------

            if (array[3] == 0)
            {
                return true;
            }

            if (array[3] + array[2] >= firstBlockSum)
            {
                return false;
            }

            if (array[4] == 0)
            {
                return true;
            }

            if (array[3] + array[2] + array[4] != firstBlockSum)
            {
                return false;
            }

            //-------------------------------------------

            if (array[5] == 0)
            {
                return true;
            }

            if (array[5] + array[4] >= firstBlockSum)
            {
                return false;
            }

            if (array[6] == 0)
            {
                return true;
            }

            if (array[5] + array[4] + array[6] != firstBlockSum)
            {
                return false;
            }

            //-------------------------------------------

            if (array[7] == 0)
            {
                return true;
            }

            if (array[7] + array[6] >= firstBlockSum)
            {
                return false;
            }

            if (array[8] == 0)
            {
                return true;
            }

            if (array[7] + array[6] + array[8] != firstBlockSum)
            {
                return false;
            }

            //-------------------------------------------

            if (array[9] == 0)
            {
                return true;
            }

            if (array[9] + array[8] >= firstBlockSum)
            {
                return false;
            }

            if (array[9] == 0)
            {
                return false;
            }


            if (array[9] + array[8] + array[1] != firstBlockSum)
            {
                return false;
            }

            for (int i = 1; i <= 10; i++)
            {
                if(!array.Contains(i))
                {
                    return false;
                }
            }

            //string s = toOutputString().Replace(" ", "");

            //Console.WriteLine("s: " + s);

            return true;
        }

    }
}
