using SampleLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    internal class DataProvider : IDataProvider
    {
        private ISourceReader sourceReader;

        public DataProvider(ISourceReader sourceReader)
        {
            this.sourceReader = sourceReader ?? throw new ArgumentNullException(nameof(sourceReader));
        }

        public Dictionary<string, string> GetAllDataFromSource(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException($"'{nameof(source)}' cannot be null or whitespace.", nameof(source));
            }

            var result = new Dictionary<string, string>();

            foreach (var file in sourceReader.GetAllSourceNames(source))
            {
                result.Add(file, sourceReader.ReadSource(file));
                
            }

            return result;
        }
    }
}
