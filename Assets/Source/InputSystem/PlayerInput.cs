using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Source.InputSystem
{
    internal class PlayerInput : MonoBehaviour, IInput
    {
        public event Action<Vector3> Touched;

        private void Update()
        {
            if (Input.touchCount != 1)
                return;

            foreach (var touch in Input.touches)
            {
                if (touch.phase != TouchPhase.Began)
                    return;

                Touched?.Invoke(touch.position);
            }
        }
    }
}