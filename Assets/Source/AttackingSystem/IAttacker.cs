using System;

namespace Source.AttackingSystem
{
    public interface IAttacker
    {
        event Action Attacked; 

        float Damage { get; }
        float Delay { get; }
        bool CanAttack { get; }

        void TryAttack();
        void Activate();
        void Deactivate();
    }
}