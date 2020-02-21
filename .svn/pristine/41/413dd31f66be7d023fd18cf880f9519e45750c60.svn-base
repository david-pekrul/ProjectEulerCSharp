using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerLibrary
{
    public class Words
    {

    }

    public class TrieTree
    {
        private bool isWord;
        private char root;
        private Dictionary<char, TrieTree> charToNextTree;

        private TrieTree(char c, bool word)
        {
            root = c;
            isWord = word;
            charToNextTree = new Dictionary<char, TrieTree>();
        }

        public TrieTree()
        {
            root = '\0';
            isWord = false;
            charToNextTree = new Dictionary<char, TrieTree>();
        }

        

        public void addWord(string str)
        {
            if (str == "")
            {
                this.isWord = true;
                return;
            }

            char firstChar = str[0];
            string remainingString = str.Substring(1);
            if (charToNextTree.ContainsKey(firstChar))
            {
                TrieTree temp = charToNextTree[firstChar];
                temp.addWord(remainingString);
            }
            else
            {
                TrieTree temp = new TrieTree(firstChar, false);
                temp.addWord(remainingString);
                charToNextTree.Add(firstChar, temp);
            }
        }

        public bool isAWord(string searchString)
        {
            
            if (searchString == "")
            {
                return this.isWord;
            }

            char firstChar = searchString[0];
            string remainingString = searchString.Substring(1);
            if (charToNextTree.ContainsKey(firstChar))
            {
                return charToNextTree[firstChar].isAWord(remainingString);
            }

            return false;
        }


        public bool canBeAWord(string searchString)
        {
            if (searchString == "")
            {
                return isWord || (charToNextTree.Count != 0);
            }

            char firstChar = searchString[0];
            string remainingString = searchString.Substring(1);
            if (charToNextTree.ContainsKey(firstChar))
            {
                return charToNextTree[firstChar].canBeAWord(remainingString);
            }

            return false;
        }
    }
}

