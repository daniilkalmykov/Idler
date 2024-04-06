using UnityEngine;

namespace Game.Scripts.Runtime.Models.Movement
{
    public interface IMovable
    {
        void Move(Vector3 direction);
    }
}