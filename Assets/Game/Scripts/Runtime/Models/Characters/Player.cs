using System;
using System.Runtime.CompilerServices;
using Game.Scripts.Runtime.Models.Input;
using Game.Scripts.Runtime.Models.Movement;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Game.Scripts.Runtime.Models.Characters
{
    internal sealed class Player : ICharacter
    {
        private readonly IInput _input;
        private readonly IMovable _movable;

        public Player(IInput input, IMovable movable)
        {
            _input = input ?? throw new ArgumentNullException();
            _movable = movable ?? throw new ArgumentNullException();
        }

        public void OnUpdate()
        {
            _movable.Move(new Vector3(_input.Horizontal, 0, _input.Vertical));
        }
    }
}