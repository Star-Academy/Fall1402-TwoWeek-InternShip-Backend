using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleLibrary.Abstraction;

namespace SampleLibrary
{
    public class QueryInterpreter : IQueryInterpreter
    {
        public QueryObj Interpret(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentException($"'{nameof(query)}' cannot be null or empty.", nameof(query));
            }

            string[] splittedQuery = query.Split(' ');

            QueryNecessaryWordCategorizer necessaryCategorizer = new();
            List<string> necessaryWords = necessaryCategorizer.Categorize(splittedQuery);

            QueryUnnecessaryWordCategorizer orWordCategorizer = new('+');
            List<string> orWords = orWordCategorizer.Categorize(splittedQuery);

            QueryUnnecessaryWordCategorizer forbiddenCategorizer = new('-');
            List<string> forbiddenWords = forbiddenCategorizer.Categorize(splittedQuery);

            QueryObj result = new(necessaryWords, orWords, forbiddenWords);

            return result;
        }
    }
}
