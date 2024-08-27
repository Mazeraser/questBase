using Codebase.Infrastructure;
using Codebase.Infrastructure.States;
using Zenject;

public class StateMachineInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<StateFactory>().AsSingle().NonLazy();

		Container.Bind<BootstrapState>().AsSingle().NonLazy();
		Container.Bind<MainMenuState>().AsSingle().NonLazy();
		Container.Bind<NewGameState>().AsSingle().NonLazy();
		Container.Bind<IntroState>().AsSingle().NonLazy();
		Container.Bind<LoadLevelState>().AsSingle().NonLazy();
		Container.Bind<DefaultState>().AsSingle().NonLazy();
		Container.Bind<ExitToMenuState>().AsSingle().NonLazy();
		Container.Bind<ContinueGameState>().AsSingle().NonLazy();

		Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
	}
}
