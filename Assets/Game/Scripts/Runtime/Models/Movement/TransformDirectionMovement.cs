using System;
using UnityEngine;

namespace Game.Scripts.Runtime.Models.Movement
{
    internal sealed class TransformDirectionMovement : IMovable
    {
        private float _speed;
        private readonly Transform _transform;

        public TransformDirectionMovement(float speed, Transform transform)
        {
            if (speed <= 0)
                throw new ArgumentException(nameof(speed));

            if (transform == null)
                throw new ArgumentNullException(nameof(transform));

            _transform = transform;
            _speed = speed;
        }

        public void Move(Vector3 direction)
        {
            _transform.position += direction * (Time.deltaTime * _speed);
        }
    }
}