using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleLibrary.Test
{
    public class QueryUnnecessaryForbiddenWordCategorizerTest
    {
        private QueryUnnecessaryWordCategorizer _sut;

        public QueryUnnecessaryForbiddenWordCategorizerTest()
        {
            _sut = new QueryUnnecessaryWordCategorizer('-');
        }

        [Theory]
        [InlineData(new[] { "get", "+illness", "-cough" }, new[] { "cough" })]
        [InlineData(new string[] { }, new string[] { })]
        [InlineData(new[] { "+illness", "fever" }, new string[] { })]
        [InlineData(new[] { "-get" }, new[] { "get" })]
        public void Categorize_ShouldReturnAllForbiddenWordsInsideSplittedqeury_WhenQueryIsValid(string[] splittedQeury, string[] expected)
        {
            // Arrange


            // Act
            var actual = _sut.Categorize(splittedQeury);

            // Arrange
            actual.Should().Equal(expected);
        }

        [Fact]
        public void Categorize_ShouldThrowArgumentException_WhenSplittedQueryIsNull()
        {
            // Arrange

            // Act
            var action = () => _sut.Categorize(null);

            // Assert
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("splittedQuery");
        }
    }
}
