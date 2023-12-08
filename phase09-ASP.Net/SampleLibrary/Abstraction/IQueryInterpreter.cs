using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary.Abstraction
{
    public interface IQueryInterpreter
    {
        QueryObj Interpret(string query);
    }
}
