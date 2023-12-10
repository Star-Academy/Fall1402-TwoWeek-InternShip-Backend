using SampleLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    internal class DataProcessor : IDataProcessor
    {
        public List<EntityStructure> Process(Dictionary<string, string> data)
        {
            if (data is null)
            {
                throw new ArgumentException(nameof(data));
            }

            List<EntityStructure> result = new List<EntityStructure>();

            foreach (string sourceName in data.Keys)
            {
                string[] splittedData = data[sourceName].Split(new char[] { ' ' });
                foreach (string word in splittedData)
                {
                    EntityStructure entity = new EntityStructure(word, new HashSet<string> { sourceName });
                    result.Add(entity);
                }

            }

            return result;
        }
    }
}
