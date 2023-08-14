using Source.MovementSystem;
using UnityEngine;

namespace Source.EnemyView
{
    public interface IEnemyView
    {
        void SetTarget(Vector3 target);
        void Move(IMovable movable);
        void TurnOff();
    }
}