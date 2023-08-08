using Source.MovementSystem;
using UnityEngine;

namespace Source.PlayerView
{
    public interface IPlayerView
    {
        void Init(IMovable movable);
        void SetTarget(Vector3 target);
    }
}