using Codebase.Services.Input;
using Codebase.UI.InventoryUI.Items;
using TMPro;
using UnityEngine;
using Zenject;

namespace Codebase.UI
{
    [RequireComponent(typeof(Fade))]
    public class Message : MonoBehaviour
    {
        private InputService _input;

        [SerializeField]
        private TMP_Text messageText;

        private bool _isActive=false;

        [Inject]
        private void Construct(InputService input)
        {
            _input = input;
        }

        private void Start()
        {
            MessageItem.ReadMessageEvent += TurnCanvas;
            GetComponent<CanvasGroup>().alpha = 0f;

        }
        private void OnDestroy()
        {
            MessageItem.ReadMessageEvent -= TurnCanvas;
        }

        private void TurnCanvas(string message)
        {
            if(_isActive)
            {
                _isActive = false;
                Hide();
            }
            else
            {
                _isActive = true;
                Show(message);
            }
        }
        private void Hide()
        {
            GetComponent<Fade>()?.Out(() => messageText.text = "");
            _input.ActivateDialogues();
            _input.ActivateUI();
            _input.DeactivateMessage();
        }
        private void Show(string message)
        {
            messageText.text = message;
            GetComponent<Fade>()?.In();
            _input.DeactivateDialogues();
            _input.DeactivateUI();
            _input.ActivateMessage();
        }
    }
}