using SampleLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    public class InvertedIndexWordFinder : IWordFinder<InvertedIndex>
    {
        public HashSet<string> Find(InvertedIndex source, string word)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException($"'{nameof(word)}' cannot be null or empty.", nameof(word));
            }

            return source.table?.GetValueOrDefault(word, []) ?? [];
        }
    }
}
