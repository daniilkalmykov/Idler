using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Game.Scripts.Runtime.Models.Input
{
    internal sealed class PCInput : IInput
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        public void OnUpdate()
        {
            Horizontal = UnityEngine.Input.GetAxis("Horizontal");
            Vertical = UnityEngine.Input.GetAxis("Vertical");
        }
    }
}