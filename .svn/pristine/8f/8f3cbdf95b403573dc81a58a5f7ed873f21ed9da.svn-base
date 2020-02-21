using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler96
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("sudoku.txt");
            
            int answer = 0;
            while(!reader.EndOfStream)
            {
                SudokuSquare square = parseSudokuSquare(reader);
                solveSquare(square);
                Console.WriteLine(square);
                Console.WriteLine("---------------------------");
                answer += square.getFirstThreeNumbers();
            }
            Console.WriteLine("ANSWER: " + answer);
        }

        public static SudokuSquare parseSudokuSquare(StreamReader reader)
        {
            if(reader.EndOfStream)
            {
                return null;
            }
            reader.ReadLine();
            SudokuSquare square = new SudokuSquare();
            int row = 0;
            while(row!= SudokuSquare.MAX_SIZE)
            {
                string line = reader.ReadLine();
                for(int col = 0; col < SudokuSquare.MAX_SIZE; col++)
                {
                    byte num = byte.Parse(line[col].ToString());
                    square.updateCell(row, col, num);
                }
                row++;
            }
            return square;
        }

        static int solveSquare(SudokuSquare square)
        {
            Stack<FillSquareOperation> opStack = new Stack<FillSquareOperation>();
            while (!square.isComplete())
            {
                Tuple<int, int> cell = square.getNextEmptySquare();
                int x = cell.Item1;
                int y = cell.Item2;
                List<byte> possibleValues = square.getPossibleValues(x, y);
                FillSquareOperation op = new FillSquareOperation(x, y, square, possibleValues);
                bool worked = op.doAction();
                opStack.Push(op);
                while(!worked)
                {
                    op.undoAction();
                    if (!op.hasMoreOperations())
                    {
                        //this operation isn't possible
                        op = opStack.Pop();
                    }
                    worked = op.doAction();

                }

                opStack.Push(op);

            }

            return square.getFirstThreeNumbers();
        }
    }

    public class SudokuSquare
    {
        public static byte MAX_SIZE = 9;
        private byte[,] square;
        public SudokuSquare()
        {
            square = new byte[9, 9];
        }

        public Tuple<int, int> getNextEmptySquare()
        {
            for (int i = 0; i < MAX_SIZE; i++)
            {
                for (int j = 0; j < MAX_SIZE; j++)
                {
                    if (square[i, j] == 0)
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }
            return null;
        }

        public byte getCell(int x, int y)
        {
            return square[x, y];
        }

        public List<byte> getPossibleValues(int x, int y)
        {
            List<byte> possibleValues = new List<byte>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < MAX_SIZE; i++)
            {
                byte value = square[x, i];
                possibleValues.Remove(value);
                value = square[i, y];
                possibleValues.Remove(value);
            }

            int startCol = (y / 3) * 3;
            int startRow = (x / 3) * 3;
            List<int> colIndexes = new List<int>() { startCol, startCol + 1, startCol + 2 };
            List<int> rowIndexes = new List<int>() { startRow, startRow + 1, startRow + 2 };

            foreach (int col in colIndexes)
            {
                foreach (int row in rowIndexes)
                {
                    byte value = square[row, col];
                    value = square[row, col];
                    possibleValues.Remove(value);
                }
            }

            return possibleValues;
        }

        public void updateCell(int x, int y, byte val)
        {
            square[x, y] = val;
        }

        public bool validateCell(int x, int y)
        {
            return validateRow(x) && validateColumn(y) && validateSubSquare(x, y);
        }

        private bool validateRow(int x)
        {
            byte[] check = new byte[MAX_SIZE+1];
            for (int i = 0; i < MAX_SIZE; i++)
            {
                int value = square[x, i];
                check[value]++;
                if (value != 0 && check[value] > 1)
                {
                    return false;
                }
            }
            return true;
        }

        private bool validateColumn(int y)
        {
            byte[] check = new byte[MAX_SIZE+1];
            for (int i = 0; i < MAX_SIZE; i++)
            {
                int value = square[i, y];
                check[value]++;
                if (value != 0 && check[value] > 1)
                {
                    return false;
                }
            }
            return true;
        }

        private bool validateSubSquare(int x, int y)
        {
            int startCol = (y / 3)*3;
            int startRow = (x / 3)*3;
            List<int> colIndexes = new List<int>() { startCol, startCol + 1, startCol + 2 };
            List<int> rowIndexes = new List<int>() { startRow, startRow + 1, startRow + 2 };

            byte[] check = new byte[MAX_SIZE+1];
            foreach (int col in colIndexes)
            {
                foreach (int row in rowIndexes)
                {
                    int value = square[row, col];
                    check[value]++;
                    if (value != 0 && check[value] > 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool isComplete()
        {
            foreach (byte b in square)
            {
                if (b == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public int getFirstThreeNumbers()
        {
            return square[0, 0]*100 + square[0, 1]*10 + square[0, 2];
        }

        public override string ToString()
        {
            string output = "";
            for(int i = 0; i < MAX_SIZE; i++)
            {
                for(int j = 0; j < MAX_SIZE; j++)
                {
                    output += "" + square[i, j] + ", ";
                }
                output += "\r\n";
            }
            return output;
        }
    }


    public class FillSquareOperation
    {
        private List<byte> possibleValues;
        private int x, y;
        private SudokuSquare square;
        private bool lastMoveWorked;
        public FillSquareOperation(int x, int y, SudokuSquare square, List<byte> values)
        {
            this.x = x;
            this.y = y;
            this.possibleValues = new List<byte>(values);
            this.square = square;
            lastMoveWorked = false;
        }

        public bool doAction()
        {

            if (possibleValues.Count == 0)
            {
                return false;
            }
            byte newVal = possibleValues[0];
            possibleValues.RemoveAt(0);
            //Console.WriteLine("DOING:: X:" + x.ToString() + ", Y: " + y.ToString() + ", V: " + newVal.ToString());
            square.updateCell(x, y, newVal);
            lastMoveWorked = square.validateCell(x, y);
            return lastMoveWorked;
        }

        public void undoAction()
        {
            //Console.WriteLine("\tUNDOING:: X:" + x.ToString() + ", Y: " + y.ToString() + ", V: " + 0);
            square.updateCell(x, y, 0);
        }

        public bool hasMoreOperations()
        {
            return possibleValues.Count != 0;
        }

        public bool didLastMoveWork()
        {

            return lastMoveWorked;
        }
    }
}