using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    public class InvertedIndex
    {
        public Dictionary<string, HashSet<string>> table;

        public InvertedIndex()
        {
            table = [];
        }

        public void Add(string word, HashSet<string> sourceNames)
        {
            table.Add(word, sourceNames);
        }

        public bool Contains(string word)
        {
            return table.ContainsKey(word);
        }

        public void AddSourceNames(string word, HashSet<string> newSourceNames)
        {
            var res = new HashSet<string>(table[word].Union(newSourceNames));
            table[word] = res;
        }
    }
}
