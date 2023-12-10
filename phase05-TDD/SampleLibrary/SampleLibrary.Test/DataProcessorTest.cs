using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleLibrary.Test
{
    public class DataProcessorTest
    {
        private DataProcessor _sut;

        public DataProcessorTest()
        {
            _sut = new DataProcessor();
        }

        [Fact]
        public void Process_ShouldReturnAListOfEntityStructureThatEachEntityIncludesAWordAndItsSourceName_WhenThereIsOnlyOneEntryInGivenData()
        {
            // Arrange
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                {"file1", "there is a word" }
            };

            List<EntityStructure> expected = new List<EntityStructure>();
            EntityStructure e1 = new EntityStructure("there", new HashSet<string> { "file1" });
            EntityStructure e2 = new EntityStructure("is", new HashSet<string> { "file1" });
            EntityStructure e3 = new EntityStructure("a", new HashSet<string> { "file1" });
            EntityStructure e4 = new EntityStructure("word", new HashSet<string> { "file1" });
            expected.Add(e1);
            expected.Add(e2);
            expected.Add(e3);
            expected.Add(e4);

            // Act
            var actual = _sut.Process(data);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Process_ShouldReturnAListOfEntityStructureThatEachEntityIncludesAWordAndItsSourceName_WhenThereAreMultipleEntriesInGivenData()
        {
            // Arrange
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                {"file1", "there is a word" },
                {"file2", "another word" }
            };

            List<EntityStructure> expected = new List<EntityStructure>();
            EntityStructure e1 = new EntityStructure("there", new HashSet<string> { "file1" });
            EntityStructure e2 = new EntityStructure("is", new HashSet<string> { "file1" });
            EntityStructure e3 = new EntityStructure("a", new HashSet<string> { "file1" });
            EntityStructure e4 = new EntityStructure("word", new HashSet<string> { "file1" });
            EntityStructure e5 = new EntityStructure("another", new HashSet<string> { "file2" });
            EntityStructure e6 = new EntityStructure("word", new HashSet<string> { "file2" });

            expected.Add(e1);
            expected.Add(e2);
            expected.Add(e3);
            expected.Add(e4);
            expected.Add(e5);
            expected.Add(e6);

            // Act
            var actual = _sut.Process(data);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Process_ShouldThrowArgumentNullException_WhenThereIsNoData()
        {
            // Arrange

            // Act
            var action = () => _sut.Process(null);

            // Assert
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be(null);
        }

        [Fact]
        public void Process_ShouldReturnAnEmptyListOfEntityStructure_WhenThereIsNoEntryInData()
        {
            // Arrange
            Dictionary<string, string> data= new Dictionary<string, string>();

            List<EntityStructure> expected = new List<EntityStructure>();

            // Act
            var actual = _sut.Process(data);

            // Assert
            actual.Should().BeEquivalentTo(actual);
        }
    }
}
