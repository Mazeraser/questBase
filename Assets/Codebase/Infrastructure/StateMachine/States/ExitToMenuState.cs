using Codebase.Services.SceneService;
using Codebase.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Codebase.Infrastructure.States
{
	public class ExitToMenuState : IPayLoadedState
	{
		private GameStateMachine _state;
		private SceneService _sceneService;
		private Fade _fade;

		public ExitToMenuState(GameStateMachine state, SceneService sceneService, Fade fade)
		{
			_state = state;
			_sceneService = sceneService;
			_fade = fade;
		}

		public void Enter()
		{
			
		}

		public void Exit()
		{
			
		}

	}
}
