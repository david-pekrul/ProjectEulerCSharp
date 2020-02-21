using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler155
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Paper
    {
        private int size;
        public PaperSet set;
        public Paper(int i)
        {
            size = i;
            set = null;
        }

        public HashSet<Paper> createChildren()
        {
            HashSet<Paper> set = new HashSet<Paper>();
            for (int i = size+1; i <= 5 ; i++)
            {
                set.Add(new Paper(i));
            }
            return null;
        }

    }

    class PaperSet
    {
        public Paper parentPaper;
        private List<Paper> set;
        public PaperSet()
        {
            set = new List<Paper>();
            parentPaper = null;
        }

        public PaperSet(List<Paper> l, Paper parent)
        {
            set = new List<Paper>(l);
            parentPaper = parent;
        }

        public HashSet<PaperSet> createChildren()
        {
            return null;
        }
    }
}
