using UnityEngine;

namespace Source.RaycastSystem
{
    public interface IRaycastCreator
    {
        Vector3? GetHitPosition(Vector3 position, LayerMask layerMask);
    }
}