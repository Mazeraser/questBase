using Zenject;
using Codebase.UI;

namespace Codebase.Infrastructure.Installers
{
    public class FadeInstaller : MonoInstaller
    {
        public Fade Fade;

        public override void InstallBindings()
        {
            Container.Bind<Fade>().FromComponentInNewPrefab(Fade).AsSingle().NonLazy();
        }
    }
}