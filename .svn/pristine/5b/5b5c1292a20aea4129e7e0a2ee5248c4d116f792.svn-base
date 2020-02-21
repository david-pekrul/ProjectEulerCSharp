using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler81
{
    class Program
    {
        static int matrixSize = 0;
        static void Main(string[] args)
        {
            matrixSize = 80;
            int[,] array = new int[matrixSize, matrixSize];
            TreeNode[,] treeNodes = new TreeNode[matrixSize, matrixSize];
            StreamReader reader = new StreamReader("matrix.txt");
            int col = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] words = line.Split(',');
                for (int i = 0; i < matrixSize; i++)
                {
                    array[i,col] = Int32.Parse(words[i]);
                    treeNodes[i,col] = new TreeNode(array[i,col]);
                }
                col++;
            }

            
            for(int i = 0; i < matrixSize; i++)
            {
                for(int j = 0; j < matrixSize; j++)
                {
                    TreeNode temp = treeNodes[i, j];
                    int u = j-1;
                    int d = j+1;
                    int r = i+1;
                    int l = i-1;
                    if(u >= 0 && u < matrixSize)
                    {
                        temp.Up = treeNodes[i, u];
                    }
                    if (d >= 0 && d < matrixSize)
                    {
                        temp.Down = treeNodes[i, d];
                    }

                    if (r >= 0 && r < matrixSize)
                    {
                        temp.Right = treeNodes[r, j];
                    }
                    if (l>= 0 && l < matrixSize)
                    {
                        temp.Left = treeNodes[l, j];
                    }
                }
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            
            queue.Enqueue(treeNodes[matrixSize-1, matrixSize-1]);
            
            while(queue.Count != 0)
            {
                TreeNode temp = queue.Dequeue();
                temp.compute();
                TreeNode l = temp.Left;
                if(l != null && !queue.Contains(l))
                {
                    queue.Enqueue(l);
                }
                TreeNode u = temp.Up;
                if(u != null && !queue.Contains(u))
                {
                    queue.Enqueue(u);
                }
            }

            Console.WriteLine(treeNodes[0,0].cost);


        }

        class TreeNode
        {
            private TreeNode down;
            private TreeNode up;
            private TreeNode left;
            private TreeNode right;
            private int value;
            private bool alreadyDecided;
            public int cost = 0;

            public TreeNode(int v)
            {
                value = v;
                alreadyDecided = false;
            }

            public TreeNode Down
            {
                get { return down; }
                set { down = value; }
            }

            public TreeNode Up
            {
                get { return up; }
                set { up = value; }
            }

            public TreeNode Left
            {
                get { return left; }
                set { left = value; }
            }

            public TreeNode Right
            {
                get { return right; }
                set { right = value; }
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Value: " + value);
                if(Right!= null)
                {
                    sb.Append(" R: " + Right.value);
                }
                if (Left != null)
                {
                    sb.Append(" L: " + Left.value);
                }
                if (Up != null)
                {
                    sb.Append(" U: " + Up.value);
                }
                if (Down != null)
                {
                    sb.Append(" D: " + Down.value);
                }
                return sb.ToString();
            }
        
            public void compute()
            {
                if(Down == null && Right == null)
                {
                    cost = value;
                    return;
                }
                if(Down == null)
                {
                    cost = value + Right.cost;
                    return;
                }
                if(Right == null)
                {
                    cost = value + Down.cost;
                    return;
                }
                cost = Math.Min(Right.cost, Down.cost) + value;
            }

            

        }
    }
}
