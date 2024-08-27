using Codebase.Services.DiarySystem;
using Codebase.Services.SaveSystem;
using Zenject;

public class DiaryInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<DiaryQuest>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<DiarySave>().AsSingle().NonLazy();
    }
}