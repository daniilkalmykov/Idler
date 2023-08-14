using System.Collections.Generic;
using Source.AttackingSystem;
using Source.EnemyView;
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
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _speed;
        [SerializeField] private float _distanceToTransit;
        [SerializeField] private float _damage;
        [SerializeField] private float _delayBetweenAttacks;
        
        private IStateMachine _stateMachine;
        private IEnemyView _enemyView;
        private Transform _target;
        private IHealth _targetHealth;
        private IMovable _movable;
        private IAttacker _attacker;
        private IHealth _health;

        private void OnDisable()
        {
            if (_health != null)
                _health.Died -= OnDied;
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
            
            _health = new Health(_maxHealth);
            _health.Died += OnDied;
            
            var distanceTransition = new DistanceTransition(transform, targetPosition, _distanceToTransit);
            var killTransition = new KillTransition(_targetHealth);

            var moveState = new MoveState(distanceTransition, _enemyView, _movable, targetPosition);
            var attackState = new AttackState(killTransition, _attacker, _targetHealth);

            _stateMachine = new StateMachine(new List<IState> { moveState, attackState });
            _stateMachine.Activate();
        }

        private void OnDied()
        {
            _stateMachine?.Deactivate();
            _enemyView.TurnOff();
        }
    }
}