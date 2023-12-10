using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary.Abstraction
{
    public interface IWordFinder<T>
    {
        public HashSet<string> Find(T source, List<string> words);
    }
}
