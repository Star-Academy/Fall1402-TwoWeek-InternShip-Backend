using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleLibrary.Test
{
    public class QueryNecessaryWordCategorizerTest
    {
        private QueryNecessaryWordCategorizer _sut;

        public QueryNecessaryWordCategorizerTest()
        {
            _sut = new QueryNecessaryWordCategorizer();
        }

        [Theory]
        [InlineData(new[] { "get", "+illness", "-cough" }, new[] { "get" })]
        [InlineData(new string[] { }, new string[] { })]
        [InlineData(new[] { "+illness", "-fever" }, new string[] { })]
        [InlineData(new[] { "get" }, new[] { "get" })]
        public void Categorize_ShouldReturnAllNecessaryWordsInsideSplittedQuery_WhenQueryIsValid(string[] splittedQuery, string[] expected)
        {
            // Arrange


            // Act
            var actual = _sut.Categorize(splittedQuery);

            // Assert
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
