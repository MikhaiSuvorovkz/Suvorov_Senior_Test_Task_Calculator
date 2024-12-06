namespace Game.Core.Entities
{
    public interface IDialogModel
    {
        string Message { get; }
        void SetMessage(string message);
    }
}