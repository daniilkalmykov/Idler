using Source.HealthSystem;

namespace Source.StateMachineSystem.EnemyStateMachine.Transitions
{
    internal sealed class KillTransition : ITransition
    {
        private readonly IHealth _health;
        
        public KillTransition(IState nextState, IHealth health)
        {
            NextState = nextState;
            _health = health;
        }

        public IState NextState { get; }
        
        public bool CanTransit()
        {
            return _health.CurrentHealth <= 0;
        }
    }
}