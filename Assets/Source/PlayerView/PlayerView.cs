using Source.MovementSystem;
using UnityEngine;

namespace Source.PlayerView
{
    internal sealed class PlayerView : MonoBehaviour, IPlayerView
    {
        private IMovable _movable;
        private Vector3 _target;
        
        private void Update()
        {
            if (_movable == null || _target == default)
                return;

            transform.position = Vector3.MoveTowards(transform.position, _target, _movable.Speed * Time.deltaTime);

            if (transform.position == _target)
                _target = default;
        }

        public void Init(IMovable movable) => _movable = movable;

        public void SetTarget(Vector3 target) => _target = target;
    }
}