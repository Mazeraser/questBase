using Codebase.Services.Input;
using Fungus;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Codebase.Services.Dialogue
{
    public class DialogueService : IDialogueService
    {
        public static event Action<string> DialogueStartedEvent;

        private const float StartButtonAlfa = 0.8f;
        private const float ChosenButtonAlfa = 1.0f;

        private InputService _input;

        private Button _activeMenuButton;
        private DialogInput _dialogInput;
        private SayDialog _sayDialog;
        private MenuDialog _menuDialogue;

        private bool _isFirstSliding = true;
        //private bool _isChangeLine = true;
        private int _phraseIndex;

        [Inject]
        private void Construct(InputService input)
        {
            _input = input;
        }

        public void StartDialogue(Flowchart flowchart, string messageName, Button activeMenuButton, DialogInput dialogInput, MenuDialog menuDialog)
        {
            DialogueStartedEvent?.Invoke(messageName);
            Debug.Log($"{messageName} is started");

            _activeMenuButton = activeMenuButton;
            _dialogInput = dialogInput;
            _menuDialogue = menuDialog;

            _sayDialog = _dialogInput.gameObject.GetComponent<SayDialog>();

            _input.DeactivateGameplay();
            _input.DeactivateUI();
            _input.ActivateDialogues();

            flowchart.SendFungusMessage(messageName);
        }

        public void PhraseSliding()
        {
            if (_input.SlidePhrasePressed)
            {
                _dialogInput.SetNextLineFlag();
            }
        }
        
        public void SlidingAnswers()
        {
            if (_input.SlideAnswersPressed && _menuDialogue.IsActive())
            {
                if (_isFirstSliding)
                {
                    _activeMenuButton = _menuDialogue.CachedButtons[0];
                    _activeMenuButton.GetComponent<CanvasGroup>().alpha = ChosenButtonAlfa;

                    _isFirstSliding = false;
                }
                else
                {
                    _phraseIndex += _input.SlideAnswers;

                    if (_phraseIndex < 0)
                    {
                        _phraseIndex = _menuDialogue.DisplayedOptionsCount - 1;
                    }
                    else if (_phraseIndex == _menuDialogue.DisplayedOptionsCount)
                    {
                        _phraseIndex = 0;
                    }

                    if (_activeMenuButton)
                    {
                        _activeMenuButton.GetComponent<CanvasGroup>().alpha = StartButtonAlfa;
                    }

                    _activeMenuButton = _menuDialogue.CachedButtons[_phraseIndex];
                    _activeMenuButton.GetComponent<CanvasGroup>().alpha = ChosenButtonAlfa;
                }
            }
        }

        public void EnterTheAnswer()
        {
            if (_input.EnterAnswerPressed && _activeMenuButton)
            {
                _activeMenuButton.GetComponent<CanvasGroup>().alpha = StartButtonAlfa;
                _activeMenuButton.onClick.Invoke();
                _activeMenuButton = null;
            }
        }

        public void EndDialogue()
        {
            Debug.Log("Dialogue is ended");
            _input.Restore();
        }
    }
}