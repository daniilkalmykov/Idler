using System;
using UnityEngine;

namespace Source.StateMachineSystem.EnemyStateMachine.Transitions
{
    internal sealed class DistanceTransition : ITransition
    {
        private readonly Transform _enemy;
        private readonly Vector3 _target;
        private readonly float _distanceToTransit;
        
        public DistanceTransition(Transform enemy, Vector3 target, float distanceToTransit)
        {
            _enemy = enemy;
            _target = target;

            if (_distanceToTransit < 0)
                throw new ArgumentException();
            
            _distanceToTransit = distanceToTransit;
        }

        public bool CanTransit()
        {
            return Vector3.Distance(_enemy.position, _target) <= _distanceToTransit;
        }
    }
}