using System;
using Zenject;
using UnityEngine;

namespace Codebase.Services.Input
{
	public class InputService : IInitializable, IDisposable
	{
		private GameInput _input;

		private bool _isStored;

		public InputService()
		{
			_input = new GameInput();
		}

		public void Initialize()
		{
			_input.Enable();
        }

		public void Dispose()
		{
			_input.Disable();
		}

		public void Activate()
		{
			_input.Enable();
		}

		public void Deactivate()
		{
			_input.Disable();
		}

        public bool InteractPressed => _input.Gameplay.Interact.WasPressedThisFrame();
        public Vector2 Movement => _input.Gameplay.Movement.ReadValue<Vector2>();
		public bool IsMoving => _input.Gameplay.Movement.ReadValue<Vector2>().x != 0;
	}
}
