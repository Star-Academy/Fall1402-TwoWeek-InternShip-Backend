using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Business.Tests;

public class SumTest
{
    [Theory]
    [InlineData(2, 4, 6)]
    [InlineData(12, 14, 26)]
    [InlineData(12, -2, 10)]
    [InlineData(12, -12, 0)]
    [InlineData(12, -14, -2)]
    public void SumTests(int num1, int num2, int answer)
    {
        //Arrange
        var sumOperator = new SumOperator();

        //Act
        int result = sumOperator.Calculate(num1, num2);

        //Assert
        Assert.Equal(answer, result);
    }
}
