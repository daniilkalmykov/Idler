using System;
using System.Collections.Generic;

namespace Source.StateMachineSystem
{
    internal sealed class StateMachine : IStateMachine
    {
        private readonly List<IState> _states;
        
        private IState _currentState;

        public StateMachine(List<IState> states)
        {
            _states = states;
            _currentState = _states[0];
        }

        public void Update()
        {
            if (_currentState == null)
                return;

            _currentState.Update();

            if (_currentState.Transition.CanTransit() == false)
                return;
            
            var index = _states.IndexOf(_currentState);

            if (index == _states.Count - 1)
                index = 0;
            else
                index++;

            Transit(_states[index]);
        }

        public void Activate()
        {
            _currentState?.Enter();
        }

        public void Deactivate()
        {
            _currentState = null;
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