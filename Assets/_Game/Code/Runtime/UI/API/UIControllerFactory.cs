namespace Game.UI
{
    using Views;
    using Presenters;

    public class UIControllerFactory
    {
        public IUIController Create
        (
            ICalculatorView calculatorView,
            IDialogView dialogView,
            CalculatorPresenter calculatorPresenter,
            DialogPresenter dialogPresenter
        )
        {
            return new UIController
            (
                calculatorView,
                dialogView,
                calculatorPresenter,
                dialogPresenter
            );
        }
    }
}