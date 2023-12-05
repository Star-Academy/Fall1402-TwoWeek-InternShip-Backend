using SampleLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    public class SourceReader : ISourceReader
    {
        public IReadOnlyCollection<string> GetAllSourceNames(string sourcePath)
        {
            List<string> sources = [];

            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);

                sources =
                [
                    .. Directory.GetFiles(sourcePath, "*", SearchOption.TopDirectoryOnly),
                ];


            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }

            var readOnlyList = new ReadOnlyCollection<string>(sources);

            return readOnlyList;
        }

        public string ReadSource(string sourcePath)
        {
            string text = "";

            try
            {
                text = File.ReadAllText(sourcePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return text;
        }
    }
}
