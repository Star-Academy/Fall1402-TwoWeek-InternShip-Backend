using SampleLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    internal class InvertedIndexNecessaryWordFinder : IWordFinder<InvertedIndex>
    {
        public HashSet<string> Find(InvertedIndex source, List<string> words)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (words is null)
            {
                throw new ArgumentNullException(nameof(words));
            }

            var result = new HashSet<string>();

            foreach(var word in words)
            {
                var search_result = source.table.GetValueOrDefault(word, []);

                if (result.Count == 0)
                {
                    result.UnionWith(search_result);
                }
                else
                {
                    result.IntersectWith(search_result);
                }
            }

            return result;
        }
    }
}
