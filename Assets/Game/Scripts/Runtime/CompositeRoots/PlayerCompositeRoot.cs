using System;
using Game.Scripts.Runtime.Models.Characters;
using Game.Scripts.Runtime.Models.Input;
using Game.Scripts.Runtime.Models.Movement;
using Reflex.Attributes;
using UnityEngine;

namespace Game.Scripts.Runtime.CompositeRoots
{
    public sealed class PlayerCompositeRoot : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private ICharacter _character;
        private IMovable _movable;
        private IInput _pcInput;

        private void Update()
        {
            _character.OnUpdate();
        }

        [Inject]
        public void Construct(IInput input)
        {
            _pcInput = input ?? throw new ArgumentNullException(nameof(input));
            
            _movable = new TransformDirectionMovement(_speed, transform);
            _character = new Player(_pcInput, _movable);
        }
    }
}