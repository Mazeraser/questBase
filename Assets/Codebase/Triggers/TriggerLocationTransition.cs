using Codebase.Services.Input;
using Codebase.UI;
using Codebase.Triggers;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class TriggerLocationTransition : MonoBehaviour, ITrigger
{
	public event System.Func<UniTask> OnInteract;

	/*
	[SerializeField]
	private CharacterPathComponent _path;
	Don't using.*/ 
	[SerializeField]
	private string _pointName;
	[SerializeField]
	private string _locationName;
	[SerializeField]
	private SpriteRenderer _interactionIcon;
	[SerializeField]
	private float _transitionDuration=0;

	private CharacterComponent _character;
	private Fade _fade;
	private CameraComponent _camera;
	private InputService _input;

	public Collider2D Collider { get; set; }

	[Inject]
	private void Construct(CharacterComponent character, Fade fade, CameraComponent camera,
		InputService input)
	{
		_character = character;
		_fade = fade;
		_camera = camera;
		_input = input;
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

	[ContextMenu("Teleport")]
	public async void Interact()
	{
		_input.Deactivate();

		if (OnInteract != null)
		{
			await OnInteract.Invoke();
		}

		_fade.In(() =>
		{
			_character.CharacterMove.MoveTo(_pointName);
			_camera.SetDolly(_locationName, _character.transform);
			_input.Activate();
			_fade.Out();
		}, _transitionDuration);
	}
}
