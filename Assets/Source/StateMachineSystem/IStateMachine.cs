namespace Source.StateMachineSystem
{
    public interface IStateMachine
    {
        void Activate();
        void Update();
        void Deactivate();
    }
}