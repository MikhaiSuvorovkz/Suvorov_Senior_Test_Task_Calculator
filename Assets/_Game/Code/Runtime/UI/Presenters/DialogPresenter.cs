namespace Game.UI.Presenters
{
    using Core.Entities;
    using Views;

    public class DialogPresenter
    {
        private readonly IDialogModel _model;
        private readonly IDialogView _dialogView;

        public DialogPresenter(IDialogModel model, IDialogView dialogView)
        {
            _model = model;
            _dialogView = dialogView;
        }

        public void ShowError(string message)
        {
            _model.SetMessage(message);
            _dialogView.SetMessage(_model.Message);
        }
    }
}