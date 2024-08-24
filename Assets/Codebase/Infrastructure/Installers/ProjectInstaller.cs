using Codebase.Services.Animation;
using Codebase.Services.SceneService;
using Codebase.UI;
using Zenject;
using UnityEngine.EventSystems;
using Codebase.Services.Input;
using Codebase.Services.SceneLoader;

namespace Codebase.Installers
{
	public class ProjectInstaller : MonoInstaller
	{
        public LoadScreen LoadScreen;
        public Fade Fade;

        public override void InstallBindings()
		{
            Container.Bind<LoadScreen>().FromComponentInNewPrefab(LoadScreen).AsSingle().NonLazy();
            Container.Bind<Fade>().FromComponentInNewPrefab(Fade).AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<SceneService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<Tweener>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<OpenCloseAnimation>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<SceneTransition>().AsSingle().NonLazy();
        }
    }
}
