using SampleLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    internal class ResultPrinter : IResultPrinter
    {
        private StringWriter _outputWriter;

        public ResultPrinter(StringWriter outputWriter)
        {
            _outputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
        }

        public void Print(HashSet<string> result)
        {
            if (result is null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            _outputWriter.WriteLine("Search result: ");

            foreach(string entry in result)
            {
                _outputWriter.WriteLine(entry);
            }
        }
    }
}
