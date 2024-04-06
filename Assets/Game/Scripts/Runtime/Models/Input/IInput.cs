namespace Game.Scripts.Runtime.Models.Input
{
    public interface IInput
    {
        float Horizontal { get; }
        float Vertical { get; }

        void OnUpdate();
    }
}