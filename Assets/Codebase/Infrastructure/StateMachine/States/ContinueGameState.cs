using Codebase.Services.SceneService;
using Codebase.UI;
using System;

namespace Codebase.Infrastructure.States
{
	public class ContinueGameState : IPayLoadedState<string>
    {
        public static event Action ReturnDataEvent;

        private readonly SceneService _sceneService;
		private readonly GameStateMachine _state;
		private Fade _fade;

		public ContinueGameState(GameStateMachine state, SceneService sceneService, Fade fade)
		{
			_state = state;
			_sceneService = sceneService;
			_fade = fade;
		}

		public void Enter(string payLoad)
		{
			UnloadMenu(payLoad);
		}

		public void Exit()
		{
			
		}

		private void UnloadMenu(string name)
		{
			_fade.In(async () =>
			{
				await _sceneService.Unload(name);
                ReturnDataEvent?.Invoke();
                _state.Enter<LoadLevelState>();
			});
		}
	}
}
