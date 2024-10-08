﻿using Codebase.Services.SceneService;
using Codebase.UI;
using System;

namespace Codebase.Infrastructure.States
{
	public class NewGameState : IPayLoadedState<string>
	{
		public static event Action NewGameStarted;

		private readonly SceneService _sceneService;
		private readonly GameStateMachine _state;
		private Fade _fade;

		public NewGameState(GameStateMachine state, SceneService sceneService, Fade fade)
		{
			_state = state;
			_sceneService = sceneService;
			_fade = fade;
		}

		public void Enter(string payLoad)
		{
			UnloadMenu(payLoad);
			NewGameStarted?.Invoke();
		}

		public void Exit()
		{
			
		}

		private void UnloadMenu(string name)
		{
			_fade.In(async () =>
			{
				await _sceneService.Unload(name);
				_state.Enter<IntroState>();
			});
		}
	}
}
