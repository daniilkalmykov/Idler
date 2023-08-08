using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Source.MovementSystem
{
    internal sealed class Movement : IMovable
    {
        public Movement(float speed)
        {
            Speed = speed;
        }

        public float Speed { get; }
    }
}