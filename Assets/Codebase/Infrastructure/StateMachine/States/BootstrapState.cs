using Codebase.Services.SceneService;

namespace Codebase.Infrastructure.States
{
    public class BootstrapState : IPayLoadedState
    {
        private const string BootScene = "Boot";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneService _sceneService;
        private LoadScreen _loadScreen;

        public BootstrapState(GameStateMachine stateMachine, SceneService sceneService, LoadScreen loadScreen)
        {
            _stateMachine = stateMachine;
			_sceneService = sceneService;
            _loadScreen = loadScreen;
        }

		public void Enter()
        {
            _sceneService.SetActiveScene(BootScene);
            //_loadScreen.Disable();
            _stateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {

		}
	}
}