using Game.Scripts.Runtime.Models.Input;
using Reflex.Core;
using UnityEngine;

namespace Game.Scripts.Runtime.App.DI
{
    public sealed class LevelInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(typeof(MobileInput), typeof(IInput));
        }
    }
}