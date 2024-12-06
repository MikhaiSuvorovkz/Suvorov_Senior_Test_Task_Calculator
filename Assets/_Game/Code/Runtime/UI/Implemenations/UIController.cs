namespace Game.UI
{
    using Views;
    using Presenters;

    public class UIController : IUIController
    {
        private readonly ICalculatorView _calculatorView;
        private readonly IDialogView _dialogView;
        private readonly CalculatorPresenter _calculatorPresenter;
        private readonly DialogPresenter _dialogPresenter;

        public UIController
        (
            ICalculatorView calculatorView,
            IDialogView dialogView,
            CalculatorPresenter calculatorPresenter,
            DialogPresenter dialogPresenter
        )
        {
            _calculatorView = calculatorView;
            _dialogView = dialogView;
            _calculatorPresenter = calculatorPresenter;
            _dialogPresenter = dialogPresenter;
        }

        public void Initialize()
        {
            SwitchToCalculator();

            _dialogView.Closed += SwitchToCalculator;
            _calculatorView.Clicked += OnCalculateButtonPressed;
            _calculatorPresenter.ErrorHappened += OnErrorHappened;
        }

        public void Dispose()
        {
            _dialogView.Closed -= SwitchToCalculator;
            _calculatorView.Clicked -= OnCalculateButtonPressed;
            _calculatorPresenter.ErrorHappened -= OnErrorHappened;
        }

        private void OnCalculateButtonPressed(string input)
        {
            _calculatorPresenter.HandleExpressionInput(input);
        }

        private void OnErrorHappened(string message)
        {
            _dialogPresenter.ShowError(message);
            SwitchToDialog();
        }

        private void SwitchToDialog()
        {
            _calculatorView.Hide();
            _dialogView.Show();
        }

        private void SwitchToCalculator()
        {
            _dialogView.Hide();
            _calculatorView.Show();
        }
    }
}