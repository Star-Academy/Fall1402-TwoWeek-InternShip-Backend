using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleLibrary;
using SampleLibrary.Abstraction;
using SearchWebAPI;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly InvertedIndex _invertedIndex; // Replace with the actual class for your inverted index

    public SearchController()
    {
        MyInvertedIndex _myInvertedIndex = new();

        _invertedIndex = _myInvertedIndex.InvertedIndex;
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