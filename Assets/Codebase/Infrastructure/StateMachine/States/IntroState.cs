using Codebase.Services.SceneService;
using Codebase.UI;
using Cysharp.Threading.Tasks;

namespace Codebase.Infrastructure.States
{
	internal class IntroState : IPayLoadedState
	{
		private readonly string _introScene = "Intro";
		private readonly GameStateMachine _stateMachine;
		private readonly SceneService _sceneService;
		private Fade _fade;

		public IntroState(GameStateMachine stateMachine, SceneService sceneService, Fade fade)
		{
			_stateMachine = stateMachine;
			_sceneService = sceneService;
			_fade = fade;
		}

		public void Enter()
		{
			LoadIntro();
		}

		public void Exit()
		{
			UnloadIntro();
		}

		private async void LoadIntro()
		{
			await _sceneService.Load(_introScene, true);
			_fade.Out();
		}

		private async void UnloadIntro()
		{
			await _sceneService.Unload(_introScene);
		}
	}
}
