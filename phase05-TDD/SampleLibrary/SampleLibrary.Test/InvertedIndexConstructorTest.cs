using Castle.Components.DictionaryAdapter.Xml;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace SampleLibrary.Test
{
    public class InvertedIndexConstructorTest
    {
        private InvertedIndexConstructor _sut;

        public InvertedIndexConstructorTest()
        {
            _sut = new InvertedIndexConstructor();
        }

        [Fact]
        public void Build_ShouldReturnConstructedInvertedIndexBasedOnProcessedData_WhenThereIsOnlyOneEntryInProcessedData()
        {
            // Arrange
            var processedData = new List<EntityStructure>();
            var entry = new EntityStructure("word", new HashSet<string> { "file1" });
            processedData.Add(entry);

            var expected = new InvertedIndex();
            expected.Add(entry.word, entry.sourceNames);

            // Act
            var actual = _sut.Build(processedData);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Build_ShouldReturnConstructedInvertedIndexBasedOnProcessedData_WhenThereAreMultipleNotRepeatedEntriesInProcessedData()
        {
            // Arrange
            var processedData = new List<EntityStructure>();
            var entry1 = new EntityStructure("word", new HashSet<string> { "file1" });
            var entry2 = new EntityStructure("word2", new HashSet<string> { "file2" });
            processedData.Add(entry1);
            processedData.Add(entry2);

            var expected = new InvertedIndex();
            expected.Add(entry1.word, entry1.sourceNames); ;
            expected.Add(entry2.word, entry2.sourceNames); ;

            // Act
            var actual = _sut.Build(processedData);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Build_ShouldReturnConstructedInvertedIndexBasedOnProcessedData_WhenThereAreMultipleRepeatedEntriesInProcessedData()
        {
            // Arrange
            var processedData = new List<EntityStructure>();
            var entry1 = new EntityStructure("word", new HashSet<string> { "file1" });
            var entry2 = new EntityStructure("word", new HashSet<string> { "file2" });
            processedData.Add(entry1);
            processedData.Add(entry2);

            var expected = new InvertedIndex();
            var entry3 = new EntityStructure("word", new HashSet<string> { "file1", "file2" });
            expected.Add(entry3.word, entry3.sourceNames);

            // Act
            var actual = _sut.Build(processedData);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Build_ShouldThrowArgumentExcetpion_WhenProcessedDataIsNull()
        {
            // Arragne

            //Act
            var action = () => _sut.Build(null);

            //Assert
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("processedData");
        }

        [Fact]
        public void Build_ShouldReturnAnEmptyInvertedIndex_WhenProcessedDataIsEmpty()
        {
            // Arrange
            List<EntityStructure> processedData = new List<EntityStructure>();
            InvertedIndex expected = new InvertedIndex();

            // Act
            var actual = _sut.Build(processedData);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
