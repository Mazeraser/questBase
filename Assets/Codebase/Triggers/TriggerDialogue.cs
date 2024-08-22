using System.Collections;
using Codebase.Libraries;
using Codebase.Services.Dialogue;
using Codebase.Services.Input;
using Codebase.Triggers;
using Codebase.UI;
using DG.Tweening;
using Fungus;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Codebase.Triggers
{
    public class TriggerDialogue : MonoBehaviour, ITriggerDialogueInteraction
    {
        [SerializeField]
        private string _messageToExecuteDialogue = "TestMessage";
        [SerializeField]
        private string _nextMessageToExecuteDialogue = "";
        [SerializeField]
        private SpriteRenderer _interactionIcon;

        public Flowchart Flowchart;
        public MenuDialog MenuDialog;
        public bool IsRepeatDialogue = true;

        private InputService _input;
        private IDialogueService _dialogueService;

        [SerializeField]private GameObject _sayDialogue;
        private DialogInput _inputDialogue;
        private Button _activeMenuButton;

        private bool isDialogueWas;
        private bool isNextMessageToExecuteDialogueWas;
        private bool _isDialogueInProcess;

        public Collider2D Collider { get; set; }

		[Inject]
        private void Construct(InputService input, IDialogueService dialogueService)
        {
            _input = input;
            _dialogueService = dialogueService;
        }

        private void Start()
        {
            _interactionIcon.DOFade(0f, 0f);
            
            _inputDialogue = _sayDialogue.GetComponent<DialogInput>();

            Collider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            if (_isDialogueInProcess)
            {
                _dialogueService.PhraseSliding();

                DialogueFinished();
            }
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
            if (isDialogueWas == false)
            {
                _input.Store();
                StartDialogue(_messageToExecuteDialogue);
                isNextMessageToExecuteDialogueWas = false;
                
                if (!IsRepeatDialogue)
                {
                    isDialogueWas = true;
                    Collider.enabled = false;
                }
            }
        }

        public void StartDialogue(string messageToExecuteDialogue)
        {
            _dialogueService.StartDialogue(Flowchart, messageToExecuteDialogue, _activeMenuButton, _inputDialogue, MenuDialog);
            
            StartCoroutine(ChangeInteraction());
        }

        public void DialogueFinished()
        {
            if (!_sayDialogue.activeSelf)
            {
                if (_nextMessageToExecuteDialogue != "" && !isNextMessageToExecuteDialogueWas)
                {
                    if (_input.SlidePhrasePressed)
                    {
                        StartDialogue(_nextMessageToExecuteDialogue);
                        isNextMessageToExecuteDialogueWas = true;
                    }
                }
                else
                {
                    _dialogueService.EndDialogue();
                    _isDialogueInProcess = false;
                    
                    /*if (IsItemInitilization && _isItemInitialized == false)
                    {
                        _isItemInitialized = true;
                        
                        GameObject newItem = GameObject.Instantiate(ItemPrefab, 
                            GameObject.FindGameObjectWithTag("InventoryContent").transform);

                        newItem.GetComponent<Item>().InitItemFromDictionary(ItemName);
                    }*/
                }
            }
        }

		private void OnDisable()
		{
			_dialogueService?.EndDialogue();
		}

		private IEnumerator ChangeInteraction()
        {
            yield return new WaitForSeconds(0.05f);

            _isDialogueInProcess = true;
        }
    }
}
