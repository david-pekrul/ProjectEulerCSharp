using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EulerLibrary;

namespace ProjectEuer178
{
    class Program
    {
        public static int sizeLimit = 25;
        static void Main(string[] args)
        {
            Matrix adjMatrix = getAdjacencyMatrix();
            List<Matrix> powMatricies = new List<Matrix>();
            powMatricies.Add(adjMatrix);

            for (int i = 2; i <= 40; i++)
            {
                Matrix temp = Matrix.Power(adjMatrix, i);
                Console.WriteLine("\r\n" + i);
                Console.WriteLine(temp);
                powMatricies.Add(temp);
            }

            Dictionary<int, int> stepsToZeroStartingStepNums = new Dictionary<int, int>();
            Dictionary<int, int> stepsToNineStartingStepNums = new Dictionary<int, int>();
            for (int i = 1; i < 35; i++)
            {
                stepsToZeroStartingStepNums.Add(i, (int) powMatricies[i][0, 9]);
                stepsToNineStartingStepNums.Add(i, (int) powMatricies[i][9, 0]);
            }

            Console.WriteLine("Done");

        }

        static bool isPandigital(string bigNumber)
        {
            if (bigNumber.Length < 10)
            {
                return false;
            }
            HashSet<char> digits = new HashSet<char>(bigNumber.ToCharArray());
            return digits.Count == 10;
        }

        static Matrix getAdjacencyMatrix()
        {
            //[
            //[0,1,0,0,0,0,0,0,0],
            //[0,0,1,0,0,0,0,0,0],
            //[0,1,0,1,0,0,0,0,0],
            //[0,0,1,0,1,0,0,0,0],
            //[0,0,0,1,0,1,0,0,0],
            //[0,0,0,0,1,0,1,0,0],
            //[0,0,0,0,0,1,0,1,0],
            //[0,0,0,0,0,0,1,0,1],
            //[0,0,0,0,0,0,0,1,0]
            //]
            Matrix matrix = new Matrix(10, 10);
            matrix[0, 1] = 1;
            matrix[1, 2] = 1;
            matrix[2, 1] = 1;
            matrix[2, 3] = 1;
            matrix[3, 2] = 1;
            matrix[3, 4] = 1;
            matrix[4, 3] = 1;
            matrix[4, 5] = 1;
            matrix[5, 4] = 1;
            matrix[5, 6] = 1;
            matrix[6, 5] = 1;
            matrix[6, 7] = 1;
            matrix[7, 6] = 1;
            matrix[7, 8] = 1;
            matrix[8, 7] = 1;
            matrix[8, 9] = 1;
            matrix[9, 8] = 1;
            return matrix;
        }
    }

    class PandigitalStepBuilder
    {
        private readonly int lastUsedDigit;
        private readonly string bigNumber;
        private bool containsNine;
        private bool containsZero;

        public PandigitalStepBuilder(int seedDigit)
        {
            lastUsedDigit = seedDigit;
            bigNumber += seedDigit;
            if (seedDigit == 0)
            {
                containsZero = true;
            }
            else if (seedDigit == 9)
            {
                containsNine = true;
            }
        }

        private PandigitalStepBuilder(string parentString, int nextDigit)
        {
            bigNumber = parentString + nextDigit;
            lastUsedDigit = nextDigit;
        }

        public int size()
        {
            return bigNumber.Length;
        }

        public List<PandigitalStepBuilder> createNextSteps()
        {
            int stepUp = lastUsedDigit + 1;
            int stepDown = lastUsedDigit - 1;

            List<PandigitalStepBuilder> nexts = new List<PandigitalStepBuilder>();

            if (containsNine)
            {
                if (Program.sizeLimit - bigNumber.Length < lastUsedDigit)
                {
                    return new List<PandigitalStepBuilder>();
                }
            }
            if (containsZero)
            {
                if (Program.sizeLimit - bigNumber.Length < (9 - lastUsedDigit))
                {
                    return new List<PandigitalStepBuilder>();
                }
            }

            if (stepUp != 10)
            {
                PandigitalStepBuilder up = new PandigitalStepBuilder(bigNumber, stepUp);
                up.containsNine = stepUp == 9;
                up.containsZero = containsZero;
                nexts.Add(up);
            }
            if (stepDown != -1)
            {
                PandigitalStepBuilder down = new PandigitalStepBuilder(bigNumber, stepDown);
                down.containsNine = containsNine;
                down.containsZero = stepDown == 0;
                nexts.Add(down);
            }
            return nexts;
        }

        public string getBigNumber()
        {
            return bigNumber;
        }

        public override string ToString()
        {
            return bigNumber;
        }
    }

}
