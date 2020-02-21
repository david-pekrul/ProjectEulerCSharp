using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler107
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] adj = new int[40, 40];
            StreamReader reader = new StreamReader("graph.txt");
            int count = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] ls = line.Split(',');
                for (int i = 0; i < 40; i++)
                {
                    if (ls[i] != "-")
                    {
                        adj[count, i] = Int32.Parse(ls[i]);
                    }
                }
                count++;
            }

            List<Node> nodes = new List<Node>();
            for (int i = 0; i < 40; i++)
            {
                Node n = new Node(i);
                nodes.Add(n);
                NodeGroup ng = new NodeGroup(n);
            }

            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < 40; i++)
            {
                for (int j = i; j < 40; j++)
                {
                    if (adj[i, j] != 0)
                    {
                        Edge e = new Edge(nodes[i], nodes[j], adj[i, j]);
                        edges.Add(e);
                    }
                }
            }

            edges.Sort((a, b) => a.weight.CompareTo(b.weight));

            int used = 0;
            int thrownOut = 0;

            foreach (Edge e in edges)
            {
                if (e.isSpanningEdge())
                {
                    e.combineNodeGroups();
                    used += e.weight;
                }
                else
                {
                    thrownOut += e.weight;
                }
            }

            Console.WriteLine("ANSWER: " + thrownOut);

            Console.WriteLine("DONE");



        }


    }

    class Edge
    {
        Node a;
        Node b;
        public int weight;

        public Edge(Node A, Node B, int w)
        {
            weight = w;
            a = A;
            b = B;
        }

        public bool isSpanningEdge()
        {
            return a.Parent != b.Parent;
        }

        public void combineNodeGroups()
        {
            NodeGroup combo = a.parentGroup.combine(b.parentGroup);
            a.parentGroup = combo;
            b.parentGroup = combo;
        }


        public override bool Equals(object obj)
        {
            if (!(obj is Edge))
            {
                return false;
            }
            Edge other = (Edge)obj;
            if (other.weight != this.weight)
            {
                return false;
            }

            if ((other.a == this.a && other.b == this.b) || (other.a == this.b && other.b == this.a))
            {
                return true;
            }
            return false;
        }
    }

    class Node
    {
        int nodeId;
        public NodeGroup parentGroup;
        public Node(int id)
        {
            nodeId = id;
            parentGroup = null;
        }

        public NodeGroup Parent
        {
            get { return parentGroup; }
            set { parentGroup = value; }
        }

    }

    class NodeGroup
    {
        public HashSet<Node> nodes;
        public NodeGroup(Node a)
        {
            nodes = new HashSet<Node>();
            nodes.Add(a);
            a.Parent = this;

        }

        private NodeGroup() { }

        public NodeGroup combine(NodeGroup other)
        {
            NodeGroup temp = new NodeGroup();
            HashSet<Node> hash = new HashSet<Node>();
            foreach (Node n in nodes)
            {
                hash.Add(n);
                n.Parent = temp;
            }
            foreach (Node n in other.nodes)
            {
                hash.Add(n);
                n.Parent = temp;
            }

            temp.nodes = hash;
            return temp;
        }
    }

}
