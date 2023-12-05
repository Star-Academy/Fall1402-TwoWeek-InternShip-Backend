using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary.Abstraction
{
    internal interface ISourceReader
    {
        IReadOnlyCollection<string> GetAllSourceNames(string sourcePath);

        string ReadSource(string sourcePath, string sourceName);
    }
}
