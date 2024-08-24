using Codebase.Services.DiarySystem;
using Zenject;

public class DiaryInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<DiaryQuest>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
    }
}