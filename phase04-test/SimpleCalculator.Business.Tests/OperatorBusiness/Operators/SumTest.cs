using FluentAssertions;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Business.Tests.OperatorBusiness.Operators;

public class SumTest
{
    [Theory]
    [InlineData(2, 4, 6)]
    [InlineData(12, -2, 10)]
    [InlineData(-12, 14, 2)]
    [InlineData(-12, -14, -26)]
    [InlineData(0, -14, -14)]
    [InlineData(12, 0, 12)]
    [InlineData(0, 0, 0)]
    public void Sum_ShouldReutrnSumResult_WhenEver(int num1, int num2, int answer)
    {
        //Arrange
        var sumOperator = new SumOperator();

        //Act
        int result = sumOperator.Calculate(num1, num2);

        //Assert
        result.Should().Be(answer);
    }
}
