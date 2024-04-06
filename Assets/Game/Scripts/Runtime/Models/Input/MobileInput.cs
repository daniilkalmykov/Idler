using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Game.Scripts.Runtime.Models.Input
{
    internal sealed class MobileInput : IInput
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        public void OnUpdate()
        {
            if (UnityEngine.Input.touchCount != 1)
                return;

            var touch = UnityEngine.Input.touches[0];

            Horizontal = touch.deltaPosition.x;
            Vertical = touch.deltaPosition.y;
        }
    }
}