using System;
using Zenject;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Codebase.Services.Input
{
	public class InputService : IInitializable, IDisposable
	{
		private GameInput _input;

		private bool _isStored;

        private bool _storedGameplay;
        private bool _storedUI;
        private bool _storedDialogues;

        public InputService()
		{
			_input = new GameInput();
		}

		public void Initialize()
		{
			_input.Enable();

            ActivateGameplay();
            DeactivateUI();
            DeactivateDialogues();
        }

		public void Dispose()
		{
			_input.Disable();
		}

        public void Activate()
        {
            _input.Enable();
            Restore();
        }

        public void Deactivate()
        {
            Store();
            _input.Disable();
        }

        public void Store()
        {
            _storedGameplay = _input.Gameplay.enabled;
            _storedUI = _input.UI.enabled;
            _storedDialogues = _input.Dialogues.enabled;

            _isStored = true;
        }

        public void ActivateUI()
        {
            _input.UI.Enable();
        }
        public void ActivateGameplay()
        {
            _input.Gameplay.Enable();
        }
        public void ActivateDialogues()
        {
            _input.Dialogues.Enable();
        }

        public void DeactivateUI()
        {
            _input.UI.Disable();
        }
        public void DeactivateGameplay()
        {
            _input.Gameplay.Disable();
        }
        public void DeactivateDialogues()
        {
            _input.Dialogues.Disable();
        }

        public void Restore()
        {
            if (_isStored)
            {
                RestoreMap(_storedGameplay, _input.Gameplay.Get());
                RestoreMap(_storedUI, _input.UI.Get());
                RestoreMap(_storedDialogues, _input.Dialogues.Get());
            }

            void RestoreMap(bool isStored, InputActionMap map)
            {
                if (isStored)
                {
                    map.Enable();
                }
                else
                {
                    map.Disable();
                }
            }
        }

        public int ItemSlider => (int)_input.UI.ItemSlider.ReadValue<Vector2>().x;
        public bool OpenInventoryPressed => _input.Gameplay.OpenInventory.WasPressedThisFrame();
        public bool CloseInventoryPressed => _input.UI.CloseInventory.WasPressedThisFrame();
        public bool InteractPressed => _input.Gameplay.Interact.WasPressedThisFrame();
        public Vector2 Movement => _input.Gameplay.Movement.ReadValue<Vector2>();
		public bool IsMoving => _input.Gameplay.Movement.ReadValue<Vector2>().x != 0;
        public bool SlidePhrasePressed => _input.Dialogues.SlidePhrase.WasPressedThisFrame();
        public bool SlideAnswersPressed => _input.Dialogues.SlideAnswers.WasPressedThisFrame();
        public int SlideAnswers => (int)_input.Dialogues.SlideAnswers.ReadValue<Vector2>().y;
        public bool EnterAnswerPressed => _input.Dialogues.EnterAnswer.WasPressedThisFrame();
    }
}
