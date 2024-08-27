using Codebase.Infrastructure;
using Codebase.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System;
using System.IO;

namespace Codebase.UI.Menu
{
	public class MainMenuPage : Page
    {
        public static event Action ReturnDataEvent;

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
			_loadGame.onClick.AddListener(() => _state.Enter<ContinueGameState, string>("MainMenu"));
			_settings.onClick.AddListener(() => _story.Push(_story.settings));
			_quit.onClick.AddListener(() => Application.Quit());

			_loadGame.interactable = File.Exists(Application.persistentDataPath + "/MyDiaryData.dat") &&
									 File.Exists(Application.persistentDataPath + "/MyInventoryData.dat") &&
									 File.Exists(Application.persistentDataPath + "/MyDiaryData.dat");

        }
        private void OnDestroy()
        {
            _newGame.onClick.RemoveAllListeners();
            _loadGame.onClick.RemoveAllListeners();
            _settings.onClick.RemoveAllListeners();
            _quit.onClick.RemoveAllListeners();
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