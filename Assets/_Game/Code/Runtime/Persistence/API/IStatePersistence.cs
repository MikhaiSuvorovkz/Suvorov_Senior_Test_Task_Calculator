namespace Game.Persistence
{
    public interface IStatePersistence<TState>
        where TState : new() 
    {
        void SaveState(TState state);
        TState LoadState();
    }
}