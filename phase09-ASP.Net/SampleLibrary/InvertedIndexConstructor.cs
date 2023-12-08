using SampleLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace SampleLibrary
{
    internal class InvertedIndexConstructor : IInvertedIndexConstructor
    {
        public InvertedIndex Build(List<EntityStructure> processedData)
        {
            if (processedData is null)
            {
                throw new ArgumentNullException(nameof(processedData));
            }

            InvertedIndex result = new InvertedIndex();

            foreach (var entity in processedData)
            {
                if (result.Contains(entity.word))
                {
                    result.AddSourceNames(entity.word, entity.sourceNames);
                }
                else
                {
                    result.Add(entity.word, entity.sourceNames);
                }

            }

            return result;
        }
    }
}
