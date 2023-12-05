using SimpleCalculator.Business.Enums;

namespace SimpleCalculator.Business.Abstraction
{
    public interface ICalculator
    {
        int Calculate(int first, int second, OperatorEnum operatorType);
    }
}