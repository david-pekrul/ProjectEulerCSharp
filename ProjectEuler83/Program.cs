using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler83
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
            int row = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] words = line.Split(',');
                for (int i = 0; i < matrixSize; i++)
                {
                    array[row, i] = Int32.Parse(words[i]);
                    treeNodes[row, i] = new TreeNode(array[row, i]);
                }
                row++;
            }

            for (int Row = 0; Row < matrixSize; Row++)
            {
                for (int Col = 0; Col < matrixSize; Col++)
                {
                    TreeNode temp = treeNodes[Row, Col];
                    int u = Row - 1;
                    int d = Row + 1;
                    int r = Col + 1;
                    int l = Col - 1;
                    if (u >= 0 && u < matrixSize)
                    {
                        temp.Up = treeNodes[u,Col];
                    }
                    if (d >= 0 && d < matrixSize)
                    {
                        temp.Down = treeNodes[d, Col];
                    }

                    if (r >= 0 && r < matrixSize)
                    {
                        temp.Right = treeNodes[Row, r];
                    }
                    if (l >= 0 && l < matrixSize)
                    {
                        temp.Left = treeNodes[Row, l];
                    }
                }
            }

            Dictionary<TreeNode, int> nodeToCost = new Dictionary<TreeNode, int>();
            Dictionary<TreeNode, TreeNode> nodeToPreviousNode = new Dictionary<TreeNode, TreeNode>();
            
            HashSet<TreeNode> Q = new HashSet<TreeNode>();

            foreach (TreeNode t in treeNodes)
            {
                nodeToCost.Add(t, int.MaxValue);
                Q.Add(t);
            }

            nodeToCost[treeNodes[0, 0]] = 0;

            while (Q.Count != 0)
            {
                TreeNode u = null;
                int dist = int.MaxValue;
                foreach (TreeNode t in Q)
                {
                    if (nodeToCost[t] < dist)
                    {
                        dist = nodeToCost[t];
                        u = t;
                    }
                }
                if (u == null || dist == int.MaxValue)
                {
                    break;
                }
                Q.Remove(u);
                List<TreeNode> neighbors = u.getNeighbors();
                foreach (TreeNode neighbor in neighbors)
                {
                    if (!Q.Contains(neighbor))
                    {
                        continue;
                    }
                    int tempDistance = nodeToCost[u] + neighbor.getValue();
                    if (tempDistance < nodeToCost[neighbor])
                    {
                        nodeToCost[neighbor] = tempDistance;
                        if (nodeToPreviousNode.ContainsKey(neighbor))
                        {
                            nodeToPreviousNode[neighbor] = u;
                        }
                        else
                        {
                            nodeToPreviousNode.Add(neighbor, u);
                        }
                    }
                }
            }
            TreeNode lastNode = treeNodes[matrixSize - 1, matrixSize - 1];
            Console.WriteLine("ANSWER: " + (nodeToCost[lastNode] + treeNodes[0,0].getValue()));
            Console.WriteLine("\n");
            TreeNode tempP = lastNode;
            while(nodeToPreviousNode.ContainsKey(tempP))
            {
                Console.WriteLine("\t" + tempP.getValue());
                tempP = nodeToPreviousNode[tempP];
            }




        }

        class TreeNode
        {
            private TreeNode down;
            private TreeNode up;
            private TreeNode left;
            private TreeNode right;
            private int value;

            public TreeNode(int v)
            {
                value = v;
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

            public int getValue()
            {
                return value;
            }

            public List<TreeNode> getNeighbors()
            {
                List<TreeNode> list = new List<TreeNode>();
                if (Up != null)
                {
                    list.Add(Up);
                }
                if (Down != null)
                {
                    list.Add(Down);
                }
                if (Left != null)
                {
                    list.Add(Left);
                }
                if (Right != null)
                {
                    list.Add(Right);
                }
                return list;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Value: " + value);
                if (Right != null)
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


        }
    }
}
