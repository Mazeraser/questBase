using Codebase.Services.Input;
using Codebase.Services.SceneLoader;
using Codebase.Services.SceneService;
using Codebase.UI;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Codebase.Infrastructure.States
{
	public class DefaultState : IPayLoadedState
	{
		private readonly GameStateMachine _stateMachine;
		private readonly SceneService _sceneService;
		private Fade _fade;
		private SceneTransition _transition;
		private InputService _input;

		private SceneInstance _scene;

		public DefaultState(GameStateMachine stateMachine, SceneService sceneService, Fade fade, 
			SceneTransition transition, InputService input)
		{
			_stateMachine = stateMachine;
			_sceneService = sceneService;
			_fade = fade;
			_transition = transition;
			_input = input;
		}

		public async void Enter()
		{
			_scene = _transition.scene;
			_scene.ActivateAsync().completed += SetActiveScene;
			_input.Activate();
			await _fade.Out();
		}

		public void Exit()
		{
			UnloadScene();
			_scene.ActivateAsync().completed -= SetActiveScene;
		}

		private void SetActiveScene(AsyncOperation operation)
		{
			_sceneService.SetActiveScene(_scene.Scene);
		}

		private async void UnloadScene()
		{
			await _sceneService.Unload(_scene.Scene);
		}
	}
}
