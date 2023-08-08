using Source.InputSystem;
using Source.MovementSystem;
using Source.PlayerView;
using Source.RaycastSystem;
using UnityEngine;

namespace Source.CompositeRoot
{
    [RequireComponent(typeof(PlayerView.PlayerView))]
    [RequireComponent(typeof(PlayerInput))]
    internal sealed class PlayerCompositeRoot : CompositeRoot
    {
        [SerializeField] private float _speed;
        [SerializeField] private LayerMask _ground;
        
        private IMovable _movable;
        private IRaycastCreator _raycastCreator;
        private IInput _input;
        private IPlayerView _playerView;

        private void OnDisable()
        {
            _input.Touched -= OnTouched;
        }

        public override void Compose()
        {
            _movable = new Movement(_speed);
            _raycastCreator = new RaycastCreator();
            
            _input = GetComponent<PlayerInput>();
            _playerView = GetComponent<PlayerView.PlayerView>();

            _playerView.Init(_movable);
            
            _input.Touched += OnTouched;
        }

        private void OnTouched(Vector3 touchPosition)
        {
            var hitPosition = _raycastCreator.GetHitPosition(touchPosition, _ground);

            if (hitPosition == null)
                return;

            var target = new Vector3(hitPosition.Value.x, transform.position.y, hitPosition.Value.z);

            _playerView.SetTarget(target);
        }
    }
}