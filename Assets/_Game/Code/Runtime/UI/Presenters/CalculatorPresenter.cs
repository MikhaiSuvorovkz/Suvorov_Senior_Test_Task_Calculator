using System;
using System.Collections.Generic;

namespace Game.UI.Presenters
{
    using Core.Entities;
    using Views;

    public class CalculatorPresenter
    {
        private const string ERROR_MESSAGE = "ERROR";

        private readonly ICalculator _calculator;
        private readonly ICalculatorView _view;
        private readonly ICalculationHistory _history;

        public event Action<string> ErrorHappened;

        public CalculatorPresenter
        (
            ICalculator calculator,
            ICalculatorView view,
            ICalculationHistory history
        )
        {
            _calculator = calculator;
            _view = view;
            _history = history;
        }

        public void HandleExpressionInput(string input)
        {
            try
            {
                string result = _calculator.Calculate(input);

                _history.Add(input, result);
            }
            catch (Exception ex)
            {
                _history.Add(input, ERROR_MESSAGE);

                var errorMessage = $"Invalid input: {ex.Message}. Please check your expression.";

                ErrorHappened?.Invoke(errorMessage);
            }
            finally
            {
                UpdateHistoryView();
            }
        }

        private IEnumerable<string> History => _history.History;

        private void UpdateHistoryView()
        {
            _view.UpdateHistory(History);
        }
    }
}