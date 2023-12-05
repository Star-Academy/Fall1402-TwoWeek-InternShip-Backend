using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleLibrary.Test
{
    public class InvertedIndexUnnecessaryWordFinderTest
    {
        private InvertedIndexUnnecessaryWordFinder _sut;

        public InvertedIndexUnnecessaryWordFinderTest()
        {
            _sut = new InvertedIndexUnnecessaryWordFinder();
        }

        [Fact]
        public void Find_ShouldReturnUnnecessaryWordsSourceNames_WhenThereIsOnlyOneEntryInInvertedIndexAndWeHaveOneUnnecessaryWordToSearch()
        {
            // Assign
            InvertedIndex invertedIndex = new();
            invertedIndex.Add("word1", ["File1", "File2"]);

            var expected = new HashSet<string> { "File1", "File2" };

            // Act
            var actual = _sut.Find(invertedIndex, ["word1"]);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Find_ShouldReturnUnnecessaryWordsSourceNames_WhenThereAreMoreThanOneEntryInInvertedIndexAndWeHaveOneUnnecessaryWordToSearch()
        {
            // Assign
            InvertedIndex invertedIndex = new();
            invertedIndex.Add("word1", ["File1", "File2", "File3"]);
            invertedIndex.Add("word2", ["File1", "File2", "File3"]);
            invertedIndex.Add("word3", ["File1", "File2", "File3"]);

            var expected = new HashSet<string> { "File1", "File2", "File3" };

            // Act
            var actual = _sut.Find(invertedIndex, ["word1"]);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Find_ShouldReturnNecessaryWordsSourceNames_WhenThereAreMoreThanOneEntryInInvertedIndexAndWeHaveMoreThanOneUnnecessaryWordToSearchAndWords()
        {
            // Assign
            InvertedIndex invertedIndex = new();
            invertedIndex.Add("word1", ["File1", "File3", "File4"]);
            invertedIndex.Add("word2", ["File1", "File2", "File3"]);
            invertedIndex.Add("word3", ["File1", "File4", "File7"]);

            var expected = new HashSet<string> { "File1", "File3", "File4", "File7" };

            // Act
            var actual = _sut.Find(invertedIndex, ["word1", "word3"]);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Find_ShouldReturnEmptyHashSet_WhenThereIsNoEntryInInvertedIndex()
        {
            // Assign
            InvertedIndex invertedIndex = new();

            var expected = new HashSet<string> { };

            // Act
            var actual = _sut.Find(invertedIndex, ["word1", "word3"]);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Find_ShouldThrowException_WhenInvertedIndexIsNull()
        {
            // Assign

            // Act
            var action = () => _sut.Find(null, ["word1", "word3"]);

            // Assert
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("source");
        }

        [Fact]
        public void Find_ShouldThrowException_WhenWordsIsNull()
        {
            // Assign
            InvertedIndex invertedIndex = new();

            // Act
            var action = () => _sut.Find(invertedIndex, null);

            // Assert
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("words");
        }
    }
}
