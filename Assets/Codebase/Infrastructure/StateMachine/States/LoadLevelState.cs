using Codebase.Infrastructure.States;
using Codebase.Services.Input;
using Codebase.Services.SceneLoader;
using Codebase.Services.SceneService;
using Codebase.UI;
using UnityEngine;

namespace Codebase.Infrastructure
{
	internal class LoadLevelState : IPayLoadedState
    {
        private readonly GameStateMachine _state;
        private readonly SceneService _sceneService;
        private readonly InputService _input;
        private LoadScreen _loadScreen;
        private Fade _fade;
        private SceneTransition _transition;

        public LoadLevelState(GameStateMachine stateMachine, SceneService sceneService, LoadScreen loadScreen, 
            Fade fade, SceneTransition transition)
        {
            _state = stateMachine;
            _sceneService = sceneService;
            _loadScreen = loadScreen;
            _fade = fade;
            _transition = transition;
        }

        public void Enter()
        {
            _loadScreen.Enable();

            _fade.Out(() =>
            {
                LoadScene(_transition.data);
            });
        }
        
        public void Exit()
        {
            
		}

        private async void LoadScene(SceneTransitionData data)
        {
            Debug.Log($"<color=yellow>Loading {data.sceneName} scene...</color>");
            _transition.scene = await _sceneService.Load(data.sceneName, false);

			_fade.In(() =>
			{
				_loadScreen.Disable();
				_state.Enter<DefaultState>();
			});
		}
	}
}