namespace Source.StateMachineSystem
{
    public interface IStateMachine
    {
        void Activate();
        void Update();
        void Deactivate();
        void Reset(IState startState);
    }
}