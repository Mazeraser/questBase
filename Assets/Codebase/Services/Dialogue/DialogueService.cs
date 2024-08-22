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

        private const float StartButtonAlfa = 0.4f;
        private const float ChosenButtonAlfa = 1.0f;

        private InputService _input;

        private Button _activeMenuButton;
        private DialogInput _dialogInput;
        private SayDialog _sayDialog;
        private MenuDialog _menuDialogue;

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
        

        public void EndDialogue()
        {
            Debug.Log("Dialogue is ended");
            _input.Restore();
        }
    }
}