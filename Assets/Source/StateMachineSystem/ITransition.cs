namespace Source.StateMachineSystem
{
    public interface ITransition
    {
        IState NextState { get; }
        
        bool CanTransit();
    }
}