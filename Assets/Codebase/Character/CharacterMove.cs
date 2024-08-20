using Codebase.Services.Input;
using Codebase.Services.SceneLoader;
using Codebase.Components;
using UnityEngine;
using Zenject;

namespace Codebase.Character
{
	public class CharacterMove : MonoBehaviour
	{
		[SerializeField]
		private float _movementSpeed;
		[SerializeField]
		private Animator _animator;

		[SerializeField] private CharacterPathComponent _path;
		private InputService _input;
		private Rigidbody2D _body2D;
        private SceneTransitionData _transition;

		[Inject]
		private void Construct(InputService input, CharacterPathComponent path, SceneTransitionData transition)
		{
			_input = input;
			_path = path;
			_transition = transition;
		}

		private void Start()
		{
			_body2D = GetComponent<Rigidbody2D>();
			MoveTo(_transition.point);
		}

		private void Update()
		{
			if (_input.IsMoving)
			{
				var direction = _input.Movement;
				transform.position = _path.GetPosition(_movementSpeed * direction.x * Time.deltaTime);
				transform.localScale = new Vector2(direction.x, transform.localScale.y);
			}
		}

		public void MoveTo(string name)
		{
			transform.position = _path.GetPointPosition(name);
		}
	}
}