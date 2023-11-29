using System;
using FluentAssertions;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Business.Tests.OperatorBusiness.Operators
{
	public class DivisionTest
	{
        [Theory]
        [InlineData(2, 4, 0)]
        [InlineData(28, 14, 2)]
        [InlineData(-28, -14, 2)]
        [InlineData(12, -2, -6)]
        [InlineData(-14, 12, -1)]
        [InlineData(0, -14, 0)]
        public void Division_ShouldReutrnDivisionResult_WhenSecondNumberIsNotZero(int num1, int num2, int answer)
        {
            //Arrange
            var divisionOperatot = new DivisionOperator();

            //Act
            int result = divisionOperatot.Calculate(num1, num2);

            //Assert
            result.Should().Be(answer);
        }

        [Fact]
        public void Division_ShouldReutrnDivisionResult_WhenSecondNumberIsZero()
        {
            //Arrange
            var divisionOperator = new DivisionOperator();
            int num1 = 12;
            int num2 = 0;

            // Act
            var action = () => divisionOperator.Calculate(num1, num2);

            //Assert
            action.Should().Throw<DivideByZeroException>();
        }
    }
}

