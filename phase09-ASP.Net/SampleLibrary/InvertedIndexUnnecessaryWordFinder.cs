using SampleLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    internal class InvertedIndexUnnecessaryWordFinder : IWordFinder<InvertedIndex>
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

            foreach (var word in words)
            {
                result.UnionWith(source.table.GetValueOrDefault(word, []));
            }

            return result;
        }
    }
}
