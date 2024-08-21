using Codebase.Services.Dialogue;
using Zenject;

namespace Assets.Codebase.Installers
{
    public class DialogueServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DialogueService>().AsSingle().NonLazy();
        }
    }
}