using System;
using Source.EnemyView;
using Source.MovementSystem;
using UnityEngine;

namespace Source.StateMachineSystem.EnemyStateMachine.States
{
    internal sealed class MoveState : IState
    {
        private readonly IEnemyView _enemyView;
        private readonly IMovable _movable;
        private readonly Vector3 _target;
        
        private bool _canMove;
        
        public MoveState(ITransition transition, IEnemyView enemyView, IMovable movable, Vector3 target)
        {
            Transition = transition ?? throw new ArgumentNullException();
            _enemyView = enemyView ?? throw new ArgumentNullException();
            _movable = movable ?? throw new ArgumentNullException();
            _target = target;
        }

        public ITransition Transition { get; }
        
        public void Enter()
        {
            _canMove = true;

            _enemyView.SetTarget(_target);
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