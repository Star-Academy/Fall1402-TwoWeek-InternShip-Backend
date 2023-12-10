using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    public class QueryObj
    {
        public List<string> necessaryWords;
        public List<string> orWords;
        public List<string> forbiddenWords;

        public QueryObj(List<string> givenNecessaryWords, List<string> givenOrWords, List<string> givenForbiddenWords)
        {
            this.necessaryWords = givenNecessaryWords;
            this.orWords = givenOrWords;
            this.forbiddenWords = givenForbiddenWords;
        }
    }
}
