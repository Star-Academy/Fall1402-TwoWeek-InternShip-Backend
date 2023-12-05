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
        public void SearchQuery_ShouldReturnSearchResults_WhenInvertedIndexHasEntriesAndQueryIsValid()
        {
            // Assign
            InvertedIndex invertedIndex = new();
            invertedIndex.Add("NecessaryWord1", ["File1", "File2", "File3", "File4"]);
            invertedIndex.Add("NecessaryWord2", ["File2", "File3", "File4"]);
            invertedIndex.Add("OrWord1", ["File2"]);
            invertedIndex.Add("OrWord2", ["File3"]);
            invertedIndex.Add("OrWord3", ["File4"]);
            invertedIndex.Add("OrWord4", ["File5"]);
            invertedIndex.Add("ForbiddenWord1", ["File4"]);

            QueryObj queryObj = new(["NecessaryWord1", "NecessaryWord2"], ["OrWord1", "OrWord2", "OrWord3", "OrWord4"], ["ForbiddenWord1"]);

            var expected = new HashSet<string> { "File2", "File3" };

            // Act
            var actual = _sut.SearchQeury(invertedIndex, queryObj);

            // Assert
            actual.Should().BeEquivalentTo(expected);

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
