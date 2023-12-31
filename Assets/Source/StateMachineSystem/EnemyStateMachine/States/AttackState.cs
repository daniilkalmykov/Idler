using System;
using Source.AttackingSystem;
using Source.HealthSystem;
using UnityEngine;

namespace Source.StateMachineSystem.EnemyStateMachine.States
{
    internal sealed class AttackState : IState
    {
        private readonly IAttacker _attacker;
        private readonly IHealth _health;

        private float _timer;

        public AttackState(ITransition transition, IAttacker attacker, IHealth health)
        {
            Transition = transition ?? throw new ArgumentNullException();
            _attacker = attacker ?? throw new ArgumentNullException();
            _health = health ?? throw new ArgumentNullException();
        }

        public ITransition Transition { get; }
        
        public void Enter()
        {
            _attacker.Activate();
        }

        public void Update()
        {
            if (_timer >= _attacker.Delay)
            {
                _attacker.TryAttack(_health);
                _timer = 0;
                
                return;
            }

            _timer += Time.deltaTime;
        }
        
        public void Exit()
        {
            _attacker.Deactivate();
        }
    }
}