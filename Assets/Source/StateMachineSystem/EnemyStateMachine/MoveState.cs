using System;
using Source.EnemyView;
using Source.MovementSystem;

namespace Source.StateMachineSystem.EnemyStateMachine
{
    internal sealed class MoveState : IState
    {
        private readonly IEnemyView _enemyView;
        private readonly IMovable _movable;
        
        private bool _canMove;
        
        public MoveState(ITransition transition, IEnemyView enemyView, IMovable movable)
        {
            Transition = transition ?? throw new ArgumentNullException();
            _enemyView = enemyView ?? throw new ArgumentNullException();
            _movable = movable ?? throw new ArgumentNullException();
        }

        public ITransition Transition { get; }
        
        public void Enter()
        {
            _canMove = true;
        }

        public void Update()
        {
            if (_canMove)
                _enemyView.Move(_movable);
        }

        public void Exit()
        {
            _canMove = false;
        }
    }
}