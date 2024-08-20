using UnityEngine;
using Zenject;
using Codebase.UI;

public class FadeInstaller : MonoInstaller
{
    public Fade Fade;

    public override void InstallBindings()
    {
        Container.Bind<Fade>().FromComponentInNewPrefab(Fade).AsSingle().NonLazy();
    }
}