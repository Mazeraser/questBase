using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField]
    private CameraComponent _camera;

    public override void InstallBindings()
    {
        Container
            .BindInstance(_camera)
            .AsSingle()
            .NonLazy();
    }
}