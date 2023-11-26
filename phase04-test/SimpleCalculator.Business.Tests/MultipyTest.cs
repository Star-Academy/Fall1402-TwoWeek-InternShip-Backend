using System;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Business.Tests
{

	public class MultipyTest
	{
        [Theory]
        [InlineData(2, 4, 8)]
        [InlineData(12, 14, 168)]
        [InlineData(12, -2, -24)]
        [InlineData(12, -12, -144)]
        [InlineData(12, -14, -168)]
        [InlineData(0, -14, 0)]
        [InlineData(12, 0, 0)]
        public void MultipyTests(int num1, int num2, int answer)
        {
            //Arrange
            var multipyOperatot = new MultiplyOperator();

            //Act
            int result = multipyOperatot.Calculate(num1, num2);

            //Assert
            Assert.Equal(answer, result);
        }
    }
}

