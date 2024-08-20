using Codebase.Services.Input;
using Codebase.Triggers;
using UnityEngine;
using Zenject;

namespace Codebase.Character
{
    public class CharacterTriggerInteraction : MonoBehaviour
    {
        private const string InteractionTriggerTag = "InteractionTrigger";

        private ITrigger _trigger;
        private InputService _input;

        [Inject]
        private void Construct(InputService input)
        {
            _input = input;
        }


        private void Update()
        {
            if (_trigger != null && _input.InteractPressed && _trigger.Collider.enabled)
            {
                _trigger.Interact();
            }
        }

        private void SetTrigger(Collider2D collision)
        {
            if (collision.CompareTag(InteractionTriggerTag))
            {

                ReturnTrigger(_trigger, false);

                _trigger = collision.GetComponent<ITrigger>();

                /*try
                {
                    _gameplayCanvasEventChecker.GetTrigger(collision.gameObject);
                }
                catch (NullReferenceException){
                    Debug.LogError("Inventory doesn't exist.");
                }*/
                ReturnTrigger(_trigger, true);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            SetTrigger(collision);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (_trigger == null)
                SetTrigger(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (_trigger != null && collision.name == _trigger.Collider.name)
            {
                ReturnTrigger(_trigger, false);

                _trigger = null;
            }
        }

        private void ReturnTrigger(ITrigger trigger, bool isPlayerEntered)
        {
            trigger?.PlayerEntered(isPlayerEntered);
        }
    }
}