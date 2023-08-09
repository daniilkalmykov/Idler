using System;

namespace Source.StateMachineSystem
{
    internal sealed class StateMachine
    {
        public StateMachine(IState currentState)
        {
            _currentState = currentState;
        }

        private IState _currentState;

        private void Activate()
        {
            _currentState.Enter();
        }
        
        private void Update()
        {
            _currentState?.Update();
        }

        private void Transit(IState nextState)
        {
            if (nextState == null)
                throw new ArgumentNullException();
            
            _currentState?.Exit();

            _currentState = nextState;
            _currentState?.Enter();
        }
    }
}