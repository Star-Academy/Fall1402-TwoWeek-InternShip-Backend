using System;
using FluentAssertions;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Business.Tests.OperatorBusiness.Operators
{

    public class MultipyTest
    {
        [Theory]
        [InlineData(2, 4, 8)]
        [InlineData(12, -2, -24)]
        [InlineData(-12, 14, -168)]
        [InlineData(-12, -14, 168)]
        [InlineData(0, -14, 0)]
        [InlineData(12, 0, 0)]
        [InlineData(0, 0, 0)]
        public void Multiply_ShouldReutrnMultiplyResult_WhenEver(int num1, int num2, int answer)
        {
            //Arrange
            var multipyOperatot = new MultiplyOperator();

            //Act
            int result = multipyOperatot.Calculate(num1, num2);

            //Assert
            result.Should().Be(answer);
        }
    }
}

