using Source.MovementSystem;
using UnityEngine;

namespace Source.EnemyView
{
    public interface IEnemyView
    {
        void Init(Vector3 target);
        void Move(IMovable movable);
    }
}