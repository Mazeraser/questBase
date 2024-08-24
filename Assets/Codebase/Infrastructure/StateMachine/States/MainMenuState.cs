using Codebase.Services.SceneService;
using Codebase.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Codebase.Infrastructure.States
{
	public class MainMenuState : IPayLoadedState
	{
		private readonly string _mainMenuScene = "MainMenu";
		private readonly GameStateMachine _state;
		private readonly SceneService _sceneService;
		private Fade _fade;

		public MainMenuState(GameStateMachine state, SceneService sceneService, Fade fade)
		{
			_state = state;
			_sceneService = sceneService;
			_fade = fade;
		}

		public async void Enter()
		{
			await UniTask.WhenAll(
				_sceneService.Load(_mainMenuScene, true),
				_fade.In()
			);

			await _fade.Out();
		}

		public void Exit()
		{
			
		}
	}
}
