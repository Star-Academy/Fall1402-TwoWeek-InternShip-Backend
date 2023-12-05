using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleLibrary.Test
{
    public class InvertedIndexQuerySearchTest
    {
        private InvertedIndexQuerySearch _sut;

        public InvertedIndexQuerySearchTest()
        {
            _sut = new InvertedIndexQuerySearch();
        }

        [Fact]
        public void SearchQuery_ShouldReturnEmpty_WhenIvertedIndexIsEmpty()
        {
            // Assign
            InvertedIndex invertedIndex = new();
            QueryObj queryObj = new(["get"], ["illness"], ["cough"]);

            // Act
            var actual = _sut.SearchQeury(invertedIndex, queryObj);

            // Assert
            actual.Should().BeEmpty();
        }

        [Fact]
        public void SearchQuery_ShouldThrowException_WhenIvertedIndexIsNull()
        {
            // Assign
            QueryObj queryObj = new(["get"], ["illness"], ["cough"]);

            // Act
            var action = () => _sut.SearchQeury(null, queryObj);
            
            // Assert
            action.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("invertedIndex");
        }

        [Fact]
        public void SerachQuery_ShouldThrowException_WhenQueryIsNull()
        {
            // Assign
            InvertedIndex invertedIndex = new();

            // Act
            var action = () => _sut.SearchQeury(invertedIndex, null);

            // Assert
            action.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("queryObj");
        }
    }
}
