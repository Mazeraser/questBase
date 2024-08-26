using Codebase.Infrastructure;
using Codebase.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Codebase.UI.Menu
{
	public class MainMenuPage : Page
	{
		[SerializeField]
		private Button _newGame;
		[SerializeField]
		private Button _loadGame;
		[SerializeField]
		private Button _settings;
		[SerializeField]
		private Button _quit;

		private readonly int _trigger = Animator.StringToHash("ToMain");
		private GameStateMachine _state;

		[Inject]
		private void Construct(GameStateMachine state)
		{
			_state = state;
		}

		private void Awake()
		{
			_newGame.onClick.AddListener(() => _state.Enter<NewGameState, string>("MainMenu"));
			//TODO: add loading saves
			_settings.onClick.AddListener(() => _story.Push(_story.settings));
			_quit.onClick.AddListener(() => Application.Quit());
		}

		public override void Open()
		{
			base.Open();
			InvokeTrigger(_trigger);
		}

		public override void Close()
		{
			base.Close();
		}
    }
}