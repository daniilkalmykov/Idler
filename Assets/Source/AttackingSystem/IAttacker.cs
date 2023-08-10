using System;
using Source.HealthSystem;

namespace Source.AttackingSystem
{
    public interface IAttacker
    {
        event Action Attacked; 

        float Damage { get; }
        float Delay { get; }
        bool CanAttack { get; }

        void TryAttack(IHealth health);
        void Activate();
        void Deactivate();
    }
}