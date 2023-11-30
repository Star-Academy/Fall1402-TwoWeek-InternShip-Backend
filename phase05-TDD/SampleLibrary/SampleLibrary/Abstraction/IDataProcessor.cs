using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary.Abstraction
{
    internal interface IDataProcessor
    {
        List<EntityStructure> Process(Dictionary<string, string> data);
    }
}
