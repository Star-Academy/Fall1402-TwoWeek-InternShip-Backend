using SimpleCalculator.Business.Abstraction;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.OperatorBusiness;

namespace SimpleCalculator.Business
{
    public class SimpleCalculator : ICalculator
    {
        private readonly IOperatorProvider _operatorProvider;

        public SimpleCalculator(IOperatorProvider operatorProvider)
        {
            _operatorProvider = operatorProvider ?? throw new ArgumentNullException(nameof(operatorProvider));
        }

        public int Calculate(int first, int second, OperatorEnum operatorType)
        {
            var @operator = _operatorProvider.GetOperator(operatorType);
            return @operator.Calculate(first, second);
        }
    }
}