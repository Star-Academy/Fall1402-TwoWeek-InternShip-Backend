using FluentAssertions;
using SampleLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleLibrary.Test
{
    public class ResultPrinterTest
    {
        private ResultPrinter _sut;
        private StringWriter _writer;

        public ResultPrinterTest()
        {
            _writer = new StringWriter();
            _sut = new ResultPrinter(_writer);
        }

        [Fact]
        public void Print_ShouldPrintResult_WhenResultIsNotEmptyOrNull()
        {
            // Arrange
            HashSet<string> result = new HashSet<string>();
            result.Add("res1");
            result.Add("res2");

            var expected = "Search result: \r\nres1\r\nres2\r\n";

            // Act
            _sut.Print(result);
            var actual = _writer.ToString();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Print_ShoulrPrintNothing_WhenResultIsEmpty()
        {
            // Arrange
            HashSet<string> result = new HashSet<string>();
            
            var expected = "Search result: \r\n";

            // Act
            _sut.Print(result);
            var actual = _writer.ToString();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Print_ShouldThrowArgumentExceptionWhenResultIsNull()
        {
            // Arrange

            // Act
            var action = () => _sut.Print(null);

            // Assert
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("result");
        }
    }
}
