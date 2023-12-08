using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleLibrary;
using SampleLibrary.Abstraction;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly InvertedIndex _invertedIndex; // Replace with the actual class for your inverted index

    public SearchController()
    {
        const string sourceDirectory = "C:\\Users\\mhda1\\Documents\\VSCode\\Fall1402-TwoWeek-InternShip-Backend\\EnglishData\\";

        SourceReader sourceReader = new();
        DataProvider dataProvider = new(sourceReader);

        Dictionary<string, string> data = dataProvider.GetAllDataFromSource(sourceDirectory);

        DataProcessor dataProcessor = new();
        List<EntityStructure> processedData = dataProcessor.Process(data);

        InvertedIndexConstructor invertedIndexConstructor = new();

        _invertedIndex = invertedIndexConstructor.Build(processedData);
    }

    [HttpGet]
    public IActionResult Get([FromQuery] string givenQuery)
    {
        if (string.IsNullOrWhiteSpace(givenQuery))
        {
            return BadRequest("Please provide a search query");
        }

        QueryInterpreter queryInterpreter = new();

        QueryObj query = queryInterpreter.Interpret(givenQuery);

        InvertedIndexQuerySearch querySearch = new InvertedIndexQuerySearch();

        var searchResult = querySearch.SearchQeury(_invertedIndex, query);

        return Ok(new { Results = searchResult });
    }
}