using Codebase.Infrastructure.States;
using Codebase.Services.Input;
using Codebase.UI.DiaryUI;
using Codebase.Services.QuestSystem.Quests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Codebase.UI
{
	public class GameplayMenu : MonoBehaviour
	{
		[SerializeField]
		private Canvas _canvas;
		[SerializeField]
		private CanvasGroup _group;
		[SerializeField]
		private Fade _menuFade;

		[SerializeField]
		private Button _continue;
		[SerializeField]
		private Button _exit;

		[SerializeField]
		private Page<Quest> _mainPage;

		private InputService _input;
		//private GameStateMachine _state;
		private Fade _fade;

		private bool _isClosed = true;
		private bool _isReady = true;

		[Inject]
		private void Construct(InputService input, Fade fade)//, GameStateMachine state
		{
			_input = input;
			//_state = state;
			_fade = fade;
		}

		private void Awake()
		{
			_canvas.enabled = false;
			_group.alpha = 0f;

			_continue.onClick.AddListener(() =>
			{
				Close();
			});

			_exit.onClick.AddListener(() =>
			{
				_fade.In(() =>
				{
					//_state.Enter<MainMenuState>();
					// TODO: move to default state
				});
			});
		}

		private void Update()
		{
			if (_input.OpenGameplayMenuPressed && _isReady)
			{
				if (_isClosed)
				{
					Open();	
				}
				else
				{
					Close();
				}
			}
		}

		private void Open()
		{
			_canvas.enabled = true;

			_isReady = false;
			_isClosed = false;

			_input.Store();
			_input.ActivateMenu();
			_input.DeactivateGameplay();
			_input.DeactivateUI();
			_input.DeactivateDialogues();

			_menuFade.In(() =>
			{
				_group.interactable = true;
				_isReady = true;
				_mainPage.ShowPage();
			});
		}

		public void Close()
		{
			_group.interactable = false;

			_isReady = false;
			_isClosed = true;

			_input.Restore();

			_menuFade.Out(() =>
			{
				_canvas.enabled = false;
				_isReady = true;
				_mainPage.HidePage();
            });
		}
	}
}