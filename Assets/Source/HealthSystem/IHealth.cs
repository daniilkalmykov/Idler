using System;

namespace Source.HealthSystem
{
    public interface IHealth
    {
        event Action Changed;
        event Action Died;
        
        float MaxHealth { get; }
        float CurrentHealth { get; }

        void TryTakeDamage(float damage);
    }
}