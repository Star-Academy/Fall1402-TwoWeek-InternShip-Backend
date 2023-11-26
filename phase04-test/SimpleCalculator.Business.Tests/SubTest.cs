using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Business.Tests;

public class SubTest
{
    [Theory]
    [InlineData(2, 4, -2)]
    [InlineData(12, 14, -2)]
    [InlineData(12, -2, 14)]
    [InlineData(12, -12, 24)]
    [InlineData(12, -14, 26)]
    public void SubTests(int num1, int num2, int answer)
    {
        //Arrange
        var subOperatot = new SubOperator();

        //Act
        int result = subOperatot.Calculate(num1, num2);

        //Assert
        Assert.Equal(answer, result);
    }
}

