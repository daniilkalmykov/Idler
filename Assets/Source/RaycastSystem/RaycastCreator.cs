using System;
using UnityEngine;

namespace Source.RaycastSystem
{
    internal sealed class RaycastCreator : IRaycastCreator
    {
        public Vector3 GetHitPosition(Vector3 position, LayerMask layerMask)
        {
            if (Camera.main == null)
                throw new ArgumentNullException();

            var ray = Camera.main.ScreenPointToRay(position);

            return Physics.Raycast(ray, out var hit, layerMask) ? hit.point : default;
        }
    }
}