using System;
using UnityEngine;

namespace Source.InputSystem
{
    public interface IInput
    {
        event Action<Vector3> Touched;
    }
}