using FluentAssertions;
using NSubstitute;
using SampleLibrary.Abstraction;
using Xunit;

namespace SampleLibrary.Test;

public class QueryInterpreterTest
{
    private QueryInterpreter _sut;

    public QueryInterpreterTest()
    {
        _sut = new QueryInterpreter();
    }

    [Fact]
    public void QueryInterpreter_ShouldReturnAQueryObjectBasedOnGivenQuery_WhenQueryIsValid()
    {
        // Arrange
        var givenQuery = "get help +illness +disease -cough";
        List<string> necessaryWords = ["get", "help"];
        List<string> orWords = ["illness", "disease"];
        List<string> forbiddenWords = ["cough"];
        QueryObj expected = new(necessaryWords, orWords, forbiddenWords);

        // Act
        QueryObj actual = _sut.Interpret(givenQuery);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Interpret_ShouldThrowArgumentException_WhenSplittedQueryIsNullOrEmpty(string query)
    {
        // Arrange
        
        // Act
        var action = () => _sut.Interpret(query);

        // Assert
        action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("query");
        
    }
}