namespace Game.Core.Entities
{
    public class DialogModel : IDialogModel
    {
        public string Message { get; private set; }

        public DialogModel(string message = "")
        {
            Message = message;
        }

        public void SetMessage(string message)
        {
            Message = message;
        }
    }
}