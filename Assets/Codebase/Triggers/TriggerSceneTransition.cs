using Codebase.Infrastructure;
using Codebase.Infrastructure.States;
using Codebase.Services.Input;
using Codebase.Services.SceneLoader;
using Codebase.Triggers;
using Codebase.UI;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class TriggerSceneTransition : MonoBehaviour, ITriggerSceneTransition
{
	[SerializeField]
	private SceneTransitionData _sceneTransitionData;
	[SerializeField]
	private SpriteRenderer _interactionIcon;

	private GameStateMachine _state;
	private InputService _input;
	private Fade _fade;
	private SceneTransition _transition;

	public Collider2D Collider { get; set; }

	[Inject]
    private void Construct(GameStateMachine state, InputService input, Fade fade, SceneTransition transition)
    {
		_state = state;
		_input = input;
		_fade = fade;
		_transition = transition;
    }

	private void Start()
	{
		Collider = GetComponent<Collider2D>();

		_interactionIcon.DOFade(0f, 0f);
	}

	public void PlayerEntered(bool isPlayerInTrigger)
	{
		if (isPlayerInTrigger)
		{
			_interactionIcon.DOFade(1f, 0.3f);
		}
		else
		{
			_interactionIcon.DOFade(0f, 0.3f);
		}
	}

	public void Interact()
	{
		_transition.data = _sceneTransitionData;
		_input.Deactivate();

		_fade.In(() =>
		{
			_state.Enter<LoadLevelState>();
		});
	}
}
