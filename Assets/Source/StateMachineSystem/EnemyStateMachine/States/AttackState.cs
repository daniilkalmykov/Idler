using Source.AttackingSystem;
using UnityEngine;

namespace Source.StateMachineSystem.EnemyStateMachine.States
{
    internal sealed class AttackState : IState
    {
        private readonly IAttacker _attacker;

        private float _timer;

        public AttackState(ITransition transition, IAttacker attacker)
        {
            Transition = transition;
            _attacker = attacker;
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
                _attacker.TryAttack();
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