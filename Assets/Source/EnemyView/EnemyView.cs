using System;
using System.Runtime.CompilerServices;
using Source.MovementSystem;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Source.EnemyView
{
    internal sealed class EnemyView : MonoBehaviour, IEnemyView
    {
        private Vector3 _target;

        public void SetTarget(Vector3 target)
        {
            _target = target;
        }

        public void Move(IMovable movable)
        {
            if (movable == null)
                throw new ArgumentNullException();

            transform.position = Vector3.MoveTowards(transform.position, _target, movable.Speed * Time.deltaTime);
        }

        public void TurnOff()
        {
            gameObject.SetActive(false);
        }
    }
}