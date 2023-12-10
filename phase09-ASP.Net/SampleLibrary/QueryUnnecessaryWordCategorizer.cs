using SampleLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    public class QueryUnnecessaryWordCategorizer : IQueryWordCategorizer
    {
        private readonly char _delimiter;

        public QueryUnnecessaryWordCategorizer(char _delimiter)
        {
            this._delimiter = _delimiter;
        }

        public List<string> Categorize(string[] splittedQuery)
        {
            if (splittedQuery is null)
            {
                throw new ArgumentNullException(nameof(splittedQuery));
            }

            List<string> result = [];

            foreach (string word in splittedQuery)
            {
                if(word.StartsWith(_delimiter))
                {
                    result.Add(word.Remove(0, 1));
                }
            }

            return result;
        }
    }
}
