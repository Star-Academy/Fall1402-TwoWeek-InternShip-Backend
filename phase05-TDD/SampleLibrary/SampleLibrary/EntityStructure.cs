using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    internal class EntityStructure
    {
        public string word;
        public HashSet<string> sourceNames;

        public EntityStructure(string givenWord, HashSet<string> givenSourceNames)
        {
            word = givenWord;
            sourceNames = givenSourceNames;
        }
    }
}
