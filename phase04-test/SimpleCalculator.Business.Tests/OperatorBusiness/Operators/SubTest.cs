using FluentAssertions;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Business.Tests.OperatorBusiness.Operators;

public class SubTest
{
    [Theory]
    [InlineData(2, 4, -2)]
    [InlineData(12, -2, 14)]
    [InlineData(-12, 14, -26)]
    [InlineData(-12, -14, 2)]
    [InlineData(0, -14, 14)]
    [InlineData(12, 0, 12)]
    [InlineData(0, 0, 0)]
    public void Sub_ShouldReutrnSubResult_WhenEver(int num1, int num2, int answer)
    {
        //Arrange
        var subOperatot = new SubOperator();

        //Act
        int result = subOperatot.Calculate(num1, num2);

        //Assert
        result.Should().Be(answer);
    }
}

