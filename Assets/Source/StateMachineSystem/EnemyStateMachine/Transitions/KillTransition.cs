using System;
using Source.HealthSystem;

namespace Source.StateMachineSystem.EnemyStateMachine.Transitions
{
    internal sealed class KillTransition : ITransition
    {
        private readonly IHealth _health;
        
        public KillTransition(IHealth health)
        {
            _health = health ?? throw new ArgumentNullException();
        }

        public bool CanTransit()
        {
            return _health.CurrentHealth <= 0;
        }
    }
}