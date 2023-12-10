using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using SimpleCalculator.Business.Abstraction;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.OperatorBusiness;
using SimpleCalculator.Business.OperatorBusiness.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.Business.Tests
{
    public class SimpleCalculatorTest
    {
        private readonly ICalculator _sut;
        private readonly IOperatorProvider _operatorProvider;

        public SimpleCalculatorTest()
        {
            _operatorProvider = Substitute.For<IOperatorProvider>();
            _sut = new SimpleCalculator(_operatorProvider);
        }

        [Fact]
        public void Calculate_ShouldReturnOperatorResult_WhenEver()
        {
            // Arrange
            var first = 2;
            var second = 3;
            var sumOperator = OperatorEnum.sum;
            var expected = 123;

            var mockedOperator = Substitute.For<IOperator>();
            _operatorProvider.GetOperator(sumOperator).Returns(mockedOperator);

            mockedOperator.Calculate(first, second).Returns(expected);

            // Act
            var actual = _sut.Calculate(first, second, sumOperator);

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public void Calculate_ShouldThrowOperatorsException_WhenOperatorThrowsException()
        {
            // Arrange
            var first = 2;
            var second = 3;
            var sumOperator = OperatorEnum.sum;

            var mockedOperator = Substitute.For<IOperator>();
            _operatorProvider.GetOperator(sumOperator).Returns(mockedOperator);

            mockedOperator.Calculate(first, second).Throws<OperatorException>();

            // Act
            var action = () => _sut.Calculate(first, second, sumOperator);

            // Assert
            action.Should().Throw<OperatorException>();
        }

        public class OperatorException : Exception
        {

        }

        //[Theory]
        //[InlineData(2, 3, OperatorEnum._)]
        //public void CalculatorTestInvalidOperator(int first, int second, OperatorEnum operatorEnum)
        //{
        //    Calculator calculator = new();

        //    Assert.Throws<NotSupportedException>(() => calculator.Calculate(first, second, operatorEnum);
        //}
    }
}
