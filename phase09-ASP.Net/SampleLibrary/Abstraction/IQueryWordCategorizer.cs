using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary.Abstraction
{
    public interface IQueryWordCategorizer
    {
        public List<string> Categorize(string[] splittedQuery);
    }
}
