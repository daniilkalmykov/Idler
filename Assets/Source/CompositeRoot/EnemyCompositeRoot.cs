using System.Collections.Generic;
using Source.AttackingSystem;
using Source.HealthSystem;
using Source.MovementSystem;
using Source.StateMachineSystem;
using Source.StateMachineSystem.EnemyStateMachine.States;
using Source.StateMachineSystem.EnemyStateMachine.Transitions;
using UnityEngine;

namespace Source.CompositeRoot
{
    [RequireComponent(typeof(EnemyView.EnemyView))]
    internal sealed class EnemyCompositeRoot : CompositeRoot
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _distanceToTransit;
        [SerializeField] private float _damage;
        [SerializeField] private float _delayBetweenAttacks;
        
        private IStateMachine _stateMachine;
        private EnemyView.EnemyView _enemyView;
        private Transform _target;
        private IHealth _targetHealth;
        private IMovable _movable;
        private IAttacker _attacker;

        private void OnDisable()
        {
            _stateMachine?.Deactivate();
        }

        private void Update()
        {
            _stateMachine?.Update();
        }

        public void Init(Transform target, IHealth targetHealth)
        {
            _target = target;
            _targetHealth = targetHealth;
        }

        public override void Compose()
        {
            _enemyView = GetComponent<EnemyView.EnemyView>();

            var targetPosition = _target.position;
            
            _movable = new Movement(_speed);
            _attacker = new Attacker(_damage, _delayBetweenAttacks);
            
            var distanceTransition = new DistanceTransition(transform, targetPosition, _distanceToTransit);
            var killTransition = new KillTransition(_targetHealth);

            var moveState = new MoveState(distanceTransition, _enemyView, _movable, targetPosition);
            var attackState = new AttackState(killTransition, _attacker, _targetHealth);

            _stateMachine = new StateMachine(new List<IState> { moveState, attackState });
            
            _stateMachine.Activate();
        }
    }
}