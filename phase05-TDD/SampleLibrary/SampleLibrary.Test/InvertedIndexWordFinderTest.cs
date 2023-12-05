using FluentAssertions;
using NSubstitute;
using SampleLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleLibrary.Test
{
    public class InvertedIndexWordFinderTest
    {
        private InvertedIndexWordFinder _sut;

        public InvertedIndexWordFinderTest()
        {
            _sut = new InvertedIndexWordFinder();
        }

        [Fact]
        public void Find_ShouldReturnEmptyAnswer_WhenWordDoesNotExistInInvertedIndex()
        {
            // Arrange
            InvertedIndex invertedIndex = new InvertedIndex();
            invertedIndex.Add("word1", new HashSet<string> { "file1", "file2" });

            var expected = new HashSet<string>();

            // Act
            var actual = _sut.Find(invertedIndex, "word2");

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Find_ShouldReturnSourceNames_WhenWordDoesExistInInvertedIndex()
        {
            // Arrange
            InvertedIndex invertedIndex = new InvertedIndex();
            invertedIndex.Add("word1", new HashSet<string> { "file1", "file2" });

            var expected = new HashSet<string> { "file1", "file2"};

            // Act
            var actual = _sut.Find(invertedIndex, "word1");

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Find_ShouldThrowArgumentException_WhenWordIsNull(string word)
        {
            // Arrange
            InvertedIndex invertedIndex = new InvertedIndex();
            invertedIndex.Add("word1", new HashSet<string> { "file1", "file2" });

            // Act
            var action = () => _sut.Find(invertedIndex, word);

            // Assert
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("word");
        }

        [Fact]
        public void Find_shouldThrowArguemntException_WhenInvertedIndexIsNull()
        {
            // Arrange
            InvertedIndex invertedIndex = null;

            // Act
            var action = () => _sut.Find(invertedIndex, "word");

            // Assert
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("source");
        }
    }
}
