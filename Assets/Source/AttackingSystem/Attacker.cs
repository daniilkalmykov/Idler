using System;
using Source.HealthSystem;

namespace Source.AttackingSystem
{
    internal sealed class Attacker : IAttacker
    {
        public Attacker(float damage, float delay)
        {
            Damage = damage;
            Delay = delay;
        }

        public event Action Attacked;
        
        public float Damage { get; }
        public float Delay { get; }
        public bool CanAttack { get; private set; }

        public void TryAttack(IHealth health)
        {
            Attacked?.Invoke();
            health.TryTakeDamage(Damage);
            
            CanAttack = false;
        }

        public void Activate()
        {
            CanAttack = true;
        }

        public void Deactivate()
        {
            CanAttack = false;
        }
    }
}