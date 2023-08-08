using System.Collections.Generic;
using UnityEngine;

namespace Source.CompositeRoot
{
    internal sealed class CompositionOrder : MonoBehaviour
    {
        [SerializeField] private List<CompositeRoot> _compositeRoots;

        private void Awake()
        {
            foreach (var compositeRoot in _compositeRoots)
                compositeRoot.Compose();
        }
    }
}