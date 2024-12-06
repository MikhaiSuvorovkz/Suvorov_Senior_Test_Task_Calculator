using System;

namespace Game.UI.Views
{
    public interface IDialogView : IView
    {
        void SetMessage(string message);
        event Action Closed;
    }
}