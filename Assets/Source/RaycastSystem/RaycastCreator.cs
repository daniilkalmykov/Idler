using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Source.RaycastSystem
{
    internal sealed class RaycastCreator : IRaycastCreator
    {
        public Vector3? GetHitPosition(Vector3 position, LayerMask layerMask)
        {
            if (Camera.main == null)
                throw new ArgumentNullException();

            var ray = Camera.main.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out var hit, layerMask))
                return hit.point;
            
            return null;
        }
    }
}