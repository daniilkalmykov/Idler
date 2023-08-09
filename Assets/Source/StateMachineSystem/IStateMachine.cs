namespace Source.StateMachineSystem
{
    public interface IStateMachine
    {
        IState CurrentState { get; }
        
        void Activate();
        void Update();
        void Deactivate();
        void Transit(IState nextState);
        void Reset(IState startState);
    }
}