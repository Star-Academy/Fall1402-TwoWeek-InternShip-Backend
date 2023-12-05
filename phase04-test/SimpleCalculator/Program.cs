using SimpleCalculator.Business;
using SimpleCalculator.Business.OperatorBusiness;
using SimpleCalculator.ConsoleApp;

using Calculator = SimpleCalculator.Business.SimpleCalculator;

new UiManager(new Calculator(new OperatorProvider()))
    .StartUI();