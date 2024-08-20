using Codebase.Services.SceneLoader;
using UnityEngine;
using Zenject;

public class StartLevelInstaller : MonoInstaller
{
    public SceneTransitionData sceneTransition;

    public override void InstallBindings()
    {
        Container.BindInstance(sceneTransition).AsSingle().NonLazy();
    }
}