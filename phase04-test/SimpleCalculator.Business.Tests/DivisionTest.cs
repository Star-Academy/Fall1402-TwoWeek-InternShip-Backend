using System;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Business.Tests
{
	public class DivisionTest
	{
        [Theory]
        [InlineData(2, 4, 0)]
        [InlineData(28, 14, 2)]
        [InlineData(12, -2, -6)]
        [InlineData(12, -12, -1)]
        [InlineData(14, -12, -1)]
        [InlineData(0, -14, 0)]
        public void DivisionTests(int num1, int num2, int answer)
        {
            //Arrange
            var divisionOperatot = new DivisionOperator();

            //Act
            int result = divisionOperatot.Calculate(num1, num2);

            //Assert
            Assert.Equal(answer, result);
        }

        [Fact]
        public void DivisionByZeroTest()
        {
            //Arrange
            var divisionOperator = new DivisionOperator();
            int num1 = 12;
            int num2 = 0;

            //Assert & Act
            Assert.Throws<DivideByZeroException>(() => divisionOperator.Calculate(num1, num2));
        }
    }
}

