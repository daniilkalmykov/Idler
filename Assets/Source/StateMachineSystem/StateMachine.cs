using System;

namespace Source.StateMachineSystem
{
    internal sealed class StateMachine : IStateMachine
    {
        public StateMachine(IState currentState)
        {
            CurrentState = currentState;
        }

        public IState CurrentState { get; private set; }

        public void Activate()
        {
            CurrentState?.Enter();
        }

        public void Update()
        {
            CurrentState?.Update();
        }

        public void Deactivate()
        {
            CurrentState = null;
        }

        public void Transit(IState nextState)
        {
            if (nextState == null)
                throw new ArgumentNullException();
            
            CurrentState?.Exit();

            CurrentState = nextState;
            CurrentState?.Enter();
        }

        public void Reset(IState startState)
        {
            CurrentState = startState;
        }
    }
}