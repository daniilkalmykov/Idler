namespace Source.StateMachineSystem
{
    public interface IState
    {
        ITransition Transition { get; }
        
        void Enter();
        void Update();
        void Exit();
    }
}