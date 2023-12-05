using SampleLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    public class QueryNecessaryWordCategorizer : IQueryWordCategorizer
    {
        public List<string> Categorize(string[] splittedQuery)
        {
            if (splittedQuery is null)
            {
                throw new ArgumentNullException(nameof(splittedQuery));
            }

            List<string> result = [];

            foreach (string word in splittedQuery)
            {
                if (!word.StartsWith('+') && !word.StartsWith('-'))
                {
                    result.Add(word);
                }
            }
            
            return result;
        }
    }
}
