using Codebase.Services.Input;
using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputService>().AsSingle().NonLazy();
    }
}