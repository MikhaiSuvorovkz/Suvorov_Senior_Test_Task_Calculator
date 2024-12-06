namespace Game.Core.Entities.Factories
{
    using Entities;
    public class CalculatorFactory
    {
        public ICalculator Create()
        {
            return new Calculator();
        }
    }

}