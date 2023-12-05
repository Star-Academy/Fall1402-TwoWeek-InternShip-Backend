using FluentAssertions;
using SimpleCalculator.Business.Abstraction;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.OperatorBusiness;
using SimpleCalculator.Business.OperatorBusiness.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.Business.Tests.OperatorBusiness
{
    public class OperatorProviderTest
    {
        [Theory]
        [InlineData(OperatorEnum.sum, typeof(SumOperator))]
        [InlineData(OperatorEnum.sub, typeof(SubOperator))]
        [InlineData(OperatorEnum.multiply, typeof(MultiplyOperator))]
        [InlineData(OperatorEnum.division, typeof(DivisionOperator))]
        public void GetOperator_ReturnsCorrectOperator(OperatorEnum operatorType, Type expectedOperatorType)
        {
            // Arrange
            IOperatorProvider operatorProvider = new OperatorProvider();

            // Act
            IOperator result = operatorProvider.GetOperator(operatorType);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(expectedOperatorType);
        }

        [Fact]
        public void GetOperator_ThrowsNotSupportedException_ForUnsupportedOperator()
        {
            // Arrange
            IOperatorProvider operatorProvider = new OperatorProvider();

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => operatorProvider.GetOperator((OperatorEnum)8));
        }
    }
}
