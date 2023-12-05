using SampleLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    public class Program
    {
        public static void Main()
        {
            const string sourceDirectory = "C:\\Users\\mhda1\\Documents\\VSCode\\Fall1402-TwoWeek-InternShip-Backend\\EnglishData\\";

            SourceReader sourceReader = new();
            DataProvider dataProvider = new(sourceReader);

            Dictionary<string, string> data = dataProvider.GetAllDataFromSource(sourceDirectory);

            DataProcessor dataProcessor = new();
            List<EntityStructure> processedData = dataProcessor.Process(data);
            
            InvertedIndexConstructor invertedIndexConstructor = new();

            InvertedIndex invertedIndex = invertedIndexConstructor.Build(processedData);

            const string givenQuery = "get help +illness +disease -cough";

            QueryInterpreter queryInterpreter = new();

            QueryObj query = queryInterpreter.Interpret(givenQuery);

            InvertedIndexQuerySearch querySearch = new InvertedIndexQuerySearch();

            var searchResult = querySearch.SearchQeury(invertedIndex, query);

            foreach(var res in searchResult)
            {
                Console.WriteLine(res);
            }
        }
    }
}
