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
    public class DataProviderTest
    {
        private readonly IDataProvider _sut;
        private readonly ISourceReader _sourceReader;

        public DataProviderTest()
        {
            _sourceReader = Substitute.For<ISourceReader>();
            _sut = new DataProvider(_sourceReader);
        }

        [Fact]
        public void GetAllDataFromSource_ShouldReturnADictionaryContainingSourceNameAndSourceData_WhenThereIsOnlyOneSourceInSourcePath()
        {
            // Arrange
            var sourceDirectory = "some source";
            var expected = new Dictionary<string, string>
            {
                {"key1", "value1" }
            };

            _sourceReader.GetAllSourceNames(sourceDirectory).Returns(["key1"]);
            _sourceReader.ReadSource("key1").Returns("value1");


            // Act
            var actual = _sut.GetAllDataFromSource(sourceDirectory);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAllDataFromSource_ShouldReturnADictionaryOfAllSourceNamesAndSourceData_WhenThereIsMultipleSourcesAtSourceDirectory()
        {
            // Arrange
            var sourceDirectory = "some source";
            var expected = new Dictionary<string, string>
            {
                {"key1", "value1" },
                {"key2", "value2" },
                {"key3", "value3" }
            };

            _sourceReader.GetAllSourceNames(sourceDirectory).Returns(expected.Keys);
            _sourceReader.ReadSource("key1").Returns("value1");
            _sourceReader.ReadSource("key2").Returns("value2");
            _sourceReader.ReadSource("key3").Returns("value3");

            // Act
            var actual = _sut.GetAllDataFromSource(sourceDirectory);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GetAllDataFromSource_ShouldThrowArgumentException_WhenSourceDirectoryIsNullOrEmpty(string sourceDirectory)
        {
            // Arrange


            // Act
            var action = () => _sut.GetAllDataFromSource(sourceDirectory);

            // Assert
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("source");
        }

        [Fact]
        public void GetAllDataFromSource_ShouldReturnEmptyDictionary_WhenThereIsNoSourceInSourceDirectory()
        {
            // Arrange
            var sourceDirectory = "some source";
            var expected = new Dictionary<string, string>();

            // Actt
            var actual = _sut.GetAllDataFromSource(sourceDirectory);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
