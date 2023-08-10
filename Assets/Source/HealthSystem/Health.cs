using System;

namespace Source.HealthSystem
{
    internal sealed class Health : IHealth
    {
        public Health(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public event Action Changed;
        public event Action Died;
        
        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }

        
        public void TryTakeDamage(float damage)
        {
            if (damage <= 0)
                throw new ArgumentException();

            CurrentHealth -= MaxHealth;

            if (CurrentHealth <= 0)
            {
                Died?.Invoke();
                return;
            }
            
            Changed?.Invoke();
        }
    }
}