using SampleLibrary;

namespace SearchWebAPI
{
    public class MyInvertedIndex
    {
        public InvertedIndex InvertedIndex { get; }

        public MyInvertedIndex()
        {
            const string sourceDirectory = "C:\\Users\\mhda1\\Documents\\VSCode\\Fall1402-TwoWeek-InternShip-Backend\\EnglishData\\";

            SourceReader sourceReader = new();
            DataProvider dataProvider = new(sourceReader);

            Dictionary<string, string> data = dataProvider.GetAllDataFromSource(sourceDirectory);

            DataProcessor dataProcessor = new();
            List<EntityStructure> processedData = dataProcessor.Process(data);

            InvertedIndexConstructor invertedIndexConstructor = new();

            InvertedIndex = invertedIndexConstructor.Build(processedData);
        }
    }
}
