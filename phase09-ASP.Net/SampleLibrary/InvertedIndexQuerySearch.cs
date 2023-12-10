using SampleLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    internal class InvertedIndexQuerySearch : IInvertedIndexQuerySearch
    {
        public HashSet<string> SearchQeury(InvertedIndex invertedIndex, QueryObj queryObj)
        {
            if (invertedIndex is null)
            {
                throw new ArgumentNullException(nameof(invertedIndex));
            }

            if (queryObj is null)
            {
                throw new ArgumentNullException(nameof(queryObj));
            }

            InvertedIndexNecessaryWordFinder necessaryWordFinder = new();

            HashSet<string> necessarySources = necessaryWordFinder.Find(invertedIndex, queryObj.necessaryWords);

            InvertedIndexUnnecessaryWordFinder unnecessaryWordFinder = new();

            HashSet<string> orSources = unnecessaryWordFinder.Find(invertedIndex, queryObj.orWords);
            HashSet<string> forbiddenSources = unnecessaryWordFinder.Find(invertedIndex, queryObj.forbiddenWords);

            var result = new HashSet<string>(necessarySources.Intersect(orSources));
            var finalResult = new HashSet<string>(result.Except(forbiddenSources));

            return finalResult;
        }
    }
}
